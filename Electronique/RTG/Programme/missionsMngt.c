//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//
//¤¤¤              INCLUDES              ¤¤¤//
#include <htc.h>
#include <pic16f882.h>

#include "Definitions.h"
#include "missionsMngt.h"
//¤¤¤              INCLUDES              ¤¤¤//
//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//

//======================================================================================
//> Fonction permettant de définir l'état de la mission à l'index spécifié
//======================================================================================
void setMissionState(char missionIndex, enum MissionStates eMissionState)
{
	if(missionIndex == 0)
	{
		switch(eMissionState)
		{
			case NOT_YET_STARTED:
				PORTA = PORTA & B8(11111000);
				break;
			case STARTED:
				PORTA = (PORTA | B8(00000001)) & B8(11111001);
				break;
			case WON_BY_SPIES:
				PORTA = (PORTA | B8(00000010)) & B8(11111010);
				break;
			case WON_BY_RESISTANCE:
				PORTA = (PORTA | B8(00000100)) & B8(11111100);
				break;
		}	
	}
	else if(missionIndex == 1)	
	{
		switch(eMissionState)
		{
			case NOT_YET_STARTED:
				PORTA = PORTA & B8(11000111);
				break;
			case STARTED:
				PORTA = (PORTA | B8(00001000)) & B8(11001111);
				break;
			case WON_BY_SPIES:
				PORTA = (PORTA | B8(00010000)) & B8(11010111);
				break;
			case WON_BY_RESISTANCE:
				PORTA = (PORTA | B8(00100000)) & B8(11100111);
				break;
		}
	}	
	else if(missionIndex == 2)		
	{
		switch(eMissionState)
		{
			case NOT_YET_STARTED:
				PORTC = PORTC & B8(11111000);
				break;
			case STARTED:
				PORTC = (PORTC | B8(00000001)) & B8(11111001);
				break;
			case WON_BY_SPIES:
				PORTC = (PORTC | B8(00000010)) & B8(11111010);
				break;
			case WON_BY_RESISTANCE:
				PORTC = (PORTC | B8(00000100)) & B8(11111100);
				break;
		}
	}	
	else if(missionIndex == 3)		
	{
		switch(eMissionState)
		{
			case NOT_YET_STARTED:
				PORTB = PORTB & B8(11111000);
				break;
			case STARTED:
				PORTB = (PORTB | B8(00000001)) & B8(11111001);
				break;
			case WON_BY_SPIES:
				PORTB = (PORTB | B8(00000010)) & B8(11111010);
				break;
			case WON_BY_RESISTANCE:
				PORTB = (PORTB | B8(00000100)) & B8(11111100);
				break;
		}
	}
	else if(missionIndex == 4)		
	{
		switch(eMissionState)
		{
			case NOT_YET_STARTED:
				PORTB = PORTB & B8(11000111);
				break;
			case STARTED:
				PORTB = (PORTB | B8(00001000)) & B8(11001111);
				break;
			case WON_BY_SPIES:
				PORTB = (PORTB | B8(00010000)) & B8(11010111);
				break;
			case WON_BY_RESISTANCE:
				PORTB = (PORTB | B8(00100000)) & B8(11100111);
				break;
		}
	}
}