#include <htc.h>

#include "Definitions.h";
#include "PlayerInput.h"

#include "PlayerIO.h"
#include "MCP23S17.h";

//======================================================================================
//> Fonction permettant de savoir si le bouton "Enter" est press�
//======================================================================================
BOOL isEnterButtonPressed()
{
	static BOOL _buttonSeenReleasedSinceLastPush = TRUE;
	
	BOOL _currentButtonState = (PORTB & B8(BIT6)) == B8(BIT6)?TRUE:FALSE;

	//Si le temps de filtrage est pass� et que le bouton est vu relach�,
	//alors on peut consid�rer que le bouton a �t� rel�ch� depuis le dernier appui
	if(!_enterButtonFilterCounter && !_currentButtonState)
	{ _buttonSeenReleasedSinceLastPush = TRUE; }	
	
	if(!_enterButtonFilterCounter && _buttonSeenReleasedSinceLastPush && _currentButtonState == TRUE)
	{
		_buttonSeenReleasedSinceLastPush = FALSE;
		_enterButtonFilterCounter = 10;
		return TRUE;
	}
	else
	{
		return FALSE;
	}	
	
	
	
}	

//======================================================================================
//> Fonction permettant de connaitre l'�tat de tous les boutons qui concernent un joueur
//======================================================================================
void getPlayerInputState(char playerIndex, BOOL* yesIsPressed, BOOL* noIsPressed, BOOL* selectIsPressed)
{
	char addressMCP = getMCPAddressFromPlayerIndex(playerIndex);
	
	if(getPortLetterForPlayerIndex(playerIndex)	== 'A')
	{
		char portState = MCP23S17_GetPortA(addressMCP);
		if((portState & B8(BIT7)) == B8(BIT7))
		{ *selectIsPressed = TRUE; }
		else
		{ *selectIsPressed = FALSE; }
		
		if((portState & B8(BIT3)) == B8(BIT3))
		{ *noIsPressed = FALSE; }
		else
		{ *noIsPressed = TRUE; }
		
		if((portState & B8(BIT2)) == B8(BIT2))
		{ *yesIsPressed = FALSE; }
		else
		{ *yesIsPressed = TRUE; }
	}	
	else
	{
		char portState = MCP23S17_GetPortB(addressMCP);
		if((portState & B8(BIT0)) == B8(BIT0))
		{ *selectIsPressed = TRUE; }
		else
		{ *selectIsPressed = FALSE; }

		if((portState & B8(BIT4)) == B8(BIT4))
		{ *noIsPressed = FALSE; }
		else
		{ *noIsPressed = TRUE; }
		
		if((portState & B8(BIT5)) == B8(BIT5))
		{ *yesIsPressed = FALSE; }
		else
		{ *yesIsPressed = TRUE; }
	}	
}