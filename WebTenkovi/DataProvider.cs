using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebTenkovi
{
    public class DataProvider
    {
        private string _putanja;
        public string Poruka { get; set;}

        public DataProvider(string putanja)
        {
            _putanja = putanja;
        }

       
        public List<Tenkovi> UcitajPodatke()
        {
            List<Tenkovi> listaTenkova = new List<Tenkovi>();

            try
            {
                using(StreamReader sr = new StreamReader(_putanja))
                {
                    string red;

                    while((red = sr.ReadLine())!=null)
                    {
                        var niz = red.Split('|');

                        Tenkovi tenk = new Tenkovi
                        {
                            Sifra = niz[0],
                            Naziv = niz[1],
                            Kolicina = niz[2],
                            Rad = niz[3],
                            Kalibar = niz[4],
                            Proizvodjac = niz[5],
                            GodinaProizvodnje = niz[6],
                            Slika = niz[7]
                        };

                        listaTenkova.Add(tenk);
                    }
                }
                return listaTenkova;
            }
            catch(Exception ex)
            {
                Poruka = ex.Message;
                return null;
            }
        }

        public bool DodajPodatakUFajl(Tenkovi tenk)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(_putanja, true))
                {
                    string red = string.Format($"{tenk.Sifra}|{tenk.Naziv}|{tenk.Kolicina}|{tenk.Rad}|{tenk.Kalibar}|{tenk.Proizvodjac}|{tenk.Proizvodjac}|{tenk.GodinaProizvodnje}|{tenk.Slika}");
                    sw.WriteLine(red);
                }
                Poruka = "Upesno dodat novi ucenik u fajl";
                return true;
            }
            catch (Exception ex)
            {
                Poruka = ex.Message;
                return false;
            }
        }

        public List<Tenkovi> ObrisiPodatakIzListe(string sifra)
        {
            var listaTenkova = UcitajPodatke();

            Tenkovi tenkovi = listaTenkova.FirstOrDefault(t => t.Sifra == sifra);
            listaTenkova.Remove(tenkovi);

            return listaTenkova;
        }

        public bool IzmeniPodatak(Tenkovi t_tenk)
        {
            var listaTenkova = UcitajPodatke();
            var tenk = listaTenkova.FirstOrDefault(t => t.Sifra == t_tenk.Sifra);

            if (tenk != null)
            {
                tenk.Sifra = t_tenk.Sifra;
                tenk.Naziv = t_tenk.Naziv;
                tenk.Kolicina = t_tenk.Kolicina;
                tenk.Rad = t_tenk.Rad;
                tenk.Kalibar = t_tenk.Kalibar;
                tenk.Proizvodjac = t_tenk.Proizvodjac;
                tenk.GodinaProizvodnje = t_tenk.GodinaProizvodnje;
            }

            bool podatakIzmenjen = UpisiPodatke(listaTenkova);
            return podatakIzmenjen;
        }

        public bool UpisiPodatke(List<Tenkovi> listaTenkova)
        { 
            try
            {
                using(StreamWriter sw = new StreamWriter(_putanja))
                {
                    foreach(var tenk in listaTenkova)
                    {
                        string red = string.Format($"{tenk.Sifra}|{tenk.Naziv}|{tenk.Kolicina}|{tenk.Rad}|{tenk.Kalibar}|{tenk.Proizvodjac}|{tenk.GodinaProizvodnje}|{tenk.Slika}");
                        sw.WriteLine(red);
                    }
                }
                Poruka = "Uspesno!";
                return true;
            }
            catch(Exception ex)
            {
                Poruka = ex.Message;
                return false;
            }

        }

        public  bool ObrisiPodatakIzFajla(string sifra)
        {
            return UpisiPodatke(ObrisiPodatakIzListe(sifra));
        }

        public List<Tenkovi> Pronadji(string sifra = "", string naziv ="", string kolicina = "", string rad ="", string kalibar = "", string proizvodjac = "", string godinaProizvodnje = "")
        {
            var listaTenkova = UcitajPodatke();
            var listaRezultata = new List<Tenkovi>();

            foreach(var Tenk in listaTenkova)
            {
                if(
                    (string.IsNullOrWhiteSpace(sifra) || Tenk.Sifra.Contains(sifra))&&
                    (string.IsNullOrWhiteSpace(naziv) || Tenk.Naziv.Contains(naziv))&&
                    (string.IsNullOrWhiteSpace(kolicina) || Tenk.Kolicina.Contains(kolicina))&&
                    (string.IsNullOrWhiteSpace(rad) || Tenk.Rad.Contains(rad))&&
                    (string.IsNullOrWhiteSpace(kalibar) || Tenk.Kalibar.Contains(kalibar))&&
                    (string.IsNullOrWhiteSpace(proizvodjac) || Tenk.Proizvodjac.Contains(proizvodjac))&&
                    (string.IsNullOrWhiteSpace(godinaProizvodnje) || Tenk.GodinaProizvodnje.Contains(godinaProizvodnje))
                    )
                {
                    listaRezultata.Add(Tenk);
                }
            }

            return listaRezultata;
        }

        public Tenkovi GetTenkovi(string sifra)
        {
            var listaTenkova = UcitajPodatke();
            var tenkovi = listaTenkova.FirstOrDefault(t => t.Sifra == sifra);
            return tenkovi;
        }

        public List<string> UcitajProizvodjaca()
        {
            var listaTenkova = UcitajPodatke();
            var listaPro = new List<string>();
            listaPro.Add("");
            if (listaTenkova != null)
            {
                foreach (var tenk in listaTenkova)
                {
                    string proizvodjac = tenk.Proizvodjac;  
                    if (!listaPro.Contains(proizvodjac))
                    {
                        listaPro.Add(proizvodjac);
                    }
                    listaPro.Sort();
                }
            }
            return listaPro;
        }

        public List<string> UcitajGodine()
        {
            var listaTenkova = UcitajPodatke();
            var listaGod = new List<string>();
            listaGod.Add("");
            if (listaTenkova != null)
            {
                foreach (var tenk in listaTenkova)
                {
                    string godinaProizvodnje = tenk.GodinaProizvodnje;
                    if (!listaGod.Contains(godinaProizvodnje))
                    {
                        listaGod.Add(godinaProizvodnje);
                    }
                }
                listaGod.Sort();
            }
            return listaGod;
        }

    }
}