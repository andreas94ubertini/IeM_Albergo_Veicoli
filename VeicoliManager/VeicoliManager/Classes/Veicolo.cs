using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeicoliManager.Classes
{
    internal abstract class Veicolo
    {
        public string? Marca { get; set; }
        public string? Modello { get; set; }
        public DateTime? AnnoImmatricolazione { get; set; }

        public Veicolo() { }
        public abstract void Descrizione();
        public abstract string ExportCsv();
    }
}
