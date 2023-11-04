#ifndef DRS_RADA_MESSAGE_H
#define DRS_RADA_MESSAGE_H

#pragma pack(push, 1) 

typedef struct DRSRadaHeader
{
    uint32_t messageCounter;
    uint32_t messageOpcode;

} DRSRadaHeader;


typedef struct  TRACK_VERSION1
{
   DRSRadaHeader header;
   float positionX;
   float positionY;
   float positionZ;

} TRACK_VERSION1;

 
typedef struct MODE_REQUEST
{
    DRSRadaHeader header;
	int mode;

} MODE_REQUEST;

#pragma pack(pop)


#endif 