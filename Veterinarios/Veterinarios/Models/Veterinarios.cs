using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinarios.Models
{
    public class Veterinarios{

        public int ID { get; set;}
        public string nome { get; set;}
        public string nCelula { get; set;}
        public string foto { get; set;}

        public ICollection<Consultas> listaConsultas { get; set; }


        public Veterinarios(){
            listaConsultas = new HashSet<Consultas>();
        }
    }
}
