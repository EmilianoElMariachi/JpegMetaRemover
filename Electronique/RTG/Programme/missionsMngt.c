//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//
//¤¤¤              INCLUDES              ¤¤¤//
#include <htc.h>
#include <pic16f882.h>

#include "Definitions.h"
#include "missionsMngt.h"
//¤¤¤              INCLUDES              ¤¤¤//
//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//

void switchOffAllMissionLeds()
{
	for(char iter = 0; iter < MAX_NUMBER_OF_MISSIONS ; iter++)
	{
		setMissionLedColor(iter, MISSION_OFF);
	}	
}	

//======================================================================================
//> Fonction permettant de définir l'état de la mission à l'index spécifié
//======================================================================================
void setMissionLedColor(char missionIndex, char ledColor)
{
	if(missionIndex == 4)
	{
		switch(ledColor)
		{
			case MISSION_OFF:
				PORTA = PORTA & B8(11111000);
				break;
			case MISSION_BLUE:
				PORTA = (PORTA | B8(00000001)) & B8(11111001);
				break;
			case MISSION_RED:
				PORTA = (PORTA | B8(00000010)) & B8(11111010);
				break;
			case MISSION_GREEN:
				PORTA = (PORTA | B8(00000100)) & B8(11111100);
				break;
		}	
	}
	else if(missionIndex == 3)	
	{
		switch(ledColor)
		{
			case MISSION_OFF:
				PORTA = PORTA & B8(11000111);
				break;
			case MISSION_BLUE:
				PORTA = (PORTA | B8(00001000)) & B8(11001111);
				break;
			case MISSION_RED:
				PORTA = (PORTA | B8(00010000)) & B8(11010111);
				break;
			case MISSION_GREEN:
				PORTA = (PORTA | B8(00100000)) & B8(11100111);
				break;
		}
	}	
	else if(missionIndex == 2)		
	{
		switch(ledColor)
		{
			case MISSION_OFF:
				PORTC = PORTC & B8(11111000);
				break;
			case MISSION_BLUE:
				PORTC = (PORTC | B8(00000001)) & B8(11111001);
				break;
			case MISSION_RED:
				PORTC = (PORTC | B8(00000010)) & B8(11111010);
				break;
			case MISSION_GREEN:
				PORTC = (PORTC | B8(00000100)) & B8(11111100);
				break;
		}
	}	
	else if(missionIndex == 1)		
	{
		switch(ledColor)
		{
			case MISSION_OFF:
				PORTB = PORTB & B8(11111000);
				break;
			case MISSION_BLUE:
				PORTB = (PORTB | B8(00000001)) & B8(11111001);
				break;
			case MISSION_RED:
				PORTB = (PORTB | B8(00000010)) & B8(11111010);
				break;
			case MISSION_GREEN:
				PORTB = (PORTB | B8(00000100)) & B8(11111100);
				break;
		}
	}
	else if(missionIndex == 0)		
	{
		switch(ledColor)
		{
			case MISSION_OFF:
				PORTB = PORTB & B8(11000111);
				break;
			case MISSION_BLUE:
				PORTB = (PORTB | B8(00001000)) & B8(11001111);
				break;
			case MISSION_RED:
				PORTB = (PORTB | B8(00010000)) & B8(11010111);
				break;
			case MISSION_GREEN:
				PORTB = (PORTB | B8(00100000)) & B8(11100111);
				break;
		}
	}
}

//======================================================================================
//> 
//======================================================================================
void displayError(char nbErrors, char blinkColor)
{
	char iter;
	
	char backUpPortA = PORTA;
	char backUpPortB = PORTB;
	char backUpPortC = PORTC;

	
	//Eteint toutes les missions
	switchOffAllMissionLeds();		
	
	for(char i = 0; i < NUM_BLINKS_ERROR ; i++)
	{
		for(iter = 0; iter < nbErrors ; iter++)
		{
			setMissionLedColor(iter, blinkColor);
		}
		
		__delay_ms(BLINK_ERROR_DELAY_MS);
		
		switchOffAllMissionLeds();	
	
		__delay_ms(BLINK_ERROR_DELAY_MS);
	}
	

	
	PORTA = backUpPortA;
	PORTB = backUpPortB;
	PORTC = backUpPortC;
	
}