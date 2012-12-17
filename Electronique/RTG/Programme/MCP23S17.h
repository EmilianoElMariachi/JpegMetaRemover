#include "Definitions.h"


void MCP23S17_Reset();

void MCP23S17_Setup();

void MCP23S17_SetIODirectionA(BYTE address, BYTE portDirection);

void MCP23S17_SetIODirectionB(BYTE address, BYTE portDirection);

void MCP23S17_SetPortA(BYTE address, BYTE port);

BYTE MCP23S17_GetPortA(BYTE address);

void MCP23S17_SetPortB(BYTE address, BYTE port);

BYTE MCP23S17_GetPortB(BYTE address);

