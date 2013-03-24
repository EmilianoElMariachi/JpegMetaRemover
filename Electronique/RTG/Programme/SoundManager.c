#include <htc.h>
#include "Definitions.h"
#include "MCP23S17.h"

//============================

#define MP3_NUM_CLOSE_YOUR_EYES 1

//============================

void _sendUsart(unsigned char byteToSend)
{
	TXREG = byteToSend;
	while(!TRMT);//Attend la fin de l'envoi de l'octet
}	

void stopPlaying()
{
	_sendUsart(0xEF);
}	

BOOL isPlaying()
{
	return (MCP23S17_GetPortB(0) & 0x80);
}	

void _playFile(char fileNumber, BOOL waitEnd)
{
	if(fileNumber > 0 && fileNumber < 200)
	{
		_sendUsart(fileNumber);
		
		if(waitEnd)
		{
			while(!isPlaying());	//Attend que la lecture commence
			while(isPlaying());		//Attend que la lecture se termine
		}
	}	
}	

void playSoundCloseYourEyes()
{
	_playFile(MP3_NUM_CLOSE_YOUR_EYES, TRUE);
}

void initSound()
{
	//Baud rate de 4800 pour un Oscillateur à 8Mhz
	SPBRG = 24;
	SPBRGH = 0;
	
	TXEN = 1;
	SYNC = 0;
	SPEN = 1;
	
	stopPlaying();	//Demande l'arrêt
	_sendUsart(231);//Met le volume au max	
	
	__delay_ms(500);
}