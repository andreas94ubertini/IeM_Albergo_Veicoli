using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeicoliManager.Classes
{
    internal class Moto : Veicolo
    {
        public double Cilindrata { get; set; }
        public Moto() { }
        public Moto(string? marca, string? modello, DateTime? annoImm, double cilindrata) {
            Marca = marca;
            Modello = modello;
            AnnoImmatricolazione = annoImm;
            Cilindrata = cilindrata;
        }
        public override void Descrizione()
        {
            Console.WriteLine($"[MOTO] {Marca}, {Modello}, {AnnoImmatricolazione} cilindrata: {Cilindrata}");
        }
        public override string ExportCsv()
        {
            return $"{Marca};{Modello};{AnnoImmatricolazione};{Cilindrata}";
        }
    }
}
