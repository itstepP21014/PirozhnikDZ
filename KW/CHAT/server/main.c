#include <sys/socket.h>
#include <netinet/in.h>
#include <unistd.h>
#include <string.h>
#include <stdio.h>

int main()
{
    int listenSocket = socket(AF_INET, SOCK_STREAM, 0);
    if(listenSocket < 0)
    {
        write(2, "Error: socket\n", 14);
        return 1;   // mozhno i exit(1);
    }
    int error; // hranit kody obrabotki oshibok
    struct sockaddr_in local;
    local.sin_family = AF_INET;
    local.sin_port = htons(7500);
    local.sin_addr.s_addr = htonl(INADDR_ANY); // slushat' vseh i otovsudu
    error = bind(listenSocket, (struct sockaddr *) &local, sizeof(local));
    if(error)
    {
        write(2, "ER: bind\n", 9);
        return 1;
    }
    error = listen(listenSocket, 5); // slushaem
    if(error)
    {
        write(2, "ER: listen\n", 11);
        return 1;
    }
    int aSocket = accept(listenSocket, NULL, NULL); //nam vse ravno kto prishel
    if(aSocket < 0)
    {
        write(2, "ER: accept\n", 11);
        return 1;
    }


    char bufClient[128];
    char bufServer[128];
    int exit = 0;
    while(!exit)
    {
        error = read(aSocket, bufClient, 128);
        if(error <= 0)
        {
            write(2, "ER: read\n", 9);
            return 1;
        }
        else
        {
            int www = strcmp(bufClient, "exit\n");
            if(!www)
            {
                error = write(1, "Your opponent left the chat.\n", 29);
                exit = 1;
                continue;
            }
            write(1, "Opponent: ", 10);
            write(1, bufClient, strlen(bufClient));
            for(int i = 0; i < strlen(bufClient); ++i)
                bufClient[i] = 0;
        }

        write(1, "You: ", 5);
        fgets(bufServer, 128, stdin);
        error = write(aSocket, bufServer, 128);
        if(error <= 0)
        {
            write(2, "ER: write\n", 10);
            return 1;
        }
        else
        {
            int www = strcmp(bufServer, "exit\n");
            if(!www)
            {
                error = write(aSocket, "Your opponent left the chat.\n", 29);
                exit = 1;
            }
            else
            {
                for(int i = 0; i < strlen(bufServer); ++i)
                bufServer[i] = 0;
            }
        }
    }
    return 0;
}
