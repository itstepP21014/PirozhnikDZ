
all: obj/main.o obj/funs.o bin/
	gcc -o bin/app obj/*
obj/main.o: main.c obj/
	gcc --std=c11 -o obj/main.o -c main.c
obj/funs.o: funs.c obj/
	gcc --std=c11 -o obj/funs.o -c funs.c

bin/:
	mkdir bin

obj/:
	mkdir obj

clean:
	rm -rf bin obj
