<%@ Page Language="C#"  MasterPageFile="~/UI/TSiPASS/CCMaster.master"  AutoEventWireup="true" CodeFile="SecondAppealCFO.aspx.cs" Inherits="UI_TSiPASS_SecondAppealCFO" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style6 {
            width: 300px;
        }

        .style7 {
            color: #FF3300;
        }

        .style8 {
        }

        .auto-style1 {
            width: 20px;
        }
        .auto-style2 {
            height: 82px;
            width: 403px;
        }
        .auto-style6 {
            width: 403px;
        }
        .auto-style7 {
            width: 302px;
        }
        .auto-style8 {
            width: 302px;
            height: 89px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript" language="javascript">
        window.onload = function () {
            var scrollY = parseInt('<%=Request.Form["scrollY"] %>');
            if (!isNaN(scrollY)) {
                window.scrollTo(0, scrollY);
            }
        };
        window.onscroll = function () {
            var scrollY = document.body.scrollTop;
            if (scrollY == 0) {
                if (window.pageYOffset) {
                    scrollY = window.pageYOffset;
                }
                else {
                    scrollY = (document.body.parentElement) ? document.body.parentElement.scrollTop : 0;
                }
            }
            if (scrollY > 0) {
                var input = document.getElementById("scrollY");
                if (input == null) {
                    input = document.createElement("input");
                    input.setAttribute("type", "hidden");
                    input.setAttribute("id", "scrollY");
                    input.setAttribute("name", "scrollY");
                    document.forms[0].appendChild(input);
                }
                input.value = scrollY;
            }
        };
    </script>
    <%--<asp:HiddenField runat="server" ID="hfPosition" Value="" />
    <script type="text/javascript">
        $(function () {
            var f = $("#<%=hfPosition.ClientID%>");
        window.onload = function () {
            var position = parseInt(f.val());
            if (!isNaN(position)) {
                $(window).scrollTop(position);
            }
        };
        window.onscroll = function () {
            var position = $(window).scrollTop();
            f.val(position);
        };
    });
    </script>--%>
    <%--    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }

    </script>
    <%--    <asp:updatepanel id="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="background-color: #339966">
                        <table style="width: 100%">
                            
                        </table>
                    </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            

                            
                            
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    <asp:GridView ID="gvSalesTax" runat="server" AutoGenerateColumns="False" border="3"
                                        CellPadding="1" CellSpacing="1" OnRowDataBound="gvSalesTax_RowDataBound">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Financial year">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlFinYear" runat="server" class="form-control txtbox" Height="33px"
                                                        Width="180px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="1st Half Year Amount paid in Rs.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt1Amountpaid" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="1st Half Year Amount claimed in Rs.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt1AmountClaimed" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="2n Half Year Amount paid in Rs.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt2Amountpaid" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="2nd Half Year Amount claimed in Rs.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt2AmountClaimed" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#B9D684" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>--%>
                            <tr id="trEnergy1" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table style="width: 100%; font-weight: bold;">
                                        
                                        
                                                                                <tr id="TRUIDNUMBER" runat="server" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label12" runat="server">UID NUMBER <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="TXTUIDNUMBER" runat="server" class="form-control txtbox" 
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                            <asp:Button ID="BTNGETDATA" runat="server" Text="GETREJECTEDAPPROVALS" Width="194px" OnClick="BTNGETDATA_Click" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;</td>
                                             
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style6">
                                                <asp:Label ID="Label11" runat="server">REJECTED APPROVALS<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="DDLREJECTEDAPPROVALS" runat="server" class="form-control txtbox" Height="33px" Width="180px" 
                                                    AutoPostBack="true" OnSelectedIndexChanged="DDLREJECTEDAPPROVALS_SelectedIndexChanged" >
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style7">
                                                &nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;</td>
                                        </tr>
                                        <tr id="trfirsthalfyearsecondquarter" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label17" runat="server">ApprovalName<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lblapprovalname" runat="server" ></asp:Label>
                                                &nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                <asp:Label ID="Label18" runat="server">Rejected Reason<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lblrejectedreason" runat="server" ></asp:Label>
                                                &nbsp;</td>
                                        </tr>
                                        <tr id="trFin2ndHalf1stquarter" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label13" runat="server">Department Rejected Date<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbldeptrejecteddate" runat="server" ></asp:Label>
                                                &nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                <asp:Label ID="Label15" runat="server">Appealed date<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lblappealeddate" runat="server" ></asp:Label>
                                                &nbsp;</td>
                                        </tr>                                     
                                        <tr id="trFin2ndHalf2ndquarter" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label19" runat="server">Appeal description<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lblappealdescription" runat="server" ></asp:Label>
                                                &nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                <asp:Label ID="Label20" runat="server">COI Rejected Remarks<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lblcoirejectedremarks" runat="server" ></asp:Label>
                                                &nbsp;</td>
                                        </tr>
                                                            <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label8" runat="server">COI Rejected Date<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lblcoirejecteddate" runat="server" ></asp:Label>
                                                &nbsp;</td>
                                            <td id="tdquartera" runat="server" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td id="tdquarterb" runat="server" visible="false" style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                
                                                <asp:Label ID="Label21" runat="server">Reason for Appeal<font color="red">*</font></asp:Label>
                                                
                                            </td>
                                            <td id="tdquarterc" runat="server" style="padding: 5px; margin: 5px"></td>
                                            <td id="tdquarterd" runat="server"  style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="TXTAPPEALREMARKS" runat="server" class="form-control txtbox" 
                                                    Height="28px"  TabIndex="36" Width="180px"></asp:TextBox>
                                                &nbsp;</td>
                                        </tr>
                                 
 
                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="btnappealprovosion" runat="server" CssClass="btn btn-primary" Height="32px"
                                        OnClick="btnappealprovosion_Click" TabIndex="10" Text="Click Here Appeal Provision" ValidationGroup="group" Width="279px" />
                                    &nbsp;
                                        
                                </td>
                            </tr>
                            
                        </table>
                        <asp:HiddenField ID="HDNCREATEDBY" runat="server" />
                       
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
    <%--            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
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
    <%--            </ContentTemplate>
        </asp:updatepanel>--%>
</asp:Content>

