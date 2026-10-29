<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmtradeRenewal.aspx.cs" Inherits="UI_TSiPASS_frmtradeRenewal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div1" align="left" runat="server">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Trade License Payment</h3>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 70%">

                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <table class="table table-hover" >
                                                <thead>
                                                    <tr>
                                                        <td colspan="3" style="color: blue;">Enter your TIN(Trade Identification Number) to check the Dues.</td>
                                                        <td></td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td  colspan="1" style="font-weight: bold; width: 79px;">TIN NO:
															 <br>
                                                            <small>(Ex.9999-999-9999)</small>
                                                        </td>
                                                        
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txttinNo" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                Height="28px" TabIndex="1" name="userProperties(tinNo)" MaxLength="13" value="" ValidationGroup="group" Width="200px" Font-Bold="true" Font-Size="15px"></asp:TextBox>
                                                        </td>
                                                         <td class="fa fa-search">
                                                            <asp:Button ID="btnfeesdetails" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="2" ValidationGroup="group" Width="190px" Text="Know Trade License Fee Dues" OnClick="btnfeesdetails_Click"></asp:Button>
                                                        </td>

                                                    </tr>
                                                    
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="trtradelicence" runat="server" Visible="false">
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Label ID="Label1" runat="server"><b>i) Trade Licence Details </b></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;1.</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="180px">TIN NO<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtTin" runat="server" class="form-control txtbox"
                                                            Height="28px"  TabIndex="3"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;2.</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="180px">Title Of Trade<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txttitletrade" runat="server" class="form-control txtbox"
                                                            Height="28px"  TabIndex="4" onkeypress="Names()"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                </tr>

                                                <tr>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;3.</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="180px">Trade Address</asp:Label>
                                                    </td>
                                                    <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txttradeaddress" runat="server" class="form-control txtbox"
                                                            Height="40px" TabIndex="5" TextMode="MultiLine"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                </tr>

                                                <tr id="Tr1" runat="server">

                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;4.</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="200px">Category</asp:Label>
                                                    </td>
                                                    <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtCatogory" runat="server" class="form-control txtbox"
                                                            Height="28px"  TabIndex="6" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                </tr>

                                                
                                                <tr id="Tr2" runat="server">
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;6.</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="200px">Plinth Area</asp:Label>
                                                    </td>
                                                    <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="Txtplinth" runat="server" class="form-control txtbox"
                                                            Height="28px"  TabIndex="8" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                </tr>
                                                
                                    
                                    <tr id="Tr3" runat="server">
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;8.</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="200px">Name of Owner</asp:Label>
                                        </td>
                                        <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:TextBox ID="txtownername" runat="server" class="form-control txtbox"
                                                Height="28px" TabIndex="10" 
                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                    </tr>
                                   
                                </table>
                                </td>
                                        <td style="width: 27px">
                                            <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                        </td>
                                <td valign="top">
                                               <table cellpadding="4" cellspacing="5" style="width: 83%">
                                               <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    </td>
                                                    <td class="style8" style="padding: 5px; margin: 5px"></td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                       
                                                    </td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    </td>
                                                    <td class="style8" style="padding: 5px; margin: 5px"></td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        
                                                    </td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                </tr>

                                                <tr>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    </td>
                                                    <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        
                                                    </td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                </tr>

                                                <tr id="Tr4" runat="server">

                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    </td>
                                                    <td class="style8" style="padding: 5px; margin: 5px"></td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                       
                                                    </td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                </tr>
                                                     <tr id="Tr5" runat="server">
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                        </td>
                                        <td class="style8" style="padding: 5px; margin: 5px"></td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                        
                                        </td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                    </tr>

                                               <tr id="Tr6" runat="server">
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;5.</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="200px">Sub Category</asp:Label>
                                                    </td>
                                                    <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="Txtsubcatogory" runat="server" class="form-control txtbox"
                                                            Height="28px"  TabIndex="7" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                </tr>
                                              <tr id="Tr7" runat="server">
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;7.</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="200px">Road Type</asp:Label>
                                                    </td>
                                                    <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtroadtype" runat="server" class="form-control txtbox"
                                                            Height="28px"  TabIndex="9" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                </tr>
                                              <tr id="Tr8" runat="server">
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;9.</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="lblowneraddress" runat="server" CssClass="LBLBLACK" Width="200px">Address of Owner</asp:Label>
                                        </td>
                                        <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:TextBox ID="Txtowneradress" runat="server" class="form-control txtbox" TextMode="MultiLine"
                                                Height="40px" TabIndex="11" 
                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                    </tr>
                                    
                                  
                                    <tr id="Tr9" runat="server">
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                        </td>
                                        <td class="style8" style="padding: 5px; margin: 5px"></td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                            
                                        </td>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                    </tr>
                                </table>
                                </td>
                                </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                <tr id="trtradeduedate" runat="server" visible="false">
                                    <td>
                                        <asp:Label ID="Label3" runat="server"><b>ii) Trade Licence Fee Due as on Date </b></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trtradecode" runat="server" visible="false">
                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3" align="center">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                    <tr id="Tr10" runat="server">
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="200px">Arrears Licence Fee(rs)</asp:Label>
                                                        </td>
                                                        <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtarreasfees" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="30" TabIndex="12"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    </tr>
                                                    <tr id="Tr11" runat="server">
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="200px">Arrears Licence Fee Interest(₹)</asp:Label>
                                                        </td>
                                                        <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtlicencesfeeinterst" runat="server" class="form-control txtbox"
                                                                Height="28px" TabIndex="13"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    </tr>

                                                    <tr id="Tr12" runat="server">
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="200px">Current Licence Fee(₹)</asp:Label>
                                                        </td>
                                                        <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtcurrlience" runat="server" class="form-control txtbox"
                                                                Height="28px"  TabIndex="14"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    </tr>

                                                    <tr id="Tr13" runat="server">
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="200px">Current Licence Fee Interest(₹)</asp:Label>
                                                        </td>
                                                        <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtclfi" runat="server" class="form-control txtbox"
                                                                Height="28px"  TabIndex="15"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    </tr>
                                                    <tr id="Tr14" runat="server">
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="200px">Arrear Garbage Charges A(₹)</asp:Label>
                                                        </td>
                                                        <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtagc" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="30" TabIndex="16"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    </tr>

                                                    <tr id="Tr15" runat="server">
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="200px">Current Garbage Charges(₹)</asp:Label>
                                                        </td>
                                                        <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="Txtcgc" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="30" TabIndex="17"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    </tr>
                                                 
                                                    <tr id="Tr16" runat="server">
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label30" runat="server" CssClass="LBLBLACK" Width="200px">Total Amount to Pay(₹))</asp:Label>
                                                        </td>
                                                        <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="Txttotalamount" runat="server" class="form-control txtbox"
                                                                Height="28px" TabIndex="18"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    </tr>

                                                    <tr id="Tr17" runat="server">
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="200px">Final Amount To Pay<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="Txtfinalamountpay" runat="server" class="form-control txtbox"
                                                                Height="28px"  TabIndex="19"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    </tr>

                                                </table>
                                            </td>
                                            <td class="style11" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style10" style="padding: 5px; margin: 5px"></td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                       
                                         <tr>
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" Visible="true"
                                                    OnClick="btnsave_Click" />
                                                &nbsp;&nbsp;<asp:Button ID="btnnext" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                    Height="32px" TabIndex="10" Text="Next" Width="90px" OnClick="btnnext_Click" />
                                                &nbsp;<asp:Button ID="btnprevious" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                    Height="32px" TabIndex="10" Text="Previous" Width="90px" OnClick="btnprevious_Click" />
                                                &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                    Width="90px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" class="alert alert-success" visible="false">
                                                    <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                </div>
                                                <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                    <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                </div>
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
</asp:Content>
