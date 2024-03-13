using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeicoliManager.Classes
{
    internal class Flotta
    {
        List<Veicolo>? flottaList;

        public void AddVeicolo(Veicolo v)
        {
            if (flottaList == null)
            {
                flottaList = new List<Veicolo>();
                flottaList.Add(v);
            }
            else
            {
                flottaList.Add(v);
            }
            ExportCsv();
        }
        public void ShowVeicoloList()
        {
            if (flottaList == null)
            {
                foreach (Veicolo v in flottaList)
                {
                    if (v.GetType() == typeof(Auto))
                    {
                        Auto temp = (Auto)v;
                        v.Descrizione();
                    }else if (v.GetType() == typeof(Moto))
                    {
                        Moto temp = (Moto)v;
                        v.Descrizione();
                    }else if (v.GetType() == typeof(Camion))
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
                using (StreamWriter sw = new StreamWriter(path+fileName))
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
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
