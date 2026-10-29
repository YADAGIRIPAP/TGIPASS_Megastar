<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmMSMEPrint.aspx.cs" Inherits="UI_TSiPASS_frmMSMEPrint" Title="MSME-Print" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style>
        .div3
        {
            /*-webkit-column-count: 3;
    -moz-column-count: 3; 
    column-count: 3; */
            -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
            -moz-column-gap: 40px; /* Firefox */
            column-gap: 40px;
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
            ;
            font-size: 13px;
            padding: 10px 10px 10px 10px;
        }

        ol.v
        {
            list-style-type: inherit;
            font-size: 17px;
            font-weight: bold;
            padding: 10px 10px 10px 10px;
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
            padding: 8px;
        }

        }
    </style>
  <%-- <script language="javascript" type="text/javascript">
       function Panel1() {
           document.getElementById('<%=A1.ClientID %>').style.display = "none";
           document.getElementById('<%=A2.ClientID %>').style.display = "none";
           document.getElementById('<%=trFilter.ClientID %>').style.display = "none";
           var panel = document.getElementById("<%=panel_printmsme.ClientID %>");
           var printWindow = window.open('', '', 'height=400,width=800');
           printWindow.document.write('<html><head><title></title>');

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
    </script>--%>
     <script type="text/javascript">
         function printGrid() {
             var gridData = document.getElementById('<%= panel_printmsme.ClientID %>');
             var windowUrl = 'about:blank';
             //set print document name for gridview
             var uniqueName = new Date();
             var windowName = 'Print_' + uniqueName.getTime();
             var prtWindow = window.open(windowUrl, windowName,
                'left=100,top=100,right=100,bottom=100,width=700,height=500');
             prtWindow.document.write('<html><head></head>');
             prtWindow.document.write('<body style=”background:none !important”>');
             prtWindow.document.write(gridData.outerHTML);
             prtWindow.document.write('</body></html>');
             prtWindow.document.close();
             prtWindow.focus();
             prtWindow.print();
             prtWindow.close();
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="panel_printmsme" runat="server">
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <h3>
                        TS-iPASS MSME APPLICATION FORM</h3>
                </div>
                <br />
                <div align="center">
                    <div align="center">
                        <table bgcolor="White" width="800" border="2px" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td>
                                    <b>MSME DETAILS</b>
                                </td>
                                <td>
                                    <b>OLD</b> &nbsp;
                                </td>
                                <td>
                                    <b>NEW</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    NAME OF INDUSTRIAL UNDERTAKING :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblNameOfUndertaker" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblupdatedindustryname" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    PartII/SSI/Udyogaadhar Memorundum/ IEM / IL ID :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lbludyogaadharno" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblupdatedudyogaadharno" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Category :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblcategory" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblupdatedcategory" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    District :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lbldistrict" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblupdateddist" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mandal :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblmandal" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblupdatedmandal" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Village :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblvillage" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblupdatedvillage" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Whether the unit is in Industrial estate or Park/Not:
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblindusestateornot" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblupdatedindusestateornot" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr id="trindustryparkname" runat="server" visible="false">
                                <td>
                                    Name of the Industrial Park:
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblindustryparkname" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblindustryparkname_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    House No :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblhouseno" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblupdthouseno" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Locality :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lbllocality" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lbllocality_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Street :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblstreet" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblstreet_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Landmark :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lbllandmark" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lbllandmark_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Complete Unit Address :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblcompleteunitaddress" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblcompleteunitaddress_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;Investment in Lakhs :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblinvestment" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblinvestment_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Employment :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblEmployment" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblEmployment_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Present Status :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblpresentstatus" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblpresentstatus_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr id="trotherstatus" runat="server" visible="false">
                                <td>
                                    Other Status :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblotherstatus" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblotherstatus_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Type Of Industry :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblindustrytype" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblindustrytype_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Date Of Commencement of Production :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lbl_dcp" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lbldcp_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Type Of Connection :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblconnection" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblconnection_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Does Unit Export :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblunitexport" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblunitexport_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr id="trexportcontry" runat="server" visible="false">
                                <td>
                                    Export Country :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblexportcountry" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblexportcountry_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Name of Entrepreneur :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblentrepname" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblentrepname_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mobile No :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblmobileno" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblmobileno_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    EmailID :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblemailid" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblemailid_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Social Status :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblcaste" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblcaste_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Is Promoter Differently Abled :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblisdiffabled" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblisdiffabled_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Is Promoter Women :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblpromoterwomen" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblpromoterwomen_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Sector :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblsector" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblsector_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Line Of Activity :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLOA" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLOA_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Category Of PCB :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblpcbcat" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblpcbcat_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Raw Materials is Procurred From :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblrawmatfrom" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblrawmatfrom_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr id="trrawdistrict" runat="server" visible="false">
                                <td>
                                    District :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblrawdistrict" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblrawdistrict_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr id="trrawstate" runat="server" visible="false">
                                <td>
                                    State :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblrawmaterialprocredstate" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblrawmaterialprocredstate_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr id="trrawcontry" runat="server" visible="false">
                                <td>
                                    Country :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblrawmaterialproccountry" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblrawmaterialproccountry_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Remarks :
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblremarks" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblremarks_new" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div class="row">
                        <div style="text-align: left; width: 70%; font: bold">
                            MANUFACTURING ITEMS(OLD)</div>
                        <div class="col-sm-12 table-responsive" align="center">
                            <asp:GridView runat="server" ID="grd_manufacturedproducts" AutoGenerateColumns="false"
                                BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" EmptyDataText="No Data Found"
                                CssClass="GRD" ForeColor="#333333" GridLines="None" Width="70%">
                                <HeaderStyle CssClass="gridcolor" />
                                <RowStyle BackColor="#ffffff" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <%#Eval("Manfitem") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity Per Annum">
                                        <ItemTemplate>
                                            <%#Eval("Manfquantityperannum") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Production In Units">
                                        <ItemTemplate>
                                            <%#Eval("Manfquantityin") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Others">
                                        <ItemTemplate>
                                            <%#Eval("Mfgothers") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OthersSpecify">
                                        <ItemTemplate>
                                            <%#Eval("OthersSpecify") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#013161" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div style="text-align: left; width: 70%; font: bold">
                            MANUFACTURING ITEMS(NEW)</div>
                        <div class="col-sm-12 table-responsive" align="center">
                            <asp:GridView runat="server" ID="grd_manufacturedproducts_NEW" AutoGenerateColumns="false"
                                BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" EmptyDataText="No Data Found"
                                CssClass="GRD" ForeColor="#333333" GridLines="None" Width="70%">
                                <HeaderStyle CssClass="gridcolor" />
                                <RowStyle BackColor="#ffffff" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <%#Eval("Manfitem") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity Per Annum">
                                        <ItemTemplate>
                                            <%#Eval("Manfquantityperannum") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Production In Units">
                                        <ItemTemplate>
                                            <%#Eval("Manfquantityin") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Others">
                                        <ItemTemplate>
                                            <%#Eval("Mfgothers") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OthersSpecify">
                                        <ItemTemplate>
                                            <%#Eval("OthersSpecify") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#013161" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-12 table-responsive" align="center">
                            <div style="text-align: left; width: 70%; font: bold">
                                RAW MATERIALS(OLD)</div>
                            <asp:GridView runat="server" ID="grd_rawmaterial" AutoGenerateColumns="false" BorderColor="#003399"
                                BorderStyle="Solid" EmptyDataText="No Data Found" BorderWidth="1px" CellPadding="4"
                                CssClass="GRD" ForeColor="#333333" GridLines="None" Width="70%">
                                <HeaderStyle CssClass="gridcolor" />
                                <RowStyle BackColor="#ffffff" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ITEM">
                                        <ItemTemplate>
                                            <%#Eval("RawItem") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity Per Annum">
                                        <ItemTemplate>
                                            <%#Eval("RawQntyperAnnum") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Production In Units">
                                        <ItemTemplate>
                                            <%#Eval("RawUnits") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Others">
                                        <ItemTemplate>
                                            <%#Eval("OtherUnits") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#013161" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 table-responsive" align="center">
                            <div style="text-align: left; width: 70%; font: bold">
                                RAW MATERIALS(NEW)</div>
                            <asp:GridView runat="server" ID="grd_rawmaterial_NEW" AutoGenerateColumns="false"
                                BorderColor="#003399" BorderStyle="Solid" EmptyDataText="No Data Found" BorderWidth="1px"
                                CellPadding="4" CssClass="GRD" ForeColor="#333333" GridLines="None" Width="70%">
                                <HeaderStyle CssClass="gridcolor" />
                                <RowStyle BackColor="#ffffff" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ITEM">
                                        <ItemTemplate>
                                            <%#Eval("RawItem") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity Per Annum">
                                        <ItemTemplate>
                                            <%#Eval("RawQntyperAnnum") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Production In Units">
                                        <ItemTemplate>
                                            <%#Eval("RawUnits") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Others">
                                        <ItemTemplate>
                                            <%#Eval("OtherUnits") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#013161" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="text-align: center">
            <asp:LinkButton ID="lnk_print" CssClass="DTTT_button DTTT_button_prin" TabIndex="0"
                aria-controls="example-4" ToolTip="View print view" OnClientClick="printGrid()"
                runat="server">
                                 <img src="../../Resource/Images/pdf-printer-icon.jpg" height="15"  />   <span>Print</span>
            </asp:LinkButton>
        </div>
    </asp:Panel>
           
    </form>
</body>
</html>

