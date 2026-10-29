<%@ Page Language="C#"  MasterPageFile="~/UI/TSiPASS/CCMaster.master"  AutoEventWireup="true" CodeFile="frmRollbacktoReleasependingstage32_DIPC.aspx.cs" Inherits="UI_TSiPASS_frmRollbacktoReleasependingstage32_DIPC" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .overlay {
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

        .style8 {
            height: 30px;
        }

        .style9 {
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
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
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
                <div class="row" align="left">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                           <tr >
                                                                    <td style="padding: 5px; margin: 5px; font-weight: bold" valign="top">
                                                                        <table style="width: 100%">
                                                                            <tr>
                                                                                <td style="width: 20%">District
                                                                                </td>
                                                                                <td style="width: 30%">
                                                                                    <asp:DropDownList ID="ddlDist" runat="server" class="form-control txtbox" Height="33px"
                                                                                        Width="180px">
                                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 20%">SANCTIONEDAMOUNT
                                                                                </td>
                                                                                <td style="width: 30%">
                                                                                   <asp:TextBox ID="TXTSANXTIONEDAMOUNT" runat="server"  Height="33px"  Width="180px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px">&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Unit Name
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtUnitName" runat="server" class="form-control txtbox"  Height="33px" 
                                                                                        MaxLength="350" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 20%">Incentive Name 
                                                                                </td>
                                                                                <td style="width: 100%">
                                                                                    <asp:DropDownList ID="ddlincentivename" runat="server" Height="33px" Width="180px">
                                                                                         <asp:ListItem>--Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 10px">&nbsp; Caste
                                                                                </td>
                                                                                <td>&nbsp; <asp:DropDownList ID="ddlcaste" runat="server" Height="33px" Width="180px">
                                                                                         <asp:ListItem>--Select--</asp:ListItem>
                                                                                         <asp:ListItem>SC</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                                <td>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" style="text-align: center">
                                                                                    <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10"
                                                                                        Text="GET Details" Width="200px" ValidationGroup="group" OnClick="btnGet_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                                        ForeColor="#333333" Height="62px" ShowFooter="True"
                                                        Width="100%">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            
                                                            <asp:BoundField DataField="NameofUnit" HeaderText="Unit Name" />
                                                            <asp:BoundField DataField="Address" HeaderText="Address"/>
                                                            <asp:BoundField DataField="DCP" HeaderText="DCP Date" />
                                                            <asp:BoundField DataField="IncentiveName" HeaderText="Incentive Name" />
                                                            <asp:BoundField DataField="SanctionedAmount" HeaderText="Sanctioned Amount" />
                                                            <asp:BoundField DataField="SanctionedDate" HeaderText="Sanctioned Date" />
                                                            <asp:BoundField DataField="MstIncentiveId" HeaderText="Sub Incentive ID" />
                                                            <asp:BoundField DataField="EnterperIncentiveID" HeaderText="Incentive ID" />
                                                            <asp:BoundField DataField="DIPCNumBer" HeaderText="DIPC Number" />
                                                            <asp:BoundField DataField="Applicationno" HeaderText="Application Number" />
                                                            <asp:BoundField DataField="DIPCDate" HeaderText="DIPC Date" />
                                                           
                                                            <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                                                            <asp:BoundField DataField="District" HeaderText="District" />
                                                            <asp:BoundField DataField="WORKINGSTATUS" HeaderText="Working Status" />
                                                            <asp:BoundField DataField="WorkStatusUptDate" HeaderText="Working Status Updated Date" />
                                                            <asp:BoundField DataField="BankAccountRemarks" HeaderText="Bank Account Remarks" />
                                                            <asp:TemplateField HeaderText="Process">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnrollback" runat="server" CausesValidation="False" CssClass="btn-success"
                                                                        Height="32px" OnClick="btnrollback_Click" OnClientClick="return confirm('Do you want to Rollback the record ? ');"
                                                                        TabIndex="10" Text="Rollback" ValidationGroup="group" Width="100px" />
                                                                 
                                                                   
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
                                                <td style="padding: 5px; margin: 5px" align="center">&nbsp;<tr>
                                                    <td align="center" style="padding: 5px; margin: 5px">&nbsp;
                                                    </td>
                                                </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
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
</asp:Content>
