VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "ClsDdex"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

Private Declare Function Render_Create Lib "DDEX.dll" (ByVal Plugin As String, ByVal hwnd As Long, ByVal ImageFolder As String, ByRef Configuration As Any) As Long

Private Declare Sub Render_SetMasterLight Lib "DDEX.dll" (ByVal DDEXRender As Long, ByVal Red As Long, ByVal Green As Long, ByVal Blue As Long)

Private Declare Sub Render_Destroy Lib "DDEX.dll" (ByVal DDDEXRender As Long)

Private Declare Sub Render_Present Lib "DDEX.dll" (ByVal DDEXRender As Long)

Private Declare Sub Render_Clean Lib "DDEX.dll" (ByVal DDEXRender As Long)

Private Declare Sub Render_FlushScreen Lib "DDEX.dll" (ByVal DDEXRender As Long)

Private Declare Sub Render_FlushBackground Lib "DDEX.dll" (ByVal DDEXRender As Long)

Private Declare Sub Render_CleanLight Lib "DDEX.dll" (ByVal DDEXRender As Long)

Private Declare Sub Render_DrawImage Lib "DDEX.dll" (ByVal DDEXRender As Long, ByVal FileNum As Long, ByVal X As Long, ByVal Y As Long, ByRef RECT As DDEX_RECT, ByRef Color As DDEX_RGBA)
Private Declare Sub Render_SetLight Lib "DDEX.dll" (ByVal DDEXRender As Long, ByRef Light As DDEX_LIGHT)

Private Declare Function Render_MakeFont Lib "DDEX.dll" (ByVal DDEXRender As Long, ByVal FontName As String, ByVal Size As Long, ByVal Bold As Boolean, ByVal Italic As Boolean, ByVal ForcedId As Long) As Long

Private Declare Sub Render_DrawFont Lib "DDEX.dll" (ByVal DDEXRender As Long, ByVal Text As String, ByVal FontId As Long, ByVal X As Long, ByVal Y As Long, ByRef Color As DDEX_RGBA)


Private DDEXRender As Long

Public Function MakeAnimator() As ClsDdexAnimator
    Set MakeAnimator = New ClsDdexAnimator
    Call MakeAnimator.Init(DDEXRender)
End Function
Public Function Init(ByVal hwnd As Long) As Boolean
    Dim c As DDEX_CONFIGURATION
    c.Deferral = 0
    c.Holder = 0
    c.Vsync = 1
    c.VertexMode = DDEX_VERTEXMODE.DX9_HARDWARE
    c.RenderMode = DDEX_RENDERMODE.DX9_HARDWARE
    c.MemoryMode = DDEX_MEMORYMODE.DX9_DEFAULT
    
    DDEXRender = Render_Create("DDEX_DX9", hwnd, App.Path & "\Graficos", c)
    
    If DDEXRender <= 0 Then
        MsgBox "Error"
        Init = False
    Else
        Init = True
    End If
    
End Function

Public Sub Present()
    Call Render_Present(DDEXRender)
End Sub
Public Sub FlushScreen()
    Call Render_FlushScreen(DDEXRender)
End Sub
Public Sub FlushBackground()
    Call Render_FlushBackground(DDEXRender)
End Sub
Public Sub Clean()
    Call Render_Clean(DDEXRender)
End Sub
Public Sub CleanLight()
    Call Render_CleanLight(DDEXRender)
End Sub
Public Sub SetMasterLight(ByVal Red As Long, ByVal Green As Long, ByVal Blue As Long)
    Call Render_SetMasterLight(DDEXRender, Red, Green, Blue)
End Sub
Friend Sub DrawLight(ByRef Light As DDEX_LIGHT)
    Call Render_SetLight(DDEXRender, Light)
End Sub
Friend Sub DrawImage(ByVal FileNum As Long, ByVal X As Integer, ByVal Y As Integer, ByRef RECT As DDEX_RECT, ByRef Color As DDEX_RGBA)
    Call Render_DrawImage(DDEXRender, FileNum, X, Y, RECT, Color)
End Sub
Public Function CreateFont(ByRef FontName As String, ByVal Size As Long, ByVal Bold As Boolean, ByVal Italic As Boolean) As Long
    CreateFont = Render_MakeFont(DDEXRender, FontName, Size, Bold, Italic, 0)
End Function
Friend Sub DrawFont(ByRef Text As String, ByVal FontId As Long, ByVal X As Long, ByVal Y As Long, ByRef Color As DDEX_RGBA)
    Call Render_DrawFont(DDEXRender, Text, FontId, X, Y, Color)
End Sub

Public Sub Destroy()
    If DDEXRender <= 0 Then Exit Sub
        Call Render_Destroy(DDEXRender)
End Sub
