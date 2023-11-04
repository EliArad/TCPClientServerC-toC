#ifndef TCP_SERVER_H
#define TCP_SERVER_H
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <winsock2.h>
#include <process.h>
#include <ws2tcpip.h>

void HandleData(char* data, int dataLength, SOCKET clientSocket);
int  InitializeTCPServer();
void CloseTCPServer();



#endif 