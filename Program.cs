
using net_ef_videogame;


while (true)
{
    Console.WriteLine("Seleziona un'opzione:");
    Console.WriteLine("1 - Inserisci un nuovo videogame");
    Console.WriteLine("2 - Ricerca un videogame per ID");
    Console.WriteLine("3 - Ricerca videogiochi per nome");
    Console.WriteLine("4 - Cancella un videogame");
    Console.WriteLine("5 - Inserisci una nuova software house");
    Console.WriteLine("6 - Esci");

    var scelta = Convert.ToInt32(Console.ReadLine());

    switch (scelta)
    {
        case 1:
            Console.WriteLine("Inserisci il nome del gioco:");
            string nomeGioco = Console.ReadLine();

            Console.WriteLine("Inserisci la descrizione del gioco:");
            string descrizioneGioco = Console.ReadLine();

            Console.WriteLine("Inserisci la data di rilascio del gioco (anno-mese-giorno):");
            DateTime dataRilascio = DateTime.Parse(Console.ReadLine());

            DateTime dataCorrente = DateTime.Now;

            Console.WriteLine("Inserisci l'ID della software house:");
            long softwareHouseId = long.Parse(Console.ReadLine());

            using (VideogamesContext db = new VideogamesContext())
            {
                // Create
                Videogame nuovoVideogame = new Videogame(nomeGioco, descrizioneGioco, dataRilascio, dataCorrente, dataCorrente, softwareHouseId);
                db.Add(nuovoVideogame);
                db.SaveChanges();
                Console.WriteLine($"Hai inserito {nomeGioco} nel database.");
               
            }
            break;


        case 2:
            
            Console.WriteLine("Inserisci l'ID del gioco che cerchi:");
            long idGioco = Convert.ToInt64(Console.ReadLine());

            using (VideogamesContext db = new VideogamesContext())
            {
                // Read
                Videogame videogame = db.Videogames.FirstOrDefault(videogame => videogame.Id == idGioco);

                if (videogame != null)
                {
                    Console.WriteLine($"Nome: {videogame.Name}");
                    Console.WriteLine($"Descrizione: {videogame.Overview}");
                    Console.WriteLine($"Data di rilascio: {videogame.ReleaseDate}");
                    Console.WriteLine($"ID della software house: {videogame.SoftwareHouseId}");
                }
                else
                {
                    Console.WriteLine($"Nessun videogame trovato con ID {idGioco}");
                }
            }


            break;

        case 3:
            {
                Console.WriteLine("Inserisci il nome del gioco che cerchi:");
                string nomeGiocoRicerca = Console.ReadLine();

                using (VideogamesContext db = new VideogamesContext())
                {
                    // Read
                    List<Videogame> videogames = db.Videogames.OrderBy(videogame => videogame.Name).ToList<Videogame>();
                
                    foreach(var Videogame in videogames) { 

                        if (videogames != null)
                        {
                            Console.WriteLine($"ID gioco: {Videogame.Id}");
                            Console.WriteLine($"Nome: {Videogame.Name}");
                            Console.WriteLine($"Descrizione: {Videogame.Overview}");
                            Console.WriteLine($"Data di rilascio: {Videogame.ReleaseDate}");
                            Console.WriteLine($"ID della software house: {Videogame.SoftwareHouseId}");
                            Console.WriteLine(System.Environment.NewLine);
                        }
                        else
                        {
                            Console.WriteLine($"Nessun videogame trovato");
                        }
                    }
                }
            }
            break;

        case 4:
            Console.WriteLine("Inserisci l'ID del gioco che intendi eliminare:");
            long idGiocoDaEliminare = Convert.ToInt64(Console.ReadLine());

            using (VideogamesContext db = new VideogamesContext())
            {
                // Read
                Videogame videogame = db.Videogames.FirstOrDefault(videogame => videogame.Id == idGiocoDaEliminare);

                if (videogame != null)
                {
                    Console.WriteLine($"Nome: {videogame.Name}");
                    Console.WriteLine($"Descrizione: {videogame.Overview}");
                    Console.WriteLine($"Data di rilascio: {videogame.ReleaseDate}");
                    Console.WriteLine($"ID della software house: {videogame.SoftwareHouseId}");
                    Console.WriteLine(System.Environment.NewLine);

                    Console.WriteLine($"Sei sicuro di voler eliminare {videogame.Name}? (Si/No)");

                    var SioNo = Console.ReadLine();

                    switch (SioNo)
                    {
                     case "Si" :

                            db.Remove(videogame);
                            db.SaveChanges();


                            Console.WriteLine(System.Environment.NewLine);
                            Console.WriteLine($"Hai cancellato {videogame.Name}");
                            Console.WriteLine(System.Environment.NewLine);
                            break;

                     case "No":

                            break;
                    }
                   
                }
                else
                {
                    Console.WriteLine($"Nessun videogame trovato con ID {idGiocoDaEliminare}");
                }
            }
            break;

        case 5:

            using (VideogamesContext db = new VideogamesContext())
            {
                Console.WriteLine("Inserisci il nome della software house:");
                string nomeSoftwareHouse = Console.ReadLine();

                SoftwareHouse nuovaSoftwareHouse = new SoftwareHouse { Name = nomeSoftwareHouse };
                db.SoftwareHouses.Add(nuovaSoftwareHouse);
                db.SaveChanges();
                Console.WriteLine($"Hai inserito {nomeSoftwareHouse} nel database.");
            }

            break;

        case 6:
            return;

        default:
            Console.WriteLine("Scelta non valida");
            break;
    }
}
