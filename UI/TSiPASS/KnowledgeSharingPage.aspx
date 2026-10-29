<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="KnowledgeSharingPage.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <table  id="divPrint" runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
     <tr>
         <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
             valign="top" align="center">
             <div class="col-lg-12" style="left: 0px; top: 0px">
                 <div class="panel panel-default">
                     <div class="panel-heading" style="text-align: center">
                         <h3 visible="false" id="Government" runat="server" class="panel-title" style="font-weight: bold;">Government of Telangana</h3>
                         <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;"><asp:Label ID="lblHeading" runat="server">TSiPASS-KnowledgingSharing Report </asp:Label>
                             <a id="Button2" href="#"   onserverclick="Button2_ServerClick"
                             runat="server">
                             <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                 alt="PDF" /></a> <a id="Button1" href="#" onserverclick="Button1_ServerClick" runat="server">
                                     <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                         alt="Excel" /></a></h2>
                     </div>
    <div>
        <div>
             <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5" style="width: 80%;font-family:'Trebuchet MS'">
                                <tr>
                                    <td>
            <table align="center" cellpadding="10" cellspacing="5">

                <tr>
                    <td>
                        <table  runat="server" id="tblselection" cellpadding="4" cellspacing="5" style="width: 100%">
                            <tr>
                                  <td style="padding: 5px; margin: 5px" align="center" runat="server" id="tdFromDate">
                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            From Date
                                                        </div>

                                                        <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </td>
                             <%--   <td style="padding: 5px; margin: 5px" align="center" runat="server" id="tdFromDate">
                                    <asp:Label ID="lblfromdt" runat="server">FromDate</asp:Label>
                                </td>
                                <td style="width: 10px">:</td>
                                <td style="width: 80px">
                                   <%-- <asp:TextBox ID="txtFromDate" runat="server" class="form-control" Width="200px" TabIndex="1"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtfrmdate_CalendarExtender" runat="server"
                                        Format="dd-MM-yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
                                    </cc1:CalendarExtender>--%>
                                  <%--   <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                    </cc1:CalendarExtender>--%>

                             
                                <td style="padding: 5px; margin: 5px" runat="server" id="tdToDate">

                                                    <div class="input-group">
                                                        <div class="input-group-addon">
                                                            To Date
                                                        </div>
                                                        <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </td>

                                   <%-- <asp:TextBox ID="txtTodate" runat="server" class="form-control" Width="200px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txttodate_CalendarExtender" runat="server"
                                        Format="dd-MM-yyyy" PopupButtonID="txtTodate" TargetControlID="txtTodate">
                                    </cc1:CalendarExtender>--%>
                                   <%--   <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                    </cc1:CalendarExtender>

                                </td>--%>

                            </tr>
                            </table>
                        </td>
                    </tr>              
                            <tr>
                                <td align="center" style="padding: 5px; padding-left: 120px; margin: 5px; text-align: center; height: 50px" colspan="10">&nbsp;&nbsp;
                                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                                                    Height="32px" TabIndex="10" Text="Submit" ValidationGroup="group"
                                                    Width="120px" OnClick="BtnSave_Click" />
                                
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="10"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbllable" runat="server"></asp:Label></td>
                </tr>
            </table>
                  <div style="margin-left: 170px">
        <table align="left" cellspacing="5">
            <tr>
                <td align="center" style="text-align: center;" valign="top" colspan="5">
                    <asp:GridView ID="Gridview" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                            Width="200%" ShowFooter="True" >
                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate> 
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                            </asp:TemplateField>
                          <asp:BoundField HeaderText="Name of Section" DataField="Name of Section" >
                            <ItemStyle CssClass="text-center" />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="Description Of Document" DataField="DescriptionofDocument">
                            <ItemStyle HorizontalAlign="Center" CssClass="tex-center" />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="Remark" DataField="Remarkmultiline">
                            <ItemStyle HorizontalAlign="Center" CssClass="aligncenter" />
                        </asp:BoundField>
<%--                                                <asp:BoundField HeaderText="Upload" DataField="Section_File_Path" />--%>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Upload">
                             <ItemTemplate>
                          <asp:HyperLink ID="Hyperlink" runat="server" Text="Upload" NavigateUrl='<%#Eval("Section_File_Path", "~/YourNextPage.aspx") %>' Target="_blank"></asp:HyperLink>
                          </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" CssClass="text-center" />
                            </asp:TemplateField>
                           
                        </Columns>
                    </asp:GridView>
                </td>
                
            </tr>
            
        </table>        
    </div>
        </div>



    </div>
    <br />

   
               </div>  
      </div>         
     </div>
     </td>
      </tr>
            </table>
</asp:Content>

