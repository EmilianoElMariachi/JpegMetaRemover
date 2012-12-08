enum MissionState
{
	NOT_YET_STARTED = 1,
	STARTED = 2,
	WON_BY_SPIES = 3,
	WON_BY_RESISTANCE = 4
};

void setMissionState(char missionNumber, enum MissionState eMissionState);
