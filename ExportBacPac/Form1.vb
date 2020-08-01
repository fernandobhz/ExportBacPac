Imports Microsoft.SqlServer.Dac
Imports System.Net.Mail

Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Console.WriteLine("Gerando bacpac")
        Dim d As New Microsoft.SqlServer.Dac.dacservices("xxxxxxxxxxx")

        Dim x As String = "eye_" & Now.Year & "_" & Now.Month & "_" & Now.Day & "-" & Now.Hour & "_" & Now.Minute & "_" & Now.Second & ".bacpac"
        Dim fileName As String = "c:\" & x
        Dim database As String = "eye"

        d.ExportBacpac(fileName, database)

        Console.WriteLine("Bacpac gerado")
        Console.WriteLine("Enviando email")
        'Start by creating a mail message object
        Dim MyMailMessage As New MailMessage()

        'From requires an instance of the MailAddress type
        MyMailMessage.From = New MailAddress("xxxxxxxx")

        'To is a collection of  types
        MyMailMessage.To.Add("xxxxxxxxx")
        'MyMailMessage.To.Add("xxxxxxxx")

        MyMailMessage.Subject = "Eye Backup " & x
        MyMailMessage.Body = "Segue em anexo backup do banco de dados " & x

        Dim attach As New Attachment(fileName)

        MyMailMessage.Attachments.Add(attach)

        'Create the SMTPClient object and specify the SMTP GMail server
        Dim SMTPServer As New SmtpClient("smtp.gmail.com")
        SMTPServer.Port = 587
        SMTPServer.Credentials = New System.Net.NetworkCredential("xxxxxxxx", "xxxxxxxxxx")
        SMTPServer.EnableSsl = True
        SMTPServer.Send(MyMailMessage)

        SMTPServer.Dispose()

        MyMailMessage.Dispose()

        System.IO.File.Delete(fileName)

        Console.WriteLine("Email enviado")
        Console.WriteLine("Concluido")
    End Sub

End Class
