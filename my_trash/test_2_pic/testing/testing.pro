TEMPLATE = app
CONFIG += console
CONFIG -= app_bundle
CONFIG -= qt

SOURCES += main.c

unix|win32: LIBS += -lSDL2_image

unix|win32: LIBS += -lSDL2
