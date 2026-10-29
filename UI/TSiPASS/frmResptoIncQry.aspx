<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmResptoIncQry.aspx.cs" Inherits="UI_TSiPASS_frmResptoIncQry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="panel-body">
        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

            <tr>

                <td style="padding: 5px; font-weight: bold; float: left; margin: 5px" valign="top">Response to Query raised on Incentives Application
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px" valign="top">
                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Udyog Adhaar/IEM No<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label447" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="210px">Name of Industry/Enterprise<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label448" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Type of Sector<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label449" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>

                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="410px">Scheme Applied<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label450" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>

                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;">5</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="410px">Incentives Applied For<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label451" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">6</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">

                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="165px">Query raised by<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label452" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">7</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="410px">Query raise date<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label453" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">8</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="410px">Query Description<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label454" runat="server"></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="410px">Query Letter<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td  style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:HyperLink ID="hplLEtter" runat="server" CssClass="LBLBLACK" ></asp:HyperLink>
                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">9</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Query Response*</td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:TextBox ID="txtdiscription" runat="server" class="form-control txtbox" Height="80px"
                                    TextMode="MultiLine" ValidationGroup="group" Width="250px"></asp:TextBox>

                            </td>
                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                <asp:Label ID="lblDesc" Visible="false" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr  id="TRRESPONSEATTACHMENT" runat="server">
                            <td style="padding: 5px; margin: 5px; text-align: left;">10&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">Response  Attachment<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="Button6" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="Button6_Click" />
                            </td>

                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="10">
                                <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                                    CssClass="GRD" ForeColor="Black" GridLines="Both"
                                    OnRowDeleting="gvCertificate_RowDeleting" Width="50%" BackColor="LightGoldenrodYellow" EnableModelValidation="True">
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                    <Columns>
                                        <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                        <%-- <asp:CommandField HeaderText="DELETE" ItemStyle-Width="100px" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" DeleteText="DELETE" ShowDeleteButton="True" />--%>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfilepath" runat="server" Text='<%# Bind("filepath") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                </asp:GridView>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID13" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="lblid13name" runat="server" CssClass="LBLBLACK" Width="385px">Civil Engineer's certificate by civil Engineer of the financial Institution/Chartered Engineer<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="fupid13" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="hypid13" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="lblid13" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="btnatchid13" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="btnatchid13_Click"/>
                            </td>

                        </tr>
                        <tr id="TRID15" runat="server" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID15ATTACHMENTNAME" runat="server" CssClass="LBLBLACK" Width="385px">Statements of accounts in respect of Aided Enterprises <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID15" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID15" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID15" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID15" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID15_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID101" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID101ATTACHMENTNAME" runat="server" CssClass="LBLBLACK" Width="406px">List of Plant & Machinery & Equipment purchased and installed in the prescribed form with attested copies of bills and payment proof in respect of self financed Enterprises/industries <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID101" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID101" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID101" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID101" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID101_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID227" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID227ATTACHMENTNAME" runat="server" CssClass="LBLBLACK" Width="385px">Photo of the Applicant along with the Equipment  in Respect of Mobile Units<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID227" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID227" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID227" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID227" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID227_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID1" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLATCHID1NAME" runat="server" CssClass="LBLBLACK" Width="385px">Valid CFO/Acknowledgement from GM,DIC concerned on pollution angle<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID1" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID1" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID1" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID1" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID1_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID4" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID4NAME" runat="server" CssClass="LBLBLACK" Width="385px">Term Loan Certificate from Financial Institute<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID4" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HUPID4" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID4" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID4" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID4_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID5" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID5NAME" runat="server" CssClass="LBLBLACK" Width="385px">Self Certification <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID5" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID5" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID5" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID5" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID5_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID6" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID6NAME" runat="server" CssClass="LBLBLACK" Width="385px">Power Bills& Payment Proof/Receipts<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID6" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID6" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID6" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID6" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID6_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID7" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID7NAME" runat="server" CssClass="LBLBLACK" Width="385px">CA Certificate showing Power Utilisation particulars for the last 3 Years<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID7" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID7" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID7" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID7" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID7_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID19" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID19NAME" runat="server" CssClass="LBLBLACK" Width="385px">Copy of the Project Report and its approval report<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID19" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID19" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID19" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID19" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID19_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID31" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID31NAME" runat="server" CssClass="LBLBLACK" Width="385px">Certificate of Functional Status issued by G.M.,DIC at the time of acquiring ISO-9000/ISO-14001/HACCP-Certificate<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID31" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID31" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID31" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID31" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID31_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID32" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID32NAME" runat="server" CssClass="LBLBLACK" Width="385px">Bills,Vouchers and proof of payment in support of Expenditure incurred for Certification<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID32" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID32" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID32" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID32" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID32_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID36" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID36NAME" runat="server" CssClass="LBLBLACK" Width="385px">Certificate from Financial Institute in the prescribed Proforma<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID36" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID36" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID36" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID36" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID36_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID44" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID44NAME" runat="server" CssClass="LBLBLACK" Width="385px">Form-A issued by CT Department<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID44" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID44" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID44" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID44" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID44_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID48" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID48NAME" runat="server" CssClass="LBLBLACK" Width="385px">Copy of valid CFO if applicable<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID48" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID48" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID48" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID48" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID48_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID1001" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID1001NAME" runat="server" CssClass="LBLBLACK" Width="570px">Certificate from the financing institution concerned showing term loan released and the value of assets acquired as on prior to filing of claim/within 6 months from the date of commencement of commercial production whichever is earlier together with other details and machinery statement as a statement of account in the form prescribed with attested copies of bills in case of institutionally financed Enterprises/industries<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID1001" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID1001" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID1001" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID1001" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID1001_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID102" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID102NAME" runat="server" CssClass="LBLBLACK" Width="385px">Caste Certificates issued by Tahsildar/ M.R.O's concerned in case of SC/ST Entrepreneur<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID102" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID102" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID102" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID102" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID102_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID103" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID103NAME" runat="server" CssClass="LBLBLACK" Width="385px">Aadhar of the Entrepreneur<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID103" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID103" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID103" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID103" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID103_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID104" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID104NAME" runat="server" CssClass="LBLBLACK" Width="385px">PAN Card of the Entrepreneur<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID104" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID104" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID104" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID104" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID104_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID105" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID105NAME" runat="server" CssClass="LBLBLACK" Width="385px">Certificate from the Chartered Accountant and % of holding of equity in the company by each partner/director<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID105" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID105" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID105" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID105" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID105_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID106" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID106NAME" runat="server" CssClass="LBLBLACK" Width="385px">Regd. Partnership Deed/Articles of Association and Memorandum of Association in case of Pvt. Ltd and Limited companies along with incorporation certificate / Bye-laws in case of Indl. Cooperative along with Registration Certificate<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID106" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID106" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID106" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID106" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID106_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID201" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID201NAME" runat="server" CssClass="LBLBLACK" Width="385px">Approval of Director of Factories<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID201" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID201" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID201" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID201" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID201_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID202" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID202NAME" runat="server" CssClass="LBLBLACK" Width="385px">Boilers Certificate<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID202" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID202" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID202" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID202" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID202_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID203" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID203NAME" runat="server" CssClass="LBLBLACK" Width="385px">Approval of Director of Town & Country Planning / UDA<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID203" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID203" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID203" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID203" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID203_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID204" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID204NAME" runat="server" CssClass="LBLBLACK" Width="385px">Regular building plans approval of Municipality or Gram Panchayat<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID204" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID204" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID204" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID204" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID204_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID205" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID205NAME" runat="server" CssClass="LBLBLACK" Width="385px">Consent for Operation from TSPCB/Acknowledgement from the General Manager, DIC concerned<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID205" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID205" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID205" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID205" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID205_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID206" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID206NAME" runat="server" CssClass="LBLBLACK" Width="385px">Power release Certificate from TSTRANSCO/DISCOM<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID206" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID206" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID206" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID206" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID206_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID207" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID207NAME" runat="server" CssClass="LBLBLACK" Width="385px">Environmental clearance<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID207" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID207" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID207" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID207" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID207_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID208" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID208NAME" runat="server" CssClass="LBLBLACK" Width="385px">Other statutory approvals (specify)<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID208" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID208" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID208" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID208" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID208_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID209" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID209NAME" runat="server" CssClass="LBLBLACK" Width="385px">EM Part – I full set/IEM/IL<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID209" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID209" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID209" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID209" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID209_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID210" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID210NAME" runat="server" CssClass="LBLBLACK" Width="385px">Udyog Aadhar<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID210" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID210" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID210" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID210" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID210_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID211" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID211NAME" runat="server" CssClass="LBLBLACK" Width="385px">Project Report<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID211" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID211" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID211" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID211" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID211_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID212" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID212NAME" runat="server" CssClass="LBLBLACK" Width="385px">Term loan sanction letters<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID212" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID212" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID212" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID212" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID212_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID213" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID213NAME" runat="server" CssClass="LBLBLACK" Width="385px">Board Resolution authorizing to sign and file claim etc., in case of Pvt./Ltd., Companies, Cooperatives and similar authorization in respect of partnership firms<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID213" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID213" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID213" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID213" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID213_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID214" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID214NAME" runat="server" CssClass="LBLBLACK" Width="385px">Registered land Sale deed/Premises Lease deed<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID214" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID214" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID214" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID214" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID214_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID215" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID215NAME" runat="server" CssClass="LBLBLACK" Width="385px">C.A. and C.E. Certificate regarding 2nd hand plant & machinery<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID215" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID215" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID215" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID215" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID215_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID216" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID216NAME" runat="server" CssClass="LBLBLACK" Width="385px">C.E. Certificate for Self fabricated machinery<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID216" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID216" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID216" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID216" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID216_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID217" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID217NAME" runat="server" CssClass="LBLBLACK" Width="385px">BIS Certificate<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID217" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID217" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID217" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID217" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID217_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID218" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID218NAME" runat="server" CssClass="LBLBLACK" Width="385px">Drug License<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID218" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID218" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID218" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID218" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID218_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID219" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID219NAME" runat="server" CssClass="LBLBLACK" Width="385px">Explosive License<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID219" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID219" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID219" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID219" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID219_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID220" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID220NAME" runat="server" CssClass="LBLBLACK" Width="385px">VAT/CST/SGST Certificate<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID220" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID220" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID220" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID220" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID220_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID223" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID223NAME" runat="server" CssClass="LBLBLACK" Width="385px">Production particulars for the last 3 years as per fixed capital investment and Line of Activity of the application duly certified by CA for the 1st time of the claim, if it is expansion / diversification project<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID223" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID223" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID223" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID223" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID223_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID224" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID224NAME" runat="server" CssClass="LBLBLACK" Width="385px">RTA Certificate<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID224" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID224" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID224" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID224" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID224_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID225" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID225NAME" runat="server" CssClass="LBLBLACK" Width="385px">PH Certificate<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID225" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID225" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID225" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID225" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID225_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID226" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID226NAME" runat="server" CssClass="LBLBLACK" Width="385px">Undertaking and Finance Certificate Prescrbed Format<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID226" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID226" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID226" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID226" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID226_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID9053" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID9053NAME" runat="server" CssClass="LBLBLACK" Width="385px">C.A Certificate as per Prescribed format<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID9053" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID9053" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID9053" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID9053" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID9053_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID3001" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID3001NAME" runat="server" CssClass="LBLBLACK" Width="385px">C.A. certificate of Pavala Vaddi <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID3001" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID3001" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID3001" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID3001" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID3001_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID52" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID52NAME" runat="server" CssClass="LBLBLACK" Width="385px">Attested copy of receipts from DISCOM <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID52" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID52" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID52" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID52" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID52_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID228" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID228NAME" runat="server" CssClass="LBLBLACK" Width="385px">First Sale Bill <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID228" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID228" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID228" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID228" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID228_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID100010" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100010NAME" runat="server" CssClass="LBLBLACK" Width="385px">Registered Land Sale deed/Lease Deed/Transfer deed/Land Conversion document(STAMPDUTY/TRANSFERDUTY) <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100010" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100010" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100010" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100010" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100010_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID100011" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100011NAME" runat="server" CssClass="LBLBLACK" Width="385px">Payment Proof(STAMPDUTY/TRANSFERDUTY) <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100011" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100011" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100011" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100011" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100011_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID100012" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100012NAME" runat="server" CssClass="LBLBLACK" Width="385px">Registered Land Sale deed/Lease Deed/Transfer deed/Land Conversion document(Mortgage Duty) <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100012" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100012" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100012" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100012" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100012_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID100013" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100013NAME" runat="server" CssClass="LBLBLACK" Width="385px">Payment Proof(Mortgage Duty) <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100013" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100013" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100013" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100013" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100013_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID100014" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100014NAME" runat="server" CssClass="LBLBLACK" Width="385px">Registered Land Sale deed/Lease Deed/Transfer deed/Land Conversion document(Land Conversion) <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100014" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100014" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100014" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100014" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100014_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID100015" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100015NAME" runat="server" CssClass="LBLBLACK" Width="385px">Payment Proof(Land Conversion) <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100015" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100015" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100015" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100015" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100015_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID100016" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100016NAME" runat="server" CssClass="LBLBLACK" Width="385px">Registered Land Sale deed/Lease Deed/Transfer deed/Land Conversion document(Land Cost) <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100016" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100016" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100016" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100016" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100016_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID100017" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100017NAME" runat="server" CssClass="LBLBLACK" Width="385px">Payment Proof(Land Cost) <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100017" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100017" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100017" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100017" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100017_Click"/>
                            </td>

                        </tr>
                        
                        <tr runat="server" id="TRID100019" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100019NAME" runat="server" CssClass="LBLBLACK" Width="385px">UNDERTAKING ON CO-BORROWER / CO-APPLICANT / CO-OBLIGANT <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100019" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100019" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100019" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100019" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100019_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID100020" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100020NAME" runat="server" CssClass="LBLBLACK" Width="385px">Loan Account Statement <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100020" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100020" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100020" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100020" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100020_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID100021" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100021NAME" runat="server" CssClass="LBLBLACK" Width="385px">Caste certificate of co-borrower <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100021" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100021" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100021" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100021" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100021_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID100022" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100022NAME" runat="server" CssClass="LBLBLACK" Width="385px">Factory License <font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100022" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100022" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100022" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100022" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100022_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID100023" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID100023NAME" runat="server" CssClass="LBLBLACK" Width="385px">TMC and Star Rating<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID100023" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID100023" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID100023" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID100023" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID100023_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID181" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID181NAME" runat="server" CssClass="LBLBLACK" Width="385px">SCCL CERTIFICATE/INVOICE<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID181" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID181" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID181" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID181" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID181_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID182" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID182NAME" runat="server" CssClass="LBLBLACK" Width="385px">Way Bridge Documents/CA Certificate<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID182" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID182" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID182" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID182" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID182_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID183" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID183NAME" runat="server" CssClass="LBLBLACK" Width="385px">Proof of Payment Receipts/Bank Statements(COAL)<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID183" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID183" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID183" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID183" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID183_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID184" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID184NAME" runat="server" CssClass="LBLBLACK" Width="385px">CA Certificate(for Internal Power Generation/for Paper Production)<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID184" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID184" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID184" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID184" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID184_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID185" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID185NAME" runat="server" CssClass="LBLBLACK" Width="385px">Attested copy of Valid CFO(COAL)<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID185" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID185" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID185" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID185" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID185_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID191" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID191NAME" runat="server" CssClass="LBLBLACK" Width="385px">TSFDC Certificate/Invoice<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID191" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID191" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID191" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID191" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID191_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID192" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID192NAME" runat="server" CssClass="LBLBLACK" Width="385px">CA certificate/Invoice<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID192" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID192" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID192" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID192" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID192_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID193" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID193NAME" runat="server" CssClass="LBLBLACK" Width="385px"> Proof of Payment Receipts/Bank Statements(WOOD)<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID193" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID193" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID193" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID193" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID193_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID194" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID194NAME" runat="server" CssClass="LBLBLACK" Width="385px">CA Certificate for Paper Production<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID194" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID194" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID194" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID194" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID194_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID195" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID195NAME" runat="server" CssClass="LBLBLACK" Width="385px">CA Certificate for ADMT Quantity for wood Purchased<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID195" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID195" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID195" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID195" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID195_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRID196" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="LBLID196NAME" runat="server" CssClass="LBLBLACK" Width="385px">Attested copy of Valid CFO(WOOD)<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPID196" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPID196" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLID196" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNID196" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNID196_Click"/>
                            </td>

                        </tr>
                        <tr runat="server" id="TRDEETATTACHMENT100050" visible="false">
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="385px">DEET Registration Acknowledgement<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FUPDEET" runat="server" class="form-control txtbox" />
                                <asp:HyperLink ID="HYPDEET" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLDEET" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Button ID="BTNDEET" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="BTNDEET_Click"/>
                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px" valign="top" align="left">&nbsp;</td>
            </tr>
            <caption>
                &nbsp;</caption>
            </td>
                                    </tr>
                                    <tr>
                                        <td align="center"
                                            style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False"
                                                CssClass="btn btn-danger" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                Text="Submit" Width="90px"
                                                OnClientClick="return confirm('Do you want to Submit the record ? ');" />
                                            &nbsp;&nbsp;</td>
                                    </tr>
              <tr id="trRejectioinNotice" runat="server">
                                                <td align="justify" style="padding: 5px; margin: 5px; color:red; font text-align: justify;" valign="top">
                                                    <b><asp:Label runat="server" id="lblquerydays"></asp:Label> 
                                                   <%--<b>Note : If you fail to furnish the information within 45 Days from the date of query raise, the application will be rejected. </b>--%>
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
        <asp:HiddenField ID="hdfFlagID0" runat="server" />
        <asp:HiddenField ID="hdfFlagID1" runat="server" />
        <asp:HiddenField ID="hdfFlagID2" runat="server" />
                <asp:HiddenField ID="HDNQUERYRAISEDIDS" runat="server" />

        <br />
        <asp:HiddenField ID="hdfFlagID3" runat="server" />
    </div>

</asp:Content>

