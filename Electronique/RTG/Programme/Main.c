//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//
//¤¤¤              INCLUDES              ¤¤¤//
#include <htc.h>

#include "Definitions.h";
#include "SPI.h";
#include "MCP23S17.h";
#include "missionsMngt.h"
#include "playerInput.h";
#include "playerOutput.h";
#include "playerIO.h";
#include "EEPROM.h"
#include "Random.h"
//¤¤¤              INCLUDES              ¤¤¤//
//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//


__CONFIG(DEBUG_OFF & LVP_OFF & FCMEN_OFF & IESO_OFF & BOREN_OFF & CP_OFF & MCLRE_ON & PWRTE_OFF & WDTE_OFF & FOSC_INTRC_NOCLKOUT);



//======================================================================================
//> Met à jour la liste des joueurs participant
//> Si le bouton 'enter' est pressé et qu'un nombre suffisant de joueur est atteint,
//> retourne TRUE pour indiquer que la partie peut commencer, sinon retourne FALSE
//======================================================================================
BOOL updatePlayersWhoWantToPlay()
{
	for(char playerIndex = 0; playerIndex < MAX_NUMBER_OF_PLAYERS ; playerIndex++)
	{
		BOOL yesIsPressed, noIsPressed, selectIsPressed;
		getPlayerInputState(playerIndex, &yesIsPressed, &noIsPressed, &selectIsPressed);
		
		BOOL slotTaken = _playersSlotsStatus[playerIndex];
		
		if(!slotTaken && (yesIsPressed || selectIsPressed))
		{
			_numberOfRegisteredPlayers++;
			_playersSlotsStatus[playerIndex] = TRUE;
			setPlayerSelectLedState(playerIndex, SELECT_ON);
		}
		else if(slotTaken && (noIsPressed || selectIsPressed))
		{
			_numberOfRegisteredPlayers--;
			_playersSlotsStatus[playerIndex] = FALSE;
			setPlayerSelectLedState(playerIndex, SELECT_OFF);
		}
			
	}
	
	BOOL gameCanStart = FALSE;
	
	if(isEnterButtonPressed())
	{
		if(_numberOfRegisteredPlayers >= MIN_NUMBER_OF_PLAYERS)
		{
			char playerIndex = 0;
			for(char slotIndex = 0; slotIndex < MAX_NUMBER_OF_PLAYERS ; slotIndex++)
			{
				if(_playersSlotsStatus[slotIndex])
				{
					_players[playerIndex++].SlotIndex = slotIndex;
				}	
			}
			gameCanStart = TRUE;
		}	
		else
		{
			displayError(MIN_NUMBER_OF_PLAYERS, MISSION_BLUE);
		}	
	}	
		
	return gameCanStart;
}	

//======================================================================================
//> Permet d'afficher le nombre d'espions présents en fonction du nombre de joueurs
//> enregistrés
//======================================================================================
void dispNumSpiesForNumOfRegPlayers()
{
	char numSpiesForCurrentGame = NUM_SPIES_PER_NUM_PLAYERS[_numberOfRegisteredPlayers - MIN_NUMBER_OF_PLAYERS];
	
	for(char missionIndex = 0; missionIndex < numSpiesForCurrentGame ; missionIndex++)
	{
		setMissionLedColor(missionIndex, MISSION_RED);	
	}	
	
}	

//======================================================================================
//> Permet d'allumer les leds indiquant les joueurs les espions
//======================================================================================
void notifyPlayersSides()
{
	for(char playerIndex = 0; playerIndex < _numberOfRegisteredPlayers ; playerIndex++)
	{
		setPlayerSideLedState(_players[playerIndex].SlotIndex, _players[playerIndex].Side);
	}
}	

//======================================================================================
//> Permet d'eteindre toutes les leds indiquant les espions
//======================================================================================
void stopNotifyPlayersSides()
{
	for(char playerIndex = 0; playerIndex < _numberOfRegisteredPlayers ; playerIndex++)
	{
		setPlayerSideLedState(_players[playerIndex].SlotIndex, SIDE_LED_OFF);
	}		
}	

//======================================================================================
//> Permet d'assigner les espions de façon aléatoire
//======================================================================================
void assignSpiesAndFirstPlayerRand()
{
	char numOfSpiesRequired = NUM_SPIES_PER_NUM_PLAYERS[_numberOfRegisteredPlayers - 5];
	
	while(numOfSpiesRequired > 0)
	{
		char playerIndex = getRandomNumberBetweenZeroAnd(_numberOfRegisteredPlayers);
		
		if(_players[playerIndex].Side != SIDE_SPY)
		{
			_players[playerIndex].Side = SIDE_SPY;
			numOfSpiesRequired--;
		}	
	}	
	
	_currentLeaderIndex = getRandomNumberBetweenZeroAnd(_numberOfRegisteredPlayers);
	
	saveRandomNumberToFlash();
}	

//#########################################################################//
//### 							INTERRUPTION 							###//
//#########################################################################//
void interrupt tc_int(void)
{
	static UCHAR _blinkCounter = 0; 

	
	//Test si c'est le timer 0 qui à déclenché l'interruption
	if (T0IE && T0IF)
	{
		
		for(char iFilterIndex = 0; iFilterIndex < NUM_BUTTONS_FILTERED; iFilterIndex++)
		{
			
			if(_buttonsFilterCounters[iFilterIndex] != 0)
			{ _buttonsFilterCounters[iFilterIndex]--; }
		}	
		
		if(_blinkCounter > BLINK_FREQ)
		{
			_toggleBlink = !_toggleBlink; 
			_blinkCounter = 0; 
		}
		else
		{ _blinkCounter++; }
		
		//Reinitialise le flag d'interruption
		T0IF=0;
	}
}
	
//#########################################################################//
//### 							INTITIALISATIONS 						###//
//#########################################################################//

void initGlobalVariables()
{
	switchOffAllMissionLeds();
	
	_winnersIs = WINNER_NOT_YET;
	_numberOfRegisteredPlayers = 0;
	_numMissionsWonBySpies = 0;
	_numMissionsWonByResistance = 0;
	
	for(char playerIndex = 0; playerIndex < MAX_NUMBER_OF_PLAYERS ; playerIndex++)
	{
		_players[playerIndex].SlotIndex = MAX_NUMBER_OF_PLAYERS;
		_players[playerIndex].VoteStatus = NO_YET_VOTED;
		_players[playerIndex].Side = SIDE_RESISTANT;
	}	
}

//======================================================================================
//>
//======================================================================================
void initializeTimer0()
{
	//_______________________________________________________
	//> T0CS: TMR0 Clock Source Select bit
	//	1 = Transition on T0CKI pin
	//  0 = Internal instruction cycle clock (FOSC/4)
	T0CS = 0;
	
	//_______________________________________________________
	//> T0SE: TMR0 Source Edge Select bit
	//  1 = Increment on high-to-low transition on T0CKI pin
	//  0 = Increment on low-to-high transition on T0CKI pin
	T0SE = 0;
	
	//_______________________________________________________
	//> PSA: Prescaler Assignment bit
	//  1 = Prescaler is assigned to the WDT
	//  0 = Prescaler is assigned to the Timer0 module
	PSA = 0;
	
	//_______________________________________________________
	//> PS<2:0>: Prescaler Rate Select bits
	//	BIT VAL  	TMR0 RATE   	WDT RATE
	//	000			1 : 2			1 : 1
	//	001			1 : 4			1 : 2
	//	010			1 : 8			1 : 4
	//	011			1 : 16			1 : 8
	//	100			1 : 32			1 : 8
	//	101			1 : 64			1 : 32
	//	110			1 : 128			1 : 64
	//	111			1 : 256			1 : 128	
	PS0 = 1;
	PS1 = 1;
	PS2 = 1;
	
	
	T0IE = 1;
	T0IF=0;
}	

//======================================================================================
//>
//======================================================================================
void initializePortsDirections()
{
	
	//_________________________________________________
	//> Configuration du mode des PORTS
		
	//1 = PORT pin configured as an input (tri-stated)
	//0 	= PORTC pin configured as an output
	//Note 1: TRISC<1:0> always reads ‘1’ in LP Oscillator mode.

	ANSEL  = B8(00000000); 	//Port a en mode digital
	ANSELH = B8(00000000);	//Port b en mode digital (non analogique)
	
	//_________________________________________________
	//> Configuration de la direction des PORTS
	
	//RA0 -> RA2 : Sortie leds Mission 1
	//RA3 -> RA5 : Sortie leds Mission 2
	TRISA  = B8(00000000);
	
	//RA0 -> RA2 : Sortie leds Mission 4
	//RA3 -> RA5 : Sortie leds Mission 5
	//RA6 : Entrée bouton "Enter"
	//RA7 : Sortie led x2 espions pour échec mission
	TRISB  = B8(01000000);
	
	//RC0 -> RC2 : Sortie leds Mission 3
	//RC3 : Sortie SDI (SCK)
	//RC4 : Entree SDI (SI)
	//RC5 : Sortie SDI (SO)
	//RC6 : Sortie SDI (/CS)
	//RC7 : Sortie SDI (/RESET)
	TRISC  = B8(00010000);

	//_________________________________________________
	//> Initialisation de la valeur de sortie des PORTS
	PORTA  = B8(00000000);
	PORTB  = B8(00000000);
	PORTC  = B8(00000000);
}	

//======================================================================================
//> Réinitialise les votes des joueurs
//======================================================================================
void resetPlayersVotes()
{
	_numPlayerVotes = 0;
	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		setPlayerVoteLedColor(_players[playerIndex].SlotIndex, VOTE_OFF);
		_players[playerIndex].VoteStatus = NO_YET_VOTED;
	}		
}

//======================================================================================
//> Réinitialise les joueurs sélectionnés pour partir en mission
//======================================================================================
void resetSelectedPlayers()
{
	//Initialise les joueurs selectionnés pour la mission
	_numPlayersSelForCurMiss = 0;				

	for(char playerIndex = 0; playerIndex < _numberOfRegisteredPlayers ; playerIndex++)
	{
		setPlayerSelectLedState(_players[playerIndex].SlotIndex, SELECT_OFF);
		_players[playerIndex].IsSelectedForMission = FALSE;	
	}
}	

//======================================================================================
//> Initialise les votes et les sélections
//======================================================================================
void initVotesAndSelPlayers()
{
	resetPlayersVotes();
	resetSelectedPlayers();	
}	

//======================================================================================
//> Retourne le nombre minimum de votes d'échec de mission requis pour que la mission
//> courante puisse echouer
//======================================================================================
char getMinSpyVotesForCurMissDefeat()
{
	if(_currentMissionIndex == 3 && (_numberOfRegisteredPlayers>= 7 && _numberOfRegisteredPlayers <= MAX_NUMBER_OF_PLAYERS))
	{ return 2; }	
	else
	{ return 1; }	
}	

//======================================================================================
//> Permet d'incrémenter de façon circulaire l'index passé en argument
//======================================================================================
void getNextIndex(char *index, char maxIndexExcluded)
{
	(*index)++;
	if((*index) >= maxIndexExcluded)
	{
		(*index) = 0;
	}
}

//======================================================================================
//> Permet de décrémenter de façon circulaire l'index passé en argument
//======================================================================================
void getPrevIndex(char *index, char maxIndexExcluded)
{
	(*index)--;
	if((*index) >= maxIndexExcluded)
	{
		(*index) = maxIndexExcluded - 1;
	}
}

//======================================================================================
//> Initialise le début de la mission
//======================================================================================
void initCurrentMission()
{
	initVotesAndSelPlayers();
	
	//Reinitialise le compteur du nombre de fois que les missions consécutives n'ont pas été acceptées
	_numConsecMissNonAccepted = 0;
	
	//Allume la led de la mission courante
	setMissionLedColor(_currentMissionIndex, MISSION_BLUE);
	
	//Détermine le nombre d'espions attendus pour la mission courante
	_numPlayersExpectedForCurMiss = PLAYERS_PER_MISSION[_currentMissionIndex][_numberOfRegisteredPlayers - MIN_NUMBER_OF_PLAYERS];
	
	//Allume ou éteint la led qui indique si deux espions sont requis pour faire échouer la mission
	LED_TWO_SPY_MIN = (getMinSpyVotesForCurMissDefeat() > 1)? LED_ON: LED_OFF;
	
}	

//======================================================================================
//> Met à jour la liste des joueurs sélectionnés pour partir à la mission courante
//> Retourne TRUE si le nombre de joueurs requis pour la mission est atteint
//======================================================================================
BOOL updatePlayersSelectedForMiss()
{
	
	//___________________________________________
	//> Gestion clignottement du joueur actif
	static BOOL _ledToggled = FALSE;
	
	if(_toggleBlink != _ledToggled)
	{
		if(_toggleBlink == TRUE)
		{ setPlayerVoteLedColor(_players[_currentLeaderIndex].SlotIndex, VOTE_GREEN); }	
		else
		{ setPlayerVoteLedColor(_players[_currentLeaderIndex].SlotIndex, VOTE_OFF); }
		_ledToggled = _toggleBlink;
	}	
	
	//___________________________________________
	//> Detection des joueurs selectionnés
	for(char playerIndex = 0; playerIndex < _numberOfRegisteredPlayers; playerIndex++)
	{
		BOOL yesIsPressed, noIsPressed, selectIsPressed;
		getPlayerInputState(_players[playerIndex].SlotIndex, &yesIsPressed, &noIsPressed, &selectIsPressed);

		if(selectIsPressed)
		{	
			if(_players[playerIndex].IsSelectedForMission == TRUE)
			{
				_players[playerIndex].IsSelectedForMission = FALSE;
				setPlayerSelectLedState(_players[playerIndex].SlotIndex, SELECT_OFF);
				_numPlayersSelForCurMiss--;			
			}
			else
			{
				_players[playerIndex].IsSelectedForMission = TRUE;
				setPlayerSelectLedState(_players[playerIndex].SlotIndex, SELECT_ON);
				_numPlayersSelForCurMiss++;
			}		
		}	
	}
	
	if(isEnterButtonPressed())
	{
		if(_numPlayersSelForCurMiss == _numPlayersExpectedForCurMiss)
		{ return TRUE; }	
		else
		{ displayError(_numPlayersExpectedForCurMiss, MISSION_BLUE); }	
	}
	
	return FALSE;
		
}	

//======================================================================================
//> Fonction permettant de savoir si la majorité absolue a été atteinte dans les votes
//> pour la mission courante
//======================================================================================
BOOL isAbsoluteMajorityReached()
{
	char numVotesYesForMiss = 0;
	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		if(_players[playerIndex].VoteStatus == VOTE_YES)
		{
			numVotesYesForMiss++;
		}	
	}	
	
	if(numVotesYesForMiss >= VOTE_ABSOLUTE_MAJORITYS[_numberOfRegisteredPlayers - MIN_NUMBER_OF_PLAYERS])
	{ return TRUE; }		
	else
	{ return FALSE; }	
}

//======================================================================================
//> Met à jour les votes des joueurs
//> Retourne TRUE si tous les joueurs ont voté, sinon retourne FALSE
//======================================================================================
BOOL updatePlayersMissionVote()
{
	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		BOOL yesIsPressed, noIsPressed, selectIsPressed;
		getPlayerInputState(_players[playerIndex].SlotIndex, &yesIsPressed, &noIsPressed, &selectIsPressed);
		
		//Test si soit 'oui' soit 'non' a été pressé
		if(yesIsPressed != noIsPressed)
		{
			if(_players[playerIndex].VoteStatus == NO_YET_VOTED)
			{
				setPlayerVoteLedColor(_players[playerIndex].SlotIndex, VOTE_GREEN_RED);
				_numPlayerVotes++;
			}	
			
			if(yesIsPressed)
			{ _players[playerIndex].VoteStatus = VOTE_YES; }
			else
			{ _players[playerIndex].VoteStatus = VOTE_NO; }		
		}	
	}
	
	BOOL allPlayersHaveVoted = (_numPlayerVotes == _numberOfRegisteredPlayers)?TRUE:FALSE;
	
	if(allPlayersHaveVoted)
	{
		_absoluteMajorityReached = isAbsoluteMajorityReached();
		if(!_absoluteMajorityReached)
		{
			_numConsecMissNonAccepted++;
		}	
	}	
	
	
	return allPlayersHaveVoted;
}

//======================================================================================
//> Permet de passer au joueur suivant
//======================================================================================
void moveToNextLeader()
{
	getNextIndex(&_currentLeaderIndex, _numberOfRegisteredPlayers);
}

//======================================================================================
//> Permet de passer au joueur suivant
//======================================================================================
void moveToNextMission()
{
	_currentMissionIndex++;
}

//======================================================================================
//> Fonction permettant de mettre à jour le vote des joueurs quand au succès ou à 
//> l'échec de la mission en cours
//> Retourne TRUE si tous les joueurs partis en mission ont voté, sinon retourne FALSE
//======================================================================================
BOOL updatePlayersMissionStatus()
{
	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		if(_players[playerIndex].IsSelectedForMission)
		{
			BOOL yesIsPressed, noIsPressed, selectIsPressed;
			getPlayerInputState(_players[playerIndex].SlotIndex, &yesIsPressed, &noIsPressed, &selectIsPressed);
			
			//Test si soit 'oui' soit 'non' a été pressé
			if(yesIsPressed != noIsPressed)
			{
				if(_players[playerIndex].VoteStatus == NO_YET_VOTED)
				{ 
					setPlayerVoteLedColor(_players[playerIndex].SlotIndex, VOTE_GREEN_RED);				
					_numPlayerVotes++;
				}	

				//Met à jour le statut du vote pour l'échec ou la réussite de la mission				
				_players[playerIndex].VoteStatus = (yesIsPressed)?VOTE_MISSION_SUCCESS: VOTE_MISSION_DEFEAT;
			}	
		}	
	}	
	
	return (_numPlayerVotes == _numPlayersSelForCurMiss)?TRUE:FALSE;	
}	

//======================================================================================
//>
//======================================================================================
BOOL updateDisplayMissionStatus()
{

	static char _ledToggled = FALSE;
	
	if(_toggleBlink != _ledToggled)
	{
		
		getNextIndex(&_slotIndexForMissionResultAnim, MAX_NUMBER_OF_PLAYERS);
		
		char nbRedRemaining = _numSpiesWhoVotesForMissFailed;
		char nbGreenRemaining = _numPlayersSelForCurMiss - _numSpiesWhoVotesForMissFailed;

		switchOffAllVotePlayersLeds(); //Optionnel
		
		for(char cpt = 0; cpt < MAX_NUMBER_OF_PLAYERS; cpt++)
		{
			getNextIndex(&_slotIndexForMissionResultAnim, MAX_NUMBER_OF_PLAYERS);
			
			if(nbRedRemaining > 0)
			{
				setPlayerVoteLedColor(_slotIndexForMissionResultAnim, VOTE_RED);
				nbRedRemaining--;
			}
			else if(nbGreenRemaining > 0)
			{
				setPlayerVoteLedColor(_slotIndexForMissionResultAnim, VOTE_GREEN);
				nbGreenRemaining--;
			}	
			else
			{
				setPlayerVoteLedColor(_slotIndexForMissionResultAnim, VOTE_OFF);
			}	
		}

		_ledToggled = _toggleBlink;
	}
	
	if(isEnterButtonPressed())
	{
		switchOffAllVotePlayersLeds();
		return TRUE;
	}	
	else
	{
		return FALSE;
	}
	
}	

//======================================================================================
//>
//======================================================================================
BOOL isGameOver()
{
	if(_numMissionsWonBySpies >= NUM_MISSIONS_TO_WIN || _numConsecMissNonAccepted >= NUM_NON_ACCEPT_CONSEC_MISS_GAMEOVER)
	{
		_winnersIs = WINNER_IS_SPIES;
		return TRUE;
	}	
	else if(_numMissionsWonByResistance >= NUM_MISSIONS_TO_WIN)
	{
		_winnersIs = WINNER_IS_RESISTANCE;
		return TRUE;
	}
	else
	{
		_winnersIs = WINNER_NOT_YET;
		return FALSE;
	}		
}	

//======================================================================================
//>
//======================================================================================
void displayGameOver()
{

	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		char playerSide =_players[playerIndex].Side;
		char playerSideColor =  (playerSide == SIDE_RESISTANT)? VOTE_GREEN : VOTE_RED;
		
		if(playerSide == _winnersIs)
		{
			if(_toggleBlink)
			{ setPlayerVoteLedColor(_players[playerIndex].SlotIndex, playerSideColor); }	
			else
			{ setPlayerVoteLedColor(_players[playerIndex].SlotIndex, VOTE_OFF); }
		}
		else
		{
			setPlayerVoteLedColor(_players[playerIndex].SlotIndex, playerSideColor);
		}	
	}	
}	

//======================================================================================
//> Initialise l'état permettant d'indiquer le camps de chaque joueur
//======================================================================================
void enterStateNotifyPlayerSides()
{
	assignSpiesAndFirstPlayerRand();
	
	switchOffAllSelPlayersLeds();
	
	dispNumSpiesForNumOfRegPlayers();
	
	notifyPlayersSides();
	
	_gameState = GAMESTATE_NOTIFY_PLAYER_SIDES;	
}	


//======================================================================================
//> Initialise l'état d'attente de selection des joueurs par le leader
//======================================================================================
void enterStateLeaderSelectPlayers()
{
	resetSelectedPlayers();
	
	char playerIndexTmp = _currentLeaderIndex;
	
	for(char i = 0; i <= _numConsecMissNonAccepted; i++)
	{
		setPlayerVoteLedColor(_players[playerIndexTmp].SlotIndex, VOTE_GREEN);
		getPrevIndex(&playerIndexTmp, _numberOfRegisteredPlayers);
	}	
	
	_gameState = GAMESTATE_WAIT_LEADER_SELECT_PLAYERS;	
}	

//======================================================================================
//> Initialise l'état d'attente des votes des joueurs pour savoir si la mission
//> courante peut partir avec les personnes sélectionnées 
//======================================================================================
void enterStateWaitMissionVotes()
{
	resetPlayersVotes();
	_gameState = GAMESTATE_WAIT_MISSION_VOTE;	
}

//======================================================================================
//> Initialise l'état d'affichage des résultats des votes
//======================================================================================
void enterStateDispVoteResults()
{
	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		setPlayerVoteLedColor(_players[playerIndex].SlotIndex, _players[playerIndex].VoteStatus);
	}
	
	_gameState = GAMESTATE_DISP_VOTE_RESULTS;	
}

//======================================================================================
//> Initialise l'état de départ de la mission avec les joueurs sélectionnés
//======================================================================================
void enterStatePlayMission()
{
	resetPlayersVotes();	
	_gameState = GAMESTATE_PLAY_MISSION;		
}	

//======================================================================================
//> Affiche le statut de la mission:
//> _ Détermine si la mission est gagnée par les résistants ou les espions
//> _ Allume la led de mission selon le camps remportant la mission
//======================================================================================
void enterStateDisplayMissionResult()
{
	_numSpiesWhoVotesForMissFailed = 0;
	
	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		if(_players[playerIndex].Side == SIDE_SPY && _players[playerIndex].VoteStatus == VOTE_MISSION_DEFEAT )
		{
			_numSpiesWhoVotesForMissFailed ++;
		}	
	}	
	
	if(_numSpiesWhoVotesForMissFailed >= getMinSpyVotesForCurMissDefeat())
	{
		_numMissionsWonBySpies++;
		setMissionLedColor(_currentMissionIndex, MISSION_RED);
	}
	else
	{
		_numMissionsWonByResistance++;
		setMissionLedColor(_currentMissionIndex, MISSION_GREEN);
	}
	
	_slotIndexForMissionResultAnim = _players[_currentLeaderIndex].SlotIndex;
	
	_gameState = GAMESTATE_DISP_MISSION_RESULT;
}	

//======================================================================================
//> Initialise l'état de game over
//======================================================================================
void enterStateGameOver()
{
	_gameState = GAMESTATE_GAMEOVER;
}	

//######################################################################################################################//
//###                                               ROUTINE PRINCIPALE                                               ###//
//######################################################################################################################//
main(void)
{
	//Initialisation des variables globales
	initGlobalVariables();
	
	//Initialisation de la direction des ports
	initializePortsDirections();
	
	//Reset le Port Expandeur (Cette action n'emet rien sur la liaison SPI)
	MCP23S17_Reset();
	
	//Configure le PIC pour permettre la com SPI
	SPI_Init();
	
	//Initialie le Port Expandeur
	MCP23S17_Setup();

	//Initialise l'accès à l'EEPROM
	setupEEPROM();

	//===================

	initializeTimer0();
	
	//enable global interrupts
	GIE = 1;
	
	//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//
	//¤¤¤ BOUCLE SANS FIN ¤¤¤//
	while(TRUE)
	{
		
		switch(_gameState)
		{
			case GAMESTATE_WAIT_FOR_PLAYERS:
				if(updatePlayersWhoWantToPlay())
				{
					enterStateNotifyPlayerSides();
				}
				
				break;
			case GAMESTATE_NOTIFY_PLAYER_SIDES: 
				if(isEnterButtonPressed())
				{
					switchOffAllMissionLeds();
					stopNotifyPlayersSides();
					initCurrentMission();
					enterStateLeaderSelectPlayers();
				}	
				
				break;
			case GAMESTATE_WAIT_LEADER_SELECT_PLAYERS:
				if(updatePlayersSelectedForMiss())
				{
					enterStateWaitMissionVotes();
				}	
				
				break;
				
			case GAMESTATE_WAIT_MISSION_VOTE:
			
				if(updatePlayersMissionVote())
				{
					if(isGameOver())
					{ enterStateGameOver(); }	
					else
					{ enterStateDispVoteResults(); }
				}	
				
				break;
			case GAMESTATE_DISP_VOTE_RESULTS:
				if(isEnterButtonPressed())
				{
					if(_absoluteMajorityReached)
					{
						enterStatePlayMission();
					}	
					else
					{
						moveToNextLeader();
						initVotesAndSelPlayers();
						enterStateLeaderSelectPlayers();
					}
				}
				
				break;
			case GAMESTATE_PLAY_MISSION:
				if(updatePlayersMissionStatus())
				{
					if(isGameOver())
					{ enterStateGameOver(); }
					else
					{ enterStateDisplayMissionResult(); }	
				}	
			
				break;
			case GAMESTATE_DISP_MISSION_RESULT:
								
				if(updateDisplayMissionStatus())
				{
					moveToNextLeader();
					moveToNextMission();
					initCurrentMission();
					enterStateLeaderSelectPlayers();
				}
					
				break;
			case GAMESTATE_GAMEOVER:
				
				displayGameOver();
				
				break;
			
		}	
		

	}
	//¤¤¤ BOUCLE SANS FIN ¤¤¤//
	//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//

	
}




	