#include <stdio.h>
#include <stdlib.h>
#include <math.h>

typedef struct Time_ {
    int hour;
    int minute;
    int second;
}Time;

void output_time(Time n);
//Time input_time(Time n);
void compare_time(Time a, Time b);
Time add_time(int adding, Time n);

void output_time(Time n)
{
    printf("%02d:%02d:%02d\n", n.hour, n.minute, n.second);
}

/*
Time input_time(Time n)
{
    printf("Vvedite vremya:\n");
    scanf("%d %d %d", &n.hour, &n.minute, &n.second);
    return n;
}
*/

void compare_time(Time a, Time b)
{
    int raznica, h=0, m=0, s=0;
    if(a.hour == b.hour && a.minute == b.minute && a.second == b.second)
        printf("\nRaznicy vo vremeni net.\n");
    else
    {
        h=abs(a.hour-b.hour);
        m=abs(a.minute-b.minute);
        s=abs(a.second-b.second);
        h=h*60*60;
        m*=60;
        raznica=h+m+s;
        printf("Raznica vo vremeni: %d secund.\n", raznica);
    }
}

Time add_time(int adding, Time n)
{
    int h=0, m=0, s=0;
    if(adding >= 86400)
        printf("Raznica vo vremeni bolshe sutok.\n");
    if(adding >= 3600)
        h=adding/3600;
    m=(adding-(h*3600))/60;
    s=adding-(m*60)-(h*3600);
    n.hour+=h;
    n.minute+=m;
    n.second+=s;
    return n;
}

int main()
{
    Time time1, time2;

    //input_time(time1);
    printf("Vvedite vremya:\n");
    scanf("%d %d %d", &time1.hour, &time1.minute, &time1.second);

    printf("Vremya 1: ");
    output_time(time1);

    //input_time(time2);
    printf("Vvedite vremya:\n");
    scanf("%d %d %d", &time2.hour, &time2.minute, &time2.second);

    printf("Vremya 2: ");
    output_time(time2);

    compare_time(time1, time2);
    add_time(8102, time2);
    output_time(time2);
    return 0;
}
