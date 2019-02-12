Attribute VB_Name = "Module1"
'D:  Hilfsfunktionen, um unter VB auf Access OLE Bitmaps zuzugreifen
'US: Helper functions used for working with Access OLE Bitmaps in VB

Public Declare Function GetTempFileName Lib "kernel32" Alias "GetTempFileNameA" (ByVal lpszPath As String, ByVal lpPrefixString As String, ByVal wUnique As Long, ByVal lpTempFileName As String) As Long
Public Declare Function GetTempPath Lib "kernel32" Alias "GetTempPathA" (ByVal nBufferLength As Long, ByVal lpBuffer As String) As Long
Public Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (lpvDest As Any, lpvSource As Any, ByVal cbCopy As Long)

Type PT
    Width As Integer
    Height As Integer
End Type

Type OBJECTHEADER
    Signature As Integer
    HeaderSize As Integer
    ObjectType As Long
    NameLen As Integer
    ClassLen As Integer
    NameOffset As Integer
    ClassOFfset As Integer
    ObjectSize As PT
    OleInfo As String * 256
End Type
Public Function WriteBitmap(ByVal OleField As Variant)
    Dim lpBuffer As String * 255
    Dim lpTempFileName As String * 255
    Call GetTempPath(250, lpBuffer)
    Call GetTempFileName(lpBuffer, "LL", 0, lpTempFileName)
    Call SetFileContents(DisplayBitmap(OleField), lpTempFileName)
    WriteBitmap = lpTempFileName
End Function
Function SetFileContents(sBitmapArray, sFileName As String)
    Const ForReading = 1, ForWriting = 2, ForAppending = 8
    Const TristateUseDefault = -2, TristateTrue = -1, TristateFalse = 0
    Dim fso, f, ts, i
    Set fso = CreateObject("Scripting.FileSystemObject")
    fso.CreateTextFile sFileName
    Set f = fso.GetFile(sFileName)
    Set ts = f.OpenAsTextStream(ForWriting, TristateUseDefault)
    For i = 0 To UBound(sBitmapArray)
        sTemp = sTemp & Chr(sBitmapArray(i))
    Next
    ts.Write sTemp
    ts.Close
    Set ts = f.OpenAsTextStream(ForReading, TristateUseDefault)
    TextStreamTest = ts.ReadLine
    ts.Close
End Function
Public Function DisplayBitmap(ByVal OleField As Variant)
    Dim Arr() As Byte
    Dim ObjHeader As OBJECTHEADER
    Dim Buffer As String
    Dim ObjectOffset As Long
    Dim BitmapOffset As Long
    Dim BitmapHeaderOffset As Integer
    Dim ArrBmp() As Byte
    Dim i As Long
    ReDim Arr(OleField.ActualSize)
    Arr() = OleField.GetChunk(OleField.ActualSize)
    CopyMemory ObjHeader, Arr(0), 19
    ObjectOffset = ObjHeader.HeaderSize + 1
    Buffer = ""
    For i = ObjectOffset To ObjectOffset + 512
        Buffer = Buffer & Chr(Arr(i))
    Next i
    If Mid(Buffer, 12, 6) = "PBrush" Then
        BitmapHeaderOffset = InStr(Buffer, "BM")
        If BitmapHeaderOffset > 0 Then
            BitmapOffset = ObjectOffset + BitmapHeaderOffset - 1
            ReDim ArrBmp(UBound(Arr) - BitmapOffset)
            CopyMemory ArrBmp(0), Arr(BitmapOffset), UBound(Arr) - BitmapOffset + 1
            DisplayBitmap = ArrBmp
        End If
    End If
End Function

