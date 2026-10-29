<%@ page language="C#" autoeventwireup="true" codefile="ErrorPage.aspx.cs" inherits="UI_TSiPASS_ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <table>
                <tr>
                    <td style="height: 100px"></td>
                </tr>
                <tr>
                    <td align="center">
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/ErrorImage.jpg" height="100px" width="100px"  />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label runat="server" ID="lbl" style="font-family: math; font-size: xx-large; color: black;">Error Occurred...!</asp:Label>
                    </td>
                </tr>
                <tr align="center">
                    <td>
                        <asp:HyperLink runat="server" id="hplprev" >Please go back to previous page and try again</asp:HyperLink>

                    </td>
                </tr>


            </table>
        </div>
    </form>
    </form>
</body>
</html>
