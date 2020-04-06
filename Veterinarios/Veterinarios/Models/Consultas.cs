using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinarios.Models
{
    public class Consultas{
        
        [Key]
        public int ID { get; set; }
        public DateTime data { get; set; }
        public string Obs { get; set; }

        [ForeignKey(nameof(vet))]
        public Veter vetFK { get; set; }
        public int vet { get; set; }


        [ForeignKey(nameof(animal))]
        public Animais animalFK { get; set; }
        public int animal { get; set; }

    }
}
