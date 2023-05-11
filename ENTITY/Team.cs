using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ENTITY
{
    public class Team
    {

        
        public int Id { get; set; }
        public string Name { get; set; }
        public string City{ get; set; }
        public string Trainer { get; set; }

        public string Colors { get; set; }

        public List<Player> PlayersList { get; set; }


        public Team(string name, string city, string trainer, string colors)
        {
            Name = name;
            City = city;
            Trainer = trainer;
            Colors = colors;
            PlayersList = new List<Player>();
        }
        public override string ToString() {


            string str = "nome player: " + Name + ", " + " Citta': " + City + ", " + "Allenatore: " + Trainer + ", " + "Colori della squadra: " + Colors + ". " ;
            str += "\n";
           
            return str;

        }


        
    }
}
