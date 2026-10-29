<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sanctionnew.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        <div align="center" style="border: thin solid #000000; padding:50px; background-position:center; background-repeat:no-repeat; background-image: url(../../images/bg_cert.png); text-align: center; width: 830px;
            letter-spacing: 1px; word-spacing: 1px;">
          
            <div style="background-color:Transparent" align="center">
                <center style="text-align: center">
                    <img src="telanganalogo.png" style="height: 67px; width: 73px" />
                </center>
                  <h3 align="center" style="color: #0000FF; font-family: Verdana;">
               GOVERNMENT OF TELANGANA</h3>
                <h3 style="color: #FF3399; font-family: Verdana;">
                    COMMISSIONERATE OF INDUSTRIESINDUSTRIES :: HYDERABAD</h3>
            </div>
           <p style="text-align: left">
           <asp:Label ID="lbl1" Text="To :" runat="server"></asp:Label>
           
           </p>
            <p style="text-align: left">
              <asp:Label ID="lblUnitName" Text="" runat="server"></asp:Label> , </br>
              <asp:Label ID="Label5" Text="" runat="server"></asp:Label>,</br>
            </p>
            <h3 style="color: #FF33CC; text-decoration: underline; font-size: 35px; font-family: Verdana;">
                <asp:Label ID="Label3" runat="server" ForeColor="#CC33FF" Text="Lr No.39/1/2016/15903,Dated: 27-05-2016"
                    Font-Underline="False" Font-Size="20px" Font-Bold="True"></asp:Label></h3>
            <br />
            <table  style="background-color:Transparent" style="width: 99%">
                <tr>
                    <td colspan="2" align="justify" style="text-align: justify; background-color:Transparent; font-family: Verdana;
                        font-size: 20px; word-spacing: 4px; letter-spacing: 1px;">
                        <asp:Label ID="Label2" runat="server" ForeColor="Black" Font-Underline="False" Font-Size="20px" Text="Sir/Madam,"
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Sub:" ForeColor="Black" 
                            Font-Underline="False" Font-Size="20px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" ForeColor="Black" Font-Underline="False" Font-Size="20px" Text="T-Pride-SC-Scanction of Investment Subsidy to M/s.Saritha Earth Movers,Subladi(V),Thirmalayapalem(M),Khammam District.-intimation-Reg"
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td>
                        <asp:Label ID="Label8" runat="server" ForeColor="Black" Text="Ref:" 
                            Font-Underline="False" Font-Size="20px"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="1.GO.Ms.No.29,Industries&Commerce(IP) Department,Dated:29/11/2014,Read with G.O.Ms.No.78,I&C(IP)Dept,Dated:09/10/2015." ForeColor="Black" Font-Underline="False" Font-Size="20px"
                            Font-Bold="False"></asp:Label>
                        <br />
                        <asp:Label ID="Label14" runat="server" 
                            Text="2.GO.Ms.No.61,Industries&Commerce(IP) Department,Dated:29/0/2010,Read with G.O.Ms.No.42,I&C(IP)Dept,Dated:05/05/2011." 
                            ForeColor="Black" Font-Underline="False" Font-Size="20px"
                            Font-Bold="False"></asp:Label>
                        <br />
                        <asp:Label ID="Label15" runat="server" 
                            Text="3.Letter No.1592/B/2015,Dated:21/09/2015of the General Manager,District Industries Centre,Khamman District." 
                            ForeColor="Black" Font-Underline="False" Font-Size="20px"
                            Font-Bold="False"></asp:Label>
                        <br />
                        <asp:Label ID="Label16" runat="server" 
                            Text="4.Minutes of the 9th SLC meeting held on 22/04/2016." 
                            ForeColor="Black" Font-Underline="False" Font-Size="20px"
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td style="background-color:Transparent; text-align: center;" colspan="2">
                        *****</td>
                </tr>
                
                <tr  style="background-color:Transparent">
                    <td  style="background-color:Transparent" colspan="2" style="font-family: Verdana; font-size: 20px; text-align: Left; word-spacing: 4px;
                        letter-spacing: 1px;">
                        <asp:Label ID="Label11" runat="server" ForeColor="Black" 
                            
                            Text="With reference o the subject cited, We are Pleased to inform you that you have been sanctioned an amount of Rs.20,18,870 /- (Rupees Twenty Lakhs Eighteen Thousand Eight Hundred and Seventy Only) towards Investment Subsidy under the Scheme of T-PRIDE vide reference 4th cited." 
                            Font-Underline="False" Font-Size="Medium"
                            Font-Bold="False" Width="100%"></asp:Label>
                    </td>
                </tr>
                <tr  style="background-color:Transparent">
                    <td colspan="2" style="text-align: Left;background-color:Transparent; font-family: Verdana; font-size: 20px; word-spacing: 4px;
                        letter-spacing: 1px;">
                        <asp:Label ID="Label1" runat="server" ForeColor="Black" 
                            
                            Text="This amount will be released as and when yor unit's trun comes as per seriatim for disbursement of available funds." 
                            Font-Underline="False" Font-Size="Medium"
                            Font-Bold="False" Width="100%"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td align="center" colspan="2" 
                        style="text-align: center; background-color:Transparent;">
                        &nbsp;
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td align="center" colspan="2" 
                        style="text-align: center; background-color:Transparent;">
                        &nbsp;</td>
                </tr>
                <tr style="background-color:Transparent" align="right">
                    <td align="right" style="text-align: right; background-color:Transparent;" 
                        colspan="2">
                        <span style="text-align: right;">
                            <asp:Label ID="lblNameOfCertifiedPerson3" runat="server" Font-Bold="True" ForeColor="Black"
                                Font-Size="15px" Height="38px" Width="164px" Font-Names="Verdana" 
                            style="margin-left: 0px">Deputy Director (II&amp;SP)</asp:Label>
                        </span>
                    </td>
                </tr>
                <tr style="background-color:Transparent" align="right">
                    <td align="right" style="text-align: right; background-color:Transparent;" 
                         colspan="2">
                        &nbsp;
                        <span style="text-align: right;">
                            <asp:Label ID="lblNameOfCertifiedPerson4" runat="server" Font-Bold="True" ForeColor="Black"
                                Font-Size="15px" Height="35px" Width="239px" Font-Names="Verdana">O/o. Commissioner Of Industries</asp:Label>
                        </span>
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td align="center" style="text-align: left; background-color:Transparent;" 
                        colspan="2" >
                        <asp:Label ID="Label12" runat="server" ForeColor="Black" 
                            
                            Text="Copy to the General Manager,District Industries Centre,Khammam District for information.  Cppy to the Branch Manager,HDFC Bank,Ameerpet,Hyderabad" 
                            Font-Underline="False" Font-Size="Medium"
                            Font-Bold="False" Width="105%"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td align="left" style="text-align: left; background-color:Transparent;" 
                        colspan="2">
                        <asp:Label ID="Label13" runat="server" ForeColor="Black" 
                            
                            Text="Note:As per para 27.0 of the T-PRIDE guidelines and also a per the para 5(x) of the release proceedings reproduced hereunder Industrial units, which obtain including Balance sheet before 30th June of te succeeding year to the disbursing agencies. Such statement should be furnished for a period of minimum six(6) years. Further, industrial units should also furnish details of production, sales, employmen, etc., in the proforma prescribed to the General Manager,District Industries Centre concerned as an annual Return before 30th June of the Succeeding year and obtain acknowledgement thereof." 
                            Font-Underline="False" Font-Size="Medium" 
                            Font-Bold="False" Width="100%"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color:Transparent">
                    <td align="center" style="text-align: center; background-color:Transparent;" 
                        colspan="2">
                        <a href="CommissionerIncentiveUpdation.aspx?Stg=11">Back</a>&nbsp;</td>
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
