<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master"AutoEventWireup="true" CodeFile="CommissionerApproval.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  

 <script type="text/javascript">
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }
</script>
<script type="text/javascript" language="javascript">
    var win = new Object();
    function Popup(intval) {

        win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
        //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

    }
</script>

<script type="text/javascript" language="javascript">
    var win = new Object();
    function PopupN(intval) {

        win = window.open("CFEPopupDept.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
        //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

    }
</script>

    <asp:UpdatePanel ID="upd1" runat="server">
<ContentTemplate>
<div align="left">
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx"></a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-edit">COMMISSIONER</i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#"></a>
                            </li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">DISTRICT WISE REPORT</h3>
                            </div>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 98%">
                                    
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                            <asp:GridView ID="grdDetails" runat="server"
                                                AutoGenerateColumns="False" CellPadding="5" ForeColor="#333333" 
                                                Height="62px" onrowdatabound="grdDetails_RowDataBound" 
                                                ShowFooter="True" Width="100%">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="UID">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                                                               </ItemTemplate>
                                                               <HeaderStyle HorizontalAlign="Left" />
                                                               </asp:TemplateField>
                                                    <asp:BoundField DataField="DateApplied" HeaderText="Date applied" />
                                                    <asp:BoundField DataField="nameofunit" HeaderText="Name of Unit" />
                                                    <asp:BoundField  Visible="false" DataField="NameofthePromoter" HeaderText="Name of Industry">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Ent_is" HeaderText="Enterprise Type">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PLoutionCategorys" HeaderText="Ploution Cateogry" />
                                                    <asp:BoundField DataField="Sec_EnterpriseName" HeaderText="Activity Proposed" />
                                                    <asp:BoundField Visible="false" DataField="LastDateofPreScrutiy" 
                                                        HeaderText="Last Date of Pre-Scrutiny" />
                                                    <asp:HyperLinkField HeaderText="CFE/CFO" Text="View" />
                                                    <asp:HyperLinkField HeaderText="Attachments" Text="Attachments" />
                                                    <asp:HyperLinkField HeaderText="Query / Response" Text="Query / Response" />
                                                    <asp:TemplateField  HeaderText="Status">
                                                        <ItemTemplate>
                                                            <br />
                                                            <asp:HyperLink ID="HyperLink1" runat="server">View Certificate</asp:HyperLink>
                                                            <br />
                                                            <asp:Label ID="Label377" runat="server" CssClass="LBLBLACK" Width="180px">Status</asp:Label>
                                                            <br />
                                                            <asp:DropDownList ID="ddlStatus" runat="server" class="form-control txtbox" 
                                                                Height="33px" Width="180px" 
                                                                onselectedindexchanged="ddlStatus_SelectedIndexChanged">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="14">Commissioner Approval</asp:ListItem>
                                                                <asp:ListItem Value="15">Generate Certificate</asp:ListItem>
                                                               
                                                                  
                                                            </asp:DropDownList>
                                                            <br />
                                                            <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="180px" 
                                                                Visible="False">Query Description</asp:Label>
                                                            <br />
                                                            <asp:TextBox ID="txtPromotor" runat="server" class="form-control txtbox" 
                                                                Height="40px" MaxLength="40" TabIndex="1" ValidationGroup="group" 
                                                                Width="180px" Visible="False" TextMode="MultiLine"></asp:TextBox>
                                                            <br />
                                                            <asp:Label ID="Label379" runat="server" CssClass="LBLBLACK" Visible="False" 
                                                                Width="180px">Amount</asp:Label>
                                                            <br />
                                                            <asp:TextBox ID="txtAmount" runat="server" class="form-control txtbox" 
                                                                Height="27px" MaxLength="40" TabIndex="1" ValidationGroup="group" 
                                                                Visible="False" Width="180px"></asp:TextBox>
                                                            <br />
                                                            <asp:HiddenField ID="hdfApplID" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField   HeaderText="Submit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="BtnSave" runat="server" CausesValidation="False" 
                                                                CssClass="btn-success" Height="32px" onclick="BtnSave_Click1" 
                                                              
                                                                TabIndex="10" Text="Submit" ValidationGroup="group" Width="80px" />
                                                            <asp:HiddenField ID="hdfGroundedNo" runat="server" />
                                                            <asp:HiddenField ID="hdfGroundedNo0" runat="server" />
                                                            <asp:HiddenField ID="hdfGroundedNo1" runat="server" />
                                                            <asp:HiddenField ID="hdfGroundedNo2" runat="server" />
                                                            <asp:HiddenField ID="hdfGroundedNo3" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:BoundField Visible="false" DataField="ApprovalName" 
                                                        HeaderText="Approval name" />
                                                        <asp:BoundField DataField="LastDateofPreScrutiy"  Visible="false" 
                                                        HeaderText="Last Date of Pre-Scrutiny" />
                                                        <asp:TemplateField HeaderText="Approval Status">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
                                                               </ItemTemplate>
                                                               <HeaderStyle HorizontalAlign="Left" />
                                                               </asp:TemplateField>
                                                        
                                                        
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" font-bold="True" 
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            &nbsp;<tr>
                                                <td align="center" style="padding: 5px; margin: 5px">
                                                    &nbsp;</td>
                                            </tr>
                                            <caption>
                                                &nbsp;</caption>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            <div ID="success" runat="server" class="alert alert-success" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" 
                                                    href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label 
                                                    ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                            <div ID="Failure" runat="server" class="alert alert-danger" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>
                                                Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
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
<%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
<div style=" z-index: 1000; margin-left: 250px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
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
        
          
                       
  </ContentTemplate>
  </asp:UpdatePanel>
 <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

