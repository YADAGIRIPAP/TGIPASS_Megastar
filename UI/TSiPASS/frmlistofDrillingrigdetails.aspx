<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmlistofDrillingrigdetails.aspx.cs" Inherits="UI_TSiPASS_frmlistofDrillingrigdetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <script language="javascript" type="text/javascript">
        function Panel1() {
            document.getElementById('<%=Button2.ClientID %>').style.display = "none";
            var panel = document.getElementById("<%=tr1.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');
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

        $(function () {
            $('#MstLftMenu').remove();
        });

    </script>
    <style>
        .algnCenter
        {
            text-align: right;
        }
    </style>
  
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }
        select
        {
            color: Black !important;
        }
    </style>
    <style>
        .algnCenter
        {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   changeMonth: true,
                   changeYear: true,
                   yearRange: yrRange

                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
            $("input[id$='txtTodate']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   changeMonth: true,
                   changeYear: true,
                   yearRange: yrRange

                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
            $("input[id$='txtTodate']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   changeMonth: true,
                   changeYear: true,
                   yearRange: yrRange

                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
        });
    </script>


     <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading" align="center">
                <h2 class="panel-title" style="font-weight: bold;">
                  Drilling Rigs Report
                    <a id="pdfPrint" href="#" onclick="javascript:return Panel1();" runat="server">
                        <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                            style="float: right;" /></a> <a id="Button2" href="#" onserverclick="BtnPDF_Click"
                                runat="server">
                               <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                            <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                alt="Excel" /></a>
                </h2>
            </div>
            <div class="panel-body">
                <table align="center" cellpadding="10" cellspacing="5" style="width: 50%; font-family: 'Trebuchet MS'">
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/HomeDeptDashboard.aspx"
                                Text="<< Back">
                            </asp:HyperLink>
                        </td>
                    </tr>
                   
                    <tr id="tr1" runat="server">
                        <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                           
                              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="True"
                                                        Width="100%" OnRowDataBound="grdDetails_RowDataBound" BorderColor="Black">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Application No">
                                                                <ItemTemplate>
                                                                    <%# Eval("UIDNo") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <%# Eval("Status") %>
                                                                    <asp:Label ID="lbl_grdrejectedremarks"  Visible="false" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Query Response">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink_queryrespond" runat="server" Text="Respond"   Font-Bold="true" ForeColor="Green"
                                                                        Target="_blank" />
                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Application Form">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink_applicationform" runat="server" Text="View"   Font-Bold="true" ForeColor="Green"
                                                                        Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Payment Details">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink_payment" runat="server" Text="View" Font-Bold="true" ForeColor="Green"
                                                                        Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Attachments">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink_attachment" runat="server" Text="View" Font-Bold="true" ForeColor="Green"
                                                                        Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:BoundField DataField="Applicationtype" HeaderText="Application Type" />
                                                             <asp:BoundField DataField="Nameoftheapplicant" HeaderText="Applicant Name" />
                                                            <asp:BoundField DataField="AddressApplicant" HeaderText="Address of Applicant" />
                                                            <asp:BoundField DataField="ApplicantMobileno" HeaderText="Contact Mobile No"  />
                                                            <asp:BoundField DataField="ApplicantEmailID" HeaderText="Contact Email ID"  />
                                                            <asp:BoundField DataField="regvehicleno" HeaderText="Registration No. of the vehicle" />
                                                            <asp:BoundField DataField="RTODistrictName" HeaderText="In which District RTO registration "  />                                                             
                                                            <asp:BoundField DataField="Descofdrillrigs" HeaderText="Description of the drilling rig"  />
                                                            <asp:BoundField DataField="maxdiameterdepth" HeaderText="Capacity of Drilling Max Diameter Depth(In inchs)" />
                                                            <asp:BoundField DataField="Areaofoperation" HeaderText="Area of operation" />
                                                            <asp:BoundField DataField="FeeAmount" HeaderText="Application Fee" />
                                                            <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date"  />
                                                             <asp:BoundField DataField="Query_RaiseDate" HeaderText="Query Raise Date" />
                                                            <asp:BoundField DataField="QueryRespondDate" HeaderText="Query Responded  Date" />
                                                             <asp:BoundField DataField="ApprovalDate" HeaderText="Approval Date" />
                                                            <asp:BoundField DataField="RejectedDate" HeaderText="Rejected Date" />
                                                                 <asp:TemplateField>
                                                                 <HeaderTemplate>
                                                                     Query Raise/Approval/Rejected Document
                                                                 </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink_approvalrejectedattachment" runat="server" Text="View" Font-Bold="true" 
                                                                        Target="_blank" />
                                                                    <br /> <br /> <br />
                                                                     <asp:HyperLink ID="hyp_viewqueryresponse" runat="server" Text="view Query Response"  Visible="false"  Font-Bold="true" ForeColor="Blue"
                                                                        Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>

                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

