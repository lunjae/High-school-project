    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pocetna.aspx.cs" Inherits="WebTenkovi.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            text-align: center;
            background-image:url(Slike/pozadina2.jpg);
        }
        .auto-style1 {
            height: 23px;
            margin: auto;
        }
        #GridView1 {
            margin: auto;
        }
         #GridView1 img{
             width: 100px;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Tenkovi</h1>
        <p>SSSR/SFRJ</p>
        <p>Predstavljanje najboljih tenkova 20 veka proizvodjaca SSSR-a i SFRJ-a</p>
        <div>
             <table class="auto-style1">
                <tr>
                    <td class="auto-style1">Sifra</td>
                    <td class="auto-style1">Naziv</td>
                    <td class="auto-style1">Kolicina&nbsp;</td>
                    <td class="auto-style1">Rad</td>
                    <td class="auto-style1">Kalibar</td>
                    <td class="auto-style1">Proizvodjac</td>
                    <td class="auto-style1">Godina proizvodnje</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtSifra" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNaziv" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtKolicina" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRad" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtKalibar" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="DropDownList2" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1">
                        <asp:Button ID="btnPronadji" runat="server" Text="Pretrazi" OnClick="btnPronadji_Click1" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="176px" Width="506px" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Sifra" HeaderText="Sifra" />
                    <asp:BoundField DataField="Naziv" HeaderText="Naziv" />
                    <asp:BoundField DataField="Kolicina" HeaderText="Kolicina" />
                    <asp:BoundField DataField="Rad" HeaderText="Rad" />
                    <asp:BoundField DataField="Kalibar" HeaderText="Kalibar" />
                    <asp:BoundField DataField="Proizvodjac" HeaderText="Proizvodjac" />
                    <asp:BoundField DataField="GodinaProizvodnje" HeaderText="Godina proizvodnje" />
                    <asp:ImageField DataImageUrlField="Slika" HeaderText="Slika">
                    </asp:ImageField>
                   <asp:CommandField CancelText="" HeaderText="Izmeni/Obrisi" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ItemStyle-HorizontalAlign="Center" DeleteText="Obrisi" EditText="Izmeni" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </div>
        <asp:Button   ID="Button1" runat="server" Text="Dodaj tenk" OnClick="dodaj_Click" Height="31px" Width="99px" />
    </form>
</body>
</html>
