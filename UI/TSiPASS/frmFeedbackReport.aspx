<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmFeedbackReport.aspx.cs" Inherits="UI_TSiPASS_frmFeedbackReport" %>

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
            color: #FF0000;
            font-weight: bold;
        }

        #mask {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 4;
            opacity: 0.4;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=40)"; /* first!*/
            filter: alpha(opacity=40); /* second!*/
            background-color: gray;
            display: none;
            width: 100%;
            height: 100%;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script src="Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function ShowPopup() {
            $('#mask').show();
            $('#<%=pnlpopup.ClientID %>').show();
        }
        function HidePopup() {
            $('#mask').hide();
            $('#<%=pnlpopup.ClientID %>').hide();
        }
        $(".btnClose").live('click', function () {
            HidePopup();
        });
    </script>
    <div id="mask">
    </div>
    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="250px"
        Width="500px" Style="z-index: 111; background-color: White; position: absolute; left: 35%; top: 12%; border: outset 2px gray; padding: 5px; display: none">
        <table width="100%" style="width: 100%; height: 100%;" cellpadding="0" cellspacing="5">
            <tr style="background-color: #0924BC">
           <%-- <tr>--%>
                <td colspan="2" style="color: White; font-weight: bold; font-size: 1.2em; padding: 3px"
                    align="center"><a id="closebtn" style="color: white; float: right; text-decoration: none" class="btnClose" href="#">X</a>
                    <asp:GridView ID="grdUdyogAadhaarAprovalsList" runat="server" AutoGenerateColumns="false" OnRowCommand="grdDetails_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="UIDNumber" HeaderText="UID NO"  />
                            <asp:BoundField DataField="ApprovalName" HeaderText="Approval Name" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnClose" CommandName="Close" runat="server" Text="Close" OnClick="btnClose_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>


    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("rptR1Print.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            document.getElementById('<%=btnGet.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=500,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');

            printWindow.document.write('</head><body style="width: 100%;text-align: center;">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function () {
                printWindow.print();
                location.reload(true);
                printWindow.close();
            }, 1000);
            return false;

        }
    </script>


    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="font-weight: bold">
                            <asp:Label ID="lblHeading" runat="server"></asp:Label>
                            &nbsp; <a id="Button2" href="#" onclick="javascript:return Panel1();"
                                runat="server" visible="false">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a>
                            <a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server" visible="false">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table id="divPrint" runat="server" border="0" cellpadding="10" cellspacing="5" style="width: 100%">
                            <%-- <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" class="style8"
                                                    align="center">
                                                    <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                        Height="33px" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged"
                                                        Width="180px" Visible="False">
                                                        <asp:ListItem>--District--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="padding: 5px; margin: 5px; text-align: right; vertical-align: top;"
                                                    valign="top">
                                                    <asp:ImageButton ID="Image4" Visible="false" runat="server" Height="40px" ImageUrl="~/images/pdf-icon4.jpg"
                                                        OnClientClick="window.print();return false" Width="40px" />
                                                    &nbsp;&nbsp; <a onclick="javascript:return OpenPopup()">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" ImageUrl="~/images/printimage.jpg"
                                                            Width="40px" /></a> &nbsp;
                                                </td>
                                            </tr>--%>
                            <tr>
                                <td>
                                    <div id="PrintPDF" runat="server">
                                        <table width="100%" style="font-family: 'Trebuchet MS'">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="left"></td>
                                                <td style="padding: 5px; margin: 5px; text-align: right;" valign="top">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="TR1" runat="server" visible="false">
                                                <td colspan="2">
                                                    <table width="80%">

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">From Date:   
                                                
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">To Date:  
                                            
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" align="left"></td>
                                                            <td style="padding: 5px; margin: 5px" align="left" colspan="3"></td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td style="padding: 5px; margin: 5px" colspan="4" align="center">
                                                                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" align="left"></td>
                                                            <td style="padding: 5px; margin: 5px" align="left" colspan="3"></td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="div_Print">
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                                <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="true" CellPadding="4"
                                                                    ShowFooter="True" Width="100%" OnRowCommand="grdDetails_RowCommand" OnRowDataBound="grdDetails_RowDataBound">
                                                                    <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                                    <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                                    <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="UID Number">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkUdyogAadhaarNo" runat="server" Text='<%# (Eval("UIDNumber") )%>' OnClick="lnkUdyogAadhaarNo_Click">'  ></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Button ID="btnback" Text="Back" runat="server" OnClick="btnback_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
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
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
