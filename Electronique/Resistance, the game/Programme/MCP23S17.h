void MCP23S17_Write(char address, char reg, char data);

char MCP23S17_Read(char address, char reg);

void MCP23S17_Reset();

void MCP23S17_Setup();

void MCP23S17_SetIODirectionA(char address, char portDirection);

char MCP23S17_GetIODirectionA(char address);

void MCP23S17_SetIOPolarityA(char address, char portPolarity);

void MCP23S17_SetPortA(char address, char port);

char MCP23S17_GetPortA(char address);

void MCP23S17_SetPortB(char address, char port);

char MCP23S17_GetPortB(char address);

char MCP23S17_GetOutputLatchA(char deviceAdr);