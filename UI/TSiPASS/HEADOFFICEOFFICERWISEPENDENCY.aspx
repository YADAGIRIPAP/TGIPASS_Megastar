<%@ page language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="HEADOFFICEOFFICERWISEPENDENCY.aspx.cs" inherits="UI_TSiPASS_HEADOFFICEOFFICERWISEPENDENCY" %>



<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">




    <div class="col-lg-12">
        <div class="panel panel-default">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td colspan="4">
                        <div class="panel-heading" align="center">
                            <h2 class="panel-title" style="font-weight: bold;">Officer Wise Pendency Report
                          <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                              <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                  alt="Excel" /></a> </h2>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="padding: 5px; margin: 5px" id="divPrint" runat="server">
                        <asp:gridview id="grdDetails" cssclass="floatingTable" runat="server" autogeneratecolumns="False" cellpadding="4"
                            onrowdatabound="grdDetails_RowDataBound" width="100%" OnRowCreated="grdDetails_RowCreated"
                            showfooter="True">
                            <headerstyle forecolor="#FFFFFF" backcolor="#009688" HorizontalAlign="Center" height="40px" cssclass="GridviewScrollC1HeaderWrap" />
                            <rowstyle height="40px" cssclass="GridviewScrollC1Item" />
                            <pagerstyle cssclass="GridviewScrollC1Pager" />
                            <footerstyle forecolor="#FFFFFF" backcolor="#009688" height="40px" cssclass="GridviewScrollC1Footer" />
                            <alternatingrowstyle height="40px" cssclass="GridviewScrollC1Item2" />
                            <columns>
                                <asp:templatefield headerstyle-horizontalalign="Center" headertext="S.No">
                                    <itemtemplate>
                                        <%# Container.DataItemIndex +1 %>
                                    </itemtemplate>
                                    <headerstyle horizontalalign="Center" />
                                </asp:templatefield>
                                <asp:boundfield datafield="USERNAME" headertext="Level of Officer"></asp:boundfield>
                                <asp:hyperlinkfield itemstyle-horizontalalign="Center" headertext="Within Count"
                                    datatextfield="WITHINCOUNT">
                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                    <itemstyle font-underline="false" horizontalalign="Center" cssclass="text-center" />
                                </asp:hyperlinkfield>
                                <asp:hyperlinkfield itemstyle-horizontalalign="Center" headertext="Beyond Count"
                                    datatextfield="BEYONDCOUNT">
                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                    <itemstyle font-underline="false" horizontalalign="Center" cssclass="text-center" />
                                </asp:hyperlinkfield>
                                <asp:hyperlinkfield itemstyle-horizontalalign="Center" headertext="Within Query count"
                                    datatextfield="WITHINCOUNTQUERY">
                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                    <itemstyle font-underline="false" horizontalalign="Center" cssclass="text-center" />
                                </asp:hyperlinkfield>
                                <asp:hyperlinkfield itemstyle-horizontalalign="Center" headertext="Beyond Query count"
                                    datatextfield="BEYONDCOUNTQUERY">
                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                    <itemstyle font-underline="false" horizontalalign="Center" cssclass="text-center" />
                                </asp:hyperlinkfield>
                                <asp:hyperlinkfield itemstyle-horizontalalign="Center" headertext="Within Count"
                                    datatextfield="WITHINTOTAL">
                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                    <itemstyle font-underline="false" horizontalalign="Center" cssclass="text-center" />
                                </asp:hyperlinkfield>
                                <asp:hyperlinkfield itemstyle-horizontalalign="Center" headertext="Beyond Count"
                                    datatextfield="BEYONDTOTAL">
                                    <footerstyle horizontalalign="Center" font-underline="false" font-bold="true" cssclass="text-center" />
                                    <itemstyle font-underline="false" horizontalalign="Center" cssclass="text-center" />
                                </asp:hyperlinkfield>
                                <asp:boundfield datafield="USERID" headertext="USERID" visible="false"></asp:boundfield>


                            </columns>
                        </asp:gridview>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:content>

