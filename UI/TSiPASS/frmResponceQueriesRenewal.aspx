<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmResponceQueriesRenewal.aspx.cs" Inherits="UI_TSiPASS_frmResponceQueriesRenewal" %>

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
                                        <tr>
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
                                        <tr>
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
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">9</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Query Response*</td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtdiscription" runat="server" class="form-control txtbox" Height="40px"
                                                    TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">10&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">Reponse  Attachment<font 
                                                            color="red">*</font></asp:Label>
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
</asp:Content>

