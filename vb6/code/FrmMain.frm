VERSION 5.00
Begin VB.Form FrmMain 
   Caption         =   "DDEX"
   ClientHeight    =   8670
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   13395
   LinkTopic       =   "Form1"
   ScaleHeight     =   578
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   893
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer tmRender 
      Enabled         =   0   'False
      Interval        =   6
      Left            =   11760
      Top             =   8160
   End
   Begin VB.PictureBox PicMain 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      ForeColor       =   &H80000008&
      Height          =   6255
      Left            =   360
      ScaleHeight     =   6225
      ScaleWidth      =   7425
      TabIndex        =   0
      Top             =   480
      Width           =   7455
   End
End
Attribute VB_Name = "FrmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private Ddex As New ClsDdex
Private Animator As New ClsDdexAnimator
Private fontId As Long
Private Sub Form_Load()
    Dim r As Boolean
    Me.Show
    r = Ddex.Init(PicMain.hwnd)
    If r Then
        Set Animator = Ddex.MakeAnimator
        fontId = Ddex.CreateFont("Arial", 16, False, False)
        tmRender.Enabled = True
        
    End If
    
End Sub

Private Sub Form_Terminate()
    Ddex.Destroy
End Sub

Private Sub Render()
    Dim r As DDEX_RECT
    Dim c As DDEX_RGBA
    Dim l As DDEX_LIGHT
    
    l.FileNum = 103
    l.Type = 0
    l.RECT.Left = 10
    l.RECT.Top = 10
    l.RECT.Right = 50
    l.RECT.Bottom = 50
    l.Color = DDEX_MakeRGBA(255, 255, 255, 255)
    
    
    
    r.Bottom = 200
    r.Right = 200
    c.a = 255
    c.r = 255
    c.b = 255
    c.g = 255
    Call Ddex.SetMasterLight(200, 200, 200)
    Call Ddex.CleanLight
    Call Ddex.Clean
    
    Call Ddex.FlushBackground
    
    Call Ddex.DrawImage(6002, 10, 10, r, c)
    Call Ddex.DrawLight(l)
    Call Ddex.FlushScreen
    Call Ddex.DrawFont("Hi! from DDEX", fontId, 30, 30, c)
    Call Ddex.Present
End Sub

Private Sub PicMain_Click()
    Animator.CreateBolt
End Sub

Private Sub tmRender_Timer()
    Render
End Sub
