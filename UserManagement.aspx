<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="UserManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel1" ID="updtProgressempsearch"  runat="server">
       <ProgressTemplate>
                <div align="center" style="padding-top: 1%;">                     
                   <b>Loading Please Wait...</b>                     
                    <img src="Images/asd.gif" runat="server" id="imgloader" />                    
                </div>
       </ProgressTemplate>
     </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>    
                <div align="center" style="margin-top: 2%;">
                    <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
        <div style="position:absolute;text-align: center; margin-left:3%; width:300px;margin-top: 2%;">
              <table align="center" width="100%">
                  <tr>

                  </tr>
              </table>
         </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
