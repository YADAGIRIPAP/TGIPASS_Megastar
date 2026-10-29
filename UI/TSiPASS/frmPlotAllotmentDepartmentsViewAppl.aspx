<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmPlotAllotmentDepartmentsViewAppl.aspx.cs" Inherits="UI_TSiPASS_frmPlotAllotmentDepartmentsViewAppl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        .style8
        {
            height: 30px;
        }
        .style9
        {
            width: 27px;
            height: 30px;
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
    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {
            win = window.open("PlotAllotmentDeptPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");          
        }
    </script>
    <script type="text/javascript" language="javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; 
            var charCode = e.which || e.keyCode;
            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 46 && charCode != 47) {
                return true;
            }
            return false;
        }
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">Plot Allotment</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">View Applications</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    View Applications</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="7" cellspacing="7" width="100%">
                                                        <tr>
                                                            <td valign="top">
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_headnameofunit" runat="server" CssClass="LBLBLACK" Width="180px">Name of Unit</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_nameofUnit" runat="server"  class="form-control txtbox"
                                                                    Height="28px" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_headuidnono" runat="server" CssClass="LBLBLACK" Width="180px">UID Number</asp:Label>
                                                            </td>
                                                            <td valign="top">
                                                                :
                                                            </td>
                                                            <td valign="top">
                                                                <asp:TextBox ID="txt_uidno" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbl_headdistrict" runat="server" CssClass="LBLBLACK" Width="180px">District</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox"
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                              &nbsp;
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="center" colspan="3">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="center" colspan="3">
                                                                <asp:Button ID="btn_searchdata" runat="server" CausesValidation="False" CssClass="btn-success"
                                                                    Height="32px" OnClick="btn_searchdata_Click" TabIndex="10" Text="Search" ValidationGroup="group"
                                                                    Width="80px" />
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5"
                                                        ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound" ShowFooter="True"
                                                        Width="100%">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="View">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnk_griduidno" runat="server" Text='<%# Eval("UIDNo") %>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="NameOftheFirm_Applicant" HeaderText="Firm Applicant Name" />   
                                                            
                                                            <asp:BoundField DataField="ApprovalName" HeaderText="Approval name" />
                                                            <asp:BoundField DataField="DateofSubmittion" HeaderText="Date of Submission" />
                                                            <asp:BoundField DataField="LastDateofPreScrutiy" HeaderText="Last Date of Pre-Scrutiny" />

                                                             <asp:BoundField DataField="District_Name" HeaderText="District name" />
                                                             <asp:BoundField DataField="IndustrialParkId" HeaderText="Industrial Park" />
                                                            <asp:HyperLinkField HeaderText="Plot Allotment Form" Text="View" />  
                                                            <asp:HyperLinkField HeaderText="Payment Details" Text="Payment Details" /> 
                                                            
                                                           <asp:HyperLinkField HeaderText="Query Details" Text="Query Details" />   
                                                         
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                   Current Status
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_grdcurrentstatus" runat="server" />     
                                                                </ItemTemplate>
                                                            </asp:TemplateField>      
                                                              <asp:BoundField DataField="Dept_Name" HeaderText="Transfered From" />
                                                            <asp:BoundField DataField="UPDATEDFLAG" HeaderText="Process" />
                                                            
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_grdbiewstatus" runat="server" CssClass="LBLBLACK" Width="180px">Status</asp:Label>
                                                                    <br />
                                                                    <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                        Height="33px" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" Width="180px">
                                                                        <asp:ListItem>--Select--</asp:ListItem>                                                                       
                                                                        <asp:ListItem Value="5">Query Raised</asp:ListItem>
                                                                        <asp:ListItem Value="19">Deffered</asp:ListItem>
                                                                        <asp:ListItem Value="13">Approved</asp:ListItem>                                                           
                                                                        <asp:ListItem Value="16">Rejected</asp:ListItem>                                                                 
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <asp:Label ID="LabelDiscription" Font-Bold="true" ForeColor="Red" runat="server"
                                                                        CssClass="LBLBLACK" Visible="False" Width="180px"></asp:Label><br />
                                                                    <asp:Label ID="lbl_statusselectedtext" runat="server" CssClass="LBLBLACK" Visible="False" Width="180px"></asp:Label>
                                                                    <br />
                                                                    <asp:TextBox ID="txt_gdreason" runat="server" class="form-control txtbox" Height="40px"
                                                                        TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Visible="False" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_gdreason"
                                                                        ErrorMessage="Please Enter Discription" TabIndex="1" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    <br />         
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Submit">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="BtnSave" runat="server" CausesValidation="False" CssClass="btn-success"
                                                                        Height="32px" OnClick="BtnSave_Click1" OnClientClick="return confirm('Do you want to update the record ? ');"
                                                                        TabIndex="10" Text="Submit" ValidationGroup="group" Width="80px" />

                                                                     <asp:HiddenField ID="hdfApplID" Value='<%# Eval("ApplicationId") %>' runat="server" />
                                                                       <asp:HiddenField ID="hf_intDeptid" Value='<%# Eval("intDeptid") %>' runat="server" />
                                                                     <asp:HiddenField ID="hf_intApprovalid" Value='<%# Eval("intApprovalid") %>' runat="server" />
                                                                     <asp:HiddenField ID="hf_intstageid" Value='<%# Eval("intstageid") %>' runat="server" />
                                                                    <asp:HiddenField ID="hf_LastDateofPreScrutiy" Value='<%# Eval("LastDateofPreScrutiy") %>' runat="server" />
                                                                    <asp:HiddenField ID="hf_grduidno" Value='<%# Eval("UIDNo") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    &nbsp;<tr>
                                                        <td align="center" style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        &nbsp;</caption>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">
                                                            ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
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
                 
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
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
</asp:Content>

