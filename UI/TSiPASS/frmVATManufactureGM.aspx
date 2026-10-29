
<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmVATManufactureGM.aspx.cs" Inherits="TSTBDCReg1" %>

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
    
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
</script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">VAT Details(Manufacture Sector )</a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    VAT Details(Manufacture Sector)</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="7" cellspacing="7" width="100%">
                                                        <tr>
                                                            <td valign="top">
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="180px">Enterprise 
                                                                Name</asp:Label>
                                                            </td>
                                                            <td>
                                                                :</td>
                                                            <td>
                                                                <asp:TextBox ID="TxtnameofUnit" runat="server" AutoPostBack="True" 
                                                                    class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:Label ID="Label380" runat="server" CssClass="LBLBLACK" Width="180px">TIN Number</asp:Label>
                                                            </td>
                                                            <td valign="top">
                                                                :</td>
                                                            <td valign="top">
                                                                <asp:TextBox ID="TxtIECNumber" runat="server" AutoPostBack="True" 
                                                                    class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td valign="top">
                                                                &nbsp;</td>
                                                            <td valign="top">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:Label ID="Label383" runat="server" CssClass="LBLBLACK" Width="180px">Commodity</asp:Label>
                                                            </td>
                                                            <td>
                                                                :</td>
                                                            <td>
                                                                <asp:TextBox ID="TxtCommodity" runat="server" AutoPostBack="True" 
                                                                    class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:Label ID="Label384" runat="server" CssClass="LBLBLACK" Width="180px">Status</asp:Label>
                                                            </td>
                                                            <td valign="top">
                                                                :</td>
                                                            <td valign="top">
                                                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="1" Width="170px" ValidationGroup="group">
                                                                    <asp:ListItem>--All--</asp:ListItem>
                                                                    <asp:ListItem>Updated</asp:ListItem>
                                                                    <asp:ListItem>Not Updated</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td align="center" colspan="3">
                                                                &nbsp;</td>
                                                            <td valign="top">
                                                                &nbsp;</td>
                                                            <td valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                                    ControlToValidate="ddlStatus" ErrorMessage="Please Select Status" 
                                                                    InitialValue="--All--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td align="center" colspan="3" style="text-align: center">
                                                                <asp:Button ID="BtnSave2" runat="server" 
                                                                    CssClass="btn-success" Height="32px" onclick="BtnClear0_Click" TabIndex="10" 
                                                                    Text="Search" ValidationGroup="group" Width="80px" />
                                                                &nbsp;
                                                                <asp:Button ID="BtnSave3" runat="server" CausesValidation="False" 
                                                                    CssClass="btn-success" Height="32px" onclick="BtnSave3_Click" TabIndex="10" 
                                                                    Text="Cancel" ValidationGroup="group" Width="80px" />
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;</td>
                                                            <td valign="top">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" 
                                                        CellPadding="5" ForeColor="#333333" Height="62px" 
                                                        OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True" Width="100%" 
                                                        AllowPaging="True" onpageindexchanging="grdDetails_PageIndexChanging" 
                                                        PageSize="20">
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
                                                         
                                                            <asp:BoundField DataField="EnterpriseName" HeaderText="Enterprise Name" />
                                                            <asp:BoundField DataField="TINNumber" HeaderText="TINNumber" 
                                                                 />
                                                            <asp:BoundField DataField="EnterpriseAddress" HeaderText="Enterprise Address" />
                                                            <asp:BoundField DataField="OwnerName" HeaderText="Owner Name" />
                                                            <asp:BoundField DataField="States_exported_to" HeaderText="Status of Exporter" />
                                                            <asp:BoundField DataField="Commodities" 
                                                                HeaderText="Commodity" />
                                                                   <asp:BoundField DataField="MobileNumber" 
                                                                HeaderText="Mobile Number" />
                                                                
                                                                   <asp:BoundField DataField="BusinessActivity" 
                                                                HeaderText="Business Activity" />
                                                                
                                                                 
                                                            <asp:HyperLinkField HeaderText="Update" Text="Update" />
                                                           
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
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    &nbsp;<tr>
                                                        <td align="center" style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                            ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
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
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
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
