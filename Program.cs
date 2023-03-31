
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
            // Codice per la ricerca per ID
            break;

        case 3:
            // Codice per la ricerca per nome
            break;

        case 4:
            // Codice per la cancellazione
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
