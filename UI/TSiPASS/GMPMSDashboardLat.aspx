<%@ Page Title=":: IPO MIS :: Dash Board" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="GMPMSDashboardLat.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" language="javascript">




    </script>
    
    
    

    <asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
<div align="left">
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx">Dashboard</a>
                            </li>
                            
                           
                        </ol>
     </div>
    
<div align="center">
<div class="row" align="center">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">GM&nbsp; Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                  <div>  
                                  <table><tr><td> <b>   Month :</b> </td><td> <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" 
                                                   Height="33px" TabIndex="1" Width="180px">
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
                                               </asp:DropDownList></td> <td></td><td><b>   Year : </b></td><td> <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem>2016</asp:ListItem>
                                                                </asp:DropDownList></td>
                                      <td>
                                          &nbsp;</td>
                                      <td>
                                          <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                                              Height="32px" OnClick="BtnSave1_Click" TabIndex="10" Text="Previous Month" 
                                              ValidationGroup="group" Width="140px" />
                                      </td>
                                      <td>
                                          &nbsp;</td>
                                      <td>
                                          <asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                              CssClass="btn btn-warning" Height="32px" onclick="BtnClear_Click" TabIndex="10" 
                                              Text="Current Month" ToolTip="To Clear  the Screen" Width="140px" />
                                      </td>
                                      </tr>
                                      <tr>
                                          <td colspan="5">
                                              &nbsp;</td>
                                          <td>
                                              &nbsp;</td>
                                          <td>
                                              &nbsp;</td>
                                          <td>
                                              &nbsp;</td>
                                          <td>
                                              &nbsp;</td>
                                      </tr>
                                      <tr>
                                          <td colspan="5">
                                              <asp:Label ID="Label25" runat="server" Font-Bold="true" 
                                                  Text="Performance Report on September 2016"></asp:Label>
                                          </td>
                                          <td>
                                              &nbsp;</td>
                                          <td>
                                              &nbsp;</td>
                                          <td>
                                              &nbsp;</td>
                                          <td>
                                              &nbsp;</td>
                                      </tr>
                                      </table>        
                                           
                                              
                                           
                                                                </div> 
                                                               
                                               &nbsp;<div class="panel panel-default">
                            <div class="panel-body" align="center">
                             
                                <table cellpadding="3" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="font-size: 16px; text-align: center;" colspan="3" >
                                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" 
                                                NavigateUrl="~/UI/TSiPASS/IPOPMSDashboard.aspx">Back</asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <b>Target Entry</b></td>
                                        <td style="width: 30px">
                                            &nbsp;</td>
                                        <td style="width: 395px; font-size: 16px;">
                                            <b>GM Need to be Updated</b></td>
                                    </tr>
                                 
                                    <tr>
                                        <td style="width: 395px" valign="top">
                                             <div class="list-group">
                                            
                                              <a  class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="Label4" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Target Entry
                                    </a>
                                            
                                             
                                                
                                            
                                                
                                                
                                                <a class="list-group-item" href="#"><span class="badge">
                                                <asp:Label ID="Label6" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-check"></i> Total Target of IPO's </a>
                                                 
                                                
                                                <a class="list-group-item" href="#"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label7" runat="server"></asp:Label>
                                                </span><i class="fa fa-spinner fa-spin"></i>Target Completed by IPO's</a>
                                                
                                                <a class="list-group-item" href="#"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label26" runat="server"></asp:Label>
                                                </span><i class="fa fa-spinner fa-spin"></i>Target Pending by IPO's</a>
                                               
                                               
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;</td>
                                        <td valign="top" style="width: 395px">                                        
                                          <div class="list-group">
                                              
                                                
                                                
                                                
                                                
                                                
                                                <a href="#" class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="Label1" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i> Total Received
                                    </a>
                                            
                                             
                                                
                                            
                                                
                                                
                                                <a class="list-group-item" href="#"><span class="badge">
                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-check"></i> Completed </a>
                                                 
                                                
                                                <a class="list-group-item" href="#"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                                </span><i class="fa fa-spinner fa-spin"></i>Pending</a>
                                               
                                               <a class="list-group-item" href="#"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label8" runat="server"></asp:Label>
                                                </span><i class="fa fa-spinner fa-spin"></i>Rejected</a>
                                                
                                        </td>
                                    </tr>
                                    
                                      <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <b>TSiPASS</b></td>
                                        <td style="width: 30px">
                                            &nbsp;</td>
                                        <td style="width: 395px; font-size: 16px;">
                                            <b>Advance Subsidy</b></td>
                                    </tr>
                                 
                                    <tr>
                                        <td style="width: 395px; height: 148px;" valign="top">
                                             <div class="list-group">
                                          
                                            
                                              <a  class="list-group-item">
                                        <span class="badge">
                                            <asp:Label ID="Label5" runat="server"></asp:Label></span>
                                        <i class="fa fa-fw fa-calendar"></i>  Completed
                                    </a>
                                            
                                             <a class="list-group-item" href="#"><span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label28" runat="server"></asp:Label>
                                                </span><i class="fa fa-spinner fa-spin"></i>Pending</a>
                                                
                                            
                                                
                                                
                                               
                                               
                                               
                                            </div>
                                        </td>
                                        <td style="width: 30px; height: 148px;">
                                            </td>
                                        <td valign="top" style="width: 395px; height: 148px;">                                        
                                            <div class="list-group">
                                                <a class="list-group-item" href="#"><span class="badge">
                                                <asp:Label ID="Label14" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-check"></i>Completed </a>
                                                <a class="list-group-item" href="VehicleInspection.aspx"><span class="badge" 
                                                    style=" background-color:#d9534f;">
                                                <asp:Label ID="Label15" runat="server"></asp:Label>
                                                </span><i class="fa fa-spinner fa-spin"></i>Pending</a>
                                            </div>
                                        </td>
                                    </tr>
                                    
                                      <tr>
                                        <td style="width: 395px; font-size: 16px; height: 27px;">
                                            &nbsp;</td>
                                        <td style="width: 30px; height: 27px;">
                                            </td>
                                        <td style="width: 395px; font-size: 16px; height: 27px;">
                                            </td>
                                    </tr>
                                 
                                    <tr>
                                        <td style="width: 395px" valign="top">
                                             &nbsp;</td>
                                        <td style="width: 30px">
                                            &nbsp;</td>
                                        <td valign="top" style="width: 395px">                                        
                                            &nbsp;</td>
                                    </tr>
                                    
                                </table>
                                &nbsp;
                               
                            </div>
                        </div>
                                            
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <table cellpadding="2" style="width: 100%">
                                                <tr>
                                                    <td style="width: 417px">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                   
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

    </div>
              
                 
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

