VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "ClsDdexAnimator"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit


Private Declare Sub Animation_Make Lib "DDEX.dll" (ByVal DDDEXRender As Long, ByVal AnimationType As Long, ByRef data As Any, ByVal DataCount As Long)

'Private Declare Function VB6_ArrayPointer Lib "msvbvm60" Alias "VarPtr" (arr As Any) As Long
Private DDEXRender As Long
Public Sub Init(ByVal DDEXRenderPointer As Long)
    DDEXRender = DDEXRenderPointer
End Sub

Public Sub CreateBolt()
    Dim data As DDEX_ANIMATION_LIGHTBOLT
    Dim positions(0 To 1) As DDEX_POSITION
    
    positions(0).X = 10
    positions(0).Y = 10
    
    positions(1).X = 200
    positions(1).Y = 200
    
    
    data.Color = DDEX_MakeRGBA(255, 255, 255, 255)
    
    data.Duration = 50

    
    data.PositionsCount = 2
    data.positions = VarPtr(positions(0))
    
    
    Call Animation_Make(DDEXRender, DDEX_ANIMATION_TYPE.LIGTHBOLTAUTOMATIC, data, 1)
    
End Sub

Public Sub Delete(ByVal DDEXAnimation As Long)

End Sub
