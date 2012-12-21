#define MIN_NUMBER_OF_PLAYERS 5
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

#define RESET 	RC7 //Définition de la pi de reset
#define CS 		RC6 //Définition de la pin correspondant au Chip Select (CS)

#define PBOOL BOOL*

//======================================================================================
//>	Déclaration des types et des énumérations partagées dans le programme
//======================================================================================
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

	enum GameStates
	{
		WAITING_FOR_PLAYERS = 1,
		NOTIFYING_PLAYER_SIDES = 2,
	};
	
	struct Player
	{
		BOOL IsSpy;
		char PlayerSlotIndex;
		enum PlayerVoteStates VoteStatus;
	};	

	//======================================================================================
	//> Déclaration des variables globales
	//======================================================================================
	enum GameStates _gameState;
	struct Player _players[MAX_NUMBER_OF_PLAYERS];
	BOOL _playersSlotsStatus[MAX_NUMBER_OF_PLAYERS];
	char _numberOfRegisteredPlayers;

#endif

