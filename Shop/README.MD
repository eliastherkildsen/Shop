# 3. Semester D23 Software Architecture and Distributed Systems.
    Afleveringsopgave i emnet Clean Architecture.
    Titel: Jewellery Shop
    Afleveres individuelt på Moodle fredag 20. september.

## Case-beskrivelse:
    Der skal bygges software i C# til at håndtere salg af håndlavede smykker. Vi er interesseret i at designe en
    software-løsning der anvender princippet for ”Clean Arctitecture”, og lave et proof of concept for designet.
    I skal derfor bare bygge en C# konsol applikation med en simpel Main til at demonstrere de forskellige Use

    Cases. Et smykke kaldes ”Item” er basisklassen.
    Information om de smykker der skal sælges hentes fra en (eller flere filer) som indeholder:
    Id, beskrivelse og pris.

    En ordre indeholder altså ét Item-objekt. Til ordren kan tilkøbes gaveindpakning og forsendelse.
    Til at arbejde med file(erne) skal Adapter-mønsteret anvendes.
    Til at bygge ordren skal Decorator-mønsteret bruges. Altså det valgte Item dekoreres med GiftWrapping og
    Shipment hvis dette ønskes.

    Bemærk at klasserne GiftWrapping og Shipment også bør hente den nødvendige information fra filer i
    filsystemet.

### I bør implementere følgende use cases til denne case (husk at det bare er en konsol applikation):
    1. Show All Items (info from file)
    2. Pick Item (for order)
    3. Add/Ignore GiftWrapping (info from file)
    4. Add/Ignore Shipment (info from file)
    5. View Order with total price.
    
### Læringsmål:
    Anvendelse af ”Clean Architecture” (både logisk og fysisk).
    Anvendelse af Dependency Inversion Princippet (SOLID #5) herunder Dependency Injection i C#.
    Anvendelse af Adapter og Decorator i en ”Clean Architecture.
    Anvendelse af Open Closed Princippet (SOLID #2).
    Jeres rapport skal indeholde:
    Den logiske arkitektur. (ringformede model) - gerne med ”dependencies” tegnet på.
    Den fysiske arkitektur (mappestrukturen i projektet).
    Forklar (illustreret med kode) de principper der er anvendt. Altså også hvordan retningen på de enkelte
    ”dependencies” er blevet. Kan domain-laget være afhængig af noget fra et andet lag?
    Kode som link til Jeres GitHub.
    /THA