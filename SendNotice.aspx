<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendNotice.aspx.cs" Inherits="SendNotice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Notice</title>

    <script language="javascript" type="text/javascript">
        function ConfirmSend() {
            if (confirm("Are you sure to Send?") == false) {
                return false;
            }
            return true;
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

         <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel1" ID="updtProgressempsearch"  runat="server">
       <ProgressTemplate>
                <div align="center" style="padding-top: 1%;">                     
                   <b>Sending Messages Please Wait...</b>                     
                    <img src="Images/asd.gif" runat="server" id="imgloader" />                    
                </div>
       </ProgressTemplate>
     </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div align="center" style="margin-top:2%;">
                    <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
                <div style="text-align: center; margin-top: 2%;">
                    <table align="center">
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlTownship" runat="server" Width="160px" AutoPostBack="true" OnSelectedIndexChanged="ddlTownship_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td></td>
                            <td>
                                <asp:DropDownList ID="ddlSector" runat="server" Width="160px" AutoPostBack="true" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td></td>
                            <td>
                                <asp:DropDownList ID="ddlBuilding" runat="server" Width="160px" AutoPostBack="true" OnSelectedIndexChanged="ddlBuilding_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="5">Select Flat No: </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                                <div style="overflow: scroll; width: 240px; height: 220px; text-align:left;">
                                    <asp:CheckBox ID="chkAllFLats" runat="server" AutoPostBack="true" OnCheckedChanged="chkAllFLats_CheckedChanged" Style="margin-left: 3px" Text="All" Visible="false" />
                                    <asp:CheckBoxList ID="chkFlats" runat="server" AutoPostBack="True" OnSelectedIndexChanged="chkFlats_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="5">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                                <asp:TextBox ID="txtTitle" Width="500px" Placeholder="Title" Height="30px" runat="server"></asp:TextBox>
                            </td>                            
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                                <asp:TextBox ID="txtMessage" Width="550px" Placeholder="Message" Height="80px" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </td>                            
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                                &nbsp;</td>                            
                        </tr>
                        <tr>
                            <td align="center" colspan="5">
                                <asp:Button ID="btnSend" runat="server" Height="35px" Text="SEND" Width="160px" OnClick="btnSend_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
