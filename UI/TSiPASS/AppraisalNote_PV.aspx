<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppraisalNote_PV.aspx.cs" Inherits="UI_TSiPASS_AppraisalNote_PV" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
     .div3 {
         /*-webkit-column-count: 3;
 -moz-column-count: 3; 
 column-count: 3; */
         -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
         -moz-column-gap: 40px; /* Firefox */
         column-gap: 40px;
     }

     .w3-code {
         border-left: 5px solid #73AD21 !important;
         font-size: 17px;
         padding: 5px;
         font-weight: bold;
         color: #082ea2;
     }

     .w4-code {
         border-left: 5px solid #73AD21 !important;
         font-size: 14px;
         padding: 5px;
         font-weight: bold;
         color: #082ea2;
     }

     ol.u {
         list-style-type: none;
         ;
         font-size: 13px;
         padding: 10px 10px 10px 10px;
     }

     ol.v {
         list-style-type: inherit;
         font-size: 17px;
         font-weight: bold;
         padding: 10px 10px 10px 10px;
     }

     .table {
         border-collapse: collapse;
         width: 100%;
     }

     th, td {
         text-align: left;
         border: 2px solid ActiveCaptionText;
         padding: 8px;
     }

     }
 </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <div id="divDynPrint" runat="server">
        </div>
    </form>
</body>
</html>
