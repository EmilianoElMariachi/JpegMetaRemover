#include <htc.h>
#include "SPI.h";
#include "MCP23S17.h";


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


#define RESET 	RC7 //Définition de la pi de reset
#define CS 		RC6 //Définition de la pin correspondant au Chip Select (CS)

void MCP23S17_Write(char deviceAdr, char reg, char data)
{
	char opCode = (0x0E & (deviceAdr << 1)) | 0x40;	
	
	CS = 0; // Sélectionne le chip
	
	SPI_SendReceive(opCode);
	SPI_SendReceive(reg);
	SPI_SendReceive(data);
	
	CS = 1; // Desélectionne le chip
}

char MCP23S17_Read(char deviceAdr, char reg)
{
	char opCode = (0x0E & (deviceAdr << 1)) | 0x41;	
	
	CS = 0; // Sélectionne le chip
	SPI_SendReceive(opCode);
	SPI_SendReceive(reg);
	char ans = SPI_SendReceive(0); 	//Octet dummy juste pour recevoir la réponse

	CS = 1; // Desélectionne le chip
	
	return ans;
}

void MCP23S17_Reset()
{
	CS = 1; // disable I/O expander
	RESET = 0;
	
	for(int i = 0; i < 1000 ; i++);
	
	RESET = 1;
}	

void MCP23S17_Setup()
{
	//Ecriture de l'Opcode (1ere trame à l'adresse 0)
	MCP23S17_Write(0, IOCON, 0b00101000); //SEQOP=1; HAEN=1 pour activer l'adressage hardware
	
	for(char addressMCP23S17 = 0; addressMCP23S17 <= 4; addressMCP23S17++)
	{
		MCP23S17_Write(addressMCP23S17, IODIRA, 0b10000000); 
		MCP23S17_Write(addressMCP23S17, IODIRB, 0b00000001);		
	}	
}	


//=====================================================================
//1 = Pin is configured as an input.
//0 = Pin is configured as an output.
//=====================================================================
void MCP23S17_SetIODirectionA(char deviceAdr, char portDirection)
{
	MCP23S17_Write(deviceAdr, IODIRA, portDirection);
}	

char MCP23S17_GetIODirectionA(char deviceAdr)
{
	return MCP23S17_Read(deviceAdr, IODIRA);
}	

void MCP23S17_SetIOPolarityA(char deviceAdr, char portPolarity)
{
	MCP23S17_Write(deviceAdr, IPOLA, portPolarity);
}

void MCP23S17_SetPortA(char deviceAdr, char port)
{
	MCP23S17_Write(deviceAdr, GPIOA, port);
}

void MCP23S17_SetPortB(char deviceAdr, char port)
{
	MCP23S17_Write(deviceAdr, GPIOB, port);
}

char MCP23S17_GetPortA(char deviceAdr)
{
	return MCP23S17_Read(deviceAdr, GPIOA);
}

char MCP23S17_GetPortB(char deviceAdr)
{
	return MCP23S17_Read(deviceAdr, GPIOB);
}


char MCP23S17_GetOutputLatchA(char deviceAdr)
{
	return MCP23S17_Read(deviceAdr, OLATA);
}	