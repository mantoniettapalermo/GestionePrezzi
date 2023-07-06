# GestionePrezzi

Benvenuti nel mio progetto! Questa è un'applicazione window realizzata in C# e nel framework .Net. 
L'obbiettivo è quello di avere una lista aggiornata di prodotti acquistabili nei negozi (in particolare è indirizzato all'acquisto di prodotti per spesa familiare) e dei relativi prezzi minimi indicati nell'unità di misura principale del prodotto.
Con questa applicazione gli utenti possono aggiungere nuovi prodotti, cercare prodotti tra quelli già esistenti e aggiungere un nuovo prezzo. 
L'applicazione si occupera di tenere traccia dei diversi prezzi inseriti per quel prodotto e di fornire all'utente il prezzo minimo tra quelli inseriti fino a quel momento. 

Lo scopo finale di questa applicazione è quella di fornire agli utenti uno strumento per risparmiare sulla spesa quotidiana. 
L'idea di creare questa app è nata da me, in quanto questo tipo di ragionamento lo applicavo mentalmente durante gli acquisti.
Ovviamente riscontrando un limite alla mia memoria o alle eventuali note su carta, volevo uno strumento informatico che mi aiutasse in questo compito.

I dati sui prodotti per questo progetto, ovvero i prodotti e i prezzi inziali, sono stati recuperati in modo automatico tramite tencologia RPA utilizzando Uipath. 
Mi sono occupata di recuperare una lista di prodotti e prezzi presenti nei principali supermercati nella mia zona. 
Da questa base di dati ho inziato ad inserire manualmente i prezzi aggiornati quando ne sentivo la necessità, in futuro vorrei automatizzare questo processo.

Al momento il database è locale alla mia macchina, appena ne avrò le competenze vorrei creare un'istanza cloud da poter condividere con tutti gli utenti che ne faranno utilizzo.
Il passo successivo sarà quello di creare una Web App per permettere l'accesso a questi dati l'accesso da remoto quando se ne ha bisogno.
