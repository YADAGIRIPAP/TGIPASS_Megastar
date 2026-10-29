<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    CodeFile="ViewPattadarAppliactions.aspx.cs" Inherits="UI_TSiPASS_ViewPattadarAppliactions" %>

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
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>
    <script type="text/javascript" language="javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            //            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
            //                return true;
            //            }
            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 46 && charCode != 47) {
                return true;
            }
            return false;
        }
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <%--<li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>--%>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">View Applications</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
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
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                                        ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True"
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
                                                            <%--ID	PATTADARID	DEPTID	APPROVALID	APPLICATIONSTATUS	STAGEID	PANcardno	AadharNo	Email	GST	MOBILENO	PATTADARNAME	SODOWO	DHARANINUMBER	MINERALNAME	EXTENTINHECTARE	SURVEYNO	DISTRICT	MANDAL	VILLAGE	CREATED_DT	CREATED_BY	MODIFIED_DT	MODIFIED_BY	UIDNO	DistrictName	MandalName	VillageName--%>
                                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                                            <asp:BoundField DataField="PATTADARID" HeaderText="Pattadar Application ID" />
                                                            <asp:BoundField DataField="PATTADARNAME" HeaderText="Pattadar Name" />
                                                            <asp:BoundField DataField="DHARANINUMBER" HeaderText="Pattadar Passbook No." />
                                                            <asp:BoundField DataField="MINERALNAME" HeaderText="Mineral Name" />
                                                            <asp:BoundField DataField="EXTENTINHECTARE" HeaderText="Total Extent in Hectare" />
                                                            <asp:BoundField DataField="DistrictName" HeaderText="District" />
                                                            <asp:BoundField DataField="MandalName" HeaderText="Mandal" />
                                                            <asp:BoundField DataField="VillageName" HeaderText="Village" />
                                                            <asp:BoundField DataField="SURVEYNO" HeaderText="Survey No" />
                                                            <asp:BoundField DataField="PartExtent" HeaderText="Extent per Survey No." />
                                                            <asp:BoundField DataField="PANcardno" HeaderText="PAN card No." />
                                                            <asp:BoundField DataField="AadharNo" HeaderText="Aadhar No." />
                                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                                            <%--<asp:BoundField DataField="GST" HeaderText="GST No." />--%>
                                                            <asp:BoundField DataField="MOBILENO" HeaderText="Mobile No." />
                                                            <asp:HyperLinkField HeaderText="Pattadar Application" Text="View" />
                                                            <asp:HyperLinkField HeaderText="Attachments" Text="Attachments" />
                                                            <asp:BoundField DataField="rejected_reason" HeaderText="Rejected Reason" />
                                                            <asp:BoundField DataField="ApprovalCompleteFlg" HeaderText="Status" />
                                                            <%--<asp:BoundField DataField="rejected_reason" HeaderText="Rejected Reason"  />
                                                             <asp:HyperLinkField HeaderText="Approved DGPS/NOC" Text="Signed DGPS" />
                                                             <asp:BoundField DataField="ApprovalCompleteFlg" HeaderText="Status" />--%>
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
