<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" EnableEventValidation="false"  AutoEventWireup="true" CodeFile="RptBeyondapps.aspx.cs" Inherits="UI_TSIPASS_RptBeyondapps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function Panel1() {

            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
              document.getElementById('<%=tblselection.ClientID %>').style.display = "none";

              var panel = document.getElementById("<%=divPrint.ClientID %>");
              var printWindow = window.open('', '', 'height=400,width=800');
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

          $(function () {

              $('#MstLftMenu').remove();

          });

    </script>
    <style>
        .GridviewScrollC1Header TH, .GridviewScrollC1Header TD {
            vertical-align: middle!important;
        }
    </style>
    <style>
        .width {
            width: 100%;
        }
    </style>
    <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default" style="font-family: Helvetica Neue, Helvetica, Arial, sans-serif; font-size: 16px; line-height: 1.42857143;">
                    <div class="panel-heading" style="text-align: center">
                        <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                        <h2 class="panel-title" style="font-weight: bold;">
                            <asp:label id="lblHeading" runat="server">TSiPASS - Applications Yet to Fall in Pendency- Department Wise</asp:label>
                            <a id="Button2" href="#" onserverclick="btnbdf_Click"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a>
                            <%--<a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>--%>
                            <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a>
                        </h2>
                    </div>
                    <div class="panel-body">
                        <table align="center" class="width" cellspacing="5" style="font-family: 'Trebuchet MS';">
                            <tr>
                                <td>
                                    <table runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <asp:hyperlink cssclass="btn btn-link" id="BtnBack" runat="server" navigateurl="~/UI/TSiPASS/ReportsDashboardNew.aspx"
                                                    text="<< Back"> </asp:hyperlink>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px"></td>
                            </tr>
                            <tr runat="server" id="div_Print">
                                <td colspan="2" style="padding: 5px;" valign="top">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="2" style="padding: 10px; margin: 5px; text-align: center; font-weight: bold;">
                                                <asp:label id="Label12" font-size="Large" runat="server">TSiPASS - Applications Yet to Fall in Pendency- Department Wise</asp:label>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td colspan="2" style="padding: 10px; margin: 5px; text-align: right; font-weight: bold;">
                                                <asp:button id="btnbdf" runat="server" cssclass="btn btn-primary" height="32px" tabindex="10" text="Generate Pdf" onclick="btnbdf_Click" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td colspan="2" style="padding: 10px; margin: 5px; text-align: center; font-weight: bold;">
                                                <asp:label id="Label1" runat="server" cssclass="LBLBLACK"></asp:label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2" style="padding: 5px;" valign="top">

                                                <asp:gridview id="grdDetails" cssclass="floatingTable" runat="server" autogeneratecolumns="true" cellpadding="5"
                                                    showfooter="false" width="100%" >
                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="50px" CssClass="GridviewScrollC1HeaderWrap" Font-Bold="true" />
                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                
                                <RowStyle Wrap="true" />
                               <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            </asp:gridview>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="Tr1" runat="server">
                                <td colspan="2" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                    <asp:label id="Label2" runat="server" visible="false" cssclass="LBLBLACK"></asp:label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">

                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Success!</strong><asp:label id="lblmsg" runat="server"></asp:label>
                                    </div>


                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Warning!</strong>
                                        <asp:label id="lblError" runat="server"></asp:label>
                                    </div>
                                </td>

                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding: 5px; margin: 5px">&nbsp;
            </td>
        </tr>
    </table>

    <style>
        .GridviewScrollC1Header TH, .GridviewScrollC1Header TD {
            vertical-align: middle!important;
        }

        .GridviewScrollC1HeaderWrap TH, .GridviewScrollC1HeaderWrap TD {
            vertical-align: middle!important;
            text-align: center!important;
        }
    </style>
</asp:Content>

