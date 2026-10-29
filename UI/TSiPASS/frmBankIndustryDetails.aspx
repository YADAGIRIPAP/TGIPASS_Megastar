<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmBankIndustryDetails.aspx.cs" Inherits="UI_TSiPASS_frmBankIndustryDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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
        
        .style8
        {
            height: 30px;
        }
        
        .style9
        {
            width: 27px;
            height: 30px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <%--<script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <script type="text/javascript">
        function RejectValidate() {
            return confirm('Do you want to reject the record ?');
        }

        function RejectValidate1() {
            return alert('Please enter the Remarks');
        }
        function RejectValidate2() {
            return alert('Record Deleted Sucessfully');
        }
    </script>
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">View Applications</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    View Applications</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                           <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" class="auto-style3">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%; margin-top: 0px;" runat="server" visible="false">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" class="auto-style1">
                                                        <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="165px">Month</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlmonth" runat="server" class="form-control txtbox" TabIndex="3"
                                                            Height="33px" Width="180px" AutoPostBack="True" 
                                                            >
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">January</asp:ListItem>
                                                            <asp:ListItem Value="2">February</asp:ListItem>
                                                            <asp:ListItem Value="3">March</asp:ListItem>
                                                            <asp:ListItem Value="4">April</asp:ListItem>
                                                            <asp:ListItem Value="5">May</asp:ListItem>
                                                            <asp:ListItem Value="6">June</asp:ListItem>
                                                            <asp:ListItem Value="7">July</asp:ListItem>
                                                            <asp:ListItem Value="8">August</asp:ListItem>
                                                            <asp:ListItem Value="9">September</asp:ListItem>
                                                            <asp:ListItem Value="10">October</asp:ListItem>
                                                            <asp:ListItem Value="11">November</asp:ListItem>
                                                            <asp:ListItem Value="12">December</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" class="style7">
                                                        &nbsp;
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                            ControlToValidate="ddlmonth" ErrorMessage="Please select Month" 
                                                            InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                                <td valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%; margin-top: 0px;" runat="server" visible="false">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label365" runat="server" CssClass="LBLBLACK" Width="113px">Year</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" Height="33px"
                                                             TabIndex="4" 
                                                            Width="180px" AutoPostBack="True">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                            ControlToValidate="ddlYear" ErrorMessage="Please select Year" 
                                                            InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5" 
                                                        ForeColor="#333333" Height="62px" ShowFooter="True" 
                                                        Width="100%" >
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>--%>
                                                             <asp:BoundField DataField="SNO" HeaderText="SNO" />
                                                            <%--<asp:TemplateField HeaderText="View">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("UID_No") %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>--%>
                                                            <asp:BoundField DataField="NAME_OF_THE_UNIT" HeaderText="Name Of The Unit" />
                                                            <asp:BoundField DataField="LINE_OF_ACTIVITY" HeaderText="Line of Activity" />
                                                            <asp:BoundField DataField="DISTRICT_ID" HeaderText="District Id" />
                                                            <asp:BoundField DataField="MANDAL_ID" HeaderText="Mandal Id" />
                                                            <asp:BoundField DataField="CONTACT_NO" HeaderText="Contact No" />
                                                            <asp:BoundField DataField="EMAIL_ID" HeaderText="Email Id" />
                                                            <asp:BoundField DataField="TYPE" HeaderText="Type" />
                                                            <asp:BoundField DataField="DATE" HeaderText="Date" />
                                                            <asp:BoundField DataField="CREATED_BY" HeaderText="Created By" />
                                                            <asp:BoundField DataField="CREATED_DT" HeaderText="Created Dt" />
                                                            <asp:BoundField DataField="IS_ACTIVE" HeaderText=" Is Active" />
                                                            <asp:BoundField DataField="STATUS" HeaderText=" Status" />
                                                            <asp:TemplateField HeaderText="Submit">
                                                                <ItemTemplate>
                                                                     <asp:HiddenField ID="hdfRemarks" runat="server" />
                                                                    <asp:Button ID="BtnSave" runat="server" CausesValidation="False" CssClass="btn-success" OnClick="BtnSave_Click"
                                                                        Height="32px"  
                                                                        TabIndex="10" Text="Approve" ValidationGroup="group" Width="100px"  />
                                                                    <asp:HiddenField ID="hdfApplID" runat="server" />
                                                                    <asp:HiddenField ID="hdfGroundedNo" runat="server" />
                                                                    <asp:HiddenField ID="hdfGroundedNo0" runat="server" />
                                                                    <asp:HiddenField ID="hdfGroundedNo1" runat="server" />
                                                                    <asp:HiddenField ID="hdfGroundedNo2" runat="server" />
                                                                    <asp:HiddenField ID="hdfGroundedNo3" runat="server" />
                                                                    <br />
                                                                    <br />
                                                                    <asp:Button ID="BtnReject" runat="server" OnClick="BtnReject_Click" CausesValidation="False" CssClass="btn-danger"
                                                                        Height="32px"  TabIndex="11" Text="Reject" ValidationGroup="group"
                                                                        Width="100px"  />
                                                                    <br />
                                                                    <br />
                                                                    <asp:TextBox runat="server" class="form-control txtbox" Height="50px" Width="180px"
                                                                        AutoComplete="false" ID="TxtReject" placeholder="Remarks" TextMode="MultiLine" />
                                                                    <br />
                                                                    <br />
                                                                </ItemTemplate>
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
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    &nbsp;<tr>
                                                        <td align="center" style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                            ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <%--<asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <%--<div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
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
</asp:Content>
