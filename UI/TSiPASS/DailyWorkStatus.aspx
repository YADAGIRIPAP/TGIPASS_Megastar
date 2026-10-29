<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DailyWorkStatus.aspx.cs" MasterPageFile="~/UI/TSiPASS/CCMaster.master" Inherits="UI_TSiPASS_DailyWorkStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <%--<script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>--%>
    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }
        .auto-style3 {
            width: 31px;
        }
        .auto-style5 {
            width: 127px;
        }
        .auto-style6 {
            width: 110px;
        }
        .auto-style7 {
            width: 278px;
        }
        </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupfrmClosedUnits.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    
    
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
               
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    DAILY WORK STATUS </h3>
                            </div>
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" 
                                                    colspan="3">
                                                    /</td>
                                            </tr>
                                           
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                
                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        
                                                    <tr>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                                1</td>
                                                            <td class="auto-style5">
                                                                <asp:Label ID="lblate" runat="server"></asp:Label> Date of Entry<font id="fn1" runat="server" 
                                                            color="red">*</font></td>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style6">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style7">
                                                                <asp:TextBox ID="txtdateofentry" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" Enabled="false" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                    <tr>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                                2&nbsp;</td>
                                                            <td class="auto-style5">
                                                                <asp:Label ID="Label1" runat="server"></asp:Label> Name of Employee<font id="Font1" runat="server" 
                                                            color="red">*</font></td>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style6">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style7">
                                                                <asp:TextBox ID="txtnameofemployee" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" Enabled="false" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                              
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style3">
                                                                3</td>
                                                            <td class="auto-style5">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Work Dones<font 
                                                            color="red" id="fn8" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style6">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style7">
                                                                <asp:TextBox ID="txtworkdone" runat="server" class="form-control txtbox" 
                                                                    Height="58px"  TabIndex="1" TextMode="MultiLine" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                             
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" Visible="false" 
                                                                    ControlToValidate="TxtAddressofUnit" 
                                                                    ErrorMesage="Please Enter Address of Unit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                             
                                                            </td>
                                                        </tr>
                                                       
                                                    </table>
                                                    
                                                </td>
                                               
                                            </tr>
                                            
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave_Click" TabIndex="10" Text="Save" Width="90px" 
                                                        ValidationGroup="group" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                                            &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                                            Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" 
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group1" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                        <asp:HiddenField ID="hdfpencode" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <br />
            <br />
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
    <%--</div>
       </td>
        </tr>
    </table>--%>
     <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='TxtDateofCloser']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                     maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback

            $("input[id$='TxtDateofCloserFirst']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
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
            $("input[id$='txtUdyogAadhaarRegdDate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
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
            $("input[id$='TxtDateofCloser']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='TxtDateofCloserFirst']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
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
</asp:Content>