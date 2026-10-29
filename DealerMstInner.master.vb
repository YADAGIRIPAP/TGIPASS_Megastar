Imports System.Data

Partial Class DealerMstInner
    Inherits System.Web.UI.MasterPage
    Dim ds As DataSet
    'Dim DlrReg As New RegReference.Registration()
    'Dim SerRef As New RegReference.Registration()

    Dim regWS As New RegReference.RegistrationSoapClient()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub PopulateMenu(ByVal UserType As String)


        System.Net.ServicePointManager.ServerCertificateValidationCallback = _
Function(se As Object, _
cert As System.Security.Cryptography.X509Certificates.X509Certificate, _
chain As System.Security.Cryptography.X509Certificates.X509Chain, _
sslerror As System.Net.Security.SslPolicyErrors) True

        regWS.ClientCredentials.UserName.UserName = "ctdwebuser"
        regWS.ClientCredentials.UserName.Password = "vatis@web#123"

        Dim menuData1 As DataSet = regWS.GetDlrStpMenu(UserType.ToString(), Session("TIN"))
        Dim menuData As DataTable = menuData1.Tables("Menu")

        Dim view As New DataView(menuData)
        view.RowFilter = "parent_function_code IS NULL"
        For Each row As DataRowView In view
            Dim newMenuItem As New MenuItem(row("function_name").ToString(), row("function_code").ToString(), "", row("url").ToString())
            Menu1.Items.Add(newMenuItem)
            AddChildMenuItems(menuData, newMenuItem)
        Next

    End Sub

    Private Sub AddChildMenuItems(ByVal menuData As DataTable, ByVal parentMenuItem As MenuItem)
        Dim view As New DataView(menuData)
        view.RowFilter = "parent_function_code= '" & Convert.ToString(parentMenuItem.Value) & "'"
        For Each row As DataRowView In view
            Dim newMenuItem As New MenuItem(row("function_name").ToString(), row("function_code").ToString(), "", row("url").ToString())
            parentMenuItem.ChildItems.Add(newMenuItem)
            AddChildMenuItems(menuData, newMenuItem)
        Next
    End Sub


End Class

