#define MAX_NUMBER_OF_PLAYERS 10

#define B8(Num) 0bNum

#define BIT0 00000001 
#define BIT1 00000010 
#define BIT2 00000100 
#define BIT3 00001000 
#define BIT4 00010000 
#define BIT5 00100000 
#define BIT6 01000000 
#define BIT7 10000000 

#define TRUE 0xFF
#define FALSE 0x00



//==========================================================================//
//	D�claration des types et des �num�rations partag�es dans le programme   //
//==========================================================================//
#ifndef COMMON_DATA_TYPES
#define  COMMON_DATA_TYPES   

	typedef char BOOL;
	
	typedef unsigned char BYTE;

	enum PlayerSelectionState
	{
		NOT_SELECTED = 0,
		SELECTED = 1,
	};

	enum PlayerVoteStates
	{
		NO_VOTE = 0,
		VOTE_NO = 1,
		VOTE_YES = 2,
	};

	enum PlayerSides
	{
		SPY = 0,
		RESISTANT = 1,
	};

#endif

	
