// See https://aka.ms/new-console-template for more information


//step 1 Si vuole progettare un sistema per la gestione di una biblioteca dove il bibliotecario può verificare i dati dei clienti registrati

// generatore di clienti
//FARE DOPO LA CLASSE

//menu che permette di accedere ad un metodo che mostra i clienti della lavanderia in 3 modi lista completa e show del singolo utente


//controlla se l'utente del programma ha inserito un numero nel menu

//menu iniziale del programma


//classe lavanderia

using System.Diagnostics.CodeAnalysis;

class Biblioteca
{
    public List<Cliente> clienti = new List<Cliente>();
    public List<Libro> libriTotali = new List<Libro>();

    public Biblioteca()
    {

        //simulazione di clienti precedenti al applicazione
        for (int i = 0; i < 50; i++)
        {
            string cognome = "tizio" + i;
            string nome = "ciccio" + i;
            string email = "email" + i + "@finta.it";
            int rand = new Random().Next(100000000,999999999) ;
            int recapitoTelefonico = rand;

            Cliente cliente = new Cliente(cognome, nome, email, recapitoTelefonico);
            clienti.Add(cliente);
        }
        for (int i = 0; i < 100; i++)
        {
            string titolo = "libro" + i;
            int rand1 = new Random().Next(1991, 2022);
            int anno = rand1;
            string settore = "sconosciuto";
            string scaffale = "sconosciuto";
            string autore = "booo" + i;

            Libro libri = new Libro(titolo, anno, settore, scaffale, autore);
            libriTotali.Add(libri);

        }
    }
}

class Media
{
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public string Settore { get; set; }
    public string Scaffale { get; set; }

    public List<Stato> stato = new List<Stato>();
    public List<Cliente> prestiti = new List<Cliente>();
    public string Autore { get; set; }

    public Biblioteca biblioteca =  Biblioteca;

    public void modificaStato(string tipo, int durata, int indiceCliente, string data)
    {
        if(tipo == "prestito")
        {
            Stato status = new Stato( tipo,durata, indiceCliente,  data );
            stato.Add(status);
            prestiti.Add( Biblioteca.clienti[indiceCliente]);
        }
        else if(tipo == "rotto")
        {
            Stato status = new Stato(tipo,0,0,"");
            stato.Add(status);
        }
    }

}
class Stato
{
    public string Tipo { get; set; }
    public int Durata { get; set; }

    public int IndiceClienti { get; set; }
    public string Data { get; set; }
    public Stato(string tipo , int durata, int indiceCliente, string data )
    {
        Tipo = tipo;
        Durata = durata;
        Data = data;
        IndiceClienti = indiceCliente;

        

    }
}

class Libro : Media
{
    public Libro(string titolo, int anno, string settore, string scaffale, string autore)
    {
        Titolo = titolo;
        Anno = anno;
        Settore = settore;
        Scaffale = scaffale;
        Autore = autore;

        //simulazione prestiti 
        int rand2 = new Random().Next(0, 5);
        for (int i = 0; i < rand2; i++)
        {
            int durata = new Random().Next(0, 10);
            int indiceCliente = new Random().Next(0, 49);
            string tipo = "prestito";
            string data = "ignota";
            prestiti.Add(item: Biblioteca.clienti[indiceCliente]);
            modificaStato(tipo, durata, indiceCliente, data );
        }
    }
}

   



// titolo,
//anno,
//settore(storia, matematica, economia, …),
//stato(In Prestito, Disponibile),
//uno scaffale in cui è posizionato,
//un autore (Nome, Cognome).