using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;


bool continua = true;

while (continua)
{
    Console.WriteLine("players selection");
    Console.WriteLine();
    Console.WriteLine("Seleziona un opzione: ");
    Console.WriteLine("1. Inserisci un player");

    Console.WriteLine("2. Ricerca un player per id");

    Console.WriteLine("5. Cancella un player");
    Console.WriteLine("6. Esci");

    Console.Write("Inserisci l'opzione desiderata: ");
    int response = int.Parse(Console.ReadLine());

    switch (response)
    {
        case 1:
            Console.Write("Inserisci il nome del giocatore: ");
            string namePlayer = Console.ReadLine();

            Console.Write("Inserisci il cognome del giocatore: ");
            string surnamePlayer = Console.ReadLine();

            Random rnd = new Random();
            int numScore = rnd.Next(1, 10);

            Random randnd = new Random();
            int numGamePlayed = randnd.Next(10, 100);


            int numGameWin = numGamePlayed -10;


            Player player1 = new Player(namePlayer, surnamePlayer, numScore, numGamePlayed, numGameWin);
            using (PlayerContext db = new PlayerContext())
            {
                db.Add(player1);
                db.SaveChanges();
            }
            break;
        case 2:

            Console.WriteLine("Inserisci l'id del giocatore da trovate : ");
            int idFoundPlayers = Convert.ToInt32(Console.ReadLine());




            using (PlayerContext db = new PlayerContext())
            {
                Player playersFound = db.Player.Where(playerScansionato => playerScansionato.PlayerID == idFoundPlayers).First();
                Console.WriteLine(playersFound.ToString());
            }







            break;

        case 5:
            continua = false;
            break;
    }


    //mi ha obbligata ad aggiungerla :(
    static void main(string[] args)
{

  
    }
}
