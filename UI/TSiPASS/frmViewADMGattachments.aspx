<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmViewADMGattachments.aspx.cs" Inherits="UI_TSiPASS_frmViewADMGattachments" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    
<%--<style type="text/css">
  

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
    .style7
    {
        color: #FF3300;
    }
    .style9
    {
        width: 27px;
    }
    .style10
    {
        width: 341px;
    }
</style>--%>

<script type="text/javascript" language="javascript">

    function OpenPopup() {

        window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

        return false;
    }

</script>
    <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
   <%-- </div>
       </td>
        </tr>
    </table>--%>
<div align="left">
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx"></a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-edit">ADM&G</i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">Attachment Details</a>
                            
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            View Attachment Details</h3>
                    </div>
                    <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="285px">ADM&G Application Attachments<font 
                                                            color="red">*</font></asp:Label></br>
                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="174px">ADM&G Application ID:<font 
                                                            color="red">*</font></asp:Label>
                                    <asp:Label ID="LblADMGID" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="154px" Height="16px"><font 
                                                            color="red"></font></asp:Label>
                                    <%--<asp:TextBox ID="txtADMGID" runat="server"  Font-Bold="True" Width="285px"/>--%>  
                                </td>

                                
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" width="100%" align="center">
                                    <table cellpadding="5px" cellspacing="5px" style="font-size: 14px; font-family: Verdana; width:100%" >
                                        <tr>
                                            <td   style="border: 1px solid #003366; font-weight: 700; width: 49px;">
                                                S.No
                                            </td>
                                            <td  style="border: 1px solid #003366; font-weight: 700;">
                                                Attachment Type
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: 700;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr id="trDGPS" runat="server">
                                            <td   style="border: 1px solid #003366; width: 49px;">
                                                1
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                DGPS Map
                                            </td>
                                            <td style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                            </td>
                                        </tr>
                                       
                                       <%-- <tr id="trOthDoc" runat="server">
                                            <td   style="border: 1px solid #003366; width: 49px;">
                                                3
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                Other Documents</td>
                                            <td style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink3" runat="server" ForeColor="#FF6600">[HyperLink3]</asp:HyperLink>
                                            </td>
                                        </tr>--%>
                                        
                                    </table>
                                </td>
                            </tr>

                                
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    &nbsp;
                                </td>
                            </tr>
                            
                            
                            
                            
                            
                            
                  
                            
                            
                             
                           
                            
                                
                           
                            
                            
                            <tr>
                                <td style="padding: 5px; margin: 5px; " valign="top" align="center">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            
                   
                        </table>

                        <table id="tblapproved" visible="false" runat="server" align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="359px">ADM&G Application Approved Attachments<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" width="100%" align="center">
                                    <table cellpadding="5px" cellspacing="5px" style="font-size: 14px; font-family: Verdana; width:100%" >
                                        <tr>
                                            <td   style="border: 1px solid #003366; font-weight: 700; width: 49px;">
                                                S.No
                                            </td>
                                            <td  style="border: 1px solid #003366; font-weight: 700;">
                                                Attachment Type
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: 700;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        
                                        
                                        
                                        <tr id="trNOC" runat="server" visible="false">
                                            <td   style="border: 1px solid #003366; width: 49px;">
                                                1
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                NOC</td>
                                            <td style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink4" runat="server" ForeColor="#FF6600">[HyperLink4]</asp:HyperLink>
                                            </td>
                                        </tr>
                                         <tr id="trSignedDGPS" visible="false" runat="server">
                                            <td   style="border: 1px solid #003366; width: 49px;">
                                                2
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                Signed DGPS</td>
                                            <td style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="#FF6600">[HyperLink2]</asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                                
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    &nbsp;
                                </td>
                            </tr>
                            
                            
                            
                            
                            
                            
                  
                            
                            
                             
                           
                            
                                
                           
                            
                            
                            <tr>
                                <td style="padding: 5px; margin: 5px; " valign="top" align="center">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            
                   
                        </table>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                    </div>
                    <%--       </ContentTemplate>
</asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
    <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>--%>
    <%--<div class="overlay">--%>
    <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
    <%--<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">--%>
    <%--<img alt="" src="../../Resource/Images/Processing.gif" />
--%>
    </div> </div>
    <%--</ProgressTemplate>
</asp:UpdateProgress> --%>
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
    <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
    <%-- </div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
