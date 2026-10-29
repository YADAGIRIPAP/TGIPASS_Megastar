<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manfofboilerRENEWAL.aspx.cs" MasterPageFile="~/UI/TSiPASS/CCMaster.master" Inherits="UI_TSiPASS_manfofboilerRENEWAL" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Resource/Styles/SideMenu/script.js" type="text/javascript"></script>
    <link href="../../Resource/Styles/SideMenu/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/balloon-css/0.4.0/balloon.min.css">
    <style type="text/css">
        .overlay {
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

        .style12 {
        }

        .style13 {
            width: 13px;
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
</script>
    --%>
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
            <li class="">
                <i class="fa fa-fw fa-edit">CAF</i>
            </li>
            <li class="active">
                <i class="fa fa-edit"></i><a href="#">Entrepreneur Details</a>
            </li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Boilers Details</h3>
                    </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label461" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="450px">Please fill this part if Registration of Boilers is required</asp:Label>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px">1</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="200px"> Covered Area of the Workshop </asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtworkshoparea" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <span style="color: rgb(57, 57, 57); font-family: &quot;Open Sans&quot;; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Sq Mtrs.</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="txtworkshoparea"
                                                    ErrorMessage="Please Enter Covered Area of the Workshop" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">3&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label448" runat="server" CssClass="LBLBLACK" Width="200px">Type of Equipments intend to Manufacture </asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlTypeOfEquipment" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Boiler</asp:ListItem>
                                                    <asp:ListItem Value="2">Boiler Component </asp:ListItem>
                                                    <asp:ListItem Value="3">Boiler & Boiler Component </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    ControlToValidate="ddlTypeOfEquipment" ErrorMessage="Please Select Type Of Equipment"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">5</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="200px">Whether the firm is prepared to accept full responsibility for the work done and is prepared to clarify any controversial issue, if required ?</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtfirmtoAcceptResponsibility" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="50" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                    ControlToValidate="txtfirmtoAcceptResponsibility" ErrorMessage="Please enter details that  the firm is prepared to accept full responsibility? "
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">7</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Width="200px">Whether the firm has an internal quality control system of their own? If so, give details </asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtfirmQualitycontrolsystem" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    ControlToValidate="txtfirmQualitycontrolsystem" ErrorMessage="Please enter details that the firm has an internal quality control system of their own? "
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                        
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">2&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label509" runat="server" CssClass="LBLBLACK" Width="200px">Upload Previous Registration/Renewal Certificate</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:FileUpload ID="FileUpload3" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="lblFileLink1" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                    Width="165px"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblfileUpload1" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px"><asp:Button ID="BtnUpload1" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="BtnUpload1_Click" />
                                            </td>
                                            <asp:HiddenField ID="HdLink1" runat="server" />
                                        </tr>

                                        <tr>
                                            <td style="padding: 5px; margin: 5px">4</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label502" runat="server" CssClass="LBLBLACK" Width="200px">Whether the firm is prepared to execute the job strictly in conformity with the regulations and maintain a high standard of work ?</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtFirmtoexecutejob" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                    ControlToValidate="txtFirmtoexecutejob"
                                                    ErrorMessage="Please enter the details the firm is prepared to execute the job strictly?" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                        
                                       

                                        <tr id="trsteampipeline" runat="server">
                                            <td style="padding: 5px; margin: 5px">6</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label508" runat="server" CssClass="LBLBLACK" Width="200px">Whether the firm is in a position to supply materials to required specification with proper test certificates if asked for ?</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtfirmtosupplymaterials" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40"  TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                                    ControlToValidate="txtfirmtosupplymaterials"
                                                    ErrorMessage="Please enter details that  the firm is in a position to supply materials to required specification with proper test certificates"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;</td>
                                    </tr>
                                    <caption>
                                        &nbsp;</caption>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <table style="width: 50%">
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">1&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" ata-balloon-length="large" data-balloon="Combined building plan including all floor plans"
                                                    data-balloon-pos="down" Width="410px">Detailed list of the machinery, Tools and Equipment <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload5" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="Label4" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
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
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label434" runat="server" ata-balloon-length="large" data-balloon="Combined site plan"
                                                    data-balloon-pos="down" CssClass="LBLBLACK" Width="165px">Detailed list of Testing Facilities<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload4" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="Label3" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
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
                                                                <asp:Label ID="Label5" runat="server" Text="<%#Container.DataItemIndex + 1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="File Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Attachment">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Text="View" NavigateUrl='<%#Eval("link") %>' Target="_blank"></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">&nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">3&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" ata-balloon-length="large" data-balloon="Combined building plan including all floor plans"
                                                    data-balloon-pos="down" Width="410px">Detailed list of technical personnel with designation, qualifications and experience <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload1" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="lblhl3" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="33px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button1_Click" />
                                                <%--<asp:LinkButton ID="lnkupload4" runat="server" TabIndex="10" Text="Upload More Files" Visible="false" OnClick="Button4_Click"></asp:LinkButton>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:GridView ID="gvupload6" runat="server" AutoGenerateColumns="False" CellPadding="3" EnableModelValidation="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label9" runat="server" Text="<%#Container.DataItemIndex + 1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="File Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Attachment">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLink2" runat="server" Text="View" NavigateUrl='<%#Eval("link") %>' Target="_blank"></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" ata-balloon-length="large" data-balloon="Combined site plan" Style="width:100%"
                                                    data-balloon-pos="down" CssClass="LBLBLACK" Width="165px">List of welders employed with copies of current certificate issued by a Competent Authority under the Indian Boiler Regulations, 1950 .<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUpload2" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="lblhl4" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="Label12" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="Button2" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="33px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button2_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:GridView ID="gvupload7" runat="server" AutoGenerateColumns="False" CellPadding="3" EnableModelValidation="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label13" runat="server" Text="<%#Container.DataItemIndex + 1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="File Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label14" runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Attachment">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLink3" runat="server" Text="View" NavigateUrl='<%#Eval("link") %>' Target="_blank"></asp:HyperLink>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                            <tr>
                                <td align="center" colspan="3"
                                    style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save"
                                        ValidationGroup="group" Width="90px" />
                                   &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server"
                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" TabIndex="10"
                                        Text="Next" Width="90px"
                                        ValidationGroup="group" />
                                    &nbsp;<asp:Button ID="BtnDelete0" runat="server" CausesValidation="False"
                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnDelete0_Click"
                                        TabIndex="10" Text="Previous" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">


                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
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
                    <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>

    </div>
    <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>

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


    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>