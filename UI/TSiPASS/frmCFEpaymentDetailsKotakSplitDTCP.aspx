<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmCFEpaymentDetailsKotakSplitDTCP.aspx.cs" Inherits="UI_TSiPASS_frmCFEpaymentDetailsKotakSplitDTCP" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <%--<script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>

    <script type="text/javascript">

        function pageLoad() {
            $('#<%=grdDetails.ClientID%>').gridviewScroll({
                width: "100%",
                height: "100%",
                arrowsize: 30,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png"
            });
        } 
           
    </script>--%>

    <style>
        .algnRight {
            text-align: right;
            padding-right: 5px;
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
        function Popup1(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>

    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("frmViewAttachmentDetailsDD.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>
    <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
    </style>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="upd1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnExel" />
        </Triggers>
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit"></i></li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">View Applications</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title" style="font-weight: bold;">
                                    <asp:Label ID="lblHeading" runat="server"></asp:Label></h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/frmR1ReportKMR.aspx"
                                                    Text="Back">
                                                </asp:HyperLink>--%>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 80%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label350" runat="server" CssClass="LBLBLACK" Width="165px">Department
                                                        Name</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control txtbox" Height="28px"
                                                            Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="lblSector0" runat="server" CssClass="LBLBLACK" Text="UID number" Width="110px"
                                                            Height="16px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtUidno" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="lblSector2" runat="server" CssClass="LBLBLACK" Height="16px" Text="District"
                                                            Width="110px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddldistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="lblSector3" runat="server" CssClass="LBLBLACK" Height="16px" Text="Payment Type"
                                                            Width="110px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlpaymentType" runat="server"
                                                            class="form-control txtbox" Height="28px" TabIndex="1" Width="180px"
                                                            AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlpaymentType_SelectedIndexChanged">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="O" Selected="True">Online</asp:ListItem>
                                                            <asp:ListItem Value="D">Demand Draft</asp:ListItem>
                                                            <asp:ListItem Value="S">SBH Challan</asp:ListItem>
                                                            <asp:ListItem Value="R">RTGSpayment</asp:ListItem>
                                                            <asp:ListItem Value="A">All</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                                    runat="server" ControlToValidate="ddlpaymentType"
                                                                    ErrorMessage="Please Select Payment Type"
                                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trdate" runat="server" visible="false">
                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="lblSector4" runat="server" CssClass="LBLBLACK" Height="16px" Text="From Date"
                                                            Width="110px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtfromDate" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtfromDate"
                                                            TargetControlID="txtfromDate">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="lblSector5" runat="server" CssClass="LBLBLACK" Height="16px" Text="To Date"
                                                            Width="110px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txttoDate" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="txtRegDate0_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                            PopupButtonID="txttoDate" TargetControlID="txttoDate">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                    </td>
                                                </tr>

                                                <tr runat="server" id="trBank" visible="false">
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="lblSector6" runat="server" CssClass="LBLBLACK" Height="16px"
                                                            Text="Bank" Width="110px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td style="padding: 5px; margin: 5px" colspan="3">
                                                        <asp:DropDownList ID="ddlBank" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="SBI">SBI</asp:ListItem>
                                                            <asp:ListItem Value="ICICI">ICICI</asp:ListItem>
                                                            <asp:ListItem Value="BILL">BillDesk</asp:ListItem>
                                                            <asp:ListItem Value="Kotak" Selected="True">Kotak</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="lblSector1" runat="server" CssClass="LBLBLACK" Height="16px" Text="Name of Unit"
                                                            Width="110px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" colspan="3">
                                                        <asp:TextBox ID="txtNameOfUnit" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="300" TabIndex="1" ValidationGroup="group" Width="280px"></asp:TextBox>
                                                    </td>
                                                     <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="lblSector8" runat="server" CssClass="LBLBLACK" Height="16px" Text="Module" Width="80px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:</td>
                                                    <td style="padding: 5px; margin: 5px"><asp:DropDownList ID="ddlmodule" runat="server" class="form-control txtbox" Height="28px" TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="CFE">CFE</asp:ListItem>
                                                            <asp:ListItem Value="CFO">CFO</asp:ListItem>
                                                            <asp:ListItem Value="REN">RENEWAL</asp:ListItem>
                                                            <asp:ListItem Value="PLOT">PLOT ALLOTMENT</asp:ListItem>   
                                                             <asp:ListItem Value="TTA">TRAVEL AGENCY</asp:ListItem>   
                                                              <asp:ListItem Value="TE">TOURISM EVENT</asp:ListItem>                                                          
                                                        </asp:DropDownList></td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 27px">&nbsp;
                                        </td>
                                        <td valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                ForeColor="#006600"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                TabIndex="10" Text="Search" Width="90px" OnClick="BtnSave1_Click"
                                                ValidationGroup="group" />
                                            &nbsp;
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                        Width="90px" />
                                            &nbsp;
                                    <asp:Button ID="BtnExel" runat="server" CssClass="btn btn-primary" Height="32px"
                                        TabIndex="10" Text="Excel" Width="90px" OnClick="BtnExel_Click" />
                                        </td>
                                    </tr>
                                    <div id="div_print">
                                    </div>
                                    <tr>
                                        <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                                ShowFooter="True" Width="100%" OnRowDataBound="grdDetails_RowDataBound"
                                                OnPageIndexChanging="grdDetails_PageIndexChanging" AllowPaging="false" PageSize="20"
                                                OnSelectedIndexChanged="grdDetails_SelectedIndexChanged"
                                                OnSelectedIndexChanging="grdDetails_SelectedIndexChanging">
                                                <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Header" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                            <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                            <asp:HiddenField ID="OnlineOrdernumber" runat="server" />
                                                            <asp:HiddenField ID="intCFEEnterpid" runat="server" />
                                                            <asp:HiddenField ID="AdditionalFlag" runat="server" />
                                                            <asp:HiddenField ID="HdfAmount" runat="server" />
                                                             <asp:HiddenField ID="hdfuidno" runat="server" />
                                                             <asp:HiddenField ID="ACCOUNTNO" runat="server" />
                                                            <asp:HiddenField ID="IFSCCODE" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pay for Department">
                                                    <HeaderTemplate>
                                                            <asp:CheckBox ID="chkAll" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="true"
                                                                runat="server" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkApproval" runat="server"  AutoPostBack="True" OnCheckedChanged="ChkApproval_CheckedChanged" />
                                                            <asp:HiddenField ID="Approval_Fee" runat="server" OnValueChanged="HdfAmount_ValueChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("UID") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Download">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("CFEID") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <asp:Label ID="lbltotal" runat="server" Text="Total Amount"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <asp:Button ID="btntransfer" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Transfer Amount" ValidationGroup="group" Width="150px" OnClick="btntransfer_Click" />                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
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
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

