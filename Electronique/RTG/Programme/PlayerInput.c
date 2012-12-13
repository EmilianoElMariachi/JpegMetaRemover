#include "CustomTypes.h";
#include "PlayerInput.h"

#include "PlayerIO.h"
#include "MCP23S17.h";


void getPlayerInputState(char playerIndex, BOOL* yesIsPressed, BOOL* noIsPressed, BOOL* selectIsPressed)
{
	char addressMCP = getMCPAddressFromPlayerIndex(playerIndex);
	
	if(getPortLetterForPlayerIndex(playerIndex)	== 'A')
	{
		char portState = MCP23S17_GetPortA(addressMCP);
		if((portState & B8(10000000)) == B8(10000000))
		{ *selectIsPressed = FALSE; }
		else
		{ *selectIsPressed = TRUE; }
	}	
	else
	{
		char portState = MCP23S17_GetPortB(addressMCP);
		if((portState & B8(00000001)) == B8(00000001))
		{ *selectIsPressed = FALSE; }
		else
		{ *selectIsPressed = TRUE; }
	}	
}



