<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmKotakUpdation2.aspx.cs" Inherits="UI_TSiPASS_frmKotakUpdation2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table style="width: 100%">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>
                    <table style="text-align: center; width: 100%" align="center">
                        <tr>
                            <td colspan="3"><strong>Data Updation to Departments</strong></td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr id="Tr1" runat="server">
                            <td colspan="3"></td>

                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr align="center">
                            <td>Enter Response Meesage:
                            </td>
                            <td>
                                <asp:TextBox ID="txtuidno" runat="server" class="form-control txtbox"
                                    Height="28px" TabIndex="1" Width="150px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                      
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 32px">
                                <asp:Button ID="btnupdate" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="btnupdate_Click" TabIndex="15" Text="Update" ValidationGroup="group" Width="90px" />
                            </td>

                        </tr>
                        <tr>
                            <td colspan="3"><table width="100%">
    <tr>
        <td>
           <b>Payment Submission Page</b>
            
        </td>
    </tr>
                <tr>
                    <td style="width: 359px">
                        UID No
                    </td>
                    <td>
                        <asp:TextBox ID="txtUID" class="form-control txtbox" Height="30px"  Width="180px" runat="server" AutoPostBack="true" OnTextChanged="txtUID_TextChanged"></asp:TextBox>

                    </td>
                </tr>
      <tr>
                    <td style="width: 359px">
                        Tracking ID
                    </td>
                    <td>
                        <asp:TextBox ID="txtTTRid" class="form-control txtbox" Height="30px"  Width="180px" runat="server"></asp:TextBox>

                    </td>
                </tr>
    <tr>
        <td >
            Bank Reference No
        </td>
        <td>
            <asp:TextBox ID="txtBrNo" class="form-control txtbox" Height="30px"  Width="180px" runat="server"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td>
            Payment Mode
        </td>
        <td > 
            <asp:TextBox ID="txtPM" class="form-control txtbox" Height="30px"  Width="180px" runat="server"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td>
            Card Name
        </td>
        <td>
            <asp:TextBox ID="txtCrdName" class="form-control txtbox" Height="30px"  Width="180px" runat="server"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td>
            Amount
        </td>
        <td>
            <asp:TextBox ID="txtAmount" runat="server" class="form-control txtbox" Height="30px"  Width="180px" AutoPostBack="true" OnTextChanged="txtAmount_TextChanged"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Email

        </td>
        <td>
            <asp:TextBox ID="txtEmail" class="form-control txtbox" Height="30px"  Width="180px" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Mobile

        </td>
        <td>
            <asp:TextBox ID="txtMobile" class="form-control txtbox" Height="30px"  Width="180px" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Amount

        </td>
        <td>
            <asp:TextBox ID="txtAmounnt2" class="form-control txtbox" Height="30px"  Width="180px" Enabled="false" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="height: 32px">
            Kotak ID

        </td>
        <td style="height: 32px">
            <asp:TextBox ID="txtKotak" class="form-control txtbox" Height="30px"  Width="180px"  runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Type of Application

        </td>
        <td>
            <asp:DropDownList ID="ddlTypeofAppl" class="form-control txtbox" runat="server" Height="30px" Width="207px">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>CFE</asp:ListItem>
                <asp:ListItem>CFO</asp:ListItem>
                <asp:ListItem>REN</asp:ListItem>
                
                
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Additional Payment

        </td>
        <td>
            <asp:DropDownList ID="ddlAddlPaymnt" class="form-control txtbox" runat="server" Height="30px" Width="207px">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>YES</asp:ListItem>
                <asp:ListItem>NO</asp:ListItem>
             
                
                
            </asp:DropDownList>
        </td>

    </tr>
    <tr>
        <td style="height: 33px">
            Transaction Date(DD/MM/YYYY)

        </td>
        <td style="height: 33px">
            <asp:TextBox ID="txtDate"   class="form-control txtbox" MaxLength="10" Height="30px"  Width="180px" runat="server"></asp:TextBox>
        </td>
    </tr>
                                <tr>
                                    <td>
                                         <asp:Button ID="btnSubmit" Height="30px" Width="100px" Font-Size="Large" BackColor="Wheat"
                                                ForeColor="Black" runat="server" Text="Submit" OnClick="btnSubmit_Click"  />
                                    </td>
                                </tr>
   
            </table></td>

                        </tr>
                        <tr>
                            <td align="center" colspan="5" style="padding: 5px; margin: 5px">
                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>

                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

