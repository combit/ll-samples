﻿Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports combit.Reporting.DesignerExtensions
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET
Imports combit.Reporting
Imports System.Text.RegularExpressions
Imports System.Collections.ObjectModel
Imports combit.ListLabel

'
' This code uses substantial portions of GMap.NET (http://greatmaps.codeplex.com). Please take note of the following license that is
' attached to GMaps.NET:
'

'
'Copyright (c) 2008-2010 Universe
'Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
'THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
'

Public Class Form1

    <STAThread>
    Public Shared Sub Main()
        SetProcessDPIAware()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SetProcessDPIAware() As Boolean
    End Function

    ' D: Datenquelle und Objekte initialisieren 
    'US: Datasource, initialization of used objects
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cities As String() = {"Konstanz", "Mexiko-City", "New York", "Seoul", "Mumbai", "São Paulo", "Manila", "Jakarta", "Delhi", "Kairo", "Istanbul", "Shanghai", "München", "Los Angeles", "Tokyo", "Buenos Aires", "Los Angeles", "Berlin", "London", "Sydney"}
        Dim pattern As String = "textBox(\d+)"
        Dim r As New Regex(pattern)

        For Each ctrl As Control In Me.Controls("GroupBox1").Controls
            Dim m As Match = r.Match(ctrl.Name)
            If m.Success Then
                ctrl.Text = cities(Convert.ToInt32(m.Groups(1).Value) - 1)
            End If
        Next

        ' D: Zuweisung DesignerObjekt
        'US: Assignment DesignerObject
        Dim MapObj As New MapsObject.combit.ListLabel.DesignerExtensions.MapsObject("MapsObject", "Maps Objekt", DirectCast(DesignerProperty.My.Resources.MapsObj, System.Drawing.Icon))
        LL.DesignerObjects.Add(MapObj)

        ' D: Projektdatei
        'US: Projectfile
        LL.AutoProjectFile = Application.StartupPath + "\..\..\..\..\..\..\..\Report Files\Maps.lst"

        ' D: Anzeige "Datei öffnen..."-Dialog
        'US: Show "File open" dialog
        LL.AutoShowSelectFile = False
    End Sub

    ' D: Textobjekte mit Inhalt füllen
    'US: Fill text objects
    Private Function GetDatasource() As ReadOnlyCollection(Of [String])
        Dim cities As String() = New String(19) {}

        Dim pattern As String = "textBox(\d+)"
        Dim r As New Regex(pattern)

        For Each ctrl As Control In Me.Controls("GroupBox1").Controls
            Dim m As Match = r.Match(ctrl.Name)
            If m.Success Then
                cities(Convert.ToInt32(m.Groups(1).Value) - 1) = ctrl.Text
            End If
        Next

        Return cities.ToList().AsReadOnly()
    End Function

    ' D: Design
    'US: Design
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Try
            'D: Datenquelle zuweisen
            'US: Data source 
            LL.DataSource = GetDatasource()

            ' D: Designer starten
            'US: Start designer
            LL.Design()
        Catch ListLabelException As Exception
            ' D: Exception abfangen
            'US: Catch Exceptions
            MessageBox.Show("Information: " + ListLabelException.Message + vbCrLf + vbCrLf + "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    ' D: Druck
    'US: Print
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        Try
            ' D: Statusanzeige bei Druck
            'US: Printing state
            LL.AutoBoxType = LlBoxType.StandardAbort

            ' D: Druckziel
            'US: Destination
            LL.AutoDestination = LlPrintMode.Export

            ' D: Datenquelle zuweisen
            'US: Data source 
            LL.DataSource = GetDatasource()

            ' D: Druck starten
            'US: Start printing
            LL.Print()
        Catch ListLabelException As Exception
            ' D: Exception abfangen
            'US: Catch Exceptions
            MessageBox.Show("Information: " + ListLabelException.Message + vbCrLf + vbCrLf + "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

End Class