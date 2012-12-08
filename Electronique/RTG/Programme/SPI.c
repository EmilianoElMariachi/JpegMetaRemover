#include <htc.h>

#include "missionsMngt.h"

//TODO : supprimer le CS
#define CS 		RC6 //D�finition de la pin correspondant au Chip Select (CS)

//=====================================================================================================================================
void SPI_ERROR(char errNum)
{
	if(errNum == 0)		 //SSPOV
	{
		setMissionState(1, WON_BY_SPIES );
		//TODO : g�rer les erreurs
	}	
	else if(errNum == 1) //WCOL
	{
		setMissionState(2, WON_BY_SPIES );
		//TODO : g�rer les erreurs
	}	
	
	RA1 = 1;
}


char SPI_SendReceive(char byteToSend)
{
	//Rempli le buffer avec l'octet � envoyer
	SSPBUF = byteToSend;
	
	//Attent la fin de la transmission
	while(!BF);	
	
	//Lit le buffer pour r�cup�rer l'octet re�u
	char byteReceived = SSPBUF;

	if(WCOL != 0)
	{
		SPI_ERROR(0);
	}	
	else if(SSPOV != 0)
	{
		SPI_ERROR(1);
	}	
	
	return byteReceived;
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
