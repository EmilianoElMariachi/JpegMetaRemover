//������������������������������������������//
//���              INCLUDES              ���//
#include <htc.h>

#include "SPI.h"
#include "missionsMngt.h"
//���              INCLUDES              ���//
//������������������������������������������//

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

