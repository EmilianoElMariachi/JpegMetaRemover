#include <htc.h>

#include "EEPROM.h"

void setupEEPROM()
{
	//Active l'écriture en EEPROM
	WREN = 1;
	
	//Mode d'adressage sur l'EEPROM (et non sur programme)
	EEPGD = 0;
}	

void writeByteToEEPROM(BYTE address, BYTE value)
{
	//Attend la fin de l'écriture précédente (sécurité)
	while(WR);
	
	//Défini l'adresse de l'octet à écrire
	EEADR = address;
	
	//Défini la valeur à écrire
	EEDAT = value;
	
	//Séquence obligatoire (cf. documentation)
	EECON2=0x55;
	EECON2=0xAA;
	
	//Donne l'ordre d'écriture
	WR = 1;
}

BYTE readByteFromEEPROM(BYTE address)
{
	//Attend la fin de la lecture précédente (sécurité)
	while(RD);
	
	//Défini l'adresse de l'octet à écrire
	EEADR = address;
	
	//Donne l'ordre de lecture
	RD = 1;
	
	//Attend la fin de la lecture
	while(RD);

	//Retourne la valeur
	return EEDAT;
}