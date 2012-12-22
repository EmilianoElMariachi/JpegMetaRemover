#include "Definitions.h"
#include "PlayerOutput.h"
#include "PlayerIO.h"
#include "MCP23S17.h";

//======================================================================================
//> Permet d'allumer ou éteindre la led de selection d'un joueur
//======================================================================================
void setPlayerSelectLedState(char playerIndex, enum PlayerSelectLedState ledState)
{
	if(getPortLetterForPlayerIndex(playerIndex) == 'A')
	{
		switch(ledState)
		{
			case OFF:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] & B8(10111111);
				break;
			case ON:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] | B8(01000000);
				break;
		}
		MCP23S17_SetPortA(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);
	}
	else
	{
		switch(ledState)
		{
			case OFF:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] & B8(11111101);
				break;
			case ON:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] | B8(00000010);
				break;
		}
		MCP23S17_SetPortB(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);	
	}	
}

//======================================================================================
//>
//======================================================================================
void setPlayerVoteLedColor(char playerIndex, enum PlayerVoteLedColor ledColor)
{
	if(getPortLetterForPlayerIndex(playerIndex) == 'A')
	{
		char maskOR, maskAND;
		switch(ledColor)
		{
			case NONE:
				maskOR  = B8(00000000); maskAND = B8(11001111);
				break;
			case RED:
				maskOR  = B8(00010000); maskAND = B8(11011111);
				break;
			case GREEN:
				maskOR  = B8(00100000); maskAND = B8(11101111);			
				break;
		}
		_MCPPorts[playerIndex] = (_MCPPorts[playerIndex] | maskOR) & maskAND;
		MCP23S17_SetPortA(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);
	}
	else
	{
		char maskOR, maskAND;
		switch(ledColor)
		{
			case NONE:
				maskOR  = B8(00000000); maskAND = B8(11110011);
				break;
			case RED:
				maskOR  = B8(00001000); maskAND = B8(11111011);			
				break;
			case GREEN:
				maskOR  = B8(00000100); maskAND = B8(11110111);			
				break;
		}	
		_MCPPorts[playerIndex] = (_MCPPorts[playerIndex] | maskOR) & maskAND;
		MCP23S17_SetPortB(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);		
	}			
}

//======================================================================================
//>
//======================================================================================
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