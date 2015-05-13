TEMPLATE = app
CONFIG += console
CONFIG -= app_bundle
CONFIG -= qt
QMAKE_CFLAGS = -std=c99
SOURCES += main.c \
    ../lib/roberry_p.c

HEADERS += \
    ../lib/roberry_p.h

unix|win32: LIBS += -lSDL2

unix|win32: LIBS += -lSDL2_image

unix|win32: LIBS += -lSDL2_ttf
