#include "CustomTypes.h"
#include "PlayerOutput.h"
#include "PlayerIO.h"
#include "MCP23S17.h";


void setPlayerSelectionState(char playerIndex, enum PlayerSelectionState playerSelectionState)
{
	if(getPortLetterForPlayerIndex(playerIndex) == 'A')
	{
		switch(playerSelectionState)
		{
			case NOT_SELECTED:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] & B8(10111111);
				break;
			case SELECTED:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] | B8(01000000);
				break;
		}
		MCP23S17_SetPortA(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);
	}
	else
	{
		switch(playerSelectionState)
		{
			case NOT_SELECTED:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] & B8(11111101);
				break;
			case SELECTED:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] | B8(00000010);
				break;
		}
		MCP23S17_SetPortB(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);	
	}	
}

void setPlayerVoteState(char playerIndex, enum PlayerVoteStates playerVoteState)
{
	if(getPortLetterForPlayerIndex(playerIndex) == 'A')
	{
		char maskOR, maskAND;
		switch(playerVoteState)
		{
			case NO_VOTE:
				maskOR  = B8(00000000); maskAND = B8(11001111);
				break;
			case VOTE_NO:
				maskOR  = B8(00010000); maskAND = B8(11011111);
				break;
			case VOTE_YES:
				maskOR  = B8(00100000); maskAND = B8(11101111);			
				break;
		}
		_MCPPorts[playerIndex] = (_MCPPorts[playerIndex] | maskOR) & maskAND;
		MCP23S17_SetPortA(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);
	}
	else
	{
		char maskOR, maskAND;
		switch(playerVoteState)
		{
			case NO_VOTE:
				maskOR  = B8(00000000); maskAND = B8(11110011);
				break;
			case VOTE_NO:
				maskOR  = B8(00001000); maskAND = B8(11111011);			
				break;
			case VOTE_YES:
				maskOR  = B8(00000100); maskAND = B8(11110111);			
				break;
		}	
		_MCPPorts[playerIndex] = (_MCPPorts[playerIndex] | maskOR) & maskAND;
		MCP23S17_SetPortB(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);		
	}			
}

void setPlayerSide(char playerIndex, enum PlayerSides playerSide)
{
	if(getPortLetterForPlayerIndex(playerIndex) == 'A')
	{
		char maskOR, maskAND;
		switch(playerSide)
		{
			case SPY:
				maskOR  = B8(00000010); maskAND = B8(11111111);
				break;
			case RESISTANT:
				maskOR  = B8(00000000); maskAND = B8(11111101);
				break;
		}
		_MCPPorts[playerIndex] = (_MCPPorts[playerIndex] | maskOR) & maskAND;
		MCP23S17_SetPortA(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);
	}
	else
	{
		char maskOR, maskAND;
		switch(playerSide)
		{
			case SPY:
				maskOR  = B8(01000000); maskAND = B8(11111111);
				break;
			case RESISTANT:
				maskOR  = B8(00000000); maskAND = B8(10111111);			
				break;
		}	
		_MCPPorts[playerIndex] = (_MCPPorts[playerIndex] | maskOR) & maskAND;
		MCP23S17_SetPortB(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);		
	}			
}