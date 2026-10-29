<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="TestMaster.aspx.cs" Inherits="UI_TSiPASS_TestMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        table {
            border-spacing: 0;
            border-collapse: collapse;
            width: 100%;
        }

        td,
        th {
            padding: 0;
        }
    </style>
    <table width="100%" align="left">
        <tr style="height: 30px">
            <td></td>
        </tr>
        <tr>

            <td align="left" style="width: 100%">
                <asp:button text="Tab 1" borderstyle="solid" width="200px" height="50px" id="Tab1" runat="server"
                    onclick="Tab1_Click" />
                <asp:button text="Tab 2" borderstyle="solid" width="200px" height="50px" id="Tab2" runat="server"
                    onclick="Tab2_Click" />
                <asp:button text="Tab 3" borderstyle="solid" width="200px" height="50px" id="Tab3" runat="server"
                    onclick="Tab3_Click" />
                <asp:multiview id="MainView" runat="server">
            <asp:View ID="View1" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                  <td>
                    <h3>
                      <span>View 1 </span>
                    </h3>
                  </td>
                </tr>
              </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                  <td>
                    <h3>
                      View 2
                    </h3>
                  </td>
                </tr>
              </table>
            </asp:View>
            <asp:View ID="View3" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                  <td>
                    <h3>
                      View 3
                    </h3>
                  </td>
                </tr>
              </table>
            </asp:View>
          </asp:multiview>
            </td>
        </tr>
    </table>
</asp:Content>

