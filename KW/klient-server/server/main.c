#include <sys/socket.h>
#include <netinet/in.h>
#include <unistd.h>
#include <string.h>

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
    char buf[128];
    error = read(aSocket, buf, strlen(buf));
    if(error <= 0)
    {
        write(2, "ER: read\n", 9);
        return 1;
    }
    else
    {
        write(1, buf, strlen(buf));
        write(1, "\n", 1);
    }
    //posylaem tuda
    error = write(aSocket, "456", 3);
    if(error <= 0)
    {
        write(2, "ER: read\n", 9);
        return 1;
    }
    return 0;
}
