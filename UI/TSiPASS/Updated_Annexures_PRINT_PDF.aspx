<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Updated_Annexures_PRINT_PDF.aspx.cs" Inherits="UI_TSiPASS_Updated_Annexures_PRINT_PDF" %>


<script runat="server">   
</script>

</script>

<%--    <form id="form2" runat="server">
        <div>
            <asp:Label ID="lblAbbreviation" runat="server" Text=""></asp:Label>
        </div>
    </form>--%>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css" media="print">
    @page {
        size: A4;
    }
    .center-align {
        text-align: center;
    }
    @media print {
  .hide-print {
    display: none;
  }
}
    @media print {
        .page-break {
            page-break-before: always;
        }
    }
</style>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 2444px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align: center; font-size:18px">GOVERNMENT OF TELANGANA</h1>
            <h2 style="text-align: center; font-size:18px; font-weight:normal">DIRECTORATE OF INDUSTRIES :: HYDERABAD</h2>
            <h3 style="text-align: center; font-size:16px; text-decoration:underline">PROCEEDINGS OF THE ADDITIONAL DIRECTOR OF INDUSTRIES</h3>
            <h4 style="text-align: center; font-size:14px; font-weight:normal">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Present: Sri. Rajkumar Ohatker, B.E, (MECH.)</h4>
           <p style="text-align: center; font-size:16px; font-weight:bold; text-decoration:underline">Cheque Procs. No. <asp:Label ID="ProcessNo" runat="server" />  -  List no. <asp:Label ID="ListNo" runat="server" /> (<asp:Label ID ="FinancialYear" runat="server"/>) <asp:Label ID="Date" runat="server"/> </p>
            <p style="text-align: center; font-size:14px"> Sub :-  <asp:Label ID="SchemeCategory" runat="server"/> - Industries - Incentives/Concessions under <asp:Label Id="SchemeName" runat="server"/> Scheme - <asp:Label ID="Scheme" runat="server"/> – Incentives sanctioned to Micro & Small Enterprises by  SLC/DLC – Release of funds towards meeting expenditure for payment of pending incentives to the units –  Cheque Proceeding - Issued.</p>
            <p style="text-align: center; font-size:14px">Ref :-&nbsp;&nbsp;&nbsp; 1. Consolidated Proceedings No. <asp:Label ID="ConsolidatedProceedingsNo1" runat="server"/> Dt. <asp:Label ID="Dt1" runat="server"/></br>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      2. Consolidated Proceedings No. <asp:Label ID="ConsolidatedProceedingsNo2" runat="server"/> Dt. <asp:Label ID="Dt2" runat="server"/></br> 3. LOC Number:&nbsp;<asp:Label ID ="LOC_NUMBER" runat="server"/>  &nbsp;dt. <asp:Label ID ="LOC_Date" runat="server"/> of the DTO, Hyd for <asp:Label ID="LOCDTOHYD" runat="server"/> </br>***
            </p>
            <p>The Director Industries issued order to release an amount of Rs. <asp:Label ID="LOCDTOHYDERABAD" runat="server"/> /- (<asp:Label ID ="LOCDTOHYDERABAD_IN_WORDS" runat="server" /> only) towards Investment subsidy/pending incentives to () cases and an amount of Rs. <asp:Label ID="DOISanction" runat="server"/>/- (<asp:Label ID ="DOISANCTION_IN_WORDS" runat="server" /> only) to () cases from the funds available in the PD account of Commissioner of Industries.</p>
            <p>The GM, DICs have forwarded UCs pertaining to the consolidated proceedings in reference cited and the details are as below:</p>
            
            
            <asp:GridView ID="gvProceedings" runat="server" AutoGenerateColumns="false"  CellPadding="4" OnRowDataBound="gvProceedings_RowDataBound" 
                                BackColor="#954675" CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="true" Width="100%" CellSpacing="4">
            <FooterStyle BackColor="#954675" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" /> <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Center" VerticalAlign="Middle" />
                <Columns>                        
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="List No.">
                                        <ItemTemplate>
                                            <asp:Label ID="ListNo" runat="server" CssClass="center-align" Text='<%# "List no." + Eval("ListNo") + " " + "(" + FinancialYear.Text +")" %>'></asp:Label>
                                        </ItemTemplate> 
                                        <HeaderStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of Claims">
                                        <ItemTemplate>
                                            <asp:Label ID="NoOfClaims" runat="server" CssClass="center-align" Text='<%#Eval("NoofClaims") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="Total_Amount" runat="server" CssClass="center-align" Text='<%# Bind("Amount", "Rs. {0:0,0.00}/-") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle />
                                    </asp:TemplateField>
                 </Columns>
            </asp:GridView>
            <h5 style="font-weight:bold; text-decoration:underline">O R D E R S:</h5>
            <p>The orders are hereby accorded for release to a total of <asp:Label ID ="TotalNoofClaims" runat="server"/> claims sanctioned by SLC/DLC as shown in the statement Table below.</p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  CellPadding="4" OnRowDataBound="GridView1_RowDataBound" OnPreRender="GridView1_PreRender"
                                BackColor="#954675" CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="true" ShowHeader="true" Width="100%" CellSpacing="4">
            <FooterStyle BackColor="#954675" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" /> <HeaderStyle BackColor="#954675" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" /> <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Center" VerticalAlign="Middle" />
                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NAME OF UNIT & ADDRESS" HeaderText="Name of Unit &amp; Address" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Name of the Bank">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBankName" runat="server" Text='<%#Eval("NAME OF THE BANK") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("BRANCH NAME") %>' />
                                        </ItemTemplate >
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAccno" runat="server" Text='<%#Eval("ACCOUNT No") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IFSC Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIFSCCode" runat="server" Text='<%#Eval("IFSC CODE No") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sanctioned Amount in Rs.">
                                        <ItemTemplate>
                                            <asp:Label ID="Sanctioned_Amount" runat="server" Text='<%# Eval("SanctionedAmount") %>' />
                                        </ItemTemplate>
                                        <HeaderStyle/>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="List No.">
                                        <ItemTemplate>
                                            <asp:Label ID="ListNo" runat="server" CssClass="center-align" Text='<%#Eval("ListNo") %>'></asp:Label>
                                        </ItemTemplate> 
                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No. of Claims">
                                        <ItemTemplate>
                                            <asp:Label ID="NoOfClaims" runat="server" CssClass="center-align" Text='<%#Eval("NoofClaims") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>--%>
                 </Columns>
            </asp:GridView>
            
            <div class="page-break">
            
            <p>The A.O (FAC),Central Office is requested to issue (05) cheque for a total amount of Rs.<asp:Label ID="TotalAmount" runat="server"/>/- (<asp:Label ID ="TotalAmount_INWORDS" runat="server" /> only) for disbursing to a total of <asp:Label ID ="TotalNoofClaims_1" runat="server"/> claims through RTGS from the funds available in the P. D. Account No. 37 of the Commissioner of Industries at DTO, Hyderabad(Urban).</p>
            <br></br>
            <p style="text-align:right">Additional Director of Industries</p>
            <br></br>
            <p>To </br> The A.O(FAC),Central Office.</p>
        </div>
        <div align="center">
            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-Secondary hide-print" height="35px" Width="150px" OnClick="btnPrint_Click" />
            <asp:Button ID="BtnClose" runat="server" Text="Close" CssClass="btn btn-Secondary hide-print" Height="35px" Width="150px" onclick="BtnClose_Click" />
        </div>

            </div>
    </form>
</body>
</html>


