<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmViewAppl_groundwaterDepartmentuser_Transco.aspx.cs" Inherits="UI_TSiPASS_frmViewAppl_groundwaterDepartmentuser_Transco" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
        function OpenPopup()
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

            win = window.open("GroundwaterPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>
    <script type="text/javascript" language="javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
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
                    <li><i class="fa fa-dashboard"></i><a href="HomeDeptDashboard.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">Ground water</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">View Applications</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    <asp:Label ID="lbl_title" runat="server"></asp:Label>
                                </h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td align="right" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                    valign="top">
                                                    <asp:HyperLink ID="hyp_back" runat="server" Enabled="true" Text="Back" OnClientClick="JavaScript:window.history.back(1); return false;" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5" AllowPaging="false"
                                                        ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True"
                                                        Width="100%">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="100px" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="hf_gridquestionarieID" runat="server" Value='<%# Eval("intCFEEnterpid") %>' />
                                                                    <asp:HiddenField ID="hf_griddeptid" runat="server" Value='<%# Eval("intDeptid") %>' />
                                                                    <asp:HiddenField ID="hf_gridapprovalid" runat="server" Value='<%# Eval("intApprovalid") %>' />
                                                                    <asp:HiddenField ID="hf_griduidno" runat="server" Value='<%# Eval("UID_No") %>' />
                                                                    <asp:HiddenField ID="hf_gridstageid" runat="server" Value='<%# Eval("StageId") %>' />
                                                                    <asp:HiddenField ID="hf_gridLastDateofPreScrunity" runat="server" Value='<%# Eval("LastDateofPreScrunity") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Approval Name">
                                                                <ItemTemplate>
                                                                    <%# Eval("ApprovalName") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Application No">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnk_uid_no" runat="server" Text='<%# Eval("UID_No") %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Application Present Status">
                                                                <ItemTemplate>
                                                                    <%# Eval("ApplicationStatus") %>
                                                                    <asp:Label ID="lbl_rejetedstatusofapplication" ForeColor="Red" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="100px" HeaderText="View">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hyp_Applicationform" Target="_blank" runat="server" Text="Application form" ForeColor="Green"></asp:HyperLink>
                                                                    <br />
                                                                    <br />
                                                                    <asp:HyperLink ID="hyp_attachments" runat="server" Target="_blank" Text="Attachments" ForeColor="Blue"></asp:HyperLink>
                                                                    <br />
                                                                    <br />
                                                                    <asp:HyperLink ID="hyp_paymentdetails" runat="server" Target="_blank" Text="Payment Details" ForeColor="#6666ff"></asp:HyperLink>
                                                                    <br />
                                                                    <br />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="100px" HeaderText="Application Type">
                                                                <ItemTemplate>
                                                                    <%# Eval("ApplicationType_IndusorAgriName") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="100px" HeaderText="District">
                                                                <ItemTemplate>
                                                                    <%# Eval("District_Name") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="100px" HeaderText="Mandal">
                                                                <ItemTemplate>
                                                                    <%# Eval("Manda_lName") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="100px" HeaderText="Applicant Details">
                                                                <ItemTemplate>
                                                                    <b>Name:</b><%# Eval("ApplicantName") %>
                                                                    <br />
                                                                    <br />
                                                                    <b>Address:</b><%# Eval("AddressApplicant") %>
                                                                    <br />
                                                                    <br />
                                                                    <b>EmailID:</b><%# Eval("ApplicantEmailID") %>
                                                                    <br />
                                                                    <br />
                                                                    <b>Mobileno:</b><%# Eval("ApplicantMobileNO") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Action">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hyp_approveapplication" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="100px" HeaderText="Location Of Well">
                                                                <ItemTemplate>
                                                                    <%# Eval("LocationOfWell") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="100px" HeaderText="Mode of drawing water">
                                                                <ItemTemplate>
                                                                    <%# Eval("TypeOfDrwngWaterName") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="100px" HeaderText="Type of well to be dug">
                                                                <ItemTemplate>
                                                                    <%# Eval("TypeofWellName") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="100px" HeaderText="Speification of Pump(HP)">
                                                                <ItemTemplate>
                                                                    <%# Eval("SpecifactioncnOFPump") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="100px" HeaderText="Distance from existing functional well(in meters)">
                                                                <ItemTemplate>
                                                                    <%# Eval("DistanceFromExistWell") %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Approval_Fee" HeaderText="MRO Application Fee" />
                                                            <asp:BoundField DataField="PaymentDate" HeaderText="PaymentDate" />
                                                            <asp:BoundField DataField="Dateofsubmission" HeaderText="MRO Forward Date" />
                                                            <asp:BoundField DataField="LastDateofPreScrunity" HeaderText="LastDateofPreScrunity" />
                                                            <asp:TemplateField HeaderText="Query View">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hyp_userqueryrespose" Text="view Query" Target="_blank" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Query_RaiseDate" HeaderText="Query raised Date" />
                                                            <asp:BoundField DataField="QueryRespondDate" HeaderText="Query Responded Date" />
                                                            <asp:BoundField DataField="Approval_Date" HeaderText="Recommended Date  to MRO" />
                                                            <asp:BoundField DataField="Dept_Rejected_date" HeaderText="Rejected Date" />
                                                            <asp:BoundField DataField="MROApproveddate" HeaderText="MRO Approved date" />
                                                            <asp:BoundField DataField="MRORejecteddate" HeaderText="MRO Rejected date" />
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
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>

                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />

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



</asp:Content>

