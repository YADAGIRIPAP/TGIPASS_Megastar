<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmAttachmentDetails.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Resource/Styles/SideMenu/script.js" type="text/javascript"></script>
    <link href="../../Resource/Styles/SideMenu/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>
    <%--<script src="../../Resource/js/bootstrap.min.js"></script>   
    <script src="../../Resource/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/js/plugins/morris/morris.min.js"></script>
    <script src="../../Resource/js/plugins/morris/morris-data.js"></script>--%>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/balloon-css/0.4.0/balloon.min.css">
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
        
        .style6
        {
            width: 192px;
        }
        
        .style7
        {
            color: #FF3300;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("frmViewAttachmentDetails.aspx?intApplicationid=" + document.getElementById("ctl00_ContentPlaceHolder1_hdfFlagID0").value, "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <%-----------------11------------------------------------------------------%>
    <%----------------12-------------------------------------------------------%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Attachment Details</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            Attachment Details</h3>
                    </div>
                    <%-----------------12------------------------------------------------------%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <td>
                                <tr>
                                    <td style="padding: 5px; margin: 5px" valign="top">
                                        <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Common Attachments<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td align="right">
                                        <%--<asp:Label ID="Label58" runat="server" CssClass="LBLBLACK" ForeColor="Red" Font-Bold="True">If you want to Upload DWG file. make is as ZIP or RAR folder and upload it.</asp:Label>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding: 5px; margin: 5px" valign="top">
                                        <table cellpadding="4" cellspacing="5" style="width: 100%; text-align: left;">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    1
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                        data-balloon="Self Certification Form" data-balloon-pos="down" Width="210px">Self Certification Form<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" class="form-control txtbox"
                                                        Height="33px" />
                                                    <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="BtnSave3_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    2
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                  <asp:Label ID="lblDeed" runat="server" CssClass="LBLBLACK" ata-balloon-length="large"
                                                        data-balloon="Registration Sale Deed" data-balloon-pos="down" Width="210px">Registration Deed<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUpload2" Width="300px" runat="server" class="form-control txtbox"
                                                        Height="33px" />
                                                    <asp:HyperLink ID="Label1" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label445" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="Button1_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    3
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" ata-balloon-length="large"
                                                        data-balloon="Mutation issued by MRO" data-balloon-pos="down" Width="165px">Mutation order<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUpload3" Width="300px" runat="server" class="form-control txtbox"
                                                        Height="33px" />
                                                    <asp:HyperLink ID="Label2" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label446" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="Button2_Click" />
                                                </td>
                                            </tr>
                                              <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">4</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" ata-balloon-length="large" data-balloon="Combined building plan including all floor plans"
                                                    data-balloon-pos="down" Width="410px">Combined building plan including all floor plans <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload5" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="Label4" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label447" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="Button4" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="33px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button4_Click" />
                                                <%--<asp:LinkButton ID="lnkupload4" runat="server" TabIndex="10" Text="Upload More Files" Visible="false" OnClick="Button4_Click"></asp:LinkButton>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:GridView ID="gvUpload4" runat="server" AutoGenerateColumns="False" CellPadding="3" EnableModelValidation="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
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
                                                                <asp:HyperLink ID="hprlink" runat="server" Text="View" NavigateUrl='<%#Eval("link") %>' Target="_blank"></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">5</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label434" runat="server" ata-balloon-length="large" data-balloon="Combined site plan"
                                                    data-balloon-pos="down" CssClass="LBLBLACK" Width="165px">Combined site plan<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload4" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="Label3" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label448" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="33px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button3_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
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
                                                                <asp:HyperLink ID="hprlink" runat="server" Text="View" NavigateUrl='<%#Eval("link") %>' Target="_blank"></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">&nbsp;</td>
                                        </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                                    6
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label436" runat="server" ata-balloon-length="large" data-balloon="Partnership details (or) Articles of Association (AOA)"
                                                        data-balloon-pos="down" CssClass="LBLBLACK" Width="410px">Partnership details (or) Articles of Association (AOA)<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUpload6" Width="300px" runat="server" class="form-control txtbox"
                                                        Height="33px" />
                                                    <asp:HyperLink ID="lblFileName0" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label449" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="BtnSave4" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="BtnSave4_Click" />
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    7
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label437" runat="server" ata-balloon-length="large" data-balloon="Process Flow Chart (Diagram)"
                                                        data-balloon-pos="down" CssClass="LBLBLACK" Width="210px">Process Flow Chart (Diagram)<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUpload7" Width="300px" runat="server" class="form-control txtbox"
                                                        Height="33px" />
                                                    <asp:HyperLink ID="Label438" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label450" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="Button5" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="Button5_Click" />
                                                </td>
                                            </tr>--%>
                                             <tr runat="server" id="trProcessFlowChart">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    7
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label437" runat="server" ata-balloon-length="large" data-balloon="Process Flow Chart (Diagram)"
                                                        data-balloon-pos="down" CssClass="LBLBLACK" Width="210px">Process Flow Chart (Diagram)<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUpload7" Width="300px" runat="server" class="form-control txtbox"
                                                        Height="33px" />
                                                    <asp:HyperLink ID="Label438" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label450" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="Button5" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="Button5_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    8
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label439" ata-balloon-length="large" data-balloon="PAN / AADHAAR"
                                                        data-balloon-pos="down" runat="server" CssClass="LBLBLACK" Width="165px">PAN / AADHAAR<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUpload8" Width="300px" runat="server" class="form-control txtbox"
                                                        Height="33px" />
                                                    <asp:HyperLink ID="Label440" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Label451" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="Button6" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="Button6_Click" />
                                                </td>
                                            </tr>
                                            <tr id="TRDEET" runat="server">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    9
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="LBLDEET" ata-balloon-length="large" data-balloon="DEET Registration Acknowledgement"
                                                        data-balloon-pos="down" runat="server" CssClass="LBLBLACK" style="left: 0px; top: 5px; width: 346px">DEET Registration Acknowledgement<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="fupdeetack" Width="300px" runat="server" class="form-control txtbox"
                                                        Height="33px" />
                                                    <asp:HyperLink ID="hypdeetack" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lbldeetack" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:Button ID="BTNDEETACK" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="BTNDEETACK_Click" />
                                                </td>
                                            </tr>
                                                                                                     <tr id="TRDEETDESCRIPTION" runat="server">
                                                            <td colspan="6" style="width:100%"><asp:hyperlink id="Hyperlink20" runat="server" visible="true"
cssclass="LBLRED" width="100%" target="_blank" navigateurl="https://deet.telangana.gov.in/">
Please click here to register in DEET (It is mandatory to register in DEET portal and upload registerred acknowledgement in attachment check slip) <span class="detail-gif" data-balloon-length="large"
             data-balloon-pos="right">&nbsp;&nbsp;&nbsp;
        <img alt="" width="40px" height="20px" src="../../images/animated-hand-image-0117.gif" /></span></asp:hyperlink><span style="color:red">(For Technical Assistance, Please call: +91 9281423576 (Dr. M.Chandrashekar, Additional Program Director))</span></td>
                                                           
                                                        </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <table id="oflineapprovals" runat="server" visible="false">
                                                        <tr id="Panelpcb2" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="5">
                                                                <asp:Label ID="Label458" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="250px">Department Approval taken offline</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="Panelpcb" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label455" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtPCBRefNo" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPCBRefNo"
                                                                    ErrorMessage="Please enter Reference Number for PCB Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="Panelpcb1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label452" runat="server" CssClass="LBLBLACK" Width="200px">Upload 
                                                        Polution Control Board Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload10" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="Label453" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[Label453]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label454" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button8" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button8_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr id="panelTSCT" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtTSCTRefNo" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTSCTRefNo"
                                                                    ErrorMessage="Please enter Reference Number for  Commercial Taxes Approval Document"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelTSCT1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="200px">Upload 
                                                        Commercial Taxes Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload11" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[HyperLink1]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button9" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button9_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr id="panelTSIIC" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox2" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2"
                                                                    ErrorMessage="Please enter Reference Number for TSIIC Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelTSIIC1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="200px">Upload 
                                                        TSIIC Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload12" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label11" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button10" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button10_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr id="panelPRD" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox3" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox3"
                                                                    ErrorMessage="Please enter Reference Number for Panchayat Raj Approval Document"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelPRD1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        Panchayat Raj Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;:&nbsp;
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload13" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[HyperLink3]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label14" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button11" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button11_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr id="panelDISCOM" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox4" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox4"
                                                                    ErrorMessage="Please enter Reference Number for DISCOM Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelDISCOM1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        DISCOM Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload14" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[HyperLink4]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label17" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button12" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button12_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr id="panelCEIG" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox5" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox5"
                                                                    ErrorMessage="Please enter Reference Number for Electrical Inspectorate Approval Document"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelCEIG1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="200px">Upload 
                                                        Electrical Inspectorate Approval Document<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload15" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink5" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[HyperLink5]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label20" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button13" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button13_Click" />
                                                            </td>
                                                        </tr>
                                                        <%----------------13-------------------------------------------------------%>
                                                        <tr id="panelTSNPDCL" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox6" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox6"
                                                                    ErrorMessage="Please enter Reference Number for TSNPDCL Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelTSNPDCL1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        TSNPDCL Approval Document<font 
                                                            color="red"*</font></asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload16" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink6" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[HyperLink6]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label23" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button14" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button14_Click" />
                                                            </td>
                                                        </tr>
                                                        <%-----------------13------------------------------------------------------%>
                                                        <%----------------14-------------------------------------------------------%>
                                                        <tr id="panelTSSPDCL" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="TextBox7" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox7"
                                                                    ErrorMessage="Please enter Reference Number for TSSPDCL Approval Document " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelTSSPDCL1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        TSSPDCL Approval Document :</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload17" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink7" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[HyperLink7]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label26" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button15" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button15_Click" />
                                                            </td>
                                                        </tr>
                                                        <%-----------------14------------------------------------------------------%>
                                                        <%----------------15-------------------------------------------------------%>
                                                        <tr id="panelFACT" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox8" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox8"
                                                                    ErrorMessage="Please enter Reference Number for Factories Approval Document"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelFACT1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        Factories Approval Document</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload18" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink8" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[HyperLink8]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label29" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button16" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button16_Click" />
                                                            </td>
                                                        </tr>
                                                        <%-----------------15------------------------------------------------------%>
                                                        <%----------------16-------------------------------------------------------%>
                                                        <tr id="panelINDUS" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label30" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox9" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox9"
                                                                    ErrorMessage="Please enter Reference Number for Industries" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelINDUS1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label456" runat="server" CssClass="LBLBLACK" Width="165px">Industries</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload19" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink9" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[HyperLink9]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label32" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button17" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button17_Click" />
                                                            </td>
                                                        </tr>
                                                        <%-----------------16------------------------------------------------------%>
                                                        <%----------------17-------------------------------------------------------%>
                                                        <tr id="panelHMDA" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox10" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox10"
                                                                    ErrorMessage="Please enter Reference Number for HMDA Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelHMDA1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label457" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        HMDA Approval Document</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload20" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink10" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                    Target="_blank">[HyperLink10]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label35" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button18" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button18_Click" />
                                                            </td>
                                                        </tr>
                                                        <%-----------------17------------------------------------------------------%>
                                                        <%----------------18-------------------------------------------------------%>
                                                        <tr id="panelCCLA" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label36" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox11" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox11"
                                                                    ErrorMessage="Please enter Reference Number for CCLA Approval Document" ValidationGroup="group"
                                                                    EnableViewState="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelCCLA1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        CCLA Approval Document</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload21" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink11" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                    Target="_blank">[HyperLink11]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label38" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button19" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button19_Click" />
                                                            </td>
                                                        </tr>
                                                        <%-----------------18------------------------------------------------------%>
                                                        <%----------------19-------------------------------------------------------%>
                                                        <tr id="panelDTCP" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label39" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox12" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBox12"
                                                                    ErrorMessage="Please enter Reference Number for District Town and Country Planning Approval Document"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelDTCP1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="200px">Upload 
                                                        District Town and Country Planning Approval Document</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload22" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink12" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                    Target="_blank">[HyperLink12]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label41" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button20" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button20_Click" />
                                                            </td>
                                                        </tr>
                                                        <%-----------------19------------------------------------------------------%>
                                                        <%----------------20-------------------------------------------------------%>
                                                        <tr id="panelFIRE" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label42" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox13" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBox13"
                                                                    ErrorMessage="Please enter Reference Number for Fire Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelFIRE1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label37" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        Fire Approval Document</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload23" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink13" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                    Target="_blank">[HyperLink13]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label44" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button21" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button21_Click" />
                                                            </td>
                                                        </tr>
                                                        <%-----------------20------------------------------------------------------%>
                                                        <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                        --%>
                                                        <tr id="panelGW" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label45" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                : &nbsp;
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox14" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TextBox14"
                                                                    ErrorMessage="Please enter Reference Number for Ground Water Approval Document"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelGW1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label40" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        Ground Water Approval Document</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload24" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink14" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                    Target="_blank">[HyperLink14]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label47" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button22" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button22_Click" />
                                                            </td>
                                                        </tr>
                                                        <%--       </ContentTemplate>
</asp:UpdatePanel>--%>
                                                        <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>--%>
                                                        <tr id="panelHMWSSB" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label48" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox15" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TextBox15"
                                                                    ErrorMessage="Please enter Reference Number for HMWSSB Approval Document" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelHMWSSB1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label43" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        HMWSSB Approval Document</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload25" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink15" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                    Target="_blank">[HyperLink15]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label50" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button23" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button23_Click" />
                                                            </td>
                                                        </tr>
                                                        <%--<div class="overlay">--%>
                                                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                                                        <tr id="panelEXCISE" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label51" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox16" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TextBox16"
                                                                    ErrorMessage="Please enter Reference Number for Excise Department Approval Document"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelEXCISE1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label46" runat="server" CssClass="LBLBLACK" Width="200px">Upload 
                                                        Excise Department Approval Document</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload26" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink16" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                    Target="_blank">[HyperLink16]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label53" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button24" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button24_Click" />
                                                            </td>
                                                        </tr>
                                                        <%--<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">--%>
                                                        <%--<img alt="" src="../../Resource/Images/Processing.gif" />
                                                        --%>
                                                        <tr id="panelREGSTAMP" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label54" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox17" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TextBox17"
                                                                    ErrorMessage="Please enter Reference Number for Registrations and Stamps Approval Document"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelREGSTAMP1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label49" runat="server" CssClass="LBLBLACK" Width="200px">Upload 
                                                        Registrations and Stamps Approval Document</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload27" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink17" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                    Target="_blank">[HyperLink17]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label56" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button25" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button25_Click" />
                                                            </td>
                                                        </tr>
                                                        <%--</ProgressTemplate>
</asp:UpdateProgress> --%>
                                                        <%--</ContentTemplate>
  </asp:UpdatePanel>--%>
                                                        <tr id="panelDCA" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label57" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox18" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TextBox18"
                                                                    ErrorMessage="Please enter Reference Number for Drugs Control Administration Approval Document"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelDCA1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label52" runat="server" CssClass="LBLBLACK" Width="200px">Upload 
                                                        Drugs Control Administration Approval Document</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload28" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink18" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                    Target="_blank">[HyperLink18]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label59" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button26" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button26_Click" />
                                                            </td>
                                                        </tr>
                                                        <%-- </div>
       </td>
        </tr>
    </table>--%>
                                                        <%----------------20-------------------------------------------------------%>
                                                        <tr id="panelIRRIGATION" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label60" runat="server" CssClass="LBLBLACK" Width="165px">Reference 
                                                        Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                : &nbsp;
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TextBox19" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TextBox19"
                                                                    ErrorMessage="Please enter Reference Number for Irrigation Approval Document"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="panelIRRIGATION1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label55" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        Irrigation Approval Document</asp:Label>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload29" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="HyperLink19" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                    Target="_blank">[HyperLink19]</asp:HyperLink>
                                                                <br />
                                                                <asp:Label ID="Label62" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button27" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button27_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <%-----------------20------------------------------------------------------%>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding: 5px; margin: 5px" valign="top" align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tradditionalattanew" runat="server" visible="false">
                                    <td colspan="2" align="left" style="padding: 5px; margin: 5px" valign="top">
                                        <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="280px">Additional Attachments</asp:Label>
                                    </td>
                                </tr>
                                <tr id="tradditionalatta" runat="server" visible="false">
                                    <td colspan="2" style="padding: 5px; margin: 5px" valign="top">
                                        <table cellpadding="4" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label442" runat="server" CssClass="LBLBLACK" Width="210px">Attachment Type<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddlAttachmentType" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" OnSelectedIndexChanged="ddlAttachmentType_SelectedIndexChanged"
                                                                    AutoPostBack="True">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Google Map (HMDA)</asp:ListItem>
                                                                    <asp:ListItem Value="2">Nodal Agency attachments(Industries Dept)</asp:ListItem>
                                                                    <asp:ListItem Value="3">TSPCB Attachments</asp:ListItem>
                                                                    <asp:ListItem Value="4">TSSPDCL/NPDCL Attachments</asp:ListItem>
                                                                    <asp:ListItem Value="5">DTCP/HMDA/KUDA/IALA Attachments</asp:ListItem>
                                                                    <asp:ListItem Value="6">NOC from Gram Panchayat</asp:ListItem>
                                                                    <asp:ListItem Value="7">Ground Water Dept Attachments</asp:ListItem>
                                                                    <asp:ListItem Value="8">Fire Dept Attachments</asp:ListItem>
                                                                    <asp:ListItem Value="9">TSIIC Land/Plot Allotment</asp:ListItem>
                                                                    <asp:ListItem Value="10">Factories Dept Attachments</asp:ListItem>
                                                                    <asp:ListItem Value="11">Others Departments</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtOthers" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact6_TextChanged"
                                                                    Visible="False"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                <asp:Label ID="Label443" runat="server" CssClass="LBLBLACK" Width="210px">Document <font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="FileUpload9" runat="server" class="form-control txtbox" Height="33px" />
                                                                <asp:HyperLink ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[Label5]</asp:HyperLink>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="Button7" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                    TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="Button7_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 200px;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                    GridLines="None" OnRowDataBound="gvCertificate_RowDataBound" OnRowDeleting="gvCertificate_RowDeleting"
                                                                    Width="100%" OnSelectedIndexChanged="gvCertificate_SelectedIndexChanged">
                                                                    <RowStyle BackColor="#ffffff" />
                                                                    <Columns>
                                                                        <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                        <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                        --%>
                                                                        <%--<asp:BoundField DataField="Manf_ItemName" HeaderText="Attachment Type" />--%>
                                                                        <%--<asp:BoundField DataField="Manf_Item_Quantity_In" HeaderText="Document" />--%>
                                                                    </Columns>
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#013161" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="center" class="style7">
                                                    &nbsp;<tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;" align="center">
                                                            <asp:Button ID="BtnClear0" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                                Height="32px" OnClick="BtnClear0_Click2" TabIndex="10" Text="View Attachment"
                                                                ToolTip="To Clear  the Screen" Width="140px" />
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        &nbsp;</caption>
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
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                        <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                            OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px"
                                            Visible="False" />
                                        &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                            Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Save" Width="90px"
                                            OnClientClick="return confirm('Do you want to Save  the record ? ');" />
                                        &nbsp;<asp:Button ID="BtnDelete0" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                            Height="32px" OnClick="BtnClear0_Click" TabIndex="10" Text="Previous" Width="90px"
                                            OnClientClick="return confirm('Do you want to Save the record ? ');" />
                                        &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                            Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                            Width="90px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                                ×times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                                Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </td>
                        </table>
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
