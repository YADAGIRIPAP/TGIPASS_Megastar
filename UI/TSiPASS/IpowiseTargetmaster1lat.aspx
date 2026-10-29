<%@ Page Title=":: TSiPASS :: IPO " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" EnableEventValidation="true" CodeFile="IpowiseTargetmaster1lat.aspx.cs" Inherits="AddPayams" %>

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
        .style6
        {
            width: 50px;
        }
        .style7
        {
            width: 2px;
        }
    </style>

    



<script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupIpowiseTarget.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

        }
        function getChildControl() {
            if (win != null && !win.closed) {

                var form1 = win.document.getElementsbyId("ctl00_ContentPlaceHolder1_hdfID").value;
                alert(form1);
            }
        }

        function Load_hdfID(val) {
            win.close();
            $get("ctl00_ContentPlaceHolder1_hdfID").value = val;
            __doPostBack("LOOKUP", val);
            alert(val);
        }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a> </li>
                    <li class=""><i class="fa fa-fw fa-table"></i>Masters </li>
                    <li class="active">&nbsp;</li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    IPO WISE TARGET MASTER</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" colspan="3" align="center">
                                            <asp:Label ID="Label347" runat="server" CssClass="LBLBLACK" Width="100px">Search</asp:Label>
                                            <asp:Button ID="btnOrgLookup0" runat="server" CssClass="btn btn-primary" Height="32px"
                                                OnClientClick="OpenPopup();" Text="Look Up" CausesValidation="False" TabIndex="1"
                                                Font-Size="12px" Style="position: static" ToolTip="Rate Lookup" 
                                                onclick="btnOrgLookup0_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 0px;">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="165px">Month</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlmonth" runat="server" class="form-control txtbox" TabIndex="3"
                                                            Height="33px" Width="180px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlmonth_SelectedIndexChanged">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">January</asp:ListItem>
                                                            <asp:ListItem Value="2">February</asp:ListItem>
                                                            <asp:ListItem Value="3">March</asp:ListItem>
                                                            <asp:ListItem Value="4">April</asp:ListItem>
                                                            <asp:ListItem Value="5">May</asp:ListItem>
                                                            <asp:ListItem Value="6">June</asp:ListItem>
                                                            <asp:ListItem Value="7">July</asp:ListItem>
                                                            <asp:ListItem Value="8">August</asp:ListItem>
                                                            <asp:ListItem Value="9">September</asp:ListItem>
                                                            <asp:ListItem Value="10">October</asp:ListItem>
                                                            <asp:ListItem Value="11">November</asp:ListItem>
                                                            <asp:ListItem Value="12">December</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" class="style7">
                                                        &nbsp;
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                            ControlToValidate="ddlmonth" ErrorMessage="Please select Month" 
                                                            InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="style6">
                                            <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="65px"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 0px;">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label365" runat="server" CssClass="LBLBLACK" Width="113px">Year</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" Height="33px"
                                                            OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" TabIndex="4" 
                                                            Width="180px" AutoPostBack="True">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                            ControlToValidate="ddlYear" ErrorMessage="Please select Year" 
                                                            InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                            &nbsp;
                                            <asp:GridView ID="gvCertificate0" runat="server" AllowPaging="True" 
                                                AutoGenerateColumns="False" CellPadding="4" CssClass="GRD" ForeColor="#333333" 
                                                Height="62px" onpageindexchanging="grdDetails_PageIndexChanging" 
                                                OnRowDataBound="grdDetails_RowDataBound" PageSize="20" 
                                                ShowFooter="True" Width="100%" DataKeyNames="intUserid">
                                                <RowStyle BackColor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <Columns>
                                                    <%--<asp:BoundField DataField="SLNo" HeaderText="SLNo" />--%>
                                                    <%-- <asp:BoundField DataField="incentive" HeaderText="Type of Incentive" />--%>
                                                    
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                        
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Dept_Name" HeaderText="IPO Name" />
                                                    <asp:TemplateField HeaderText="Bank Visit-I">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txttargetBanvisit1" runat="server" class="form-control txtbox" 
                                                                Height="28px" MaxLength="5" onkeypress="NumberOnly()" 
                                                                OnTextChanged="txttargetBanvisit1_TextChanged" TabIndex="5" ValidationGroup="group" 
                                                                Width="100px" AutoPostBack="True"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Bank Visit-II">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txttargetBankvisit2" runat="server" class="form-control txtbox" 
                                                                Height="28px" MaxLength="5" onkeypress="NumberOnly()" 
                                                                OnTextChanged="txtMSName_TextChanged" TabIndex="5" ValidationGroup="group" 
                                                                Width="100px" Enabled="False"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Vehicle Inspection">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txttargetVehicleInsp" runat="server" class="form-control txtbox" 
                                                                Height="28px" MaxLength="5" onkeypress="NumberOnly()" 
                                                                OnTextChanged="txtMSName_TextChanged" TabIndex="5" ValidationGroup="group" 
                                                                Width="100px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PMEGP &amp;amp; Mudra">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txttargetPMEGP" runat="server" class="form-control txtbox" 
                                                                Height="28px" MaxLength="5" onkeypress="NumberOnly()" 
                                                                OnTextChanged="txtMSName_TextChanged" TabIndex="5" ValidationGroup="group" 
                                                                Width="100px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Closed Units">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txttargetClosedUnits" runat="server" class="form-control txtbox" 
                                                                Height="28px" MaxLength="5" onkeypress="NumberOnly()" 
                                                                OnTextChanged="txtMSName_TextChanged" TabIndex="5" ValidationGroup="group" 
                                                                Width="100px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Industry Catelouge">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txttargetIndustryCatelog" runat="server" class="form-control txtbox" 
                                                                Height="28px" MaxLength="5" onkeypress="NumberOnly()" 
                                                                OnTextChanged="txtMSName_TextChanged" TabIndex="5" ValidationGroup="group" 
                                                                Width="100px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit Inspection">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txttargetUnitInsp" runat="server" class="form-control txtbox" 
                                                                Height="28px" MaxLength="5" onkeypress="NumberOnly()" 
                                                                OnTextChanged="txtMSName_TextChanged" TabIndex="5" ValidationGroup="group" 
                                                                Width="100px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#013161" cssclass="GRDHEADER" Font-Bold="True" 
                                                    ForeColor="White" />
                                                <EditRowStyle BackColor="#B9D684" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                OnClick="BtnSave_Click" TabIndex="6" Text="Save" ValidationGroup="group" Width="90px" />&nbsp;&nbsp;<asp:Button
                                                    ID="BtnCancel" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                    Height="32px" OnClick="BtnClear0_Click" TabIndex="7" Text="Cancel" Width="90px"
                                                    OnClientClick="return confirm('Do you want to delete the record ? ');" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                            &nbsp;
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
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 10px; opacity: 1; -moz-opacity: 1;">
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
