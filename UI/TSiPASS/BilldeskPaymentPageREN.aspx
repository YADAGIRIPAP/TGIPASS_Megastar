<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BilldeskPaymentPageREN.aspx.cs" Inherits="UI_TSiPASS_BilldeskPaymentPageREN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
   
    <form id="form1" action='<%= Session["BuildDeskNewUrl"].ToString() %>' method="post">
        <div>
            <input id="msg" type="hidden" value='<%=Session["msg"].ToString() %>' name="msg" />
           
            <input style="border-top-width: thin; font-weight: bold; border-left-width: thin; font-size: 12px; border-left-color: #ffffff; border-bottom-width: thin; border-bottom-color: #ffffff; color: #ffffff; border-top-color: #ffffff; font-family: Tahoma, Verdana, Arial, Helvetica, sans-serif; background-color: #7f853d; border-right-width: thin; border-right-color: #ffffff"
                type="submit" value="PAY NOW" id="btnpaynow" runat="server"/>
        </div>
    </form>
</body>
</html>
