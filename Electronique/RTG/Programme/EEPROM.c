#include <htc.h>

#include "EEPROM.h"

void setupEEPROM()
{
	//Active l'�criture en EEPROM
	WREN = 1;
	
	//Mode d'adressage sur l'EEPROM (et non sur programme)
	EEPGD = 0;
}	

void writeByteToEEPROM(BYTE address, BYTE value)
{
	//Attend la fin de l'�criture pr�c�dente (s�curit�)
	while(WR);
	
	//D�fini l'adresse de l'octet � �crire
	EEADR = address;
	
	//D�fini la valeur � �crire
	EEDAT = value;
	
	//S�quence obligatoire (cf. documentation)
	EECON2=0x55;
	EECON2=0xAA;
	
	//Donne l'ordre d'�criture
	WR = 1;
}

BYTE readByteFromEEPROM(BYTE address)
{
	//Attend la fin de la lecture pr�c�dente (s�curit�)
	while(RD);
	
	//D�fini l'adresse de l'octet � �crire
	EEADR = address;
	
	//Donne l'ordre de lecture
	RD = 1;
	
	//Attend la fin de la lecture
	while(RD);

	//Retourne la valeur
	return EEDAT;
}