using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facs.Models
{
    public class UtenteGuest
    {
        public int Piano { get; set; }
        public int Stanza { get; set; }
        public decimal Temperatura { get; set; }
        public bool StatoPorta { get; set; }
        public bool Occupato { get; set; }
    }
}
