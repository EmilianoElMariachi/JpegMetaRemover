#include <time.h>

#include "CustomTypes.h"
#include "EEPROM.h";

//=======================================================//
//===                   DEFINITIONS                   ===//
//=======================================================//
#define RAND_SEED_EEPROM_ADR 0

//=======================================================//
//===                    VARIABLES                    ===//
//=======================================================//
static	long _LastRandomNumber = 0;
static	BOOL _IsRandomInitialized = FALSE;


//=======================================================//
//===                    FONCTIONS                    ===//
//=======================================================//
void initializeRandomSeedFromFlash()
{
	
	
	BYTE byte0 = readByteFromEEPROM(RAND_SEED_EEPROM_ADR); 		//Poid faible
	BYTE byte1 = readByteFromEEPROM(RAND_SEED_EEPROM_ADR + 1);
	BYTE byte2 = readByteFromEEPROM(RAND_SEED_EEPROM_ADR + 2);
	BYTE byte3 = readByteFromEEPROM(RAND_SEED_EEPROM_ADR + 3);	//Poid fort
		
	_LastRandomNumber = (byte3 & 0xFFL) << 24 |
						(byte2 & 0xFFL) << 16 | 
						(byte1 & 0xFFL) <<  8 |
						(byte0 & 0xFFL) <<  0 ;
}

void saveRandomNumberToFlash()
{
	BYTE byte0 = (_LastRandomNumber >>  0) & 0x000000FF;
	BYTE byte1 = (_LastRandomNumber >>  8) & 0x000000FF;
	BYTE byte2 = (_LastRandomNumber >> 16) & 0x000000FF;
	BYTE byte3 = (_LastRandomNumber >> 24) & 0x000000FF;
	
	writeByteToEEPROM(RAND_SEED_EEPROM_ADR + 0, byte0);
	writeByteToEEPROM(RAND_SEED_EEPROM_ADR + 1, byte1);
	writeByteToEEPROM(RAND_SEED_EEPROM_ADR + 2, byte2);
	writeByteToEEPROM(RAND_SEED_EEPROM_ADR + 3, byte3);
	
	
}	

int getRandomNumber()
{
	if(!_IsRandomInitialized)
	{
		initializeRandomSeedFromFlash();
		_IsRandomInitialized = TRUE;	
	}
	
	_LastRandomNumber = _LastRandomNumber*1103515245L + 12345;
		
	saveRandomNumberToFlash();
		
	return((int)(_LastRandomNumber >> 16) & 077777);
}

