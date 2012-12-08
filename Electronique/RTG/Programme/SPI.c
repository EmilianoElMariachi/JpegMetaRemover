#include <htc.h>

//TODO : supprimer le CS
#define CS 		RC6 //Définition de la pin correspondant au Chip Select (CS)

//=====================================================================================================================================
void SPI_ERROR(char errNum)
{
	if(errNum == 0)		 //SSPOV
	{
		//TODO : gérer les erreurs
	}	
	else if(errNum == 1) //WCOL
	{
		//TODO : gérer les erreurs
	}	
	
	RA1 = 1;
}


char SPI_SendReceive(char byteToSend)
{
	
	SSPBUF = byteToSend;
	byteToSend = SSPBUF;
	while(!BF);	
	
	if(WCOL != 0)
	{
		SPI_ERROR(0);
	}	
	else if(SSPOV != 0)
	{
		SPI_ERROR(1);
	}	
	
	return SSPBUF;
}	

	

void SPI_Init()
{
	
	
	//_____________________________________________________________________________
	//> Configuration registre SSPSTAT : Synchronous Serial Port Status Register
	SSPSTAT = 0x40;// Configure register for SPI..(b6=0).
	
	//_____________________________________________________________________________
	//> Configuration registre SSPCON : Synchronous Serial Port Control Register 1
	SSPCON = 0x20;

	CS = 1;
}

//=====================================================================================================================================
