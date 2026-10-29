<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="IncentiveStatusInspectionUploadDetailsAddlView.aspx.cs" Inherits="UI_TSiPASS_IncentiveStatusInspectionUploadDetailsAddlView" %>

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
        
        .style10
        {
            width: 9px;
            height: 28px;
        }
        
        .style11
        {
            width: 210px;
            height: 28px;
        }
        
        .style12
        {
            width: 212px;
            height: 28px;
        }
        
        .style13
        {
            width: 210px;
            height: 21px;
        }
        
        .style14
        {
            width: 9px;
            height: 21px;
        }
        
        .style15
        {
            height: 21px;
        }
        
        .style16
        {
            width: 212px;
            height: 21px;
        }
        
        .style17
        {
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
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            Incentive Applications <a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                                <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="Excel" /></a>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 99%">
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr style="display: none;">
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" class="style11">
                                                            <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK" Width="108px">Status</asp:Label>
                                                        </td>
                                                        <td class="style10" style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            <asp:DropDownList ID="ddlstatus" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" AutoPostBack="True" TabIndex="1">
                                                                <asp:ListItem>All</asp:ListItem>
                                                                <asp:ListItem>Pending</asp:ListItem>
                                                                <asp:ListItem>Reject</asp:ListItem>
                                                                <asp:ListItem>Forwarded</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="108px">Industry Name</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            :
                                                        </td>
                                                        <td class="style12" style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="TxtIndname" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="80" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" class="style13">
                                                            <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="108px">District</asp:Label>
                                                        </td>
                                                        <td class="style14" style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                            <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" AutoPostBack="True" TabIndex="1">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="style15" style="padding: 5px; margin: 5px">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                            <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="108px">Incentive Name</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                            :
                                                        </td>
                                                        <td class="style16" style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlIncentiveName" runat="server" class="form-control txtbox"
                                                                Height="33px" TabIndex="1" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td valign="middle" align="center" colspan="3" style="text-align: center">
                                                <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    TabIndex="10" Text="Search" Width="90px" OnClick="BtnSearch_Click" />
                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Clear" ToolTip="To Clear  the Screen"
                                                    Width="90px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                &nbsp;
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" colspan="3" align="center">
                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                    ForeColor="#006600"></asp:Label>
                                                <tr>
                                                    <td align="center" style="padding: 5px; margin: 5px" valign="top">
                                                        <div style="margin-bottom: 17px; text-align: left; margin-left: 50px;">
                                                            <input type="text" id="search" class="form-control input-sm" style="width: 380px;
                                                                font-size: 16px; height: 35px; float: left; margin-right: 10px;" placeholder="Type to search" /><input
                                                                    type="button" class="btn btn-default" value="Clear" id="clear" /></div>
                                                        <asp:GridView ID="gvdetailsnew" runat="server" CssClass="floatingTable" AllowPaging="false"
                                                            AutoGenerateColumns="False" CellPadding="4" Height="62px" PageSize="20" Width="90%"
                                                            Font-Names="Verdana" Font-Size="12px" GridLines="Both" OnRowDataBound="gvdetailsnew_RowDataBound">
                                                            <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                            <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
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
                                                                <asp:BoundField DataField="EMiUdyogAadhar" ItemStyle-HorizontalAlign="Center" HeaderText="EMI Udyog Aadhaar" Visible="false"/>
                                                                <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name" />
                                                                <asp:BoundField DataField="ApplciantName" ItemStyle-HorizontalAlign="Center" HeaderText="Applciant Name (Saarvasri)" />
                                                                <asp:BoundField DataField="CASTE" ItemStyle-HorizontalAlign="Center" HeaderText="Category" />
                                                                 <asp:BoundField DataField="INCENTIVESNAME" ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Type" />
                                                                  <asp:BoundField DataField="DateofReceipt" ItemStyle-HorizontalAlign="Center" HeaderText="Date Of Recieved From JD" />
<%--                                                                <asp:BoundField DataField="DepartmentProcessedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Date Of Recieved From Department" />--%>
                                                                   <asp:BoundField DataField="RecommendedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="JD Recommended Amount" />
                                                                <asp:BoundField DataField="NoClaims" ItemStyle-HorizontalAlign="Center" HeaderText="No. Incentives" Visible="false"/>
                                                                <asp:BoundField DataField="Unitaddress" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Address" />
                                                               
                                                                  <asp:BoundField DataField="SSCDATE" ItemStyle-HorizontalAlign="Center" HeaderText="SSC Inspection Date" />
                                                                 <asp:BoundField DataField="EnterpriseName" ItemStyle-HorizontalAlign="Center" HeaderText="Category of Unit" />
                                                                <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="View Application" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <%--  <a id="View" target="_blank" href="ApplicantIncentiveDtls.aspx?EntrpId=<%# Eval("EnterperIncentiveID") %>">View</a>--%>
                                                                        <%--<asp:HyperLink ID="anchortaglink" runat="server" Text="View" Font-Bold="true" ForeColor="Green" Target="_blank" />--%>
                                                                        <asp:Button ID="anchortaglink" runat="server" Text="Process" CssClass="btn btn-primary"
                                                                            OnClick="anchortaglink_Click"></asp:Button>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IncentiveidS" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIncentiveIDS" Text='<%#Eval("IncentiveIds") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr id="trold" runat="server" visible="false">
                                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                        &nbsp;<tr>
                                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                                    ForeColor="#006600"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <caption>
                                                            &nbsp;</caption>
                                                    </td>
                                                </tr>
                                            </td>
                                        </tr>
                                        <tr id="divExport" visible="false" runat="server">
                                            <td align="center" style="text-align: center;" valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table></td></tr></table>
                    </div>
                   
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $('#search').val('');
        });

        $('#search').keyup(function () {
            var value = $(this).val();
            var patt = new RegExp(value, "i");

            $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                if (!($(this).find('td').text().search(patt) >= 0)) {
                    $(this).not('thead').hide();
                }
                if (($(this).find('td').text().search(patt) >= 0)) {
                    $(this).show();
                }
            });

        });

        $('#clear').click(function () {
            $('#search').val('');
            $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody tr').show();
        });

    </script>
</asp:Content>
