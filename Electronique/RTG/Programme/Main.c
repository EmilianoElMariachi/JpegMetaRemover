//いいいいいいいいいいいいいいいいいいいいい//
//い�              INCLUDES              い�//
#include <htc.h>
#include <pic16f882.h>

#include "Definitions.h";
#include "SPI.h";
#include "MCP23S17.h";
#include "missionsMngt.h"
#include "playerInput.h";
#include "playerOutput.h";
#include "playerIO.h";
#include "EEPROM.h"
#include "Random.h"
//い�              INCLUDES              い�//
//いいいいいいいいいいいいいいいいいいいいい//


__CONFIG(DEBUG_OFF & LVP_OFF & FCMEN_OFF & IESO_OFF & BOREN_OFF & CP_OFF & MCLRE_ON & PWRTE_OFF & WDTE_OFF & FOSC_INTRC_NOCLKOUT);



//======================================================================================
//> Met � jour la liste des joueurs participant
//======================================================================================
void updatePlayersWhoWantToPlay()
{
	for(char playerIndex = 0; playerIndex < MAX_NUMBER_OF_PLAYERS ; playerIndex++)
	{
		BOOL yesIsPressed, noIsPressed, selectIsPressed;
		getPlayerInputState(playerIndex, &yesIsPressed, &noIsPressed, &selectIsPressed);
		
		if(yesIsPressed || selectIsPressed)
		{
			if(_playersSlotsStatus[playerIndex] == FALSE)
			{
				_numberOfRegisteredPlayers++;
				_playersSlotsStatus[playerIndex] = TRUE;
				setPlayerSelectLedState(playerIndex, SELECT_ON);
			}
		}
		else if(noIsPressed)
		{
			if(_playersSlotsStatus[playerIndex] == TRUE)
			{
				_numberOfRegisteredPlayers--;
				_playersSlotsStatus[playerIndex] = FALSE;
				setPlayerSelectLedState(playerIndex, SELECT_OFF);
			}	
		}		
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
//> Permet d'assigner les espions de fa�on al�atoire
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
	
	_currentPlayerIndex = getRandomNumberBetweenZeroAnd(_numberOfRegisteredPlayers);
	
	saveRandomNumberToFlash();
}	

//======================================================================================
//> Si le bouton 'enter' est press� et qu'un nombre suffisant de joueur est pr�sent,
//> alors la partie peut commencer
//======================================================================================
BOOL canGameStart()
{
	if(_numberOfRegisteredPlayers >= MIN_NUMBER_OF_PLAYERS && isEnterButtonPressed())
	{
		char playerIndex = 0;
		for(char slotIndex = 0; slotIndex < MAX_NUMBER_OF_PLAYERS ; slotIndex++)
		{
			if(_playersSlotsStatus[slotIndex])
			{
				_players[playerIndex++].SlotIndex = slotIndex;
			}	
		}
		
		return TRUE;
	}	
	else
	{
		return FALSE;
	}	
}	

//#########################################################################//
//### 							INTERRUPTION 							###//
//#########################################################################//
void interrupt tc_int(void)
{
	static UCHAR _blinkCounter = 0; 

	
	//Test si c'est le timer 0 qui � d�clench� l'interruption
	if (T0IE && T0IF)
	{
		//Changer les variables globales ICI
		if(_enterButtonFilterCounter != 0)
		{ _enterButtonFilterCounter--; }
		
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
	//Note 1: TRISC<1:0> always reads �1� in LP Oscillator mode.

	ANSEL  = B8(00000000); 	//Port a en mode digital
	ANSELH = B8(00000000);	//Port b en mode digital (non analogique)
	
	//_________________________________________________
	//> Configuration de la direction des PORTS
	
	//RA0 -> RA2 : Sortie leds Mission 1
	//RA3 -> RA5 : Sortie leds Mission 2
	TRISA  = B8(00000000);
	
	//RA0 -> RA2 : Sortie leds Mission 4
	//RA3 -> RA5 : Sortie leds Mission 5
	//RA6 : Entr�e bouton "Enter"
	TRISB  = B8(11000000);
	
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
	PORTB  = B8(00000000);
}	

//======================================================================================
//> R�initialise les votes des joueurs
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
//> R�initialise les joueurs s�lectionn�s pour partir en mission
//======================================================================================
void resetSelectedPlayers()
{
	//Initialise les joueurs selectionn�s pour la mission
	_numPlayersSelForCurMiss = 0;				

	for(char playerIndex = 0; playerIndex < _numberOfRegisteredPlayers ; playerIndex++)
	{
		setPlayerSelectLedState(_players[playerIndex].SlotIndex, SELECT_OFF);
		_players[playerIndex].IsSelectedForMission = FALSE;	
	}
}	

//======================================================================================
//> Initialise le d�but de la mission
//======================================================================================
void initCurrentMission()
{
	
	resetPlayersVotes();

	resetSelectedPlayers();
	
	//Allume la mission courante � l'�tat en cours
	setMissionLedColor(_currentMissionIndex,MISSION_BLUE);
	
	//D�termine le nombre d'espions attendus pour la mission courante
	_numPlayersExpectedForCurMiss = PLAYERS_PER_MISSION[_currentMissionIndex][_numberOfRegisteredPlayers - MIN_NUMBER_OF_PLAYERS];
}	

//======================================================================================
//>
//======================================================================================
void updatePlayersSelectedForMiss()
{
	
	//___________________________________________
	//> Gestion clignottement du joueur actif
	static BOOL _ledToggled = FALSE;
	
	if(_toggleBlink != _ledToggled)
	{
		if(_toggleBlink == TRUE)
		{ setPlayerVoteLedColor(_players[_currentPlayerIndex].SlotIndex, VOTE_GREEN); }	
		else
		{ setPlayerVoteLedColor(_players[_currentPlayerIndex].SlotIndex, VOTE_OFF); }
		_ledToggled = _toggleBlink;
	}	
	
	//___________________________________________
	//> Detection des joueurs selectionn�s
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
}	

//======================================================================================
//> Retourne TRUE si le nombre de joueurs requis pour la mission est atteint
//======================================================================================
BOOL canVoteForMission()
{
	if(isEnterButtonPressed())
	{
		if(_numPlayersSelForCurMiss == _numPlayersExpectedForCurMiss)
		{ return TRUE; }	
		else
		{
			 displayError(_numPlayersExpectedForCurMiss, MISSION_BLUE);
			 displayError(_numPlayersSelForCurMiss, MISSION_RED);
		}	
	}
	
	return FALSE;
}

//======================================================================================
//> Met � jour les votes des joueurs
//======================================================================================
void updatePlayersMissionVote()
{
	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		BOOL yesIsPressed, noIsPressed, selectIsPressed;
		getPlayerInputState(_players[playerIndex].SlotIndex, &yesIsPressed, &noIsPressed, &selectIsPressed);
		
		//Test si soit 'oui' soit 'non' a �t� press�
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
}

//======================================================================================
//> Permet de savoir si les r�sultats de vote peuvent �tre affich�s (si tout le monde �
//> vot�)
//======================================================================================
BOOL canDisplayVoteResults()
{
	return (_numPlayerVotes == _numberOfRegisteredPlayers)?TRUE:FALSE;
}	

//======================================================================================
//>
//======================================================================================
void displayVoteResults()
{
	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		setPlayerVoteLedColor(_players[playerIndex].SlotIndex, _players[playerIndex].VoteStatus);
	}	
}	

//======================================================================================
//>
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
//> Permet de passer au joueur suivant
//======================================================================================
void moveToNextPlayer()
{
	_currentPlayerIndex ++;
	if(_currentPlayerIndex >= _numberOfRegisteredPlayers)
	{
		_currentPlayerIndex = 0;
	}	
}

//======================================================================================
//> Permet de passer au joueur suivant
//======================================================================================
void moveToNextMission()
{
	_currentMissionIndex++;
}

//======================================================================================
//>
//======================================================================================
void updatePlayersMissionStatus()
{
	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		if(_players[playerIndex].IsSelectedForMission)
		{
			BOOL yesIsPressed, noIsPressed, selectIsPressed;
			getPlayerInputState(_players[playerIndex].SlotIndex, &yesIsPressed, &noIsPressed, &selectIsPressed);
			
			//Test si soit 'oui' soit 'non' a �t� press�
			if(yesIsPressed != noIsPressed)
			{
				if(_players[playerIndex].VoteStatus == NO_YET_VOTED)
				{ 
					setPlayerVoteLedColor(_players[playerIndex].SlotIndex, VOTE_GREEN_RED);				
					_numPlayerVotes++; 
				}	
				
				if((_players[playerIndex].Side == SIDE_RESISTANT) || yesIsPressed)
				{
					_players[playerIndex].VoteStatus = VOTE_MISSION_SUCCESS;
				}	
				else
				{
					_players[playerIndex].VoteStatus = VOTE_MISSION_DEFEAT;		
				}	
			}	
		}	
	}		
}	

//======================================================================================
//> Retourne TRUE si tous les joueurs partis en mission ont vot�, sinon retourne FALSE
//======================================================================================
BOOL canDisplayMissionStatus()
{
	return (_numPlayerVotes == _numPlayersSelForCurMiss)?TRUE:FALSE;
}	

//======================================================================================
//> Retourne le nombre minimum de votes d'�chec de mission requis pour que la mission
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
//> Affiche le statut de la mission
//======================================================================================
void displayMissionStatus()
{
	char numVotesMissDefeat = 0;
	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		if(_players[playerIndex].VoteStatus == VOTE_MISSION_DEFEAT)
		{
			numVotesMissDefeat++;
		}	
	}	
	
	if(numVotesMissDefeat >= getMinSpyVotesForCurMissDefeat())
	{
		_numMissionsWonBySpies++;
		setMissionLedColor(_currentMissionIndex, MISSION_RED);
	}
	else
	{
		_numMissionsWonByResistance++;
		setMissionLedColor(_currentMissionIndex, MISSION_GREEN);
	}	
}	

//======================================================================================
//>
//======================================================================================
BOOL isGameOver()
{
	if(_numMissionsWonBySpies >= NUM_MISSIONS_TO_WIN || _numMissionsWonByResistance >= NUM_MISSIONS_TO_WIN)
	{
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

	//Initialise l'acc�s � l'EEPROM
	setupEEPROM();

	//===================

	initializeTimer0();
	
	//enable global interrupts
	GIE = 1;
	
	while(TRUE)
	{
		
		switch(_gameState)
		{
			case GAMESTATE_WAIT_FOR_PLAYERS:

				updatePlayersWhoWantToPlay();
				
				if(canGameStart())
				{
					assignSpiesAndFirstPlayerRand();
					notifyPlayersSides();
					switchOffAllSelPlayersLeds();
					_gameState = GAMESTATE_NOTIFY_PLAYER_SIDES;
				}
				
				break;
			case GAMESTATE_NOTIFY_PLAYER_SIDES: 
				if(isEnterButtonPressed())
				{
					stopNotifyPlayersSides();
					initCurrentMission();
					_gameState = GAMESTATE_WAIT_CUR_PLAYER_SELECT_PLAYERS;
				}	
				
				break;
			case GAMESTATE_WAIT_CUR_PLAYER_SELECT_PLAYERS:
			
				updatePlayersSelectedForMiss();
				
				if(canVoteForMission())
				{
					resetPlayersVotes();
					_gameState = GAMESTATE_WAIT_MISSION_VOTE;	
				}	
				
				break;
				
			case GAMESTATE_WAIT_MISSION_VOTE:
			
				updatePlayersMissionVote();
				
				if(canDisplayVoteResults())
				{
					displayVoteResults();
					_gameState = GAMESTATE_DISP_VOTE_RESULTS;	
				}	
				
				break;
			case GAMESTATE_DISP_VOTE_RESULTS:
				if(isEnterButtonPressed())
				{
					if(isAbsoluteMajorityReached())
					{
						resetPlayersVotes();	
						_gameState = GAMESTATE_PLAY_MISSION;		
					}	
					else
					{
						moveToNextPlayer();
						initCurrentMission();
						_gameState = GAMESTATE_WAIT_CUR_PLAYER_SELECT_PLAYERS;
					}
				}
				
				break;
			case GAMESTATE_PLAY_MISSION:
				updatePlayersMissionStatus();
				
				if(canDisplayMissionStatus())
				{
					displayMissionStatus();
					
					if(isGameOver())
					{ _gameState = GAMESTATE_GAMEOVER; }
					else
					{ _gameState = GAMESTATE_DISP_MISSION_RESULT; }	
				}	
			
				break;
			case GAMESTATE_DISP_MISSION_RESULT:
								
				if(isEnterButtonPressed())
				{
					moveToNextPlayer();
					moveToNextMission();
					initCurrentMission();
					
					_gameState = GAMESTATE_WAIT_CUR_PLAYER_SELECT_PLAYERS;
				}	
				break;
				
			case GAMESTATE_GAMEOVER:
				
				break;
			
		}	
		

	}
	
	
}




	