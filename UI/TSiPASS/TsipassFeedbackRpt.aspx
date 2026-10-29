<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="TsipassFeedbackRpt.aspx.cs" Inherits="UI_TSiPASS_TsipassFeedbackRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }
    </script>

    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=A1.ClientID %>').style.display = "none";
            document.getElementById('<%=A2.ClientID %>').style.display = "none";
            <%--document.getElementById('<%=trFilter.ClientID %>').style.display = "none";--%>

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');

            printWindow.document.write('</head><body >');
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

    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            <asp:Label ID="lblHeading" runat="server">Feedback Report</asp:Label>
                            &nbsp;<a id="A1" href="#" onclick="javascript:return Panel1();"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="font-family: 'Trebuchet MS'">
                            <tr>
                                <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                                    <b>
                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"></asp:Label></b>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="6">
                                    <table width="100%">
                                        <tr runat="server" id="trBetweenDates" visible="true">
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
                                                <br />
                                                <%--<asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Generate Report" Width="180px" OnClick="btnGet_Click" />--%>
                                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10" Width="100px"
                                                    Text="Submit" OnClick="BtnSave1_Click" /> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                <asp:Button ID="btnclear" runat="server" CssClass="btn btn-default" TabIndex="10" Width="100px"
                                                    Text="Clear" OnClick="btnclear_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <%-- <b>Srcutiny Stage</b>--%>
                                </td>
                            </tr>
                            <tr id="div_Print" runat="server">
                                <td align="center" colspan="6" style="padding: 5px; margin: 5px">
                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnRowDataBound="grdDetails_RowDataBound" Width="100%" ShowFooter="True" OnRowCommand="grdDetails_RowCommand">
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />

                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Post Applications Count">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkPostAppln" runat="server" CommandArgument='<%#Eval("PostApplnCount")%>  ' Text='<%#Eval("PostApplnCount")%>  ' CommandName="PostAppln"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Post Certificate Count">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkPostCertificate" runat="server" CommandArgument='<%#Eval("PostApplnCertCount")%>  ' Text='<%#Eval("PostApplnCertCount")%>  ' CommandName="PostCertificate"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkTotal" runat="server" CommandArgument='<%#Eval("Totalcount")%>  ' Text='<%#Eval("Totalcount")%>  ' CommandName="Total"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4" style="padding: 5px; margin: 5px"></td>
                            </tr>
                            <tr>
                                <td align="left" colspan="4" style="padding: 5px; margin: 5px">
                                    <b>
                                        <asp:Label ID="lblgrdDetails2" runat="server" CssClass="LBLBLACK"></asp:Label></b>
                                </td>
                            </tr>
                            <tr id="div_Print2" runat="server">
                                <td align="center" style="text-align: center;" valign="top">
                                    <asp:GridView ID="grdDetails2" runat="server" AutoGenerateColumns="false" CellPadding="5"
                                        ShowFooter="True" Width="100%" RowDataBound="grdDetails2_RowDataBound" OnRowCommand="grdDetails2_RowCommand1">
                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UID_NO" HeaderText="UID NO" />
                                            <asp:BoundField DataField="NameofIndustrialUnder" HeaderText="Industry Name" />
                                            <asp:BoundField DataField="NameofthePromoter" HeaderText="Entreprneur Name" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" />
                                            <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                                            <asp:BoundField DataField="Created_dt" HeaderText="Submission date" />
                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnprocess" CssClass="btn btn-primary" OnClick="btnprocess_Click" runat="server" Text="View" Width="100px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CREATED_BY" HeaderText="Created by" Visible="false" />
                                            <asp:TemplateField HeaderText="Post Application Slno" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPOSTAPPLNSLNO" runat="server" Text='<%# Eval("POSTAPPLNSLNO") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">

                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Success!</strong><asp:Label ID="Label2" runat="server"></asp:Label>
                                    </div>


                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>

                            </tr>
                            <%-- <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>


