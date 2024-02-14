<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="CinemaAdmin.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    
        <div>
            
            <h1>Sale cinema</h1>

            <div>
            <h2>Sala nord</h2>
            <asp:Label ID="LabelNord" runat="server" Text="Biglietti normali"></asp:Label>
            <asp:Label ID="LabelRidottiNord" runat="server" Text="Biglietti ridotti"></asp:Label>
            </div>

            <div>
            <h2>Sala est</h2>
            <asp:Label ID="LabelEst" runat="server" Text="Biglietti normali"></asp:Label>
            <asp:Label ID="LabelRidottiEst" runat="server" Text="Biglietti ridotti"></asp:Label>
            </div>

            <div>
            <h2>Sala sud</h2>
            <asp:Label ID="LabelSud" runat="server" Text="Biglietti normali"></asp:Label>
            <asp:Label ID="LabelRidottiSud" runat="server" Text="Biglietti ridotti"></asp:Label>
            </div>

        </div>
    <form id="form1" runat="server">

        <div>
            <div>
            <asp:Label ID="LabelNome" runat="server" Text="Nome"></asp:Label>
            <asp:TextBox ID="TextBoxNome" runat="server"></asp:TextBox>
            </div>

            <div>
            <asp:Label ID="LabelCognome" runat="server" Text="Cognome"></asp:Label>
            <asp:TextBox ID="TextBoxCognome" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="LabelSelezione" runat="server" Text="scegli la sala"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Value="Nord">Sala Nord</asp:ListItem>
                <asp:ListItem Value="Est">Sala Est</asp:ListItem>
                <asp:ListItem Value="Sud">Sala Sud</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div>
                <asp:Label ID="LabelSelezioneTipo" runat="server" Text="Spunta se ridotto"></asp:Label>
                <asp:CheckBox ID="CheckBoxRidotto" runat="server" />
            </div>

            <div>
                <asp:Button ID="PrenotaBtn" runat="server" Text="Prenota" OnClick="PrenotaBtn_Click" />
            </div>
        </div>
    </form>
</body>
</html>
