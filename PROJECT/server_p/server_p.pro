TEMPLATE = app
CONFIG += console
CONFIG -= app_bundle
CONFIG -= qt
QMAKE_CFLAGS = -std=c99
SOURCES += main.c \
    ../roberry_p.c

HEADERS += \
    ../roberry_p.h

unix|win32: LIBS += -lSDL2

unix|win32: LIBS += -lSDL2_image

unix|win32: LIBS += -lSDL2_ttf
