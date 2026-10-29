<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RENCertificate.aspx.cs" Inherits="UI_TSiPASS_Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>COI Certficate</title>
    <style>
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
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <div align="center" style="border: thin solid #000000; padding:50px; background-position:center; background-repeat:no-repeat; text-align: center; width: 830px;
            letter-spacing: 1px; word-spacing: 1px;">
            <h3 align="center">
                <table width="100%" style="background-color:Transparent">
                  
                    <tr>
                        <td colspan="3">
                         <asp:Label ID="lblApprovalNo" runat="server"  Font-Names="Verdana" Font-Size="12px"></asp:Label>
                        </td>
                      
                    </tr>
                    <tr><td>

                        </td>
                        <td>
                                         </td>
                        <td>
                                       </td>
                    </tr>
                   <tr>
                   
                  <td><img src="telanganalogo.png" style="height: 67px; width: 73px" /></td>
                         <td style="text-align:center;padding:3px;" >
                            <h3 align="center"><span>GOVERNMENT OF TELANGANA<br />DEPARTMENT OF TOURISM</span> </h3>
                            <h4 align="center"># 3-5-891, Tourism House, Himayatnagar, Hyderabad – 500029</h4>
                        </td>
                       
                    <td align="justify"><%-- <img src="../../images/telanganatourism.jpg.png"  style="height: 67px; width: 114px"/>--%> 
                        &nbsp;  <img src="../../images/TGtourism.png"  style="height: 67px; width: 114px" /></td>
                       
                    </tr>
                </table>
            </h3>
            <h3 style="color: #0000FF; font-size: larger; text-align: center; font-family: Verdana;">
                (RENEWAL)</h3>
            <table>
  <tr>
                        <td colspan="6" style="text-align:center;padding:0px;" >
                            <h3 align="center"><span>APPROVAL</span> </h3>                         
                        </td>
                    </tr>
            </table>
           
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
                            </Columns>
                            <PagerStyle ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                    </td>
                </tr>
              
                <tr  style="background-color:Transparent">
                    <td colspan="3" style="text-align: Left;background-color:Transparent; font-family: Verdana; font-size: 20px; word-spacing: 4px;
                        letter-spacing: 1px;">
              
                        <asp:Label ID="Label1" runat="server" ForeColor="Black" Font-Underline="False" Font-Size="15px"
                            Font-Bold="False" Width="100%">The unit is hereby accorded permission to establish/operate the unit in the above said premises.This approval is issued in accordance with the powers vested as per the Section 4(x) of TS-iPASS Act, No. 3of 2014 Government of Telangana.</asp:Label>
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td align="center" colspan="3" style="text-align: center; background-color:Transparent;">
                        &nbsp;
                    </td>
                </tr>
                <tr style="background-color:Transparent;">
                    <td style="background-color:Transparent" align="left" style="text-align: left">
                        <span style="text-align: left;">
                            <asp:Label ID="lblNameOfCertifiedPerson2" runat="server" Font-Bold="True" ForeColor="Black"
                                Font-Names="Verdana"></asp:Label>
                        </span>
                    </td>
                    <td  align="center" style="text-align: center; background-color:Transparent">
                        <asp:Image ID="Image1" runat="server" Height="180px" Width="250px" />
                    </td>
                    <td align="center" style="text-align: center;  background-color:Transparent;">
                        <span style="text-align: center;">
                           <asp:Label ID="lblNameOfCertifiedPerson3" runat="server" Font-Bold="True" ForeColor="Black"
                                Font-Size="12px" Height="31px" Width="280px" Font-Names="Verdana">COMMISSIONER OF TOURISM</asp:Label>
                        </span>
                    </td>
                </tr>
                  <tr>
                    <td align="center" style="background-color:Transparent;" colspan="3">
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
    </form>
</body>
</html>
