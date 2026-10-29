<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmFeedBackChangestatus.aspx.cs" Inherits="UI_TSiPASS_frmFeedBackChangestatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div align="left">
        <ol class="breadcrumb">
            You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
            <li class="">
                <i class="fa fa-fw fa-edit">CAF</i>
            </li>
            <li class="active">
                <i class="fa fa-edit"></i><a href="#">FeedBack Details</a>
            </li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title"></h3>
                    </div>
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top" id="tblstatus">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr id="Tr1" runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px" class="style11">
                                                            <asp:Label ID="Lblstatus1" runat="server" CssClass="LBLBLACK" Width="108px">Process</asp:Label>
                                                        </td>
                                                        <td class="style10" style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Labelcolun1" runat="server" CssClass="LBLBLACK" Width="10px">:</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            <asp:DropDownList ID="ddlstatus" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px"
                                                                TabIndex="1"
                                                                ValidationGroup="group" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" AutoPostBack="true">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem>Closed with Reply</asp:ListItem>
                                                                <asp:ListItem>Closed without Reply</asp:ListItem>
                                                                <%--<asp:ListItem>Forward</asp:ListItem>--%>
                                                                <%--    <asp:ListItem>Rejected</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>

                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            <asp:RequiredFieldValidator ID="ReqfvStatus" runat="server"
                                                                ControlToValidate="ddlstatus" ErrorMessage="Please Select Status"
                                                                ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                        </td>


                                                    </tr>
                                                    <tr id="trreplyremarks" runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            <asp:Label ID="LblRemarks" runat="server" CssClass="LBLBLACK" Width="108px">Reply Remarks</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            <asp:Label ID="Labelcolun2" runat="server" CssClass="LBLBLACK" Width="10px">:</asp:Label>
                                                        </td>
                                                        <td class="style12" style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="TxtRemarks" runat="server" class="form-control txtbox"
                                                                Height="58px" MaxLength="360" TabIndex="1" ValidationGroup="group"
                                                                Width="250px" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="reqfvRemarks" runat="server"
                                                                ControlToValidate="TxtRemarks" ErrorMessage="Please Enter Remarks"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="trreplyfile" runat="server" visible="false">
                                                        <td class="style17" style="padding: 5px; margin: 5px">Reply File</td>
                                                        <td class="style17" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style12" style="padding: 5px; margin: 5px">
                                                            <asp:FileUpload ID="FileUpload" runat="server" class="form-control txtbox"
                                                                Height="28px" />
                                                            <asp:HyperLink ID="lblFileName1" runat="server" CssClass="LBLBLACK"
                                                                Target="_blank" Width="165px">[lblFileName]</asp:HyperLink>
                                                            <br />
                                                            <asp:Label ID="Label560" runat="server" Visible="False"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>


                                        </tr>

                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td class="style11" style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Lblforward" runat="server" CssClass="LBLBLACK" Width="108px">Forward To</asp:Label>
                                                        </td>
                                                        <td class="style10" style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Labelcolun3" runat="server" CssClass="LBLBLACK" Width="10px">:</asp:Label>
                                                        </td>
                                                        <td class="style17" style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlforward" runat="server" class="form-control txtbox"
                                                                Height="33px" TabIndex="1" Width="180px">
                                                                <asp:ListItem Value="1213">Commisioner</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="style17" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        <td class="style17" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        <td class="style17" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        <td class="style12" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td valign="middle" align="center" colspan="3" style="text-align: center">
                                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                                                    Height="32px" TabIndex="10" Text="Submit"
                                                    Width="90px" OnClick="BtnSave_Click" ValidationGroup="group" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                Text="Clear" ToolTip="To Clear  the Screen" Width="90px" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnforward" runat="server" CssClass="btn btn-primary"
                                                    Height="32px" TabIndex="10" Text="Forward"
                                                    Width="90px" ValidationGroup="group" OnClick="btnforward_Click" Visible="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                            <td style="width: 27px">&nbsp;</td>
                                            <td valign="top">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" colspan="3"
                                                align="center">
                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana"
                                                    Font-Size="13px" ForeColor="#006600"></asp:Label>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3" align="center">
                                                        <asp:Label ID="lblprevstatus" runat="server" Font-Bold="True"
                                                            Font-Names="verdana" Font-Size="13px" ForeColor="Black">Previous Status Details</asp:Label>
                                                        <tr>
                                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                                <asp:GridView ID="grdDetails" runat="server" AllowPaging="True"
                                                                    AutoGenerateColumns="False" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                    GridLines="None" Height="62px"
                                                                    OnPageIndexChanging="grdDetails_PageIndexChanging"
                                                                    OnRowDataBound="grdDetails_RowDataBound" PageSize="15" Width="100%">
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left"
                                                                        VerticalAlign="Middle" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                                        <asp:BoundField DataField="User_id" HeaderText="Status Changed By" />
                                                                    </Columns>
                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                                                        ForeColor="White" />
                                                                    <EditRowStyle BackColor="#B9D684" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                                <tr>
                                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                                                    </td>
                                                                </tr>
                                                                <caption>
                                                                    &nbsp;<table align="center" border="0">
                                                                        <tr>
                                                                            <td align="left" width="150">
                                                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana"
                                                                                    Font-Size="12px" ForeColor="#404040" Text="Industry Name"></asp:Label>
                                                                            </td>
                                                                            <td align="center" width="20">
                                                                                <strong><span>:</span></strong></td>
                                                                            <td align="left">
                                                                                <asp:Label ID="LblInd" runat="server" Font-Names="Verdana" Font-Size="Small"
                                                                                    Width="200px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" class="style18">
                                                                                <asp:Label ID="lblLocality" runat="server" Font-Bold="True"
                                                                                    Font-Names="Verdana" Font-Size="12px" ForeColor="#404040" Text="Email"></asp:Label>
                                                                            </td>
                                                                            <td align="center" width="20">
                                                                                <strong><span>:</span></strong></td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEmail" runat="server" Font-Names="Verdana" Font-Size="Small"
                                                                                    Width="200px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana"
                                                                                    Font-Size="12px" ForeColor="#404040" Text="District Name"></asp:Label>
                                                                            </td>
                                                                            <td align="center">
                                                                                <strong><span>:</span></strong></td>
                                                                            <td align="left">
                                                                                <asp:Label ID="LblDist" runat="server" Font-Names="Verdana" Font-Size="Small"
                                                                                    Width="200px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" class="style18">
                                                                                <asp:Label ID="lable2" runat="server" Font-Bold="True" Font-Names="Verdana"
                                                                                    Font-Size="12px" ForeColor="#404040" Text="Mobile Number"></asp:Label>
                                                                            </td>
                                                                            <td align="center">
                                                                                <strong><span>:</span></strong></td>
                                                                            <td align="left">
                                                                                <asp:Label ID="LblMob" runat="server" Font-Names="Verdana" Font-Size="Small"
                                                                                    Width="200px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                       
                                                                        <tr>
                                                                            <td align="left">&nbsp;</td>
                                                                            <td align="center">&nbsp;</td>
                                                                            <td align="left" colspan="4">&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">
                                                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Verdana"
                                                                                    Font-Size="12px" ForeColor="#404040" Text="Description" ToolTip="Description"
                                                                                    Width="112px"></asp:Label>
                                                                            </td>
                                                                            <td align="center">
                                                                                <strong><span>:</span></strong></td>
                                                                            <td align="left" valign="bottom">
                                                                                <asp:Label ID="LblDesc" runat="server" Font-Names="Verdana" Font-Size="Small"
                                                                                   ></asp:Label>
                                                                            </td>
                                                                            <td align="left" class="style18">
                                                                                <asp:Label ID="lbldate" runat="server" Font-Bold="True" Font-Names="Verdana"
                                                                                    Font-Size="12px" ForeColor="#404040" Text="Date"></asp:Label>
                                                                            </td>
                                                                            <td align="center">
                                                                                <strong><span>:</span></strong></td>
                                                                            <td align="left">&nbsp;
                                                                                <asp:Label ID="lblgreivancedate" runat="server" Font-Names="Verdana" Font-Size="Small"
                                                                                    Width="200px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">&nbsp;</td>
                                                                            <td align="center">&nbsp;</td>
                                                                            <td align="left" colspan="4">&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label439" runat="server" Font-Bold="True" Font-Names="Verdana"
                                                                                    Font-Size="12px" ForeColor="#404040" Text="Attachment"
                                                                                    ToolTip="Grievance File" Width="112px"></asp:Label>
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                <strong><span>:</span></strong></td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:HyperLink ID="HyperLinkGriev" runat="server" Target="_blank">HyperLink</asp:HyperLink>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="center">
                                                                            <td align="center" colspan="6">&nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                </caption>
                                                            </td>
                                                        </tr>
                                                    </td>
                                                </tr>
                                            </td>
                                        </tr>

                                    </table>
                                    </td>
                                </tr>
                            </table>

                    </div>

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


    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

