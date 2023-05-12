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

        
        public int PlayerID { get; set; }


        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }

        [Range(1,10)]
        public int Score { get; set; }
        [Range(10,100)]
        public int  GamesWon{ get; set; }
        [Range(10,100)]
        public int  GamesPlayed { get; set; }


        public int TeamId { get; set; }
        public Team Team { get; set; }

        public Player( string name, string surname, int score, int gamesPlayed,int gamesWon, int teamId)
        {
            
            Name = name;
            Surname = surname;
            Score = score;
            GamesPlayed = gamesPlayed;
            GamesWon = gamesWon;
            TeamId = teamId;

        }


        public override string ToString()
        { 
            string str = "nome player: " + Name + ", " + " cognome player: " + Surname + ", " + "Punteggio: " + Score + ", " + "partite vinte: " + GamesWon + ", " + "partite giocate: " + GamesPlayed + ". ";
            str += "                  ";

            return str;
        }




    }
}
