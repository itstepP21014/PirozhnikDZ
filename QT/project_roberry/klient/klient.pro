TEMPLATE = app
CONFIG += console
CONFIG -= app_bundle
CONFIG -= qt
QMAKE_CFLAGS = -std=c99
SOURCES += main.c \
    ../ROBERRY/roberry.c

HEADERS += \
    ../ROBERRY/roberry.h

