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
    Console.WriteLine("Gestore Team e Giocatori");
    Console.WriteLine();
    Console.WriteLine("Seleziona un opzione: ");
    Console.WriteLine("1. Inserisci un team: ");
    Console.WriteLine("2. Inserisci un player:");

    Console.WriteLine("3. Ricerca un player per id:");
    Console.WriteLine("4. Modifica nome giocatore per id:");
    Console.WriteLine("5. Cancella un player:");
    Console.WriteLine("6. Esci");
    Console.WriteLine();

    Console.Write("Inserisci l'opzione desiderata: ");
    int response = int.Parse(Console.ReadLine());

    switch (response)
    {
        case 1:
            Console.Write("Inserisci il nome della squadra: ");
            string nameTesm = Console.ReadLine();

            Console.Write("Inserisci la citta' della squadra: ");
            string cityTeam= Console.ReadLine();

            Console.Write("Inserisci il nome del trainer: ");
            string nameTrainer = Console.ReadLine();

            Console.Write("Inserisci colori del team: ");
            string colorTeam = Console.ReadLine();

            Team Team1 = new Team(nameTesm, cityTeam, nameTrainer, colorTeam);
            using (PlayerContext db = new PlayerContext())
            {
                db.Add(Team1);
                db.SaveChanges();
                Console.WriteLine(Team1.ToString());
            }

            break;

        case 2:
            Console.Write("Inserisci il nome del giocatore: ");
            string namePlayer = Console.ReadLine();

            Console.Write("Inserisci il cognome del giocatore: ");
            string surnamePlayer = Console.ReadLine();

            Random rnd = new Random();
            int numScore = rnd.Next(1, 10);

            Random randnd = new Random();
            int numGamePlayed = randnd.Next(10, 100);


            int numGameWin = numGamePlayed -10;
            Console.WriteLine("inserisci l'id del team del giocatore");
            int inputIdGamer = int.Parse(Console.ReadLine());

            Player player1 = new Player(namePlayer, surnamePlayer, numScore, numGamePlayed, numGameWin, inputIdGamer );
            using (PlayerContext db = new PlayerContext())
            {
                db.Add(player1);
                db.SaveChanges();
                Console.WriteLine(player1.ToString());
            }
            break;
        case 3:

            Console.WriteLine("Inserisci l'id del giocatore da trovate : ");
            int idFoundPlayers = Convert.ToInt32(Console.ReadLine());


            try { 

            using (PlayerContext db = new PlayerContext())
            {
                Player playersFound = db.Player.Where(playerScansionato => playerScansionato.PlayerID == idFoundPlayers).First();
                Console.WriteLine(playersFound.ToString());
            }
            }catch (Exception ex) 
            { 
                Console.WriteLine( "l'id non combacia ");
            }

            break;

            case 4:
            Console.WriteLine("inserisci l'id del giocatore da modificare:");
            int idFoundPlayers2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("inserisci il nuovo nome:");
            string newName = Console.ReadLine();

            Console.WriteLine("inserisci il nuovo cognome:");
            string newSurname = Console.ReadLine();


            try { 
            using (PlayerContext db = new PlayerContext())
            {
                Player playersFound = db.Player.Where(playerScansionato => playerScansionato.PlayerID == idFoundPlayers2).First();
                Console.WriteLine("giocatore prima della modifica:  " + playersFound.ToString());

                playersFound.Name = newName;
                playersFound.Surname = newSurname;

                Console.WriteLine("giocatore dopo la modifica: " + playersFound.ToString());

                Console.WriteLine();

                db.SaveChanges();
            }
            }catch(Exception ex) { Console.WriteLine("spiacente l'id selezionato non combacia"); }

            break;

        case 5:

           

            Console.WriteLine("Inserisci il nome del giocatore da cancellare : ");
            string nameFoundPlayers = Console.ReadLine();


            try
            {

                using (PlayerContext db = new PlayerContext())
                {

                    Player playersFound = db.Player.Where(playerScansionato => playerScansionato.Name == nameFoundPlayers).First();



                    db.Remove(playersFound);

                    Console.WriteLine("il giocatore:  " + playersFound + "e' stato eliminato");
                    db.SaveChanges();


                }
            }catch (Exception ex)
            {
                Console.WriteLine("il nome selezionato non combacia ");
            }

            break;

        case 6:
            continua = false;
            Console.WriteLine("alla prossima arrivederci!");
            break;

        default:
            Console.WriteLine("Non hai inserito un'opzione valida! Ritenta!");
            break;
    }


   
}
