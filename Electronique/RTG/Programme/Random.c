//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//
//¤¤¤              INCLUDES              ¤¤¤//
#include "Definitions.h"
#include "EEPROM.h"
//¤¤¤              INCLUDES              ¤¤¤//
//¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤//


//##########################################//
//###          VARIABLES LOCALES         ###//
static long _lastRandomNumber = 0;
//###          VARIABLES LOCALES         ###//
//##########################################//


//======================================================================================
//> Fonction permettant d'initialiser la graine du random à partir de la valeur 
//> sauvegardée dans la flash
//======================================================================================
void initializeRandomSeedFromFlash()
{
	BYTE* addrOfRandomNumber = (BYTE*)&_lastRandomNumber;

	*(addrOfRandomNumber + 0) = readByteFromEEPROM(RAND_SEED_EEPROM_ADR + 0); 		//Poid faible
	*(addrOfRandomNumber + 1) = readByteFromEEPROM(RAND_SEED_EEPROM_ADR + 1); 		
	*(addrOfRandomNumber + 2) = readByteFromEEPROM(RAND_SEED_EEPROM_ADR + 2); 		
	*(addrOfRandomNumber + 3) = readByteFromEEPROM(RAND_SEED_EEPROM_ADR + 3); 		//Poid fort
}

//======================================================================================
//>	Fonction permettant de sauvegarder la dernière valeur aléatoire générée
//======================================================================================
void saveRandomNumberToFlash()
{
	BYTE* addrOfRandomNumber = (BYTE*)&_lastRandomNumber;
	
	writeByteToEEPROM(RAND_SEED_EEPROM_ADR + 0, *(addrOfRandomNumber + 0));
	writeByteToEEPROM(RAND_SEED_EEPROM_ADR + 1, *(addrOfRandomNumber + 1));
	writeByteToEEPROM(RAND_SEED_EEPROM_ADR + 2, *(addrOfRandomNumber + 2));
	writeByteToEEPROM(RAND_SEED_EEPROM_ADR + 3, *(addrOfRandomNumber + 3));
}	

//======================================================================================
//> Retourne un nombre aléatoire entre 0 to 255
//======================================================================================
unsigned char getRandomNumber() 
{
	static BOOL _isRandomInitialized = FALSE;
	
	if(!_isRandomInitialized)
	{
		initializeRandomSeedFromFlash();
		_isRandomInitialized = TRUE;	
	}
	
	_lastRandomNumber = _lastRandomNumber * 1103515245L + 12345;
		
	PUCHAR adrRnd = (PUCHAR)&_lastRandomNumber;
		
	return adrRnd[0] + adrRnd[1] + adrRnd[2] + adrRnd[3];
}

//======================================================================================
//> Retourne un nombre aléatoire entre 0 to 255
//======================================================================================
unsigned char getRandomNumberBetweenZeroAnd(unsigned char maxValueExcluded)
{
	//[0->255]
	unsigned char randChar = getRandomNumber();
	
	unsigned char result = (unsigned char)((randChar * maxValueExcluded) / UCHAR_MAX);

	//Cas particulier uniquement pour randChar == 255
	if(result >= maxValueExcluded)
	{ result = maxValueExcluded -1; }	
	
	//[0->maxValue - 1]
	return result;
}	