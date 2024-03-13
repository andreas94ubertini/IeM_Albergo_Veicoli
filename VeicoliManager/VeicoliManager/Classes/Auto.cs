using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeicoliManager.Classes
{
    internal class Auto : Veicolo
    {
        public int NumeroPorte { get; set; }
        public Auto() { }
        public Auto(string? marca, string? modello, DateTime? annoImm, int numeroPorte)
        {
            Marca = marca;
            Modello = modello;
            AnnoImmatricolazione = annoImm;
            NumeroPorte = numeroPorte;
        }
        public override void Descrizione()
        {
            Console.WriteLine($"[AUTO] {Marca}, {Modello}, {AnnoImmatricolazione} numero porte: {NumeroPorte}");
        }

        public override string ExportCsv()
        {
            return $"{Marca};{Modello};{AnnoImmatricolazione};{NumeroPorte}";
        }
    }
}
