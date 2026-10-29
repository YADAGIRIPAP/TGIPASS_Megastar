<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="IncentiveStatusDetailsNew.aspx.cs" Inherits="UI_TSiPASS_IncentiveStatusDetailsNew" %>

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
    <%--<script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
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
                                                        <tr style="display: none">
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
                                                                                <asp:ListItem Text="Select" Value="0"> </asp:ListItem>
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
                                                                    <tr>
                                                                        <td class="style13" style="padding: 5px; margin: 5px">
                                                                            <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="108px">From Date</asp:Label>
                                                                        </td>
                                                                        <td class="style14" style="padding: 5px; margin: 5px">
                                                                            :
                                                                        </td>
                                                                        <td class="style15" style="padding: 5px; margin: 5px">
                                                                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px"
                                                                                MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                       <%--     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtFromDate"
                                                                                TargetControlID="txtFromDate">
                                                                            </cc1:CalendarExtender>--%>
                                                                        </td>
                                                                        <td class="style15" style="padding: 5px; margin: 5px">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="style15" style="padding: 5px; margin: 5px">
                                                                            <asp:Label ID="Label442" runat="server" CssClass="LBLBLACK" Width="108px">To Date</asp:Label>
                                                                        </td>
                                                                        <td class="style15" style="padding: 5px; margin: 5px">
                                                                            :
                                                                        </td>
                                                                        <td class="style16" style="padding: 5px; margin: 5px">
                                                                            <asp:TextBox ID="txtToDate" runat="server" class="form-control txtbox" Height="28px"
                                                                                MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        <%--    <cc1:CalendarExtender ID="txtRegDate0_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                                                PopupButtonID="txtToDate" TargetControlID="txtToDate">
                                                                            </cc1:CalendarExtender>--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td valign="middle" align="center" colspan="3" style="text-align: center">
                                                                <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Height="32px"
                                                                    TabIndex="10" Text="Search" Width="90px" OnClick="BtnSearch_Click" />
                                                                &nbsp;
                                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Clear" ToolTip="To Clear  the Screen"
                                                                    Width="90px" />
                                                                &nbsp;<asp:Button ID="BtnSearch0" runat="server" CssClass="btn btn-info" Height="32px"
                                                                    OnClick="BtnSearch0_Click" TabIndex="10" Text="Export" Width="90px" />
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
                                                                        <asp:Panel ID="Panel1" runat="server">
                                                                            <contenttemplate>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 98%">
                                     <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                        <div style="margin-bottom: 17px; text-align: left; margin-left:0px;">
                                                            <input type="text" id="search" class="form-control input-sm" style="width: 380px; font-size: 16px; height: 35px;float:left;margin-right:10px;" placeholder="Type to search" /><input type="button" class="btn btn-default" value="Clear" id="clear" />
                                        </div>
                                           <asp:GridView ID="gvdetailsnew" CssClass="floatingTable" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                                            CellPadding="4"  Height="62px"
                                                                            PageSize="20" Width="105%" Font-Names="Verdana" Font-Size="12px" GridLines="Both" OnRowDataBound="gvdetailsnew_RowDataBound">
                                                                            <HeaderStyle VerticalAlign="Middle"  Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle BackColor="#013161"  Height="40px" CssClass="GridviewScrollC1Header" />
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
                                                                                <asp:BoundField DataField="EMiUdyogAadhar" ItemStyle-HorizontalAlign="Center" HeaderText="EMI Udyog Aadhaar" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="EnterpriseSector" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Unit" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="EnterpriseName" ItemStyle-HorizontalAlign="Center" HeaderText="Category of Unit" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>


                                                                                <asp:BoundField DataField="ApplciantName" ItemStyle-HorizontalAlign="Center" HeaderText="Applicant Name" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="Caste_Name" ItemStyle-HorizontalAlign="Center" HeaderText="Social Status" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="Address" ItemStyle-HorizontalAlign="Center" HeaderText="Address" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="IncentiveCount" ItemStyle-HorizontalAlign="Center" HeaderText="No. of Incentives" >
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                  <asp:TemplateField HeaderText="Incentiveid">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                  <asp:TemplateField HeaderText="GM Recommended Date" Visible="true">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblGMRecommendeddate" Text='<%#Eval("GMrecommededdate") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Process Application" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                      <%--  <a id="View" target="_blank" href="ApplicantIncentiveDtls.aspx?EntrpId=<%# Eval("EnterperIncentiveID") %>">View</a>--%>
                                                                                       <%-- <asp:HyperLink ID="anchortaglink" runat="server" Text="Process" Font-Bold="true" ForeColor="Green" Target="_blank" />--%>
                                                                                        <asp:Button ID="anchortaglink" runat="server" Text="Process" CssClass="btn btn-primary" OnClick="anchortaglink_Click"></asp:Button>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                               <asp:TemplateField HeaderText="AppliedIncentives" Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAppliedIncentives" Text='<%#Eval("AppliedIncentives") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            
                                                                        </asp:GridView>

                                             <%---------------sowjanya--------------%>

 <asp:GridView ID="grdOfficer" CssClass="floatingTable" runat="server" AllowPaging="false" AutoGenerateColumns="False"
     CellPadding="4" Height="62px" ShowFooter="true"
     PageSize="20" Width="105%" Font-Names="Verdana" Font-Size="12px" GridLines="Both" OnRowDataBound="grdOfficerChange_RowDataBound">
     <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
     <RowStyle CssClass="GridviewScrollC1Item" />
     <PagerStyle CssClass="GridviewScrollC1Pager" />
     <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
     <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
     <Columns>
         <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
             <ItemTemplate>
                 <%# Container.DataItemIndex + 1%>
                 <asp:HiddenField ID="HiddenField1" runat="server" />
                 <asp:HiddenField ID="HiddenField2" runat="server" />
             </ItemTemplate>
             <HeaderStyle HorizontalAlign="Center" />
             <ItemStyle Width="50px" />
         </asp:TemplateField>
         <asp:BoundField DataField="EMiUdyogAadhar" ItemStyle-HorizontalAlign="Center" HeaderText="EMI Udyog Aadhaar">
             <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>
         <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
             <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>
         <asp:BoundField DataField="EnterpriseSector" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Unit">
             <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>

         <asp:BoundField DataField="EnterpriseName" ItemStyle-HorizontalAlign="Center" HeaderText="Category of Unit">
             <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>


         <asp:BoundField DataField="ApplciantName" ItemStyle-HorizontalAlign="Center" HeaderText="Applicant Name">
             <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>

         <asp:BoundField DataField="Caste_Name" ItemStyle-HorizontalAlign="Center" HeaderText="Social Status">
             <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>

         <asp:BoundField DataField="Address" ItemStyle-HorizontalAlign="Center" HeaderText="Address">
             <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>

         <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}">
             <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>
         <asp:TemplateField HeaderText="No. of Incentives">
             <ItemTemplate>
                 <%# Eval("IncentiveCount") %>
             </ItemTemplate>
             <FooterTemplate>
                 <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
             </FooterTemplate>
             <ItemStyle HorizontalAlign="Center" />
             <FooterStyle HorizontalAlign="Center" Font-Bold="true" />
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Incentiveid">
             <ItemTemplate>
                 <asp:Label ID="lblEnterperIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
             </ItemTemplate>
         </asp:TemplateField>

         <asp:TemplateField HeaderText="GM Recommended Date" Visible="true">
             <ItemTemplate>
                 <asp:Label ID="Label2" Text='<%#Eval("GMrecommededdate") %>' runat="server" />
             </ItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Assigned to" Visible="true">
             <ItemTemplate>
                 <asp:Label ID="lblAssignedto" Text='<%#Eval("EmployeeName") %>' runat="server" />
             </ItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Assigned Date" Visible="true">
             <ItemTemplate>
                 <asp:Label ID="lblAssignedDate" Text='<%#Eval("InspectionAssignDate") %>' runat="server" />
             </ItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Update Officer" ItemStyle-HorizontalAlign="Center" Visible="false">
             <ItemTemplate>
                 <asp:DropDownList ID="ddlOfficer" runat="server" class="form-control txtbox" Height="33px"
                     Width="180px">
                     <asp:ListItem Text="Select" Value="0"> </asp:ListItem>
                 </asp:DropDownList>
                 <asp:Button ID="btnUpdateOfficer" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdateOfficer_Click"></asp:Button>
             </ItemTemplate>
             <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Rollaback and Asign Officer" ItemStyle-HorizontalAlign="Center" Visible="false">
             <ItemTemplate>
                 <asp:DropDownList ID="RollbackddlOfficer" runat="server" class="form-control txtbox" Height="33px"
                     Width="180px">
                     <asp:ListItem Text="Select" Value="0"> </asp:ListItem>
                 </asp:DropDownList>
                 <asp:Button ID="btnRollbakandUpdateOfficer" runat="server" Text="Rollback And Assign" CssClass="btn btn-primary" OnClick="btnRollbakandUpdateOfficer_Click"></asp:Button>
             </ItemTemplate>
             <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>

         <asp:TemplateField HeaderText="Process Application" ItemStyle-HorizontalAlign="Center" visible="false">
             <ItemTemplate>
                 <%--  <a id="View" target="_blank" href="ApplicantIncentiveDtls.aspx?EntrpId=<%# Eval("EnterperIncentiveID") %>">View</a>--%>
                 <%-- <asp:HyperLink ID="anchortaglink" runat="server" Text="Process" Font-Bold="true" ForeColor="Green" Target="_blank" />--%>
                 <asp:Button ID="Button1" runat="server" Text="Process" CssClass="btn btn-primary" OnClick="anchortaglink_Click"></asp:Button>
             </ItemTemplate>
             <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>
         <asp:TemplateField HeaderText="AppliedIncentives" Visible="true">
             <ItemTemplate>
                 <asp:Label ID="lblAppliedIncentivess" Text='<%#Eval("AppliedIncentives") %>' runat="server" />
             </ItemTemplate>
         </asp:TemplateField>
     </Columns>

 </asp:GridView>
 <%-------------------sowjanya-----------------------%>
                                        
                                        </td>

                                            </tr>
                                    <tr runat="server" visible="false">
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                        
                                           <asp:GridView ID="grdDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                            CellPadding="4"  Height="62px"
                                                                            OnPageIndexChanging="grdDetails_PageIndexChanging" OnRowDataBound="grdDetails_RowDataBound"
                                                                            PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                                            <HeaderStyle VerticalAlign="Middle"  Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle BackColor="#013161"  Height="40px" CssClass="GridviewScrollC1Header" />
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
                                                                                <asp:BoundField DataField="EMiUdyogAadhar" HeaderText="EMI Udyog Aadhaar" />
                                                                                <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                                                                <asp:BoundField DataField="ApplciantName" HeaderText="Applciant Name" />
                                                                                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                                                                <asp:BoundField DataField="Caste" HeaderText="Caste" />
                                                                                <asp:BoundField DataField="Category" HeaderText="Category" />
                                                                                <asp:BoundField DataField="District" HeaderText="District" />
                                                                                <asp:BoundField DataField="TypeofOrg" HeaderText="Type of Organization" Visible="false" />
                                                                                <asp:BoundField DataField="EnterperIncentiveID" HeaderText="Enterper Incentive ID"
                                                                                    Visible="false" />
                                                                                <asp:BoundField DataField="UnitEmail" HeaderText="Email" />
                                                                                <asp:BoundField DataField="UnitMObileNo" HeaderText="Mobile" />
                                                                                <asp:TemplateField HeaderText="View Incentives">
                                                                                    <ItemTemplate>
                                                                                        <a id="View" target="_blank" href="IncetivesDraft.aspx?EntrpId=<%# Eval("EnterperIncentiveID") %>">
                                                                                            View</a>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="View Attachments">
                                                                                    <ItemTemplate>
                                                                                        <a id="View" target="_blank" href="Show_AttachmentsNew.aspx?EntrpId=<%# Eval("EnterperIncentiveID") %>">
                                                                                            View</a>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Update Status">
                                                                                    <ItemTemplate>
                                                                                        <table style="width: 100%" cellpadding="4" cellspacing="5">
                                                                                            <tr>
                                                                                                <td>
                                                                    <a id="ViewforQuery" target="_blank" href="frmResptoIncQry.aspx?EntrpId=<%# Eval("EnterperIncentiveID") %>">
                                                                    <asp:LinkButton ID="lnkView" Visible="false" runat="server" OnClick="lnkView_Click1">Query Response</asp:LinkButton>
                                                                                                </td>
                                                                                                <asp:Label ID="lbl123" Text="Inspecting Officer" runat="server"></asp:Label>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 150px; height: 29px">
                                                                                                    <asp:DropDownList ID="ddlDeptname" runat="server" Width="180px" CssClass="DROPDOWN" 
                                                                                                        class="form-control txtbox" Height="33px"  OnSelectedIndexChanged="ddlDeptname_SelectedIndexChanged1" AutoPostBack="true" CausesValidation="True">
                                                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtIncQueryFnl" Visible="false" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>

                                                                                                <td>
                                                                                                    <asp:Label ID="lblQueryDescErr" runat="server" Visible="False" Text="Please enter query Description" Font-Bold="True"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <asp:Button ID="BtnSaveg" runat="server" CssClass="BUTTON" TabIndex="10"
                                                                                                        Text="Submit" ValidationGroup="group" Width="100px" OnClick="BtnSaveg_Click" />
                                                                                                    
                                                                                             
                                                                                                
                                                                                                    
                                                                        <asp:Button ID="btnCancelIncQry" CssClass="BUTTON" Visible="false" runat="server" Text="Cancel"></asp:Button>
                                                                                                    <asp:HiddenField ID="HdfintApplicationid" runat="server" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="Manda_lName" HeaderText="Mandal Name" />
                                                                                <asp:TemplateField HeaderText="Inspection Date">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblInspectionDate" Text='<%#Eval("InspectionDate") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="SubmittedDate" HeaderText="Submitted Date" />
                                                                                <asp:BoundField DataField="sectorname" HeaderText="Manufacture/Service" />
                                                                                <asp:BoundField DataField="assigned" HeaderText="Assigned To" />
                                                                                <%--<asp:HyperLinkField HeaderText="Forward" />--%>
                                                                                
                                                                                
                                                                                 <asp:TemplateField HeaderText="Incentives">
                                                                                    <ItemTemplate>
                                                                                        <asp:GridView ID="GrdInc" runat="server" AutoGenerateColumns="False" 
                                                                                            ShowHeader="False">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="IncentiveName" />
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                  <asp:TemplateField HeaderText="Incentives Draft">
                                                                                        <ItemTemplate>
                                                                                            <a id="View" target="_blank" href="FinalPage.aspx?EntrpId=<%# Eval("EnterperIncentiveID") %>">View</a>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                            </Columns>
                                                                            
                                                                        </asp:GridView>
                                        
                                        </td>

                                            </tr>
                                            </table>
                                            </div>
                                            </contenttemplate>
                                                                        </asp:Panel>
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
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

            $("input[id$='txtFromDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtTodate']").datepicker(
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
            $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtTodate']").datepicker(
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
</asp:Content>
