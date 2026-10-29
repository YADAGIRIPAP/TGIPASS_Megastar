<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/UI/TSiPASS/BankMaster.master"  CodeFile="frmSbordinateDebtscheme_report.aspx.cs" Inherits="UI_TSIPASS_frmSbordinateDebtscheme_report" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                        
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 99%">
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        
                                        
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
                                                &nbsp;<tr id="trNEW1" runat="server">
                                                    <td align="center" style="padding: 5px; margin: 5px; width: 100%;" valign="top">
                                                        <div style="margin-bottom: 17px; text-align: left; margin-left: 50px;">
                                                            <input type="text" id="search" class="form-control input-sm" style="width: 380px;
                                                                font-size: 16px; height: 35px; float: left; margin-right: 10px;" placeholder="Type to search" /><input
                                                                    type="button" class="btn btn-default" value="Clear" id="clear" />
                                                        </div>
                                                      
                                                    </td>
                                                </tr>
                                                <tr id="trNEW2" runat="server" >
                                                    <td align="center" style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                                        <asp:GridView ID="grdDetails" CssClass="floatingTable1" runat="server" AutoGenerateColumns="false" CellPadding="5"
                                ShowFooter="True" Width="1000px" OnRowDataBound="grdDetails_RowDataBound"> 
                                <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="50px" CssClass="GridviewScrollC1HeaderWrap" Font-Bold="true" />
                                <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                
                                <RowStyle Wrap="true" />
                            <Columns>
                                 <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Unitname" HeaderText="Name of the Unit" ItemStyle-HorizontalAlign="Center">
                                                                           
                                                                        </asp:BoundField>
                                <asp:BoundField DataField="id" HeaderText="sno" Visible="false" ItemStyle-HorizontalAlign="Center">
                                                                           
                                                                        </asp:BoundField>
                               

                                    <asp:BoundField HeaderText="Entrepreneur name" DataField="Entrepreneurname" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField HeaderText="Address" DataField="Address" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField HeaderText="Line of Activity" DataField="LineOfActivity" ItemStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField HeaderText="Registered Date" DataField="RegisteredDate" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="remarks" HeaderText="remarks" Visible="false" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                                    <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Email Id" DataField="EmailId" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Is SMA or NPA" DataField="RbtSMANPA" ItemStyle-HorizontalAlign="Center" />
                                                                        
                                                      <asp:TemplateField HeaderText="Edit">
                                                                
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hypedit" runat="server" Target="_blank"> </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                    

                            </Columns>
                            </asp:GridView>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                        &nbsp;
                                                        <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                            ForeColor="#006600"></asp:Label>
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
            //$('#search1').val('');



            if ($('table.floatingTable1').not('thead')) {
                var len = $('table.floatingTable1 tr').has('th ').length;
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
            var value = $(this).val();
            var patt = new RegExp(value, "i");

            $('#ctl00_ContentPlaceHolder1_grdDetails tbody').find('tr').each(function () {
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
            $('#ctl00_ContentPlaceHolder1_grdDetails tbody tr').show();
        });


        //$('#search1').keyup(function () {
        //    var value = $(this).val();
        //    var patt = new RegExp(value, "i");

        //    $('#ctl00_ContentPlaceHolder1_GridView1 tbody').find('tr').each(function () {
        //        if (!($(this).find('td').text().search(patt) >= 0)) {
        //            $(this).not('thead').hide();
        //        }
        //        if (($(this).find('td').text().search(patt) >= 0)) {
        //            $(this).show();
        //        }
        //    });

        //});

        //$('#clear1').click(function () {
        //    $('#search1').val('');
        //    $('#ctl00_ContentPlaceHolder1_GridView1 tbody tr').show();
        //});


    </script>
</asp:Content>