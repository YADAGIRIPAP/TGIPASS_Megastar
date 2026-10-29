<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="DeptFeedBackStatusDetails.aspx.cs" Inherits="UI_TSiPASS_DeptFeedBackStatusDetails" %>


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

    <script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>
    <%--<script type="text/javascript">
        function removescrolling() {

            $('#<%=grdDetails.ClientID%>').gridviewScroll({

             });
         }
         function pageLoad() {
             $('#<%=grdDetails.ClientID%>').gridviewScroll({
                width: "1024px",
                height: "100%",
                arrowsize: 30,
                varrowtopimg: "../../images/arrowvt.png",
                varrowbottomimg: "../../images/arrowvb.png",
                harrowleftimg: "../../images/arrowhl.png",
                harrowrightimg: "../../images/arrowhr.png"
            });
            //loadfirstRow();
        }
    </script>--%>
    <script language="javascript" type="text/javascript">



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
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-edit">CAF</i>
                    </li>
                    <li class="active">
                        <i class="fa fa-edit"></i><a href="#">Feedback Details</a>
                    </li>
                </ol>
            </div>

            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title"></h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                        <tr>
                                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                                    <tr>


                                                                        <td style="padding: 5px; margin: 5px" class="style17">
                                                                            <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="108px">Industry Name</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px" class="style17">:</td>
                                                                        <td class="style12" style="padding: 5px; margin: 5px">
                                                                            <asp:TextBox ID="TxtIndname" runat="server" class="form-control txtbox"
                                                                                Height="28px" MaxLength="80" TabIndex="1" ValidationGroup="group"
                                                                                Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <%-- <td style="padding: 5px; margin: 5px" class="style11">
                                                        <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK" Width="108px">Status</asp:Label>
                                                    </td>
                                                    <td class="style10" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px" class="style17">
                                                        <asp:DropDownList ID="ddlstatus" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px" AutoPostBack="True" 
                                                            TabIndex="1">
                                                            <asp:ListItem>All</asp:ListItem>
                                                            <asp:ListItem>Pending</asp:ListItem>
                                                            <asp:ListItem>Redressed</asp:ListItem>
                                                            <asp:ListItem>Reject</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </td>--%>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px" class="style13">
                                                                            <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="108px">District</asp:Label>
                                                                        </td>
                                                                        <td class="style14" style="padding: 5px; margin: 5px">:</td>
                                                                        <td style="padding: 5px; margin: 5px" class="style15">
                                                                            <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox"
                                                                                Height="33px" Width="180px" AutoPostBack="True" TabIndex="1">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="style15" style="padding: 5px; margin: 5px"></td>
                                                                        <td style="padding: 5px; margin: 5px" class="style15"></td>
                                                                        <td style="padding: 5px; margin: 5px" class="style15"></td>
                                                                        <td class="style16" style="padding: 5px; margin: 5px"></td>
                                                                    </tr>
                                                                </table>
                                                            </td>


                                                        </tr>

                                                        <tr>
                                                            <td valign="middle" align="center" colspan="3" style="text-align: center">
                                                                <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary"
                                                                    Height="32px" TabIndex="10" Text="Search"
                                                                    Width="90px" OnClick="BtnSearch_Click" />
                                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                                    CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                                    Text="Clear" ToolTip="To Clear  the Screen" Width="90px" Visible="False" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                                            <td style="width: 27px">&nbsp;</td>
                                                            <td valign="top">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: center;" colspan="3"
                                                                align="center">
                                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana"
                                                                    Font-Size="13px" ForeColor="#006600"></asp:Label>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                                        <asp:GridView ID="grdDetails" runat="server" AllowPaging="False"
                                                                            AutoGenerateColumns="False" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                            GridLines="Both" Height="62px"
                                                                            OnPageIndexChanging="grdDetails_PageIndexChanging"
                                                                            OnRowDataBound="grdDetails_RowDataBound" PageSize="15" Width="100%">
                                                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Sl No.">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="IndustryName" HeaderText="Industry Name" />
                                                                                <asp:BoundField DataField="Dept_Name" HeaderText="Department Name" />
                                                                                <asp:BoundField DataField="District_Name" HeaderText="District Name" />
                                                                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                                                                <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                                                                                <asp:BoundField DataField="Created_dt" HeaderText="Date" />
                                                                                <asp:BoundField DataField="Grivance_Subject" HeaderText="Subject" />
                                                                                <asp:BoundField DataField="Grievance_Description"
                                                                                    HeaderText="Description" />
                                                                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                                                                <asp:TemplateField HeaderText="Process">
                                                                                    <ItemTemplate>
                                                                                        <asp:Button ID="btnprocess" CssClass="btn btn-primary" OnClick="btnprocess_Click" runat="server" Text="PROCESS" Width="100px" />
                                                                                        <%--<a id="lnkChangeStatus"
                                                                                            href='frmFeedBackChangestatus.aspx?intGrievanceid=<%# Eval("intGrievanceid") %>'>Change Status</a>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:HyperLinkField HeaderText="Forward" Text="Forward" Visible="false" />
                                                                                <asp:BoundField DataField="RegisteredBy"
                                                                                    HeaderText="Registered By" Visible="false"/>
                                                                                 <asp:TemplateField HeaderText="intGrievanceid" Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblintGrievanceid" runat="server" Text='<%# Eval("intGrievanceid") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left" />

                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True"
                                                                                ForeColor="White" />
                                                                            <EditRowStyle BackColor="#B9D684" />
                                                                            <AlternatingRowStyle BackColor="White" />
                                                                        </asp:GridView>
                                                                        <tr>
                                                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">&nbsp;</td>
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
                    <%--<div class="overlay">
                      
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />

                        </div>

                    </div>--%>
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




