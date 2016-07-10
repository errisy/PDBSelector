Class MainWindow
    Private models As New System.Collections.ObjectModel.ObservableCollection(Of PDBModel)
    Private ModelRegex As New System.Text.RegularExpressions.Regex("^\s*MODEL\s+\d+\s*$")
    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        dgMain.ItemsSource = models
        Dim pdbFolder = New IO.DirectoryInfo("C:\Users\Jack\Documents\Visual Studio 2015\Projects\PDBCasper\PDBCasper\pdb")
        Dim limit As Integer = 0
        For Each info In pdbFolder.GetFiles("*.jpg")


            Dim model As New PDBModel
            model.ID = info.Name.Substring(0, 4)

            Dim id As String = model.ID
            Dim pdbFilename As String = pdbFolder.FullName + "\" + id + ".pdb"
            If Not IO.File.Exists(pdbFilename) Then Continue For

            model.Image = (Function() As BitmapImage
                               Dim bmp = New BitmapImage
                               bmp.BeginInit()
                               bmp.UriSource = New Uri(info.FullName)
                               bmp.EndInit()
                               Return bmp
                           End Function).Invoke()

            Dim asyncLoad = New Task(Sub()
                                         Dim code = (Function() As String
                                                         Try
                                                             Dim wc As New System.Net.WebClient
                                                             Return wc.DownloadString("http://www.abren.net/asaview/all/" + id.ToLower + "A.txt")
                                                         Catch ex As Exception
                                                             Return "Error"
                                                         End Try
                                                     End Function).Invoke()
                                         Dim lines = IO.File.ReadAllLines(pdbFolder.FullName + "\" + id + ".pdb")
                                         Dim models = String.Join(vbCrLf, lines.Where(Function(line) ModelRegex.IsMatch(line)).ToArray())
                                         Dispatcher.Invoke(Sub()
                                                               model.CodeFull = code
                                                               If model.CodeFull.Length > 50 Then
                                                                   model.Code = model.CodeFull.Substring(0, 50)
                                                               Else
                                                                   model.Code = model.CodeFull
                                                               End If
                                                               model.Models = models
                                                           End Sub)
                                     End Sub)
            asyncLoad.Start()
            models.Add(model)
            limit += 1
            If limit > 500 Then Exit For
        Next

        'Dim selector = "1F18,1F1G,1FFP,1FM4,1GQA,1GQO,1GRV,1GTD,1GXW,1H22,1H64,1HXH,1ISP,1ITW,1IVJ,1IX9,1IYO,1IZH,1J0T,1JOG,1JXN,1K1K,1K6M,1KJM,1KJP,1KK9,1KL6,1KN1,1KOL,1L4D,1L5R,1L7X,1L8S,1LFK,1LGF,1LL7,1LO5,1LV2,1LVC,1LVG,1LW5,1LWL,1M03,1M08,1M0T,1M0W,1M15,1M41,1M4U,1M67,1M6S,1M7Q,1MB3,1MBV,1MD0,1ME4,1MG3,1MGQ,1MHM,1MIV,1MKG,1MKK,1MLY,1MT5,1MTO,1MUK,1MW2,1MWB,1MWH,1MY5,1MZ8,1MZJ,1MZO,1N12,1N2F,1N4K,1N60,1N6D,1N7Q,1N7S,1N83,1N8I,1N8O,1N9R,1NCE,1ND5,1NDE,1NF5,1NFF,1NFR,1O12,1O13,1O1N,1O6S,1O6T,1O6V,1O76,1O81,1O99,1O9L"
        'Dim ids = selector.Split(",")

        'For Each model In models
        '    If ids.Contains(model.ID) Then model.Selected = True
        'Next

        Me.rSelected.Text = "0"
        Me.rCount.Text = models.Count.ToString
    End Sub

    Private Sub ExportSelected(sender As Object, e As RoutedEventArgs)
        Dim dInfo As New System.IO.DirectoryInfo("C:\Users\Jack\Documents\Visual Studio 2015\Projects\PDBCasper\PDBCasper\pdbSelected")
        If Not dInfo.Exists Then dInfo.Create()


        'Dim list = models.Where(Function(model As PDBModel) As Boolean
        '                            Return model.Selected
        '                        End Function).Select(Of String)(Function(model As PDBModel) As String
        '                                                            Return model.ID
        '                                                        End Function).ToArray()
        'Dim value = String.Join(",", list)

        'Dim k = value
        For Each model In models
            If model.Selected Then
                Dim pdbSource = "C:\Users\Jack\Documents\Visual Studio 2015\Projects\PDBCasper\PDBCasper\pdb\" + model.ID + ".pdb"
                Dim jpgSource = "C:\Users\Jack\Documents\Visual Studio 2015\Projects\PDBCasper\PDBCasper\pdb\" + model.ID + ".jpg"
                Dim pdbTarget = "C:\Users\Jack\Documents\Visual Studio 2015\Projects\PDBCasper\PDBCasper\pdbSelected\" + model.ID + ".pdb"
                Dim jpgTarget = "C:\Users\Jack\Documents\Visual Studio 2015\Projects\PDBCasper\PDBCasper\pdbSelected\" + model.ID + ".jpg"
                Dim ASA = "C:\Users\Jack\Documents\Visual Studio 2015\Projects\PDBCasper\PDBCasper\pdbSelected\" + model.ID + "_ASA.txt"
                IO.File.Move(pdbSource, pdbTarget)
                IO.File.Copy(jpgSource, jpgTarget)
                IO.File.WriteAllText(ASA, model.CodeFull)
            End If
        Next
    End Sub

    Private Sub TickChanged(sender As Object, e As RoutedEventArgs)

        Me.rSelected.Text = models.Where(Function(model)
                                             If model.CodeFull = "Error" Then
                                                 model.Selected = False
                                             End If
                                             Return model.Selected
                                         End Function).Count.ToString
        Me.rCount.Text = models.Count.ToString
    End Sub
End Class
