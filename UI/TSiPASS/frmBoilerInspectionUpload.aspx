<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmBoilerInspectionUpload.aspx.cs" Inherits="UI_TSiPASS_frmBoilerInspectionUpload" %>

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

        .style6 {
            width: 192px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
    <%-- </div>
       </td>
        </tr>
    </table>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
            <li class="">
                <i class="fa fa-fw fa-edit">CFO</i>
            </li>
            <li class="active">
                <i class="fa fa-edit"></i><a href="#">Queries Respond Details</a>
            </li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Query Response Details</h3>
                    </div>
                    <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="210px">Responce Query</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">UID Number<font 
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
                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="210px">Name of Industry<font 
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
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Enterprise Type<font 
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
                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="410px">Polution Category<font 
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
                                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="165px">Department Name<font 
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
                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="410px">Department Approval<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label452" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">7</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="410px">Query Raise Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label453" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">8</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="410px">Query Description<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label454" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top" colspan="4">
                                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="True"
                                                    Width="100%" BorderColor="Black">
                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                                        <asp:BoundField DataField="StatusDate" HeaderText="Status Date" />
                                                        <asp:TemplateField HeaderText="Download">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hprlink" runat="server" Text="Document" NavigateUrl='<%#Eval("Document") %>' Target="_blank"></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>

                                            </td>
                                        </tr>
                                        <tr id="trboilerstagesdropdown" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">7</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Status*</td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlBoilerStages" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" AutoPostBack="True">
                                                    <%--<asp:ListItem>--District--</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <%-- <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">9</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Query Response*</td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtdiscription" runat="server" class="form-control txtbox" Height="40px"
                                                    TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>--%>
                                        <tr id="rescduleINSdate" visible="false" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">8</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"> Thorough examination date*</td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtInspection" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="13" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr id="rescdulehrddate" visible="false" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">9</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Hydraulic Test date</td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txthydraulic" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="13" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtRegDate"
                                                                    TargetControlID="txtRegDate">
                                                                </cc1:CalendarExtender>--%>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>

                                        <tr id="reschdule" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">10&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">Upload Documents<font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                                <asp:HyperLink ID="lblFileNameResponse" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameResponse]</asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button6" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                    Width="72px" OnClick="Button6_Click" />
                                            </td>
                                        </tr>

                                        <tr id="truploadrepairer" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">10&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Upload Repairer Details Attachment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fileuploadrepairerdetails" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="lblrepairerdetails" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                                <asp:HyperLink ID="hyperlinkrepairerdetails" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnrepairerdetails" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                    Width="72px" OnClick="btnrepairerdetails_Click" />
                                            </td>
                                        </tr>

                                        <tr id="truploadCompletion" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">10&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Upload Completion Report Attachment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fileuploadploadCompletion" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                                <asp:HyperLink ID="hyperlinkploadCompletion" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnploadCompletion" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                    Width="72px" OnClick="btnploadCompletion_Click" />
                                            </td>
                                        </tr>

                                        <tr id="trInspection" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">10&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">Upload Certificate(Annexure-I)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fileuploadInspection" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                                <asp:HyperLink ID="hyperlinkInspection" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnInspection" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                    Width="72px" OnClick="btnInspection_Click" />
                                            </td>
                                        </tr>

                                        <tr id="trirRelavent" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">11</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Upload Inspection Report (Annexure-II)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fileuploadirRelavent" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                                <asp:HyperLink ID="hyperlinkirRelavent" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnirRelavent" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                    Width="72px" OnClick="btnirRelavent_Click" />
                                            </td>
                                        </tr>

                                        <tr id="trformv" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">12</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="165px">Other Relavent Documents<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fileuploadformv" runat="server" class="form-control txtbox" />
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                                <asp:HyperLink ID="hyperlinkformv" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnformv" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                    Width="72px" OnClick="btnformv_Click" />
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

                            <tr>
                                <td align="center"
                                    style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False"
                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                        Text="Submit" Width="90px"
                                        OnClientClick="return confirm('Do you want to Next the record ? ');" />
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
                    </div>
                    <%--       </ContentTemplate>
</asp:UpdatePanel>--%>
                </div>
            </div>
        </div>

    </div>
    <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>--%>
    <%--<div class="overlay">--%>
    <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
    <%--<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">--%>
    <%--<img alt="" src="../../Resource/Images/Processing.gif" />
    --%>
</div>
    
</div>
    <%--</ProgressTemplate>
</asp:UpdateProgress> --%>

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


    <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
    <%-- </div>
       </td>
        </tr>
    </table>--%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txthydraulic']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txthydraulic']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            width: 250px;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtInspection']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtInspection']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>

</asp:Content>
