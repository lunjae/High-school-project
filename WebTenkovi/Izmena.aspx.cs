using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTenkovi
{
    public partial class Izmena : System.Web.UI.Page
    {
        DataProvider dp;
        Tenkovi tenkovi;
        protected void Page_Load(object sender, EventArgs e)
        {
            string putanja = Server.MapPath("~/Slike/Tenkovi.txt");
            dp = new DataProvider(putanja);

            tenkovi = Session["Tenkovi"] as Tenkovi;

            if(!IsPostBack)
            {
                if (tenkovi != null)
                {
                    txtSifraIzmena.Text = tenkovi.Sifra;
                    txtNazivIzmena.Text = tenkovi.Naziv;
                    txtKolicinaIzmena.Text = tenkovi.Kolicina;
                    txtRadIzmena.Text = tenkovi.Rad;
                    txtKalibarIzmena.Text = tenkovi.Kalibar;
                    txtProizvodjacIzmena.Text = tenkovi.Proizvodjac;
                    txtGodinaIzmena.Text = tenkovi.GodinaProizvodnje;
  
                }
            }

        }

        protected void Potvrdi_Click(object sender, EventArgs e)
        {

            Tenkovi t = new Tenkovi()
            {
                Sifra = txtSifraIzmena.Text,
                Naziv = txtNazivIzmena.Text,
                Kolicina = txtKolicinaIzmena.Text,
                Rad = txtRadIzmena.Text,
                Kalibar = txtKalibarIzmena.Text,
                Proizvodjac = txtProizvodjacIzmena.Text,
                GodinaProizvodnje = txtGodinaIzmena.Text,
                Slika = FileUpload1.FileName
            };
            if(t!=null)
            {
                dp.DodajPodatakUFajl(t);

            }
            Response.Redirect("Pocetna.aspx");
        }

        protected void Nazad_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pocetna.aspx");
        }
    }
}