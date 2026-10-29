<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmR1Report.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    
<style   type="text/css">
.overlay
{
position: fixed;
z-index: 999;
height: 100%;
width: 100%;
top: 112px;
background-color:Gray;
filter: alpha(opacity=60);
opacity: 0.9;
-moz-opacity: 0.9;
}
    .style8
    {
        color: #FF0000;
        font-weight: bold;
    }
    .GRD
{
	
	height:auto;
	border-color:#013161;
	border-style:solid;
	border-width:1px;
text-transform:capitalize;
	padding:10px;
}

.GRDITEM
	{
	/*background-color: WHITE;*/
	color:black;	
	font-size:	12px;
	font-weight: normal;
	font-family:Verdana;
	padding:10px;
	/*text-decoration:none;*/
	/*border-color:#013161;*/
	/*border-style:solid;*/
	text-transform:uppercase;
	/*border-width:1px;*/
	/*height:23px;*/
	/*text-indent:5px;*/
	padding:10px;
	
	/*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
	}
	
	.GRDHEADER	
{
	color:#0E2A46;
	vertical-align:middle;
	text-align:center;
	height:25px;
	width:50px;
	padding:10px;
	font-size:	12px;
	font-weight: bold;
	text-transform:capitalize;
	font-family: Verdana;	
	BACKGROUND-IMAGE: url(../images/bg_blue_grd.gif);
	border-color:#ffffff;
	border-style:solid;
	border-width:1px;
	}
    </style>

<script type="text/javascript" language="javascript">

function OpenPopup() 
 
   {

    window.open("Lookups/LookupBDC.aspx","List","scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

    return false;
    }
    </script>
 <script type="text/javascript">
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
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
                                <i class="fa fa-fw fa-edit"></i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">R1: CM's DASH BOARD</a>
                            </li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">R1: CM's DASH BOARD</h3>
                            </div>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: right;" valign="top" 
                                            align="right">
                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" 
                                                class="form-control txtbox" Height="33px" 
                                                onselectedindexchanged="ddlProp_intDistrictid_SelectedIndexChanged" 
                                                Width="180px" Visible="False">
                                                <asp:ListItem>--District--</asp:ListItem>
                                            </asp:DropDownList>
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="style8" 
                                            style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                             <asp:Image ID="Image4" runat="server" Height="40px" 
                                                ImageUrl="~/images/printimage.jpg" Width="40px" />
                                            &nbsp;&nbsp;<asp:Image ID="Image3" runat="server" Height="40px" 
                                                ImageUrl="~/images/pdf-icon4.jpg" Width="40px" />
                                            &nbsp;
                                            <asp:Image ID="Image2" runat="server" Height="40px" 
                                                ImageUrl="~/images/Excel-icon.png" Width="40px" /></td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="style8" 
                                            style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="300px">Report as on: 30.03.2016</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;" 
                                            valign="top">
                                            <asp:GridView ID="grdDetails" runat="server" 
                                                AutoGenerateColumns="False" CellPadding="4" CssClass="box1" ForeColor="#333333" 
                                                Height="62px" PageSize="15" 
                                                ShowFooter="True" Width="100%">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
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
                                                    <asp:BoundField HeaderText="No of Applications" DataField="No of Application">
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="No of Department Approvals Required" 
                                                        DataField="No of Approvals Required">
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="No of  Department Approvals taken offline" 
                                                        DataField="No of Approvals Taken offline">
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Net Department Approvals required" 
                                                        DataField="Net Approvals required" />
                                                    <asp:BoundField HeaderText="No of Department Approvals Applied for" 
                                                        DataField="No of Approvals Applied for" />
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="LblProjCost" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="400px">Total Capital Investment (Rs. in Crores)</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;" 
                                            valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="Label482" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="621px">PRESCRUTINY STATUS OF APPROVALS APPLIED FOR</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;" 
                                            valign="top">
                                            <asp:GridView ID="grdDetails0" runat="server" AutoGenerateColumns="False" 
                                                CellPadding="4" CssClass="GRD" ForeColor="#333333" Height="62px" 
                                                PageSize="15" ShowFooter="True" 
                                                Width="100%">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid0" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid0" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Description" DataField="DType">
                                                        <ItemStyle Width="220px" />
                                                           </asp:BoundField>
                                                        
                                                    <asp:BoundField HeaderText="Completed" DataField="Completed">
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Query Raised" DataField="Query Raised">
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="No Query but Pending" 
                                                        DataField="No Query but Pending" />
                                                 
                                                    <asp:BoundField HeaderText="Total" DataField="Total" />
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: left;" 
                                            valign="top">
                                            <asp:GridView ID="grdDetails3" runat="server" AutoGenerateColumns="False" 
                                                CellPadding="4" CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" 
                                                ShowFooter="True" Width="100%">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid3" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid3" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DType" HeaderText="Description">
                                                        <ItemStyle Width="220px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Completed" HeaderText="Completed">
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Query Raised" HeaderText="Query Raised">
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="No Query but Pending" 
                                                        HeaderText="No querry, but Pending" />
                                                    <asp:BoundField DataField="Total" HeaderText="Total" />
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: left;" 
                                            valign="top">
                                            <asp:Label ID="Label483" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="400px">APPROVAL PROCESS STATUS</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;" 
                                            valign="top">
                                            <asp:GridView ID="grdDetails1" runat="server" AutoGenerateColumns="False" 
                                                CellPadding="4" CssClass="GRD" ForeColor="#333333" Height="62px" 
                                                 PageSize="15" ShowFooter="True" 
                                                Width="100%">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid1" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid1" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Description" DataField="DType">
                                                        <ItemStyle Width="220px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Approved" DataField="Approved">
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Under Process" DataField="Under Process">
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Rejected" DataField="Rejected" />
                                                    <asp:BoundField HeaderText="Total" DataField="Total" />
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" align="center">
                                           
                                            <asp:Label ID="Label484" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="400px">TS-iPASS APPROVALS</asp:Label>
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" 
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:GridView ID="grdDetails2" runat="server" AutoGenerateColumns="False" 
                                                CellPadding="4" CssClass="GRD" ForeColor="#333333" Height="62px" 
                                                 PageSize="15" ShowFooter="True" 
                                                Width="100%">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid2" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid2" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Description" DataField="DType">
                                                        <ItemStyle Width="220px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Total Applications fully paid" 
                                                        DataField="Total Appliacations Fully Paid">
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Total Applications Appd within time limits" 
                                                        DataField="Total Appliacations Approved with in Time Limits">
                                                        <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Total Applications Appd beyond time limits" 
                                                        DataField="TotalAppliacationsApprovedbeyondTimeLimits" />
                                                    <asp:BoundField HeaderText="Grand Total " DataField="Grand Total" />
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            
                                            
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label> 
  </div>
                                            
                                            
                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Warning!</strong> 
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
<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
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

