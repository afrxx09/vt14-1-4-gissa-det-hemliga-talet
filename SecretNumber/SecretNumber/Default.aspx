<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SecretNumber.Default" ViewStateMode="Disabled" EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/styles/styles.css" rel="stylesheet" />
    <title>Gissa det hemliga talet.</title>
</head>
<body>
    <div id="wrap">
        <div id="header">
            <h1>Gissa det hemliga talet</h1>
        </div>
        <div id="content">
            <form id="form1" runat="server">
                <div>
                    <div class="formrow errortext">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                    </div>
                    <div class="formrow">
                        <asp:Label ID="Label1" runat="server" Text="Label">Gissa på ett tal mellan 1 och 100</asp:Label>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Talet måste vara mellan 1 och 100." ControlToValidate="txtGuess" Display="Dynamic" MaximumValue="100" MinimumValue="1" Text="*" Type="Integer"></asp:RangeValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältelt får inte vara tomt" Text="*" ControlToValidate="txtGuess" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="formrow">
                        <asp:TextBox ID="txtGuess" runat="server" autofocus="autofocus"></asp:TextBox>
                        <asp:Button ID="btnMakeGuess" runat="server" Text="Gissa" OnClick="btnMakeGuess_Click" />
                    </div>
                    <div class="formrow">
                        <asp:Label ID="lblGuesses" runat="server" Visible="false"></asp:Label>
                    </div>
                    <div class="formrow">
                        <asp:Label ID="lblResponse" runat="server" Visible="false"></asp:Label>
                    </div>
                    <div class="formrow">
                        <asp:PlaceHolder ID="phGameOver" runat="server" Visible="false">
                            <asp:Button ID="btnResetGame" runat="server" Text="Starta om spelet" CausesValidation="false" />
                        </asp:PlaceHolder>
                    </div>
                </div>
            </form>
        </div>
        <div id="footer">
            <p>ASP.NET WebForms - lnu</p>
            <p>Laboration 1.4: Gissa det hemliga talet</p>
            <p>Andreas Fridlund - afrxx09</p>
        </div>
    </div>
</body>
</html>
