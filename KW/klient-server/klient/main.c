#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <unistd.h>
#include <string.h>

int main(int argc, char **argv)
{
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

    char buf[128]="Privet, Oleg! ;)";
    error = write(aSocket, buf, 128); // posylaem posylku
    if(error <= 0)
    {
        write(2, "ER: write\n", 10);
        return 1;
    }

    error = read(aSocket, buf, 128);
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
    return 0;
}
