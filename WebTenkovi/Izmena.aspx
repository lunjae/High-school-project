<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Izmena.aspx.cs" Inherits="WebTenkovi.Izmena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
            margin: auto;
            text-align: center;
        }
        body {
            background-image: url(Slike/pozadina.jpg)
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            
        <table class="auto-style1">
            <tr style="text-align:center">
                <td class="auto-style3">Sifra</td>
                <td >
                    <asp:TextBox ID="txtSifraIzmena" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="text-align:center">
                <td class="auto-style1">Naziv</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtNazivIzmena" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="text-align:center">
                <td class="auto-style3">Kolicina</td>
                <td>
                    <asp:TextBox ID="txtKolicinaIzmena" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="text-align:center">
                <td class="auto-style3">Rad</td>
                <td >
                    <asp:TextBox ID="txtRadIzmena" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="text-align:center">
                <td class="auto-style1">Kalibar</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtKalibarIzmena" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="text-align:center">
                <td class="auto-style3">Proizvodjac</td>
                <td>
                    <asp:TextBox ID="txtProizvodjacIzmena" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Godina proizvodnje<br />
                </td>
                <td>
                    <asp:TextBox ID="txtGodinaIzmena" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="text-align:center">
                <td class="auto-style3">Slika<br />
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr style="text-align:center">
                <td colspan="2"><asp:Button ID="Button1" runat="server" Text="Potvrdi" OnClick="Potvrdi_Click"/> <asp:Button ID="Button2" runat="server" Text="Nazad" OnClick="Nazad_Click" /></td>
             </tr>
        </table>
        </div>
    </form>
</body>
</html>
