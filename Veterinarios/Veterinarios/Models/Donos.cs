using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinarios.Models
{
    public class Donos {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Mete um {0}")]
        [StringLength(40, ErrorMessage = "O {0} não pode ter mais de {1} caracteres")]
        public string nome { get; set; }

        [RegularExpression("[MF]", ErrorMessage = "Coloque M ou F")]
        public string sexo { get; set; }

        [Required(ErrorMessage = "Mete um {0}")]
        [StringLength(9, MinimumLength=9, ErrorMessage = "O {0} não pode ter mais de {2} caracteres")]
        [RegularExpression("[123567][0-9]{8}", ErrorMessage = "Deve escrever um numero que comece por 1,2,3,5,6,7, de seguida de 8 algarismos")]
        public string NIF { get; set; }

        public ICollection<Animais> listaAnimais { get; set; }

        public Donos(){
            this.listaAnimais = new HashSet<Animais>();
        }
    }
}
