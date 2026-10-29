<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="SWGDeptDashboardDrillDown.aspx.cs" Inherits="UI_TSiPASS_SWGDeptDashboardDrillDown" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

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
        }
    </script>
    <script type="text/javascript" language="javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;

            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 46 && charCode != 47) {
                return true;
            }
            return false;
        }
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">View Applications</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">View Applications</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                                            ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True"
                                                            Width="100%">
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>                                                                      
                                                                        <asp:HiddenField ID="hdfApplID" Value='<%# Eval("SCD_QDID") %>'  runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="View" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" ></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="SCD_PTINNO" HeaderText="PTIN Number  " />
                                                                <asp:BoundField DataField="SCD_PTINNAME" HeaderText="PTIN Name" />
                                                                <asp:BoundField DataField="SCD_PTINCATEGORY" HeaderText=" PTIN Category" />
                                                                <asp:BoundField DataField="SCD_DISTRICT" HeaderText="District" />
                                                                <asp:BoundField DataField="SCD_MUNICIPALITY" HeaderText="Municipality" />
                                                                <asp:BoundField DataField="SCD_PTINMOBILENO" HeaderText="Mobile" />
                                                                 <asp:BoundField DataField="SCD_CANWATER" HeaderText="CAN Number" />
                                                                <asp:BoundField DataField="SCD_PTINOWNERNAME" HeaderText="CAN Owner Name" />
                                                                <asp:BoundField DataField="SCD_PTINCANCATEGORY" HeaderText="CAN Category" />
                                                                   <asp:BoundField DataField="address" HeaderText="Address" />
                                                                <asp:TemplateField HeaderText="Status">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label377" runat="server" CssClass="LBLBLACK" Width="180px">Status</asp:Label>
                                                                        <br />
                                                                        <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                            Height="33px" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" Width="180px">
                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                            <asp:ListItem Value="12">Completed</asp:ListItem>
                                                                            <asp:ListItem Value="11">Completed with Payment Request</asp:ListItem>
                                                                            <asp:ListItem Value="5">Query Raised</asp:ListItem>
                                                                            <asp:ListItem Value="16">Rejected</asp:ListItem>
                                                                        </asp:DropDownList>

                                                                        <br />
                                                                        <asp:Label ID="LabelDiscription" Font-Bold="true" ForeColor="Red" runat="server"
                                                                            CssClass="LBLBLACK" Visible="False" Width="180px" Text=""></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Visible="False" Width="180px"
                                                                            Text="Query Description"></asp:Label>
                                                                        <br />
                                                                        <asp:TextBox ID="txtPromotor" runat="server" class="form-control txtbox" Height="40px"
                                                                            TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Visible="False" Width="180px">
                                                                        </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPromotor"
                                                                            ErrorMessage="Please Enter Discription" TabIndex="1" ValidationGroup="group">
                                                                        *</asp:RequiredFieldValidator>
                                                                        <br />
                                                                        <asp:Label ID="Label379" runat="server" CssClass="LBLBLACK" Visible="False" Width="180px">Amount</asp:Label>
                                                                        <br />
                                                                        <asp:TextBox ID="txtAmount" runat="server" class="form-control txtbox" Height="27px"
                                                                            MaxLength="40" TabIndex="1" ValidationGroup="group" onkeypress="return inputOnlyNumbers(event)"
                                                                            Visible="False" Width="180px" onpaste="return false">
                                                                        </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmount"
                                                                            ErrorMessage="Please Enter Amount" TabIndex="1" ValidationGroup="group">                        *</asp:RequiredFieldValidator>
                                                                        <br />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Submit">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="BtnSave" runat="server" CausesValidation="False" CssClass="btn-success"
                                                                            Height="32px" OnClick="BtnSave_Click" OnClientClick="return confirm('Do you want to update the record ? ');"
                                                                            TabIndex="10" Text="Submit" ValidationGroup="group" Width="80px" />

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                               
                                                                <asp:BoundField Visible="false" DataField="ReasonForRejection" HeaderText="Reason For Rejection" />

                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
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

</asp:Content>

