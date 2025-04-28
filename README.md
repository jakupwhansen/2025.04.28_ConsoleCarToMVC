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
