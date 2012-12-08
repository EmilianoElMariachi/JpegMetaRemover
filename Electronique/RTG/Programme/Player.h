#define MIN_NUMBER_OF_PLAYERS 5
#define MAX_NUMBER_OF_PLAYERS 10

//struct Player;

enum EnumPlayerVoteState
{
	NOT_YET_VOTED = 0,
	VOTED_NO = 1,
	VOTED_YES = 2
};

struct Player _ArrayOfPlayers[MAX_NUMBER_OF_PLAYERS];

char _numberOfPlayers;

char _arrayOfPlayersIndex[MAX_NUMBER_OF_PLAYERS];

