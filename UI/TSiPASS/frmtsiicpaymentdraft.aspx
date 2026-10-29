<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmtsiicpaymentdraft.aspx.cs" Inherits="UI_TSIPASS_frmtsiicpaymentdraft" %>

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

        .CS {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
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
            color: #FF3300;
        }

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .GRD {
            width: 800px;
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 5px;
        }

        .GRDHEADER {
            border: 1px solid #1d9a5b;
            color: #1d9a5b;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url('../../Resource/Styles/images/bg_blue_grd.gif');
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/ /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }

        .LBLBLACK {
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <%-- <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Departments</a> </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <%--<div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Departments</h3>
                            </div>--%>
                <table style="width: 100%">
                    <tr>
                        <td>
                            <div class="col-md-12">
                                <h1 class="page-head-line" align="left" style="font-size: x-large">Payment</h1>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-size: 13pt" valign="top" class="style8"></td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <div style="width: 100%">
                                                        <div style="width: 100%">
                                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                ForeColor="#333333" Height="62px"
                                                                Width="100%" OnRowDataBound="grdDetails_RowDataBound">
                                                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
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
                                                                    <asp:BoundField DataField="distid" HeaderText="District" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField DataField="indparkid" HeaderText="Industrial Park" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField DataField="plotno" HeaderText="Plot No" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField DataField="sqmts" HeaderText="Area (In Sq. Mtrs)" ItemStyle-HorizontalAlign="Right" />
                                                                    <asp:BoundField DataField="price" HeaderText="Price (In Rs.)" ItemStyle-HorizontalAlign="Right" />
                                                                    <asp:BoundField DataField="emd" HeaderText="EMD (In Rs.)" ItemStyle-HorizontalAlign="Right" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center" class="style7">&nbsp;
                                                </td>
                                            </tr>

                                        </table>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%--   </div>--%>
                        </td>
                    </tr>


                    <tr>
                        <td style="padding: 5px; margin: 5px" align="center" class="style7"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="4" cellspacing="5" style="width: 83%" runat="server" id="paynotOnline">
                                <tr id="amt0" runat="server">
                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="200px">Amount<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:TextBox ID="TxtAmountOnline" runat="server" class="form-control txtbox" Enabled="False"
                                            Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                            Width="180px"></asp:TextBox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtAmountOnline"
                                            ErrorMessage="Please enter Amount" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                    </td>
                                    <td id="Td1" style="padding: 5px; margin: 5px; text-align: left;" colspan="4" runat="server">
                                        <asp:RadioButtonList ID="rdbOnlineBankType" runat="server" Font-Bold="True" Font-Names="Verdana"
                                            RepeatDirection="Horizontal"
                                            Width="350px">
                                            <%--  <asp:ListItem  Selected="True">SBI</asp:ListItem>
                                                    <asp:ListItem>ICICI</asp:ListItem>--%>
                                            <%--<asp:ListItem Value="Billdesk">Bill desk</asp:ListItem>--%>
                                            <asp:ListItem Selected="True" Value="Kotak">Kotak Payment Gateway</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                    </td>
                                    <td align="left" id="trbuilddesc" runat="server" visible="false">
                                        <asp:CheckBox ID="chkBuilldesc" runat="server" Text="" Checked="True" Enabled="false" /><img alt="Builddesc" src="../../images/billdesk.png" width="140px" height="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                        <b>Terms and Conditions:
                                                    <br />
                                        </b>
                                        <br />
                                        1. Do not press F5 or refresh the page while the transaction is in process.
                                                <br />
                                        2. Do not press back button while the transaction is in process
                                                <br />
                                        3. Only the transactions with “Successful” status message will be deemed to be received
                                                <br />
                                        4. In case the transaction is not “Successful” and the amount has been debited from
                                                your account and any other queries, please contact the Toll free number: 7306-600-600
                                                or upload a grievance.
                                                <br />
                                        5. There is no refund policy for the payment. But if any excess amount is paid,
                                                it would be adjusted in the future payments.
                                                <br />
                                        6. All the details regarding the payments are secure and confidential. We do not
                                                store the bank details entered by the entrepreneur.
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;" colspan="2">
                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                TabIndex="10" Text="Pay" ValidationGroup="group" Width="90px"
                                Visible="False" />
                            &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Height="32px"
                                OnClick="BtnClear0_Click" TabIndex="10" Text="Pay" Width="200px" ValidationGroup="group" />
                            &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                Width="90px" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                        <asp:HiddenField ID="hdfUIDNumber" runat="server" />
                    </tr>

                </table>
            </div>

        </div>
    </div>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

