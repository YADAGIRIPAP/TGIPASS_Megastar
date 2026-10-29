<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmShowcauseReply.aspx.cs" Inherits="UI_TSiPASS_frmShowcauseReply" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="panel-body">
        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

            <tr>

                <td style="padding: 5px; font-weight: bold; float: left; margin: 5px" valign="top">Response to Showcause Notice
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px" valign="top">
                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Udyog Adhaar/IEM No<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label447" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="210px">Name of Industry/Enterprise<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label448" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Type of Sector<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label449" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>

                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="410px">Scheme Applied<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label450" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>

                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;">5</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="410px">Incentives Applied For<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label451" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">6</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">

                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="165px">Showcause Issued by<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label452" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">7</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="410px">Showcause Issued date<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label453" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                         <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">8</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Showcause Letter</td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:HyperLink ID="anchortagGMCertificate" runat="server" Text="Showcause Letter" Font-Bold="true" ForeColor="Green" Target="_blank" />

                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                <asp:Label ID="Label2" Visible="false" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">9</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="410px">GM Delay Reason<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label454" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">10</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Showcause Notice Reply*</td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:TextBox ID="txtdiscription" runat="server" class="form-control txtbox" Height="80px"
                                    TextMode="MultiLine" ValidationGroup="group" Width="250px"></asp:TextBox>

                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                <asp:Label ID="lblDesc" Visible="false" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;">11&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">Attachment<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="Button6" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="Button6_Click" />
                            </td>

                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="10">
                                <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                                    CssClass="GRD" ForeColor="Black" GridLines="Both"
                                    OnRowDeleting="gvCertificate_RowDeleting" Width="50%" BackColor="LightGoldenrodYellow" EnableModelValidation="True">
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                    <Columns>
                                        <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                        <%-- <asp:CommandField HeaderText="DELETE" ItemStyle-Width="100px" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" DeleteText="DELETE" ShowDeleteButton="True" />--%>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfilepath" runat="server" Text='<%# Bind("filepath") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                </asp:GridView>
                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px" valign="top" align="left">&nbsp;</td>
            </tr>
            <caption>
                &nbsp;</caption>
            </td>
                                    </tr>
                                    <tr>
                                        <td align="center"
                                            style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False"
                                                CssClass="btn btn-danger" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                Text="Submit" Width="90px"
                                                OnClientClick="return confirm('Do you want to Submit the record ? ');" />
                                            &nbsp;&nbsp;</td>
                                    </tr>
            <tr>
                <td align="center" style="padding: 5px; margin: 5px">


                    <div id="success" runat="server" visible="false" class="alert alert-success">
                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>


                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <strong>Warning!</strong>
                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdfID" runat="server" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
        <asp:ValidationSummary ID="ValidationSummary2" runat="server"
            ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
        <asp:HiddenField ID="hdfFlagID" runat="server" />
        <asp:HiddenField ID="hdfFlagID0" runat="server" />
        <asp:HiddenField ID="hdfFlagID1" runat="server" />
        <asp:HiddenField ID="hdfFlagID2" runat="server" />
        <br />
        <asp:HiddenField ID="hdfFlagID3" runat="server" />
    </div>

</asp:Content>