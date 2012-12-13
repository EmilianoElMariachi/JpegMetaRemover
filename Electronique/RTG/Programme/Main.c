#include <htc.h>
#include <pic16f882.h>

#include "CustomTypes.h";
#include "SPI.h";
#include "MCP23S17.h";
#include "missionsMngt.h"
#include "playerInput.h";
#include "playerOutput.h";
#include "playerIO.h";
#include "EEPROM.h"
#include "Random.h"

__CONFIG(DEBUG_OFF & LVP_OFF & FCMEN_OFF & IESO_OFF & BOREN_OFF & CP_OFF & MCLRE_ON & PWRTE_OFF & WDTE_OFF & FOSC_INTRC_NOCLKOUT);

#define _XTAL_FREQ 8000000	//Oscillateur interne cadencé à 8 Mhz

//==============================================================================

#define BUTTON_APPUYE	RB0	//bit 1 of PORTC


//==============================================================================

volatile BOOL _shouldToggleAEffacer = FALSE;

char _currentMissionIndex = 0;
char _CPT_A_EFFACER = 0;
enum PlayerSelectionState _arePlayersSelectedAEffacer = NOT_SELECTED;

//==============================================================================






BOOL isEnterButtonPressed()
{
	//TODO : à finir
}	

	

void toggleMissionLedsAEffacer()
{

	if(_currentMissionIndex == 0)
	{
		setMissionState(1, NOT_YET_STARTED);
		setMissionState(2, NOT_YET_STARTED);
		setMissionState(3, NOT_YET_STARTED);
		setMissionState(4, NOT_YET_STARTED);
		setMissionState(5, NOT_YET_STARTED);
		_currentMissionIndex ++;	
	}
	else if(_currentMissionIndex == 1)
	{
		setMissionState(1, STARTED);
		setMissionState(2, STARTED);
		setMissionState(3, STARTED);
		setMissionState(4, STARTED);
		setMissionState(5, STARTED);		
		_currentMissionIndex ++;	
	}
	else if(_currentMissionIndex == 2)
	{
		setMissionState(1, WON_BY_RESISTANCE);
		setMissionState(2, WON_BY_RESISTANCE);
		setMissionState(3, WON_BY_RESISTANCE);
		setMissionState(4, WON_BY_RESISTANCE);
		setMissionState(5, WON_BY_RESISTANCE);
		_currentMissionIndex ++;	
	}
	else if(_currentMissionIndex == 3)
	{
		setMissionState(1, WON_BY_SPIES);
		setMissionState(2, WON_BY_SPIES);
		setMissionState(3, WON_BY_SPIES);
		setMissionState(4, WON_BY_SPIES);
		setMissionState(5, WON_BY_SPIES);
		_currentMissionIndex = 0;	
	}
	
}

enum GameStates
{
	WAITING_FOR_PLAYERS,
	
};	

//#########################################################################//
//
//#########################################################################//

void checkPlayersWhoWantToPlay()
{
	for(char playerIndex = 0; playerIndex < MAX_NUMBER_OF_PLAYERS ; playerIndex++)
	{
		enum PlayerVoteStates playerVoteState = getPlayerVoteState(playerIndex);
		if(playerVoteState == VOTE_NO)
		{
		}
		else if(playerVoteState == VOTE_YES)
		{
		}		
	}	
}	


//#########################################################################//
//### 							INTERRUPTION 							###//
//#########################################################################//
void interrupt tc_int(void)
{
	if (T0IE && T0IF)
	{
		_CPT_A_EFFACER++;
		
		if(_CPT_A_EFFACER == 10)
		{
			_CPT_A_EFFACER = 0;
			_shouldToggleAEffacer = TRUE;
		}
		
		T0IF=0;
	}
}

//#########################################################################//
//### 							INTITIALISATIONS 						###//
//#########################################################################//

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

void initializePortsDirections()
{
	//1 = PORT pin configured as an input (tri-stated)
	//0 	= PORTC pin configured as an output
	//Note 1: TRISC<1:0> always reads ‘1’ in LP Oscillator mode.

	ANSEL  = B8(00000000); 	//Port a en mode digital
	ANSELH = B8(00000000);	//Port b en mode digital (non analogique)
	
	TRISA  = B8(00000000);
	TRISB  = B8(11000000);
	TRISC  = B8(00010000);
	
	//TODO : a effacer
	PORTA = B8(00000000);
}	

void initializeMissionLeds()
{
	for(char i = 1; i <= 5; i++)
	{
		setMissionState(i, NOT_YET_STARTED);
	}	
}	

main(void)
{
	
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
	
	//Eteint les leds mission
	initializeMissionLeds();

	//===================

	initializeTimer0();
	
	
	//enable global interrupts
	GIE = 1;
	
	BOOL buttonPushed = FALSE;

//
	while(TRUE)
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
			
			if(_shouldToggleAEffacer == TRUE)
			{
				toggleMissionLedsAEffacer();
				_shouldToggleAEffacer = FALSE;
			}	
		}	 

		//__delay_ms(1000);

	
	}

	
}




	