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
	
	char portState, selectBtnBitIndex, noBtnBitIndex, yesBtnBitIndex;
	
	if(getPortLetterForPlayerIndex(playerIndex)	== 'A')
	{
		 portState = MCP23S17_GetPortA(addressMCP);
		 selectBtnBitIndex = 7;
		 noBtnBitIndex = 3;
		 yesBtnBitIndex = 2;
	}	
	else
	{
		portState = MCP23S17_GetPortB(addressMCP);
		selectBtnBitIndex = 0;
		noBtnBitIndex = 4;
		yesBtnBitIndex = 5;
	}	
	
	

	*selectIsPressed = FALSE;
	
	if(testbit(portState, selectBtnBitIndex))
	{
		if(_buttonsFilterCounters[playerIndex] == 0)
		{ *selectIsPressed = TRUE; }	
		_buttonsFilterCounters[playerIndex] = BUTTON_FILTER_TIME;
	}	
	
	*noIsPressed = testbit(portState, noBtnBitIndex)?FALSE:TRUE;
	*yesIsPressed = testbit(portState, yesBtnBitIndex)?FALSE:TRUE;
	
}