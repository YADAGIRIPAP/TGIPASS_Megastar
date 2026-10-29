<%@ Page Language="C#"  MasterPageFile="~/UI/TSiPASS/CCMaster.master"  AutoEventWireup="true" CodeFile="frmlocationfrommap.aspx.cs" Inherits="UI_TSiPASS_frmlocationfrommap" %>

<%--<!DOCTYPE html>--%>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title></title>--%>
 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=true"></script>
    <script type="text/javascript">
        window.onload = function () {
            var mapOptions = {
                center: new google.maps.LatLng(18.1124, 79.0193),
                zoom: 14,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var res = document.getElementById('lbllatitude');
            var res1 = document.getElementById('lbllongitude');
            var res2 = document.getElementById('hf_msmeno');

            var infoWindow = new google.maps.InfoWindow();
            var latlngbounds = new google.maps.LatLngBounds();
            //var test = new google.maps.mapOptions.MapTypeId;
            var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
            google.maps.event.addListener(map, 'click', function (e) {
                if (e.latLng.lat() != "" && e.latLng.lng() != "") {
                    var r = confirm("Are you Sure about the location");
                    if (r == true) {
                        //                        alert("Latitude: " + e.latLng.lat() + "\r\nLongitude: " + e.latLng.lng());
                        if (confirm("Latitude: " + e.latLng.lat() + "\r\nLongitude: " + e.latLng.lng())) {
                            window.location = "frmMSME_edit.aspx?Latitude=" + e.latLng.lat() + "&Longitude=" + e.latLng.lng();
                        }
                    }
                    res.innerHTML = "Latitude : " + e.latLng.lat();
                    res1.innerHTML = "Longitude :" + e.latLng.lng();


                } else {

                }

            });

        }
    </script>



<%--</head>
<body>
    <form id="form1" runat="server">--%>
        
        <div id="dvMap" style="width: 500px; height: 500px">
    </div> 
       <asp:HiddenField ID="hf_msmeno" runat="server" />
         <asp:Label ID="lbllatitude" runat="server" ForeColor="Red"></asp:Label>
         <asp:Label ID="lbllongitude" runat="server" ForeColor="Red"></asp:Label>
   <%-- </form>
</body>
</html>--%>
</asp:Content>
