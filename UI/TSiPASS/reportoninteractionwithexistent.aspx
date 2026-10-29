<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="reportoninteractionwithexistent.aspx.cs" Inherits="UI_TSiPASS_reportoninteractionwithexistent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        //function pageLoad() {
        //    var date = new Date();
        //    var yrRange = "1990:" + (date.getFullYear() + 1);
        //    var currentMonth = date.getMonth();
        //    var currentDate = date.getDate();
        //    var currentYear = date.getFullYear();
            //$("input[id$='txtfrmdate']").datepicker(
            //    {
            //        dateFormat: "dd/mm/yy",
            //        changeMonth: true,
            //        changeYear: true,
            //        yearRange: yrRange,
            //        maxDate: 0
            //    })
            //$("input[id$='txttodate']").datepicker(
            //    {
            //        dateFormat: "yy-mm-dd",
            //        changeMonth: true,
            //        changeYear: true,
            //        yearRange: yrRange,
            //        maxDate: 0
            //    })    
        //}
    </script>
     <script language="javascript" type="text/javascript">
         $(function () {

             $('#MstLftMenu').remove();

         });
     </script>
    <style type="text/css">
    .col-lg-10 {
        width: 1050px;
    }
</style>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                 <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold; align-content:center"><asp:Label ID="lblHeading" runat="server" Visible="false">reportoninteractionwithexistent Details</asp:Label>
                                <a id="Button2" href="#" onserverclick="Button2_ServerClick"
                                runat="server">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="Button1" href="#" onserverclick="Button1_ServerClick" runat="server">
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h2>
                        </div>
                 <div>
                      <tr>
                                <td colspan="8" style="width: 883px; height: 25px;">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink3" runat="server" NavigateUrl="~/UI/TSiPASS/InteractionsReportsDashBoard.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                </div>

                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">Women-Cell</asp:Label>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="6" align="center" style="text-decoration: underline; padding-bottom:30px">
                                    <asp:Label ID="lblhdng" runat="server" Font-Bold="true" Font-Size="25px"> Report on Interaction Through Women-Cell</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="style3" align="center" style="width: 178px">
                                                <asp:Label ID="lblfromdt" runat="server">From Date :</asp:Label>
                                            </td>
                                            <td style="width: 10px">:</td>
                                            <td style="width: 229px">
                                                <asp:TextBox ID="txtfrmdate" runat="server" class="form-control" Width="150px" TabIndex="1"></asp:TextBox>
                                                <cc1:CalendarExtender ID="txtfrmdate_CalendarExtender" runat="server"
                                                    Format="dd-MM-yyyy" PopupButtonID="txtfrmdate" TargetControlID="txtfrmdate">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td class="style3" align="center" style="width: 178px">
                                                <asp:Label ID="lbltodate" runat="server">To Date :</asp:Label>
                                            </td>
                                            <td style="width: 11px">:</td>
                                            <td>
                                                <div>
                                                    <asp:TextBox ID="txttodate" runat="server" class="form-control txtbox" style="width:150px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server"
                                                        Format="dd-MM-yyyy" PopupButtonID="txttodate" TargetControlID="txttodate">
                                                    </cc1:CalendarExtender>
                                                </div>
                                            </td>
                                            <td class="style3" align="right" style="width: 178px">
                                                <asp:Label ID="Label1" runat="server">District </asp:Label>
                                            </td>
                                            <td style="width: 11px">:</td>
                                            <td style="width:200px">
                                                <div>
                                                    <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" style="width:150px" >
                                                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center; height: 50px" colspan="10">&nbsp;&nbsp;
                                                <asp:Button ID="BtnGetData" runat="server" CssClass="btn btn-primary"
                                                    Height="32px" TabIndex="10" Text="Get Report" ValidationGroup="group"
                                                    Width="120px" OnClick="BtnGetData_Click" />
                                                &nbsp;
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10"></td>
                            </tr>
                        </table>
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 70%">
                          <%--  <tr>
                                <td colspan="8" style="width: 883px">
                                    <asp:Label ID="lblForGrid" Text="District wise PMEGP Succes Stories" Visible="false" runat="server" Font-Bold="true"></asp:Label>

                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdsupport" runat="server" AutoGenerateColumns="false" Width="100%"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333"
                                        CssClass="HeaderFloat" OnRowDataBound="grdsupport_RowDataBound" >
                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                                <%--Districtid--%>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField HeaderText="District" DataTextField="District" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>                                       
                                            <asp:HyperLinkField HeaderText="Visited" DataTextField="VisitedCount" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                             <asp:HyperLinkField HeaderText="Existing" DataTextField="ExstCount" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                            <asp:HyperLinkField HeaderText="New" DataTextField="NewCount" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>                                         
                                              <asp:HyperLinkField HeaderText="Reported Grievance " DataTextField="GrvncSubmtd" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField> 
                                             <asp:HyperLinkField HeaderText="Pending with the officer" DataTextField="ofcrpending" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                             <asp:HyperLinkField HeaderText="Resolved by Officer" DataTextField="ofcrResolved" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>  
                                            
                                                  <asp:HyperLinkField HeaderText="Escalated to GM" DataTextField="escalatedtoGM" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField HeaderText="Pending with GM" DataTextField="GMpending" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField HeaderText="Resolved by GM" DataTextField="GMResolved" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField HeaderText="Escalated to DIPC" DataTextField="escalatedtoDIPC" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField HeaderText="Pending with DIPC" DataTextField="DIPCpending" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField HeaderText="Resolved by DIPC" DataTextField="DIPCResolved" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField HeaderText="Escalated to DOI" DataTextField="escalatedtoDOI" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField HeaderText="Pending with DOI" DataTextField="DOIpending" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField HeaderText="Resolved by DOI" DataTextField="DOIResolved" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>                                           
                                             <asp:HyperLinkField HeaderText="Grievance Online" DataTextField="grvncOnline" ControlStyle-ForeColor="Black" FooterStyle-CssClass="text-center">
                                                    <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                </asp:HyperLinkField>
                                            <asp:BoundField HeaderText="District ID" DataField="Districtid" Visible="false" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>

                    </div>

                </div>

            </div>
        </div>

    </div>
</asp:Content>



