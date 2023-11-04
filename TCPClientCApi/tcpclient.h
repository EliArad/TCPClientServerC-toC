#ifndef TCP_CLIENT_H
#define TCP_CLIENT_H
#include <stdint.h>

int TCPClient_Initialize(int port);
void TCPClient_Close();
int TCPClient_Send(uint8_t* buffer, uint32_t size);
int TCPClient_Connect();


#endif 