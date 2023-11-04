#include "../TCPServer/tcpserver.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <winsock2.h>
#include <process.h>
#include "drsradamessage.h"

// Function to handle incoming data
void HandleData(char* data, int dataLength, SOCKET clientSocket)
{
    
    TRACK_VERSION1* track = (TRACK_VERSION1 *)data;
    printf("track position X = %f\n", track->positionX);
    printf("track position Y = %f\n", track->positionY);
    printf("track position Z = %f\n", track->positionZ);

}

void main()
{
    InitializeTCPServer();

    printf("Press any key to exit\n");
    int res = getchar();
   
}