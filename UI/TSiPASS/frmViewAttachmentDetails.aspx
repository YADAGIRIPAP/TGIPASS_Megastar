<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/Lookups/CCLookupsMaster.master" AutoEventWireup="true" CodeFile="frmViewAttachmentDetails.aspx.cs" Inherits="TSTBDCReg1" %>

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
                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Compulsary Attachments<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" width="100%" align="center">
                                    <table cellpadding="5px" cellspacing="5px" style="font-size: 14px; font-family: Verdana; width:100%" >
                                        <tr>
                                            <td   style="border: 1px solid #003366; font-weight: 700;">
                                                S.No
                                            </td>
                                            <td  style="border: 1px solid #003366; font-weight: 700;">
                                                Attachment Type
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: 700;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                1
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                Self Certification Form
                                            </td>
                                            <td style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#FF6600" Target="_blank">[HyperLink1]</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                2
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                Registration Deed
                                            </td>
                                            <td style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="#FF6600" Target="_blank">[HyperLink1]</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                3
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                Mutation order
                                            </td>
                                            <td style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink3" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                4
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                Combined building plan including all floor plans
                                            </td>
                                            <td style="border: 1px solid #003366">
                                                <%--<asp:HyperLink ID="HyperLink4" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>--%>
                                                <asp:GridView ID="gvUpload4" runat="server" AutoGenerateColumns="False" CellPadding="3" EnableModelValidation="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowDataBound="gvUpload4_RowDataBound" >
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblslno" runat="server" Text="<%#Container.DataItemIndex + 1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="File Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Attachment">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hprlink" runat="server" Text="View" NavigateUrl='<%#Eval("link") %>'></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Attachment" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFileNamenew" runat="server" Text='<%#Eval("LINKNEW") %>'></asp:Label>                                                                
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                5
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                Combined site plan
                                            </td>
                                            <td style="border: 1px solid #003366">
                                                <%--<asp:HyperLink ID="HyperLink5" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>--%>
                                                <asp:GridView ID="gvUpload5" runat="server" AutoGenerateColumns="False" CellPadding="3" EnableModelValidation="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblslno" runat="server" Text="<%#Container.DataItemIndex + 1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="File Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Attachment">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hprlink" runat="server" Text="View" NavigateUrl='<%#Eval("link") %>'></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                6
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                Partnership details (or) Articles of Association (AOA)
                                            </td>
                                            <td style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink6" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                7
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                Process Flow Chart (Diagram)
                                            </td>
                                            <td style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink7" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                8
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                PAN / AADHAAR
                                            </td>
                                            <td style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink8" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                                <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" align="center">
                                    <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="236px">Offline Approval Attachments</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; " valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%">
                                        <tr>
                                            <td  style="border: 1px solid #003366; font-weight: bold; height: 27px;">
                                                S.No
                                            </td>
                                            
                                            <td style="border: 1px solid #003366; font-weight: bold; height: 27px;">
                                                Approval Name
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: bold; height: 27px;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Panel ID="pnlOflSno" runat="server">
                                                </asp:Panel>
                                            </td>
                                          
                                             <td >
                                                <asp:Panel ID="pnlOflAppr" runat="server">
                                                </asp:Panel>
                                            </td>
                                            <td >
                                                <asp:Panel ID="pnlOflPath" runat="server">
                                                </asp:Panel>
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
                                <td align="left" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="196px">Additional Attachments</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; width: 100%" valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%" style="font-size: 14px; font-family: verdana;">
                                        <tr>
                                            <td   style="border: 1px solid #003366; font-weight: bold;">
                                                S.No
                                            </td>
                                            <td  style="border: 1px solid #003366; font-weight: bold;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                <asp:Panel ID="AdditionalSno" runat="server">
                                                </asp:Panel>
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                <asp:Panel ID="AdditionalHyper" runat="server">
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" align="center">
                                    <asp:Label ID="Label427" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="196px">Approval Attachments</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; " valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%">
                                        <tr>
                                            <td  style="border: 1px solid #003366; font-weight: bold;">
                                                S.No
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: bold;">
                                                Department Name
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: bold;">
                                                Approval Name
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: bold;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Panel ID="Panel3" runat="server">
                                                </asp:Panel>
                                            </td>
                                            <td >
                                                <asp:Panel ID="Panel7" runat="server">
                                                </asp:Panel>
                                            </td>
                                             <td >
                                                <asp:Panel ID="Panel8" runat="server">
                                                </asp:Panel>
                                            </td>
                                            <td >
                                                <asp:Panel ID="Panel4" runat="server">
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="196px">Digital Sign Plan Document</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; width:100%"" valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%">
                                        <tr>
                                            <td  style="border: 1px solid #003366; font-weight: bold;">
                                                S.No
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: bold;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Panel ID="Panel9" runat="server">
                                                </asp:Panel>
                                            </td>
                                            <td >
                                                <asp:Panel ID="Panel10" runat="server">
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="196px">DPMS Plan Document</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; width:100%"" valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%">
                                        <tr>
                                            <td  style="border: 1px solid #003366; font-weight: bold;">
                                                S.No
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: bold;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Panel ID="Panel11" runat="server">
                                                </asp:Panel>
                                            </td>
                                            <td >
                                                <asp:Panel ID="Panel12" runat="server">
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trcoi1" runat="server" visible="false">
                               <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                   <asp:Label ID="LBLCOI" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="196px">COI ATTACHMENT</asp:Label>
                               </td>
                           </tr>
                           <tr id="trcoi2" runat="server" visible="false">
                               <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                   <table cellpadding="5px" cellspacing="5px" width="100%" style="font-size: 14px; font-family: verdana;">
                                       <tr>
                                           <td class="style9" style="border: 1px solid #003366; font-weight: bold;">
                                               S.No
                                           </td>
                                           <td class="style10" style="border: 1px solid #003366; font-weight: bold;">
                                               Attachment Path
                                           </td>
                                       </tr>
                                       <tr>
                                           <td class="style9" style="border: 1px solid #003366">
                                               1
                                           </td>
                                           <td class="style10" style="border: 1px solid #003366">
                                               <asp:HyperLink ID="HyperLinkcoi" runat="server" ForeColor="#FF6600">TS-iPASS consolidated certificate</asp:HyperLink>
                                           </td>
                                       </tr>
                                   </table>
                               </td>
                           </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label428" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="196px">Respondant Attachment</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; width:100%"" valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%">
                                        <tr>
                                            <td  style="border: 1px solid #003366; font-weight: bold;">
                                                S.No
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: bold;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Panel ID="Panel5" runat="server">
                                                </asp:Panel>
                                            </td>
                                            <td >
                                                <asp:Panel ID="Panel6" runat="server">
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                             <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="250px">Rejection Attachments</asp:Label>
                                </td>
                            </tr>
                           <tr>
                                <td style="padding: 5px; margin: 5px; width:100%"" valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%">
                                        <tr>
                                            <td  style="border: 1px solid #003366; font-weight: bold;">
                                                S.No
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: bold;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Panel ID="pnlRejectionAttachment" runat="server">
                                                </asp:Panel>
                                            </td>
                                            <td >
                                                <asp:Panel ID="pnlRejectionAttachment1" runat="server">
                                                <asp:HyperLink ID="hplRejectedDoc" runat="server" ForeColor="#FF6600">[RejectedDoc]</asp:HyperLink>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="250px">Appeal Attachments</asp:Label>
                                </td>
                            </tr>
                                <tr>
                                <td style="padding: 5px; margin: 5px; width:100%"" valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%">
                                        <tr>
                                            <td  style="border: 1px solid #003366; font-weight: bold;">
                                                S.No
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: bold;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:Panel ID="pnlAppealCount" runat="server">
                                                </asp:Panel>
                                            </td>
                                            <td >
                                                <asp:Panel ID="pnlAppeal" runat="server">
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                           
                            <tr>
                                <%--<td style="padding: 5px; margin: 5px; " valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%" style="font-size: 14px; font-family: verdana;">
                                        <tr>
                                            <td   style="border: 1px solid #003366; font-weight: bold;">
                                                S.No
                                            </td>
                                            <td  style="border: 1px solid #003366; font-weight: bold;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                 <asp:Panel ID="pnlAppeal2" runat="server">
                                                </asp:Panel>
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                <%--<asp:HyperLink ID="HyperLink9" runat="server" ForeColor="#FF6600"></asp:HyperLink>
                                                 <asp:Panel ID="pnlAppeal1" runat="server">
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>--%>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="196px">Payment proof Attachments</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; " valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%" style="font-size: 14px; font-family: verdana;">
                                        <tr>
                                            <td   style="border: 1px solid #003366; font-weight: bold;">
                                                S.No
                                            </td>
                                            <td  style="border: 1px solid #003366; font-weight: bold;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                <asp:Panel ID="Panel2" runat="server">
                                                </asp:Panel>
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                <asp:Panel ID="Panel1" runat="server">
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="196px">Land Details 
Attachments</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; " valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%" style="font-size: 14px; font-family: verdana;">
                                        <tr>
                                            <td   style="border: 1px solid #003366; font-weight: bold;">
                                                S.No
                                            </td>
                                            <td  style="border: 1px solid #003366; font-weight: bold;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                1
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink11" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                2
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink12" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                3
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink13" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label425" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="250px">Response Query Attachments</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; " valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%" style="font-size: 14px; font-family: verdana;">
                                        <tr>
                                            <td   style="border: 1px solid #003366; font-weight: bold;">
                                                S.No
                                            </td>
                                            <td  style="border: 1px solid #003366; font-weight: bold;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                1
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink14" runat="server" ForeColor="#FF6600">[HyperLink1]</asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr 
                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr style="display:none">
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label426" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="196px">Approval Attachments</asp:Label>
                                </td>
                            </tr>
                            <tr style="display:none">
                                <td style="padding: 5px; margin: 5px; " valign="top" align="center">
                                    <table cellpadding="5px" cellspacing="5px" width="100%" style="font-size: 14px; font-family: verdana;">
                                        <tr>
                                            <td   style="border: 1px solid #003366; font-weight: bold;">
                                                S.No
                                            </td>
                                            <td style="border: 1px solid #003366; font-weight: bold;">
                                                Attachment Path
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   style="border: 1px solid #003366">
                                                1
                                            </td>
                                            <td  style="border: 1px solid #003366">
                                                <asp:HyperLink ID="HyperLink15" runat="server" ForeColor="#FF6600" Target="_blank">[HyperLink1]</asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="196px">Hmda Attachments</asp:Label>
                                </td>
                            </tr>
                            <tr id="hmdaattachements" runat="server" visible="false">
                                <td style="padding: 10px; margin: 5px;">
                                    <asp:GridView ID="gvlastattachments" runat="server" AutoGenerateColumns="False"
                                        Width="80%" HorizontalAlign="Left" ShowHeader="true"  OnRowDataBound="gvlastattachments_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Attachments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Attachment" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFileNamenew" runat="server" Text='<%#Eval("LINKNEW") %>'></asp:Label>                                                                
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" align="center" class="style7">
                                    &nbsp;<asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px"
                                        Visible="False" />
                                    &nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Next" Width="90px"
                                        OnClientClick="return confirm('Do you want to Next the record ? ');" Visible="False" />
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <caption>
                                        &nbsp;</caption>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                            &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                            Warning!</strong>
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
