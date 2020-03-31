using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinarios.Models{
    public class Animais{

        [Key]
        public int Id { get; set; }
        public string nome { get; set; }
        public string especie { get; set; }
        public double peso { get; set; }
        public string raca { get; set; }
        public string foto { get; set; }

        [ForeignKey(nameof(dono))]
        public int donoFK { get; set; }
        public Donos dono { get; set; }

    }
}
