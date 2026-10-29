
<%@ Page Title=":: TSiPASS : Works wise Report " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="coiGeneralQueryAbstarct.aspx.cs" Inherits="UI_TSIPASS_coiGeneralQueryAbstarct" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script language="javascript" type="text/javascript">
 

    <style>
        .width {
            width: 85%;
        }
    </style>
     <%--datepicker added on 17/01/2019--%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
           
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index:9999 !important;
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
     <script language="javascript" type="text/javascript">
         function Panel1() {

             var panel = document.getElementById("<%=td1.ClientID %>");
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
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
               <table id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
               <tr>

               
               <td>
                <div class="panel-heading" style="text-align: center">
                        
                            
                            &nbsp; <a id="pdfPrint" href="#" onclick="javascript:return Panel1();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                            <%--<a id="button2" href="#" onserverclick="btnbdf_click"
                                    runat="server">
                                    <img src="../../resource/images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                        alt="pdf" /></a>--%>
                                        <a id="Button1" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a>
                        </h2>
                    </div>
               </td>
               </tr>

        <tr>
            <td id="td1" runat="server">
                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True" Width="100%">
                                                                    <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                                    <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                                    <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>                           
                                                                           
                                                                        <asp:BoundField DataField="Type" HeaderText="Type">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="150px" />
                                                                        </asp:BoundField>
                                                                      
                                                                       
                                                                             <asp:HyperLinkField DataTextField="Total_Recieved" HeaderText="Total Received">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                        </asp:HyperLinkField>

                                                                        <asp:HyperLinkField DataTextField="Total_pending" HeaderText="Total Pending">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                        </asp:HyperLinkField>
                                                                        
                                                                        <asp:HyperLinkField DataTextField="Total_addressed" HeaderText="Total Addressed">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                        </asp:HyperLinkField>
                                                                        <asp:HyperLinkField DataTextField="Total_rejected" HeaderText="Total Rejected">
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="text-center" Width="180px" />
                                                                        </asp:HyperLinkField>
                                                                    </Columns>
                                                                </asp:GridView>                              <RowStyle Wrap="true" />
                            </asp:GridView>
            </td>
            
            </tr>
                   </table>
         
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
