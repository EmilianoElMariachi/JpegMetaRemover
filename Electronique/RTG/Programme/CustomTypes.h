#define MAX_NUMBER_OF_PLAYERS 10

#define B8(Num) 0bNum

#define TRUE 0xFF
#define FALSE 0x00



//==========================================================================//
//	Déclaration des types et des énumérations partagées dans le programme   //
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

#endif

	
