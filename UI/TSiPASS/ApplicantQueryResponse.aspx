<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="ApplicantQueryResponse.aspx.cs" Inherits="UI_TSIPASS_ApplicantQueryResponse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <style>

        table tr td {padding-top: 10px; padding-bottom:15px}

    </style>

     <div class="container">
        <div class="row">
            <div class="col-md-10">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Query Response
                    </div>
                    <div class="panel-body">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-10" runat="server" >
                                   





                                    <table style="width: 90%"  id="tbls" runat="server">
                                        <tr>
                                            <td><b>Application Number</b></td>
                                            <td>:</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblRmId"></asp:Label></td>
                                        </tr>

                                        

                                          <tr>
                                            <td><b>District Name</b></td>
                                            <td>:</td>
                                            <td>
                                                <asp:Label runat="server" ID="lbldstid"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td><b>Unit Name</b></td>
                                            <td>:</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblUnitName"></asp:Label></td>
                                        </tr>
                                      
                                        <tr>
                                            <td><b>IndustrialPark Name</b> </td>
                                            <td>:</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblindusparkname"></asp:Label>
                                            </td>
                                        </tr>
                                            <tr>
                                            <td><b>Plots</b> </td>
                                            <td>:</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblplots"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><b>Query raise date</b> </td>
                                            <td>:</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblQueryRaisedDate"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><b>Query Description</b> </td>
                                            <td>:</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblQueryDescription"></asp:Label>
                                                <asp:HiddenField runat="server" ID="hdnQueryId" />
                                              
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tbl" >
                                            <td><b>Query Response</b></td>
                                            <td>:</td>
                                            <td runat="server"  >
                                                <asp:TextBox runat="server" class="form-control" Style="height: 160px; resize: vertical;" TextMode="MultiLine" ID="txtQueryResponse" placeholder="Enter Query Response" name="QueryResponse" />

                                                      
                                            </td>
                                        </tr>
                                        
                                         <tr>


                                            <td><b>Query Response Attachment</b></td>
                                            <td>:</td>
                                            <td>
                                                <asp:DropDownList ID="ddltssicattachments" runat="server" class="form-control col-sm-3">
                                                   
                                                </asp:DropDownList>

                                           <%--      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddltssicattachments"
                                                                                ErrorMessage="Please Upload files" Display="Dynamic" InitialValue="--Select--"  ForeColor="#CC0000" SetFocusOnError="True"
                                                                                ValidationGroup="1"></asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>


                                            <td><b>Response Attachment</b></td>
                                            <td>:</td>
                                            <td>
                                                <asp:FileUpload ID="fupResAttachment" runat="server" />
                                            </td>
                                        </tr>

                                          <tr id="Tr1" runat="server" >
                                            <td></td>
                                            <td></td>
                                            <td>
                                                <asp:Button ID="btnAttach" runat="server" Text="Attach Files"   CssClass="btn btn-warning" OnClick="btnAttach_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                    <a href="javascript:void(0);" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                </div>
                                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                    <a href="javascript:void(0);" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                    <strong>Warning!</strong>
                                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                </div>
                                                  <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="10">
                                                <div style="position:relative;left:292px;">
                                                    <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False"
                                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                                                    CssClass="GRD" ForeColor="Black" GridLines="Both"
                                                    OnRowDeleting="gvCertificate_RowDeleting" Width="50%" BackColor="LightGoldenrodYellow" EnableModelValidation="True">
                                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                    <Columns>
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
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                     

                                      <ul class="list-inline">
                                                    <li style="padding-left:280px">
                                                             <asp:Button runat="server" ID="btnSubmit" ValidationGroup="1" style="width:130px;" OnClick="btnSubmit_Click" CssClass="btn btn-success " Text="Submit" />  
                                                    </li>
                                                    <li  style="padding-left:100px">
                                                               <asp:Button runat="server" ID="Button1"  style="width:130px;" OnClick="btnSubm_Click"  CssClass="btn btn-success" Text="Dashboard" />
                                                    </li>
                                                     
                                                </ul>
                                   
                                   


                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        $(function () {
            $("[id$='success'],[id$='Failure']").fadeOut(6000);
        });

    </script>



</asp:Content>

