#include <stdio.h>
#include <winsock2.h>

#include "tcpclient.h"

static WSADATA wsa;
static SOCKET client_socket = INVALID_HANDLE_VALUE;
static struct sockaddr_in server;
static char buffer[1024];

int TCPClient_Initialize(int port)
{

    // Initialize Winsock
    if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0) {
        perror("Failed to initialize Winsock");
        return 0;
    }

    // Create a socket
    if ((client_socket = socket(AF_INET, SOCK_STREAM, 0)) == INVALID_SOCKET) {
        perror("Failed to create socket");
        return 0;
    }

    server.sin_family = AF_INET;
    if (inet_pton(AF_INET, "127.0.0.1", &server.sin_addr) <= 0) { // Replace with the server's IP address
        perror("Failed to convert IP address");
        return 0;
    }
    server.sin_port = htons(port); // Replace with the server's port number
}

int TCPClient_Connect()
{

    // Connect to the server
    if (connect(client_socket, (struct sockaddr*)&server, sizeof(server)) < 0) {
        perror("Failed to connect to the server");
        return 0;
    }

    return 1;
}

int TCPClient_Send(uint8_t *buffer, uint32_t size)
{

    send(client_socket, buffer, size, 0);

}

void TCPClient_Close()
{
    if (client_socket != INVALID_HANDLE_VALUE)
    {
        closesocket(client_socket);
    }
    WSACleanup();
}