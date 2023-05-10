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
        [MaxLength (50)]
        public int  GamesWon{ get; set; }
        [MaxLength(50)]
        public int  GamesPlayed { get; set; }
       


    }
}
