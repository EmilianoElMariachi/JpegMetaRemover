//������������������������������������������//
//���              INCLUDES              ���//
#include <htc.h>

#include "SPI.h"
#include "missionsMngt.h"
//���              INCLUDES              ���//
//������������������������������������������//

//======================================================================================
//> TODO: a d�placer dans un fichier .C de gestion des erreurs
//======================================================================================
void SPI_ERROR(char errNum)
{
	if(errNum == 0)		 //SSPOV
	{
		//TODO : g�rer les erreurs
	}	
	else if(errNum == 1) //WCOL
	{
		//TODO : g�rer les erreurs
	}	
	
	RA1 = 1;
}

//======================================================================================
//> Fonction d'envoi et r�ception d'un octet sur le bus SPI
//======================================================================================
BYTE SPI_SendReceive(BYTE byteToSend)
{
	//Rempli le buffer avec l'octet � envoyer
	SSPBUF = byteToSend;
	
	//Attent la fin de la transmission
	while(!BF);	
	
	//Lit le buffer pour r�cup�rer l'octet re�u
	BYTE byteReceived = SSPBUF;

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

	
//======================================================================================
//> Configuration des registres permettant d'activer la liaison SPI
//======================================================================================
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

