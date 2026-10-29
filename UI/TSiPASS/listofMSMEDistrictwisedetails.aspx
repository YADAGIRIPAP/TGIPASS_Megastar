<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="listofMSMEDistrictwisedetails.aspx.cs" Inherits="UI_TSiPASS_listofMSMEDistrictwisedetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= GridView1.ClientID %>');
           var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();
            var prtWindow = window.open(windowName,'left=100,top=100,right=100,bottom=100,width=700,height=500');
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
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {
            win = window.open("frmMSMEPrint.aspx?MSMENo=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
        }
    </script>
    <script language="javascript" type="text/javascript">
        function Panel1() {
            document.getElementById('<%=pdfPrint.ClientID %>').style.display = "none";
            document.getElementById('<%=pdfPrint.ClientID %>').style.display = "none";
            var panel = document.getElementById("<%=GridView1.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>newTable</title>');

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


        $(function () {

            $('#MstLftMenu').remove();

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;<li class="active"><a href="#">
                <asp:Label ID="lblHead1" runat="server" CssClass="LBLBLACK" Font-Bold="True"></asp:Label>
            </a></li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server"  CssClass="LBLBLACK" Font-Bold="True" ></asp:Label>
                            <a id="pdfPrint" href="#" onclick="javascript:return printGrid();"
                                                    runat="server">
                                                    <img src="../../Resource/Images/pdf-printer-icon.jpg" alt="PDF" width="30px;" height="30px;"
                                                        style="float: right;" /></a>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-12 form-group" align="center">
                          <asp:HyperLink ID="hyp_back" runat="server" Font-Size="Small"   NavigateUrl="~/UI/TSiPASS/MSME_DistrictwiseReport.aspx">Back</asp:HyperLink>
                          &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                          &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                           &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                          &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                          &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                          &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                           <b>
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label></b>
                                </div>
                                
                            </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-12 form-group" align="center">
                                <div class="table-responsive" style="overflow-x: auto;">

                                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-small-font table-bordered table-striped" AutoGenerateColumns="false" PageSize="10"
                                        AllowPaging="false" ShowHeaderWhenEmpty="true" ShowHeader="true" OnRowDataBound="GridView1_RowDataBound"  OnPageIndexChanging="GridView1_PageIndexChanging" ShowFooter="false" EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;">
                                         <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                    <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                    <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                    <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sr.#
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    Sr.#
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    View
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                <asp:LinkButton ID="hyp_view" Text="View" runat="server" ></asp:LinkButton>
                                                    <%-- <asp:HyperLink ID="hyp_view" Text="View" runat="server"  /> ---%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Unit Name
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                     <%#Eval("UNIT_NAME") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    UAM ID
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                     <%#Eval("UAM_ID") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    IE or Not
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                           <%#Eval("UNITS_IE_OR_NOT") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Industry Category
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                     <%#Eval("EnterpriseName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    INVESTMENT
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                            <%#Eval("INVESTMENT") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    EMPLOYMENT
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("EMPLOYMENT") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Present Status
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("PresentStatus") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    TYPE OF INDUSTRY
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("TYPEOFINDUSTRY") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    EXPORT
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("EXPORT") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    TYPE OF CONNECTION
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                     <%#Eval("TYPEOFCONNECTION") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                     Date of Commencement
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("DATEOFCOMMENCEMENT") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    District Name
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("District_Name") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Mandal Name
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("Manda_lName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Industries park
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("IndustrialPark") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Village
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("Village") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    House No/Plot No
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("HouseNo") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Street
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("Street") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Locality
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("Locality") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Land Mark
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("LandMark") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Complete Address
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("CompleteAddress") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Promoter Name
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("NAME_OF_ENTREPRENEUR") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Mobile Number
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("MOBILE_NO") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    EMAIL ID
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("EMAIL_ID") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Social Status
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                     <%#Eval("SOCAILSTATUS") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                  Promoter Women  
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("PROMOTERWOMEN") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Promoter Disabled
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("PROMOTERDISABLED") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                   SECTOR
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("SECTOR") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                   LINE OF ACTIVITY
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("LineofActivity_Name") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                   PCB CATEGORY
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("PCBCATEGORY") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                   Raw Material Procured
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Eval("RAWMATERIALPROCURED") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Location Details
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                   <%#Eval("LocationDetails") %> 
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                        </Columns>
                                        <HeaderStyle BorderWidth="2px" />
                                        <FooterStyle Font-Bold="true" />
                                        <PagerStyle CssClass="gridview"></PagerStyle>
                                    </asp:GridView>
                                    <div class="form-group" style="padding-left: 645px">
                                        <asp:HyperLink ID="hyp_close" runat="server" NavigateUrl="~/UI/TSiPASS/MSME_DistrictwiseReport.aspx"  CssClass="btn btn-danger  btn-sm" Text="Close" ></asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

