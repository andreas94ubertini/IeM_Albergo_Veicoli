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

        public void AddVeicolo(Veicolo v)
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
        public void ShowVeicoloList()
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
        public void ExportCsv()
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
                                  "-Premi 2 rimuovere un veicolo");
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
                }

            }

        }

    }
}
