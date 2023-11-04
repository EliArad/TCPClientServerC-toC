#include "tcpserver.h"

static WSADATA wsaData;
static SOCKET serverSocket = INVALID_HANDLE_VALUE;
static struct sockaddr_in serverAddr;
static SOCKET clientSocket = NULL;

#pragma comment(lib, "ws2_32.lib")


static void ReceiveDataThread(void* clientSocket) 
{
    SOCKET client = *(SOCKET*)clientSocket;
    char buffer[1024];
    int bytesRead;

    while ((bytesRead = recv(client, buffer, sizeof(buffer), 0) > 0))
    {
        printf("Data Received: %d\n", bytesRead);
        HandleData(buffer, bytesRead, client);
         
    }

    closesocket(client);
    clientSocket = NULL;
     
}

int TCPServer_Send(uint8_t* buffer, uint32_t size)
{
    int res = send(clientSocket, buffer, size, 0);
    return res;
}

 
 
static void AcceptConnectionsThread(void* serverSocket)
{
    SOCKET server = *(SOCKET*)serverSocket;
    struct sockaddr_in clientAddr;
    int addrLen = sizeof(struct sockaddr_in);

    while (1) {
        printf("Waiting for connection...\n");
        clientSocket = accept(server, (struct sockaddr*)&clientAddr, &addrLen);
        if (clientSocket == INVALID_SOCKET) {
            printf("Socket accept failed.\n");
            continue;
        }
        printf("Server connected to client..\n");

        char clientIP[INET_ADDRSTRLEN];
        inet_ntop(AF_INET, &clientAddr.sin_addr, clientIP, INET_ADDRSTRLEN);
        printf("Client connected: %s:%d\n", clientIP, ntohs(clientAddr.sin_port));


        // Create a thread for data reception
        _beginthread(ReceiveDataThread, 0, &clientSocket);
    }
} 

int TCPServer_Initialize(int port)
{
    // Initialize Winsock
    if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0) {
        printf("WSAStartup failed.\n");
        return 0;
    }

    // Create the socket
    if ((serverSocket = socket(AF_INET, SOCK_STREAM, 0)) == INVALID_SOCKET) {
        printf("Socket creation failed.\n");
        return 0;
    }

    // Setup server address
    serverAddr.sin_family = AF_INET;
    serverAddr.sin_addr.s_addr = INADDR_ANY;
    serverAddr.sin_port = htons(port);

    // Bind the socket
    if (bind(serverSocket, (struct sockaddr*)&serverAddr, sizeof(serverAddr)) == SOCKET_ERROR) {
        printf("Socket bind failed.\n");
        closesocket(serverSocket);
        return 0;
    }

    // Listen for incoming connections
    if (listen(serverSocket, 5) == SOCKET_ERROR) {
        printf("Socket listen failed.\n");
        closesocket(serverSocket);
        return 0;
    }

    printf("Server listening on port %d...\n", port);

    // Create a thread for accepting connections
    _beginthread(AcceptConnectionsThread, 0, &serverSocket);


    return 1;
}
void TCPServer_Close()
{
    if (serverSocket != INVALID_HANDLE_VALUE)
    {
        closesocket(serverSocket);
        serverSocket = INVALID_HANDLE_VALUE;
    }
    WSACleanup();
}
