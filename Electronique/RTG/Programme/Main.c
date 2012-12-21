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
#define _XTAL_FREQ 8000000	//Oscillateur interne cadencé à 8 Mhz




//======================================================================================
//>
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
				setPlayerSelectionState(playerIndex, SELECTED);
			}
		}
		else if(noIsPressed)
		{
			if(_playersSlotsStatus[playerIndex] == TRUE)
			{
				_numberOfRegisteredPlayers--;
				_playersSlotsStatus[playerIndex] = FALSE;
				setPlayerSelectionState(playerIndex, NOT_SELECTED);
			}	
		}		
	}
}	

//======================================================================================
//>
//======================================================================================
BOOL canGameStart()
{
	if(isEnterButtonPressed() && _numberOfRegisteredPlayers >= MIN_NUMBER_OF_PLAYERS)
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
	if (T0IE && T0IF)
	{
		//Changer le variables globales ICI
		
		T0IF=0;
	}
}
	
//#########################################################################//
//### 							INTITIALISATIONS 						###//
//#########################################################################//

void initGlobalVariables()
{
	_gameState = WAITING_FOR_PLAYERS;
	_numberOfRegisteredPlayers = 0;
	for(char playerIndex = 0; playerIndex < MAX_NUMBER_OF_PLAYERS ; playerIndex++)
	{
		_players[playerIndex].PlayerSlotIndex = -1;
		_players[playerIndex].VoteStatus = NO_VOTE;
		_players[playerIndex].IsSpy = FALSE;
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
//>
//======================================================================================
void displayButtonPressedAEffacer()
{
	for(char playerIndex = 0; playerIndex < MAX_NUMBER_OF_PLAYERS; playerIndex++)
	{
		BOOL yesIsPressed, noIsPressed, selectIsPressed;
		getPlayerInputState(playerIndex, &yesIsPressed, &noIsPressed, &selectIsPressed);
		
		
		if(selectIsPressed == TRUE)
		{
			setPlayerSelectionState(playerIndex, SELECTED);
		}	
		else
		{
			setPlayerSelectionState(playerIndex, NOT_SELECTED);
		}	
		
		if(yesIsPressed == TRUE && noIsPressed == FALSE)
		{
			setPlayerVoteState(playerIndex, VOTE_YES);
		}	
		else if(yesIsPressed == FALSE && noIsPressed == TRUE)
		{
			setPlayerVoteState(playerIndex, VOTE_NO);
		}	
		else
		{
			setPlayerVoteState(playerIndex, NO_VOTE);
		}

		if(isEnterButtonPressed() == TRUE)
		{
			setPlayerSide(playerIndex, SPY);
		}
		else
		{
			setPlayerSide(playerIndex, RESISTANT);
		}	
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
			case WAITING_FOR_PLAYERS:

				updatePlayersWhoWantToPlay();
				
				if(canGameStart() == TRUE)
				{
					_gameState = NOTIFYING_PLAYER_SIDES;
				}	
				
			break;
		}	
		
		//displayButtonPressedAEffacer();
		//__delay_ms(1000);

	
	}

	
}




	