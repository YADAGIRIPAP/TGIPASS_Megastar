<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="SupporttoWomenExistingEntrepreneursDrillDwn.aspx.cs" Inherits="UI_TSiPASS_SupporttoWomenExistingEntrepreneursDrillDwn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }     
    </style>
     <script language="javascript" type="text/javascript">
        $(function () {

            $('#MstLftMenu').remove();

        });
     </script>
    <div align="left">
        <div class="row" align="left">
           <div class="col-lg-12" id="divPrint1" runat="server">
                 <div class="panel-heading" style="text-align: center">
                            <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                            <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold; align-content:center"><asp:Label ID="lblHeading" runat="server" Visible="false">SupporttoWomenExistingEntrepreneurs Details</asp:Label>
                                <a id="Button2" href="#" onserverclick="Button2_ServerClick"
                                runat="server">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="Button1" href="#" onserverclick="Button1_ServerClick" runat="server">
                                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h2>
                        </div>
               <div>
                      <tr>
                                <td colspan="8" style="width: 883px; height: 25px;">
                                    <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/SupporttoWomenExistingEntrepreneurs.aspx"
                                                        Text="<< Back">
                                                    </asp:HyperLink>

                                </td>
                            </tr>
                </div>

               <%-- <div>
                    <asp:LinkButton ID="lnkbutton" runat="server" OnClick="lnkbutton_Click">Back</asp:LinkButton>
                </div>--%>
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title" style="text-align:center;">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px" > Women Existing Entrepreneurs Details</asp:Label>
                        </h3>
                    </div>   
                    <br />
   <%-- <div  style="overflow-x: auto; width: 950px; max-height: 300px">--%>
       <asp:GridView ID="GrdwmenEntpnrdtls" runat="server" AutoGenerateColumns="False" Width="95%"  BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" 
           Style="margin-left:15px; margin-right:5px;" AllowSorting="true" CssClass="floatingtable"  HeaderStyle-CssClass="FixedHeader" OnRowDataBound="GrdwmenEntpnrdtls_RowDataBound" >
            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" CssClass="GridviewScrollC1HeaderWrap" />
            <RowStyle HorizontalAlign="Center" CssClass="GridviewScrollC1Item"  />
    <Columns>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
        <asp:BoundField DataField="InteractionType" HeaderText="InteractionType"   />
        <asp:BoundField DataField="Name" HeaderText="Unit Name"/>
        <asp:BoundField DataField="Address" HeaderText="Address"/>
        <asp:BoundField DataField="Investment" HeaderText="Investment"/>
         <asp:BoundField DataField="Employment" HeaderText="Employment"/>
         <asp:HyperLinkField HeaderText="View" DataTextField="" Text="View" />
         <asp:TemplateField HeaderText="existing entpreurID" Visible="false">
          <ItemTemplate>
          <asp:Label id="lblentrpurID" runat="server" Text='<%#Eval("PIEEId") %>'  ></asp:Label>
           </ItemTemplate>
         </asp:TemplateField>
    </Columns>
</asp:GridView>
  </div>
  <br />
</div>
            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
    </div>
    </div>
</asp:Content>

