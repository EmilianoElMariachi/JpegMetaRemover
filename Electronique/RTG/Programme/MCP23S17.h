

#define IODIRA 		0x00
#define IODIRB 		0x01

#define IPOLA 		0x02
#define IPOLB 		0x03

#define GPINTENA 	0x04
#define GPINTENB 	0x05

#define DEFVALA		0x06
#define DEFVALB		0x07

#define INTCONA		0x08
#define INTCONB		0x09

#define IOCON		0x0A
#define IOCON2		0x0B

#define GPPUA 		0x0C
#define GPPUB 		0x0D

#define INTFA		0x0E
#define INTFB		0x0F

#define INTCAPA		0x10
#define INTCAPB		0x11

#define GPIOA 		0x12
#define GPIOB 		0x13

#define OLATA		0x14
#define OLATB		0x15

void MCP23S17_Write(BYTE address, BYTE registerToWrite, BYTE data);

BYTE MCP23S17_Read(BYTE address, BYTE registerToRead);

void MCP23S17_Reset();

void MCP23S17_Setup();

void MCP23S17_SetIODirectionA(BYTE address, BYTE portDirection);

BYTE MCP23S17_GetIODirectionA(BYTE address);

void MCP23S17_SetIOPolarityA(BYTE address, BYTE portPolarity);

void MCP23S17_SetPortA(BYTE address, BYTE port);

BYTE MCP23S17_GetPortA(BYTE address);

void MCP23S17_SetPortB(BYTE address, BYTE port);

BYTE MCP23S17_GetPortB(BYTE address);

BYTE MCP23S17_GetOutputLatchA(BYTE deviceAdr);