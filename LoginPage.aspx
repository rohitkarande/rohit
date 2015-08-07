<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
     <script type="text/javascript" language="javascript">
         javascript: window.history.forward(1);
    </script>
    <script type="text/javascript">
        function validate() {
            if (document.getElementById('txtUserName').vlaue == "") {
                alert('Please enter Username').
                document.getElementById('txtUserName').setFocus();
                return false;
            }
            if (document.getElementById('txtPassword').vlaue == "") {
                alert('Please enter Password').
                document.getElementById('txtPassword').setFocus();
                return false;
            }
        }

        function WaterMarkUname(txtUserName, event) {
            var defaultText = "Enter Username Here";            
            // Condition to check textbox length and event type
            if (txtUserName.value.length == 0 & event.type == "blur") {
                //if condition true then setting text color and default text in textbox
                txtUserName.style.color = "Gray";
                txtUserName.value = defaultText;
            }
            // Condition to check textbox value and event type
            if (txtUserName.value == defaultText & event.type == "focus") {
                txtUserName.style.color = "black";
                txtUserName.value = "";
            }
        }

        function WaterMarkPswd(txtPassword, event) {            
            var pswdText = "Enter Password Here";            
            // Condition to check textbox length and event type
            if (txtPassword.value.length == 0 & event.type == "blur") {
                //if condition true then setting text color and default text in textbox
                txtPassword.type = "SingleLine";
                txtPassword.style.color = "Gray";
                txtPassword.value = pswdText;
            }
            // Condition to check textbox value and event type
            if (txtPassword.value == pswdText & event.type == "focus") {
                txtPassword.style.color = "black";
                txtPassword.type = "Password";
                txtPassword.value = "";
            }
        }

        //....Function for focus on Login button....//
        function clickButton(e, btnLogin) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(btnLogin);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div style="text-align:center; margin-top:9%;">
        <div style="text-align:center;">
            <b style="color:lightblue; font-size:30px;">Login</b>
        </div>
    <table align="center" style=" margin-top:2%;">        
        <tr>
        <td>
            <asp:TextBox ID="txtUserName" runat="server" Text="Enter Username Here" ForeColor="Gray" onblur = "WaterMarkUname(this, event);" onfocus = "WaterMarkUname(this, event);" Width="300px" Height="30px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" Text="Enter Password Here" ForeColor="Gray" onblur = "WaterMarkPswd(this, event);" onfocus = "WaterMarkPswd(this, event);" Width="300px" Height="30px"></asp:TextBox>
        </td>
        </tr>
        <tr>
            <td style="text-align:center; height:30px;">
                <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" Width="300px" Height="40px" OnClick="btnLogin_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td><a href="">Forgot Password</a> </td>
        </tr>

    </table>
    </div>
                </ContentTemplate>            
        </asp:UpdatePanel>
        <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel1" ID="updtProgressempsearch"  runat="server">
       <ProgressTemplate>
                <div align="center" style="padding-top: 2%;">                     
                   <b>Loading Please wait...</b>                     
                    <img src="Images/asd.gif" runat="server" id="imgloader" />                    
                </div>
       </ProgressTemplate>
     </asp:UpdateProgress>
    </form>
</body>
</html>
