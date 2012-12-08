#include <htc.h>
#include <pic16f882.h>
#include "SPI.h";

#include "MCP23S17.h";

#include "player.h";

__CONFIG(DEBUG_OFF & LVP_OFF & FCMEN_OFF & IESO_OFF & BOREN_OFF & CP_OFF & MCLRE_ON & PWRTE_OFF & WDTE_OFF & FOSC_INTRC_NOCLKOUT);

#define _XTAL_FREQ 8000000	//Oscillateur interne cadencé à 8 Mhz

//==============================================================================

#define BUTTON_APPUYE	RB0	//bit 1 of PORTC
#define TRUE 0xFF
#define FALSE 0x00

typedef char BOOL;


//==============================================================================
enum PlayerSelectionState
{
	NOT_SELECTED = 0x00,
	SELECTED = 0xFF,
};

enum MissionState
{
	NOT_YET_STARTED = 1,
	STARTED = 2,
	WON_BY_SPIES = 3,
	WON_BY_RESISTANCE = 4
};	


//==============================================================================

char _MCPPorts[MAX_NUMBER_OF_PLAYERS] = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

BOOL _shouldToggleAEffacer = FALSE;

char _currentMissionIndex = 0;
char _CPT_A_EFFACER = 0;
char _statePlayerVoteAEffacer = NOT_YET_VOTED;
enum PlayerSelectionState _arePlayersSelectedAEffacer = NOT_SELECTED;

//==============================================================================


void setMissionState(char missionNumber, enum MissionState eMissionState)
{
	if(missionNumber == 1)
	{
		switch(eMissionState)
		{
			case NOT_YET_STARTED:
				PORTA = PORTA & 0b11111000;
				break;
			case STARTED:
				PORTA = (PORTA | 0b00000001) & 0b11111001;
				break;
			case WON_BY_SPIES:
				PORTA = (PORTA | 0b00000010) & 0b11111010;
				break;
			case WON_BY_RESISTANCE:
				PORTA = (PORTA | 0b00000100) & 0b11111100;
				break;
		}	
	}
	else if(missionNumber == 2)	
	{
		switch(eMissionState)
		{
			case NOT_YET_STARTED:
				PORTA = PORTA & 0b11000111;
				break;
			case STARTED:
				PORTA = (PORTA | 0b00001000) & 0b11001111;
				break;
			case WON_BY_SPIES:
				PORTA = (PORTA | 0b00010000) & 0b11010111;
				break;
			case WON_BY_RESISTANCE:
				PORTA = (PORTA | 0b00100000) & 0b11100111;
				break;
		}
	}	
	else if(missionNumber == 3)		
	{
		switch(eMissionState)
		{
			case NOT_YET_STARTED:
				PORTC = PORTC & 0b11111000;
				break;
			case STARTED:
				PORTC = (PORTC | 0b00000001) & 0b11111001;
				break;
			case WON_BY_SPIES:
				PORTC = (PORTC | 0b00000010) & 0b11111010;
				break;
			case WON_BY_RESISTANCE:
				PORTC = (PORTC | 0b00000100) & 0b11111100;
				break;
		}
	}	
	else if(missionNumber == 4)		
	{
		switch(eMissionState)
		{
			case NOT_YET_STARTED:
				PORTB = PORTB & 0b11111000;
				break;
			case STARTED:
				PORTB = (PORTB | 0b00000001) & 0b11111001;
				break;
			case WON_BY_SPIES:
				PORTB = (PORTB | 0b00000010) & 0b11111010;
				break;
			case WON_BY_RESISTANCE:
				PORTB = (PORTB | 0b00000100) & 0b11111100;
				break;
		}
	}
	else if(missionNumber == 5)		
	{
		switch(eMissionState)
		{
			case NOT_YET_STARTED:
				PORTB = PORTB & 0b11000111;
				break;
			case STARTED:
				PORTB = (PORTB | 0b00001000) & 0b11001111;
				break;
			case WON_BY_SPIES:
				PORTB = (PORTB | 0b00010000) & 0b11010111;
				break;
			case WON_BY_RESISTANCE:
				PORTB = (PORTB | 0b00100000) & 0b11100111;
				break;
		}
	}
}	 

char getMCPAddressFromPlayerIndex(char playerIndex)
{
	return playerIndex / 2;
}	

char getPortLetterForPlayerIndex(char playerIndex)
{
	if((playerIndex % 2) == 0)
	{
		return 'B';
	}	
	else
	{
		return 'A';
	}	
}

BOOL isPlayerSelectionButtonPressed(playerIndex)	
{
	char addressMCP = getMCPAddressFromPlayerIndex(playerIndex);
	
	if(getPortLetterForPlayerIndex(playerIndex)	== 'A')
	{
		char portState = MCP23S17_GetPortA(addressMCP);
		if((portState & 0b10000000) == 0b10000000)
		{ return FALSE; }
		else
		{ return TRUE; }
	}	
	else
	{
		char portState = MCP23S17_GetPortB(addressMCP);
		if((portState & 0b00000001) == 0b00000001)
		{ return FALSE; }
		else
		{ return TRUE; }
	}	
}	

void setPlayerVoteState(char playerIndex, enum EnumPlayerVoteState ePlayerVoteState)
{
	if(getPortLetterForPlayerIndex(playerIndex) == 'A')
	{
		char maskOR, maskAND;
		switch(ePlayerVoteState)
		{
			case NOT_YET_VOTED:
				maskOR  = 0b00000000; maskAND = 0b11001111;
				break;
			case VOTED_NO:
				maskOR  = 0b00010000; maskAND = 0b11011111;
				break;
			case VOTED_YES:
				maskOR  = 0b00100000; maskAND = 0b11101111;			
				break;
		}
		_MCPPorts[playerIndex] = (_MCPPorts[playerIndex] | maskOR) & maskAND;
		MCP23S17_SetPortA(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);
	}
	else
	{
		char maskOR, maskAND;
		switch(ePlayerVoteState)
		{
			case NOT_YET_VOTED:
				maskOR  = 0b00000000; maskAND = 0b11110011;
				break;
			case VOTED_NO:
				maskOR  = 0b00001000; maskAND = 0b11111011;			
				break;
			case VOTED_YES:
				maskOR  = 0b00000100; maskAND = 0b11110111;			
				break;
		}	
		_MCPPorts[playerIndex] = (_MCPPorts[playerIndex] | maskOR) & maskAND;
		MCP23S17_SetPortB(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);		
	}			
}	

void setPlayerSelectionState(char playerIndex, enum PlayerSelectionState playerSelectionState)
{
	if(getPortLetterForPlayerIndex(playerIndex) == 'A')
	{
		switch(playerSelectionState)
		{
			case NOT_SELECTED:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] & 0b10111111;
				break;
			case SELECTED:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] | 0b01000000;
				break;
		}
		MCP23S17_SetPortA(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);
	}
	else
	{
		switch(playerSelectionState)
		{
			case NOT_SELECTED:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] & 0b11111101;
				break;
			case SELECTED:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] | 0b00000010;
				break;
		}
		MCP23S17_SetPortB(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);	
	}	
}	





void toggleVoteLedsAEffacer()
{
	
	if(_statePlayerVoteAEffacer == NOT_YET_VOTED)
	{
		_statePlayerVoteAEffacer =  VOTED_NO;
	}
	else if(_statePlayerVoteAEffacer == VOTED_NO)
	{
		_statePlayerVoteAEffacer =  VOTED_YES;
	}
	else
	{
		_statePlayerVoteAEffacer = NOT_YET_VOTED;
	}	
	
	for(char playerIndex = 0; playerIndex <= 9 ; playerIndex++)
	{
		 setPlayerVoteState(playerIndex, _statePlayerVoteAEffacer);
	}	
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
			//_shouldToggleAEffacer = TRUE;
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

	ANSEL  = 0b00000000; 	//Port a en mode digital
	ANSELH = 0b00000000;	//Port b en mode digital (non analogique)
	
	TRISA  = 0b00000000;
	TRISB  = 0b11000000;
	TRISC  = 0b00010000;
	
	//TODO : a effacer
	PORTA = 0b00000000;
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
			if(isPlayerSelectionButtonPressed(playerIndex) == TRUE)
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
				toggleVoteLedsAEffacer();
				_shouldToggleAEffacer = FALSE;
			}	
		}	 

		//__delay_ms(1000);

	
	}

	
}




	