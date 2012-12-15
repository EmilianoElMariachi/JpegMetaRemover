#include <htc.h>

#include "CustomTypes.h";
#include "PlayerInput.h"

#include "PlayerIO.h"
#include "MCP23S17.h";

BOOL isEnterButtonPressed()
{
	if((PORTB & B8(BIT6)) == B8(BIT6))
	{
		return TRUE;
	}	
	else
	{
		return FALSE;
	}	
}	

void getPlayerInputState(char playerIndex, BOOL* yesIsPressed, BOOL* noIsPressed, BOOL* selectIsPressed)
{
	char addressMCP = getMCPAddressFromPlayerIndex(playerIndex);
	
	if(getPortLetterForPlayerIndex(playerIndex)	== 'A')
	{
		char portState = MCP23S17_GetPortA(addressMCP);
		if((portState & B8(BIT7)) == B8(BIT7))
		{ *selectIsPressed = FALSE; }
		else
		{ *selectIsPressed = TRUE; }
		
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
		{ *selectIsPressed = FALSE; }
		else
		{ *selectIsPressed = TRUE; }

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



