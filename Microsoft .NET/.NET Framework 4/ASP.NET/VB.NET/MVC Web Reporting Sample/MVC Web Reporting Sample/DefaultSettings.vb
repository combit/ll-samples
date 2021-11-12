Imports combit.Reporting
Imports combit.Reporting.DataProviders
Imports combit.Reporting.Repository
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace WebReporting
    Module CmbtSettings
        Public ReadOnly Property ArtkRecCount As Integer
            Get
                Return 20
            End Get
        End Property


        ' D:   Stellen Sie hier die Sprache für die Berichte und den Designer ein.
        ' US:  Set the language For the reports And the Designer here.
        Public ReadOnly Property Language As LlLanguage
            Get
                Return LlLanguage.English
                'Return LlLanguage.German
            End Get
        End Property

        ' D: Setzen Sie die gewünschte Einheit auf Inch oder Millimeter. SysDefault Werte verwenden für den WebReportDesigner immer Millimeter, um die Synchronisierung zwischen Client und Server zu gewährleisten.
        ' US: Set the Unit To Inch Or Millimeter. SysDefault Values automatically use millimeter In the web report designer context To make sure client And server units are synchronized. 
        Public ReadOnly Property Unit As LlUnits
            Get
                Return LlUnits.Inch_1_1000
                'Return LlUnits.Millimeter_1_100
            End Get
        End Property

        Public ReadOnly Property MultiTabRecCount As Integer
            Get
                Return 5
            End Get
        End Property

        Public ReadOnly Property UnlimitedRecordsList As List(Of String)
            Get
                Return New List(Of String)() From {
                    "Customer list with sort order.srt",
                    "Kundenliste mit Sortierung.lsr",
                    "Crosstab with comparison of previous year.srt",
                    "Kreuztabelle mit Vorjahresvergleich.lsr",
                    "Conditional formatting and native aggregate functions.srt",
                    "Bedingte Formatierung und native Aggregatsfunktionen.lsr"
                }
            End Get
        End Property

        Public ReadOnly Property IsEmployeeList As List(Of String)
            Get
                Return New List(Of String)() From {
                    "Mixed portrait and landscape.srt",
                    "Mischung von Hoch- und Querformat.lsr",
                    "Crosstab.srt",
                    "Kreuztabelle.lsr"
                }
            End Get
        End Property

        Public ReadOnly Property RepositoryLanguage As String
            Get

                If Language = LlLanguage.German Then
                    Return "de"
                End If

                Return "en"
            End Get
        End Property

        Public ReadOnly Property FileExtension As String
            Get
                If Language = LlLanguage.German Then
                    Return ".lsr"
                End If

                Return ".srt"
            End Get
        End Property
    End Module

    Module DefaultSettings
        Private _fileRepository As SQLiteFileRepository

        Function GetBaseRepository() As SQLiteFileRepository
            If _fileRepository Is Nothing Then
                _fileRepository = New SQLiteFileRepository(WebReporting.SampleWebReportingApplication.RepositoryDatabaseFile, CmbtSettings.RepositoryLanguage)
            End If

            Return _fileRepository
        End Function

        Private Function GetDataSourceForProject(ByVal repositoryIdOfProject As String, ByVal forDesign As Boolean) As IDataProvider
            If Not String.IsNullOrEmpty(repositoryIdOfProject) Then
                Dim reportDisplayName As String = GetBaseRepository().GetItem(repositoryIdOfProject).ExtractDisplayName()
                Dim dataProvider As IDataProvider = DataAccess.SampleData.CreateProviderCollection(reportDisplayName & CmbtSettings.FileExtension, forDesign)
                Return dataProvider
            End If

            Return Nothing
        End Function

        Function GetListLabelInstance(ByVal repositoryID As String, ByVal Optional repository As IRepository = Nothing) As ListLabel
            Dim LL As ListLabel = New ListLabel With {
                .DataSource = GetDataSourceForProject(repositoryID, False),
                .Language = CmbtSettings.Language,
				.Unit = CmbtSettings.Unit
            }

            If CmbtSettings.Language = LlLanguage.German Then
                LL.Variables.Add("ArtikelListe.ArtikelNr.Von", String.Empty)
                LL.Variables.Add("ArtikelListe.ArtikelNr.Bis", String.Empty)
            Else
                LL.Variables.Add("ItemList.ItemNo.From", String.Empty)
                LL.Variables.Add("ItemList.ItemNo.To", String.Empty)
            End If

            Return LL
        End Function
    End Module
End Namespace
