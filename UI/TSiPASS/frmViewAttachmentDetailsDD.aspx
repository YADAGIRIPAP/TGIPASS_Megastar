<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/Lookups/CCLookupsMaster.master" AutoEventWireup="true" CodeFile="frmViewAttachmentDetailsDD.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


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
background-color:Gray;
filter: alpha(opacity=60);
opacity: 0.9;
-moz-opacity: 0.9;
}
    .style9
    {
        width: 27px;
    }
    .style10
    {
        width: 341px;
    }
</style>

<script type="text/javascript" language="javascript">

function OpenPopup() 
 
   {

    window.open("Lookups/LookupBDC.aspx","List","scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

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
                                <i class="fa fa-fw fa-edit">CAF</i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">Attachment Details</a>
                            </li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">View Attachment Details</h3>
                            </div>
                          <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                            <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="196px">Demand Draft Attachments</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                            <table cellpadding="5px" cellspacing="5px" 
                                                width="100%" style="font-size: 14px; font-family: verdana;">
                                                <tr>
                                                    <td class="style9" style="border: 1px solid #003366; font-weight: bold;">
                                                        S.No</td>
                                                    <td class="style10" style="border: 1px solid #003366; font-weight: bold;">
                                                        Attachment Path</td>
                                                </tr>
                                                <tr>
                                                    <td class="style9" style="border: 1px solid #003366">
                                            <asp:Panel ID="Panel2" runat="server">
                                                        
                                                    </asp:Panel>
                                                    </td>
                                                    <td class="style10" style="border: 1px solid #003366">
                                            <asp:Panel ID="Panel1" runat="server">
                                                        
                                                    </asp:Panel>
                                                    </td>
                                                </tr>
                                                </table>
                                        </td>
                                    </tr>
                                            <caption>
                                                &nbsp;</caption>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            
                                            
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
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
</div>
    
</div>
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

