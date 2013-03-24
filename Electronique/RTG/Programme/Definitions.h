//======================================================================================
//>	Déclaration des types et des énumérations partagées dans le programme
//======================================================================================
#ifndef COMMON_DATA_TYPES
#define  COMMON_DATA_TYPES
	#define _XTAL_FREQ 8000000	//Oscillateur interne cadencé à 8 Mhz

	#define BUTTON_FILTER_DELAY 10
	
	#define BLINK_ERROR_DELAY_MS 200
	#define NUM_BLINKS_ERROR 3

	#define BLINK_FREQ 5
   
	#define UCHAR_MAX 255
	
	#define NUM_NON_ACCEPT_CONSEC_MISS_GAMEOVER 5
	
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
	
	#define  testbit(var, bit)  ((var) & (1 <<(bit)))
	#define  setbit(var, bit)   ((var) |= (1 << (bit)))
	#define  clrbit(var, bit)   ((var) &= ~(1 << (bit)))
	
	
	#define FALSE 0
	#define TRUE 1
	
	#define CS 					RB7 	//Définition de la pin correspondant au Chip Select (CS)
	#define ENTER_BUTTON_STATE	RB6 	//La pin correspondant au bouton 'Enter' (0 relaché, 1 appuyé)
	
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

	#define LED_OFF			0
	#define LED_ON			1

	#define SIDE_LED_OFF		LED_OFF
	#define SIDE_LED_ON			LED_ON

	#define SIDE_RESISTANT 		SIDE_LED_OFF
	#define SIDE_SPY 			SIDE_LED_ON

	#define GAMESTATE_WAIT_FOR_PLAYERS 					1
	#define GAMESTATE_NOTIFY_PLAYER_SIDES 				2
	#define GAMESTATE_WAIT_LEADER_SELECT_PLAYERS 		3
	#define GAMESTATE_WAIT_MISSION_VOTE 				4
	#define GAMESTATE_DISP_VOTE_RESULTS 				5
	#define GAMESTATE_PLAY_MISSION 						6
	#define GAMESTATE_DISP_MISSION_RESULT				7	
	#define GAMESTATE_GAMEOVER							8
		
	#define WINNER_IS_RESISTANCE		SIDE_RESISTANT
	#define WINNER_IS_SPIES				SIDE_SPY
	#define WINNER_NOT_YET				2
	
	#define BUTTON_FILTER_TIME			3
	#define NUM_BUTTONS_FILTERED		11
	#define ENTER_BTN_FILTER_INDEX		10
	
	struct Player
	{
		BOOL Side:1;
		char SlotIndex:4;
		BOOL IsSelectedForMission:1;
		char VoteStatus:2;
	}  _players[MAX_NUMBER_OF_PLAYERS];	

	//======================================================================================
	//> Déclaration des variables globales
	//======================================================================================
	char _MCPPorts[MAX_NUMBER_OF_PLAYERS] = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

	char _gameState = GAMESTATE_WAIT_FOR_PLAYERS;
	BOOL _playersSlotsStatus[MAX_NUMBER_OF_PLAYERS];
	char _numberOfRegisteredPlayers = 0;	//Le nombre de joueurs
	char _currentLeaderIndex = 0;			//L'index du joueur ayant le role de désigner les joueurs sélectionnés pour la mission courante
	char _currentMissionIndex = 0;			//L'index de la mission en cours
	
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
	BOOL _absoluteMajorityReached = FALSE; 		//Booléen mis à jour à la fin des votes pour la missions en cours
	
	
	volatile char _buttonsFilterCounters[NUM_BUTTONS_FILTERED] = {0,0,0,0,0,0,0,0,0,0};
	volatile BOOL _toggleBlink = FALSE; 
	
	char _numSpiesWhoVotesForMissFailed = 0;		//Nombre d'espions ayant votés pour l'échec de la mission en cours
	char _slotIndexForMissionResultAnim = 0;


	char _numMissionsWonBySpies = 0;
	char _numMissionsWonByResistance = 0;
	char _numConsecMissNonAccepted = 0;
	char _winnersIs = WINNER_NOT_YET;	

#endif


