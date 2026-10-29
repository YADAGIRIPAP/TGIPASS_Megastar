<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmDharaniredriect.aspx.cs" Inherits="UI_TSiPASS_frmDharaniredriect" %>

<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    	<script>
            function validate() {
                var myFormDate = new FormData();
                //myFormDate.append("hashcode",
                //    "b241fc34dcee0ccae65e6488c8c8602bd05a9a06");
                var Hashcode = '<%= Session["Hashcode"] %>';
                myFormDate.append("hashcode", Hashcode);
               // alert("hashcode is:= " + Hashcode)

                //myFormDate.append("saltkey", "637109790414002498");
                var saltkey = '<%= Session["Saltkey"] %>';
                myFormDate.append("saltkey", saltkey);

                var userId = '<%= Session["userId"] %>';
                myFormDate.append("userId", userId);
                //alert("salt key is:= " + saltkey)
                $.ajax({
                    type: "POST",
                    url: 'https://dharani.telangana.gov.in/validateipassuser',
                    cache: false,
                    //timeout : 600000,
                    data: myFormDate,
                    processData: false,
                    contentType: false,
                    success: function (response) {
                        //    	                alert("Validation Complete your jwttoken is11:= ")
                        document.getElementById("jwttoken").value = response;
                        //alert('Success');
                       // alert("Validation Complete your jwttoken is:= " + response)
                        //consoLE.log(response);

                        document.form1.method = "POST";
                        document.form1.action = "https://dharani.telangana.gov.in/ipassCitizenAuthenticate";
                        document.form1.submit();
                    },
                    failure: function (response) {
                        alert(response.d)
                       // cOnsoLe.loG('Failed');
                    }

                });
                window.onload = validate;
            }
            function redirect() {
                document.form1.method = "POST";
                document.form1.action = "https://14.99.115.179:9095/ipassCitizenAuthenticate";
                document.form1.submit();
            }
	</script>
</head>
<body  onload ="validate()">
    <form id="form1" runat="server">
  <%--  method="post"  action="https://14.99.115.179:9095/ipassCitizenAuthenticate"--%>
    <input type="hidden" name="jwttoken" id="jwttoken" />
	<%--<input type="button" value="Redirect" onclick="redirect();" />--%>
        <asp:Label runat="server" ID="NOTE" Text="PLEASE WAIT ... <br/> DO NOT REFRESH THE PAGE. YOU WILL BE AUTOMATICALLY REDIRECTED TO ANOTHER PAGE"></asp:Label>
        <%--<input type="text" name="note" id="note" value="PLEASE WAIT ... DO NOT REFRESH THE PAGE. YOU WILL BE AUTOMATICALLY REDIRECTED TO ANOTHER PAGE." />--%>
</form>
</body>
</html>
