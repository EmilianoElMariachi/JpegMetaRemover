#include "Definitions.h"

void switchOffAllMissionLeds();

void setMissionState(char missionIndex, enum MissionStates eMissionState);

void displayError(char nbErrors, enum MissionStates blinkColor);