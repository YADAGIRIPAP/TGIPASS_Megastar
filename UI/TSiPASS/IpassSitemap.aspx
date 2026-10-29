<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="IpassSitemap.aspx.cs" Inherits="UI_TSIPASS_IpassSitemap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .vl {
            border-left: 6px solid black;
            height: 400px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="height: 30px">
    </div>
    <div style="padding-left: 110px;">

        <asp:TreeView ID="TreeView1" runat="server">
            <Nodes>
                <asp:TreeNode Text=">>Home" NavigateUrl="~/TSHome.aspx" Target="_blank" />
                <asp:TreeNode Text=">>About Us" NavigateUrl="~/about.aspx" Target="_blank"></asp:TreeNode>
                <asp:TreeNode Text="Services">
                    <asp:TreeNode Text="TS-iPass Certificate Verification" NavigateUrl="frmCFEcertificateProcess.aspx" Target="_blank" />
                    <asp:TreeNode Text="Incentive" NavigateUrl="~/IncentiveRegistrationViewDocsNew.aspx" Target="_blank" />
                    <asp:TreeNode Text="Raw Material Allocation" NavigateUrl="~/RawMatirialLink.aspx" Target="_blank" />
                    <asp:TreeNode Text="Grievance/Feedback" NavigateUrl="GuestGrievance.aspx" Target="_blank" />
                    <asp:TreeNode Text="Investor Facilitation Cell" NavigateUrl="IFCHomepage.aspx" Target="_blank" />
                    <asp:TreeNode Text="Udyog Aadhaar" NavigateUrl="http://udyogaadhaar.gov.in/" Target="_blank" />
                    <asp:TreeNode Text="Mis Reports" NavigateUrl="MisreportDashboard.aspx" Target="_blank" />
                </asp:TreeNode>
                <asp:TreeNode Text=">>Related Departments" NavigateUrl="~/links.aspx" Target="_blank"></asp:TreeNode>
                <asp:TreeNode Text=">>Information Wizard" NavigateUrl="~/Information.aspx" Target="_blank"></asp:TreeNode>
                <asp:TreeNode Text=">>Act & Rules" NavigateUrl="~/Downloads.aspx" Target="_blank"></asp:TreeNode>
                <asp:TreeNode Text=">>Business Regulations" NavigateUrl="~/UseCommentsOnAmmendments.aspx" Target="_blank"></asp:TreeNode>
                <asp:TreeNode Text=">>Contact Us" NavigateUrl="~/Contacts.aspx" Target="_blank"></asp:TreeNode>
                <asp:TreeNode Text=">>Login" NavigateUrl="~/IpassLogin.aspx" Target="_blank"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>

    </div>
    <div style="height: 50px">
    </div>
</asp:Content>

