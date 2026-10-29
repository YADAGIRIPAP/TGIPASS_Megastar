<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dummy.aspx.cs" Inherits="dummy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 15.0pt;
            width: 88pt;
            color: white;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #337AB7;
        }
        .style5
        {
            width: 42pt;
            color: white;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #337AB7;
        }
        .style6
        {
            width: 179pt;
            color: white;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #337AB7;
        }
        .style7
        {
            width: 103pt;
            color: white;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #337AB7;
        }
        .style8
        {
            height: 15.0pt;
            width: 88pt;
            color: #333333;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #FFFFFF;
        }
        .style12
        {
            width: 42pt;
            color: #333333;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #FFFFFF;
        }
        .style13
        {
            width: 179pt;
            color: #333333;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #FFFFFF;
        }
        .style14
        {
            width: 103pt;
            color: #333333;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #FFFFFF;
        }
        .style15
        {
            height: 15.0pt;
            width: 88pt;
            color: #333333;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: white;
        }
        .style19
        {
            width: 42pt;
            color: #333333;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: white;
        }
        .style20
        {
            width: 179pt;
            color: #333333;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: white;
        }
        .style21
        {
            width: 103pt;
            color: #333333;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: white;
        }
    .form-control{display:block;width:100%;height:34px;padding:6px 12px;font-size:14px;line-height:1.42857143;color:#555;background-color:#fff;background-image:none;border:1px solid #ccc;border-radius:4px;-webkit-box-shadow:inset 0 1px 1px rgba(0,0,0,.075);box-shadow:inset 0 1px 1px rgba(0,0,0,.075);-webkit-transition:border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;-o-transition:border-color ease-in-out .15s,box-shadow ease-in-out .15s;transition:border-color ease-in-out .15s,box-shadow ease-in-out .15s}button,select{text-transform:none}*{-webkit-box-sizing:border-box;-moz-box-sizing:border-box;box-sizing:border-box}
        .style23
        {
            height: 20px;
            width: 88pt;
            color: #333333;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #FFFFFF;
        }
        .style26
        {
            width: 42pt;
            color: #333333;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #FFFFFF;
            height: 20px;
        }
        .style27
        {
            width: 179pt;
            color: #333333;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #FFFFFF;
            height: 20px;
        }
        .style28
        {
            width: 103pt;
            color: #333333;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: left;
            vertical-align: bottom;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #FFFFFF;
            height: 20px;
        }
    </style>
</head>
<body>
<form runat="server">
    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse; width="100%">
        <colgroup>
            <col style="mso-width-source:userset;mso-width-alt:4278;width:88pt" 
                width="117" />
            <col style="mso-width-source:userset;mso-width-alt:4205;width:86pt" 
                width="115" />
            <col style="mso-width-source:userset;mso-width-alt:8740;width:179pt" 
                width="239" />
            <col style="mso-width-source:userset;mso-width-alt:5010;width:103pt" 
                width="137" />
        </colgroup>
        <tr height="20" style="height:15.0pt">
        <td class="style1" height="20" width="117">
            <asp:CheckBox ID="CheckBox1" runat="server" /></td>
            <td class="style1" height="20" width="117">
                Jobcard No</td>
            <td class="style5" width="56" align="left">
                Gender</td>
            <td class="style6" width="239">
                Household Name</td>
            <td class="style7" width="137">
                Status</td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox2" runat="server" /></td>
            <td class="style8" height="20" width="117">
                TK4/R/14/02638</td>
            <td class="style12" width="56">
                F</td>
            <td class="style13" width="239">
                ZIPPORAH WAITHERA MUIRURI</td>
            <td class="style14" width="137">
                                                        <asp:DropDownList ID="DropDownList10" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox3" runat="server" /></td>
            <td class="style8" height="20" width="117">
                TK8/R/15/06440</td>
            <td class="style12" width="56">
                F</td>
            <td class="style13" width="239">
                WINNIE NYAMBURA KINYANJUI</td>
            <td class="style14" width="137">
                                                        <asp:DropDownList ID="DropDownList11" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox4" runat="server" /></td>
            <td class="style15" height="20" width="117">
                TK4/R/14/02637</td>
            <td class="style19" width="56">
                F</td>
            <td class="style20" width="239">
                WINNIE ANYANGO OYENGO</td>
            <td class="style21" width="137">
                                                        <asp:DropDownList ID="DropDownList12" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr>
        <td class="style23" width="117">
               <asp:CheckBox ID="CheckBox5" runat="server" /></td>
            <td class="style23" width="117">
                TK6/R/15/04113</td>
            <td class="style26" width="56">
                F</td>
            <td class="style27" width="239">
                WINNELIZZ NJERI WANJIRU</td>
            <td class="style28" width="137">
                                                        <asp:DropDownList ID="DropDownList13" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox6" runat="server" /></td>
            <td class="style15" height="20" width="117">
                TK5/R/14/03952</td>
            <td class="style19" width="56">
                F</td>
            <td class="style20" width="239">
                WINFRED WAYUA MUSAU</td>
            <td class="style21" width="137">
                                                        <asp:DropDownList ID="DropDownList14" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox7" runat="server" /></td>
            <td class="style8" height="20" width="117">
                TK3/R/14/02340</td>
            <td class="style12" width="56">
                M</td>
            <td class="style13" width="239">
                WILSON MULOKI KINGOO</td>
            <td class="style14" width="137">
                                                        <asp:DropDownList ID="DropDownList15" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox8" runat="server" /></td>
            <td class="style15" height="20" width="117">
                TK7/R/15/05508</td>
            <td class="style19" width="56">
                M</td>
            <td class="style20" width="239">
                WILLIAM MATHU MWANGI</td>
            <td class="style21" width="137">
                                                        <asp:DropDownList ID="DropDownList16" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox9" runat="server" /></td>
            <td class="style15" height="20" width="117">
                TK3/R/14/02338</td>
            <td class="style19" width="56">
                F</td>
            <td class="style20" width="239">
                WAMBUA VERONICAH MWELU</td>
            <td class="style21" width="137">
                                                        <asp:DropDownList ID="DropDownList17" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox10" runat="server" /></td>
            <td class="style8" height="20" width="117">
                TK7/R/15/05487</td>
            <td class="style12" width="56">
                F</td>
            <td class="style13" width="239">
                WAINAINA MILLICENT KLANJIRU</td>
            <td class="style14" width="137">
                                                        <asp:DropDownList ID="DropDownList18" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox11" runat="server" /></td>
            <td class="style8" height="20" width="117">
                TK4/R/14/02636</td>
            <td class="style12" width="56">
                F</td>
            <td class="style13" width="239">
                VICTORIA MUMO KIMENGO</td>
            <td class="style14" width="137">
                                                        <asp:DropDownList ID="DropDownList19" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox12" runat="server" /></td>
            <td class="style15" height="20" width="117">
                TK2/D/13/01306</td>
            <td class="style19" width="56">
                F</td>
            <td class="style20" width="239">
                VENANZIAH NORA MUENI MUTUA</td>
            <td class="style21" width="137">
                                                        <asp:DropDownList ID="DropDownList20" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox13" runat="server" /></td>
            <td class="style8" height="20" width="117">
                TK7/R/15/05492</td>
            <td class="style12" width="56">
                M</td>
            <td class="style13" width="239">
                TONNY NYAMAI KATHINA</td>
            <td class="style14" width="137">
                                                        <asp:DropDownList ID="DropDownList21" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox14" runat="server" /></td>
            <td class="style15" height="20" width="117">
                TK5/R/14/03967</td>
            <td class="style19" width="56">
                M</td>
            <td class="style20" width="239">
                TITUS NGUGI NJUGUNA</td>
            <td class="style21" width="137">
                                                        <asp:DropDownList ID="DropDownList22" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox15" runat="server" /></td>
            <td class="style8" height="20" width="117">
                TK6/R/15/04087</td>
            <td class="style12" width="56">
                F</td>
            <td class="style13" width="239">
                TERESIA WANGECI GATHUKIA</td>
            <td class="style14" width="137">
                                                        <asp:DropDownList ID="DropDownList23" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox16" runat="server" /></td>
            <td class="style8" height="20" width="117">
                TK1/D/13/00961</td>
            <td class="style12" width="56">
                F</td>
            <td class="style13" width="239">
                TERESIA NJAMBI MUTHONI</td>
            <td class="style14" width="137">
                                                        <asp:DropDownList ID="DropDownList24" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        <tr height="20" style="height:15.0pt">
        <td class="style8" height="20" width="117">
               <asp:CheckBox ID="CheckBox17" runat="server" /></td>
            <td class="style15" height="20" width="117">
                TK3/R/14/02336</td>
            <td class="style19" width="56">
                F</td>
            <td class="style20" width="239">
                TERESIA MUTIO MUTUA</td>
            <td class="style21" width="137">
                                                        <asp:DropDownList ID="DropDownList25" runat="server" 
                                                            class="form-control txtbox" 
                    Height="28px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Present</asp:ListItem>
                                                            <asp:ListItem>Absent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
        </tr>
        </table>
     </form>
</body>
</html>
