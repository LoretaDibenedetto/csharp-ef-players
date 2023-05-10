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
       

        public Player( string name, string surname, int score, int gamesPlayed)
        {
            
            Name = name;
            Surname = surname;
            Score = score;
            gamesPlayed = gamesPlayed;
          
        }
    }
}
