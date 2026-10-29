<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmDepartmentsApprovalProcessOtherServices.aspx.cs" Inherits="UI_TSiPASS_frmDepartmentsApprovalProcessOtherServices" %>

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
        .style7
        {
            width: 42px;
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

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
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
                    <li class="active"><i class="fa fa-edit"></i><a href="#"><asp:Label ID="lblHeaderlink" runat="server" ></asp:Label></a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title"><asp:Label ID="lblHeading" runat="server" ></asp:Label></h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">From Date</asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtFromDate"
                                                                    TargetControlID="txtFromDate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                2&nbsp;
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Width="150px">To Date</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtToDate" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="txtRegDate0_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                                    PopupButtonID="txtToDate" TargetControlID="txtToDate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="text-align: center;" align="center" colspan="3">
                                                                <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                    OnClick="BtnSave_Click" TabIndex="10" Text="Search" ValidationGroup="group" Width="90px" />
                                                                &nbsp;
                                                                <asp:Button ID="BtnCancel" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                                                    Width="90px" />
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="style8">
                                                </td>
                                                <td class="style9">
                                                </td>
                                                <td valign="top" class="style8">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False"
                                                        CellPadding="5" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound"
                                                        ShowFooter="True" Width="100%">
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
                                                            <asp:TemplateField HeaderText="UID Number">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                                                               </ItemTemplate>
                                                               <HeaderStyle HorizontalAlign="Left" />
                                                           
                                                           </asp:TemplateField>
                                                           
                                                            <asp:BoundField DataField="NameofIndustrialUnder" HeaderText="Name of Industry"></asp:BoundField>
                                                            <asp:BoundField DataField="LastDateofPreScrutiy" Visible="false" HeaderText="Last date of Prescrutiny" />
                                                            <%-- <asp:HyperLinkField HeaderText="Respond to Query"  DataNavigateUrlFields="Keyword,State,City"
                    DataNavigateUrlFormatString="KeywordSrchSumDtl.aspx?Keyword={0}&State={1}&City={2}"/>--%>
                                                            <asp:HyperLinkField HeaderText="Approval" Text="Approval" />
                                                             <asp:BoundField DataField="Dept_Name" HeaderText="Transfered From" />
                                                             <asp:BoundField DataField="Village_Name" HeaderText="Village" />
                                                             <asp:BoundField DataField="Manda_lName" HeaderText="Mandal" />
                                                             <asp:BoundField DataField="District_Name" HeaderText="District" />
                                                             <asp:BoundField DataField="DeptCompletedDate" HeaderText="Prescrutiny Completed Date" />
                                                             <asp:BoundField DataField="TargetApprovalDate" HeaderText="Target Approval Date" />
                                                             <asp:BoundField DataField="UPDATEDFLAG" HeaderText="Process" />
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
                                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                    &nbsp;<tr>
                                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        &nbsp;</caption>
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
</asp:Content>

