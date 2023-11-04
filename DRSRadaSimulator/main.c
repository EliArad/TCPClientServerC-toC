#include "../TCPServer/tcpserver.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <winsock2.h>
#include <process.h>
#include "drsradamessage.h"
#include "../TCPClientCApi/tcpclient.h"

void sendPosition()
{
    MODE_REQUEST  mr;
    mr.header.messageCounter = 50000;
    mr.header.messageOpcode = 1;
    mr.mode = 123;
    if (TCPClient_Send((uint8_t*)&mr, sizeof(mr)) == 0)
    {
        printf("failed to send");
    }
}


void sendTime()
{

}
 


// Function to handle incoming data
void HandleData(char* data, int dataLength, SOCKET clientSocket)
{
    DRSRadaHeader* header = (DRSRadaHeader*)data;
    if (header->messageOpcode == 7)
    {
        TRACK_VERSION1* track = (TRACK_VERSION1*)data;

        printf("track position X = %f\n", track->positionX);
        printf("track position Y = %f\n", track->positionY);
        printf("track position Z = %f\n", track->positionZ);
    }

}

void main()
{
    int choice;

    if (TCPServer_Initialize(7003) == 0)
    {
        printf("failed to create server on port 7003\n");
        TCPServer_Close();
        return;            
    }

    if (TCPClient_Initialize(7002) == 0)
    {
        printf("Failed to initialize client at 7002\n");
        return;            
    }
    
    while (TCPClient_Connect() == 0)
    {
        printf("waiting for client to connect\n");
        Sleep(1);
    }
    printf("Client Connected to host simulator server\n");

    do 
    {
        printf("\nMenu:\n");
        printf("1. Send Position\n");
        printf("2. Send Time\n");
        printf("3. Exit\n");
        printf("Enter your choice: ");

        if (scanf_s("%d", &choice) == 1) {
            switch (choice) {
            case 1:
                sendPosition();
                break;
            case 2:
                sendTime();
                break;
            case 3:
                printf("Exiting the program.\n");
                break;
            default:
                printf("Invalid choice. Please enter a valid option.\n");
            }
        }
        else {
            printf("Invalid input. Please enter a valid number.\n");
        }

        // Clear the input buffer to handle potential input errors
        while (getchar() != '\n');
    } while (choice != 3);
     
}