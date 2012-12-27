#include <htc.h>

#include "Definitions.h";
#include "PlayerInput.h"

#include "PlayerIO.h"
#include "MCP23S17.h";

//======================================================================================
//> Fonction permettant de savoir si le bouton "Enter" est pressé
//======================================================================================
BOOL isEnterButtonPressed()
{
	if(ENTER_BUTTON_STATE)
	{
		_buttonsFilterCounters[ENTER_BTN_FILTER_INDEX] = BUTTON_FILTER_TIME;
	}	
	else if(_buttonsFilterCounters[ENTER_BTN_FILTER_INDEX] == 1)
	{
		_buttonsFilterCounters[ENTER_BTN_FILTER_INDEX] = 0;
		return TRUE;
	}
		
	return FALSE;
}	

//======================================================================================
//> Fonction permettant de connaitre l'état de tous les boutons qui concernent un joueur
//======================================================================================
void getPlayerInputState(char playerIndex, BOOL* yesIsPressed, BOOL* noIsPressed, BOOL* selectIsPressed)
{
	char addressMCP = getMCPAddressFromPlayerIndex(playerIndex);
	
	*selectIsPressed = FALSE;
	
	if(getPortLetterForPlayerIndex(playerIndex)	== 'A')
	{
		char portState = MCP23S17_GetPortA(addressMCP);
		
		if(testbit(portState, 7))
		{ _buttonsFilterCounters[playerIndex] = BUTTON_FILTER_TIME; }	
		else if(_buttonsFilterCounters[playerIndex] == 1)
		{ 
			_buttonsFilterCounters[playerIndex] = 0; 
			*selectIsPressed = TRUE; 
		}	
		
		*noIsPressed = testbit(portState, 3)?FALSE:TRUE;
		*yesIsPressed = testbit(portState, 2)?FALSE:TRUE;
	}	
	else
	{
		char portState = MCP23S17_GetPortB(addressMCP);
		
		if(testbit(portState, 0))
		{ _buttonsFilterCounters[playerIndex] = BUTTON_FILTER_TIME; }	
		else if(_buttonsFilterCounters[playerIndex] == 1)
		{
			_buttonsFilterCounters[playerIndex] = 0; 
			*selectIsPressed = TRUE; 
		}	
		
		*noIsPressed = testbit(portState, 4)?FALSE:TRUE;
		*yesIsPressed = testbit(portState, 5)?FALSE:TRUE;
	}	
}