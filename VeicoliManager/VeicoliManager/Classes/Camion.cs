using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeicoliManager.Classes
{
    internal class Camion : Veicolo
    {
        public double CapacitaCarico { get; set; }
    
        public Camion() { }
        public Camion(string? marca,string? modello, DateTime? annoImm,double capacitaCarico)
        {
            Marca = marca;
            Modello = modello;
            AnnoImmatricolazione = annoImm;
            CapacitaCarico = capacitaCarico;
        }


        public override void Descrizione()
        {
            Console.WriteLine($"[Camion] {Marca}, {Modello}, {AnnoImmatricolazione} capacità di carico: {CapacitaCarico}");
        }
        public override string ExportCsv()
        {
            return $"{Marca};{Modello};{AnnoImmatricolazione};{CapacitaCarico}";
        }
    }
}
