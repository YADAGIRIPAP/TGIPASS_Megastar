<%@ Page Title="" Language="C#" MasterPageFile="CCMaster.master" AutoEventWireup="true" CodeFile="Ammendments.aspx.cs" Inherits="UI_TSiPASS_Ammendments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">



        function OpenPopup() {

            window.open("Lookups/MobilizationLookup.aspx", "List", "scrollbars=yes,resizable=yes,width=900,height=750");

            return false;
        }


        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }

        function DecimalOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter DecimalValues Only");
            }
        }


        function AlphaNumericOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets,  and Characters  Only");
            }
        }

    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration1]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration2]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtsurveynum]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtExtent]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('input[id$=txtCJFSBeneficiery]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });


    </script>

    <style>
        .CS {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }
    </style>
    <%--   <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="index.html">Dashboard</a> </li>
            <li class=""><i class="fa fa-fw fa-table"></i>Helpdesk </li>
            <li class="active"><i class="fa fa-edit"></i>View Status </li>
        </ol>
    </div>
    <div align="center">
        <div class="row" align="center">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">DEPARTMENT AMENDMENTS</h3>
                    </div>
                    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                    <div class="panel-body">
                        <table style="vertical-align: top; text-align: center;" cellpadding="5" cellspacing="10"
                            width="100%">

                            <tr id="tramendentype" runat="server">
                                <td style="padding: 5px; margin: 5px; text-align: left;">Regulation Type</td>

                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:DropDownList ID="ddlamendmenttype" runat="server" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlamendmenttype_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Draft</asp:ListItem>
                                        <asp:ListItem Value="2">Final</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 10px">&nbsp;</td>

                            </tr>

                            <tr id="tramendenname" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px; text-align: left;">Regulation Name</td>

                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:DropDownList ID="ddlAmendment" runat="server" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlAmendment_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 10px">&nbsp;</td>

                            </tr>

                            <tr id="tramentext" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:Label ID="lblammentname" runat="server" Text="Regulation Name"></asp:Label>
                                </td>

                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:TextBox ID="txtAmendmentName" runat="server" class="form-control txtbox"  Width="180px"
                                        Height="28px" MaxLength="200" TabIndex="1"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 10px"></td>

                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:Label ID="lblamendentdate" runat="server" Text="Regulation Date"></asp:Label>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:TextBox ID="txtAmendmentDate" runat="server" class="form-control txtbox" Height="28px"  Width="180px" MaxLength="40" TabIndex="1" ValidationGroup="group" ></asp:TextBox>
                                        <%-- <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtAmendmentDate">
                                    </cc1:CalendarExtender>--%>

                                    </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="right" style="height: 20px"></td>


                            </tr>
                            <tr>
                                <td align="right" style="text-align: left">
                                    <asp:Label ID="lblamendentupload" runat="server" Text="Regulation Upload"></asp:Label>
                                </td>

                                <td colspan="2" align="left" style="text-align: left">
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="CS"
                                        Height="28px" /><font 
                                                            color="red"><strong>(Upload only PDF files)</strong></font>

                                    <%-- <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Width="165px"
                                        Target="_blank">[lblFileName]</asp:HyperLink>--%>
                                    <br />
                                    <asp:Label ID="Label444" runat="server" Visible="true" Font-Bold="true" Font-Size="Large"></asp:Label>
                                    
                                </td>
                            </tr>
                            <tr id="Trdeptamd" runat="server" visible="false">
                                <td align="right" style="text-align: left">
                                    <asp:Label ID="Label1" runat="server" Text="Department Comment Upload"></asp:Label>
                                </td>

                                <td colspan="2" align="left" style="text-align: left">
                                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="CS"
                                        Height="28px" />

                                    <%-- <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Width="165px"
                                        Target="_blank">[lblFileName]</asp:HyperLink>--%>
                                    <br />
                                    <asp:Label ID="Label2" runat="server" Visible="true" Font-Bold="true" Font-Size="Large"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trusercomments" runat="server" visible="false" align="center">
                                <td colspan="5">
                                    <asp:GridView Width="100%" ID="gvComments" runat="server" AutoGenerateColumns="false" border="3" CellPadding="4" CellSpacing="1">
                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle Height="50px" BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUsername" runat="server" Text='<%# Bind("[User Name]") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="District Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDistrict" runat="server" Text='<%# Bind("District") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Mobile No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("[Mobile No]") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Mail Id">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmailid" runat="server" Text='<%# Bind("[Mail Id]") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Ammendment">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmmendment" runat="server" Text='<%# Bind("[Ammendment]") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Comments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblusrcomm" runat="server" Text='<%# Bind("[User Comments]") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Department Comments">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="lbldeptcoments" runat="server" TextMode="MultiLine" Height="80px" Width="300px"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="comid" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamdid" runat="server" Text='<%# Bind("Comment_Id") %>' ></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="right" style="height: 25px"></td>


                            </tr>
                            <tr>
                                <td colspan="3" align="center" style="text-align: center;">


                                    <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning"
                                        Height="28px" TabIndex="10" Text="Upload"
                                        Width="116px" OnClick="BtnSave3_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                            <asp:Button ID="BTNcLEAR" runat="server" CssClass="btn btn-xs btn-warning"
                                                                                Height="28px" TabIndex="10" Text="Clear"
                                                                                Width="82px" OnClick="BTNcLEAR_Click" />
                                </td>

                            </tr>
                            <%--<tr id="Tr1" runat="server">
                                <td colspan="4" align="center" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle; padding-top: 5px; text-align: center"
                                    valign="middle">
                                    <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="11px"
                                        ForeColor="Green" Style="position: static"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr id="Tr1" runat="server">
                                <td colspan="3" align="center" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle; padding-top: 5px; text-align: center"
                                    valign="middle">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblresult" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblerrMsg" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <%--<tr runat="server" id="Reject">
                                <td colspan="4" align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                    valign="middle">
                                    <asp:Label ID="lblerrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="270px"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr colspan="4" runat="server" id="Close">
                                <td align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                    valign="middle">
                                    <asp:Label ID="lblStatus" runat="server" Font-Bold="True" ForeColor="Red" Width="272px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center" style="padding: 5px; vertical-align: middle; height: 35px; text-align: left"
                                    valign="middle">&nbsp; &nbsp;
                                </td>
                            </tr>

                        </table>
                        <br />
                        <asp:ValidationSummary ID="vg" runat="server" ForeColor="Green" ShowMessageBox="True"
                            ShowSummary="False" Style="position: static" ValidationGroup="group" />

                        <asp:HiddenField ID="hdfusercode" runat="server" />
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <br />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>

    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>

    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtAmendmentDate']").datepicker(
               {
                   dateFormat: "yy/mm/dd",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtAmendmentDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "yy/mm/dd",
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
</asp:Content>

