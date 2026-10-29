<%@ page language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="HelpdeskDet.aspx.cs" inherits="HelpdeskDet" title=":: CAP Foundation :: Help Desk Report Details" %>

<script runat="server">

    protected void grdHelpdesk_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
</script>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">

    <asp:updatepanel id="upd1" runat="server">
        <contenttemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                           
                    <li>
                        <i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a>
                    </li>
                    <li class="">
                        <i class="fa fa-fw fa-table"></i>Masters
                            </li>
                    <li class="active">
                        <i class="fa fa-edit"></i><a href="#">Add States</a>
                    </li>
                </ol>
            </div>

            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Helpdesk Details</h3>
                            </div>
                            <div class="panel-body">

                                <table cellpadding="0" cellspacing="0" style="width: 99%">
                                    <tr>
                                        <td style="vertical-align: top; width: 50%; text-align: center">
                                            <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                                                width="100%">

                                                <tr>
                                                    <td align="center"
                                                        style="padding: 5px; vertical-align: middle; text-align: left"
                                                        valign="middle"></td>
                                                </tr>
                                                <tr>
                                                    <td align="center"
                                                        style="padding: 5px; vertical-align: middle; height: 35px; text-align: left"
                                                        valign="middle">

                                                        <asp:gridview id="grdHelpdesk" runat="server" autogeneratecolumns="False" cellpadding="4"
                                                            cssclass="GRD" forecolor="#333333" gridlines="Both"
                                                            pagesize="15" showfooter="True" style="position: static" width="100%"
                                                            onrowdatabound="grdHelpdesk_RowDataBound">
                                                            <rowstyle backcolor="#FFFFFF" cssclass="GRDITEM" horizontalalign="Left" verticalalign="Middle" height="40px" />
                                                            <columns>
                                                                <asp:boundfield headertext="Sno" />
                                                                <asp:boundfield headertext="Helpdesk Type" />
                                                                <asp:boundfield headertext="From Whom" datafield="user_Type" visible="false" />
                                                                <asp:boundfield headertext="Helpdesk Remarks" datafield="hd_desc" />
                                                                <asp:templatefield headertext="Uploaded Document">
                                                                    <edititemtemplate>
                                                                        <asp:textbox id="TextBox2" runat="server" text='<%# Bind("LINKNEW") %>'></asp:textbox>
                                                                    </edititemtemplate>
                                                                    <itemtemplate>
                                                                        <asp:hyperlink id="hypLetter" runat="server" Text='<%# Bind("hd_fileuploadname") %>' target="_blank"></asp:hyperlink>
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                 <asp:boundfield headertext="Helpdesk Date" datafield="Createddt" />
                                                                <asp:boundfield headertext="Status" datafield="Status" />
                                                                <asp:boundfield headertext="Response Remarks" datafield="Remarks" />

                                                                <asp:templatefield headertext="Response Document">
                                                                    <edititemtemplate>
                                                                        <asp:textbox id="txtReply_Filename" runat="server" text='<%# Bind("Reply_Filename") %>'></asp:textbox>
                                                                    </edititemtemplate>
                                                                    <itemtemplate>
                                                                        <asp:hyperlink id="hypReply_Filepath" text='<%# Bind("Reply_Filename") %>' runat="server" target="_blank"></asp:hyperlink>
                                                                    </itemtemplate>
                                                                </asp:templatefield>
                                                                <%--<asp:HyperLinkField HeaderText="Document" DataTextField="hd_uplddocname" >  
                                                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:HyperLinkField>--%>
                                                            </columns>
                                                            <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                            <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                            <emptydatatemplate>
                                                                <table align="center">
                                                                    <asp:label id="Label2" runat="server" font-bold="True" font-names="Verdana"
                                                                        font-size="11px" forecolor="Red" text="No Issues Found"></asp:label>
                                                                </table>
                                                            </emptydatatemplate>
                                                            <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                            <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" forecolor="White" />
                                                            <editrowstyle backcolor="#013161" />
                                                            <alternatingrowstyle backcolor="White" />
                                                        </asp:gridview>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center"
                                                        style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle; padding-top: 5px; height: 35px; text-align: center"
                                                        valign="middle">&nbsp;&nbsp;&nbsp;</td>
                                                </tr>
                                            </table>
                                            <asp:button id="BtnBack" runat="server" cssclass="BUTTON"
                                                height="20px" tabindex="10"
                                                text="Back" tooltip="Go To Feed Back Details" validationgroup="group"
                                                onclick="BtnBack_Click" />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </contenttemplate>
    </asp:updatepanel>


</asp:content>

