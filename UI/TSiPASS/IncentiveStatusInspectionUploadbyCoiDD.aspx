<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="IncentiveStatusInspectionUploadbyCoiDD.aspx.cs" Inherits="UI_TSiPASS_IncentiveStatusInspectionUploadbyCoiDD" %>

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
                        <h3 class="panel-title">Incentive Applications
                            <%--<a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                            <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                alt="Excel" /></a>--%>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 99%">
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr id="tr12" runat="server" visible="false">
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" class="style11">
                                                            <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK" Width="108px">Status</asp:Label>
                                                        </td>
                                                        <td class="style10" style="padding: 5px; margin: 5px">:
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
                                                        <td style="padding: 5px; margin: 5px" class="style17"></td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                            <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="108px">Industry Name</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style17">:
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
                                                        <td class="style14" style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                            <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" AutoPostBack="True" TabIndex="1">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="style15" style="padding: 5px; margin: 5px"></td>
                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                            <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK"
                                                                Width="108px">Incentive Name</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="style15">:</td>
                                                        <td class="style16" style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlIncentiveName" runat="server"
                                                                class="form-control txtbox" Height="33px" TabIndex="1"
                                                                Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">&nbsp;
                                            </td>
                                            <td style="width: 27px">&nbsp;
                                            </td>
                                            <td valign="top">&nbsp;
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            
                                            <td style="padding: 5px; margin: 5px; text-align: center;" colspan="3" align="center">
                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                    ForeColor="#006600"></asp:Label>
                                                <tr id="trNEW1" runat="server" visible="false">
                                                    <td align="center" style="padding: 5px; margin: 5px" valign="top">
                                                        <div style="text-align:left;font-size:16px;margin-left:50px;font-weight:500;">Search</div>
                                                        <div style="margin-bottom: 17px; text-align: left; margin-left: 50px;">
                                                            
                                                            <input type="text" id="search" class="form-control input-sm" style="width: 230px;font-size: 14px; height: 35px; float: left; margin-right: 10px;" placeholder="Unit Name" />
                                                            
                                                            <select class="form-control" id="SelCatgy" style="float:left; margin-right:10px;width:148px;height:35px;">
                                                                <option value="0">Select Category</option>
                                                                <option value="SC">SC</option>
                                                                <option value="ST">ST</option>
                                                                <option value="PHC">PHC</option>
                                                                <option value="GENERAL">GENERAL</option>
                                                            </select>

                                                            <asp:DropDownList ID="DrpDist" runat="server" style="float:left; margin-right:10px;" class="form-control txtbox" Height="33px"
                                                                Width="142px" TabIndex="1">
                                                                <asp:ListItem Value="0">Select District</asp:ListItem>
                                                            </asp:DropDownList>
                                                            
                                                            <input type="button" class="btn btn-default" style="float:left" value="Clear" id="clear" />
                                                            <div class="clear"></div>
                                                        </div>
                                                        <asp:GridView ID="gvdetailsnew" CssClass="floatingTable" runat="server" AllowPaging="false"
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
                                                                        <asp:Label ID="lblDistID" CssClass="GrdDistrict" runat="server" Text='<%#Eval("District") %>'
                                                                            Style="display: none;" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="UnitName" ItemStyle-CssClass="GrdUnitname" ItemStyle-HorizontalAlign="Center"
                                                                    HeaderText="Unit Name" />
                                                                <asp:BoundField DataField="Category" ItemStyle-CssClass="GrdCategory" ItemStyle-HorizontalAlign="Center"
                                                                    HeaderText="Category" />
                                                                <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"
                                                                    HeaderText="Date of Filing" />
                                                                <asp:BoundField DataField="InspectionAssignDate" ItemStyle-HorizontalAlign="Center"
                                                                    HeaderText="G.M Recommended Date" />
                                                                <asp:BoundField DataField="NoofIncentives" ItemStyle-HorizontalAlign="Center" HeaderText="No. Incentives" />
                                                                <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IncentiveidS" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIncentiveIDS" Text='<%#Eval("IncentiveIds") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Incentive Types">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIncentivetypes" Text='<%#Eval("INCENTIVESNAME") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="districtName" ItemStyle-HorizontalAlign="Center" HeaderText="District" />
                                                                <asp:TemplateField HeaderText="Process Application" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <%--  <a id="View" target="_blank" href="ApplicantIncentiveDtls.aspx?EntrpId=<%# Eval("EnterperIncentiveID") %>">View</a>--%>
                                                                        <%--<asp:HyperLink ID="anchortaglink" runat="server" Text="View" Font-Bold="true" ForeColor="Green" Target="_blank" />--%>
                                                                        <asp:Button ID="Button1" runat="server" Text="Process" CssClass="btn btn-primary"
                                                                            OnClick="anchortaglink_Click"></asp:Button>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr id="trNEW2" runat="server" visible="false">
                                                    <td align="center" style="padding: 5px; margin: 5px;width:100%" valign="top">
                                                       <div style="text-align:left;font-size:16px;margin-left:50px;font-weight:500;">Search</div>
                                                        <div style="margin-bottom: 17px; text-align: left; margin-left: 50px;">
                                                            
                                                            <input type="text" id="Text1"  class="form-control input-sm" style="width: 230px;font-size: 14px; height: 35px; float: left; margin-right: 10px;" placeholder="Unit Name" />
                                                            
                                                            <select class="form-control" id="Select1" style="float:left; margin-right:10px;width:148px;height:35px;">
                                                                <option value="0">Select Category</option>
                                                                <option value="SC">SC</option>
                                                                <option value="ST">ST</option>
                                                                <option value="PHC">PHC</option>
                                                                <option value="GENERAL">GENERAL</option>
                                                            </select>

                                                            <asp:DropDownList ID="DropDownList1" runat="server" style="float:left; margin-right:10px;" class="form-control txtbox" Height="33px"
                                                                Width="142px" TabIndex="1">
                                                                <asp:ListItem Value="0">Select District</asp:ListItem>
                                                            </asp:DropDownList>
                                                            
                                                            <input type="button" class="btn btn-default" style="float:left" value="Clear" id="Button2" />
                                                            <div class="clear"></div>
                                                        </div>
                                                        <asp:GridView ID="GridView1" runat="server" CssClass="floatingTable1" AllowPaging="false"
                                                            AutoGenerateColumns="False" CellPadding="4" Height="62px" PageSize="20" Width="90%"
                                                            Font-Names="Verdana" Font-Size="12px" GridLines="Both" OnRowDataBound="GridView1_RowDataBound">
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
                                                                        <asp:Label ID="lblDistID" CssClass="GrdDistrict" runat="server" Text='<%#Eval("District") %>'
                                                                            Style="display: none;" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="UnitName" ItemStyle-CssClass="GrdUnitname" ItemStyle-HorizontalAlign="Center"
                                                                    HeaderText="Unit Name" />
                                                                <asp:BoundField DataField="Category" ItemStyle-CssClass="GrdCategory" ItemStyle-HorizontalAlign="Center"
                                                                    HeaderText="Category" />
                                                                <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center"
                                                                    HeaderText="Date of Filing" />
                                                                <asp:BoundField DataField="InspectionAssignDate" ItemStyle-HorizontalAlign="Center"
                                                                    HeaderText="G.M Recommended Date" />
                                                                <asp:BoundField DataField="CreatedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Query Raised Date" />
                                                                <asp:BoundField DataField="NoofIncentives" ItemStyle-HorizontalAlign="Center" HeaderText="No. Incentives" />
                                                                <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IncentiveidS" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIncentiveIDS" Text='<%#Eval("IncentiveIds") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Incentive Types">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIncentivetypes" Text='<%#Eval("INCENTIVESNAME") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="districtName" ItemStyle-HorizontalAlign="Center" HeaderText="District" />
                                                                <asp:TemplateField HeaderText="Process Application" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="Button1" runat="server" Text="Process" CssClass="btn btn-primary"
                                                                            OnClick="anchortaglink_Click"></asp:Button>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>

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

     <script type="text/javascript">
         $(function () {
             $('#search').val('');

             if ($('table.floatingTable1').not('thead')) {
                 var len = $('table.floatingTable1 tr').has('th').length;
                 $('table.floatingTable1').prepend('<thead></thead>')
                 for (i = 0; i < len; i += 1) {
                     $('table.floatingTable1').find('thead').append($('table.floatingTable1').find("tr:eq(" + i + ")"));
                 }
             }

             var $table = $('table.floatingTable1');
             $table.floatThead();
             $table.floatThead({ position: 'fixed' });
             $table.floatThead({ autoReflow: 'true' });


         });

         $('#search').keyup(function () {

             SearchGrid(1);
         });

         $('#SelCatgy').change(function () {
             debugger;
             SearchGrid(1);
         });

         $('#ctl00_ContentPlaceHolder1_DrpDist').change(function () {

             SearchGrid(1);
         });

         $('#Text1').keyup(function () {
             SearchGrid(2);
         });

         $('#Select1').change(function () {
             SearchGrid(2);
         });

         $('#ctl00_ContentPlaceHolder1_DropDownList1').change(function () {
             SearchGrid(2);
         });




         function SearchGrid(id) {
             debugger;
             var unitname = '';
             var category = '0';
             var distrit = '0'
             if (id == 1) {
                 unitname = $('#search').val();
                 category = $('#SelCatgy').val();
                 distrit = $('#ctl00_ContentPlaceHolder1_DrpDist').val();
             }
             if (id == 2) {
                 unitname = $('#Text1').val();
                 category = $('#Select1').val();
                 distrit = $('#ctl00_ContentPlaceHolder1_DropDownList1').val();
             }


             if (unitname != '' && category != '0' && distrit != '0') {

                 if (id == 1) {
                     $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                         var patt = new RegExp(unitname, "i");
                         var patt1 = new RegExp(category, "i");
                         var patt2 = new RegExp(distrit, "i");
                         if (!($(this).find('td').find('.GrdDistrict').text().search(patt2) >= 0 && $(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                             $(this).not('thead').hide();
                         }
                         if (($(this).find('td').find('.GrdDistrict').text().search(patt2) >= 0 && $(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                             $(this).show();
                         }
                     });
                 }

                 if (id == 2) {
                     $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                         var patt = new RegExp(unitname, "i");
                         var patt1 = new RegExp(category, "i");
                         var patt2 = new RegExp(distrit, "i");
                         if (!($(this).find('td').find('.GrdDistrict').text().search(patt2) >= 0 && $(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                             $(this).not('thead').hide();
                         }
                         if (($(this).find('td').find('.GrdDistrict').text().search(patt2) >= 0 && $(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                             $(this).show();
                         }
                     });
                 }



             } else if (unitname != '' && distrit != '0') {

                 if (id == 1) {
                     {
                         $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                             var patt = new RegExp(unitname, "i");
                             var patt1 = new RegExp(distrit, "i");

                             if (!($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                                 $(this).not('thead').hide();
                             }
                             if (($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                                 $(this).show();
                             }
                         });
                     }
                     if (id == 2) {
                         $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                             var patt = new RegExp(unitname, "i");
                             var patt1 = new RegExp(distrit, "i");

                             if (!($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                                 $(this).not('thead').hide();
                             }
                             if (($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                                 $(this).show();
                             }
                         });
                     }
                 }

             } else if (category != '0' && distrit != '0') {

                 if (id == 1) {
                     $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                         var patt = new RegExp(category, "i");
                         var patt1 = new RegExp(distrit, "i");

                         if (!($(this).find('td.GrdCategory').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                             $(this).not('thead').hide();
                         }
                         if (($(this).find('td.GrdCategory').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                             $(this).show();
                         }
                     });
                 }
                 if (id == 2) {
                     $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                         var patt = new RegExp(category, "i");
                         var patt1 = new RegExp(distrit, "i");

                         if (!($(this).find('td.GrdCategory').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                             $(this).not('thead').hide();
                         }
                         if (($(this).find('td.GrdCategory').text().search(patt) >= 0 && $(this).find('td').find('.GrdDistrict').text().search(patt1) >= 0)) {
                             $(this).show();
                         }
                     });
                 }


             } else if (unitname != '' && category != '0') {

                 if (id == 1) {
                     $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                         var patt = new RegExp(unitname, "i");
                         var patt1 = new RegExp(category, "i");

                         if (!($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                             $(this).not('thead').hide();
                         }
                         if (($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                             $(this).show();
                         }
                     });
                 }


                 if (id == 2) {
                     $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                         var patt = new RegExp(unitname, "i");
                         var patt1 = new RegExp(category, "i");

                         if (!($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                             $(this).not('thead').hide();
                         }
                         if (($(this).find('td.GrdUnitname').text().search(patt) >= 0 && $(this).find('td.GrdCategory').text().search(patt1) >= 0)) {
                             $(this).show();
                         }
                     });
                 }


             } else if (unitname != '') {
                 if (id == 1) {
                     $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                         var patt = new RegExp(unitname, "i");
                         if (!($(this).find('td.GrdUnitname').text().search(patt) >= 0)) {
                             $(this).not('thead').hide();
                         }
                         if (($(this).find('td.GrdUnitname').text().search(patt) >= 0)) {
                             $(this).show();
                         }
                     });
                 }

                 if (id == 2) {
                     $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                         var patt = new RegExp(unitname, "i");
                         if (!($(this).find('td.GrdUnitname').text().search(patt) >= 0)) {
                             $(this).not('thead').hide();
                         }
                         if (($(this).find('td.GrdUnitname').text().search(patt) >= 0)) {
                             $(this).show();
                         }
                     });
                 }
             }
             else if (category != '0') {
                 if (id == 1) {
                     $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                         var patt = new RegExp(category, "i");
                         if (!($(this).find('td.GrdCategory').text().search(patt) >= 0)) {
                             $(this).not('thead').hide();
                         }
                         if (($(this).find('td.GrdCategory').text().search(patt) >= 0)) {
                             $(this).show();
                         }
                     });
                 }

                 if (id == 2) {
                     $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                         var patt = new RegExp(category, "i");
                         if (!($(this).find('td.GrdCategory').text().search(patt) >= 0)) {
                             $(this).not('thead').hide();
                         }
                         if (($(this).find('td.GrdCategory').text().search(patt) >= 0)) {
                             $(this).show();
                         }
                     });
                 }

             }
             else if (distrit != '0') {
                 if (id == 1) {
                     $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                         var patt = new RegExp(distrit, "i");
                         if (!($(this).find('td').find('.GrdDistrict').text().search(patt) >= 0)) {
                             $(this).not('thead').hide();
                         }
                         if (($(this).find('td').find('.GrdDistrict').text().search(patt) >= 0)) {
                             $(this).show();
                         }
                     });
                 }

                 if (id == 2) {
                     $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
                         var patt = new RegExp(distrit, "i");
                         if (!($(this).find('td').find('.GrdDistrict').text().search(patt) >= 0)) {
                             $(this).not('thead').hide();
                         }
                         if (($(this).find('td').find('.GrdDistrict').text().search(patt) >= 0)) {
                             $(this).show();
                         }
                     });
                 }

             } else {
                 if (id == 1)
                     $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody tr').show();
                 if (id == 2)
                     $('#ctl00_ContentPlaceHolder1_GridView1 tbody tr').show();

             }
         }




         $('#clear').click(function () {
             debugger;

             $('#search').val('');
             $('#SelCatgy').val('0');
             $('#ctl00_ContentPlaceHolder1_DrpDist').val('0');
             $('#ctl00_ContentPlaceHolder1_gvdetailsnew tbody tr').show();

         });



         $('#Button2').click(function () {
             debugger;

             $('#Text1').val('');
             $('#Select1').val('0');
             $('#ctl00_ContentPlaceHolder1_DropDownList1').val('0');
             $('#ctl00_ContentPlaceHolder1_GridView1 tbody tr').show();


         });



     </script>
</asp:Content>

