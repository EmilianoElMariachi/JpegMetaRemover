#define MIN_NUMBER_OF_PLAYERS 5
#define MAX_NUMBER_OF_PLAYERS 10

//struct Player;

enum PlayerVoteStates
{
	NO_VOTE = 0,
	VOTE_NO = 1,
	VOTE_YES = 2
};

struct Player _ArrayOfPlayers[MAX_NUMBER_OF_PLAYERS];

char _numberOfPlayers;

char _arrayOfPlayersIndex[MAX_NUMBER_OF_PLAYERS];

enum PlayerVoteStates getPlayerVoteState(char playerIndex);