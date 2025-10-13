Imports SmartBooks.BusinessLogic
Imports Janus.Windows.GridEX
Imports System.IO
Imports System.Windows.Forms
Imports System.Text
Imports System.Security.Cryptography
Imports System.Drawing
Imports JSON.NET.Framework
Imports System.Text.RegularExpressions
Public Class Security
    Public Shared Function Encrypt(ByVal clearText As String, Optional ByVal isCompanyCode As Boolean = False) As String
        Dim EncryptionKey As String = "HR_TEAM_SS"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)

        Using encryptor As Aes = Aes.Create()
            Dim pdb As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)

            Using ms As MemoryStream = New MemoryStream()

                Using cs As CryptoStream = New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using

                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        clearText = "s" + clearText
        clearText = If(isCompanyCode, Regex.Replace(clearText, "[^a-zA-Z0-9 =-]", ""), clearText)
        Return clearText
    End Function


    Public Shared Function Decrypt(ByVal cipherText As String) As String
        Dim EncryptionKey As String = "HR_TEAM_SS"
        cipherText = cipherText.Substring(1)
        cipherText = cipherText.Replace(" ", "+")
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)

        Using encryptor As Aes = Aes.Create()
            Dim pdb As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)

            Using ms As MemoryStream = New MemoryStream()

                Using cs As CryptoStream = New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using

                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using

        Return cipherText
    End Function

End Class