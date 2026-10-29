<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProformaQueryRaiseShortFallLetter.aspx.cs"
    Inherits="UI_TSiPASS_ProformaQueryRaiseShortFallLetter" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .leftalign {
            text-align: left;
        }

        .rightalign {
            text-align: right;
        }

        .floatleft {
            float: left;
        }

        body {
            background-color: #ffffff;
        }
    </style>
    <style type="text/css">
        .auto-style3 {
            text-align: justify;
        }

        .auto-style6 {
            text-decoration: underline;
        }
        .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
         border:1px solid #000000 !important;
        }
        /*table.table-bordered{
   border:1px solid #000000 !important;
  }
table.table-bordered > thead > tr > th{
    border:1px solid #000000 !important;
}
table.table-bordered > tbody > tr > td{
   border:1px solid #000000 !important;
}*/
    </style>
    <script type="text/javascript">

        function myFunction() {
            document.getElementById("Div1").style.visibility = "hidden";
            //$("#Button2").hide();
            window.print();
            // $("#Button2").show();
            document.getElementById("Div1").style.visibility = "visible";
        }
    </script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="border: 3px solid #000000; text-align: center;">
            <div style="padding-top: 14px">
            </div>
            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" style="width: 75px; height: 75px;" alt="" />
          
            <h3 style="color: #0000FF;">
                <asp:Label Font-Bold="true" Font-Size="14pt" ID="lblheadTPRIDE" runat="server">GOVERNMENT OF TELANGANA <br />COMMISSIONERATE OF INDUSTRIES :: HYDERABAD</asp:Label>
                <asp:Label Font-Bold="true" Font-Size="14pt" ID="lblhead" runat="server"></asp:Label>
            </h3>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px; font-weight:bold">
                <span class="auto-style6" >Memo No :</span>
                <asp:Label ID="lblLetterNo" CssClass="auto-style6" runat="server"></asp:Label>
                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<span class="auto-style6" style="font-weight: bold">Dated:</span>&nbsp;
                                <asp:Label ID="lblLetterDate" class="auto-style6" runat="server"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-15" style="padding-top: 14px">
                <span class="floatleft" style="font-weight: bold"><%--Sir,--%></span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">Sub:- Incentives - &nbsp;
                                <asp:Label ID="lblTIdeaTPride" runat="server"></asp:Label>&nbsp; - Application of&nbsp;<asp:Label
                                    ID="lblEnterpreneurDetails" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblEntDist"
                                        runat="server"></asp:Label>&nbsp; District – Reg.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">Ref :- TSIPASS Application no, <asp:Label ID="lblApplicationNo" runat="server" Text="lblApplicationNo"></asp:Label> , dt:&nbsp;
                                <%-- <asp:Label ID="lblRefLetterNo" runat="server"></asp:Label>--%>
                    <asp:Label ID="lblRefLetterDate" runat="server"></asp:Label><%--&nbsp; of the G.M., DIC,&nbsp;
                                <asp:Label ID="lblEntDist1" runat="server"></asp:Label>&nbsp; &nbsp;District--%>.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <b>******* </b>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 14px">
                <span class="floatleft auto-style3">The attention of the General Manager, District Industries Centre, &nbsp;
                                <asp:Label ID="lblEntDist2" runat="server"></asp:Label>&nbsp; District is invited
                                to the reference cited and it is to inform that on scrutiny / verification of the
                                claim application the following shortfalls are noticed.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"  style="padding-top: 20px">
                <asp:GridView ID="gvShortfalls" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" GridLines="Both" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Sl.No">
                            <ItemTemplate>
                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Incentive" HeaderText="Type of incetive" />
                        <asp:BoundField DataField="Remarks" HeaderText="Shortfalls" />
                        <asp:BoundField DataField="CreatedDate" HeaderText="DateofQuery" />
                        <asp:TemplateField HeaderText="Masterincentiveid" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblMstIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CreatedByid" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblCreatedByid" Text='<%#Eval("CreatedByid") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 20px">
                <span class="floatleft auto-style3">The General Manager, District Industries Centre,
                                &nbsp;
                                <asp:Label ID="lblEntDist3" runat="server"></asp:Label>&nbsp; District is requested
                                to furnish above shortfall information / documents of the captioned unit
                                <%--duly attested--%>
                                immediately for taking necessary action in the matter.
                </span>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 30px">
                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3" style="text-align: left;">
                        <span style="float: left;"><span style="float: left;"><b>To,</b></span><br />
                            The General Manager,<br />
                            District Industries Centre,<br />
                            <asp:Label ID="lblEntDist4" runat="server"></asp:Label>
                        </span>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4"></div>
                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5" style="text-align: left;">
                        <span style="float: right;"><span style="float: left;"></span>
                            <b>Sd/-</b><br />
                            <asp:Label ID="lblqueryraisedby" runat="server" Text=""> </asp:Label>
                            <br />
                            <asp:Label ID="lblqueryraisedbydesignation" runat="server" Text=""> </asp:Label>
                            <br />
                            Commissionerate of Industries</span>
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 20px; padding-bottom: 20px">
                <span class="floatleft auto-style3">Copy to the &nbsp;
                                <asp:Label ID="lblEnterpreneurDetails2" runat="server"></asp:Label>&nbsp;<asp:Label
                                    ID="lblEntDist6" runat="server"></asp:Label>district for information with request to submit the same through
                                GM, DIC,&nbsp;<asp:Label ID="lblEntDist5" runat="server"></asp:Label>
                    &nbsp;District.
                </span>
            </div>
            <div>
                <table>
                      <tr id="trRejectioinNotice" runat="server">
                                                <td align="justify" style="padding: 5px; margin: 5px; color:Black; font text-align: justify;" valign="top">
                                                    <b><asp:Label runat="server" id="lblquerydays"></asp:Label> 
                                                   <%--<b>Note : If you fail to furnish the information within 45 Days from the date of query raise, the application will be rejected. </b>--%>
                                                </td>
                                            </tr>
                </table>
            </div>
        </div>
        <div class="container" id="Div1" runat="server" style="text-align: center; vertical-align: bottom;">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="javascript: myFunction()" />
            </div>
        </div>
    </form>
</body>
</html>
