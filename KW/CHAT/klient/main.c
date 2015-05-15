#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <unistd.h>
#include <string.h>
#include <stdio.h>

int main(int argc, char **argv)
{
    if(argc != 2)
    {
        write(2, "have to write adress\n", 21);
        return 1;
    }
    int aSocket = socket(AF_INET, SOCK_STREAM, 0);
    if(aSocket < 0)
    {
        write(2, "Error: socket\n", 11);
        return 1;   // mozhno i exit(1);
    }
    int error; // hranit kody obrabotki oshibok
    struct sockaddr_in peer;
    peer.sin_family = AF_INET;
    peer.sin_port = htons(7500); // ona preobrazobybaet k setevomu poryadku bait
    // peer.sin_addr.s_addr = inet_addr("127.0.0.1"); // 127.0.0.1 - eto my sami, nash komp
    peer.sin_addr.s_addr = inet_addr(argv[1]);
    error = connect(aSocket, (struct sockaddr *) &peer, sizeof(peer));
    if(error)
    {
        write(2, "ER: connect\n", 12);
        return 1;
    }

    char bufClient[128];
    char bufServer[128];
    int exit = 0;
    while(!exit)
    {
        write(1, "You: ", 5);
        fgets(bufClient, 128, stdin);
        error = write(aSocket, bufClient, 128); // posylaem posylku
        if(error <= 0)
        {
            write(2, "ER: write\n", 10);
            return 1;
        }
        else
        {
            int www = strcmp(bufClient, "exit\n");
            if(!www)
            {
                error = write(aSocket, "Your opponent left the chat.\n", 29);
                exit = 1;
                continue;
            }
            else
            {
                for(int i = 0; i < strlen(bufClient); ++i)
                    bufClient[i] = 0;
            }
        }

        error = read(aSocket, bufServer, 128);
        if(error <= 0)
        {
            write(2, "ER: read\n", 9);
            return 1;
        }
        else
        {
            int www = strcmp(bufServer, "exit\n");
            if(!www)
            {
                error = write(1, "Your opponent left the chat.\n", 29);
                exit = 1;
                continue;
            }
            write(1, "Opponent: ", 10);
            write(1, bufServer, strlen(bufServer));
            for(int i = 0; i < strlen(bufServer); ++i)
                bufServer[i] = 0;
        }
    }
    return 0;
}
