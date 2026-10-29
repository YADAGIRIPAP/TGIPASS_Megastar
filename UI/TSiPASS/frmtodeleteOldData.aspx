<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmtodeleteOldData.aspx.cs" Inherits="UI_TSiPASS_frmtodeleteOldData" %>
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
        .style7
        {
            width: 42px;
        }
        .style8
        {
            height: 30px;
        }
        .auto-style1 {
            width: 342px;
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
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Application <span class="text-primary">Details</span></a></li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">To Remove Record from All Approvals
                                    </h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body"> 
                                    <%--<asp:LinkButton ID="IAT" runat="server" PostBackUrl="~/UI/tsipass/IncentiveApplicationTracker.aspx" Text="Incentive Application tracker" > </asp:LinkButton>--%>
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>                                               
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td align="center" style="padding: 5px; margin: 5px">
                                                                1&nbsp;
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Width="150px">UID Number</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style1">
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
                                              <caption>
                                                  <br />
                                                  <br />
                                                  <tr>
                                                      <td align="center" colspan="3" style="text-align: center;">
                                                          <asp:Label ID="lblrecords" runat="server" ForeColor="Red"></asp:Label>
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td align="left" colspan="3" style="padding: 5px; margin: 5px" valign="top">
                                                          <asp:GridView ID="grdDetails" runat="server" AllowPaging="False" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound" PageSize="15" ShowFooter="True" Width="100%">
                                                              <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                              <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                              <Columns>
                                                                  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                      <ItemTemplate>
                                                                          <%# Container.DataItemIndex + 1%>
                                                                         <%-- <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                          <asp:HiddenField ID="HdfApprovalid" runat="server" />--%>
                                                                      </ItemTemplate>
                                                                      <HeaderStyle HorizontalAlign="Center" />
                                                                      <ItemStyle Width="50px" />
                                                                  </asp:TemplateField>
                                                                  <asp:TemplateField Visible="false">
                                                                      <Itemtemplate>
                                                                          <asp:Label ID="lbluid" runat="server" Text='<%# Bind("UID_No") %>'></asp:Label>
                                                                      </Itemtemplate>
                                                                  </asp:TemplateField>
                                                                  <asp:BoundField DataField="UID_No" HeaderText="UID" />
                                                                  <asp:BoundField DataField="UnitName" HeaderText="Name of the Industry" />
                                                                  <asp:BoundField DataField="Activity Proposed" HeaderText="Activity Proposed" />
                                                                  <asp:BoundField DataField="lineofActivity" HeaderText="Line of Activity" />
                                                                  <asp:BoundField DataField="Investment" HeaderText="Total Investment (in Crores)" />
                                                                  <asp:BoundField DataField="Date of application" HeaderText="Date of application" />
                                                                  <asp:TemplateField HeaderText="View Status">
                                                                
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hypLetter" runat="server" Target="_blank"> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="Delete Record">
                                                                      <ItemTemplate>
                                                                          <%--<asp:HyperLink ID="hypLetter" runat="server" Target="_blank"> </asp:HyperLink>--%>
                                                                      <asp:TextBox ID="dltreason" TextMode="MultiLine" Width="200px" Height="40px" runat="server"></asp:TextBox>
                                                                          <asp:Button ID="DltRecord" Text="Delete" CssClass="btn btn-danger"  Width="100px" runat="server" OnClick="DltRecord_Click" />
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
                                                      <td align="left" colspan="3" style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                                  </tr>
                                                  
                                                 
                                                  <tr>
                                                      <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                          <div id="success" runat="server" class="alert alert-success" visible="false">
                                                              <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                          </div>
                                                          <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                              <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                              <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                          </div>
                                                      </td>
                                                  </tr>
                                            </caption>
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
