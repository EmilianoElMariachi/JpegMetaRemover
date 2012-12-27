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
		_enterButtonFilterCounter = 2;
	}	
	else if(_enterButtonFilterCounter == 1)
	{
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
	
	if(getPortLetterForPlayerIndex(playerIndex)	== 'A')
	{
		char portState = MCP23S17_GetPortA(addressMCP);
		*selectIsPressed = testbit(portState, 7)?TRUE:FALSE;
		*noIsPressed = testbit(portState, 3)?FALSE:TRUE;
		*yesIsPressed = testbit(portState, 2)?FALSE:TRUE;
	}	
	else
	{
		char portState = MCP23S17_GetPortB(addressMCP);
		*selectIsPressed = testbit(portState, 0)?TRUE:FALSE;
		*noIsPressed = testbit(portState, 4)?FALSE:TRUE;
		*yesIsPressed = testbit(portState, 5)?FALSE:TRUE;
	}	
}