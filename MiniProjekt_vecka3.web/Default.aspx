<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MiniProjekt_vecka3.web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="PingisStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <h1 style="color:#353535 ; font-size: 80px; text-align: center">Academy C#.NET VT18
                <br />
                Pingis Pingis Pingis</h1>
            <center>
            <table class="keywords">
                <thead>
                    <tr>
                        <th>Player</th>
                        <th>Matches Played</th>
                        <th>Matches Won</th>
                        <th>Matches Lost</th>
                        <th>Sets Won</th>
                        <th>Sets Lost</th>
                        <th>Set Difference</th>
                    </tr>
                </thead>

                <asp:Repeater ID="leagueRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td ><%# Eval("Name") %></td>
                            <td><%# Eval("MatchesPlayed") %></td>
                            <td><%# Eval("MatchesWon") %></td>
                            <td><%# Eval("MatchesLost") %></td>
                            <td><%# Eval("SetsWon") %></td>
                            <td><%# Eval("SetsLost") %></td>
                            <td><%# Eval("SetDifference") %></td>
                        </tr>       
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <asp:Button ID="btnMatch" runat="server" Text="Add"/>
            <table>

                <thead>
                    <tr>
                        <th>
                            <asp:DropDownList ID="DropDownListPlayer" runat="server">
                            </asp:DropDownList></th>
                        <th>
                            <asp:DropDownList ID="DropDownListP1Sets" runat="server">
                                <asp:ListItem Value="0">0</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                            </asp:DropDownList></th>
                        <th></th>
                        <th>
                            <asp:DropDownList ID="DropDownListP2Sets" runat="server">
                                <asp:ListItem Value="0">0</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                            </asp:DropDownList></th>
                        <th>
                            <asp:DropDownList ID="DropDownListPlayer2" runat="server">
                            </asp:DropDownList></th>

                    </tr>
                    <tr>
                        <th>Player 1</th>
                        <th class="score"></th>
                        <th class="middle"></th>
                        <th class="score"></th>
                        <th>Player 2</th>
                    </tr>
                </thead>

                <asp:Repeater ID="matchRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="nameL"><%# Eval("Player1") %></td>
                            <td class="score"><%# Eval("Player1Sets") %></td>
                            <td class="middle">-</td>
                            <td class="score"><%# Eval("Player2Sets") %></td>
                            <td class="nameR"><%# Eval("Player2") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
			<asp:TextBox ID="newPlayerName" runat="server" placeholder="Player Name"/>
			<asp:TextBox ID="newPlayerPwd" runat="server" placeholder="Password" TextMode="Password"/>
            <asp:Button ID="btnAddPlayer" runat="server" Text="Add new player" />
				<br />
				<br />
				<p>Remove Player:</p><asp:DropDownList ID="DropDownRemove" runat="server">
                </asp:DropDownList><asp:TextBox ID="RemovePwd" runat="server" placeholder="Password" TextMode="Password"/>
				<asp:Button ID="btnRemovePlayer" runat="server" Text="Remove player" />
                </center>
        </div>
    </form>
</body>
</html>
