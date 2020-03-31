using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinarios.Models
{
    public class Donos{

        public int ID { get; set; }
        public string nome { get; set; }
        public string NIF { get; set; }

        public ICollection<Animais> listaAnimais { get; set; }

        public Donos(){
            this.listaAnimais = new HashSet<Animais>();
        }
    }
}
