# GestionePrezzi

## Storia del Progetto
Benvenuti nel mio progetto! Questo viaggio è iniziato con un'idea semplice ma potente: aiutare le famiglie a risparmiare sulla spesa quotidiana. Mi chiamo Antonietta e sono la mente dietro questa applicazione, sviluppata in C# utilizzando il framework .Net. L'ispirazione è nata dalla mia esperienza personale: durante la spesa, mi trovavo spesso a cercare di ricordare i prezzi migliori per i vari prodotti, un compito che diventava sempre più difficile man mano che aumentavano gli articoli da acquistare. Volevo uno strumento che mi aiutasse a risolvere questo problema, e così è nata questa app.

## Obiettivo dell'Applicazione
L'applicazione ha l'obiettivo di fornire una lista sempre aggiornata dei prodotti disponibili nei negozi, con i relativi prezzi minimi indicati per unità di misura. Questo strumento permette agli utenti di:

- Aggiungere nuovi prodotti: Ogni prodotto può essere inserito specificando nome, categoria e unità di misura.
- Cercare prodotti: Gli utenti possono cercare tra i prodotti esistenti utilizzando vari filtri, come il nome del prodotto o la categoria.
- Aggiungere nuovi prezzi: Ogni volta che un utente trova un prezzo migliore, può aggiungerlo al database, contribuendo a tenere traccia dei diversi prezzi per quel prodotto.
- Visualizzare il prezzo minimo: L'applicazione calcola automaticamente il prezzo minimo tra quelli inseriti per ogni prodotto, aiutando gli utenti a trovare le offerte migliori.
- 
## Tecnologie Utilizzate
Per popolare inizialmente il database, ho utilizzato la tecnologia RPA (Robotic Process Automation) tramite UiPath. Questo mi ha permesso di raccogliere automaticamente una lista di prodotti e prezzi dai principali supermercati della mia zona. Con questa base dati, ho iniziato ad aggiornare manualmente i prezzi quando necessario. In futuro, intendo automatizzare ulteriormente questo processo per garantire che i dati siano sempre aggiornati in tempo reale.

## Visione per il Futuro
Attualmente, il database è locale alla mia macchina, ma sto lavorando per acquisire le competenze necessarie a migrare i dati su un'istanza cloud. Questo passo sarà fondamentale per permettere la condivisione dei dati con tutti gli utenti che vorranno utilizzare l'applicazione. Il prossimo grande obiettivo è sviluppare una Web App che consenta l'accesso remoto ai dati, in modo che gli utenti possano consultare i prezzi ovunque si trovino.

## Tecnologie e Strumenti per il Futuro
- Database Cloud: Sto valutando servizi come AWS, Azure, e Google Cloud per ospitare il database, garantendo sicurezza e accessibilità.
- Web App: Utilizzerò tecnologie moderne come ASP.NET Core, Blazor o React per sviluppare un'interfaccia web intuitiva e reattiva.
- Automatizzazione con RPA: Continuerò a sfruttare UiPath per l'aggiornamento automatico dei prezzi, ma esplorerò anche altre soluzioni di automazione per migliorare l'efficienza.
- Best Practices e Coinvolgimento della Community
- Controllo di Versione: Git sarà essenziale per il controllo di versione, assicurando che ogni cambiamento sia tracciabile e gestibile.
- Testing: Implementerò unit test e integration test per mantenere la stabilità dell'applicazione.
- Sicurezza: La protezione dei dati degli utenti sarà una priorità, con misure di autenticazione e autorizzazione robuste.


Questo progetto è molto più di un semplice strumento: è un compagno per le famiglie che vogliono ottimizzare le loro spese quotidiane. Sono entusiasta di continuare a migliorarlo e renderlo sempre più utile per tutti. Grazie per aver condiviso questo viaggio con me!
