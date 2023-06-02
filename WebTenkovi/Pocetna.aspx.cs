using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTenkovi
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataProvider dp;
        protected void Page_Load(object sender, EventArgs e)
        {
            string putanja = Server.MapPath("~/Slike/Tenkovi.txt");
            dp = new DataProvider(putanja);
            if(!IsPostBack)
            {
                GridView1.DataSource = dp.UcitajPodatke();
               
                DropDownList1.DataSource = dp.UcitajProizvodjaca();
                DropDownList2.DataSource = dp.UcitajGodine();
                DataBind();

            }

        }

        

        protected void dodaj_Click(object sender, EventArgs e)
        {
            Session["Tenkovi"] = null;
            Response.Redirect("Izmena.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //string sifra = GridView1.Rows[e.RowIndex].Cells[0].Text;
            dp.ObrisiPodatakIzFajla(GridView1.Rows[e.RowIndex].Cells[0].Text);
            Response.Redirect("Pocetna.aspx");
           
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Tenkovi tenkovi = dp.GetTenkovi(GridView1.Rows[e.NewEditIndex].Cells[0].Text);
            Session["Tenkovi"] = tenkovi;
            Response.Redirect("Izmena.aspx");
        }

        protected void btnPronadji_Click1(object sender, EventArgs e)
        {
            string sifra = txtSifra.Text;
            string naziv = txtNaziv.Text;
            string kolicina = txtKolicina.Text;
            string rad = txtRad.Text;
            string kalibar = txtKalibar.Text;
            string proizvodjac = DropDownList1.SelectedValue;
            string godinaProizvodnje = DropDownList2.SelectedValue;
            GridView1.DataSource = dp.Pronadji(sifra, naziv, kolicina, rad, kalibar, proizvodjac, godinaProizvodnje);
            GridView1.DataBind();
        }
    }
}