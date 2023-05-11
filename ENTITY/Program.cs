using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.ComponentModel;

bool continua = true;

while (continua)
{
    
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("**======GESTORE TEAM E GIOCATORI======**");
    Console.WriteLine("= = = = = = = = = = = = = = = = =");
    Console.WriteLine("Seleziona un opzione: ");
    Console.WriteLine("1. Inserisci un team: ");
    Console.WriteLine("2. Ricerca team per id: ");
    Console.WriteLine("3. Apporta delle modifiche al team: ");
    Console.WriteLine("= = = = = = = = = = = = = = = = =");


    Console.WriteLine("4. Inserisci un giocatore: ");

    Console.WriteLine("5. Ricerca un giocatore per id: ");
    Console.WriteLine("6. Modifica nome giocatore per id: ");
    Console.WriteLine("7. Cancella un giocatore scrivendo il suo nome: ");
    Console.WriteLine("= = = = = = = = = = = = = = = = =");


    Console.WriteLine("8. Esci");
    Console.WriteLine();

    Console.Write("Inserisci l'opzione desiderata: ");
    int response = int.Parse(Console.ReadLine());

    switch (response)
    {
        case 1:
            Console.ForegroundColor = ConsoleColor.Green;

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
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("Inserisci l'id del team da trovate : ");
            int idFoundTeam = Convert.ToInt32(Console.ReadLine());


            try
            {

                using (PlayerContext db = new PlayerContext())
                {
                    Team team3 = db.Teamer.Where(teamScansionato => teamScansionato.Id == idFoundTeam).First();
                    Console.WriteLine(team3.ToString());
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("L'id non combacia con quello selezionato");
            }

            break;
        case 3:
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write("Inserisci l'id del team da modificare: ");
            int idFoundTeam2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Inserisci il nuovo nome del team: ");
            string newNameTeam = Console.ReadLine();

            Console.Write("Inserisci il nuovo allenatore team: ");
            string newTrainerTeam = Console.ReadLine();

            Console.Write("Inserisci il nuovo colore del team: ");
            string newColorTeam = Console.ReadLine();

            using (PlayerContext db = new PlayerContext())
            { Team teamFound = db.Teamer.Where(teamScansionato => teamScansionato.Id == idFoundTeam2).First(); 
              Console.WriteLine("-Team prima della modifica"+ teamFound.ToString());

                teamFound.Name = newNameTeam;
                teamFound.Trainer = newTrainerTeam;
                teamFound.Colors = newColorTeam;


                db.SaveChanges();
                Console.WriteLine("-Team dopo la modifica "+ teamFound.ToString());


            }



                break;
        case 4:
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Inserisci il nome del giocatore: ");
            string namePlayer = Console.ReadLine();

            Console.Write("Inserisci il cognome del giocatore: ");
            string surnamePlayer = Console.ReadLine();

            Random rnd = new Random();
            int numScore = rnd.Next(1, 10);

            Random randnd = new Random();
            int numGamePlayed = randnd.Next(10, 100);


            int numGameWin = numGamePlayed -10;
            Console.Write("Inserisci l'id del team del giocatore");
            int inputIdGamer = int.Parse(Console.ReadLine());

            Player player1 = new Player(namePlayer, surnamePlayer, numScore, numGamePlayed, numGameWin, inputIdGamer );
            using (PlayerContext db = new PlayerContext())
            {
                db.Add(player1);
                db.SaveChanges();
                Console.WriteLine(player1.ToString());
            }
            break;
        case 5:
             Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.Write("Inserisci l'id del giocatore da trovate: ");
            int idFoundPlayer = Convert.ToInt32(Console.ReadLine());


            try { 

            using (PlayerContext db = new PlayerContext())
            {
            
                Player playersFound = db.Player.Where(playerScansionato => playerScansionato.PlayerID == idFoundPlayer).First();
                Console.WriteLine(playersFound.ToString());
            }
            }catch (Exception ex) 
            { 
                Console.WriteLine( "L'id non combacia ");
            }

            break;
            
            case 6:
            Console.ForegroundColor = ConsoleColor.Yellow;


            Console.Write("Inserisci l'id del giocatore da modificare:");
            int idFoundPlayers2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Inserisci il nuovo nome:");
            string newName = Console.ReadLine();

            Console.Write("Inserisci il nuovo cognome:");
            string newSurname = Console.ReadLine();


            try { 
            using (PlayerContext db = new PlayerContext())
            {
                Player playersFound = db.Player.Where(playerScansionato => playerScansionato.PlayerID == idFoundPlayers2).First();
                Console.WriteLine("-Giocatore prima della modifica:  " + playersFound.ToString());

                playersFound.Name = newName;
                playersFound.Surname = newSurname;

                Console.WriteLine("-Giocatore dopo la modifica: " + playersFound.ToString());

                Console.WriteLine();

                db.SaveChanges();
            }
            }catch(Exception ex) { Console.WriteLine("Spiacente l'id selezionato non combacia"); }

            break;
           
        case 7:

            Console.ForegroundColor = ConsoleColor.Gray;


            Console.WriteLine("Inserisci il nome del giocatore da cancellare: ");
            string nameFoundPlayers = Console.ReadLine();


            try
            {

                using (PlayerContext db = new PlayerContext())
                {

                    Player playersFound = db.Player.Where(playerScansionato => playerScansionato.Name == nameFoundPlayers).First();



                    db.Remove(playersFound);

                    Console.WriteLine("Il giocatore:  " + playersFound + "e' stato eliminato");
                    db.SaveChanges();


                }
            }catch (Exception ex)
            {
                Console.WriteLine("Il nome selezionato non combacia ");
            }

            break;

        case 8:
            Console.ForegroundColor = ConsoleColor.Red;

            continua = false;
            Console.WriteLine("Alla prossima arrivederci!");
            break;

        default:
            Console.WriteLine("Non hai inserito un'opzione valida! Ritenta!");
            break;
    }


   
}
