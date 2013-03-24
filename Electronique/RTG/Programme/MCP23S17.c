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


//======================================================================================
//> Fonction élémentaire permettant d'écrire un registre d'un MCP23S17
//======================================================================================
void MCP23S17_Write(BYTE deviceAdr, BYTE registerToWrite, BYTE data)
{
	BYTE opCode = (0x0E & (deviceAdr << 1)) | 0x40;	
	
	CS = 0; // Sélectionne le chip
	
	SPI_SendReceive(opCode);
	SPI_SendReceive(registerToWrite);
	SPI_SendReceive(data);
	
	CS = 1; // Desélectionne le chip
}

//======================================================================================
//> Fonction élémentaire permettant de lire un registre d'un MCP23S17
//======================================================================================
BYTE MCP23S17_Read(BYTE deviceAdr, BYTE registerToRead)
{
	char opCode = (0x0E & (deviceAdr << 1)) | 0x41;	
	
	CS = 0; // Sélectionne le chip
	SPI_SendReceive(opCode);
	SPI_SendReceive(registerToRead);
	char ans = SPI_SendReceive(0); 	//Octet dummy juste pour recevoir la réponse

	CS = 1; // Desélectionne le chip
	
	return ans;
}

//======================================================================================
//> Fonction permettant d'initialiser et configurer les MCP23S17
//======================================================================================
void MCP23S17_Setup()
{
	//Ecriture de l'Opcode (1ere trame à l'adresse 0)
	MCP23S17_Write(0, IOCON, B8(00101000)); //SEQOP=1; HAEN=1 pour activer l'adressage hardware
	
	MCP23S17_SetIODirectionB(0, B8(10110001));	
	MCP23S17_SetIODirectionA(0, B8(10001100)); 
	
	MCP23S17_SetIODirectionB(1, B8(10110001));	
	MCP23S17_SetIODirectionA(1, B8(00001101)); 

	MCP23S17_SetIODirectionB(2, B8(10110001));	
	MCP23S17_SetIODirectionA(2, B8(10001101)); 

	MCP23S17_SetIODirectionB(3, B8(10110001));	
	MCP23S17_SetIODirectionA(3, B8(10001101)); 

	MCP23S17_SetIODirectionA(4, B8(10001101)); 
	MCP23S17_SetIODirectionB(4, B8(10110001));	
	
	
	for(char addressMCP23S17 = 0; addressMCP23S17 <= 4; addressMCP23S17++)
	{
		MCP23S17_SetPortA(addressMCP23S17, B8(00000000));
		MCP23S17_SetPortB(addressMCP23S17, B8(00000000));	
	}	
	
	CS = 1; // disable I/O expander
}	


//======================================================================================
// Fonction permettant de configurer la direction du port A
//> portDirection
//> Bit set to 1 = Pin is configured as an input.
//> Bit set to 0 = Pin is configured as an output.
//======================================================================================
void MCP23S17_SetIODirectionA(BYTE deviceAdr, BYTE portDirection)
{
	MCP23S17_Write(deviceAdr, IODIRA, portDirection);
}	

//======================================================================================
// Fonction permettant de configurer la direction du port B
//> portDirection
//> Bit set to 1 = Pin is configured as an input.
//> Bit set to 0 = Pin is configured as an output.
//======================================================================================
void MCP23S17_SetIODirectionB(BYTE deviceAdr, BYTE portDirection)
{
	MCP23S17_Write(deviceAdr, IODIRB, portDirection);
}	

//======================================================================================
// Fonction permettant de définir l'état du port A
//======================================================================================
void MCP23S17_SetPortA(BYTE deviceAdr, BYTE port)
{
	MCP23S17_Write(deviceAdr, GPIOA, port);
}

//======================================================================================
// Fonction permettant de définir l'état du port B
//======================================================================================
void MCP23S17_SetPortB(BYTE deviceAdr, BYTE port)
{
	MCP23S17_Write(deviceAdr, GPIOB, port);
}

//======================================================================================
// Fonction permettant de connaitre l'état du port A
//======================================================================================
BYTE MCP23S17_GetPortA(BYTE deviceAdr)
{
	return MCP23S17_Read(deviceAdr, GPIOA);
}

//======================================================================================
// Fonction permettant de connaitre l'état du port B
//======================================================================================
char MCP23S17_GetPortB(char deviceAdr)
{
	return MCP23S17_Read(deviceAdr, GPIOB);
}


