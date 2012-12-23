//======================================================================================
//>	D�claration des types et des �num�rations partag�es dans le programme
//======================================================================================
#ifndef COMMON_DATA_TYPES
#define  COMMON_DATA_TYPES
	#define _XTAL_FREQ 8000000	//Oscillateur interne cadenc� � 8 Mhz

	#define BUTTON_FILTER_DELAY 10
	
	#define BLINK_ERROR_DELAY_MS 100
	#define NUM_BLINKS_ERROR 3

	#define BLINK_FREQ 3
   
	#define UCHAR_MAX 255
	
	#define NUM_MISSIONS_TO_WIN 	3
	#define MIN_NUMBER_OF_PLAYERS 	5
	#define MAX_NUMBER_OF_PLAYERS 	10
	#define NUM_PLAYERS_RANGE (MAX_NUMBER_OF_PLAYERS - MIN_NUMBER_OF_PLAYERS)+1
	#define MAX_NUMBER_OF_MISSIONS 	5
	
	
	#define B8(Num) 0bNum
	
	#define BIT0 00000001 
	#define BIT1 00000010 
	#define BIT2 00000100 
	#define BIT3 00001000 
	#define BIT4 00010000 
	#define BIT5 00100000 
	#define BIT6 01000000 
	#define BIT7 10000000 
	
	#define FALSE 0
	#define TRUE 1
	
	#define RESET 	RC7 //D�finition de la pi de reset
	#define CS 		RC6 //D�finition de la pin correspondant au Chip Select (CS)
	
	
	#define CHAR char
	#define UCHAR unsigned char
	#define PBOOL BOOL*
	#define PCHAR char*
	#define PUCHAR UCHAR*

	
	#define BOOL UCHAR
	#define BYTE UCHAR

	#define RAND_SEED_EEPROM_ADR 0

	#define MISSION_OFF 0
	#define MISSION_BLUE 1
	#define MISSION_RED 2
	#define MISSION_GREEN 3
		
	#define SELECT_OFF 		0
	#define SELECT_ON 		1
	
	#define VOTE_OFF 		0
	#define VOTE_GREEN 		1
	#define VOTE_RED 		2
	#define VOTE_GREEN_RED 	3

	#define NO_YET_VOTED	VOTE_OFF
	#define VOTE_YES 		VOTE_GREEN
	#define VOTE_NO 		VOTE_RED
	
	#define VOTE_MISSION_DEFEAT  VOTE_NO
	#define VOTE_MISSION_SUCCESS VOTE_YES

	#define SIDE_LED_OFF		0
	#define SIDE_LED_ON			1

	#define SIDE_RESISTANT 		SIDE_LED_OFF
	#define SIDE_SPY 			SIDE_LED_ON

	#define GAMESTATE_WAIT_FOR_PLAYERS 					1
	#define GAMESTATE_NOTIFY_PLAYER_SIDES 				2
	#define GAMESTATE_WAIT_CUR_PLAYER_SELECT_PLAYERS 	3
	#define GAMESTATE_WAIT_MISSION_VOTE 				4
	#define GAMESTATE_DISP_VOTE_RESULTS 				5
	#define GAMESTATE_PLAY_MISSION 						6
	#define GAMESTATE_DISP_MISSION_RESULT				7	
	#define GAMESTATE_GAMEOVER							8
		
	struct Player
	{
		BOOL Side:1;
		char SlotIndex:4;
		BOOL IsSelectedForMission:1;
		char VoteStatus:2;
	}  _players[MAX_NUMBER_OF_PLAYERS];;	

	//======================================================================================
	//> D�claration des variables globales
	//======================================================================================
	char _gameState = GAMESTATE_WAIT_FOR_PLAYERS;
	BOOL _playersSlotsStatus[MAX_NUMBER_OF_PLAYERS];
	char _numberOfRegisteredPlayers = 0;
	char _currentPlayerIndex = 0;
	char _currentMissionIndex = 0;
	
	const char NUM_SPIES_PER_NUM_PLAYERS[NUM_PLAYERS_RANGE] = {2, 2, 3, 3, 3, 4};
	const char VOTE_ABSOLUTE_MAJORITYS[NUM_PLAYERS_RANGE] = {3, 4, 4, 5, 5, 6};

	const char PLAYERS_PER_MISSION [MAX_NUMBER_OF_MISSIONS][NUM_PLAYERS_RANGE]  = { {2, 2, 2, 3, 3, 3},
																				  {3, 3, 3, 4, 4, 4},
																				  {2, 4, 3, 4, 4, 4},
																				  {3, 3, 4, 5, 5, 5},
																				  {3, 4, 4, 5, 5, 5} };
																				  
	char _numPlayersSelForCurMiss = 0;
	char _numPlayersExpectedForCurMiss = 0;
	char _numPlayerVotes = 0;
	volatile UCHAR _enterButtonFilterCounter = 0; 
	volatile BOOL _toggleBlink; 
	
	char _numMissionsWonBySpies = 0;
	char _numMissionsWonByResistance = 0;

#endif

