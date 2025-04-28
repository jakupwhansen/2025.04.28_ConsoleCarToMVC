MVC 04

Vi har nu indført Dependency Injection ved at lade CarController modtage ICarView i sin constructor.
Programmet vælger hvilket View der skal bruges og giver det videre til Controlleren.
Dette fjerner Controllerens ansvar for at vælge afhængigheder selv.
Det giver lavere kobling, større fleksibilitet og gør koden nemmere at teste og udvide.
Controlleren styrer flowet uden at kende detaljerne om hvordan View fungerer.

MVC 03

Vi har nu oprettet en CarController, som styrer hele programmets logik.
Controlleren håndterer brugerens valg, og samarbejder med både View og Model.
Program-klassen starter kun Controlleren og har ikke længere logik selv.
Dette adskiller ansvar i koden, så hver del kun gør én ting, som i rigtig MVC.
Controlleren kalder View for brugerinput og output, og opdaterer Model baseret på valgene.

MVC 02

Vi har oprettet et interface ICarView, som definerer hvad et View skal kunne.
CarView og ColorCarView implementerer ICarView med hver deres måde at vise data på.
Programmet arbejder kun gennem ICarView, og kender ikke konkrete Views.
Det gør koden fleksibel, så vi kan skifte View uden at ændre logikken.
Dette giver lav kobling, bedre struktur og fremtidssikrer applikationen.

MVC 01 

Første skridt mod MVC: Vi flytter al brugerinput og output til en separat View-klasse. Program-klassen holder nu mest styr på logikken (controller-rollen).

MVC 00 

En C# Console applikation som kan vise biler og oprette nye bilere også. Den er lavet helt uden MVC hensyn. Vi skal så udvide den i små skridt, til at blive en komplet MVC agtig løsning, så vi lærer at forstå og anvende MVC mønstret i vores fremtidige løsninger
