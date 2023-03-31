
        
{
   /* try
    { */
      


        while (true)
        {
            Console.WriteLine("Seleziona un'opzione:");
            Console.WriteLine("1 - Inserisci un nuovo videogame");
            Console.WriteLine("2 - Ricerca un videogame per ID");
            Console.WriteLine("3 - Ricerca videogiochi per nome");
            Console.WriteLine("4 - Cancella un videogame");
            Console.WriteLine("5 - Esci");

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
                    int softwareHouseId = int.Parse(Console.ReadLine());

                    break;

                case 2:

                

                    break;

                case 3:
             
                    break;

                case 4:
                
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        }
  /*  }
    catch ( )
    {
        Console.WriteLine($"Errore di connessione al database: \n ");

    } */
}