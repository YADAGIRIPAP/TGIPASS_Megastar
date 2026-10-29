<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="SactionViewSLC.aspx.cs" Inherits="UI_TSiPASS_SactionViewSLC" %>

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

        .style10 {
            width: 9px;
            height: 28px;
        }

        .style11 {
            width: 210px;
            height: 28px;
        }

        .style12 {
            width: 212px;
            height: 28px;
        }

        .style13 {
            width: 210px;
            height: 21px;
        }

        .style14 {
            width: 9px;
            height: 21px;
        }

        .style15 {
            height: 21px;
        }

        .style16 {
            width: 212px;
            height: 21px;
        }

        .style17 {
            height: 28px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function sumPropBulk() {
            var txtFirstNumberValue = document.getElementById('txtProsPetorlClassA').value;
            var txtSecondNumberValue = document.getElementById('txtPropPetolClassB').value;
            var txtThirdNumberValue = document.getElementById('txtPropPetolClassB').value;
            var result = parseInt(txtFirstNumberValue) + parseInt(txtSecondNumberValue) + parseInt(txtThirdNumberValue);
            if (!isNaN(result)) {
                document.getElementById('txtPropPetrolTotal').value = result;
            }
        }
    </script>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Incentive Status Upload</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <%--<div class="panel-heading" align="center">
                        <h3 class="panel-title">Incentive Applications <a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                            <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                alt="Excel" /></a>
                        </h3>
                    </div>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 99%">
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <div class="col-md-12">
                                        <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1heading"></h1>
                                    </div>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr id="trno" runat="server">
                                            <td style="padding: 5px; margin: 5px; color: blue; font-weight: bold" valign="top" colspan="12" runat="server" id="tdinvestments"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" colspan="12" align="center">


                                                <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px"
                                                    PageSize="20" Width="90%" Font-Names="Verdana" Font-Size="12px" GridLines="Both">
                                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="NameofUnitAddress" ItemStyle-HorizontalAlign="Center" HeaderText="Name of Unit & Address">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DateofReceipt" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Receipt">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Scheme" ItemStyle-HorizontalAlign="Center" HeaderText="Scheme">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SVCDATE" ItemStyle-HorizontalAlign="Center" HeaderText="SVC Date">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RecommendedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Recommended Amount">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Sactionned Amount">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtsactionnedAmount" Text='<%#Eval("RecommendedAmount") %>' Width="100px" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEnterperIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%-- <asp:TemplateField HeaderText="View Application" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                      
                                                                        <asp:HyperLink ID="anchortaglink" runat="server" Text="View" Font-Bold="true" ForeColor="Green" Target="_blank" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Approved/ Rejected">
                                                            <ItemTemplate>
                                                                <asp:RadioButtonList ID="rbtnLstApprove" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbtnLstApprove_SelectedIndexChanged">
                                                                    <asp:ListItem Value="Y" Selected="True">Approved</asp:ListItem>
                                                                    <asp:ListItem Value="N">Rejected</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:TextBox ID="txtIncQueryFnl2" TextMode="MultiLine" Height="100px" Width="250px" Visible="false" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                                        
                                                    </Columns>

                                                </asp:GridView>

                                            </td>

                                        </tr>
                                        <tr style="height: 30px">
                                            <td>
                                                <table style="width: 80%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" id="tdslcno" runat="server">SLC No </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtslcno" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox></td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" id="tdslcndate" runat="server">SLC Date
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox runat="server" ID="txtslcnodate" class="form-control txtbox" Height="28px"
                                                                MaxLength="80" TabIndex="1" Width="150px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                        <tr style="height: 30px">
                                            <td>
                                                <table style="width: 80%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px;width:140px;"  id="td1" runat="server">Minutes of Meeting :</td>

                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:FileUpload ID="fucMinOfMeet" runat="server" class="form-control txtbox" />
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Button runat="server" Text="Upload" ID="bntUpload" CssClass="btn btn-primary" Style="margin-left: 12px; margin-top: 1px;" OnClick="bntUpload_Click" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="2">
                                                            <asp:HyperLink runat="server" ID="lnkMinOfMeeting" Target="_blank" style="margin-left:262px;"></asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                        <tr style="height:15px;"><td></td></tr>



                                        <tr>
                                            <td style="padding: 5px; margin: 5px" colspan="12" align="center">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    TabIndex="10" Text="SUBMIT" Width="111px" OnClick="btnSubmit_Click" ValidationGroup="group" /></td>
                                        </tr>
                                        <tr style="height: 20px">
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="10">
                                                <asp:GridView ID="gvdetailsfinalproforma" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="True" Width="100%" CellSpacing="4" OnRowDataBound="gvdetailsfinalproforma_RowDataBound">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Name of Unit & Address">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNameofUnitAddress" runat="server" Text='<%#Eval("NameofUnit") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Date of Receipt">
                                                            <ItemTemplate>
                                                                <asp:Label ID="hSLCNumber" runat="server" Text='<%#Eval("DateofApplication") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Recommended Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRecommendedAmount" runat="server" Text='<%#Eval("RecommendedAmount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sactioned Amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSactionedAmount" runat="server" Text='<%#Eval("SanctionedAmount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                         <asp:BoundField DataField="SchemeName" ItemStyle-HorizontalAlign="Center" HeaderText="Scheme">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SLCNumer" ItemStyle-HorizontalAlign="Center" HeaderText="SLC Numer">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SLCDate" ItemStyle-HorizontalAlign="Center" HeaderText="SLCDate">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Masterincentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMstIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Intimation Letter">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortagGMCertificate" Target="_blank" runat="server" Text="View"></asp:HyperLink>
                                                                <asp:Label ID="lbloffiline" Visible="false" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Scheme" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblScheme" Text='<%#Eval("SchemeName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DIPCNumer" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDIPCNumer" Text='<%#Eval("SLCNumer") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="OfflineFlag" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOfflineFlag" Text='<%#Eval("OfflineFlag") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
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
                            </tr>
                        </table>

                    </div>

                </div>
            </div>
        </div>
    </div>
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


            $("input[id$='txtslcnodate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtslcnodate']").datepicker(
            {
                dateFormat: "dd/mm/yy",
                //  maxDate: new Date(currentYear, currentMonth, currentDate)
            });
        });
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            
        }
    </style>
</asp:Content>

