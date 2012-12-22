//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//
//¤¤¤              INCLUDES              ¤¤¤//
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
//¤¤¤              INCLUDES              ¤¤¤//
//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//


__CONFIG(DEBUG_OFF & LVP_OFF & FCMEN_OFF & IESO_OFF & BOREN_OFF & CP_OFF & MCLRE_ON & PWRTE_OFF & WDTE_OFF & FOSC_INTRC_NOCLKOUT);



//======================================================================================
//> Met à jour la liste des joueurs participant
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
		setPlayerSide(_players[playerIndex].PlayerSlotIndex, _players[playerIndex].Side);
	}
}	

//======================================================================================
//> Permet d'eteindre toutes les leds indiquant les espions
//======================================================================================
void stopNotifyPlayersSides()
{
	for(char playerIndex = 0; playerIndex < _numberOfRegisteredPlayers ; playerIndex++)
	{
		setPlayerSide(_players[playerIndex].PlayerSlotIndex, RESISTANT);
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
		
		if(_players[playerIndex].Side != SPY)
		{
			_players[playerIndex].Side = SPY;
			numOfSpiesRequired--;
		}	
	}	
	
	_currentPlayerIndex = getRandomNumberBetweenZeroAnd(_numberOfRegisteredPlayers);
	
	saveRandomNumberToFlash();
}	

//======================================================================================
//> Si le bouton 'enter' est pressé et qu'un nombre suffisant de joueur est présent,
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
				_players[playerIndex++].PlayerSlotIndex = slotIndex;
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

	
	//Test si c'est le timer 0 qui à déclenché l'interruption
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
	for(char playerIndex = 0; playerIndex < MAX_NUMBER_OF_PLAYERS ; playerIndex++)
	{
		_players[playerIndex].PlayerSlotIndex = MAX_NUMBER_OF_PLAYERS;
		_players[playerIndex].VoteStatus = NO_VOTE;
		_players[playerIndex].Side = RESISTANT;
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
//> Initialise le début de la mission
//======================================================================================
void initCurrentMission()
{
	//Initialise les joueurs selectionnés pour la mission
	_numPlayersSelForCurMiss = 0;
	
	//Allume la mission courante à l'état en cours
	setMissionState(_currentMissionIndex,MISSION_BLUE);
	
	//Détermine le nombre d'espions attendus pour la mission courante
	_numSpiesExpectedForCurMiss = SPIES_PER_MISSION[_currentMissionIndex][_numberOfRegisteredPlayers - MIN_NUMBER_OF_PLAYERS];
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
		{ setPlayerVoteLedColor(_players[_currentPlayerIndex].PlayerSlotIndex, VOTE_GREEN); }	
		else
		{ setPlayerVoteLedColor(_players[_currentPlayerIndex].PlayerSlotIndex, VOTE_OFF); }
		_ledToggled = _toggleBlink;
	}	
	
	//___________________________________________
	//> Detection des joueurs selectionnés
	for(char playerIndex = 0; playerIndex < _numberOfRegisteredPlayers; playerIndex++)
	{
		char slotIndex = _players[playerIndex].PlayerSlotIndex;
		
		BOOL yesIsPressed, noIsPressed, selectIsPressed;
		getPlayerInputState(slotIndex, &yesIsPressed, &noIsPressed, &selectIsPressed);

		if(selectIsPressed)
		{	
			
			if(_players[playerIndex].PlayerSelectedForMission == SELECTED)
			{
				_players[playerIndex].PlayerSelectedForMission = NOT_SELECTED;
				setPlayerSelectLedState(slotIndex, SELECT_OFF);
				_numPlayersSelForCurMiss--;			
			}
			else
			{
				_players[playerIndex].PlayerSelectedForMission = SELECTED;
				setPlayerSelectLedState(slotIndex, SELECT_ON);
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
		if(_numPlayersSelForCurMiss == _numSpiesExpectedForCurMiss)
		{ return TRUE; }	
		else
		{ displayError(_numSpiesExpectedForCurMiss, MISSION_BLUE); }	
	}
	
	return FALSE;
}

//======================================================================================
//> Réinitialise les votes des joueurs
//======================================================================================
void resetPlayersVotes()
{
	_numPlayerVotes = 0;
	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		_players[playerIndex].VoteStatus = NO_VOTE;
	}		
}	

//======================================================================================
//> Met à jour les votes des joueurs
//======================================================================================
void updatePlayersMissionVote()
{
	for(char playerIndex = 0; playerIndex <  _numberOfRegisteredPlayers ; playerIndex++)
	{
		struct Player player = _players[playerIndex];
		char slotIndex = player.PlayerSlotIndex;
		
		BOOL yesIsPressed, noIsPressed, selectIsPressed;
		getPlayerInputState(slotIndex, &yesIsPressed, &noIsPressed, &selectIsPressed);
		
		//Test si soit 'oui' soit 'non' a été pressé
		if(yesIsPressed != noIsPressed)
		{
			if(player.VoteStatus == NO_VOTE)
			{
				setPlayerVoteLedColor(slotIndex, VOTE_GREEN_RED);
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
//> Permet de savoir si les résultats de vote peuvent être affichés (si tout le monde à
//> voté)
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
		struct Player player = _players[playerIndex];
		setPlayerVoteLedColor(player.PlayerSlotIndex, player.VoteStatus);
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

	//Initialise l'accès à l'EEPROM
	setupEEPROM();

	//===================

	initializeTimer0();
	
	//enable global interrupts
	GIE = 1;
	
	while(TRUE)
	{
			
		switch(_gameState)
		{
			case WAIT_FOR_PLAYERS:

				updatePlayersWhoWantToPlay();
				
				if(canGameStart())
				{
					assignSpiesAndFirstPlayerRand();
					notifyPlayersSides();
					switchOffAllSelPlayersLeds();
					_gameState = NOTIFY_PLAYER_SIDES;
				}
				
				break;
			case NOTIFY_PLAYER_SIDES: 
				if(isEnterButtonPressed())
				{
					stopNotifyPlayersSides();
					initCurrentMission();
					_gameState = WAIT_CUR_PLAYER_SELECT_PLAYERS;
				}	
				
				break;
			case WAIT_CUR_PLAYER_SELECT_PLAYERS:
			
				updatePlayersSelectedForMiss();
				
				if(canVoteForMission())
				{
					resetPlayersVotes();
					_gameState = WAIT_MISSION_VOTE;	
				}	
				
				break;
				
			case WAIT_MISSION_VOTE:
			
				updatePlayersMissionVote();
				
				if(canDisplayVoteResults())
				{
					displayVoteResults();
					_gameState = DISP_VOTE_RESULTS;	
				}	
				
				break;

		}	
		

	}
	
	
}




	