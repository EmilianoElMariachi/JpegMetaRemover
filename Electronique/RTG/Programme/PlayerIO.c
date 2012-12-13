#include "CustomTypes.h"
#include "PlayerIO.h"

char getMCPAddressFromPlayerIndex(char playerIndex)
{
	return playerIndex / 2;
}	

char getPortLetterForPlayerIndex(char playerIndex)
{
	if((playerIndex % 2) == 0)
	{
		return 'B';
	}	
	else
	{
		return 'A';
	}	
}