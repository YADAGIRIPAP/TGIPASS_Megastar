<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmcoiGeneralDD.aspx.cs" masterPageFile="~/UI/TSiPASS/CCMaster.master" Inherits="UI_TSIPASS_frmcoiGeneralDD" %>



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


        <table>
            <tr>
                <td style="width:100%">
                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="true" CellPadding="4"
                                                                      Width="100%">
                                                                    <HeaderStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                                                    <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle Height="40px" CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle Height="30px" CssClass="GridviewScrollC1Header" />
                                                                    <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                                    
                                                                </asp:GridView>
                </td>
            </tr>
        </table>

    </asp:Content>