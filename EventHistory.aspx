<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventHistory.aspx.cs" Inherits="EventHistory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event History</title>
    <link href="CSS/AjaxCal.css" rel="stylesheet" />
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
         <div align="center" style="margin-top:2%;">
                    <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
         </div>
        <div style="text-align: center; margin-top: 2%;">
              <table align="center">
                  <tr>
                      <td>From Date</td>
                      <td>:</td>
                      <td>
                          <asp:TextBox ID="txtFromDate" Width="140px" runat="server" Enabled="false" ForeColor="Black"></asp:TextBox>
                          <asp:ImageButton ID="DateBtn1" ImageUrl="~/Images/Calender1.jpg" runat="server" />
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
                         PopupButtonID="DateBtn1" Enabled="true" TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                      </td>
                      <td></td>
                      <td>To Date</td>
                      <td>:</td>
                      <td>
                          <asp:TextBox ID="txtToDate" Width="140px" runat="server" Enabled="false" ForeColor="Black"></asp:TextBox>
                          <asp:ImageButton ID="DateBtn2" ImageUrl="~/Images/Calender1.jpg" runat="server" />
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1"
                         PopupButtonID="DateBtn2" Enabled="true" TargetControlID="txtToDate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                      </td>
                  </tr>
                  <tr>
                      <td colspan="7"></td>
                  </tr>
                  <tr>
                      <td colspan="7">
                          <asp:Button ID="btnShow" runat="server" Text="Show" Width="100px" Height="35px" OnClick="btnShow_Click" />
                      </td>
                  </tr>
              </table>
        </div>
                <div style="text-align: center; margin-top: 2%;">
                    <table align="center">
                        <tr>
                            <td></td>
                            <td>
                                <asp:GridView ID="grdEventHistory" Width="600px" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
