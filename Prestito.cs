﻿// See https://aka.ms/new-console-template for more information


//step 1 Si vuole progettare un sistema per la gestione di una biblioteca dove il bibliotecario può verificare i dati dei clienti registrati

// generatore di clienti
//FARE DOPO LA CLASSE

//menu che permette di accedere ad un metodo che mostra i clienti della lavanderia in 3 modi lista completa e show del singolo utente


//controlla se l'utente del programma ha inserito un numero nel menu

//menu iniziale del programma


//classe lavanderia

class Prestito
{
    public int Durata { get; set; }

    public Cliente Cliente { get; set; }

    public string Voce { get; set; }


    public string DataInizio { get; set; }

    public Prestito(Cliente cliente, string voce,  int durata ,string data, string dataInizio)
    {
        Voce = voce;
        Durata = durata;
        Cliente = cliente;
        DataInizio = dataInizio;
    }

}
   



// titolo,
//anno,
//settore(storia, matematica, economia, …),
//stato(In Prestito, Disponibile),
//uno scaffale in cui è posizionato,
//un autore (Nome, Cognome).