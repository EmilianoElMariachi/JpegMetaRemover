//======================================================================================
//>	Déclaration des types et des énumérations partagées dans le programme
//======================================================================================
#ifndef COMMON_DATA_TYPES
#define  COMMON_DATA_TYPES
	#define BUTTON_FILTER_DELAY 10

	#define BLINK_FREQ 3
   
	#define UCHAR_MAX 255
	
	#define MIN_NUMBER_OF_PLAYERS 5
	#define MAX_NUMBER_OF_PLAYERS 10
	
	#define MAX_NUMBER_OF_MISSIONS 5
	
	
	#define B8(Num) 0bNum
	
	#define BIT0 00000001 
	#define BIT1 00000010 
	#define BIT2 00000100 
	#define BIT3 00001000 
	#define BIT4 00010000 
	#define BIT5 00100000 
	#define BIT6 01000000 
	#define BIT7 10000000 
	
	#define TRUE 0x01
	#define FALSE 0x00
	
	#define RESET 	RC7 //Définition de la pi de reset
	#define CS 		RC6 //Définition de la pin correspondant au Chip Select (CS)
	
	
	#define CHAR char
	#define UCHAR unsigned char
	#define PBOOL BOOL*
	#define PCHAR char*
	#define PUCHAR UCHAR*


	#define RAND_SEED_EEPROM_ADR 0

	typedef char BOOL;
	
	typedef unsigned char BYTE;

	enum MissionStates
	{
		NOT_YET_STARTED = 1,
		STARTED = 2,
		WON_BY_SPIES = 3,
		WON_BY_RESISTANCE = 4
	};

	enum PlayerVoteLedColor
	{
		NONE = 0,
		GREEN = 1,
		RED = 2,
	};
		
	enum PlayerSelectLedState
	{
		OFF = 0,
		ON = 1,
	};
	
	enum PlayerSelectionState
	{
		NOT_SELECTED = OFF,
		SELECTED = ON,
	};

	enum PlayerVoteStates
	{
		NO_VOTE = 0,
		VOTE_NO = 1,
		VOTE_YES = 2,
	};

	enum PlayerSides
	{
		RESISTANT = 0,
		SPY = 1,
	};

	enum GameStates
	{
		WAIT_FOR_PLAYERS = 1,
		NOTIFY_PLAYER_SIDES = 2,
		WAIT_CUR_PLAYER_SELECT_PLAYERS = 3,
	};
	
	struct Player
	{
		BOOL Side:1;
		char PlayerSlotIndex:4;
		BOOL PlayerSelectedForMission:1;
		char VoteStatus:2;
	}  _players[MAX_NUMBER_OF_PLAYERS];;	

	//======================================================================================
	//> Déclaration des variables globales
	//======================================================================================
	enum GameStates _gameState = WAIT_FOR_PLAYERS;
	BOOL _playersSlotsStatus[MAX_NUMBER_OF_PLAYERS];
	char _numberOfRegisteredPlayers = 0;
	char _currentPlayerIndex = 0;
	char _currentMissionIndex = 0;
	
	const char NUM_SPIES_PER_NUM_PLAYERS[MIN_NUMBER_OF_PLAYERS+1] = {2, 2, 3, 3, 3, 4};

	const char SPIES_PER_MISSION [MAX_NUMBER_OF_MISSIONS][MIN_NUMBER_OF_PLAYERS+1]  = { {2, 2, 2, 3, 3, 3},
																						{3, 3, 3, 4, 4, 4},
																						{2, 4, 3, 4, 4, 4},
																						{3, 3, 4, 5, 5, 5},
																						{3, 4, 4, 5, 5, 5} };

	char _numSpiesExpectedForCurMiss = 0;	
	volatile UCHAR _enterButtonFilterCounter = 0; 
	volatile BOOL _toggleBlink; 
	


#endif

