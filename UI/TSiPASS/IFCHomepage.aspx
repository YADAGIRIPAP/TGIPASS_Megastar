<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master"
    AutoEventWireup="true" CodeFile="IFCHomepage.aspx.cs" Inherits="UI_TSiPASS_IFCHomepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table style="width: 100%">
        <tr>
        <td>
           <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i></i><a href="Home.aspx">Home</a></li>
                    <%--<li class=""><i class="fa fa-fw fa-edit">CFE</i> </li>--%>
                    <li class="active"><i ></i>Investor Facilitation Cell
                    </li>
                </ol>
            </div>
        </td>
        </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="text-align: center; width: 100%" align="center">
                        <tr>
                            <td>
                                <strong>Investor Facilitation Cell</strong>
                            </td>
                        </tr>
                        <br />
                        <tr>
                            <td align="justify" style="padding: 5px; margin: 5px">
                                <br />
                                <ul>
                                    <li>One of the key reforms undertaken by the State Government of Telangana to improve
                                        the investment climate is to facilitate and guide the investors proposing to set
                                        up industrial units in the State. To strengthen the investor facilitation, the Government
                                        has constituted a dedicated Investor Facilitation Cell at the Commissionerate of
                                        Industries. The Facilitation Cell provides information on various approvals/clearances,
                                        queries regarding investments in the State and availability of support for Entrepreneurs.</li>
                                    <br />
                                    <br />
                                    <li>The key objective of the Facilitation Cell is to be the Single Point of contact
                                        for Investors interested in Telangana. They aim to provide focused attention in
                                        actualizing the investments on the ground through a “one stop” facilitation process.</li>
                                    <br />
                                    <br />
                                    The Investor Facilitation Cell has been constituted vide &nbsp; <a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/UI/TSIPASS/DisplayDocs/G.O.35, Investor facilitaion cell.PDF"
                                        target="_blank">G.O.Ms.No. 35</a> dated 03.06.2017
                                    <br />
                                    <br />
                                    The detailed procedures for Application Approval, Grievance Redressal and Query
                                    Handling has been defined vide Circular No. <a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/UI/TSIPASS/DisplayDocs/Working Procedures for IFC.pdf"
                                        target="_blank">15/2016/32077/EODB,Dated:27/07/2017</a>
                                </ul>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <br />
                        <tr>
                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                <asp:HyperLink ID="HyperLink5" NavigateUrl="~/UI/TSiPASS/GuestGeneralQuery.aspx"
                                    runat="server" Font-Size="Large" Target="_blank">Click here to register General Query</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                <strong>Or Call us at 040 – 23441636 and register your query with the Operator</strong>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
