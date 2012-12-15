#define MIN_NUMBER_OF_PLAYERS 5
#define MAX_NUMBER_OF_PLAYERS 10


/*
struct Player
{
	BOOL isSpy;
	BOOL isActive;
	enum PlayerVoteStates voteStatus;
	
};	

struct Player _ArrayOfPlayers[MAX_NUMBER_OF_PLAYERS];

char _arrayOfPlayersIndex[MAX_NUMBER_OF_PLAYERS];

*/
BOOL isEnterButtonPressed();

void getPlayerInputState(char playerIndex, BOOL* yesIsPressed, BOOL* noIsPressed, BOOL* selectIsPressed);