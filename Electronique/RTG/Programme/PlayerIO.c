//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//
//¤¤¤              INCLUDES              ¤¤¤//
#include "Definitions.h"
#include "PlayerIO.h"

//¤¤¤              INCLUDES              ¤¤¤//
//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//

//======================================================================================
//> Fonction permettant de connaitre l'adresse du Port Expandeur (MCP23S17) selon
//> l'index du joueur
//======================================================================================
char getMCPAddressFromPlayerIndex(char playerIndex)
{
	return playerIndex / 2;
}	

//======================================================================================
//> Fonction permettant de savoir quel port (A ou B) est associé au player dont l'index
//> est spécifié
//======================================================================================
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