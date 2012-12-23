#include "Definitions.h"
#include "PlayerOutput.h"
#include "PlayerIO.h"
#include "MCP23S17.h";

//======================================================================================
//> Permet d'eteindre toutes les leds de selection des joueurs
//======================================================================================
void switchOffAllSelPlayersLeds()
{
	for(char slotIndex = 0; slotIndex < MAX_NUMBER_OF_PLAYERS; slotIndex++)
	{
		setPlayerSelectLedState(slotIndex, SELECT_OFF);
	}	
}	

//======================================================================================
//> Permet d'allumer ou éteindre la led de selection d'un joueur
//======================================================================================
void setPlayerSelectLedState(char playerIndex, char ledState)
{
	if(getPortLetterForPlayerIndex(playerIndex) == 'A')
	{
		switch(ledState)
		{
			case SELECT_OFF:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] & B8(10111111);
				break;
			case SELECT_ON:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] | B8(01000000);
				break;
		}
		MCP23S17_SetPortA(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);
	}
	else
	{
		switch(ledState)
		{
			case SELECT_OFF:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] & B8(11111101);
				break;
			case SELECT_ON:
				_MCPPorts[playerIndex] = _MCPPorts[playerIndex] | B8(00000010);
				break;
		}
		MCP23S17_SetPortB(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);	
	}	
}

//======================================================================================
//> Permet d'allumer la led de vote à la couleur spécifiée pour un joueur donné
//======================================================================================
void setPlayerVoteLedColor(char playerIndex, char ledColor)
{
	if(getPortLetterForPlayerIndex(playerIndex) == 'A')
	{
		char maskOR, maskAND;
		switch(ledColor)
		{
			case VOTE_OFF:
				maskOR  = B8(00000000); maskAND = B8(11001111);
				break;
			case VOTE_RED:
				maskOR  = B8(00010000); maskAND = B8(11011111);
				break;
			case VOTE_GREEN:
				maskOR  = B8(00100000); maskAND = B8(11101111);			
				break;
			case VOTE_GREEN_RED:
				maskOR  = B8(00110000); maskAND = B8(11111111);			
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
			case VOTE_OFF:
				maskOR  = B8(00000000); maskAND = B8(11110011);
				break;
			case VOTE_RED:
				maskOR  = B8(00001000); maskAND = B8(11111011);			
				break;
			case VOTE_GREEN:
				maskOR  = B8(00000100); maskAND = B8(11110111);			
				break;
			case VOTE_GREEN_RED:
				maskOR  = B8(00001100); maskAND = B8(11111111);			
				break;
		}	
		_MCPPorts[playerIndex] = (_MCPPorts[playerIndex] | maskOR) & maskAND;
		MCP23S17_SetPortB(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);		
	}			
}

//======================================================================================
//>
//======================================================================================
void setPlayerSideLedState(char playerIndex, char ledState)
{
	if(getPortLetterForPlayerIndex(playerIndex) == 'A')
	{
		char maskOR, maskAND;
		switch(ledState)
		{
			case SIDE_LED_ON:
				maskOR  = B8(00000010); maskAND = B8(11111111);
				break;
			case SIDE_LED_OFF:
				maskOR  = B8(00000000); maskAND = B8(11111101);
				break;
		}
		_MCPPorts[playerIndex] = (_MCPPorts[playerIndex] | maskOR) & maskAND;
		MCP23S17_SetPortA(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);
	}
	else
	{
		char maskOR, maskAND;
		switch(ledState)
		{
			case SIDE_LED_ON:
				maskOR  = B8(01000000); maskAND = B8(11111111);
				break;
			case SIDE_LED_OFF:
				maskOR  = B8(00000000); maskAND = B8(10111111);			
				break;
		}	
		_MCPPorts[playerIndex] = (_MCPPorts[playerIndex] | maskOR) & maskAND;
		MCP23S17_SetPortB(getMCPAddressFromPlayerIndex(playerIndex), _MCPPorts[playerIndex]);		
	}			
}