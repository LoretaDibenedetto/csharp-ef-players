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
    
    Console.WriteLine();

    Console.WriteLine("**======GESTORE TEAM E GIOCATORI======**");
    Console.WriteLine("= = = = = = = = = = = = = = = = =");
    Console.WriteLine();
    Console.WriteLine("Seleziona un opzione: ");
    Console.WriteLine("1. Inserisci un team: ");
    Console.WriteLine("2. Ricerca team per id: ");
    Console.WriteLine("3. Apporta delle modifiche al team: ");
    Console.WriteLine();

    Console.WriteLine("= = = = = = = = = = = = = = = = =");

    Console.WriteLine();

    Console.WriteLine("4. Inserisci un giocatore: ");

    Console.WriteLine("5. Ricerca un giocatore per id: ");
    Console.WriteLine("6. Modifica nome giocatore per id: ");
    Console.WriteLine("7. Cancella un giocatore scrivendo il suo nome: ");
    Console.WriteLine("8. Cerca giocatore per nome o cognome:");
    Console.WriteLine();

    Console.WriteLine("= = = = = = = = = = = = = = = = =");


    Console.WriteLine("9. Inserisci due squadre e scopri chi ha vinto!");
    Console.WriteLine("10. Stampa lista giocatori:");
    Console.WriteLine("11. Esci");
    Console.WriteLine();

    Console.Write("Inserisci l'opzione desiderata: ");
    try { 
    int response = int.Parse(Console.ReadLine());
   



    switch (response)
    {
        case 1:
                //l'utente puo' ancora mettere numeri dove non ci vanno

            Console.ForegroundColor = ConsoleColor.White;


            Console.Write("Inserisci il nome della squadra: ");
            string nameTesm = Console.ReadLine();
                if (string.IsNullOrEmpty(nameTesm))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Il nuovo nome della squadra non può essere un campo vuoto.");
                    break;
                }


            Console.Write("Inserisci la citta' della squadra: ");
            string cityTeam = Console.ReadLine();

                if (string.IsNullOrEmpty(cityTeam))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("la citta' della squadra non puo' essere un campo vuoto.");
                    break;
                }

            Console.Write("Inserisci il nome del trainer: ");
            string nameTrainer = Console.ReadLine();

               if(string.IsNullOrEmpty(nameTrainer))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("il nome dell' allenatore non puo' essere un campo vuoto.");
                    break;
                }


            Console.Write("Inserisci colori del team: ");
            string colorTeam = Console.ReadLine();
                if (string.IsNullOrEmpty(colorTeam))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("i colori della squadra non possono essere un campo vuoto");
                    break;
                }

            Team Team1 = new Team(nameTesm, cityTeam, nameTrainer, colorTeam);
            using (PlayerContext db = new PlayerContext())
            {
                db.Add(Team1);
                db.SaveChanges();
                Console.WriteLine(Team1.ToString());
            }

            break;

        case 2:

            Console.ForegroundColor = ConsoleColor.White;
            try
            {


            Console.Write("Inserisci l'id del team da trovate : ");
            int idFoundTeam = int.Parse(Console.ReadLine());



                using (PlayerContext db = new PlayerContext())
                {
                    Team team3 = db.Teamer.Where(teamScansionato => teamScansionato.Id == idFoundTeam).First();
                    Console.WriteLine(team3.ToString());
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("L'id non combacia con quello selezionato o e' vuoto");
            }

            break;

        case 3:
             try { 

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Inserisci l'id del team da modificare: ");
            int idFoundTeam2 = int.Parse(Console.ReadLine());
            

            Console.Write("Inserisci il nuovo nome del team: ");
            string newNameTeam = Console.ReadLine();

              if (string.IsNullOrEmpty(newNameTeam))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Il nuovo nome della squadra non può essere vuoto.");
                    break;
                }

            Console.Write("Inserisci il nuovo allenatore team: ");
            string newTrainerTeam = Console.ReadLine();

                if (string.IsNullOrEmpty(newTrainerTeam))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Il nuovo nome dell' allenatore della squadra non può essere vuoto.");
                    break;
                }


            Console.Write("Inserisci il nuovo colore del team: ");
            string newColorTeam = Console.ReadLine();

                if (string.IsNullOrEmpty(newNameTeam))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Il nuovo colore della squadra non può essere vuoto.");
                    break;
                }

                using (PlayerContext db = new PlayerContext())
                { Team teamFound = db.Teamer.Where(teamScansionato => teamScansionato.Id == idFoundTeam2).First();
                Console.WriteLine("-Team prima della modifica" + teamFound.ToString());

                teamFound.Name = newNameTeam;
                teamFound.Trainer = newTrainerTeam;
                teamFound.Colors = newColorTeam;


                db.SaveChanges();
                Console.WriteLine("-Team dopo la modifica " + teamFound.ToString());


                 }
                }catch(FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }



            break;

        case 4:

                try { 
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Inserisci il nome del giocatore: ");
            string namePlayer = Console.ReadLine();

             if (string.IsNullOrEmpty(namePlayer))
                 {
                  Console.ForegroundColor = ConsoleColor.Red;
                  Console.WriteLine("Il nome del giocatore non può essere vuoto, riprova...");
                   break; 
                 }

            Console.Write("Inserisci il cognome del giocatore: ");
            string surnamePlayer = Console.ReadLine();

              if (string.IsNullOrEmpty(surnamePlayer))
                  {
                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine("Il cognome del giocatore non può essere vuoto, riprova...");
                    break;
                  }

            Random rnd = new Random();
            int numScore = rnd.Next(1, 10);

            Random randnd = new Random();
            int numGamePlayed = randnd.Next(10, 100);


            int numGameWin = numGamePlayed - 10;
            Console.Write("Inserisci l'id del team del giocatore: ");
            int inputIdGamer = int.Parse(Console.ReadLine());

            Player player1 = new Player(namePlayer, surnamePlayer, numScore, numGamePlayed, numGameWin, inputIdGamer);
                 
            using (PlayerContext db = new PlayerContext())
            {
               
                db.Add(player1);
                db.SaveChanges();
                Console.WriteLine(player1.ToString());
            }

                }catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;   
                    Console.WriteLine("digita il carattere corretto!");
                }
               
            break;

        case 5:

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Inserisci l'id del giocatore da trovate: ");
            int idFoundPlayer = int.Parse(Console.ReadLine());


            try {

                using (PlayerContext db = new PlayerContext())
                {

                    Player playersFound = db.Player.Where(playerScansionato => playerScansionato.PlayerID == idFoundPlayer).First();
                    Console.WriteLine(playersFound.ToString());
                }
            } catch (Exception ex)
            {  
                  
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine( "L'id non combacia ");
            }

            break;

        case 6:
         try {

            Console.ForegroundColor = ConsoleColor.White;


            Console.Write("Inserisci l'id del giocatore da modificare:");
            int idFoundPlayers2 = int.Parse(Console.ReadLine());
            
            Console.Write("Inserisci il nuovo nome:");
            string newName = Console.ReadLine();
             if (string.IsNullOrEmpty(newName))
                {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("il campo non puo' essere vuoto");
                        break;
                }

            Console.Write("Inserisci il nuovo cognome:");
            string newSurname = Console.ReadLine();
                    if (string.IsNullOrEmpty(newSurname))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("il campo non puo' essere vuoto");
                        break;
                    }

           
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
            } catch (Exception )
            { 
                Console.WriteLine("Spiacente l'id selezionato non combacia"); 
            }

            break;

        case 7:

            Console.ForegroundColor = ConsoleColor.White;


            try
            {
            Console.WriteLine("Inserisci il nome del giocatore da cancellare: ");
            string nameFoundPlayers = Console.ReadLine(); //se inserisci un campo vuoto comunque non lo trova comunque nel database
            


                using (PlayerContext db = new PlayerContext())
                {

                    Player playersFound = db.Player.Where(playerScansionato => playerScansionato.Name == nameFoundPlayers).First();



                    db.Remove(playersFound);

                    Console.WriteLine("Il giocatore:  " + playersFound + "e' stato eliminato");
                    db.SaveChanges();


                }
            } catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Il nome selezionato non combacia ");
            }

            break;

        case 8:
           
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("vuoi cercare il giocatore attraverso il suo nome(N) o cognome(C)");
            string UserChoice = Console.ReadLine();
            if(UserChoice.ToUpper() == "N" )
            {
                try { 
                    Console.WriteLine("Inserisci il nome del giocatore che vuoi cercare:");
                    string namePlayerSearch = Console.ReadLine();
                     if(string.IsNullOrEmpty(namePlayerSearch))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("il campo non puo' essere vuoto");
                            break;

                        }
                        using (PlayerContext db = new PlayerContext())
                    {
                        Player playerNameFound = db.Player.Where(player => player.Name == namePlayerSearch).First();

                        Console.WriteLine(playerNameFound.ToString());

                       

                    }
                    }catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("questo giocatore non e' ancora stato implementato nel nostro database!");
                }
               
            }else if(UserChoice.ToUpper() == "C") 
            {
                try
                {
                    Console.WriteLine("Inserisci il cognome del giocatore che vuoi cercare:");
                    string surnamePlayerSearch = Console.ReadLine();
                    if(string.IsNullOrEmpty (surnamePlayerSearch))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("il campo non puo' essere vuoto");
                            break;

                        }
                        using (PlayerContext db = new PlayerContext())
                    {
                        Player playerNameFound = db.Player.Where(player => player.Surname == surnamePlayerSearch).First();

                        Console.WriteLine(playerNameFound.ToString());

                       

                    }
                }
                catch {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("questo giocatore non e' ancora stato implementato nel nostro database!");
                }


            }else if(string.IsNullOrEmpty(UserChoice) ) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("il campo non puo' essere vuoto");
                    break;
                
                }


            break;
        case 9:

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("inserisci il nome della prima squadra:");
                string nameUserTeam = Console.ReadLine();
                if (string.IsNullOrEmpty(nameUserTeam))
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("il campo non puo' essere vuoto");
                }

                Console.WriteLine("inserisci il nome della seconda squadra:");
                string nameUserTeam2 = Console.ReadLine();
                if (string.IsNullOrEmpty(nameUserTeam2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("il campo non puo' essere vuoto");
                }

                Random randomGAmeNumber = new Random();

                int numGameRandom = randomGAmeNumber.Next(1, 20);
                try
                {
                    using (PlayerContext db = new PlayerContext())
                    {
                        Team teamName1 = db.Teamer.Where(Team => Team.Name == nameUserTeam).First();
                        Team teamName2 = db.Teamer.Where(Team => Team.Name == nameUserTeam2).First();

                        if (numGameRandom <= 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine(teamName1.Name + " ha vinto contro " + teamName2.Name + " " + teamName1.Trainer + "  e' felice!");
                        }
                        else if (numGameRandom >= 12)
                        {
                            Console.WriteLine(teamName1.Name + " ha pareggiato contro " + teamName2.Name);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine(teamName2.Name + " ha perso contro " + teamName1.Name + " " + teamName2.Trainer + " e' scontento!");

                        }



                    }

                }
                catch (Exception ex) { Console.WriteLine("inserisci un nome valido!"); }

                break;

            case 10:

                Console.ForegroundColor = ConsoleColor.White;
                using(PlayerContext db = new PlayerContext())
                {

                        List<Player> playersList = db.Player.FromSqlRaw("SELECT * FROM Player").ToList<Player>();
                    // playersList.ForEach(student => Console.WriteLine(student.ToString()));
                    Player.stampList(playersList);
                }

            break;

       case 11:

         

                Console.ForegroundColor = ConsoleColor.Green;

                continua = false;
                Console.WriteLine("Alla prossima arrivederci!");
                break;



            default:
                Console.WriteLine("Riprova!");
                break;
    }

    }catch (Exception ex) 
    { 
        Console.WriteLine("Digita il carattere corretto!, Riprova");
    }


}
