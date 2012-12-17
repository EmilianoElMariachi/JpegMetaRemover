#include "Definitions.h"
#include "EEPROM.h";

//=======================================================//
//===                   DEFINITIONS                   ===//
//=======================================================//
#define RAND_SEED_EEPROM_ADR 0

//=======================================================//
//===                    VARIABLES                    ===//
//=======================================================//
long _lastRandomNumber = 0;

//=======================================================//
//===                    FONCTIONS                    ===//
//=======================================================//
void initializeRandomSeedFromFlash()
{
	BYTE* addrOfRandomNumber = (BYTE*)&_lastRandomNumber;

	*(addrOfRandomNumber + 0) = readByteFromEEPROM(RAND_SEED_EEPROM_ADR + 0); 		//Poid faible
	*(addrOfRandomNumber + 1) = readByteFromEEPROM(RAND_SEED_EEPROM_ADR + 1); 		
	*(addrOfRandomNumber + 2) = readByteFromEEPROM(RAND_SEED_EEPROM_ADR + 2); 		
	*(addrOfRandomNumber + 3) = readByteFromEEPROM(RAND_SEED_EEPROM_ADR + 3); 		//Poid fort
}

void saveRandomNumberToFlash()
{
	BYTE* addrOfRandomNumber = (BYTE*)&_lastRandomNumber;
	
	writeByteToEEPROM(RAND_SEED_EEPROM_ADR + 0, *(addrOfRandomNumber + 0));
	writeByteToEEPROM(RAND_SEED_EEPROM_ADR + 1, *(addrOfRandomNumber + 1));
	writeByteToEEPROM(RAND_SEED_EEPROM_ADR + 2, *(addrOfRandomNumber + 2));
	writeByteToEEPROM(RAND_SEED_EEPROM_ADR + 3, *(addrOfRandomNumber + 3));
}	

int getRandomNumber()
{
	static BOOL _isRandomInitialized = FALSE;
	
	if(!_isRandomInitialized)
	{
		initializeRandomSeedFromFlash();
		_isRandomInitialized = TRUE;	
	}
	
	_lastRandomNumber = _lastRandomNumber*1103515245L + 12345;
		
	saveRandomNumberToFlash();
		
	return((int)(_lastRandomNumber >> 16) & 077777);
}

