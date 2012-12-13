//==========================================================//
//=== 					FONCTIONS EXPOSEES 				 ===//
//==========================================================//
char getMCPAddressFromPlayerIndex(char playerIndex);

char getPortLetterForPlayerIndex(char playerIndex);


//==========================================================//
//=== 						VARIABLES 				 	 ===//
//==========================================================//
char _MCPPorts[MAX_NUMBER_OF_PLAYERS] = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
