#include <htc.h>
#include "SPI.h";
#include "MCP23S17.h";



#define RESET 	RC7 //Définition de la pi de reset
#define CS 		RC6 //Définition de la pin correspondant au Chip Select (CS)

void MCP23S17_Write(BYTE deviceAdr, BYTE registerToWrite, BYTE data)
{
	BYTE opCode = (0x0E & (deviceAdr << 1)) | 0x40;	
	
	CS = 0; // Sélectionne le chip
	
	SPI_SendReceive(opCode);
	SPI_SendReceive(registerToWrite);
	SPI_SendReceive(data);
	
	CS = 1; // Desélectionne le chip
}

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
	MCP23S17_Write(0, IOCON, B8(00101000)); //SEQOP=1; HAEN=1 pour activer l'adressage hardware
	
	for(char addressMCP23S17 = 0; addressMCP23S17 <= 4; addressMCP23S17++)
	{
		MCP23S17_Write(addressMCP23S17, IODIRA, B8(10001100)); 
		MCP23S17_Write(addressMCP23S17, IODIRB, B8(00110001));		
	}	
}	


//=====================================================================
//1 = Pin is configured as an input.
//0 = Pin is configured as an output.
//=====================================================================
void MCP23S17_SetIODirectionA(BYTE deviceAdr, BYTE portDirection)
{
	MCP23S17_Write(deviceAdr, IODIRA, portDirection);
}	

char MCP23S17_GetIODirectionA(BYTE deviceAdr)
{
	return MCP23S17_Read(deviceAdr, IODIRA);
}	

void MCP23S17_SetIOPolarityA(BYTE deviceAdr, BYTE portPolarity)
{
	MCP23S17_Write(deviceAdr, IPOLA, portPolarity);
}

void MCP23S17_SetPortA(BYTE deviceAdr, BYTE port)
{
	MCP23S17_Write(deviceAdr, GPIOA, port);
}

void MCP23S17_SetPortB(BYTE deviceAdr, BYTE port)
{
	MCP23S17_Write(deviceAdr, GPIOB, port);
}

BYTE MCP23S17_GetPortA(BYTE deviceAdr)
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