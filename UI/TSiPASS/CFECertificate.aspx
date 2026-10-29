<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CFECertificate.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>COI Certficate</title>
    <style type="text/css">
        .div3
        {
            /*-webkit-column-count: 3;
    -moz-column-count: 3; 
    column-count: 3; */
            -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
            -moz-column-gap: 40px; /* Firefox */
            column-gap: 20px;
        }
        .w3-code
        {
            border-left: 5px solid #73AD21 !important;
            font-size: 17px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }
        .w4-code
        {
            border-left: 5px solid #73AD21 !important;
            font-size: 14px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }
        ol.u
        {
            list-style-type: none;
            font-size: 13px;
            padding: 10px 10px 10px 10px;
        }
        ol.v
        {
            list-style-type: inherit;
            font-size: 17px;
            font-weight: bold;
            padding: 6px 6px 6px 6px;
        }
        .table
        {
            border-collapse: collapse;
            width: 100%;
        }
        th, td
        {
            text-align: left;
            border: 2px solid ActiveCaptionText;
            padding: 5px;
        }
    </style>
    
     <script type="text/javascript" src="../../Resource/Scripts/code39.js" ></script>
    <style type="text/css">
  	#barcode {font-weight: normal; font-style: normal; line-height:normal; sans-serif; font-size: 30pt}
        .auto-style1 {
            width: 847px;
            height: 1063px;
        }
        </style>

       <script language="javascript" type="text/javascript">
           function Redirect() {
               var session = '<%=HttpContext.Current.Session["uid"]%>';
               if (session != "" && session != null && session != undefined) {
                   var ask = window.confirm("Thank you for downloading your TS-iPASS consolidated certificate. Hope you had good experience. Please spare some time for filling feedback form, it will help us in improving our service.");
                   if (ask) {
                       window.location = "IpassFeedBackForm.aspx?Rfrom=3";
                   }
               }
           }
        </script>
</head>
<body onload="Redirect();" style="width: 1248px; height: 1123px">
    <form id="form1" runat="server">
    <div align="center">
        <div align="center" style="border: thin solid #000000; padding:20px; background-position:center; background-repeat:no-repeat; 
            background-image: url('../../images/bg_cert.png'); text-align: center; letter-spacing: 1px; word-spacing: 1px;" >
            <h3 align="center">
                <table style="background-color:Transparent; width: 100%;">
                    <tr>
                        <td style="width: 33%; text-align: left;" align="left">
                            <asp:Label ID="lblApprovalNo" runat="server" Width="350px" Font-Names="Verdana" Font-Size="12px"></asp:Label>
                        </td>
                        <td style="font-family: Verdana; text-align:center; font-size: 14px;width: 33%">
                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" style="height: 67px; width: 73px" /></td>
                        <td style="font-family: Verdana; font-size: 12px;width: 33%; text-align: right;" 
                            align="right">
                            <asp:Label ID="lblApprovalNo0" runat="server" Visible="false" Width="300px" Font-Names="Verdana" 
                                Font-Size="12px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </h3>
            <div style="background-color:Transparent" align="center">
                <h3 style="color: #FF3399; font-family: Verdana;">
                   <%-- COMMISSIONERATE OF INDUSTRIES--%>
                    <asp:Label ID="Label4" runat="server"  Font-Names="Verdana" 
                                Font-Size="15px"></asp:Label>
                    </h3>
            </div>
            <h3 style="color: #0000FF; font-family: Verdana;">
            INDUSTRIES DEPARTMENT <br />
                 <asp:Label ID="Label5" runat="server"  Font-Names="Verdana" 
                                Font-Size="15px"></asp:Label>
               <%-- Chirag-ali Lane, 
                Abids, 
                Hyderabad – 500 001--%>
            </h3>
            <h3 style="color: #FF33CC; text-decoration: underline; font-size: 35px; font-family: Verdana;">
                <asp:Label ID="Label3" runat="server" ForeColor="#FF33CC" Text="TG-iPASS APPROVAL"
                    Font-Underline="False" Font-Size="24px" Font-Bold="True"></asp:Label></h3>
            <h3 style="color: #0000FF; font-size: larger; text-align: center; font-family: Verdana;">
                (CONSENT FOR ESTABLISHMENT)</h3>
            <br />
            <table  style="background-color:Transparent" style="width: 99%">
                <tr>
                    <td colspan="3" align="justify" style="text-align: justify; background-color:Transparent; font-family: Verdana;
                        font-size: 20px; word-spacing: 4px; letter-spacing: 1px;">
                        <asp:Label ID="Label2" runat="server" ForeColor="Black" Font-Underline="False" Font-Size="20px"
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td style="background-color:Transparent" colspan="3">
                        <asp:GridView  style="background-color:Transparent" ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" Height="62px" PageSize="15" Width="100%" BorderColor="Black"
                            BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" Font-Names="Verdana"
                            Font-Size="14px">
                            <FooterStyle Font-Bold="True" ForeColor="Black" />
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ApprovalName" HeaderText="Approval/ Clearance issued">
                                    <ItemStyle Width="450px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RefNo" Visible="false" HeaderText="Reference Number" />
                                <asp:BoundField DataField="Approval_Date"  HeaderText="Date of approval" />
                                <asp:BoundField DataField="Status"  HeaderText="status" />
                            </Columns>
                            <PagerStyle ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                    </td>
                </tr>
               
                <tr  style="background-color:Transparent">
                    <td  style="background-color:Transparent;font-family: Verdana; font-size: 20px; text-align: Left; word-spacing: 4px;letter-spacing: 1px;" colspan="3" >
                        <asp:Label ID="lblNameOfCertifiedPerson5" runat="server" ForeColor="Black" Font-Underline="False"
                            Font-Size="20px" Font-Bold="False" Width="100%">In view of the above the unit is hereby accorded the Permission/Approval applied for under TS-iPASS.</asp:Label>
                    </td>
                </tr>
                <tr  style="background-color:Transparent">
                    <td colspan="3" style="text-align: Left;background-color:Transparent; font-family: Verdana; font-size: 20px; word-spacing: 4px;
                        letter-spacing: 1px;">
                        <asp:Label ID="Label1" runat="server" ForeColor="Black" Font-Underline="False" Font-Size="20px"
                            Font-Bold="False" Width="100%">This approval is issued in accordance with the powers vested as per the Section 
                                4(X) of TS-iPASS Act, No. 3 of 2014 Government of Telangana.</asp:Label>

                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td align="center" colspan="3" style="text-align: center; background-color:Transparent;">
                        &nbsp;
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td style="background-color:Transparent" align="left" style="text-align: left">
                        <span style="text-align: left;">
                            <asp:Label ID="lblNameOfCertifiedPerson2" runat="server" Font-Bold="True" ForeColor="Black"
                                Width="250px" Font-Names="Verdana"></asp:Label>
                        </span>
                    </td>
                    <td  align="center" style="text-align: center; background-color:Transparent" runat="server" visible="false">
                            <asp:Image ID="Image1" runat="server" Width="250px" Height="180px" 
                                 />     </td>
                    <td align="center" style="text-align: center;  background-color:Transparent;">
                        <span style="text-align: center;">
                            <asp:Label ID="lblNameOfCertifiedPerson3" runat="server" Font-Bold="True" ForeColor="Black"
                                Font-Size="15px" Height="31px" Width="280px" Font-Names="Verdana">Commissioner of Industries
Telangana</asp:Label>
                        </span>
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td align="center" style="text-align: center; background-color:Transparent;" colspan="3">
                        &nbsp;</td>
                  
                </tr>
                <tr>
                    <td align="center" style="background-color:Transparent;" colspan="3" runat="server" visible="false">
                    <div style="border:1px; border-color:Black;background-position:left; background-repeat:no-repeat;">
                        Signature valid<br />                        
                        <asp:Label ID="lblsigby" Font-Size="Small" runat="server"/><br />
                        <asp:Label ID="lblSig" Font-Size="Small" runat="server"/>
                    </div>
                    </td>                    
                </tr>
                <tr>
                  <td align="center" style="background-color:Transparent;" colspan="3">
                    <div style="border:1px; border-color:Black;background-position:left; background-repeat:no-repeat;">
                       <b> Note </b>: *This is a computer generated certificate please verify it by clicking on the link 
                             <b> <u>https://ipass.telangana.gov.in/UI/TSiPASS/frmCFEcertificateProcess.aspx</u></b>
                                and entering the application number mentioned on the certificate.
                    </div>
                    </td>  
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
    </div>
    
      <script type="text/javascript">
          /* <![CDATA[ */
          function get_object(id) {
              var object = null;
              if (document.layers) {
                  object = document.layers[id];
              } else if (document.all) {
                  object = document.all[id];
              } else if (document.getElementById) {
                  object = document.getElementById(id);
              }
              return object;
          }
          get_object("lblBarcode").innerHTML = DrawCode39Barcode(get_object("lblBarcode").innerHTML, 1);
          /* ]]> */
</script>
    </form>
</body>
</html>