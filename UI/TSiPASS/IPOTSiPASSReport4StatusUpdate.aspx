<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="IPOTSiPASSReport4StatusUpdate.aspx.cs" Inherits="TSTBDCReg1" %>

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
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
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
<asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">Incentive</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">View Details</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                </h3>
                            </div>
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 99%">
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px" class="style11">
                                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="165px">Month<font 
                                                            color="red">*</font></asp:Label>
                                                                        </td>
                                                                        <td class="style10" style="padding: 5px; margin: 5px">
                                                                            :
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                                <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" Height="33px"
                                                                     TabIndex="1" 
                                                                    Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">January</asp:ListItem>
                                                                    <asp:ListItem Value="2">February</asp:ListItem>
                                                                    <asp:ListItem Value="3">March</asp:ListItem>
                                                                    <asp:ListItem Value="4">April</asp:ListItem>
                                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                                    <asp:ListItem Value="6">June</asp:ListItem>
                                                                    <asp:ListItem Value="7">July</asp:ListItem>
                                                                    <asp:ListItem Value="8">August</asp:ListItem>
                                                                    <asp:ListItem Value="9">September</asp:ListItem>
                                                                    <asp:ListItem Value="10">October</asp:ListItem>
                                                                    <asp:ListItem Value="11">November</asp:ListItem>
                                                                    <asp:ListItem Value="12">December</asp:ListItem>
                                                                </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                                <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="165px">Year<font 
                                                            color="red">*</font></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                                            :
                                                                        </td>
                                                                        <td class="style12" style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem>2016</asp:ListItem>
                                                                </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="middle" align="center" colspan="3" style="text-align: center">
                                                                <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                    TabIndex="10" Text="Search" Width="90px" OnClick="BtnSearch_Click" />
                                                                &nbsp;
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
                                                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                        <asp:GridView ID="grdDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="GRD" ForeColor="#333333" GridLines="None" Height="62px" OnPageIndexChanging="grdDetails_PageIndexChanging" OnRowDataBound="grdDetails_RowDataBound"  PageSize="20" Width="100%">
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
                            <asp:BoundField DataField="MonthName" HeaderText="Month" />
                   <asp:BoundField DataField="VI_Year" HeaderText="Year" />
                   <asp:BoundField DataField="NameofUnit" HeaderText="Unit Name" />
                   <asp:BoundField DataField="AddressofUnit" HeaderText="Address of Unit" ControlStyle-Width="150px" ItemStyle-Width="300px" />
                    <asp:BoundField DataField="CStatus" HeaderText="Current Status" />
                   <asp:BoundField DataField="DateofApproval" HeaderText="Date of Approval" 
DataFormatString="{0:dd/MM/yyyy}"/>
              
                   <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                   
             
                                             <asp:TemplateField HeaderText="Update Status">
                                                                                
                                                                <ItemTemplate>
                                                                
                                                                 <table style="width: 100%" cellpadding="4" cellspacing="5">
                                                                 <tr>
                                                                 <asp:Label ID="lbl123" Text="Status" runat="server"></asp:Label>
                                                                 </tr>
                                                                 <tr>
                                                               
                                                                 <td style="width: 150px; height: 29px">
                                                                <asp:DropDownList ID="ddlStatus" runat="server" Width="180px" 
                                                                    CssClass="DROPDOWN" >
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                     <asp:ListItem>Accepted</asp:ListItem>
                                                                      <asp:ListItem>Rejected</asp:ListItem>
                                                                    
                                                                </asp:DropDownList>
                                                                </td>
                                                                </tr>
                                                                 <tr>
                                                            <td colspan="4" align="center">
                                                                 <asp:Button ID="BtnSaveg" runat="server" CssClass="BUTTON" Height="20px" 
                                                                                     TabIndex="10" Text="Submit" ValidationGroup="group" 
                                                                                    Width="61px" onclick="BtnSaveg_Click" />
                                  <asp:HiddenField ID="HdfintApplicationid" runat="server" /></td>
                                                        </tr>
                                                                
                                                        </table>
                                                                  
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             
                                                                            </Columns>
                                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                            <EditRowStyle BackColor="#B9D684" />
                                                                            <AlternatingRowStyle BackColor="White" />
                                                                        </asp:GridView>
                                                                        <tr>
                                                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                                                &nbsp;
                                                                                <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="verdana" 
                                                                                    Font-Size="13px" ForeColor="#006600"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <caption>
                                                                            &nbsp;</caption>
                                                                    </td>
                                                                </tr>
                                                            </td>
                                                        </tr>
                                                    </table>
                                    </div>
                             </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
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
       </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
