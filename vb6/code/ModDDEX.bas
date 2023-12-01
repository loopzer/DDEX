Attribute VB_Name = "ModDDEX"
Option Explicit

Public Enum DDEX_MEMORYMODE
    DX9_DEFAULT = 0
    DX9_ADMIN = 1
    DX9_SYSTEM = 2
End Enum
Public Enum DDEX_RENDERMODE
    DX9_HARDWARE = 0
    DX9_REF = 1
    DX9_SOFTWARE = 2
End Enum

Public Enum DDEX_VERTEXMODE
    DX9_HARDWARE = 0
    DX9_SOFTWARE = 1
End Enum

Public Enum DDEX_ANIMATION_TYPE
    LIGTHBOLT = 0
    LIGTHBOLTAUTOMATIC
End Enum

Public Type DDEX_CONFIGURATION
    Vsync As Byte
    Holder As Byte
    RenderMode As Byte
    VertexMode As Byte
    MemoryMode As Byte
    Deferral As Byte
End Type

Public Type DDEX_RECT
        Left As Long
        Top As Long
        Right As Long
        Bottom As Long
End Type

Public Type DDEX_RGBA
    a As Byte
    r As Byte
    g As Byte
    b As Byte
End Type

Public Type DDEX_LIGHT
    FileNum As Long
    Type As Byte
    RECT As DDEX_RECT
    Color As DDEX_RGBA
End Type

Public Type DDEX_POSITION
    X As Long
    Y As Long
End Type

Public Type DDEX_ANIMATION_LIGHTBOLT
    Color As DDEX_RGBA
    Duration As Long
    PositionsCount As Long
    positions As Long
End Type

Public Function DDEX_MakeRGBA(a As Byte, r As Byte, g As Byte, b As Byte) As DDEX_RGBA
    DDEX_MakeRGBA.a = a
    DDEX_MakeRGBA.r = r
    DDEX_MakeRGBA.g = g
    DDEX_MakeRGBA.b = b
End Function
