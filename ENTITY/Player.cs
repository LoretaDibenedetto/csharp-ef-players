using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Player
    {

        [Key]
        public int PlayerID { get; set; }


        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength (30)]
        public int Score { get; set; } 
       
        public int  GamesWon{ get; set; }
        
        public int  GamesPlayed { get; set; }
       

        public Player( string name, string surname, int score, int gamesPlayed,int gamesWon)
        {
            
            Name = name;
            Surname = surname;
            Score = score;
            GamesPlayed = gamesPlayed;
            GamesWon = gamesWon;

          
        }


        public override string ToString()
        { 
            string str = "nome player: " + Name + ", " + " cognome player: " + Surname + ", " + "Punteggio: " + Score + ", " + "partite vinte: " + GamesWon + ", " + "partite giocate: " + GamesPlayed + ". ";
            str += "                  ";

            return str;
        }




    }
}
