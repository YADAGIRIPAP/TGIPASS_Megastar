<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TS-iPASSCFO.aspx.cs" Inherits="Default2" Title="TS-iPASS- Questionnaire" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
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





        .GRD {
            width: 200px;
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            padding: 10px;
            text-transform: capitalize;
        }

        * {
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
            text-align: center;
        }

        .GRDHEADER {
            border: 1px solid #ffffff;
            color: #0E2A46;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            BACKGROUND-IMAGE: url('../../Resource/Styles/images/bg_blue_grd.gif');
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px;
            /*text-decoration:none;*/
            /*border-color:#013161;*/
            /*border-style:solid;*/
            text-transform: uppercase;
            /*border-width:1px;*/
            /*height:23px;*/
            /*text-indent:5px;*/
            /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }

        a {
            color: #337ab7;
            text-decoration: none;
        }

        a {
            background-color: transparent;
        }

        .style2 {
            color: #FF0000;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <table align="center"
            style="border: 1px solid #000000; font-family: Verdana; font-size: 12px; text-align: center; width: 800px;">
            <tr>
                <td align="center" style="padding: 0px; margin: 0px; text-align: center">
                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png"
                        width="45px" height="45px" />
                </td>
            </tr>
            <tr style="padding: 0px; margin: 0px; border: 1px solid #000000; font-family: Verdana; font-size: 18px;">
                <td align="center" style="text-align: center; font-family: Verdana; font-weight: bold; font-size: 18px; border: 1px solid #000000;">TS-iPASS COMMON APPLICATION FORM</td>
            </tr>

            <tr style="padding: 0px; margin: 0px; border: 1px solid #000000;">
                <td align="center"
                    style="text-align: center; font-weight: bold; font-size: 16px; border: 1px solid #000000;">CFO Questionnaire Form</td>
            </tr>
            <tr>
                <td align="center">




                    <table bgcolor="White" width="900" border="2px" cellpadding="22"
                        style="font-family: Verdana; font-size: 14px;">
                        <tr style="background-color: #6699FF">

                            <th>
                                <b><span>Sector of Enterprise</span></b></th>
                            <th>
                                <asp:Label ID="LblSectionofExterprise" runat="server"></asp:Label>
                            </th>
                        </tr>
                        <tr>

                            <td>
                                <span style="color: rgb(51, 51, 51); font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 20px; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">Proposed District</span></td>
                            <td>
                                <span></span>
                                <asp:Label ID="txtDistrict" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>

                            <td>
                                <span style="color: rgb(51, 51, 51); font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 20px; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">Proposed Mandal</span></td>
                            <td>
                                <asp:Label ID="lblMandal" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>

                            <td>Proposed Village</td>
                            <td>
                                <span></span>
                                <asp:Label ID="lblVillage" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>

                            <td colspan="2" style="background-color: #CCFFFF"><b>Project Cost Details :</b></td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GvProjectdtls" runat="server"
                                    CellPadding="4" ForeColor="#333333"
                                    Height="62px" PageSize="15" Width="100%"
                                    BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                                    Font-Bold="False" Font-Names="Verdana" Font-Size="14px">
                                    <%-- <FooterStyle Font-Bold="True" ForeColor="Black" />--%>
                                    <RowStyle HorizontalAlign="Left"
                                        VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1%>
                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="70px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle Font-Bold="True"
                                        ForeColor="Black" />
                                    <EditRowStyle BackColor="#B9D684" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>





                        <tr>

                            <td>
                                <b>Total Project Cost (in Rs. Lakhs) :</b></td>
                            <td>

                                <span>
                                    <asp:Label ID="txtTotalValue" runat="server"></asp:Label>
                                </span></td>
                        </tr>
                        <tr>

                            <td>Have you taken CFE from Pollution Control Board</td>
                            <td>
                                <span>
                                    <asp:Label ID="lblCfePCB" runat="server" Font-Bold="False"
                                        ForeColor="Black"></asp:Label>
                                </span></td>
                        </tr>





                        <!--///-->


                        <tr>

                            <td>Line of Activity</td>
                            <td>
                                <asp:Label ID="txtActivity" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>

                            <td>Pollution Category of Enterprise</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtPolutionCategory" runat="server" Font-Bold="False"></asp:Label>
                                </span></td>
                        </tr>

                        <tr>
                            <td>Do you Require Licence from Factories</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtLicence" runat="server"></asp:Label>
                                </span></td>
                        </tr>

                        <tr>
                            <td>Do you require High Tension Meter to your industry(HT meter) </td>
                            <td>
                                <span>
                                    <asp:Label ID="txtHtMeter" runat="server"></asp:Label>
                                </span></td>
                        </tr>
                        <tr>
                            <td>Is the Height of the Building greater than or equal to 15 Metres</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtBuildingHeight" runat="server" Font-Bold="False"
                                        ForeColor="Black"></asp:Label>
                                </span></td>
                        </tr>
                        <tr>
                            <td>Have you taken NOC from FIRE</td>
                            <td>
                                <span>
                                    <asp:Label ID="txtNOCFormFire" runat="server" Font-Bold="False"
                                        ForeColor="Black"></asp:Label>
                                </span></td>
                        </tr>



                        <tr>
                            <td>Do you use any products related to Drugs </td>
                            <td>
                                <span>
                                    <asp:Label ID="txtDrugsRelated" runat="server"></asp:Label>
                                </span></td>
                        </tr>
                        <tr>

                            <td>Do you require a Boiler for your industry </td>
                            <td>
                                <span>
                                    <asp:Label ID="txtBoilerRequired" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>

                            <td>Do you require a Boiler Manufactuer for your industry </td>
                            <td>
                                <span>
                                    <asp:Label ID="txtBoilerRequiredmanu" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <%--<tr>                       
                                                  
                            <td>
                                Do you store Rectified Spirit/Kerosene/Naptha</td>
                            <td>
                                <span>
                                <asp:Label ID="txtSpirit" runat="server"></asp:Label>
                                </span>
</td>
                    </tr>
                    
                     <tr>                       
                                                 
                            <td>
                                Constitution of the unit</td>
                            <td>
                                <span>
                                <asp:Label ID="txtConsitutionOfUnit" runat="server"></asp:Label>
                                </span></td>
                    </tr>
                   
                    
                   
                     <tr>                                                  
                            <td>
                                Generator Requirement </td>
                            <td>
                                <span>
                                <asp:Label ID="txtGeneratorRequirement" runat="server"></asp:Label>
                                </span>
</td>
                    </tr>
                   
                     <tr>                                                 
                            <td>
                                Height of the Building.</td>
                            <td>
                                <span>
                                <asp:Label ID="txtHightOfBulding" runat="server"></asp:Label>
                                </span></td>
                    </tr>
                        <tr>                       
                          
                            <td>
                                Built up Area(Including Parking Cellars)
Square Meters
</td>
                            <td>
                               <span>
                                <asp:Label ID="txtBuiltUpArea" runat="server"></asp:Label>
                                </span></td>
                    </tr>
                    
                        <tr>
                       
                            <td>
                                Area Type </td>
                            <td>
                                <span>
                                <asp:Label ID="txtAreaType" runat="server"></asp:Label>
                                </span>
</td>
                    </tr>
                    
                    <tr>                       
                                                   
                            <td>
                                Is there any need to Fell trees in Proposed Site
(Non-Exempted trees List)</td>
                            <td>
                                <span>
                                <asp:Label ID="txtFellTrees" runat="server"></asp:Label>
                                </span>
</td>
                    </tr>
                    
                    <tr>                       
                       
                            <td>
                                Number of trees to be felled</td>
                            <td>
                                <span>
                                <asp:Label ID="txtTreesToBeFelled" runat="server"></asp:Label>
                                </span>
</td>
                    </tr>
                    
                    
                    <tr>                       
                       
                            <td>
                                Name of Unit</td>
                            <td>
                                <span>
                                <asp:Label ID="txtTreesToBeFelled0" runat="server"></asp:Label>
                                </span>
</td>
                    </tr>--%>
                    </table>





                </td>
            </tr>
            <tr>
                <td align="center" style="text-align: center">
                    <asp:GridView ID="grdDetails" runat="server"
                        AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333"
                        Height="62px" PageSize="15" Width="100%"
                       
                        ShowFooter="True" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                        Font-Bold="False" Font-Names="Verdana" Font-Size="14px"
                        >
                        <FooterStyle Font-Bold="True" ForeColor="Black" />
                        <RowStyle HorizontalAlign="Left"
                            VerticalAlign="Middle" />
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
                            <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required ">
                                <ItemStyle Width="450px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Dept_Full_name" HeaderText="Department">
                                <ItemStyle Width="180px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fees" HeaderText="Fees (Rs.)" DataFormatString="{0:0}">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle Font-Bold="True"
                            ForeColor="Black" />
                        <EditRowStyle BackColor="#B9D684" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <%--<tr><td align="center" style="text-align: center">        
        <asp:GridView ID="grdDetails" runat="server" 
                                                AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" 
                                                Height="62px" PageSize="15" Width="100%" 
                                                onrowdatabound="grdDetails_RowDataBound" 
                        ShowFooter="True" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                        Font-Bold="False" Font-Names="Verdana" Font-Size="14px" 
                        onselectedindexchanged="grdDetails_SelectedIndexChanged">
                                                <footerstyle font-bold="True" forecolor="Black" />
                                                <rowstyle horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required " >
                                                        <ItemStyle Width="450px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Dept_Full_name" HeaderText="Department" >
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Fees" HeaderText="Fees (Rs.)"   DataFormatString="{0:0}"  >
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle font-bold="True" forecolor="#333333" />
                                                <headerstyle font-bold="True" 
                                                    forecolor="Black" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView></td></tr>--%>

            <tr>
                <td align="center" class="style2" style="text-align: center">Note: For 
        any other clearances from Government of India, applicant shall apply directly to 
        the concerned department.</td>
            </tr>

            <tr>
                <td align="center" class="style2" style="text-align: center"><a href="Home.aspx" target="_self" style="color: blue">HOME</a></td>
            </tr>

        </table>

    </form>
</body>
</html>
