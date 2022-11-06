// See https://aka.ms/new-console-template for more information


//step 1 Si vuole progettare un sistema per la gestione di una biblioteca dove il bibliotecario può verificare i dati dei clienti registrati

// generatore di clienti
//FARE DOPO LA CLASSE

//menu che permette di accedere ad un metodo che mostra i clienti della lavanderia in 3 modi lista completa e show del singolo utente


//controlla se l'utente del programma ha inserito un numero nel menu

//menu iniziale del programma


//classe lavanderia

class Media
{
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public string Settore { get; set; }
    public string Scaffale { get; set; }

    public string Stato { get; set; }
    public string Autore { get; set; }

    public void modificaStato(string tipo)
    {
        Stato = tipo;
    }

}
   



// titolo,
//anno,
//settore(storia, matematica, economia, …),
//stato(In Prestito, Disponibile),
//uno scaffale in cui è posizionato,
//un autore (Nome, Cognome).