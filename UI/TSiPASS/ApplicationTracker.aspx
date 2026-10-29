<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="ApplicationTracker.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay {
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

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style7 {
            width: 42px;
        }

        .style8 {
            height: 30px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Application Tracker</a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Application Tracker</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body"> 
<%--                                    <asp:LinkButton ID="IAT" runat="server" PostBackUrl="~/UI/tsipass/IncentiveApplicationTracker.aspx"   Text="Incentive Application tracker"> </asp:LinkButton>--%>
                                       <asp:LinkButton 
    ID="IAT" 
    runat="server" 
    Text="Incentive Application Tracker"
    OnClientClick="window.open('IncentiveApplicationTracker.aspx', '_blank'); return false;">
</asp:LinkButton>
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Name of Unit</asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtnameofUnit" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="380px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnameofUnit"
                                                                    ErrorMessage="Please ente Name of Unit" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Width="150px">Type of Application</asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddlquantityper" runat="server" 
                                                                    class="form-control txtbox" Height="33px" 
                                                                    onselectedindexchanged="ddlquantityper_SelectedIndexChanged" TabIndex="1" 
                                                                    Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                     <asp:ListItem>CFE</asp:ListItem>
                                                                    <asp:ListItem>CFO</asp:ListItem>
                                                                    <asp:ListItem>RENEWAL</asp:ListItem>
                                                                    <asp:ListItem>PLOT</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                                    ControlToValidate="ddlquantityper" 
                                                                    ErrorMessage="Please Select Application Type" InitialValue="--Select--" 
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" align="center" colspan="3">
                                                    <asp:Label Visible="false" ForeColor="Red" runat="server" ID="lblError" Text="*Please Enter Unit Name or UID Number"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" align="center" colspan="3">
                                                    <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave_Click" TabIndex="10" Text="Search" ValidationGroup="group" Width="90px" />
                                                    &nbsp;
                                                    <asp:Button ID="BtnCancel" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen"
                                                        Width="90px" />
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                </td>
                                                <td valign="top" class="style8">
                                                </td>
                                            </tr>
                                              <tr>
                                              <br />
                                              <br />
                                                <td style="text-align: center;" align="center" colspan="3">
                                                    <asp:Label ForeColor="Red" runat="server" ID="lblrecords"></asp:Label>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    <asp:GridView ID="grdDetails" runat="server" AllowPaging="False" AutoGenerateColumns="false"
                                                        CellPadding="5" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound"
                                                        PageSize="15" ShowFooter="True" Width="100%">
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
                                                             <asp:BoundField DataField="UID" HeaderText="UID"></asp:BoundField>
                                                            <asp:BoundField DataField="Name of the Industry" HeaderText="Name of the Industry"></asp:BoundField>
                                                            <asp:BoundField DataField="District" HeaderText="District"></asp:BoundField>
                                                              <asp:BoundField DataField="DTCPFLAG" HeaderText="DTCP FLAG"></asp:BoundField>
                                                            <asp:BoundField DataField="INCENTIVESAPPLIED" HeaderText="Applied for Incentive"></asp:BoundField>
                                                            <asp:BoundField DataField="ALLAPPROVALSISSUEDFLAG" HeaderText="All Approval Issued"></asp:BoundField>
                                                           <asp:BoundField DataField="Activity Proposed" HeaderText="Activity Proposed"></asp:BoundField>
                                                           <asp:BoundField DataField="Line of Activity" HeaderText="Line of Activity"></asp:BoundField>
                                                           <asp:BoundField DataField="Total Investment (in Crores)" HeaderText="Total Investment (in Crores)"></asp:BoundField>
                                                           <asp:BoundField DataField="Date of application" HeaderText="Date of application"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="View Status">
                                                                
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hypLetter" runat="server" Target="_blank"> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
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
                                                <td align="left" colspan="3" style="padding: 5px; margin: 5px" valign="top">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="3" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:GridView ID="grdDetails0" runat="server" AllowPaging="False" 
                                                        AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" Height="62px" 
                                                        OnRowDataBound="grdDetails0_RowDataBound" PageSize="15" ShowFooter="True" 
                                                        Width="100%">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid0" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid0" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="UID" HeaderText="UID" />
                                                            <asp:BoundField DataField="Name of the Industry" 
                                                                HeaderText="Name of the Industry" />
                                                             <asp:BoundField DataField="District" HeaderText="District"></asp:BoundField>
                                                            <asp:BoundField DataField="INCENTIVESAPPLIED" HeaderText="Applied for Incentive"></asp:BoundField>
                                                            <asp:BoundField DataField="ALLAPPROVALSISSUEDFLAG" HeaderText="All Approval Issued" Visible="false"></asp:BoundField>
                                                            <asp:BoundField DataField="Activity Proposed" HeaderText="Activity Proposed" />
                                                            <asp:BoundField DataField="Line of Activity" HeaderText="Line of Activity" />
                                                            <asp:BoundField DataField="Total Investment (in Crores)" 
                                                                HeaderText="Total Investment (in Crores)" />
                                                            <asp:BoundField DataField="Date of application" 
                                                                HeaderText="Date of application" />
                                                            <asp:TemplateField HeaderText="View Status">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hypLetter0" runat="server" Target="_blank"> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
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
                                                <td align="left" colspan="3" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:GridView ID="grdRenewal" runat="server" AllowPaging="False"
                                                        AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" Height="62px"
                                                        OnRowDataBound="grdRenewal_RowDataBound" PageSize="15" ShowFooter="True"
                                                        Width="100%">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid0" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid0" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="UID" HeaderText="UID" />
                                                            <asp:BoundField DataField="Name of the Industry"
                                                                HeaderText="Name of the Industry" />
                                                             <asp:BoundField DataField="District" HeaderText="District"></asp:BoundField>
                                                            <asp:BoundField DataField="INCENTIVESAPPLIED" HeaderText="Applied for Incentive"></asp:BoundField>
                                                            <asp:BoundField DataField="ALLAPPROVALSISSUEDFLAG" HeaderText="All Approval Issued" Visible="false"></asp:BoundField>
                                                            <asp:BoundField DataField="Activity Proposed" HeaderText="Activity Proposed" />
                                                            <asp:BoundField DataField="Line of Activity" HeaderText="Line of Activity" />
                                                            <asp:BoundField DataField="Total Investment (in Crores)"
                                                                HeaderText="Total Investment (in Crores)" />
                                                            <asp:BoundField DataField="Date of application"
                                                                HeaderText="Date of application" />
                                                            <asp:TemplateField HeaderText="View Status">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hypLetter0" runat="server" Target="_blank"> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
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
                                                    <td align="left" colspan="3">
                                                        <asp:GridView ID="grdPlot" CssClass="" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                            CellPadding="4" Height="62px" OnRowDataBound="grdPlot_RowDataBound"  
                                                            PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px" GridLines="Both">
                                                            <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                            <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Appid" ItemStyle-HorizontalAlign="Center" HeaderText="Application No">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRmTypeid" Text='<%#Eval("intstageid") %>' runat="server" Visible="false" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="firmname" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="DistrictName" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="indparkid" ItemStyle-HorizontalAlign="Center" HeaderText="Industrialpark Name">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="plotno" ItemStyle-HorizontalAlign="Center" HeaderText="Plot No">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="Applicationfileddate" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-HorizontalAlign="Center" HeaderText="Application Filed Date">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>

                                                                <asp:TemplateField HeaderText="Queries Count" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkQueryCount" runat="server" Text='<%#Eval("QueryCount")%>' PostBackUrl='<%#Eval("Appid","QueryResponse.aspx?Appid={0}")%>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <center>
                                                                            <asp:Button ID="anchortaglin" runat="server" Text='<%#("ColumnName") %>' Visible="false" CssClass="btn btn-primary" OnClick="anchortaglin_Click" CommandArgument=" <%# Container.DataItemIndex + 1%>" />
                                                                        </center>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;<tr>
                                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                       <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
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
