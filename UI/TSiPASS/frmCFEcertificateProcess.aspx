<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master"
    AutoEventWireup="true" CodeFile="frmCFEcertificateProcess.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }
        .style7
        {
            width: 42px;
        }
        .style8
        {
            height: 30px;
        }
        .style9
        {
            width: 27px;
            height: 30px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i></i><a href="Home.aspx">Home</a></li>
                    <%--<li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>--%>
                    <li class="active"><i ></i>TG-iPASS Certificate Verification
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    TG-iPASS Certificate Verification</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                         <tr>
                                                           <td style="padding: 5px; margin: 5px; text-align: left;">
                                                               1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Width="150px">Type of Application</asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddlquantityper" runat="server" 
                                                                    class="form-control txtbox" Height="33px" 
                                                                    TabIndex="1" 
                                                                    Width="180px" OnSelectedIndexChanged="ddlquantityper_SelectedIndexChanged">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="CFE">CFE</asp:ListItem>
                                                                    <asp:ListItem Value="CFO">CFO</asp:ListItem>
                                                                    <asp:ListItem Value="HOTELCFE">CFE HOTEL</asp:ListItem>
                                                                    <asp:ListItem Value="HOTELCFO">CFO HOTEL</asp:ListItem>
                                                                    <asp:ListItem Value="REN">Renewal</asp:ListItem>
                                                                    <asp:ListItem Value="INC">Incentives</asp:ListItem>
                                                                    <asp:ListItem Value="Plot">TSIIC Plot Allotment</asp:ListItem>
                                                                    <asp:ListItem Value="EVENTS">Tourism Events</asp:ListItem>
                                                                    <asp:ListItem Value="AGENCY">Travel Agency</asp:ListItem>
                                                                    <asp:ListItem Value="FDC">Film Shooting</asp:ListItem>
                                                                    <asp:ListItem Value="MULTIPLEX">Multiplex Screening</asp:ListItem>
                                                                    <asp:ListItem Value="MOBILE">Mobile Tower</asp:ListItem>
                                                                    <asp:ListItem Value="ADV">Advertisement</asp:ListItem>
                                                                    <asp:ListItem Value="EXBR">Excise Brand Registration</asp:ListItem>
                                                                    <asp:ListItem Value="EXLAB">Excise Label Registration</asp:ListItem>
                                                                    <asp:ListItem Value="EXIMP">Excise Import</asp:ListItem>
                                                                    <asp:ListItem Value="EXEXP">Excise Export</asp:ListItem>
                                                                       <asp:ListItem Value="LIQUOR">Prohibition and Excise Department</asp:ListItem>
                                                                     <asp:ListItem Value="BMW">  Bio Medical Waste Management</asp:ListItem>
                                                                     <asp:ListItem Value="LEGAL">Legal Metrology Verification</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                    ControlToValidate="ddlquantityper" 
                                                                    ErrorMessage="Please Select Application Type" InitialValue="--Select--" 
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Name of Unit</asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtnameofUnit" runat="server" class="form-control txtbox" Height="28px"
                                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnameofUnit"
                                                                    ErrorMessage="Please ente Name of Unit" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                5
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label425" runat="server" CssClass="LBLBLACK" Width="210px">Unit location</asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddlLand_intDistrictid" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlLand_intDistrictid"
                                                                    ErrorMessage="Please Select Location of unit" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                       
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                2&nbsp;
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Width="150px">UID Number</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtUID" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUID"
                                                                    ErrorMessage="Please enter UID number" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                4
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label426" runat="server" CssClass="LBLBLACK" Width="150px">Category</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlLand_intDistrictid0" runat="server" class="form-control txtbox"
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="O">Orange</asp:ListItem>
                                                                    <asp:ListItem Value="R">Red</asp:ListItem>
                                                                    <asp:ListItem Value="G">Green</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlLand_intDistrictid0"
                                                                    ErrorMessage="Please enter Category" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="text-align: center;" align="center" colspan="3">
                                                                <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                    OnClick="BtnSave_Click" TabIndex="10" Text="Search" ValidationGroup="group" Width="90px" />
                                                                &nbsp;
                                                                <asp:Button ID="BtnCancel" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                                                    Width="90px" />
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="style8">
                                                </td>
                                                <td class="style9">
                                                </td>
                                                <td valign="top" class="style8">
                                                </td>
                                            </tr>
                                            <tr id="trcfecfo" runat="server">
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    <asp:GridView ID="grdDetails" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                                                        CellPadding="5" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound"
                                                        PageSize="15" ShowFooter="True" Width="100%" DataKeyNames="intCertificationid">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                            <asp:BoundField DataField="UnitName" HeaderText="Name  of Unit"></asp:BoundField>
                                                            <asp:BoundField DataField="UID" HeaderText="UID Number"></asp:BoundField>
                                                            <asp:BoundField DataField="District_Name" HeaderText="Location of Unit" />
                                                            <%-- <asp:HyperLinkField HeaderText="Respond to Query"  DataNavigateUrlFields="Keyword,State,City"
                    DataNavigateUrlFormatString="KeywordSrchSumDtl.aspx?Keyword={0}&State={1}&City={2}"/>--%>
                                                            <asp:BoundField DataField="Address" HeaderText="Address" />
                                                            <asp:TemplateField HeaderText="Download">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox2" runat="server" Text="View"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hypLetter" runat="server" Target="_blank"> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Stat" HeaderText="Status" />
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                                 <tr>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="12" id="trinc" runat="server" visible="false">
                                            <div style="width: 100%">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="100%" CellSpacing="4" OnRowDataBound="GridView1_RowDataBound">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="NameofUnitAddress" ItemStyle-HorizontalAlign="Center" HeaderText="Name of Unit & Address">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DateofReceipt" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Receipt">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Scheme" ItemStyle-HorizontalAlign="Center" HeaderText="Scheme">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RecommendedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Recommended Amount">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Amount">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SanctionedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Date">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SLCNumer" ItemStyle-HorizontalAlign="Center" HeaderText="SLC Numer">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SLCDate" ItemStyle-HorizontalAlign="Center" HeaderText="SLCDate">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEnterperIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Intimation Letter">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortagGMCertificate" Target="_blank" runat="server" Text="Intimation Letter"></asp:HyperLink>
                                                                 <asp:Label ID="lbloffiline" Visible="false" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="OfflineFlag" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOfflineFlag" Text='<%#Eval("OfflineFlag") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                    &nbsp;<tr>
                                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                                            &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                                            Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
           
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
