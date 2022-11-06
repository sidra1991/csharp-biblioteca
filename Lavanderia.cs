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
    public List<Prestito> prestiti = new List<Prestito>();
    public List<Libro> libriDisponibili = new List<Libro>();
    public List<Dvd> dvdTotali = new List<Dvd>();
    public List<Dvd> dvdDisponibili = new List<Dvd>();
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

        //creazione Libri
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
            libriDisponibili.Add(libri);
        }

        //creazione Dvd
        for (int i = 0; i < 100; i++)
        {
            string titolo = "DVD" + i;
            int rand1 = new Random().Next(1991, 2022);
            int anno = rand1;
            string settore = "sconosciuto";
            string scaffale = "sconosciuto";
            string autore = "booo" + i;

            Dvd dvd = new Dvd(titolo, anno, settore, scaffale, autore);
            dvdTotali.Add(dvd);
            dvdDisponibili.Add(dvd);
        }
        //simulazione prestiti libri
        for (int j = 0; j < clienti.Count; j++)
        {

            int rand2 = new Random().Next(0, 5);
            if (rand2 > 0 && libriDisponibili.Count > 5)
            {
                Cliente cliente = clienti[j];
                int durata = new Random().Next(0, 10);
                int rand = new Random().Next(0, libriDisponibili.Count);
                Libro media = libriTotali[rand];
                string dataInizio = "ignota";
                string data = "ignota";
                libriDisponibili.Remove(libriDisponibili[rand]);
                string tipo = "prestito";
                libriTotali[rand].modificaStato(tipo);
                string voce = "libro " + media.Titolo;

                Prestito prestato = new Prestito(cliente, voce, durata, data, dataInizio);
                prestiti.Add(prestato);
            }
        }

        //simulazione prestiti DVD
        for (int j = 0; j < clienti.Count; j++)
        {

            int rand2 = new Random().Next(0, 5);
            if (rand2 > 0 && dvdDisponibili.Count > 5)
            {
                Cliente cliente = clienti[j];
                int durata = new Random().Next(0, 10);
                int rand = new Random().Next(0, libriDisponibili.Count);
                Dvd media = dvdTotali[rand];
                string dataInizio = "ignota";
                string data = "ignota";
                dvdDisponibili.Remove(dvdDisponibili[rand]);
                string tipo = "prestito";
                dvdTotali[rand].modificaStato(tipo);

                string voce ="DVD " + media.Titolo; 

                Prestito prestato = new Prestito(cliente, voce, durata, data, dataInizio);
                prestiti.Add(prestato);
            }
        }
    }
    public void nuovoPrestito(Cliente cliente, string voce, int durata, string data, string dataInizio,int libroIndiceDisponibili)
    {


        Prestito prestato = new Prestito(cliente, voce, durata, data, dataInizio);
        prestiti.Add(prestato);
        libriDisponibili.Remove(libriDisponibili[libroIndiceDisponibili]);
    }
}
   



// titolo,
//anno,
//settore(storia, matematica, economia, …),
//stato(In Prestito, Disponibile),
//uno scaffale in cui è posizionato,
//un autore (Nome, Cognome).