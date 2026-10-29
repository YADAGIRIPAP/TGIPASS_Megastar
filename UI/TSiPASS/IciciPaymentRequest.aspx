<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="IciciPaymentRequest.aspx.cs" Inherits="IciciPaymentRequest" Title="Online Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<table style="width: 550px;border-collapse:collapse;" border="1">
                                                  <tr>
                                                      <td class="GRD" style="height: 23px; font-weight: bold;" colspan="2">
                                                          Merchant Transaction Details
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA">Request Type </span>:</td>
                                                      <td align="left">
                                                          <asp:TextBox ID="TxtReqType" runat="server" Width="262px" ReadOnly="True">T</asp:TextBox></td>
                                                  </tr>
                                                  <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA">Merchant Code</span>:</td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtMarchantCode" runat="server" Width="262px" ReadOnly="True">L57156</asp:TextBox></td>
                                                  </tr>
                                                  <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA">Merchant Txn RefNumber</span> :</td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtMerTransRefNumber" runat="server" Width="262px" ReadOnly="True"></asp:TextBox></td>
                                                  </tr>
                                                  <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA">ITC:</span></td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtITC" runat="server" Width="262px" ReadOnly="True"></asp:TextBox></td>
                                                  </tr>
                                                    <%--<tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA">MerchantTxnRefNumber</span> :</td>
                                                      <td align="left">
                                                          <asp:TextBox ID="TxtMerTransRefNo" runat="server" Width="262px" ReadOnly="True"></asp:TextBox></td>
                                                  </tr>
                                                  <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA">ITC:</span></td>
                                                      <td align="left">
                                                          <asp:TextBox ID="TxtITC" runat="server" Width="262px" ReadOnly="True"></asp:TextBox></td>
                                                  </tr>--%>
                                                    <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA">Amount</span> :</td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtAmount" runat="server" Width="262px" ReadOnly="True"></asp:TextBox></td>
                                                  </tr>
                                                  <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA"><span style="font-size: 11pt; font-family: 'Calibri','sans-serif';
                                                                  mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                                                  mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                                                  Currency Code</span>:</span></td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtCurrancyCode" runat="server" Width="262px" ReadOnly="True">INR</asp:TextBox></td>
                                                  </tr>
                                                    <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA">Unique Customer Id</span> :</td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtUniqueCustId" runat="server" Width="262px" ReadOnly="True"></asp:TextBox></td>
                                                  </tr>
                                                  <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA"><span style="font-size: 11pt; font-family: 'Calibri','sans-serif';
                                                                  mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                                                  mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                                                  Return URL</span>:</span></td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtReturnUrl" runat="server" Width="262px" ReadOnly="True"></asp:TextBox></td>
                                                  </tr>
                                                    <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA"><span style="font-size: 11pt; font-family: 'Calibri','sans-serif';
                                                                  mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                                                  mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                                                  S2S Return URL</span></span> :</td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtReturnS2s" runat="server" Width="262px" ReadOnly="True"></asp:TextBox></td>
                                                  </tr>
                                                  <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA"><span style="font-size: 11pt; font-family: 'Calibri','sans-serif';
                                                                  mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                                                  mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                                                  TPSLTxn ID</span>:</span></td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtTpslTxnId" runat="server" Width="262px" ReadOnly="True"></asp:TextBox></td>
                                                  </tr>
                                                     <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA"><span style="font-size: 11pt; font-family: 'Calibri','sans-serif';
                                                                  mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                                                  mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                                                  Shopping Cart Details</span>:</span></td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtShoppingCartDtls" runat="server" Width="262px" ReadOnly="True"></asp:TextBox></td>
                                                  </tr>
                                                     <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA"><span style="font-size: 11pt; font-family: 'Calibri','sans-serif';
                                                                  mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                                                  mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                                                  txn Date</span>:</span></td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtDate" runat="server" Width="262px" ReadOnly="True"></asp:TextBox></td>
                                                  </tr>
                                                     <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA"><span style="font-size: 11pt; font-family: 'Calibri','sans-serif';
                                                                  mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                                                  mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                                                  Email</span>:</span></td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtEmailId" runat="server" Width="262px"></asp:TextBox></td>
                                                  </tr>
                                                     <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA"><span style="font-size: 11pt; font-family: 'Calibri','sans-serif';
                                                                  mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                                                  mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                                                  Mobile Number</span>:</span></td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtMobileNumber" runat="server" Width="262px"></asp:TextBox></td>
                                                  </tr>
                                                     <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA"><span style="font-size: 11pt; font-family: 'Calibri','sans-serif';
                                                                  mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                                                  mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                                                  <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                                      mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                                      mso-bidi-language: AR-SA">Bank Code</span></span>:</span></td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtBankCode" runat="server" Width="262px">470</asp:TextBox></td>
                                                  </tr>
                                                   <tr>
                                                      <td align="right">
                                                          <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                              mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                              mso-bidi-language: AR-SA"><span style="font-size: 11pt; font-family: 'Calibri','sans-serif';
                                                                  mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                                                                  mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                                                                  <span style="font-size: 11pt; font-family: 'Calibri','sans-serif'; mso-fareast-font-family: 'Times New Roman';
                                                                      mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
                                                                      mso-bidi-language: AR-SA">Customer Name</span></span>:</span></td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtCustomerName" runat="server" Width="262px"></asp:TextBox></td>
                                                  </tr>
                                                  <tr>
                                                      <td>
                                                      </td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtpropertypath" runat="server" Width="262px" ReadOnly="True" Visible="false"></asp:TextBox></td>
                                                  </tr>
                                               <%--   <tr>
                                                      <td>
                                                      </td>
                                                      <td align="left">
                                                          <asp:TextBox ID="txtaccountno" runat="server" Width="262px" ReadOnly="True" Visible="false" Text=""></asp:TextBox></td>
                                                  </tr>--%>
                                                  <tr><td colspan="2">
                                                      <asp:Label ID="lblError" runat="server" Text=""></asp:Label></td></tr>
                                                  <tr><td colspan="2"></td></tr>
                                                  <tr>
                                                      <td colspan="2">
                                                          <asp:Button ID="btn_Request" runat="server" OnClick="btn_Request_Click" Text=" Submit Payment" />
                                                          <br />
                                                      </td>
                                                  </tr>
                                              </table>
</asp:Content>

