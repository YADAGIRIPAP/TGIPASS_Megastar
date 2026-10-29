<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster_Meeseva.master"
    AutoEventWireup="true" CodeFile="IncentiveSingleUploads_MeeSeva.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        
        .txtalignright
        {
            display: block;
            text-align: right;
            width: 100%;
            height: 34px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
        }
        
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
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <%--<script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    
                    <li class="active"><i class="fa fa-edit"></i><a href="#">
                        <asp:Label ID="lblIncHeaderType" runat="server" Text="" /></a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                     <asp:Label ID="lblIncentivetype" runat="server" Text="" />
                                </h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table cellpadding="4" cellspacing="4" style="width: 100%" align="center">
                                            <tr>
                                                <th>
                                                    <asp:Label ID="lblIncentiveNameTitle" runat="server"></asp:Label>
                                                </th>
                                            </tr>                                            
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="grdChecklistsDocument" runat="server" AutoGenerateColumns="False"
                                                        CellPadding="10" GridLines="Both" Width="100%" Visible="false"
                                                        OnRowCommand="grdChecklistsDocument_RowCommand" CellSpacing="10">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex +1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="20px" />
                                                            </asp:TemplateField>
                                                            <%--<asp:BoundField DataField="IncentiveName" HeaderText="Incentive Name" 
                                                                ItemStyle-Font-Bold="true" />--%>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblattachmentID" Text='<%#Eval("AttachmentID") %>' runat="server"
                                                                        Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveId") %>' runat="server" 
                                                                        Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Document Checklist">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblattachment" runat="server" Text='<%# Eval("AttachmentName") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Upload Documents">
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" RenderMode="Inline" ID="updFU">
                                                                        <ContentTemplate>
                                                                            <asp:FileUpload ID="fuDocuments" runat="server" />
                                                                            <asp:Button ID="btnUpload" runat="server" Text="Upload" 
                                                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="btnUpload" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="250px">
                                                                <ItemTemplate>                                                                    
                                                                    <asp:HyperLink ID="lhl" runat="server" Text='<%# Eval("FileNm") %>' 
                                                                        Font-Bold="true" ForeColor="Green" Target="_blank" />
                                                                    <asp:Label ID="lblisMandatoryDoc" runat="server" 
                                                                        Text='<%#Eval("MandatoryDoc") %>' Visible="false" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr><td><br /></td></tr>
                                            <tr>
                                                <td  style="width:100%;">
                                                    <table id="tblPayment" runat="server" visible="true" style="width:100%;">
                                                        <tr>
                                                            <th style="background-color:#337ab7; color:White; height:40px;" colspan="5">
                                                                Receive Payment
                                                            </th>
                                                        </tr>
                                                        <tr><td colspan="5"><br /></td></tr>
                                                        <tr>
                                                            <td style="width:20%;">Challan Amount </td>
                                                            <td style="width:20%;">
                                                                <asp:TextBox ID="txtChallanAmt" runat="server" class="txtalignright" Height="28px"
                                                                    Text="0" ReadOnly="true"/>
                                                            </td>
                                                            <td  style="width:10%;"></td>
                                                            <td style="width:20%;">User Charges </td>
                                                            <td style="width:20%;">
                                                                <asp:TextBox ID="txtUserCharges" runat="server" class="txtalignright" Height="28px"
                                                                    Text="35" ReadOnly="true"/>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Courier Charges </td>
                                                            <td>
                                                                <asp:TextBox ID="txtCourierCharges" runat="server" class="txtalignright" Height="28px"
                                                                    Text="0" ReadOnly="true"/>
                                                            </td>
                                                            <td style="width:10%;"></td>
                                                            <td>Total Amount </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTotalAmt" runat="server" class="txtalignright" Height="28px"
                                                                    Text="35" ReadOnly="true"/>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr><td><br /></td></tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <span style="padding-left: 10px;">
                                                        <asp:Button ID="btnPrevious" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                            Height="32px" TabIndex="10" Text="Previous" Width="90px" OnClick="btnPrevious_Click" />
                                                    </span><span style="padding-left: 10px;">
                                                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                            TabIndex="10" Text="Save" Width="150px" OnClick="btnSave_Click" />
                                                    </span><span style="padding-left: 10px;">
                                                        <asp:Button ID="btnNext" runat="server" CausesValidation="False" Visible="false"
                                                            CssClass="btn btn-warning" Height="32px" TabIndex="10" Text="Next" OnClick="btnNext_Click"
                                                            Width="90px" />
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
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
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
