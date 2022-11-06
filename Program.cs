// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;

Console.WriteLine("Hello, World!");

Biblioteca biblioteca = new Biblioteca();


//array con le voci dei menu principali cosi da poterli gerstire solo da qui
string[] menuPrincipale = { "seleziona il menu","1. Registro","2. nuovo prestito" };
string[] menuRegistro = { "seleziona l'azione", "1. reggistro tutti gli utenti" , "2. registro prestiti"};


//controlla sulle scelte del utente
int testNumero(){

    int libero;

    string tester = Console.ReadLine();
    int number;

    bool success = int.TryParse(tester, out number);
    if (success)
    {
         libero = Convert.ToInt32(tester);
    }else
    {
        Console.WriteLine("mi spiace non è un numero");
        libero =  testNumero();
    }


    return libero;
}
bool siOno()
{
    string testo = Convert.ToString(Console.ReadLine());
    if( testo == "si"|| testo == "yes"|| testo == "y"|| testo == "s")
    {
        return true;
    }
    else
    {
        return false;
    }

}
//menu iniziale del programma
void menu(string[] menuPrincipale)
{
    foreach (string menuPrincipaleItem in menuPrincipale)
    {
        Console.WriteLine(menuPrincipaleItem);
    }

    int MP = testNumero();

    if (MP > menuPrincipale.Length || MP < 0)
    {
        MP = 1;
    }

    switch (MP)
    {
        case 1:
            menuReggistro();
            break;
        case 2:
            nuovoPrestito(biblioteca);
            break;
    }
}


void nuovoPrestito(Biblioteca biblioteca)
{
    Console.WriteLine("devi prestare un dvd o un libro ?  exit per tornare in dietro");
    string selezione = Convert.ToString(Console.ReadLine());

    if (selezione == "libro")
    {
        Console.WriteLine("devi digitare il nome del libro, vuoi vedere la lista dei libri disponibili ? ");
        if (siOno())
        {
            for (int i = 0; i < biblioteca.libriDisponibili.Count; i++)
            {
                Console.WriteLine("libro numero " + (i+1));
                Console.WriteLine(biblioteca.libriDisponibili[i].Titolo);
                Console.WriteLine("-------------------");
            }

            Console.WriteLine("digita ora il nome del libro oppure il suo numero indice");
            string libro = Convert.ToString(Console.ReadLine());
            int number;

            bool success = int.TryParse(libro, out number);
            if (success){
                int libroInt = Convert.ToInt32(libro);
                if( libroInt > 1 || libroInt < biblioteca.libriDisponibili.Count)
                {
                    Lprestito(libroInt);
                }else
                {
                    Console.WriteLine("numero non valido");
                    nuovoPrestito(biblioteca);
                }
            
            }else
            {
                int libroInt = 0;
                bool successo = false;
                for (int i =0; i < biblioteca.libriDisponibili.Count; i++)
                {
                    if (biblioteca.libriDisponibili[i].Titolo == libro)
                    {
                        successo = true;
                        libroInt = i;
                        break;
                    }

                    
                }
                if (successo)
                {
                    Lprestito(libroInt);
                }
                else
                {
                    Console.WriteLine("nome non trovato");
                    nuovoPrestito(biblioteca);
                }
            }
            
        }
    }
}


void Lprestito(int libroInt)
{
    Console.WriteLine("inserisci l'indice del cliente");
    int indice = testNumero();
    Cliente cliente = biblioteca.clienti[indice];
    string voce = "libro " + biblioteca.libriDisponibili[libroInt].Titolo;
    Console.WriteLine("digita la durata in giorni");
    int durata = testNumero();
    Console.WriteLine("indica la data di inizio ... !! non implementata correttamente!!");
    string dataInizio = Convert.ToString(Console.ReadLine());
    Console.WriteLine("indica la data di fine... !! non implementata correttamente!!");
    string data = Convert.ToString(Console.ReadLine());
    int libroIndiceDisponibili = libroInt;


    biblioteca.nuovoPrestito(cliente, voce, durata, data, dataInizio, libroIndiceDisponibili);
    menu(menuPrincipale);
}
//menu del registro
void menuReggistro()
{
    foreach (string menuRegistro in menuRegistro)
    {
        Console.WriteLine(menuRegistro);
    }

    int MP = testNumero();

    if (MP > menuPrincipale.Length || MP < 0)
    {
        MP = 1;
    }

    switch (MP)
    {
        case 1:
            listaUtenti(biblioteca);
            break;
        case 2:
            listaPrestiti(biblioteca);
            break;
    }
}

void listaPrestiti(Biblioteca biblioteca)
{
     for (int i = 0; i < biblioteca.prestiti.Count ; i++)
    {
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine (biblioteca.prestiti[i].Cliente);
        Console.WriteLine("tiene prestito");
        Console.WriteLine(biblioteca.prestiti[i].Voce);
        Console.WriteLine("dalla data");
        Console.WriteLine(biblioteca.prestiti[i].DataInizio);
        Console.WriteLine("per giorni ");
        Console.WriteLine(biblioteca.prestiti[i].Durata);

    }
    menu(menuPrincipale);
}


menu(menuPrincipale);


//funzione che mostra la lista intera dei clienti
void listaUtenti(Biblioteca biblioteca)
{

    int i = 1;
    foreach (Cliente item in biblioteca.clienti)
    {
        Console.WriteLine("utente numero " + i);
        Console.WriteLine("nome -----" + item.Nome);
        Console.WriteLine("cognome --" + item.Cognome);
        Console.WriteLine("email ----" + item.Email);
        Console.WriteLine("telefono -" + item.RecapitoTelefonico);
        Console.WriteLine("------------------------------------------------------------------------------------------------------------");
        i++;

    }

    Console.WriteLine("vuoi le specifiche di un cliente? si o no?");
    if (siOno())
    {
        menuShowCliente(biblioteca);
    }
    else
    {
        menuReggistro();
    }


}

// menu di ricerca clienti
void menuShowCliente(Biblioteca biblioteca)
{
    Console.WriteLine("seleziona utente");
    Console.WriteLine("1. per indice");
    Console.WriteLine("2. per nome");
    Console.WriteLine("3. per cognome");
    Console.WriteLine("4. per emai");
    Console.WriteLine("5. per telefono");
    Console.WriteLine("6. torna al menu iniziale");

    int scelta = testNumero();

    if (scelta > 5 || scelta < 1)
    {
        Console.WriteLine("il tuo numero non è compreso tra le selezioni");
        menuShowCliente(biblioteca);
    }
    switch (scelta)
    {
        case 1:
            Console.WriteLine("indicami l'indice");
            int indice = testNumero();
            if (indice > 0 || indice < biblioteca.clienti.Count)
            {
                Console.WriteLine("cliente " + indice);
                Console.WriteLine("nome " + biblioteca.clienti[indice - 1].Nome);
                Console.WriteLine("cognome " + biblioteca.clienti[indice - 1].Cognome);
                Console.WriteLine("email " + biblioteca.clienti[indice - 1].Email);
                Console.WriteLine("recapito telefonico " + biblioteca.clienti[indice - 1].RecapitoTelefonico);
            }
            else
            {
                menuShowCliente(biblioteca);
            }
            break;
        case 2:
            Console.WriteLine("indicami il nome");
            string nome = Convert.ToString(Console.ReadLine());
            bool trovato = false;
            int i = 0;
            for (; i < biblioteca.clienti.Count; i++)
            {
                if (nome == biblioteca.clienti[i].Nome)
                {
                    trovato = true;
                }
            }

            if (trovato)
            {
                i--;
                Console.WriteLine("cliente " + i);
                Console.WriteLine("nome " + biblioteca.clienti[i].Nome);
                Console.WriteLine("cognome " + biblioteca.clienti[i].Cognome);
                Console.WriteLine("email " + biblioteca.clienti[i].Email);
                Console.WriteLine("recapito telefonico " + biblioteca.clienti[i].RecapitoTelefonico);
            }
            else
            {
                menuShowCliente(biblioteca);
            }
            break;
        case 3:
            Console.WriteLine("indicami il cognome");
            string cognome = Convert.ToString(Console.ReadLine());
            bool trovato2 = false;
            int i2 = 0;
            for (; i2 < biblioteca.clienti.Count; i2++)
            {
                if (cognome == biblioteca.clienti[i2].Cognome)
                {
                    trovato2 = true;
                }
            }

            if (trovato2)
            {
                i2--;
                Console.WriteLine("cliente " + i2);
                Console.WriteLine("nome " + biblioteca.clienti[i2].Nome);
                Console.WriteLine("cognome " + biblioteca.clienti[i2].Cognome);
                Console.WriteLine("email " + biblioteca.clienti[i2].Email);
                Console.WriteLine("recapito telefonico " + biblioteca.clienti[i2].RecapitoTelefonico);
            }
            else
            {
                menuShowCliente(biblioteca);
            }
            break;
        case 4:
            Console.WriteLine("indicami il email");
            string email = Convert.ToString(Console.ReadLine());
            bool trovato3 = false;
            int i3 = 0;
            for (; i3 < biblioteca.clienti.Count; i3++)
            {
                if (email == biblioteca.clienti[i3].Email)
                {
                    trovato3 = true;
                }
            }

            if (trovato3)
            {
                i3--;
                Console.WriteLine("cliente " + i3);
                Console.WriteLine("nome " + biblioteca.clienti[i3].Nome);
                Console.WriteLine("cognome " + biblioteca.clienti[i3].Cognome);
                Console.WriteLine("email " + biblioteca.clienti[i3].Email);
                Console.WriteLine("recapito telefonico " + biblioteca.clienti[i3].RecapitoTelefonico);
            }
            else
            {
                menuShowCliente(biblioteca);
            }
            break;
        case 5:
            Console.WriteLine("indicami il numero di telefomo");
            int numero = testNumero();
            bool trovato4 = false;
            int i4 = 0;
            for (; i4 < biblioteca.clienti.Count; i4++)
            {
                if (numero == biblioteca.clienti[i4].RecapitoTelefonico)
                {
                    trovato4 = true;
                }
            }

            if (trovato4)
            {
                i4--;
                Console.WriteLine("cliente " + i4);
                Console.WriteLine("nome " + biblioteca.clienti[i4].Nome);
                Console.WriteLine("cognome " + biblioteca.clienti[i4].Cognome);
                Console.WriteLine("email " + biblioteca.clienti[i4].Email);
                Console.WriteLine("recapito telefonico " + biblioteca.clienti[i4].RecapitoTelefonico);
            }
            else
            {
                menuShowCliente(biblioteca);
            }
            break;
        case 6:
            menu(menuPrincipale); ;
            break;

    }
}



// parte 2 Il bibliotecario può effettuare dei prestiti ai suoi clienti registrati, attraverso il sistema, sui documenti che sono di vario tipo (libri, DVD). I documenti sono caratterizzati da:
//un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD),
//titolo,
//anno,
//settore(storia, matematica, economia, …),
//stato(In Prestito, Disponibile),
//uno scaffale in cui è posizionato,
//un autore (Nome, Cognome).
//Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.