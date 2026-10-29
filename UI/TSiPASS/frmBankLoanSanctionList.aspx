<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmBankLoanSanctionList.aspx.cs" MasterPageFile="~/UI/TSiPASS/BankSanctionList.master" Inherits="UI_TSiPASS_frmBankLoanSanctionList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function chkRegNoLastLetters() {
            var reg = /^\d[0-9]*$/;
            var tlength = document.getElementById("<%=txtregistrationno.ClientID%>");
            var msg = document.getElementById("<%=lblmsg0.ClientID%>")
            var s = String(tlength.value);
            var st = s.substring(s.length, s.length - 4)
            if (!reg.test(st)) {

                //alert("Last 4 Letters must contain only Numbers !\nFormat must be AP09BQ1234");
                tlength.focus();
                return false;
            }
            else
                return true;
        }
    </script>

    <%--blink--%>
    <style type="text/css">
<!--
/* @group Blink */
.blink {
	-webkit-animation: blink .75s linear infinite;
	-moz-animation: blink .75s linear infinite;
	-ms-animation: blink .75s linear infinite;
	-o-animation: blink .75s linear infinite;
	 animation: blink .75s linear infinite;
}
@-webkit-keyframes blink {
	0% { opacity: 1; }
	50% { opacity: 1; }
	50.01% { opacity: 0; }
	100% { opacity: 0; }
}
@-moz-keyframes blink {
	0% { opacity: 1; }
	50% { opacity: 1; }
	50.01% { opacity: 0; }
	100% { opacity: 0; }
}
@-ms-keyframes blink {
	0% { opacity: 1; }
	50% { opacity: 1; }
	50.01% { opacity: 0; }
	100% { opacity: 0; }
}
@-o-keyframes blink {
	0% { opacity: 1; }
	50% { opacity: 1; }
	50.01% { opacity: 0; }
	100% { opacity: 0; }
}
@keyframes blink {
	0% { opacity: 1; }
	50% { opacity: 1; }
	50.01% { opacity: 0; }
	100% { opacity: 0; }
}
/* @end */
-->
</style>
   <%-- blink--%>

    <asp:UpdatePanel ID="upd1" runat="server">
         <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave3" />
            <%--<asp:PostBackTrigger ControlID="btnUpload2" />--%>
        </Triggers>
        <ContentTemplate>

            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="frmBankLoanSanctionList.aspx">ADMIN</a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-table"></i>
                    </li>

                </ol>
            </div>
            <%--<div class="alert alert-warning fade in" id="warning" runat="server" visible="false">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Warning!</strong> <asp:Label ID="lbluserid0" runat="server" 
        CssClass="" ></asp:Label>
    &nbsp;
  </div>--%>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title"><p class="tab blink" style="color:white">Bridge Loan Application.....</p>
                                    <h3></h3>
                                    <h3></h3>
</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">
                                <tr>
                                        <td  colspan="6" style="padding: 5px;font-weight:bold; text-align:left; margin: 5px">
                                            <asp:Label ID="lblReleaseError" ForeColor="Red" Visible="false" runat="server" Text="Application is not in sanction stage."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="middle" width="30%" runat="server" visible="false">Type of Sector</td>
                                        <td>
                                            <asp:DropDownList ID="rblSector" runat="server" RepeatDirection="Horizontal" Visible="false"
                                                class="form-control txtbox" AutoPostBack="true" TabIndex="1" Height="33px" Width="180px">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Service</asp:ListItem>
                                                <asp:ListItem Value="2">Manufacture</asp:ListItem>
                                                <%--<asp:ListItem Value="3">Textiles</asp:ListItem>--%>
                                            </asp:DropDownList></td>
                                        <td align="left" valign="middle" width="30%">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr id="trvehicleno" runat="server" visible="false">
                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">Vehicle Number
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtregistrationno" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="10" TabIndex="4" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator92" runat="server" ControlToValidate="txtregistrationno"
                                                ErrorMessage="Please Enter Vehicle Number" SetFocusOnError="true" ValidationGroup="group"
                                                Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr id="trdistrict" runat="server" visible="true">
                                        <td align="center" valign="middle" width="30%">District : 
                                        </td>
                                        <td style="padding: 5px; margin:5px; width:192px;">
                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged" Width="180px">
                                                <asp:ListItem>--District--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProp_intDistrictid" ErrorMessage="Please Select Proposed Location (District)" InitialValue="--District--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                       
                                        <td align="left" valign="middle" width="30%">Mandal :
                                        </td>
                                        <td style="padding: 5px; margin:5px; width:192px;">
                                            <asp:DropDownList ID="ddlProp_intMandalid" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px">
                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlProp_intMandalid" ErrorMessage="Please Select Proposed Location (Mandal)" InitialValue="--Mandal--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                         
                                    </tr>

                                  
                                    
                                    <tr id="trlineofactivity" runat="server" visible="true">
                                       
                                        

                                         <td align="center" valign="middle" width="30%">Name of Unit :
                                        </td>
                                        <td style="padding: 5px; margin:5px; width:192px;">
                                            <asp:TextBox ID="txtnameofunit" autocomplete="off" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="500" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtnameofunit" ErrorMessage="Please Enter Name of Unit Details" InitialValue="" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                       
                                        </td>
                                         <td align="center" valign="middle" width="30%"> 
                                        </td>
                                        <td style="padding: 5px; margin:5px; width:192px;">
                                            <asp:DropDownList ID="ddlintLineofActivity" runat="server" AutoPostBack="True" Visible="false" class="custom-select" Height="33px" Width="300px">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlintLineofActivity"
                                                ErrorMessage="Please Select Line of Activity" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td align="center" valign="middle" width="30%">&nbsp;</td>
                                        <td align="left" valign="middle" width="30%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4"
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnnext" runat="server" CssClass="btn btn-primary"
                                                Height="32px" TabIndex="2" Text="Next"
                                                ValidationGroup="group" Width="90px" OnClick="btnnext_Click" Enabled="true" Visible="false" />&nbsp;&nbsp;&nbsp;

                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                                Height="32px" TabIndex="2" Text="Search"
                                                ValidationGroup="group" Width="90px" OnClick="BtnSave1_Click" Enabled="true" Visible="true" />&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                        </td>
                                        
                                    </tr>
                                    <caption>
                                        <br />
                                        <br />
                                        <tr>
                                            <td align="left" colspan="6" style="padding: 5px; margin: 5px" valign="top">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="5" ForeColor="#333333" Height="62px" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" Width="100%">
                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Application No" HeaderText="ApplicationNo" Visible="false" />
                                                        <asp:BoundField DataField="UnitName" HeaderText="Name of the Unit" />
                                                         <asp:BoundField DataField="UNITADDRESS" HeaderText="Unit Address" />
                                                        <asp:BoundField DataField="Incentive" HeaderText="Incentive" />
                                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                                        <asp:BoundField DataField="Application Filed Date" HeaderText="ApplicationFiledDate" Visible="false" />
                                                        <asp:BoundField DataField="IncentiveTypeID" HeaderText="IncentiveTypeID" Visible="false" />
                                                         <asp:BoundField DataField="SanctionAmount" HeaderText="Sanctioned Amount" Visible="true" />
                                                            <asp:BoundField DataField="sanctionDate" HeaderText="Sanctioned Date" Visible="true"/>
                                                           
                                                        <%--<asp:BoundField DataField="IncentiveID" HeaderText="IncentiveID" Visible="false" />--%>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncid" runat="server" Text='<%# Eval("IncentiveID") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="IncentiveTypeID" runat="server" Text='<%# Eval("IncentiveTypeID") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Click for Apply">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkApproval" runat="server" OnCheckedChanged="ChkApproval_CheckedChanged" AutoPostBack="true" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </caption>

                                     
                                 
                                </table>
                                <br />
                                <br />
                                <table runat="server" id="tablLoanDetails" visible="false">
                                       <tr>
                                        <td style="padding:5px;margin:5px" align="center" valign="middle" width="192px">Bridge Loan Amount : 
                                        </td>
                                        <td style="padding: 5px; margin:5px; width:192px;">
                                            
                                            <asp:TextBox ID="txtBridgeLoanAmt" runat="server" autocomplete="off" class="form-control txtbox" Height="28px"
                                                MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        

                                           <td style="padding: 5px; margin:5px; width:192px;">
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator94" runat="server" ControlToValidate="txtBridgeLoanAmt" ErrorMessage="Please Enter Loan Amount" InitialValue="" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                           </td>
                                        

                                        <td  style="padding:5px" valign="middle" align="center" width="192px">Bridge Sanction Date:
                                        </td>
                                        <td align="left" style="padding: 5px; margin:5px;  width:192px;">
                                            <asp:TextBox ID="txtBridgeLoanDate" runat="server" autocomplete="off" class="form-control txtbox" Height="28px" MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                       </td>
                                           <td align="left" style="padding: 5px; margin:5px;  width:192px;">
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBridgeLoanDate" ErrorMessage="Please Enter the Loan Date Details" InitialValue="" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                           </td>
                                    </tr>
                                  

                                    <tr runat="server" visible="false">
                                        <td align="center" valign="middle" width="30%">Bridge Account No : </td>
                                        <td style="padding: 5px; margin:5px;  width:192px;">
                                            <asp:TextBox ID="txtBridgeAccNo" runat="server" autocomplete="off" class="form-control txtbox" Height="28px" MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                       
                                        </td>
                                        
                                        <td style="padding: 5px; margin:5px;  width:192px;">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator95" runat="server" ControlToValidate="txtBridgeAccNo" ErrorMessage="Please Enter the Loan Account Number Details" InitialValue="" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        
                                        <td align="left" valign="middle" style="padding: 5px; margin:5px;  width:192px;" >BridgeLoanNo: </td>
                                        <td align="center" style="padding: 5px; margin:5px;  width:192px;">
                                            
                                       <asp:TextBox ID="txtBridgeLoanNo" runat="server" autocomplete="off" class="form-control txtbox" Height="28px"
                                                MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            
                                       </td>
                                        <td align="center" style="padding: 5px; margin:5px;  width:192px;">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator96" runat="server" ControlToValidate="txtBridgeLoanNo" ErrorMessage="Please Enter Loan No" InitialValue="" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="center" valign="middle" width="30%">Bridge Loan Sanction Document : </td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" class="form-control txtbox"
                                                        Height="33px" />
                                                     <asp:Label ID="Label444" Font-Bold="true" ForeColor="DarkBlue" Font-Size="Smaller" runat="server" Visible="False" CssClass="LBLBLACK"></asp:Label>
                                                    <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Target="_blank" Visible="false"></asp:HyperLink>
                                                    <br />
                                                   
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" OnClick="BtnSave3_Click" Width="72px"  />
                                                </td>
                                    </tr>

                                    <tr>
                                        <td valign="top" colspan="5">
                                            <asp:CheckBox ID="chkverifyallDoc0" AutoPostBack="true" runat="server" OnCheckedChanged="chkverifyallDoc0_CheckedChanged" />
                                             <b style="color:red">I here by certify that the above loan amount has been disbursed to the beneficiary.Hence I request incentives payable to be paid to TIHCL by the Office COI</b>
                                             
                                        </td>
                                        <td valign="top">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="5" style="padding: 5px; margin: 5px"></td>
                                        <td align="center" style="padding: 5px; margin: 5px">&nbsp;</td>
                                    </tr>

                                      <tr>
                                        <td align="center" colspan="5"
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary"
                                                Height="32px" TabIndex="2" Text="Next"
                                                ValidationGroup="group" Width="90px" Enabled="true" Visible="false" />&nbsp;&nbsp;&nbsp;

                                 <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary"
                                                Height="32px" TabIndex="2" Text="Submit" OnClick="btnSubmit_Click"
                                                ValidationGroup="group" Width="90px" Enabled="false" Visible="true" />&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="Button3" runat="server" CausesValidation="False"
                                                CssClass="btn btn-warning" Height="32px" TabIndex="10" Visible="true"
                                                Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" OnClick="Button3_Click" />
                                        </td>
                                          <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                                <td align="center" colspan="5" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td align="center" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>




            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

            <br />


        </ContentTemplate>
    </asp:UpdatePanel>

    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtDateofCommencement']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback

            $("input[id$='txtNewPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExistingPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExpanDiverPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback  

            $("input[id$='txttermload']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback  

            $("input[id$='txtdatesome']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback  

            $("input[id$='txtCSTRegDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            //added newly
            $("input[id$='txtBridgeLoanDate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                  maxDate: new Date(currentYear, currentMonth, currentDate)
             }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtGSTDate']").datepicker(
           {
               dateFormat: "dd/mm/yy",
               //  maxDate: new Date(currentYear, currentMonth, currentDate)
           }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtdateofreg']").datepicker(
            {
                dateFormat: "dd/mm/yy",
                //  maxDate: new Date(currentYear, currentMonth, currentDate)
            }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtTermLoanReleasedDate']").datepicker(
           {
               dateFormat: "dd/mm/yy",
               //  maxDate: new Date(currentYear, currentMonth, currentDate)
           }); // Will run at every postback/AsyncPostback  

        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtDateofCommencement']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtNewPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback   

            $("input[id$='txtExistingPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExpanDiverPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txttermload']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txtdatesome']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtCSTRegDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback 
            //added newly
            $("input[id$='txtGSTDate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtdateofreg']").datepicker(
            {
                dateFormat: "dd/mm/yy",
                //  maxDate: new Date(currentYear, currentMonth, currentDate)
            }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtTermLoanReleasedDate']").datepicker(
           {
               dateFormat: "dd/mm/yy",
               //  maxDate: new Date(currentYear, currentMonth, currentDate)
           }); // Will run at every postback/AsyncPostback  

        });
    </script>
    <style type="text/css">
        .ui at k r font- 8pt; i or eight: 250px; d n 0.2 em 0 dth; 2 px; .auto-style8 {
            height: 29px;
        }

        </style>
</asp:Content>