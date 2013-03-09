#include <htc.h>
#include "Definitions.h"
#include "MCP23S17.h";

#define SHORT_PRESS_DELAY 50
#define LONG_PRESS_DELAY 1000
	
#define BTN_ADR_NEXT_VOL_UP 0
#define BTN_IDX_NEXT_VOL_UP 0

#define BTN_ADR_STOP_PAUSE 0
#define BTN_IDX_STOP_PAUSE 1

#define BTN_ADR_PREV_VOL_DN 1
#define BTN_IDX_PREV_VOL_DN 2

//============================

void _pushNextBtn()
{
	_MCPPorts[BTN_IDX_NEXT_VOL_UP] = _MCPPorts[BTN_IDX_NEXT_VOL_UP] & B8(01111111);
	MCP23S17_SetPortB(BTN_ADR_NEXT_VOL_UP,_MCPPorts[BTN_IDX_NEXT_VOL_UP]);		
}	

void _releaseNextBtn()
{
	_MCPPorts[BTN_IDX_NEXT_VOL_UP] = _MCPPorts[BTN_IDX_NEXT_VOL_UP] | B8(10000000);
	MCP23S17_SetPortB(BTN_ADR_NEXT_VOL_UP, _MCPPorts[BTN_IDX_NEXT_VOL_UP]);		
}	

void pressNextBtn()
{
	_pushNextBtn();	
	__delay_ms(SHORT_PRESS_DELAY);
	_releaseNextBtn();	
}

//============================

void _pushPlayPauseBtn()
{
	_MCPPorts[BTN_IDX_STOP_PAUSE] = _MCPPorts[BTN_IDX_STOP_PAUSE] & B8(11111110);
	MCP23S17_SetPortA(BTN_ADR_STOP_PAUSE, _MCPPorts[BTN_IDX_STOP_PAUSE]);		
}	

void _releasePlayPauseBtn()
{
	_MCPPorts[BTN_IDX_STOP_PAUSE] = _MCPPorts[BTN_IDX_STOP_PAUSE] | B8(00000001);
	MCP23S17_SetPortA(BTN_ADR_STOP_PAUSE, _MCPPorts[BTN_IDX_STOP_PAUSE]);		
}

void pressPlayBtn()
{
	_pushPlayPauseBtn();
	__delay_ms(SHORT_PRESS_DELAY);
	_releasePlayPauseBtn();
}	

void longPressPlayBtn()
{
	_pushPlayPauseBtn();
	__delay_ms(LONG_PRESS_DELAY);
	_releasePlayPauseBtn();
}	


//============================

void _pushPrevBtn()
{
	_MCPPorts[BTN_IDX_PREV_VOL_DN] = _MCPPorts[BTN_IDX_PREV_VOL_DN] & B8(01111111);
	MCP23S17_SetPortB(BTN_ADR_PREV_VOL_DN, _MCPPorts[BTN_IDX_PREV_VOL_DN]);		
}	

void _releasePrevBtn()
{
	_MCPPorts[BTN_IDX_PREV_VOL_DN] = _MCPPorts[BTN_IDX_PREV_VOL_DN] | B8(10000000);
	MCP23S17_SetPortB(BTN_ADR_PREV_VOL_DN, _MCPPorts[BTN_IDX_PREV_VOL_DN]);		
}

void pressPrevBtn()
{
	_pushPrevBtn();
	__delay_ms(SHORT_PRESS_DELAY);
	_releasePrevBtn();
}

//============================

void playSoundCloseYourEyes()
{
	pressPlayBtn();
	__delay_ms(8000);
	longPressPlayBtn();
}	

//============================

void initSound()
{
	_releaseNextBtn();
	_releasePrevBtn();
	longPressPlayBtn();//STOP
}