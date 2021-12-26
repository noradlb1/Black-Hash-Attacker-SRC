Imports System.Security.Cryptography
Imports System.Text
Public Class Form1
    Dim salt As String = ""
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox2.Checked Then
            salt = TextBox4.Text
        End If
        TextBox3.Text = "Please Wait..."
        Dim attacker As New Threading.Thread(AddressOf SingleAttack)
        attacker.Start(ComboBox1.Text)
    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As New OpenFileDialog
        With a
            .Filter = "txt (*.txt)|*.txt"
            .Title = "select password list"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                TextBox1.Text = .FileName
            Else
                Return
            End If
        End With
    End Sub

    Private Sub TextBox2_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text.Length = 32 Then
            ComboBox1.Text = "MD5"
        ElseIf TextBox2.Text.Length = 40 Then
            ComboBox1.Text = "SHA1"
        ElseIf TextBox2.Text.Length = 64 Then
            ComboBox1.Text = "SHA256"
        ElseIf TextBox2.Text.Length = 96 Then
            ComboBox1.Text = "SHA384"
        ElseIf TextBox2.Text.Length = 128 Then
            ComboBox1.Text = "SHA512"
        ElseIf TextBox2.Text.Length > 128 Then
            MsgBox("Sorry we do not support this hash yet", MsgBoxStyle.Critical, "):")
        End If
    End Sub
    Private Delegate Sub UpdatePasswordTextDelegate(ByVal status As String)
    Private Sub UpdatePasswordText(ByVal status As String)
        Try
            BeginInvoke(New UpdatePasswordTextDelegate(AddressOf UpdatePasswordTextSub), status)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub UpdatePasswordTextSub(ByVal status As String)
        Try
            TextBox3.Text = status
        Catch ex As Exception

        End Try
    End Sub
    Sub SingleAttack(ByVal HashType As String)
        Dim PasswordList() As String = IO.File.ReadAllLines(TextBox1.Text)
        Dim Count As Integer = PasswordList.Length
        Dim Password As Integer = 0
        For Each hash As String In PasswordList
            Select Case HashType
                Case "MD5"
                    Label1.Text = "Password Teste: " & Password & "/" & Count
                    Password = Password + 1
                    If CheckBox2.Checked Then
                        If GetHashMD5(salt & hash) = TextBox2.Text.ToUpper Then
                            UpdatePasswordText("Password Found : " & hash)
                            MsgBox("Hash Has Been Cracked !", MsgBoxStyle.Information, "Done!")
                            Return
                        End If
                    Else
                        If GetHashMD5(hash) = TextBox2.Text.ToUpper Then
                            UpdatePasswordText("Password Found : " & hash)
                            MsgBox("Hash Has Been Cracked !", MsgBoxStyle.Information, "Done!")
                            Return
                        End If
                    End If

                Case "SHA1"
                    Label1.Text = "Password Teste: " & Password & "/" & Count
                    Password = Password + 1
                    If CheckBox2.Checked Then
                        If GetHashSHA1(salt & hash) = TextBox2.Text.ToUpper Then
                            UpdatePasswordText("Password Found : " & hash)
                            MsgBox("Hash Has Been Cracked !", MsgBoxStyle.Information, "Done!")
                            Return
                        End If
                    Else
                        If GetHashSHA1(hash) = TextBox2.Text.ToUpper Then
                            UpdatePasswordText("Password Found : " & hash)
                            MsgBox("Hash Has Been Cracked !", MsgBoxStyle.Information, "Done!")
                            Return
                        End If
                    End If

                Case "SHA256"
                    Label1.Text = "Password Teste: " & Password & "/" & Count
                    Password = Password + 1
                    If CheckBox2.Checked Then
                        If GetHashSHA256(salt & hash) = TextBox2.Text.ToUpper Then
                            UpdatePasswordText("Password Found : " & hash)
                            MsgBox("Hash Has Been Cracked !", MsgBoxStyle.Information, "Done!")
                            Return
                        End If
                    Else
                        If GetHashSHA256(salt & hash) = TextBox2.Text.ToUpper Then
                            UpdatePasswordText("Password Found : " & hash)
                            MsgBox("Hash Has Been Cracked !", MsgBoxStyle.Information, "Done!")
                            Return
                        End If
                    End If


                Case "SHA384"
                    Label1.Text = "Password Teste: " & Password & "/" & Count
                    Password = Password + 1
                    If CheckBox2.Checked Then
                        If GetHashSHA384(salt & hash) = TextBox2.Text.ToUpper Then
                            UpdatePasswordText("Password Found : " & hash)
                            MsgBox("Hash Has Been Cracked !", MsgBoxStyle.Information, "Done!")
                            Return
                        End If
                    Else
                        If GetHashSHA384(hash) = TextBox2.Text.ToUpper Then
                            UpdatePasswordText("Password Found : " & hash)
                            MsgBox("Hash Has Been Cracked !", MsgBoxStyle.Information, "Done!")
                            Return
                        End If
                    End If


                Case "SHA512"
                    Label1.Text = "Password Teste: " & Password & "/" & Count
                    Password = Password + 1
                    If CheckBox2.Checked Then
                        If GetHashSHA512(salt & hash) = TextBox2.Text.ToUpper Then
                            UpdatePasswordText("Password Found : " & hash)
                            MsgBox("Hash Has Been Cracked !", MsgBoxStyle.Information, "Done!")
                            Return
                        End If
                    Else
                        If GetHashSHA512(hash) = TextBox2.Text.ToUpper Then
                            UpdatePasswordText("Password Found : " & hash)
                            MsgBox("Hash Has Been Cracked !", MsgBoxStyle.Information, "Done!")
                            Return
                        End If
                    End If
            End Select
        Next
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("old var اصدار قديم")
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox2.Text = "Disable"
            TextBox4.Enabled = True
        Else
            CheckBox2.Text = "Enable"
            TextBox4.Enabled = False
        End If
    End Sub
End Class
