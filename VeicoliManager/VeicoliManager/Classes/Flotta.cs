using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeicoliManager.Classes
{
    internal class Flotta
    {
        private List<Veicolo>? flottaList;
        

        private void AddVeicolo(Veicolo v)
        {
            if (flottaList == null)
            {
                flottaList = new List<Veicolo>();
                flottaList.Add(v);
                Console.WriteLine("Veicolo aggiunto correttamente");
                ExportCsv();
            }
            else
            {
                flottaList.Add(v);
                Console.WriteLine("Veicolo aggiunto correttamente");
                ExportCsv();
            }


        }
        private void DeleteVeicolo(string? marca, string? modello, DateTime annoImmatricolazione) {
            if (flottaList != null)
            {
                Veicolo toFind = flottaList.Find(ve => ve.Marca == marca && ve.Modello == modello && ve.AnnoImmatricolazione == annoImmatricolazione);
                if (toFind != null)
                {
                    flottaList.Remove(toFind);
                    int n = flottaList.Count;
                    Console.WriteLine("Veicolo rimosso con successo");
                    if(n == 0)
                    {
                        flottaList = null;
                    }
                }
                else
                {
                    Console.WriteLine("Nessun veicolo corrispondente");
                }
            }
            else
            {
                Console.WriteLine("Nessun Veicolo presente");
            }
        }

        private void ShowVeicoloList()
        {
            if (flottaList != null)
            {
                foreach (Veicolo v in flottaList)
                {
                    if (v.GetType() == typeof(Auto))
                    {
                        Auto temp = (Auto)v;
                        v.Descrizione();
                    }
                    else if (v.GetType() == typeof(Moto))
                    {
                        Moto temp = (Moto)v;
                        v.Descrizione();
                    }
                    else if (v.GetType() == typeof(Camion))
                    {
                        Camion temp = (Camion)v;
                        v.Descrizione();
                    }
                }
            }
            else
            {
                Console.WriteLine("Nessun veicolo presente attualmente");
            }
        }
        private void ExportCsv()
        {
            string? path = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            string fileName = "\\SavedData\\flotta.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path + fileName))
                {
                    if (flottaList != null)
                    {
                        foreach (Veicolo v in flottaList)
                        {
                            if (v.GetType() == typeof(Auto))
                            {
                                Auto temp = (Auto)v;
                                sw.WriteLine(v.ExportCsv());
                            }
                            else if (v.GetType() == typeof(Moto))
                            {
                                Moto temp = (Moto)v;
                                sw.WriteLine(v.ExportCsv());
                            }
                            else if (v.GetType() == typeof(Camion))
                            {
                                Camion temp = (Camion)v;
                                sw.WriteLine(v.ExportCsv());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void Menu()
        {
            bool active = true;
            Console.WriteLine("=========================================");
            Console.WriteLine("Benvenuto nel sistema di gestione veicoli");
            while (active)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("-Premi 1 per vedere la flotta \n" +
                                  "-Premi 2 aggiungere un veicolo \n" +
                                  "-Premi 3 rimuovere un veicolo");
                string? inputChoice = Console.ReadLine();
                switch (inputChoice)
                {
                    case "1":
                        {
                            this.ShowVeicoloList();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Che tipo di veicolo vuoi registrare?");
                            Console.WriteLine("-1) Automobile \n" +
                                              "-2) Moto \n" +
                                              "-3) Camion");
                            string? typeChoice = Console.ReadLine();
                            if (typeChoice == "1")
                            {
                                Console.WriteLine("Registrazione Automobile!");
                                Console.WriteLine("Inserisci Marca");
                                string? marca = Console.ReadLine();
                                Console.WriteLine("Inserisci Modello");
                                string? modello = Console.ReadLine();
                                Console.WriteLine("Inserisci Anno di Immatricolazione");
                                string? annoImm = Console.ReadLine();
                                try
                                {
                                    DateTime convertedAnnoImm = Convert.ToDateTime(annoImm);
                                    Console.WriteLine("Inserisci numero di porte");
                                    string? numPorte = Console.ReadLine();
                                    int convertedNumPorte = Convert.ToInt32(numPorte);
                                    Veicolo v = new Auto(marca, modello, convertedAnnoImm, convertedNumPorte);
                                    this.AddVeicolo(v);

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }



                            }
                            else if (inputChoice == "2")
                            {
                                Console.WriteLine("Registrazione Moto!");
                                Console.WriteLine("Inserisci Marca");
                                string? marca = Console.ReadLine();
                                Console.WriteLine("Inserisci Modello");
                                string? modello = Console.ReadLine();
                                Console.WriteLine("Inserisci Anno di Immatricolazione");
                                string? annoImm = Console.ReadLine();
                                try
                                {
                                    DateTime convertedAnnoImm = Convert.ToDateTime(annoImm);
                                    Console.WriteLine("Inserisci Cilindrata");
                                    string? cilindrata = Console.ReadLine();
                                    double convertedCilindrata = Convert.ToDouble(cilindrata);
                                    Veicolo v = new Moto(marca, modello, convertedAnnoImm, convertedCilindrata);
                                    this.AddVeicolo(v);

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (inputChoice == "3")
                            {
                                Console.WriteLine("Registrazione Camion!");
                                Console.WriteLine("Inserisci Marca");
                                string? marca = Console.ReadLine();
                                Console.WriteLine("Inserisci Modello");
                                string? modello = Console.ReadLine();
                                Console.WriteLine("Inserisci Anno di Immatricolazione");
                                string? annoImm = Console.ReadLine();
                                try
                                {
                                    DateTime convertedAnnoImm = Convert.ToDateTime(annoImm);
                                    Console.WriteLine("Inserisci capacità di carico");
                                    string? capCarico = Console.ReadLine();
                                    double convertedCapcarico = Convert.ToDouble(capCarico);
                                    Veicolo v = new Camion(marca, modello, convertedAnnoImm, convertedCapcarico);
                                    this.AddVeicolo(v);

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Eliminazione Veicolo");
                            Console.WriteLine("Inserisci Marca");
                            string? marca = Console.ReadLine();
                            Console.WriteLine("Inserisci Modello");
                            string? modello = Console.ReadLine();
                            Console.WriteLine("Inserisci anno Immatricolazione");
                            string? annoImm = Console.ReadLine();
                            try
                            {
                                DateTime convertedAnnoImm = Convert.ToDateTime(annoImm);
                                
                                this.DeleteVeicolo(marca, modello, convertedAnnoImm);

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                }

            }

        }

    }
}
