Imports System.Data
Imports System.Web.Mail
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports BusinessLogic


Partial Class Registration_NewRegistration
    Inherits System.Web.UI.Page
    Dim Ds, DsAllDtls As DataSet

    ' Dim cd As New RegReference.RegistrationSoapClient()

    'Dim regWS As New RegReference.Registration()

    Dim regWS As New RegReference.RegistrationSoapClient()
    Dim SerRef As New RegReference.RegistrationSoapClient()
    Dim objDml As New BusinessLogic.DML

    'Dim SerRef As New RegReference.RegistrationSoapClient()
    'Dim RegSerRef As New RegReference.RegistrationSoapClient()
    'Dim masterref As New RegReference.RegistrationSoapClient()


    Dim slno As Integer
    Private order As String
    Dim StrStepOneRes As String = ""
    Dim StrStepTwoCnt As String
    Dim StrStepThreeCnt As String = "0"
    Dim Res, strRNR, strTIN As String
    Dim AppDate As Date
    Dim DtBusAct, DtVatComm, DtCstComm As New DataTable

    Dim MobNum, VAT, CST As String
    Shared uname As [String] = "vatisds.sms"
    Shared pwd As [String] = "Hy%243Fr%237kZ"
    Shared sender As [String] = "NICSMS"

    Shared dataStream As Stream

    Shared mes As String
    Shared message As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            System.Net.ServicePointManager.ServerCertificateValidationCallback = _
 Function(se As Object, _
 cert As System.Security.Cryptography.X509Certificates.X509Certificate, _
 chain As System.Security.Cryptography.X509Certificates.X509Chain, _
 sslerror As System.Net.Security.SslPolicyErrors) True

            regWS.ClientCredentials.UserName.UserName = "ctdwebuser"
            regWS.ClientCredentials.UserName.Password = "vatis@web#123"

            'regWS.Credentials

            'If Request.QueryString("emailid") = "" Then

            'Response.Write("Email Id is empty")
            'Response.Redirect("")
            'Response.End()
            'End If

            'Thread.CurrentThread.CurrentUICulture = New CultureInfo("te-IN")
            Thread.CurrentThread.CurrentCulture = New CultureInfo("en-IN")


            Page.Form.Attributes.Add("enctype", "multipart/form-data")

            If Not Page.IsPostBack Then

                Fill_DropDowns()

                '   BindCheckLists()  ' 'checklist master

                TxtAppDt.Text = DateTime.Now.ToString("dd-MM-yyyy")
                TxtEMail.Text = Request.QueryString("emailid")

                DtBusAct.Columns.Add(New DataColumn("activity_code", GetType(Decimal)))
                DtBusAct.Columns.Add(New DataColumn("activity_name", GetType(String)))
                DtBusAct.Columns.Add(New DataColumn("priority", GetType(Decimal)))
                ViewState("DtBusAct") = DtBusAct

                DtVatComm.Columns.Add(New DataColumn("commodity_code", GetType(Decimal)))
                DtVatComm.Columns.Add(New DataColumn("commodity_name", GetType(String)))
                DtVatComm.Columns.Add(New DataColumn("priority", GetType(Decimal)))
                ViewState("DtVatComm") = DtVatComm

                DtCstComm.Columns.Add(New DataColumn("commodity_code", GetType(Decimal)))
                DtCstComm.Columns.Add(New DataColumn("commodity_name", GetType(String)))
                DtCstComm.Columns.Add(New DataColumn("priority", GetType(Decimal)))
                ViewState("DtCstComm") = DtCstComm

                If Request.QueryString("Edit") = "Y" Then
                    If Not Request.QueryString("RNR") = "" Then
                        LblRNR.Text = Request.QueryString("RNR").ToString()
                        LblAppNo2.Text = LblRNR.Text
                        LblAppNo3.Text = LblRNR.Text
                        LblAppNo4.Text = LblRNR.Text
                        LblAppNo5.Text = LblRNR.Text
                        LblAppNo6.Text = LblRNR.Text
                        ' LblAppNo7.Text = LblRNR.Text
                        GetRNRDtls()

                        ' BindCheckListsDocument(Request.QueryString("RNR").ToString())

                    End If
                Else

                End If
            End If
        Catch ex As Exception
            Errors.ErrorLog_Vat(ex)
            'Response.Write(ex.Message)
            'Response.Write(ex.InnerException)
        End Try
    End Sub


    Sub GetRNRDtls()

        DsAllDtls = regWS.GetRNRDtls(LblRNR.Text.Trim)
        'Data Filling in First Step
        If DsAllDtls.Tables("FirstStep").Rows.Count > 0 Then
            If DsAllDtls.Tables("FirstStep").Rows(0)("registration_type") = "R" Then
                RbReg.Items.FindByText("Regular").Selected = True
            Else
                RbReg.Items.FindByText("Startup").Selected = True
            End If

            RbRegACT.Items.FindByText(DsAllDtls.Tables(0).Rows(0)("dealer_type")).Selected = True

            If DsAllDtls.Tables("FirstStep").Rows(0)("cst_flag") = "Y" Then
                RbRegCST.Items.FindByText("Yes").Selected = True
            Else
                RbRegCST.Items.FindByText("No").Selected = True
            End If
            If RbRegACT.SelectedItem.Value = "TOT" Then
                RbRegCST.Items.FindByText("Yes").Enabled = False
                RbRegCST.Items.FindByText("Yes").Selected = False
                RbRegCST.Items.FindByText("No").Enabled = True
                RbRegCST.Items.FindByText("No").Selected = True
            Else
                RbRegCST.Items.FindByText("Yes").Enabled = True
                RbRegCST.Items.FindByText("No").Enabled = True
            End If

            TxtAppDt.Text = DsAllDtls.Tables("FirstStep").Rows(0)("application_date")

            DdlDivisions.SelectedValue = DsAllDtls.Tables("FirstStep").Rows(0)("division_code")
            Fill_Circles()
            DdlCircles.SelectedValue = DsAllDtls.Tables("FirstStep").Rows(0)("circle_code")

            TxtEntName.Text = Convert.ToString(DsAllDtls.Tables("FirstStep").Rows(0)("enterprise_name"))
            TxtEntDrNo.Text = Convert.ToString(DsAllDtls.Tables("FirstStep").Rows(0)("door_no"))
            TxtEntLocality.Text = Convert.ToString(DsAllDtls.Tables("FirstStep").Rows(0)("location"))
            TxtEntStreet.Text = Convert.ToString(DsAllDtls.Tables("FirstStep").Rows(0)("street"))
            TxtEntCity.Text = Convert.ToString(DsAllDtls.Tables("FirstStep").Rows(0)("city"))
            TxtPIN.Text = Convert.ToString(DsAllDtls.Tables("FirstStep").Rows(0)("pin"))
            TxtEMail.Text = Convert.ToString(DsAllDtls.Tables("FirstStep").Rows(0)("email_id"))
            DdlDistrict.SelectedValue = Convert.ToString(DsAllDtls.Tables("FirstStep").Rows(0)("district_code"))

            'Data Filling in Second Step
            If DsAllDtls.Tables("SecondStep").Rows.Count > 0 Then
                DdlOccupancy.SelectedValue = Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("occupancy_status"))
                TxtOwnerName.Text = Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("name"))
                TxtOwnerFatherName.Text = Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("father_name"))
                If Not IsDBNull(DsAllDtls.Tables("SecondStep").Rows(0)("dob")) Then
                    TxtOwnerDOB.Text = CDate(Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("dob"))).ToString("dd-MM-yyyy")
                Else
                    TxtOwnerDOB.Text = ""
                End If
                TtUID.Text = Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("uid"))
                TxtOwnerDrNo.Text = Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("door_no"))
                TxtOwnerLocality.Text = Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("location"))
                TxtOwnerStreet.Text = Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("street"))
                TxtOwnerCity.Text = Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("city"))
                TxtOwnerPIN.Text = Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("pin"))
                DdlOwnerDist.SelectedValue = Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("district_code"))
                TxtEstTax.Text = Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("turnover_amount"))
                DdlBusStatus.SelectedValue = Convert.ToString(DsAllDtls.Tables("SecondStep").Rows(0)("business_status_code"))

                FirstTaxPeriod()
                Dim Fryear As String
                Dim FrMonth As String
                If Not IsDBNull(DsAllDtls.Tables("SecondStep").Rows(0)("first_tax_period_start_date")) Then
                    Fryear = Convert.ToDateTime(DsAllDtls.Tables("SecondStep").Rows(0)("first_tax_period_start_date")).Year
                    Dim dt As Date = DsAllDtls.Tables("SecondStep").Rows(0)("first_tax_period_start_date")
                    FrMonth = dt.Month


                    If RbRegACT.SelectedItem.Text = "VAT" Then
                        DdlTaxPrdYear.SelectedValue = Fryear
                    Else
                        Select Case FrMonth
                            Case "4", "7", "10"
                                DdlTaxPrdYear.SelectedValue = Fryear & "-" & Fryear + 1
                            Case "1"
                                DdlTaxPrdYear.SelectedValue = Fryear - 1 & "-" & Fryear
                        End Select
                    End If

                    If RbRegACT.SelectedItem.Text = "VAT" Then
                        DdlTaxPrdMonth.SelectedValue = FrMonth
                    Else
                        Select Case FrMonth
                            Case "4", "5", "6"
                                DdlTaxPrdMonth.SelectedValue = "Apr-Jun"
                            Case "7", "8", "9"
                                DdlTaxPrdMonth.SelectedValue = "Jul-Sep"
                            Case "10", "11", "12"
                                DdlTaxPrdMonth.SelectedValue = "Oct-Dec"
                            Case "1", "2", "3"
                                DdlTaxPrdMonth.SelectedValue = "Jan-Mar"
                        End Select
                    End If
                Else
                    FirstTaxPeriod()
                End If
            Else
                FirstTaxPeriod()
            End If

            'Data Filling in Third Step

            If DsAllDtls.Tables("ThirdBusActTextStep").Rows.Count > 0 Then
                LBoxSelBusinessActivity.DataSource = DsAllDtls.Tables("ThirdBusActTextStep")
                LBoxSelBusinessActivity.DataTextField = "activity"
                LBoxSelBusinessActivity.DataValueField = "activity_code"
                LBoxSelBusinessActivity.DataBind()
                LBoxSelBusinessActivity.ClearSelection()
                LBoxBusinessActivity.ClearSelection()
            End If

            If DsAllDtls.Tables("ThirdVatCommTextStep").Rows.Count > 0 Then
                LBoxSelCommodity.DataSource = DsAllDtls.Tables("ThirdVatCommTextStep")
                LBoxSelCommodity.DataTextField = "commodity"
                LBoxSelCommodity.DataValueField = "commodity_code"
                LBoxSelCommodity.DataBind()
                LBoxCommodity.ClearSelection()
                LBoxSelCommodity.ClearSelection()
            End If


            If DsAllDtls.Tables("ThirdCstCommTextStep").Rows.Count > 0 Then
                LBoxSelInterstate.DataSource = DsAllDtls.Tables("ThirdCstCommTextStep")
                LBoxSelInterstate.DataTextField = "commodity"
                LBoxSelInterstate.DataValueField = "commodity_code"
                LBoxSelInterstate.DataBind()
                LBoxInterstate.ClearSelection()
                LBoxSelInterstate.ClearSelection()
            End If

            'Filling of Fourth Step
            If DsAllDtls.Tables("FourthStep").Rows.Count > 0 Then
                DdlBank.SelectedValue = Convert.ToString(DsAllDtls.Tables("FourthStep").Rows(0)("bank_code"))
                TxtBnkAccNo.Text = Convert.ToString(DsAllDtls.Tables("FourthStep").Rows(0)("bank_account_number"))
                TxtBnkCode.Text = Convert.ToString(DsAllDtls.Tables("FourthStep").Rows(0)("bank_branch_code"))
                TxtBnkAdd.Text = Convert.ToString(DsAllDtls.Tables("FourthStep").Rows(0)("bank_branch_address"))
                TxtPAN.Text = Convert.ToString(DsAllDtls.Tables("FourthStep").Rows(0)("pan_number"))
                TxtPAN_new.Text = Convert.ToString(DsAllDtls.Tables("FourthStep").Rows(0)("pan_number"))
                TxtPTNo.Text = Convert.ToString(DsAllDtls.Tables("FourthStep").Rows(0)("profession_tax_number"))
                TxtLandLine.Text = Convert.ToString(DsAllDtls.Tables("FourthStep").Rows(0)("phone_number"))
                TxtMobile.Text = Convert.ToString(DsAllDtls.Tables("FourthStep").Rows(0)("mobile_number"))

                If IsDBNull(DsAllDtls.Tables("FourthStep").Rows(0)("accounts_computerised")) Then
                    RbAcc.Items.FindByText("No").Selected = True
                Else
                    If DsAllDtls.Tables("FourthStep").Rows(0)("accounts_computerised") = "Y" Then
                        RbAcc.Items.FindByText("Yes").Selected = True
                    Else
                        RbAcc.Items.FindByText("No").Selected = True
                    End If
                End If
            End If
            'Filling of Fifth Step
            AddBusGridBind()

            'Filling of Sixth Step
            PartnersGridBind()

        Else

        End If

    End Sub
    'All Dropdowns filling in all the steps
    Sub Fill_DropDowns()

        Ds = regWS.GetTableDatasetOrderby("Division_mst", "status", "A", "Division_name")
        DdlDivisions.DataSource() = Ds.Tables(0)
        DdlDivisions.DataValueField = "division_code"
        DdlDivisions.DataTextField = "division_name"
        DdlDivisions.DataBind()
        DdlDivisions.Items.Insert(0, "--Select--")
        DdlDivisions.Items(0).Value = "sel"
        DdlDivisions.SelectedIndex = 0
        Ds.Clear()


        Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
        DdlDistrict.DataSource() = Ds.Tables(0)
        DdlDistrict.DataValueField = "district_code"
        DdlDistrict.DataTextField = "district_name"
        DdlDistrict.DataBind()
        DdlDistrict.Items.Insert(0, "--Select--")
        DdlDistrict.Items(0).Value = "sel"
        DdlDistrict.SelectedIndex = 0

        DdlOwnerDist.DataSource() = Ds.Tables(0)
        DdlOwnerDist.DataValueField = "district_code"
        DdlOwnerDist.DataTextField = "district_name"
        DdlOwnerDist.DataBind()
        DdlOwnerDist.Items.Insert(0, "--Select--")
        DdlOwnerDist.Items(0).Value = "sel"
        DdlOwnerDist.SelectedIndex = 0
        Ds.Clear()

        Ds = regWS.GetTableDatasetOrderby("management_type_mst", "status", "A", "management_type")
        DdlBusStatus.DataSource() = Ds.Tables(0)
        DdlBusStatus.DataValueField = "management_type_code"
        DdlBusStatus.DataTextField = "management_type"
        DdlBusStatus.DataBind()
        DdlBusStatus.Items.Insert(0, "--Select--")
        DdlBusStatus.Items(0).Value = "sel"
        DdlBusStatus.SelectedIndex = 0
        Ds.Clear()

        Ds = regWS.GetTableDatasetOrderby("Bank_mst", "status", "A", "bank_name")
        DdlBank.DataSource() = Ds.Tables(0)
        DdlBank.DataValueField = "bank_code"
        DdlBank.DataTextField = "bank_name"
        DdlBank.DataBind()
        DdlBank.Items.Insert(0, "--Select--")
        DdlBank.Items(0).Value = "sel"
        DdlBank.SelectedIndex = 0
        Ds.Clear()

        Ds = regWS.GetTableDatasetOrderby("commodity_mst", "status", "A", "commodity_name")
        LBoxCommodity.DataSource() = Ds.Tables(0)
        LBoxCommodity.DataValueField = "commodity_code"
        LBoxCommodity.DataTextField = "commodity_name"
        LBoxCommodity.DataBind()

        LBoxInterstate.DataSource = Ds.Tables(0)
        LBoxInterstate.DataTextField = "commodity_name"
        LBoxInterstate.DataValueField = "commodity_code"
        LBoxInterstate.DataBind()
        Ds.Clear()

        Ds = regWS.GetTableDatasetOrderby("management_type_mst", "status", "A", "management_type")
        DdlBusStatus.DataSource = Ds.Tables(0)
        DdlBusStatus.DataTextField = "management_type"
        DdlBusStatus.DataValueField = "management_type_code"
        DdlBusStatus.DataBind()
        DdlBusStatus.Items.Insert(0, "SELECT")
        DdlBusStatus.Items(0).Value = "sel"
        DdlBusStatus.SelectedIndex = 0
        Ds.Clear()

        Ds = regWS.GetTableDatasetOrderby("business_activity_master", "status", "A", "activity_name")
        LBoxBusinessActivity.DataSource = Ds.Tables(0)
        LBoxBusinessActivity.DataTextField = "activity_name"
        LBoxBusinessActivity.DataValueField = "activity_code"
        LBoxBusinessActivity.DataBind()
        Ds.Clear()

    End Sub
    'Grid Binding in 6th step
    Public Sub PartnersGridBind()

        If Not LblRNR.Text = "" Then
            Ds = regWS.GetRnrPartnerDtls(LblRNR.Text)
        End If


        If Ds.Tables("reg_partners_tmp").Rows.Count > 0 Then
            GvwBusiness.DataSource = Ds.Tables("reg_partners_tmp")
            GvwBusiness.DataBind()
        Else

            Dim NewEmptyRow As DataRow = Ds.Tables("reg_partners_tmp").NewRow
            NewEmptyRow("name") = ""

            Ds.Tables("reg_partners_tmp").Rows.Add(NewEmptyRow)

            GvwBusiness.DataSource = Ds.Tables("reg_partners_tmp")
            GvwBusiness.DataBind()

            GvwBusiness.Rows(0).Visible = False
            GvwBusiness.Rows(0).Controls.Clear()
        End If


        Ds.Clear()
    End Sub
    'Grid Binding in 5th step
    Public Sub AddBusGridBind()
        Ds = regWS.getpartnerBusiness(LblRNR.Text)

        If Ds.Tables("reg_place_of_business_tmp").Rows.Count > 0 Then
            gvPartnerBusiness.DataSource = Ds.Tables("reg_place_of_business_tmp")
            gvPartnerBusiness.DataBind()
        Else
            Dim NewEmptyRow As DataRow = Ds.Tables("reg_place_of_business_tmp").NewRow
            NewEmptyRow("door_no") = ""
            Ds.Tables("reg_place_of_business_tmp").Rows.Add(NewEmptyRow)

            gvPartnerBusiness.DataSource = Ds.Tables("reg_place_of_business_tmp")
            gvPartnerBusiness.DataBind()

            gvPartnerBusiness.Rows(0).Visible = False
            gvPartnerBusiness.Rows(0).Controls.Clear()
        End If
        Ds.Clear()
    End Sub

    Private Sub SortDDL(ByRef objDDL As DropDownList)
        Dim textList As New ArrayList()
        Dim valueList As New ArrayList()

        For Each li As ListItem In objDDL.Items
            textList.Add(li.Text)
        Next

        textList.Sort()

        For Each item As Object In textList
            Dim value As String = objDDL.Items.FindByText(item.ToString()).Value
            valueList.Add(value)
        Next
        objDDL.Items.Clear()

        For i As Integer = 0 To textList.Count - 1
            Dim objItem As New ListItem(textList(i).ToString(), valueList(i).ToString())
            objDDL.Items.Add(objItem)
        Next
    End Sub
    'Wizard Control Finish Button Click
    Protected Sub WizardReg_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles WizardReg.FinishButtonClick
        Try



            Dim result As Integer = 0



            Dim UpdateStatus As String = regWS.UpdateAppEntryStat(LblRNR.Text, "C")
            If UpdateStatus = "Success" Then

                Dim Ds As Data.DataSet = SerRef.GetRNRStatusDtls(LblRNR.Text)
                If Not Ds Is Nothing AndAlso Ds.Tables.Count > 0 AndAlso Ds.Tables(0).Rows.Count > 0 AndAlso Ds.Tables(0).Columns.Contains("status") Then
                    objDml.InsUpdDelVATReg("Z", 0, RbReg.SelectedValue, RbRegACT.SelectedValue, RbRegCST.SelectedValue, Convert.ToDateTime(TxtAppDt.Text), DdlDivisions.SelectedItem.Text, DdlCircles.SelectedItem.Text, TxtPAN_new.Text, TxtOwnerName.Text, TxtOwnerDrNo.Text, TxtOwnerStreet.Text, TxtOwnerLocality.Text, TxtOwnerCity.Text, DdlDistrict.SelectedItem.Text, TxtPIN.Text, TxtEMail.Text, Date.Now, Date.Now, Ds.Tables(0).Rows(0)("status"), LblRNR.Text)
                End If

                Dim msg As String = "You have  applied for " + VAT + " Registration. Your RNR is " + LblRNR.Text + ". Using RNR , you may track your application status. "
                ' SendSingleSMS(uname, pwd, sender, MobNum, msg)

                Response.Redirect("CompleteRegInfo.aspx?RNR= " & LblRNR.Text & "")
            ElseIf UpdateStatus = "Fail" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "alertscript", "alert('Failed to Save the Application... Try Again...')", True)
            End If


        Catch ex As Exception
            Errors.ErrorLog_Vat(ex)
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "alertscript", "alert('Failed to Save the Application... Try Again...')", True)
        End Try
    End Sub

    'Wizard control Next Button click
    Protected Sub WizardReg_NextButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles WizardReg.NextButtonClick
        Select Case WizardReg.ActiveStepIndex

            Case 0
                If (WizardReg.ActiveStepIndex = 0) Then
                    Try
                        Dim StrSerialNo As String = "1"

                        TxtPAN.Text = TxtPAN_new.Text

                        If (Request.QueryString("Edit") <> "Y") Then

                            If LblRNR.Text = "" Then
                                ' strRNR = getRandomNo()
                                strRNR = regWS.GetRNR()
                                LblRNR.Text = strRNR
                                LblAppNo2.Text = LblRNR.Text
                                LblAppNo3.Text = LblRNR.Text
                                LblAppNo4.Text = LblRNR.Text
                                LblAppNo5.Text = LblRNR.Text
                                LblAppNo6.Text = LblRNR.Text
                                ' LblAppNo7.Text = LblRNR.Text
                            End If

                            StrStepOneRes = regWS.RegStepOneInsUpd(LblRNR.Text, RbReg.SelectedValue.ToString(), RbRegCST.SelectedValue.ToString(), _
                                        RbRegACT.SelectedValue.ToString(), TxtAppDt.Text, DdlCircles.SelectedValue.ToString(), TxtEntName.Text.ToString(), _
                                        StrSerialNo.ToString(), TxtEntDrNo.Text.ToString().Trim(), TxtEntStreet.Text.ToString().Trim(), _
                                        TxtEntLocality.Text.ToString().Trim(), TxtEntCity.Text.ToString().Trim(), "TELANGANA", _
                                        DdlDistrict.SelectedItem.ToString(), TxtPIN.Text.ToString().Trim(), TxtEMail.Text.ToString().Trim(), _
                                        "Online", "Insert", strTIN)

                            VAT = IIf(RbRegACT.SelectedItem.Text = "VAT", IIf(RbRegCST.SelectedItem.Value = "Y", "VAT/CST", "VAT"), "TOT")
                            'CST = IIf(RbRegCST.SelectedItem.Value = "Y", "CST", "VAT")

                            If (StrStepOneRes = "Success") Then
                                ScriptManager.RegisterStartupScript(UpdatePanel1, Me.GetType(), "alertscript", "alert('Please note down your application Number to complete data entry later and to track application status')", True)





                                ''sending the default password through mail

                                'Dim objMail As New MailMessage
                                'With objMail
                                '    .From = "ril_helpdesk@tgct.gov.in"
                                '    .To = TxtEMail.Text.Trim().ToString()
                                '    .Subject = "Mail from Commercial Taxes"
                                '    .Body = "AP COMMERCIAL TAXES DEPARTMENT <br><br><br> Please note down your Application Number to complete data entry later and to track Application Status <br><br>Application No. : " & LblRNR.Text.Trim & ""
                                '    .BodyFormat = MailFormat.Html
                                '    ' SmtpMail.SmtpServer = "192.168.32.3" '- ------apts
                                '    SmtpMail.SmtpServer = "192.168.1.169" ' '-----ctax
                                '    SmtpMail.Send(objMail)
                                'End With
                                If Request.QueryString("TIN") = "" Then
                                    FirstTaxPeriod()
                                End If

                            Else
                                e.Cancel = True
                                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Please check all the fields and then click Next..')", True)
                                Exit Sub
                            End If

                        Else
                            StrStepOneRes = regWS.RegStepOneInsUpd(LblRNR.Text.ToString(), RbReg.SelectedValue.ToString(), _
                                RbRegCST.SelectedValue.ToString(), RbRegACT.SelectedValue.ToString(), TxtAppDt.Text, _
                                DdlCircles.SelectedValue.ToString(), TxtEntName.Text.ToString(), StrSerialNo.ToString(), _
                                TxtEntDrNo.Text.ToString().Trim(), TxtEntStreet.Text.ToString().Trim(), _
                                TxtEntLocality.Text.ToString().Trim(), TxtEntCity.Text.ToString().Trim(), "TELANGANA", _
                                DdlDistrict.SelectedItem.ToString(), TxtPIN.Text.ToString().Trim(), TxtEMail.Text.ToString().Trim(), _
                                "Online", "Update", strTIN)
                        End If

                        objDml.InsUpdDelVATReg("I", 0, RbReg.SelectedValue, RbRegACT.SelectedValue, RbRegCST.SelectedValue, Convert.ToDateTime(TxtAppDt.Text), DdlDivisions.SelectedItem.Text, DdlCircles.SelectedItem.Text, TxtPAN_new.Text, TxtOwnerName.Text, TxtOwnerDrNo.Text, TxtOwnerStreet.Text, TxtOwnerLocality.Text, TxtOwnerCity.Text, DdlDistrict.SelectedItem.Text, TxtPIN.Text, TxtEMail.Text, Date.Now, Date.Now, "", LblRNR.Text)

                    Catch ex As Exception
                        Errors.ErrorLog_Vat(ex)
                        Throw New Exception(ex.Message)
                    End Try

                End If
            Case 1
                If (WizardReg.ActiveStepIndex = 1) Then
                    Try
                        Dim StrSerialNo As String = "1"
                        Dim FrstDt As String
                        If RbRegACT.SelectedItem.Text = "VAT" Then
                            If DdlTaxPrdYear.SelectedValue = "2014" And DdlTaxPrdMonth.SelectedValue = "6" Then
                                FrstDt = "02-" & DdlTaxPrdMonth.SelectedValue & "-" & DdlTaxPrdYear.SelectedValue
                            Else
                                FrstDt = "01-" & DdlTaxPrdMonth.SelectedValue & "-" & DdlTaxPrdYear.SelectedValue
                            End If
                        Else
                            If DdlTaxPrdYear.SelectedValue = "2014-2015" And DdlTaxPrdMonth.SelectedValue = "Apr-Jun" Then
                                FrstDt = "02-jun-" & DdlTaxPrdYear.SelectedValue.Substring(0, 4).ToString()
                            Else
                                If DdlTaxPrdMonth.SelectedValue = "Apr-Jun" Then
                                    FrstDt = "01-apr-" & DdlTaxPrdYear.SelectedValue.Substring(0, 4).ToString()
                                ElseIf DdlTaxPrdMonth.SelectedValue = "Jul-Sep" Then
                                    FrstDt = "01-jul-" & DdlTaxPrdYear.SelectedValue.Substring(0, 4).ToString()
                                ElseIf DdlTaxPrdMonth.SelectedValue = "Oct-Dec" Then
                                    FrstDt = "01-oct-" & DdlTaxPrdYear.SelectedValue.Substring(0, 4).ToString()
                                ElseIf DdlTaxPrdMonth.SelectedValue = "Jan-Mar" Then
                                    FrstDt = "01-jan-" & DdlTaxPrdYear.SelectedValue.Substring(5, 4).ToString()
                                End If
                            End If

                        End If

                        'Second Step Insertion/Updation
                        StrStepOneRes = regWS.RegStepTwoInsUpd(LblRNR.Text.ToString(), DdlOccupancy.SelectedItem.ToString(), _
                        TxtOwnerName.Text.ToString(), StrSerialNo, TtUID.Text.ToString(), "O", TxtOwnerFatherName.Text.ToString(), _
                        TxtOwnerDrNo.Text.ToString().Trim(), TxtOwnerStreet.Text.ToString().Trim(), _
                        TxtOwnerLocality.Text.ToString().Trim(), TxtOwnerCity.Text.ToString().Trim(), "TELANGANA", _
                        DdlOwnerDist.SelectedItem.ToString(), TxtOwnerPIN.Text.ToString().Trim(), _
                        "Online", TxtOwnerDOB.Text, FrstDt, TxtEstTax.Text, DdlBusStatus.SelectedItem.Value)

                        If (StrStepOneRes = "Success") Then
                            StrStepTwoCnt = "1"
                        Else
                            e.Cancel = True
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Please check all the fields and then click Next..')", True)
                            Exit Sub
                        End If


                        If RbRegCST.SelectedItem.Value = "Y" Then
                            CSTComm.Visible = True
                            LBoxSelInterstate.Visible = True
                            LBoxInterstate.Visible = True
                            btnInterstateAdd.Visible = True
                            btnInterstateRemove.Visible = True
                        Else
                            CSTComm.Visible = False
                            LBoxSelInterstate.Visible = False
                            LBoxInterstate.Visible = False
                            btnInterstateAdd.Visible = False
                            btnInterstateRemove.Visible = False
                        End If

                    Catch ex As Exception
                        Errors.ErrorLog_Vat(ex)
                        Throw New Exception(ex.Message)
                    End Try

                End If
            Case 2
                If (WizardReg.ActiveStepIndex = 2) Then
                    Try

                        If LBoxSelBusinessActivity.Items.Count() > 0 Then

                            Dim BusPrty As Integer = 0

                            DtBusAct = DirectCast(ViewState("DtBusAct"), DataTable)
                            DtBusAct.Clear()
                            For i As Integer = 0 To LBoxSelBusinessActivity.Items.Count() - 1
                                Dim targdr As DataRow
                                targdr = DtBusAct.NewRow()

                                targdr(0) = Convert.ToInt32(LBoxSelBusinessActivity.Items(i).Value)
                                targdr(1) = LBoxSelBusinessActivity.Items(i).Text.ToString()
                                targdr(2) = BusPrty + 1
                                Dim r1 As Integer = Convert.ToInt32(targdr(0))
                                Dim r2 As String = Convert.ToString(targdr(1))
                                Dim r3 As Integer = Convert.ToInt32(targdr(2))
                                DtBusAct.Rows.Add(targdr)
                                DtBusAct.AcceptChanges()
                                BusPrty = r3
                            Next

                        Else
                            e.Cancel = True
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Select Business Activity')", True)
                            Exit Sub
                        End If


                        If LBoxSelCommodity.Items.Count() > 0 Then

                            Dim VatPriority As Integer = 0
                            DtVatComm = DirectCast(ViewState("DtVatComm"), DataTable)
                            DtVatComm.Clear()

                            For i As Integer = 0 To LBoxSelCommodity.Items.Count() - 1
                                Dim targdr As DataRow
                                targdr = DtVatComm.NewRow()
                                targdr(0) = Convert.ToInt32(LBoxSelCommodity.Items(i).Value)
                                targdr(1) = LBoxSelCommodity.Items(i).Text.ToString()
                                targdr(2) = VatPriority + 1
                                Dim r1 As Integer = Convert.ToInt32(targdr(0))
                                Dim r2 As String = Convert.ToString(targdr(1))
                                Dim r3 As Integer = Convert.ToInt32(targdr(2))
                                DtVatComm.Rows.Add(targdr)
                                DtVatComm.AcceptChanges()
                                VatPriority = r3
                            Next

                        Else
                            e.Cancel = True
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Select Principal Commodities')", True)
                            Exit Sub
                        End If

                        DtCstComm = DirectCast(ViewState("DtCstComm"), DataTable)
                        DtCstComm.Clear()

                        If (LBoxInterstate.Visible = True) Then

                            If LBoxSelInterstate.Items.Count() > 0 Then
                                Dim CstPriority As Integer = 0

                                For i As Integer = 0 To LBoxSelInterstate.Items.Count() - 1
                                    Dim targdr As DataRow
                                    targdr = DtCstComm.NewRow()
                                    targdr(0) = Convert.ToInt32(LBoxSelInterstate.Items(i).Value)
                                    targdr(1) = LBoxSelInterstate.Items(i).Text.ToString()
                                    targdr(2) = CstPriority + 1
                                    Dim r1 As Integer = Convert.ToInt32(targdr(0))
                                    Dim r2 As String = Convert.ToString(targdr(1))
                                    Dim r3 As Integer = Convert.ToInt32(targdr(2))
                                    DtCstComm.Rows.Add(targdr)
                                    DtCstComm.AcceptChanges()
                                    CstPriority = r3
                                Next

                            Else
                                e.Cancel = True
                                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Select CST Commodities')", True)
                                Exit Sub
                            End If
                        End If


                        Try
                            Dim iCnt As Integer = 0
                            'Third Step Insertion/Updation
                            iCnt = regWS.RegStepThirdInsUpd(LblRNR.Text.ToString(), DtBusAct, DtVatComm, DtCstComm)

                            If (iCnt = 1) Then
                                StrStepTwoCnt = "1"
                            Else
                                e.Cancel = True
                                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Please check all the fields and then click Next..')", True)
                                Exit Sub
                            End If

                        Catch ex As Exception
                            Errors.ErrorLog_Vat(ex)
                            Throw New Exception(ex.Message)
                        End Try

                    Catch ex As Exception
                        Errors.ErrorLog_Vat(ex)
                        Throw New Exception(ex.Message)
                    End Try

                End If
                ''code for Step 4 Begins
            Case 3
                If (WizardReg.ActiveStepIndex = 3) Then
                    Try
                        StrStepOneRes = regWS.RegStepFourUpdate(LblRNR.Text.ToString(), DdlBank.SelectedItem.Value, _
                        TxtBnkAccNo.Text, TxtBnkCode.Text, TxtBnkAdd.Text, TxtPAN.Text, TxtPTNo.Text, TxtLandLine.Text, TxtMobile.Text, _
                        RbAcc.SelectedItem.Value.ToString(), "Online")

                        MobNum = TxtMobile.Text

                        If (StrStepOneRes = "Success") Then
                            StrStepTwoCnt = "1"
                        Else
                            e.Cancel = True
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Please check all the fields and then click Next..')", True)
                            Exit Sub
                        End If

                    Catch ex As Exception
                        Errors.ErrorLog_Vat(ex)
                        Throw New Exception(ex.Message)
                    End Try

                    ''Filling of Fifth Step
                    AddBusGridBind()

                    ''Filling of Sixth Step
                    PartnersGridBind()
                End If

            Case 5
                If (WizardReg.ActiveStepIndex = 5) Then
                    Try
                        ''Filling of Sixth Step
                        '  BindCheckLists()

                    Catch ex As Exception

                    End Try
                End If
        End Select

    End Sub
    'RNR generation based on date
    Public Function getRandomNo() As String

        Dim RandomVal As New Random()
        Dim RandomNumber As String = RandomVal.Next(1, 9999)
        Dim len As Integer = RandomNumber.ToString.Length
        If (len = 1) Then
            RandomNumber = DateTime.Now.ToString("yyyyMMdd") + "000" + RandomNumber
        ElseIf len = 2 Then
            RandomNumber = DateTime.Now.ToString("yyyyMMdd") + "00" + RandomNumber
        ElseIf len = 3 Then
            RandomNumber = DateTime.Now.ToString("yyyyMMdd") + "0" + RandomNumber
        Else
            RandomNumber = DateTime.Now.ToString("yyyyMMdd") + RandomNumber
        End If
        Return RandomNumber

    End Function
    'Based on Country selection loading of state dropdown
    Protected Sub DdlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim countryddl As DropDownList = DirectCast(GvwBusiness.Rows(GvwBusiness.EditIndex).FindControl("DdlCountry"), DropDownList)
        Dim stateddl As DropDownList = DirectCast(GvwBusiness.Rows(GvwBusiness.EditIndex).FindControl("DdlState"), DropDownList)
        Dim statetxt As TextBox = DirectCast(GvwBusiness.Rows(GvwBusiness.EditIndex).FindControl("State_txt"), TextBox)
        Dim districttxt As TextBox = DirectCast(GvwBusiness.Rows(GvwBusiness.EditIndex).FindControl("DistrictEdit_txt"), TextBox)
        Dim districtddl As DropDownList = DirectCast(GvwBusiness.Rows(GvwBusiness.EditIndex).FindControl("DdlParternerDist"), DropDownList)

        If countryddl.SelectedItem.Text.ToUpper() = "INDIA" Then

            Ds = regWS.GetTableDatasetOrderby("state_mst", "status", "A", "state_name")
            stateddl.DataSource() = Ds.Tables(0)
            stateddl.DataValueField = "state_code"
            stateddl.DataTextField = "state_name"
            stateddl.DataBind()
            stateddl.Items.Insert(0, "SELECT")
            districtddl.Visible = True
            stateddl.Visible = True
            statetxt.Visible = False
            districttxt.Visible = False
            Ds.Clear()
        Else
            districtddl.Visible = False
            stateddl.Visible = False
            statetxt.Visible = True
            districttxt.Visible = True
        End If

    End Sub
    'Based on Country selection loading of state dropdown in footer
    Protected Sub CountryFoot_ddl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim countryddl As DropDownList = DirectCast(GvwBusiness.FooterRow.FindControl("CountryFoot_ddl"), DropDownList)
        Dim stateddl As DropDownList = DirectCast(GvwBusiness.FooterRow.FindControl("StateFoot_ddl"), DropDownList)
        Dim statetxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("StateFoot_txt"), TextBox)
        Dim districtddl As DropDownList = DirectCast(GvwBusiness.FooterRow.FindControl("DistrictFoot_ddl"), DropDownList)
        Dim districttxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("DistrictFoot_txt"), TextBox)

        If countryddl.SelectedItem.Text.ToUpper() = "INDIA" Then
            Ds = regWS.GetTableDatasetOrderby("state_mst", "status", "A", "state_name")
            stateddl.Items.Clear()
            stateddl.DataSource() = Ds.Tables(0)
            stateddl.DataValueField = "state_code"
            stateddl.DataTextField = "state_name"
            stateddl.DataBind()
            stateddl.Items.Insert(0, "SELECT")
            districtddl.Visible = True
            stateddl.Visible = True
            statetxt.Visible = False
            districttxt.Visible = False
        Else
            districtddl.Visible = False
            stateddl.Visible = False
            statetxt.Visible = True
            districttxt.Visible = True
        End If

    End Sub
    'Based on State selection loading of district dropdown
    Protected Sub DdlState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim stateddl As DropDownList = DirectCast(GvwBusiness.Rows(GvwBusiness.EditIndex).FindControl("DdlState"), DropDownList)
        Dim districtddl As DropDownList = DirectCast(GvwBusiness.Rows(GvwBusiness.EditIndex).FindControl("DdlParternerDist"), DropDownList)
        Dim districttxt As TextBox = DirectCast(GvwBusiness.Rows(GvwBusiness.EditIndex).FindControl("DistrictEdit_txt"), TextBox)

        If stateddl.SelectedItem.Text.ToUpper() = "TELANGANA" Then

            Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
            districtddl.DataSource() = Ds.Tables(0)
            districtddl.DataValueField = "district_code"
            districtddl.DataTextField = "district_name"
            districtddl.DataBind()
            districtddl.Items.Insert(0, "SELECT")
            districtddl.Visible = True
            districttxt.Visible = False
            Ds.Clear()
            'ElseIf stateddl.SelectedItem.Text.ToUpper() = "ANDHRA PRADESH" Then
            '    'Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
            '    Ds = regWS.GetDistrictsAP()
            '    districtddl.DataSource() = Ds.Tables(0)
            '    districtddl.DataValueField = "district_code"
            '    districtddl.DataTextField = "district_name"
            '    districtddl.DataBind()
            '    districtddl.Items.Insert(0, "SELECT")
            '    districtddl.Visible = True
            '    districttxt.Visible = False
            '    Ds.Clear()
        Else
            districtddl.Visible = False
            districttxt.Visible = True
        End If

    End Sub

    'Based on State selection loading of district dropdown in footer
    Protected Sub StateFoot_ddl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim stateddl As DropDownList = DirectCast(GvwBusiness.FooterRow.FindControl("StateFoot_ddl"), DropDownList)
        Dim districtddl As DropDownList = DirectCast(GvwBusiness.FooterRow.FindControl("DistrictFoot_ddl"), DropDownList)
        Dim districttxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("DistrictFoot_txt"), TextBox)

        If stateddl.SelectedItem.Text.ToUpper() = "TELANGANA" Then
            Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
            districtddl.DataSource() = Ds.Tables(0)
            districtddl.DataValueField = "district_code"
            districtddl.DataTextField = "district_name"
            districtddl.DataBind()
            districtddl.Items.Insert(0, "SELECT")
            districtddl.Visible = True
            districttxt.Visible = False
            Ds.Clear()
            'ElseIf stateddl.SelectedItem.Text.ToUpper() = "ANDHRA PRADESH" Then
            '    'Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
            '    Ds = regWS.GetDistrictsAP()
            '    districtddl.DataSource() = Ds.Tables(0)
            '    districtddl.DataValueField = "district_code"
            '    districtddl.DataTextField = "district_name"
            '    districtddl.DataBind()
            '    districtddl.Items.Insert(0, "SELECT")
            '    districtddl.Visible = True
            '    districttxt.Visible = False
            '    Ds.Clear()
        Else
            districtddl.Visible = False
            districttxt.Visible = True
        End If

    End Sub

    'Row Databound event in 6th step
    Protected Sub GvwBusiness_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GvwBusiness.RowDataBound

        'it helps to find the controls in the edit mode
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit Then

            Dim countryddl As DropDownList = DirectCast(e.Row.FindControl("DdlCountry"), DropDownList)
            Dim stateddl As DropDownList = DirectCast(e.Row.FindControl("DdlState"), DropDownList)
            Dim districtddl As DropDownList = DirectCast(e.Row.FindControl("DdlParternerDist"), DropDownList)
            Ds = regWS.GetTableDatasetOrderby("country_mst", "status", "A", "country_name")
            countryddl.DataSource() = Ds.Tables(0)
            countryddl.DataValueField = "country_code"
            countryddl.DataTextField = "country_name"
            countryddl.DataBind()

            countryddl.Items.Insert(0, "SELECT")
            stateddl.Items.Insert(0, "SELECT")
            districtddl.Items.Insert(0, "SELECT")
            Ds.Clear()
        End If
        If e.Row.RowType = DataControlRowType.Footer Then

            Dim countryddl As DropDownList = DirectCast(e.Row.FindControl("CountryFoot_ddl"), DropDownList)
            Dim stateddl As DropDownList = DirectCast(e.Row.FindControl("StateFoot_ddl"), DropDownList)
            Dim districtddl As DropDownList = DirectCast(e.Row.FindControl("DistrictFoot_ddl"), DropDownList)

            Ds = regWS.GetTableDatasetOrderby("country_mst", "status", "A", "country_name")
            countryddl.DataSource() = Ds.Tables(0)
            countryddl.DataValueField = "country_code"
            countryddl.DataTextField = "country_name"
            countryddl.DataBind()
            countryddl.Items.Insert(0, "SELECT")
            stateddl.Items.Insert(0, "SELECT")
            districtddl.Items.Insert(0, "SELECT")
            Ds.Clear()
        End If

    End Sub
    'Row Command event in 6th step
    Protected Sub GvwBusiness_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GvwBusiness.RowCommand

        Dim status As Integer = 0

        If e.CommandName = "Insert" Then
            Dim nametxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("namefoot_txt"), TextBox)
            Dim fathernametxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("FatherNameFoot_txt"), TextBox)
            Dim doornotxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("DoorNoFoot_txt"), TextBox)
            Dim streettxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("StreetFoot_txt"), TextBox)
            Dim locationtxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("LocalityFoot_txt"), TextBox)
            Dim statetxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("StateFoot_txt"), TextBox)
            Dim districttxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("DistrictFoot_txt"), TextBox)
            Dim citytxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("CityFoot_txt"), TextBox)
            Dim pintxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("PinFoot_txt"), TextBox)
            Dim uidtxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("UidFoot_txt"), TextBox)
            Dim emailtxt As TextBox = DirectCast(GvwBusiness.FooterRow.FindControl("EmailFoot_txt"), TextBox)
            Dim countryddl As DropDownList = DirectCast(GvwBusiness.FooterRow.FindControl("CountryFoot_ddl"), DropDownList)
            Dim stateddl As DropDownList = DirectCast(GvwBusiness.FooterRow.FindControl("StateFoot_ddl"), DropDownList)
            Dim districtddl As DropDownList = DirectCast(GvwBusiness.FooterRow.FindControl("DistrictFoot_ddl"), DropDownList)

            Ds = regWS.GetMaxSNo(LblRNR.Text)

            slno = Convert.ToInt32(Ds.Tables("SnoPartners").Rows(0)(0)) + 1

            If statetxt.Visible = False AndAlso districttxt.Visible = False Then
                status = regWS.RegStepSixIns(LblRNR.Text, slno, nametxt.Text, uidtxt.Text, fathernametxt.Text, _
                doornotxt.Text, streettxt.Text, locationtxt.Text, citytxt.Text, "P", _
                districtddl.SelectedItem.Text, stateddl.SelectedItem.Text, pintxt.Text, emailtxt.Text, _
                countryddl.SelectedItem.Text)
            End If

            If statetxt.Visible = True AndAlso districttxt.Visible = True AndAlso stateddl.Visible = False AndAlso districtddl.Visible = False Then
                status = regWS.RegStepSixIns(LblRNR.Text, slno, nametxt.Text, uidtxt.Text, fathernametxt.Text, doornotxt.Text, _
                                    streettxt.Text, locationtxt.Text, citytxt.Text, "P", districttxt.Text, statetxt.Text, _
                                    pintxt.Text, emailtxt.Text, countryddl.SelectedItem.Text)
            End If

            If stateddl.Visible = True AndAlso districttxt.Visible = True AndAlso statetxt.Visible = False AndAlso districtddl.Visible = False Then
                status = regWS.RegStepSixIns(LblRNR.Text, slno, nametxt.Text, uidtxt.Text, fathernametxt.Text, _
                                    doornotxt.Text, streettxt.Text, locationtxt.Text, citytxt.Text, "P", districttxt.Text, _
                                    stateddl.SelectedItem.Text, pintxt.Text, emailtxt.Text, countryddl.SelectedItem.Text)
            End If

            If status = 1 Then
                GvwBusiness.EditIndex = -1
                PartnersGridBind()
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Inserted Record Successfully..')", True)
            Else
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Failed to insert the record!..')", True)
            End If
        End If

    End Sub

    'Row Edit event in 6th step
    Protected Sub GvwBusiness_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvwBusiness.RowEditing


        Dim countrylbl As Label = DirectCast(GvwBusiness.Rows(e.NewEditIndex).FindControl("Country_lbl"), Label)
        Dim statelbl As Label = DirectCast(GvwBusiness.Rows(e.NewEditIndex).FindControl("state_lbl"), Label)
        Dim districtlbl As Label = DirectCast(GvwBusiness.Rows(e.NewEditIndex).FindControl("District_lbl"), Label)
        Dim country As String = countrylbl.Text
        Dim state As String = statelbl.Text
        Dim district As String = districtlbl.Text

        GvwBusiness.EditIndex = e.NewEditIndex
        PartnersGridBind()
        GvwBusiness.Rows(GvwBusiness.EditIndex).BackColor = System.Drawing.Color.LightSteelBlue

        Dim countryddl As DropDownList = DirectCast(GvwBusiness.Rows(e.NewEditIndex).FindControl("DdlCountry"), DropDownList)
        countryddl.Items.FindByText(country).Selected = True
        Dim stateddl As DropDownList = DirectCast(GvwBusiness.Rows(e.NewEditIndex).FindControl("DdlState"), DropDownList)

        Dim StateTxt As TextBox = DirectCast(GvwBusiness.Rows(e.NewEditIndex).FindControl("State_txt"), TextBox)
        Dim RequiredFieldValidator37 As RequiredFieldValidator = DirectCast(GvwBusiness.Rows(e.NewEditIndex).FindControl("RequiredFieldValidator37"), RequiredFieldValidator)
        Dim RequiredFieldValidator39 As RequiredFieldValidator = DirectCast(GvwBusiness.Rows(e.NewEditIndex).FindControl("RequiredFieldValidator39"), RequiredFieldValidator)


        If (countryddl.SelectedItem.Text.ToUpper() = "INDIA") Then
            stateddl.Visible = True
            StateTxt.Visible = False
            RequiredFieldValidator39.Enabled = True
            RequiredFieldValidator37.Enabled = True
            Ds = regWS.GetTableDatasetOrderby("state_mst", "status", "A", "state_name")
            stateddl.Items.Clear()
            stateddl.DataSource() = Ds.Tables(0)
            stateddl.DataValueField = "state_code"
            stateddl.DataTextField = "state_name"
            stateddl.DataBind()
            stateddl.Items.FindByText(state).Selected = True
        Else
            stateddl.Visible = False
            StateTxt.Visible = True
            RequiredFieldValidator39.Enabled = False
            RequiredFieldValidator37.Enabled = False
        End If

        Dim districtddl As DropDownList = DirectCast(GvwBusiness.Rows(e.NewEditIndex).FindControl("DdlParternerDist"), DropDownList)
        Dim DistTxt As TextBox = DirectCast(GvwBusiness.Rows(e.NewEditIndex).FindControl("DistrictEdit_txt"), TextBox)

        'If (stateddl.SelectedItem.Text.ToUpper() = "TELANGANA") Then

        '    districtddl.Visible = True
        '    DistTxt.Visible = False
        '    Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
        '    districtddl.DataSource() = Ds.Tables(0)
        '    districtddl.DataValueField = "district_code"
        '    districtddl.DataTextField = "district_name"
        '    districtddl.DataBind()
        '    districtddl.Items.FindByText(district).Selected = True
        'Else
        '    districtddl.Visible = False
        '    DistTxt.Visible = True
        'End If

        If stateddl.SelectedItem.Text.ToUpper() = "TELANGANA" Then
            districtddl.Visible = True
            DistTxt.Visible = False
            Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
            districtddl.DataSource() = Ds.Tables(0)
            districtddl.DataValueField = "district_code"
            districtddl.DataTextField = "district_name"
            districtddl.DataBind()
            'districtddl.Items.Insert(0, "SELECT")
            districtddl.Items.FindByText(district).Selected = True
            Ds.Clear()
            'ElseIf stateddl.SelectedItem.Text.ToUpper() = "ANDHRA PRADESH" Then
            '    districtddl.Visible = True
            '    DistTxt.Visible = False
            '    'Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
            '    Ds = regWS.GetDistrictsAP()
            '    districtddl.DataSource() = Ds.Tables(0)
            '    districtddl.DataValueField = "district_code"
            '    districtddl.DataTextField = "district_name"
            '    districtddl.DataBind()
            '    'districtddl.Items.Insert(0, "SELECT")
            '    districtddl.Items.FindByText(district).Selected = True
            '    Ds.Clear()
        Else
            districtddl.Visible = False
            DistTxt.Visible = True
        End If

        Ds.Clear()
        Dim partnamevalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator53"), RequiredFieldValidator)
        Dim fathernamevalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator55"), RequiredFieldValidator)
        Dim doornovalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator57"), RequiredFieldValidator)
        Dim streetvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator59"), RequiredFieldValidator)
        Dim localityvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator61"), RequiredFieldValidator)
        Dim countryvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator30"), RequiredFieldValidator)
        Dim statevalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator38"), RequiredFieldValidator)
        Dim districtvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator40"), RequiredFieldValidator)
        Dim cityvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator63"), RequiredFieldValidator)
        Dim pinvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator65"), RequiredFieldValidator)
        Dim uidvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator67"), RequiredFieldValidator)
        Dim emailvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator69"), RequiredFieldValidator)

        partnamevalidator.Enabled = False
        fathernamevalidator.Enabled = False
        doornovalidator.Enabled = False
        streetvalidator.Enabled = False
        localityvalidator.Enabled = False
        countryvalidator.Enabled = False
        statevalidator.Enabled = False
        districtvalidator.Enabled = False
        cityvalidator.Enabled = False
        pinvalidator.Enabled = False
        uidvalidator.Enabled = False
        emailvalidator.Enabled = False


    End Sub
    'Row Cancell event in 6th step
    Protected Sub GvwBusiness_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvwBusiness.RowCancelingEdit

        GvwBusiness.EditIndex = -1
        PartnersGridBind()

    End Sub
    'Row Update event in 6th step
    Protected Sub GvwBusiness_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvwBusiness.RowUpdating

        Try

            Dim status As Integer = 0
            Dim partnername As TextBox = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("PartDirectNameEdit_txt"), TextBox)
            Dim fathername As TextBox = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("FatherNameEdit_txt"), TextBox)
            Dim doorno As TextBox = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("DoorNoEdit_txt"), TextBox)
            Dim street As TextBox = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("RoadStreetBuildEdit_txt"), TextBox)
            Dim location As TextBox = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("LocalityEdit_txt"), TextBox)
            Dim country As DropDownList = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("DdlCountry"), DropDownList)
            Dim state As DropDownList = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("DdlState"), DropDownList)
            Dim statetxt As TextBox = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("State_txt"), TextBox)
            Dim district As DropDownList = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("DdlParternerDist"), DropDownList)
            Dim districttxt As TextBox = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("DistrictEdit_txt"), TextBox)
            Dim city As TextBox = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("CityEdit_txt"), TextBox)
            Dim pin As TextBox = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("PinZipEdit_txt"), TextBox)
            Dim uid As TextBox = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("UidEdit_txt"), TextBox)
            Dim email As TextBox = DirectCast(GvwBusiness.Rows(e.RowIndex).FindControl("EmailEdit_txt"), TextBox)
            Dim slno As Integer = Convert.ToInt32(GvwBusiness.DataKeys(e.RowIndex).Value)
            Dim partnamevalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator53"), RequiredFieldValidator)
            Dim fathernamevalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator55"), RequiredFieldValidator)
            Dim doornovalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator57"), RequiredFieldValidator)
            Dim streetvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator59"), RequiredFieldValidator)
            Dim localityvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator61"), RequiredFieldValidator)
            Dim countryvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator30"), RequiredFieldValidator)
            Dim statevalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator38"), RequiredFieldValidator)
            Dim districtvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator40"), RequiredFieldValidator)
            Dim cityvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator63"), RequiredFieldValidator)
            Dim pinvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator65"), RequiredFieldValidator)
            Dim uidvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator67"), RequiredFieldValidator)
            Dim emailvalidator As RequiredFieldValidator = DirectCast(GvwBusiness.FooterRow.FindControl("RequiredFieldValidator69"), RequiredFieldValidator)


            If statetxt.Visible = False AndAlso districttxt.Visible = False Then
                status = regWS.RegStepSixUpd(LblRNR.Text, slno, partnername.Text, uid.Text, fathername.Text, _
                            doorno.Text, street.Text, location.Text, city.Text, "P", district.SelectedItem.Text, _
                            state.SelectedItem.Text, pin.Text, email.Text, country.SelectedItem.Text)
            End If

            If statetxt.Visible = True AndAlso districttxt.Visible = True AndAlso state.Visible = False AndAlso district.Visible = False Then
                status = regWS.RegStepSixUpd(LblRNR.Text, slno, partnername.Text, uid.Text, fathername.Text, _
                                doorno.Text, street.Text, location.Text, city.Text, "P", districttxt.Text, _
                                statetxt.Text, pin.Text, email.Text, country.SelectedItem.Text)
            End If

            If statetxt.Visible = False AndAlso districttxt.Visible = True AndAlso state.Visible = True AndAlso district.Visible = False Then
                status = regWS.RegStepSixUpd(LblRNR.Text, slno, partnername.Text, uid.Text, fathername.Text, _
                                               doorno.Text, street.Text, location.Text, city.Text, "P", districttxt.Text, _
                                               state.SelectedItem.Text, pin.Text, email.Text, country.SelectedItem.Text)
            End If

            If status = 1 Then
                GvwBusiness.EditIndex = -1
                PartnersGridBind()
                partnamevalidator.Enabled = True
                fathernamevalidator.Enabled = True
                doornovalidator.Enabled = True
                streetvalidator.Enabled = True
                localityvalidator.Enabled = True
                countryvalidator.Enabled = True
                statevalidator.Enabled = True
                districtvalidator.Enabled = True
                cityvalidator.Enabled = True
                pinvalidator.Enabled = True
                uidvalidator.Enabled = True
                emailvalidator.Enabled = True

                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Updated Successfully..')", True)
            Else

                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Sorry, Updation failed..')", True)
                Exit Sub

            End If

        Catch ex As Exception
            Errors.ErrorLog_Vat(ex)
            Throw New Exception("Failed to Update record due to following error: " + ex.Message)
        End Try

    End Sub
    'Row Delete event in 6th step
    Protected Sub GvwBusiness_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvwBusiness.RowDeleting

        slno = Convert.ToInt32(GvwBusiness.DataKeys(e.RowIndex).Value)
        'Dim deleteQuery As String = "delete from reg_partners_tmp where rnr='" & LblRNR.Text & "' and serial_no=" & slno & ""

        Dim status As Integer = regWS.RegStepSixDel(LblRNR.Text, slno)
        If status = 0 Then
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Failed to Delete the Record...')", True)
        Else
            GvwBusiness.EditIndex = -1
            PartnersGridBind()
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Record Deleted Successfully...')", True)
        End If

    End Sub

    'Row Cancell event in 5th step
    Protected Sub gvPartnerBusiness_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvPartnerBusiness.RowCancelingEdit

        gvPartnerBusiness.EditIndex = -1
        AddBusGridBind()

    End Sub

    'Row Command event in 5th step
    Protected Sub gvPartnerBusiness_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPartnerBusiness.RowCommand

        Dim status As Integer = 0

        If e.CommandName = "Insert" Then
            Dim doornotxt As TextBox = DirectCast(gvPartnerBusiness.FooterRow.FindControl("DoorNoFoot_txt"), TextBox)
            Dim streettxt As TextBox = DirectCast(gvPartnerBusiness.FooterRow.FindControl("StreetFoot_txt"), TextBox)
            Dim locationtxt As TextBox = DirectCast(gvPartnerBusiness.FooterRow.FindControl("LocalityFoot_txt"), TextBox)
            Dim districttxt As TextBox = DirectCast(gvPartnerBusiness.FooterRow.FindControl("DistrictFoot_txt"), TextBox)
            Dim citytxt As TextBox = DirectCast(gvPartnerBusiness.FooterRow.FindControl("CityFoot_txt"), TextBox)
            Dim pintxt As TextBox = DirectCast(gvPartnerBusiness.FooterRow.FindControl("PinFoot_txt"), TextBox)
            Dim stateddl As DropDownList = DirectCast(gvPartnerBusiness.FooterRow.FindControl("StateFoot_ddl"), DropDownList)
            Dim districtddl As DropDownList = DirectCast(gvPartnerBusiness.FooterRow.FindControl("DistrictFoot_ddl"), DropDownList)
            Dim typeddl As DropDownList = DirectCast(gvPartnerBusiness.FooterRow.FindControl("ddlFootType"), DropDownList)

            Ds = regWS.GetMaxSNo(LblRNR.Text)

            slno = Convert.ToInt32(Ds.Tables("SnoBusiness").Rows(0)(0)) + 1

            If districttxt.Visible = False AndAlso districtddl.Visible = True AndAlso stateddl.Visible = True Then
                status = regWS.RegStepFiveIns(LblRNR.Text, slno, doornotxt.Text, streettxt.Text, locationtxt.Text, _
                        citytxt.Text, typeddl.SelectedItem.Value, districtddl.SelectedItem.Text, stateddl.SelectedItem.Text, pintxt.Text)
            End If

            If districttxt.Visible = True AndAlso districtddl.Visible = False AndAlso stateddl.Visible = True Then
                status = regWS.RegStepFiveIns(LblRNR.Text, slno, doornotxt.Text, streettxt.Text, locationtxt.Text, _
                        citytxt.Text, typeddl.SelectedItem.Value, districttxt.Text, stateddl.SelectedItem.Text, pintxt.Text)
            End If

            If status = 1 Then
                gvPartnerBusiness.EditIndex = -1
                AddBusGridBind()
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Inserted Successfully..')", True)
            Else
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.GetType(), "alertscript", "alert('Failed to Insert the Record...')", True)
            End If
        End If

    End Sub
    'Row Databound event in 5th step
    Protected Sub gvPartnerBusiness_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPartnerBusiness.RowDataBound

        'it helps to find the controls in the edit mode
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit Then

            Dim stateddl As DropDownList = DirectCast(e.Row.FindControl("DdlState"), DropDownList)
            Dim districtddl As DropDownList = DirectCast(e.Row.FindControl("DdlParternerDist"), DropDownList)

            Ds = regWS.GetTableDatasetOrderby("state_mst", "status", "A", "state_name")
            stateddl.Items.Clear()
            stateddl.DataSource() = Ds.Tables(0)
            stateddl.DataValueField = "state_code"
            stateddl.DataTextField = "state_name"
            stateddl.DataBind()

            stateddl.Items.Insert(0, "SELECT")
            districtddl.Items.Insert(0, "SELECT")
            Ds.Clear()
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            Ds = regWS.getpartnerBusiness(LblRNR.Text)
            Dim stateddl As DropDownList = DirectCast(e.Row.FindControl("StateFoot_ddl"), DropDownList)
            Dim districtddl As DropDownList = DirectCast(e.Row.FindControl("DistrictFoot_ddl"), DropDownList)

            Ds = regWS.GetTableDatasetOrderby("state_mst", "status", "A", "state_name")
            stateddl.Items.Clear()
            stateddl.DataSource() = Ds.Tables(0)
            stateddl.DataValueField = "state_code"
            stateddl.DataTextField = "state_name"
            stateddl.DataBind()
            stateddl.Items.Insert(0, "SELECT")
            districtddl.Items.Insert(0, "SELECT")
            Ds.Clear()
        End If

    End Sub
    'Row Delete event in 5th step
    Protected Sub gvPartnerBusiness_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvPartnerBusiness.RowDeleting

        gvPartnerBusiness.Rows(e.RowIndex).BackColor = System.Drawing.Color.IndianRed
        slno = Convert.ToInt32(gvPartnerBusiness.DataKeys(e.RowIndex).Value)

        Dim status As Integer = regWS.RegStepFiveDel(LblRNR.Text, slno)
        If status = 0 Then
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.[GetType](), "alertscript", "alert('Failed to delete the Record...')", True)
        Else

            gvPartnerBusiness.EditIndex = -1
            AddBusGridBind()
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.[GetType](), "alertscript", "alert('Record deleted Successfully...')", True)
        End If

    End Sub
    'Row Edit event in 5th step
    Protected Sub gvPartnerBusiness_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvPartnerBusiness.RowEditing

        Dim statelbl As Label = DirectCast(gvPartnerBusiness.Rows(e.NewEditIndex).FindControl("state_lbl"), Label)
        Dim districtlbl As Label = DirectCast(gvPartnerBusiness.Rows(e.NewEditIndex).FindControl("District_lbl"), Label)
        Dim type_lbl As Label = DirectCast(gvPartnerBusiness.Rows(e.NewEditIndex).FindControl("type_lbl"), Label)

        Dim state As String = statelbl.Text
        Dim district As String = districtlbl.Text
        Dim typelbl As String = type_lbl.Text

        gvPartnerBusiness.EditIndex = e.NewEditIndex
        AddBusGridBind()

        Dim stateddl As DropDownList = DirectCast(gvPartnerBusiness.Rows(e.NewEditIndex).FindControl("DdlState"), DropDownList)
        stateddl.Items.FindByText(state).Selected = True

        Dim typeddl As DropDownList = DirectCast(gvPartnerBusiness.Rows(e.NewEditIndex).FindControl("ddlEditType"), DropDownList)
        typeddl.Items.FindByValue(typelbl).Selected = True

        Dim districtddl As DropDownList = DirectCast(gvPartnerBusiness.Rows(e.NewEditIndex).FindControl("DdlParternerDist"), DropDownList)
        Dim DistrictEdit_txt As TextBox = DirectCast(gvPartnerBusiness.Rows(e.NewEditIndex).FindControl("DistrictEdit_txt"), TextBox)
        Dim RequiredFieldValidator33 As RequiredFieldValidator = DirectCast(gvPartnerBusiness.Rows(e.NewEditIndex).FindControl("RequiredFieldValidator33"), RequiredFieldValidator)
        'If stateddl.SelectedItem.Text.ToUpper() = "TELANGANA" Then
        '    districtddl.Visible = True
        '    DistrictEdit_txt.Visible = False
        '    RequiredFieldValidator33.Enabled = True
        '    Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
        '    districtddl.DataSource() = Ds.Tables(0)
        '    districtddl.DataValueField = "district_code"
        '    districtddl.DataTextField = "district_name"
        '    districtddl.DataBind()
        '    districtddl.Items.FindByText(district).Selected = True
        '    Ds.Clear()

        'Else
        '    districtddl.Visible = False
        '    DistrictEdit_txt.Visible = True
        '    RequiredFieldValidator33.Enabled = False
        'End If

        If stateddl.SelectedItem.Text.ToUpper() = "TELANGANA" Then
            districtddl.Visible = True
            DistrictEdit_txt.Visible = False
            RequiredFieldValidator33.Enabled = True
            Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
            districtddl.DataSource() = Ds.Tables(0)
            districtddl.DataValueField = "district_code"
            districtddl.DataTextField = "district_name"
            districtddl.DataBind()
            'districtddl.Items.Insert(0, "SELECT")
            districtddl.Items.FindByText(district).Selected = True
            Ds.Clear()
            'ElseIf stateddl.SelectedItem.Text.ToUpper() = "ANDHRA PRADESH" Then
            '    districtddl.Visible = True
            '    DistrictEdit_txt.Visible = False
            '    RequiredFieldValidator33.Enabled = True
            '    'Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
            '    Ds = regWS.GetDistrictsAP()
            '    districtddl.DataSource() = Ds.Tables(0)
            '    districtddl.DataValueField = "district_code"
            '    districtddl.DataTextField = "district_name"
            '    districtddl.DataBind()
            '    'districtddl.Items.Insert(0, "SELECT")
            '    districtddl.Items.FindByText(district).Selected = True
            '    Ds.Clear()
        Else
            districtddl.Visible = False
            DistrictEdit_txt.Visible = True
            RequiredFieldValidator33.Enabled = False
        End If

        Dim statevalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator32"), RequiredFieldValidator)
        Dim districtvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator34"), RequiredFieldValidator)
        Dim typevalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator36"), RequiredFieldValidator)
        Dim doorvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator43"), RequiredFieldValidator)
        Dim streetvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator45"), RequiredFieldValidator)
        Dim localityvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator47"), RequiredFieldValidator)
        Dim cityvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator49"), RequiredFieldValidator)
        Dim pinvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator51"), RequiredFieldValidator)

        statevalidator.Enabled = False
        districtvalidator.Enabled = False
        typevalidator.Enabled = False
        doorvalidator.Enabled = False
        streetvalidator.Enabled = False
        localityvalidator.Enabled = False
        cityvalidator.Enabled = False
        pinvalidator.Enabled = False

    End Sub
    'Row Update event in 5th step
    Protected Sub gvPartnerBusiness_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvPartnerBusiness.RowUpdating

        Try
            Dim status As Integer = 0
            Dim doorno As TextBox = DirectCast(gvPartnerBusiness.Rows(e.RowIndex).FindControl("DoorNoEdit_txt"), TextBox)
            Dim street As TextBox = DirectCast(gvPartnerBusiness.Rows(e.RowIndex).FindControl("RoadStreetBuildEdit_txt"), TextBox)
            Dim location As TextBox = DirectCast(gvPartnerBusiness.Rows(e.RowIndex).FindControl("LocalityEdit_txt"), TextBox)
            Dim state As DropDownList = DirectCast(gvPartnerBusiness.Rows(e.RowIndex).FindControl("DdlState"), DropDownList)
            Dim district As DropDownList = DirectCast(gvPartnerBusiness.Rows(e.RowIndex).FindControl("DdlParternerDist"), DropDownList)
            Dim districttxt As TextBox = DirectCast(gvPartnerBusiness.Rows(e.RowIndex).FindControl("DistrictEdit_txt"), TextBox)
            Dim city As TextBox = DirectCast(gvPartnerBusiness.Rows(e.RowIndex).FindControl("CityEdit_txt"), TextBox)
            Dim pin As TextBox = DirectCast(gvPartnerBusiness.Rows(e.RowIndex).FindControl("PinZipEdit_txt"), TextBox)
            Dim slno As Integer = Convert.ToInt32(gvPartnerBusiness.DataKeys(e.RowIndex).Value)
            Dim statevalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator32"), RequiredFieldValidator)
            Dim districtvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator34"), RequiredFieldValidator)
            Dim typevalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator36"), RequiredFieldValidator)
            Dim doorvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator43"), RequiredFieldValidator)
            Dim streetvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator45"), RequiredFieldValidator)
            Dim localityvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator47"), RequiredFieldValidator)
            Dim cityvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator49"), RequiredFieldValidator)
            Dim pinvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.FooterRow.FindControl("RequiredFieldValidator51"), RequiredFieldValidator)
            Dim type As DropDownList = DirectCast(gvPartnerBusiness.Rows(e.RowIndex).FindControl("ddlEditType"), DropDownList)


            If districttxt.Visible = False AndAlso district.Visible = True AndAlso state.Visible = True Then
                status = regWS.RegStepFiveUpd(LblRNR.Text, slno, doorno.Text, street.Text, location.Text, _
                        city.Text, type.SelectedItem.Value, district.SelectedItem.Text, state.SelectedItem.Text, pin.Text)
            End If

            If districttxt.Visible = True AndAlso district.Visible = False AndAlso state.Visible = True Then
                status = regWS.RegStepFiveUpd(LblRNR.Text, slno, doorno.Text, street.Text, location.Text, _
                            city.Text, type.SelectedItem.Value, districttxt.Text, state.SelectedItem.Text, pin.Text)
            End If

            If status = 1 Then
                gvPartnerBusiness.EditIndex = -1
                AddBusGridBind()
                statevalidator.Enabled = True
                districtvalidator.Enabled = True
                typevalidator.Enabled = True
                doorvalidator.Enabled = True
                streetvalidator.Enabled = True
                localityvalidator.Enabled = True
                cityvalidator.Enabled = True
                pinvalidator.Enabled = True
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.[GetType](), "alertscript", "alert('Updated Successfully..')", True)
            Else

                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.[GetType](), "alertscript", "alert('Sorry, Updation failed..')", True)
            End If

        Catch ex As Exception
            Errors.ErrorLog_Vat(ex)
            Throw New Exception("Failed to Update record due to following error: " + ex.Message)
        End Try

    End Sub
    'Based on State selection district dropdown loading in 5th step
    Protected Sub DdlState_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim stateddl As DropDownList = DirectCast(gvPartnerBusiness.Rows(gvPartnerBusiness.EditIndex).FindControl("DdlState"), DropDownList)
        Dim districtddl As DropDownList = DirectCast(gvPartnerBusiness.Rows(gvPartnerBusiness.EditIndex).FindControl("DdlParternerDist"), DropDownList)
        Dim districttxt As TextBox = DirectCast(gvPartnerBusiness.Rows(gvPartnerBusiness.EditIndex).FindControl("DistrictEdit_txt"), TextBox)
        Dim districtvalidator As RequiredFieldValidator = DirectCast(gvPartnerBusiness.Rows(gvPartnerBusiness.EditIndex).FindControl("RequiredFieldValidator33"), RequiredFieldValidator)


        If stateddl.SelectedItem.Text.ToUpper() = "TELANGANA" Then
            Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
            districtddl.DataSource() = Ds.Tables(0)
            districtddl.DataValueField = "district_code"
            districtddl.DataTextField = "district_name"
            districtddl.DataBind()
            districtddl.Items.Insert(0, "SELECT")
            districtddl.Visible = True
            districttxt.Visible = False
            districtvalidator.Enabled = True
            'ElseIf stateddl.SelectedItem.Text.ToUpper() = "ANDHRA PRADESH" Then
            '    'Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
            '    Ds = regWS.GetDistrictsAP()
            '    districtddl.DataSource() = Ds.Tables(0)
            '    districtddl.DataValueField = "district_code"
            '    districtddl.DataTextField = "district_name"
            '    districtddl.DataBind()
            '    districtddl.Items.Insert(0, "SELECT")
            '    districtddl.Visible = True
            '    districttxt.Visible = False
            '    districtvalidator.Enabled = True
            '    Ds.Clear()
        Else
            districtddl.Visible = False
            districttxt.Visible = True
            districtvalidator.Enabled = False
        End If

    End Sub
    'Based on State selection district dropdown loading in 5th step footer
    Protected Sub StateFoot_ddl_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim stateddl As DropDownList = DirectCast(gvPartnerBusiness.FooterRow.FindControl("StateFoot_ddl"), DropDownList)
        Dim districtddl As DropDownList = DirectCast(gvPartnerBusiness.FooterRow.FindControl("DistrictFoot_ddl"), DropDownList)
        Dim districttxt As TextBox = DirectCast(gvPartnerBusiness.FooterRow.FindControl("DistrictFoot_txt"), TextBox)

        If stateddl.SelectedItem.Text.ToUpper() = "TELANGANA" Then
            Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
            districtddl.DataSource() = Ds.Tables(0)
            districtddl.DataValueField = "district_code"
            districtddl.DataTextField = "district_name"
            districtddl.DataBind()
            districtddl.Items.Insert(0, "SELECT")
            districtddl.Visible = True
            districttxt.Visible = False
            'ElseIf stateddl.SelectedItem.Text.ToUpper() = "ANDHRA PRADESH" Then
            '    'Ds = regWS.GetTableDatasetOrderby("district_mst", "status", "A", "district_name")
            '    Ds = regWS.GetDistrictsAP()
            '    districtddl.DataSource() = Ds.Tables(0)
            '    districtddl.DataValueField = "district_code"
            '    districtddl.DataTextField = "district_name"
            '    districtddl.DataBind()
            '    districtddl.Items.Insert(0, "SELECT")
            '    districtddl.Visible = True
            '    districttxt.Visible = False
            '    Ds.Clear()
        Else
            districtddl.Visible = False
            districttxt.Visible = True
        End If

    End Sub

    'Filling of Circles dropdown based on Division selection
    Sub Fill_Circles()

        Ds = regWS.getAllLinkedCircles(DdlDivisions.SelectedValue.Trim)

        DdlCircles.DataSource() = Ds.Tables("Linked_Circles")
        DdlCircles.DataValueField = "circle_code"
        DdlCircles.DataTextField = "circle_name"
        DdlCircles.DataBind()
        DdlCircles.Items.Insert(0, "SELECT")
        DdlCircles.Items(0).Value = "sel"
        DdlCircles.SelectedIndex = 0
        Ds.Clear()
    End Sub

    Protected Sub DdlDivisions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlDivisions.SelectedIndexChanged

        Fill_Circles()

    End Sub

    Protected Sub RbReg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbReg.SelectedIndexChanged
        If RbReg.SelectedItem.Value = "S" Then
            RbRegACT.Items.FindByText("TOT").Enabled = False
            RbRegACT.Items.FindByText("TOT").Selected = False
            RbRegCST.Items.FindByText("Yes").Enabled = True
            RbRegCST.Items.FindByText("No").Enabled = True
        Else
            RbRegACT.Items.FindByText("TOT").Enabled = True
            RbRegCST.Items.FindByText("Yes").Enabled = True
            RbRegCST.Items.FindByText("No").Enabled = True
        End If
        'FirstTaxPeriod()
    End Sub

    Protected Sub RbRegACT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRegACT.SelectedIndexChanged
        If RbRegACT.SelectedItem.Value = "TOT" Then
            RbRegCST.Items.FindByText("Yes").Enabled = False
            RbRegCST.Items.FindByText("Yes").Selected = False
            RbRegCST.Items.FindByText("No").Enabled = True
            RbRegCST.Items.FindByText("No").Selected = True
        Else
            RbRegCST.Items.FindByText("Yes").Enabled = True
            RbRegCST.Items.FindByText("No").Enabled = True
        End If
        FirstTaxPeriod()
    End Sub

    'Protected Sub DdlTaxPrdYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlTaxPrdYear.SelectedIndexChanged
    '    DdlTaxPrdMonth.SelectedIndex = 0

    '    If RbRegACT.SelectedItem.Value = "TOT" Then
    '        DdlTaxPrdMonth.Items.Clear()
    '        DdlTaxPrdMonth.Items.Add("--Select--")
    '        DdlTaxPrdMonth.Items(0).Value = "sel"

    '        Dim mon As Integer = Convert.ToDateTime(TxtAppDt.Text).Month
    '        Select Case mon
    '            Case 4, 5, 6
    '                DdlTaxPrdMonth.Items.Add("Apr-Jun")
    '                DdlTaxPrdMonth.Items.Add("Jul-Sep")
    '            Case 7, 8, 9
    '                DdlTaxPrdMonth.Items.Add("Jul-Sep")
    '                DdlTaxPrdMonth.Items.Add("Oct-Dec")
    '            Case 10, 11, 12
    '                DdlTaxPrdMonth.Items.Add("Oct-Dec")
    '                DdlTaxPrdMonth.Items.Add("Jan-Mar")
    '            Case 1, 2, 3
    '                If DdlTaxPrdYear.SelectedValue = (Convert.ToDateTime(TxtAppDt.Text).Year & "-" & Convert.ToDateTime(TxtAppDt.Text).Year + 1) Then
    '                    DdlTaxPrdMonth.Items.Add("Jan-Mar")
    '                Else
    '                    DdlTaxPrdMonth.Items.Add("Apr-Jun")
    '                End If
    '        End Select
    '    End If
    'End Sub
    'loading of year for first tax period
    Sub FirstTaxPeriod()
        Dim year As Integer
        Dim CurrentMonth As String
        year = Convert.ToDateTime(TxtAppDt.Text).Year
        DdlTaxPrdMonth.Items.Clear()
        DdlTaxPrdYear.Items.Clear()

        If ViewState("AppDate") Is Nothing Then
            AppDate = DateTime.Parse(TxtAppDt.Text, Globalization.CultureInfo.CreateSpecificCulture("en-CA"))

            ViewState.Add("AppDate", AppDate)
        End If



        DdlTaxPrdYear.Items.Add("--Select--")
        DdlTaxPrdYear.Items(0).Value = "sel"

        DdlTaxPrdMonth.Items.Add("--Select--")
        DdlTaxPrdMonth.Items(0).Value = "sel"

        ''modified on 28-01-2012 on CCT's instructions.
        If RbRegACT.SelectedItem.Value = "VAT" Then

            DdlTaxPrdYear.Items.Add(ViewState("AppDate").Year)
            DdlTaxPrdYear.Items.Add(ViewState("AppDate").Year + 1)
            DdlTaxPrdYear.Items.Add(ViewState("AppDate").Year + 2)

            Dim t As New DateTime(1, 1, 1)
            For i As Integer = 1 To 12
                CurrentMonth = [String].Format("{0:MMMM}", t).ToString()
                t = t.AddMonths(1)
                ' DdlTaxPrdMonth.Items.Add(CurrentMonth)

                DdlTaxPrdMonth.Items.Add(New ListItem(CurrentMonth, i))
            Next
        ElseIf RbRegACT.SelectedItem.Value = "TOT" Then
            DdlTaxPrdYear.Items.Add(ViewState("AppDate").Year - 1 & "-" & ViewState("AppDate").Year)
            DdlTaxPrdYear.Items.Add(ViewState("AppDate").Year & "-" & ViewState("AppDate").Year + 1)
            DdlTaxPrdYear.Items.Add(ViewState("AppDate").Year + 1 & "-" & ViewState("AppDate").Year + 2)

            DdlTaxPrdMonth.Items.Add("Apr-Jun")
            DdlTaxPrdMonth.Items.Add("Jul-Sep")
            DdlTaxPrdMonth.Items.Add("Oct-Dec")
            DdlTaxPrdMonth.Items.Add("Jan-Mar")
        End If

        'If RbReg.SelectedItem.Value = "R" Then
        '    If RbRegACT.SelectedItem.Value = "VAT" Then

        '        Dim mon As Integer = Convert.ToDateTime(TxtAppDt.Text).Month

        '        Select Case mon
        '            Case 11, 12
        '                DdlTaxPrdYear.Items.Add(Convert.ToDateTime(TxtAppDt.Text).Year)
        '                DdlTaxPrdYear.Items.Add(Convert.ToDateTime(TxtAppDt.Text).Year + 1)
        '            Case Else
        '                DdlTaxPrdYear.Items.Add(Convert.ToDateTime(TxtAppDt.Text).Year)
        '        End Select

        '        Dim t As New DateTime(1, 1, 1)
        '        For i As Integer = 1 To 12
        '            CurrentMonth = [String].Format("{0:MMMM}", t).ToString()
        '            t = t.AddMonths(1)
        '            DdlTaxPrdMonth.Items.Add(CurrentMonth)
        '        Next

        '    ElseIf RbRegACT.SelectedItem.Value = "TOT" Then
        '        Dim mon As Integer = Convert.ToDateTime(TxtAppDt.Text).Month

        '        Select Case mon
        '            Case 1, 2, 3
        '                DdlTaxPrdYear.Items.Add(Convert.ToDateTime(TxtAppDt.Text).Year & "-" & Convert.ToDateTime(TxtAppDt.Text).Year + 1)
        '                DdlTaxPrdYear.Items.Add(Convert.ToDateTime(TxtAppDt.Text).Year + 1 & "-" & Convert.ToDateTime(TxtAppDt.Text).Year + 2)
        '            Case Else
        '                DdlTaxPrdYear.Items.Add(Convert.ToDateTime(TxtAppDt.Text).Year & "-" & Convert.ToDateTime(TxtAppDt.Text).Year + 1)
        '        End Select

        '        DdlTaxPrdMonth.Items.Add("Apr-Jun")
        '        DdlTaxPrdMonth.Items.Add("Jul-Sep")
        '        DdlTaxPrdMonth.Items.Add("Oct-Dec")
        '        DdlTaxPrdMonth.Items.Add("Jan-Mar")

        '    End If

        'ElseIf RbReg.SelectedItem.Value = "S" Then
        '    If RbRegACT.SelectedItem.Value = "VAT" Then
        '        Dim mon As Integer = Convert.ToDateTime(TxtAppDt.Text).Month

        '        Select Case mon
        '            Case 1
        '                DdlTaxPrdYear.Items.Add(Convert.ToDateTime(TxtAppDt.Text).Year)
        '                DdlTaxPrdYear.Items.Add(Convert.ToDateTime(TxtAppDt.Text).Year + 1)
        '            Case Else
        '                DdlTaxPrdYear.Items.Add(Convert.ToDateTime(TxtAppDt.Text).Year)
        '                DdlTaxPrdYear.Items.Add(Convert.ToDateTime(TxtAppDt.Text).Year + 1)
        '                DdlTaxPrdYear.Items.Add(Convert.ToDateTime(TxtAppDt.Text).Year + 2)
        '        End Select
        '    End If

        '    Dim t As New DateTime(1, 1, 1)
        '    For i As Integer = 1 To 12
        '        CurrentMonth = [String].Format("{0:MMMM}", t).ToString()
        '        t = t.AddMonths(1)
        '        DdlTaxPrdMonth.Items.Add(CurrentMonth)
        '    Next

        'End If
    End Sub
    ''loading of months for first tax period based on year
    Protected Sub DdlTaxPrdMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlTaxPrdMonth.SelectedIndexChanged
        Dim FrTxDt, AppDt As Date

        If RbReg.SelectedItem.Value = "R" Then
            If RbRegACT.SelectedItem.Value = "VAT" Then
                If DdlTaxPrdYear.SelectedItem.Value <> "sel" And DdlTaxPrdMonth.SelectedItem.Value <> "sel" Then

                    FrTxDt = "01-" & DdlTaxPrdMonth.SelectedValue & "-" & DdlTaxPrdYear.SelectedValue
                    AppDt = DateAdd("d", 44, ViewState("AppDate"))

                    If FrTxDt > AppDt Then
                        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "alertscript", "alert('First Tax Period should be with in 45 days from Application Date')", True)
                        DdlTaxPrdMonth.SelectedIndex = 0
                    ElseIf FrTxDt < ViewState("AppDate") Then
                        If FrTxDt.Month <> ViewState("AppDate").Month Then
                            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "alertscript", "alert('First Tax Period should not be less than the Application Date')", True)
                            DdlTaxPrdMonth.SelectedIndex = 0
                        Else
                            'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "alertscript", "alert('correct')", True)
                        End If

                    ElseIf FrTxDt > ViewState("AppDate") And FrTxDt < AppDt Then
                        'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "alertscript", "alert('correct')", True)
                    End If
                End If
            ElseIf RbRegACT.SelectedItem.Value = "TOT" Then


            End If

        ElseIf RbReg.SelectedItem.Value = "S" Then
            If RbRegACT.SelectedItem.Value = "VAT" Then
                If DdlTaxPrdYear.SelectedItem.Value <> "sel" And DdlTaxPrdMonth.SelectedItem.Value <> "sel" Then
                    FrTxDt = "01-" & DdlTaxPrdMonth.SelectedValue & "-" & DdlTaxPrdYear.SelectedValue
                    AppDt = DateAdd("m", 23, ViewState("AppDate"))

                    If FrTxDt > AppDt Then
                        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "alertscript", "alert('First Tax Period should be with in 24 months from Application Date')", True)
                        DdlTaxPrdMonth.SelectedIndex = 0
                    ElseIf FrTxDt < ViewState("AppDate") Then
                        If FrTxDt.Month <> ViewState("AppDate").Month Then
                            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "alertscript", "alert('First Tax Period should not be less than the Application Date')", True)
                            DdlTaxPrdMonth.SelectedIndex = 0
                        Else
                            'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "alertscript", "alert('correct')", True)
                        End If

                    ElseIf FrTxDt > ViewState("AppDate") And FrTxDt < AppDt Then
                        'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "alertscript", "alert('correct')", True)
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub WizardReg_ActiveStepChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WizardReg.ActiveStepChanged

        If (WizardReg.ActiveStepIndex = 4) Then
            Dim b As Button = DirectCast(WizardReg.FindControl("StepNavigationTemplateContainerID").FindControl("StepNextButton"), Button)
            b.CausesValidation = False
        End If

        If (WizardReg.ActiveStepIndex = 5) Then
            Dim b As Button = DirectCast(WizardReg.FindControl("FinishNavigationTemplateContainerID").FindControl("FinishButton"), Button)
            b.CausesValidation = True  ''''False

        End If

    End Sub
    'Business Activity List Box selected Items Copy to New List Box
    Protected Sub btnBusActAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBusActAdd.Click
        Dim boolPresent As Boolean = False

        If LBoxBusinessActivity.SelectedItem Is Nothing Then
            Exit Sub
        Else
            Dim intItemsCount As Integer = LBoxSelBusinessActivity.Items.Count
            If (intItemsCount >= 5) Then
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.[GetType](), "alertscript", "alert('You may select maximum 5 Business Activities only...')", True)
            Else
                For intItems As Integer = 0 To LBoxBusinessActivity.Items.Count - 1
                    If LBoxBusinessActivity.Items(intItems).Selected = True Then
                        If LBoxSelBusinessActivity.Items.Count > 0 Then
                            For intItemCount As Integer = 0 To LBoxSelBusinessActivity.Items.Count - 1
                                If LBoxSelBusinessActivity.Items(intItemCount).Text = LBoxBusinessActivity.Items(intItems).Text Then
                                    boolPresent = True
                                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.[GetType](), "alertscript", "alert('Business Activity Already Selected')", True)
                                    Exit For
                                Else
                                    boolPresent = False
                                End If
                            Next
                        End If
                        If boolPresent = False Then
                            LBoxSelBusinessActivity.Items.Add(LBoxBusinessActivity.Items(intItems))
                            LBoxSelBusinessActivity.ClearSelection()
                        Else
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If

    End Sub

    Protected Sub btnBusActRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBusActRemove.Click
        If LBoxSelBusinessActivity.SelectedItem Is Nothing Then
            Exit Sub
        Else
            If (LBoxSelBusinessActivity.Items.Count > 0) Then
                LBoxSelBusinessActivity.Items.RemoveAt(LBoxSelBusinessActivity.SelectedIndex)
            End If
        End If
        LBoxSelBusinessActivity.ClearSelection()
    End Sub

    Protected Sub btnCommodityAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCommodityAdd.Click
        Dim boolPresent As Boolean = False

        If LBoxCommodity.SelectedItem Is Nothing Then
            Exit Sub
        Else
            Dim intItemsCount As Integer = LBoxSelCommodity.Items.Count
            If (intItemsCount >= 5) Then
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.[GetType](), "alertscript", "alert('You may select maximum 5 Commodities only...')", True)
            Else
                For intItems As Integer = 0 To LBoxCommodity.Items.Count - 1
                    If LBoxCommodity.Items(intItems).Selected = True Then
                        If LBoxSelCommodity.Items.Count > 0 Then
                            For intItemCount As Integer = 0 To LBoxSelCommodity.Items.Count - 1
                                If LBoxSelCommodity.Items(intItemCount).Text = LBoxCommodity.Items(intItems).Text Then
                                    boolPresent = True
                                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.[GetType](), "alertscript", "alert('Commodity Already Selected')", True)
                                    Exit For
                                Else
                                    boolPresent = False
                                End If
                            Next
                        End If
                        If boolPresent = False Then
                            LBoxSelCommodity.Items.Add(LBoxCommodity.Items(intItems))
                            LBoxSelCommodity.ClearSelection()
                        Else
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Protected Sub btnCommodityRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCommodityRemove.Click
        If LBoxSelCommodity.SelectedItem Is Nothing Then
            Exit Sub
        Else


            If (LBoxSelCommodity.Items.Count > 0) Then
                LBoxSelCommodity.Items.RemoveAt(LBoxSelCommodity.SelectedIndex)
            End If
        End If
        LBoxSelCommodity.ClearSelection()
    End Sub

    Protected Sub btnInterstateAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInterstateAdd.Click
        Dim boolPresent As Boolean = False

        If LBoxInterstate.SelectedItem Is Nothing Then
            Exit Sub
        Else
            Dim intItemsCount As Integer = LBoxSelInterstate.Items.Count

            For intItems As Integer = 0 To LBoxInterstate.Items.Count - 1
                If LBoxInterstate.Items(intItems).Selected = True Then
                    If LBoxSelInterstate.Items.Count > 0 Then
                        For intItemCount As Integer = 0 To LBoxSelInterstate.Items.Count - 1
                            If LBoxSelInterstate.Items(intItemCount).Text = LBoxInterstate.Items(intItems).Text Then
                                boolPresent = True
                                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.[GetType](), "alertscript", "alert('Commodity Already Selected')", True)
                                Exit For
                            Else
                                boolPresent = False
                            End If
                        Next
                    End If
                    If boolPresent = False Then
                        LBoxSelInterstate.Items.Add(LBoxInterstate.Items(intItems))
                        LBoxSelInterstate.ClearSelection()
                    Else
                        Exit Sub
                    End If
                End If
            Next
        End If

    End Sub

    Protected Sub btnInterstateRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInterstateRemove.Click
        If LBoxSelInterstate.SelectedItem Is Nothing Then
            Exit Sub
        Else
            If (LBoxSelInterstate.Items.Count > 0) Then
                LBoxSelInterstate.Items.RemoveAt(LBoxSelInterstate.SelectedIndex)
            End If
        End If
        LBoxSelInterstate.ClearSelection()
    End Sub

    Protected Sub TxtAppDt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAppDt.TextChanged
        AppDate = DateTime.Parse(TxtAppDt.Text, Globalization.CultureInfo.CreateSpecificCulture("en-CA"))


        If AppDate < DateTime.Now.AddDays(-30).ToShortDateString() Or AppDate > DateTime.Now.ToShortDateString() Then
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, Me.[GetType](), "alertscript", "alert('Application Date should be in 30 days')", True)
            TxtAppDt.Text = ""
            SetFocus(TxtAppDt)
            Exit Sub
        End If

        AppDate = DateTime.Parse(TxtAppDt.Text, Globalization.CultureInfo.CreateSpecificCulture("en-CA"))

        Dim str As String
        str = ChecKdate(TxtAppDt.Text.Trim)
        If Not str = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "alertscript", "alert('" & str & "')", True)
            TxtAppDt.Text = ""
            SetFocus(TxtAppDt)
            Exit Sub
        End If

        ViewState.Add("AppDate", AppDate)
    End Sub

    Public Shared Function ChecKdate(ByVal strdt As String) As String
        Try
            Dim msg As String = ""
            Dim dt As New Date()

            Dim strdt1 As String()
            strdt1 = strdt.Split("-")
            dt = Date.ParseExact(strdt, "dd-MM-yyyy", Nothing)
            If strdt1.Length = 3 Then
                'If Convert.ToInt32(strdt1(1)) > 12 Then
                '    msg = "Please enter date in dd-mm-yyyy format"
                'End If
                If Convert.ToInt32(strdt1(2)) < 2014 Then
                    msg = "Date should be greater than or equal to 2nd June 2014"
                End If
                If Convert.ToInt32(strdt1(2)) = 2014 Then
                    Select Case Convert.ToInt32(strdt1(1))
                        Case "01", "02", "03", "04", "05"
                            msg = "Date should be greater than or equal to 2nd June 2014"
                        Case "06"
                            If Convert.ToInt32(strdt1(0)) < 2 Then
                                msg = "Date should be greater than or equal to 2nd June 2014"
                            End If
                    End Select

                End If
            Else
                msg = "Please enter date in dd-mm-yyyy format"
            End If
            Return msg
        Catch ex As Exception
            Return "Please enter date in dd-mm-yyyy format"
        End Try
    End Function

    Public Shared Sub SendSingleSMS(ByVal uname As [String], ByVal pwd As [String], ByVal sender As [String], ByVal mno As [String], ByVal msg As [String]) 'As String
        Dim request As HttpWebRequest
        Try
            request = DirectCast(WebRequest.Create("https://smsgw.sms.gov.in/failsafe/HttpLink?"), HttpWebRequest)
            request.ProtocolVersion = HttpVersion.Version10
            '((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            DirectCast(request, HttpWebRequest).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)"
            request.Method = "POST"

            Dim query As [String] = "username=" + HttpUtility.UrlEncode(uname) + "&pin=" + pwd + "&message=" + msg + "&mnumber=" + mno + "&signature=" + sender
            Dim byteArray As Byte() = Encoding.ASCII.GetBytes(query)
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length
            dataStream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As WebResponse = request.GetResponse()
            Dim Status As [String] = DirectCast(response, HttpWebResponse).StatusDescription
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            message = responseFromServer
            reader.Close()
            dataStream.Close()
            response.Close()
            'Return message
        Catch ex As Exception
            Errors.ErrorLog_Vat(ex)
            message = ex.InnerException.ToString()
            ' Return mes
        Finally

        End Try
    End Sub


    'Protected Sub grdChecklistsDocument_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdChecklistsDocument.RowCommand
    '    Dim rowIndex As Integer = Integer.Parse(e.CommandArgument.ToString())
    '    '  Dim lnkTIN As LinkButton = DirectCast(grdChecklistsDocument.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).FindControl("lnkTIN"), LinkButton)
    '    Dim row As GridViewRow = grdChecklistsDocument.Rows(rowIndex)
    '    Dim CheckListcode As String = row.Cells(0).Text

    '    Dim fileUpload As FileUpload = DirectCast(grdChecklistsDocument.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).FindControl("fuDocuments"), FileUpload)
    '    Dim uploadButton As Button = DirectCast(grdChecklistsDocument.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).FindControl("btnUpload"), Button)
    '    fileUpload.Visible = True
    '    uploadButton.Visible = True

    'End Sub

    'Protected Sub chkCheckListName_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Dim row As GridViewRow = DirectCast(DirectCast(sender, CheckBox).NamingContainer, GridViewRow)
    '    Dim index As Integer = row.RowIndex
    '    Dim cb1 As CheckBox = DirectCast(grdChecklistsDocument.Rows(index).FindControl("chkCheckListName"), CheckBox)
    '    Dim checklistCode As Label = DirectCast(grdChecklistsDocument.Rows(index).FindControl("lblchecklist_code"), Label)
    '    Dim fileUpload As FileUpload = DirectCast(grdChecklistsDocument.Rows(index).FindControl("fuDocuments"), FileUpload)
    '    Dim btnUpload As Button = DirectCast(grdChecklistsDocument.Rows(index).FindControl("btnUpload"), Button)
    '    If (cb1.Checked) Then
    '        fileUpload.Visible = True
    '        btnUpload.Visible = True
    '    Else
    '        fileUpload.Visible = False
    '        btnUpload.Visible = False

    '    End If

    'End Sub

    'Protected Sub grdChecklistsDocument_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdChecklistsDocument.RowCommand

    '    Try


    '        If e.CommandName = "Upload" Then

    '            Dim rowIndex As Integer = Integer.Parse(e.CommandArgument.ToString())

    '            Dim checklistCode As Label = DirectCast(grdChecklistsDocument.Rows(rowIndex).Cells(0).FindControl("lblchecklist_code"), Label)
    '            Dim checklistName As CheckBox = DirectCast(grdChecklistsDocument.Rows(rowIndex).Cells(1).FindControl("chkCheckListName"), CheckBox)
    '            Dim fileUpload As FileUpload = DirectCast(grdChecklistsDocument.Rows(rowIndex).FindControl("fuDocuments"), FileUpload)
    '            Dim BtnUpload As Button = DirectCast(grdChecklistsDocument.Rows(rowIndex).FindControl("btnUpload"), Button)

    '            If checklistName.Checked Then

    '                If fileUpload.HasFile AndAlso fileUpload.PostedFile.ContentLength > 0 Then

    '                    Dim fileExt As String = System.IO.Path.GetExtension(fileUpload.FileName)

    '                    If fileExt.ToLower() = ".jpeg" OrElse fileExt.ToLower() = ".jpg" OrElse fileExt.ToLower() = ".png" OrElse fileExt.ToLower() = ".pdf" Then

    '                        If fileUpload.PostedFile.ContentLength < "500000" Then

    '                            CreateDirectoryIfNotExists(LblRNR.Text)
    '                            Dim filename As String = fileUpload.FileName

    '                            Dim objResult As Object = regWS.CheckListFilesExists(LblRNR.Text, filename)

    '                            If objResult = "exists" Then
    '                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('This File Name Already Exists..Please try another files')", True)
    '                                Exit Sub
    '                            End If

    '                            fileUpload.PostedFile.SaveAs(Path.GetFullPath(Server.MapPath("Documents\VAT\")) + "\" + LblRNR.Text + "\" + filename.Trim())

    '                            checklistName.Checked = False
    '                            fileUpload.Visible = False
    '                            BtnUpload.Visible = False

    '                            Dim filepath As String = "\" + "VAT" + "\" + LblRNR.Text + "\" + filename.Trim()

    '                            Ds = regWS.SaveDocumentChecklist_Dealer(LblRNR.Text, checklistCode.Text, fileUpload.FileName, filepath, ddlUploadOption.SelectedValue)
    '                            If Ds IsNot Nothing Then
    '                                If Ds.Tables(0).Rows.Count > 0 Then
    '                                    grdDocumentList.DataSource = Ds.Tables(0)
    '                                    grdDocumentList.DataBind()
    '                                    Ds.Clear()
    '                                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Document uploaded successfully..')", True)
    '                                Else
    '                                    grdDocumentList.DataSource = Nothing
    '                                    grdDocumentList.DataBind()
    '                                End If
    '                            End If

    '                        Else
    '                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('file size should be below 500 KB')", True)
    '                            Exit Sub
    '                        End If

    '                    Else
    '                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Files are allow only PDF and Image(.jpg,.jpeg,.png)')", True)
    '                        Exit Sub
    '                    End If

    '                Else
    '                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('please select files')", True)
    '                    Exit Sub
    '                End If
    '            Else
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Please check Document Name')", True)
    '                Exit Sub
    '            End If

    '        End If
    '    Catch ex As Exception
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Oops something went wrong..')", True)
    '    End Try

    'End Sub

    Private Sub CreateDirectoryIfNotExists(ByVal NewDirectory As String)
        Try
            If Not Directory.Exists(Path.GetFullPath(Server.MapPath("Documents\VAT\")) + "\" + NewDirectory) Then

                Directory.CreateDirectory(Path.GetFullPath(Server.MapPath("Documents\VAT\")) + "\" + NewDirectory)
            Else

            End If
        Catch _err As IOException
        End Try


    End Sub

    'Protected Sub grdDocumentList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDocumentList.RowCommand

    '    If e.CommandName = "DocumentDelete" Then
    '        Dim rowIndex As Integer = Integer.Parse(e.CommandArgument.ToString())

    '        Dim lblchecklistCode As Label = DirectCast(grdDocumentList.Rows(rowIndex).Cells(0).FindControl("lblCheckListCode"), Label)
    '        Dim lbl_RNR As Label = DirectCast(grdDocumentList.Rows(rowIndex).Cells(1).FindControl("lblRNR"), Label)
    '        Dim lblFileName As Label = DirectCast(grdDocumentList.Rows(rowIndex).Cells(1).FindControl("lblFileName"), Label)

    '        Dim strPathFile As String = Path.GetFullPath(Server.MapPath("Documents\VAT\")) + lbl_RNR.Text + "\" + lblFileName.Text

    '        Dim Result As Integer = regWS.DeleteCheckListDocument(lbl_RNR.Text, lblchecklistCode.Text, lblFileName.Text)
    '        If Result > 0 Then

    '            If strPathFile IsNot Nothing OrElse strPathFile <> String.Empty Then
    '                If (File.Exists(strPathFile)) Then

    '                    File.Delete(strPathFile)

    '                End If
    '            End If

    '            BindCheckListsDocument(lbl_RNR.Text)
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('File Deleted Successfully...')", True)

    '        End If

    '    End If
    'End Sub

    'Protected Sub ddlUploadOption_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUploadOption.SelectedIndexChanged


    '    If ddlUploadOption.SelectedValue = "C" Then

    '        grdChecklistsDocument.Visible = False
    '        grdDocumentList.Visible = False
    '        chkDocuementCheckList.Visible = True

    '        ddlUploadOption.Items.FindByValue("O").Enabled = False


    '    ElseIf ddlUploadOption.SelectedValue = "O" Then


    '        grdChecklistsDocument.Visible = True
    '        grdDocumentList.Visible = True
    '        chkDocuementCheckList.Visible = False

    '        ddlUploadOption.Items.FindByValue("C").Enabled = False


    '    End If
    'End Sub

    Protected Sub TxtEMail_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEMail.TextChanged
        If Request.QueryString("Edit") = "Y" Then
        Else
            'Ds = regWS.GeteMailRegdDtls(Request.QueryString("emailid").ToString(), "")
            Ds = regWS.GeteMailRegdDtls(TxtEMail.Text, "")
            If (Ds.Tables("eMailCheck").Rows.Count > 0) Then
                '  Session("Msg") = "Record already entered for this e-Mail ID"

                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "alertscript", "Record already entered for this e-Mail ID')", True)
                Exit Sub
                ' Response.Redirect("../DlrEMail_Home.aspx")
            End If
        End If
    End Sub
End Class
