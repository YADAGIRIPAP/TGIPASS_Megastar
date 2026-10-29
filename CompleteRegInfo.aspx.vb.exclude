Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Data
Imports System.Threading
Imports System.Globalization

Partial Class CompleteRegInfo
    Inherits System.Web.UI.Page
    Dim Ds As New DataSet
    Dim StrRnr As String
    Dim RegSerRef As New NewReg.NewRegistrationSoapClient()

    'DlrRegistration.Registration()
    Dim masterref As New NewReg.NewRegistrationSoapClient()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If (Session("MailID") = "") Then
        '    Response.Redirect("../Dlr_Home.aspx")
        'End If
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-IN")
        If Not Page.IsPostBack = True Then
            ImageButton1.Visible = False
            ImageButton2.Visible = False
            Call bind()
        End If
    End Sub
    'Grid Bind based on RNR
    Public Sub bind()
        'StrRnr = "030220120316"
        'If StrRnr IsNot Nothing Then
        If Request.QueryString("RNR") IsNot Nothing Then
            StrRnr = Request.QueryString("RNR").Trim()

            Ds = RegSerRef.GetRNRDtls(StrRnr)
            If (Ds.Tables(0).Rows.Count > 0) Then

                LblRnr.Text = StrRnr
                LblTIN.Text = Convert.ToString(Ds.Tables("FirstStep").Rows(0)("tin_grn"))

                If (Ds.Tables("FirstStep").Rows(0)("registration_type").ToString() = "R") Then
                    LblRegType.Text = "Regular"
                ElseIf (Ds.Tables("FirstStep").Rows(0)("registration_type").ToString() = "S") Then
                    LblRegType.Text = "Startup"
                End If
                LblAppDt.Text = CDate(Ds.Tables("FirstStep").Rows(0)("application_date").ToString()).ToString("dd-MM-yyyy")


                LblAct.Text = Ds.Tables("FirstStep").Rows(0)("dealer_type").ToString()
                If (Ds.Tables("FirstStep").Rows(0)("cst_flag").ToString() = "Y") Then
                    LblCst.Text = "YES"
                ElseIf (Ds.Tables("FirstStep").Rows(0)("cst_flag").ToString() = "N") Then
                    LblCst.Text = "NO"
                End If
                LblEntryDt.Text = CDate(Ds.Tables("FirstStep").Rows(0)("inserted_date").ToString()).ToString("dd-MM-yyyy")
                LblDivision.Text = Ds.Tables("FirstStep").Rows(0)("division_name").ToString()
                LblCircle.Text = Ds.Tables("FirstStep").Rows(0)("circle_name").ToString()
                LblEName.Text = Ds.Tables("FirstStep").Rows(0)("enterprise_name").ToString()
                LblFirstTaxDt.Text = Ds.Tables("SecondStep").Rows(0)("first_tax_period_start_date").ToString()
                LblEAddress.Text = Ds.Tables("FirstStep").Rows(0)("EAddress").ToString()

                LblEoccStatus.Text = Ds.Tables("SecondStep").Rows(0)("occupancy_status").ToString()
                LblETurnOver.Text = Ds.Tables("SecondStep").Rows(0)("turnover_amount").ToString()
                LblOname.Text = Ds.Tables("SecondStep").Rows(0)("name").ToString()
                LblOUid.Text = Ds.Tables("SecondStep").Rows(0)("uid").ToString()
                LblOFatherName.Text = Ds.Tables("SecondStep").Rows(0)("father_name").ToString()
                LblOAddress.Text = Ds.Tables("SecondStep").Rows(0)("OAddress").ToString()
                LblOBusinessStatus.Text = Ds.Tables("SecondStep").Rows(0)("management_type").ToString()

                LblBankName.Text = Ds.Tables("FourthStep").Rows(0)("bank_name").ToString()
                LblBankBranchCd.Text = Ds.Tables("FourthStep").Rows(0)("bank_branch_code").ToString()
                LblBankAcctNo.Text = Ds.Tables("FourthStep").Rows(0)("bank_account_number").ToString()
                LblBankBranchAdd.Text = Ds.Tables("FourthStep").Rows(0)("bank_branch_address").ToString()
                LblPanNo.Text = Ds.Tables("FourthStep").Rows(0)("pan_number").ToString()
                LblPtaxNo.Text = Ds.Tables("FourthStep").Rows(0)("profession_tax_number").ToString()
                LblPhNo.Text = Ds.Tables("FourthStep").Rows(0)("phone_number").ToString()
                LblMobileNo.Text = Ds.Tables("FourthStep").Rows(0)("mobile_number").ToString()
                LblEmail.Text = Ds.Tables("FirstStep").Rows(0)("email_id").ToString()
                ViewState.Add("vsCircleCode", Ds.Tables("FirstStep").Rows(0)("circle_code").ToString())
                ViewState.Add("vsDivisionShortCode", Ds.Tables("FirstStep").Rows(0)("division_short_code").ToString())
                If (Ds.Tables("FourthStep").Rows(0)("accounts_computerised").ToString() = "Y") Then
                    LblPAcctComp.Text = "YES"
                ElseIf (Ds.Tables("FourthStep").Rows(0)("accounts_computerised").ToString() = "N") Then
                    LblPAcctComp.Text = "NO"
                End If


                ViewState.Add("UploadOption", Ds.Tables("FirstStep").Rows(0)("document_status").ToString())
                If (Ds.Tables("FirstStep").Rows(0)("document_status").ToString() = "S") Then
                    Fieldset1.Visible = True


                    grdChecklist.DataSource = Nothing
                    grdChecklist.DataBind()
                Else
                    Fieldset1.Visible = True
                    grdChecklist.DataSource = Ds.Tables("CheckListStep")
                    grdChecklist.DataBind()
                End If

                Ds.Clear()

                Ds = RegSerRef.GetRNRDtls(StrRnr)
                grdPBusinessActy.DataSource = Ds.Tables("ThirdBusActTextStep")
                grdPBusinessActy.DataBind()
                Ds.Clear()
                Ds = RegSerRef.GetRNRDtls(StrRnr)
                grdPrincipalCommd.DataSource = Ds.Tables("ThirdVatCommTextStep")
                grdPrincipalCommd.DataBind()
                Ds.Clear()

                Ds = RegSerRef.getpartnerBusiness(StrRnr)
                grdCompBusinessDtls.DataSource = Ds
                grdCompBusinessDtls.DataBind()
                Ds.Clear()

                Ds = RegSerRef.GetRnrPartnerDtls(StrRnr)
                grdCompPartnerDtls.DataSource = Ds
                grdCompPartnerDtls.DataBind()
                Ds.Clear()
            Else
                Response.Redirect("../Home.aspx")
            End If
        Else
            Response.Redirect("~/Home.aspx")
        End If

        'Catch ex As Exception
        '    Response.Write(ex.Message)
        'End Try
    End Sub

    Protected Sub ButEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButEdit.Click
        Dim UpdateStatus As String = RegSerRef.UpdateAppEntryStat(LblRnr.Text, "I")
        If UpdateStatus = "Success" Then
            Session("RNR") = LblRnr.Text.Trim
            Response.Redirect("NewRegistration.aspx?RNR=" & LblRnr.Text & "&Edit=Y")
        ElseIf UpdateStatus = "Fail" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "alertscript", "alert('Failed to Edit the Application... Try Again...')", True)
        End If
    End Sub
    Public Sub alert(ByVal StrMsg As String)
        ScriptManager.RegisterClientScriptBlock(Page, Page.[GetType](), Guid.NewGuid().ToString(), "alert('" + StrMsg + "');", True)
    End Sub
    Protected Sub ButSub_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButSub.Click
        Dim UpdateStatus As String = RegSerRef.UpdateAppEntryStat(LblRnr.Text, "F")
        If UpdateStatus = "Success" Then



            Dim stronlineMsg As String
            stronlineMsg = "You have successfully submitted your " & LblAct.Text & "  Registration application and supporting Documents " & _
                           " ONLINE. Please take a printout of your registration summary, if required."

            Dim strCourMsg As String
            strCourMsg = "You have successfully submitted your " & LblAct.Text & " Registration application. " & _
                           "Please take a printout of your application, sign it, and send it to your registering authority with self-attested copies " & _
                            " of the supporting documents through courier"
            Dim strMsg As String
            strMsg = "You have successfully submitted your " & LblAct.Text & " Registration application. " & _
                           "Since you are a Proprietory concern and are dealing in Sensitive commodities, " & _
                                    " you are advised to submit all supporting documents together with a signed copy of the application " & _
                                   " physically before the concerned registering authority."

            If ViewState("UploadOption").Equals("O") Then
                alert(stronlineMsg)
            ElseIf ViewState("UploadOption").Equals("C") Then
                alert(strCourMsg)
            ElseIf ViewState("UploadOption").Equals("S") Then
                alert(strMsg)

            End If


            'alert("You have successfully submitted " & LblAct.Text & " registration application. Please take the print of registration summery by clicking on print icon")
            'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "alertscript", "alert('You have successfully submitted registration application. Click OK and print the registration summery", True)
            ButSub.Visible = False
            ButEdit.Visible = False
            ImageButton1.Visible = True
            ImageButton2.Visible = True

        ElseIf UpdateStatus = "Fail" Then
            ImageButton1.Visible = False
            ImageButton2.Visible = False
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "alertscript", "alert('Failed to Save the Application... Try Again...')", True)
        End If

    End Sub
End Class
