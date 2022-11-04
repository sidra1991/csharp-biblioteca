// See https://aka.ms/new-console-template for more information


//step 1 Si vuole progettare un sistema per la gestione di una biblioteca dove il bibliotecario può verificare i dati dei clienti registrati

// generatore di clienti
//FARE DOPO LA CLASSE

//menu che permette di accedere ad un metodo che mostra i clienti della lavanderia in 3 modi lista completa e show del singolo utente


//controlla se l'utente del programma ha inserito un numero nel menu

//menu iniziale del programma


//classe lavanderia

using System.Net.Security;

class Cliente
{

    public string Cognome { get;private set; }
    public string Nome { get;private set; }    
    public int RecapitoTelefonico { get;private set; }
    public string Email { get;private set; }
    public Cliente( string cognome, string nome, string email, int recapitoTelefonico)
    {
        Cognome = cognome;
        Nome = nome;
        Email = email;
        RecapitoTelefonico = recapitoTelefonico;
    }
}

//classe clienti con specifiche
//cognome,
//nome,
//email,
//recapito telefonico