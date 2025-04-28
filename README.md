<p align="right">
  <a href="https://github.com/jakupwhansen/2025.04.28_ConsoleCarToMVC/blob/master/Opsummering.md">Opsummering af hele systemet</a>
</p>


MVC 08 (DTO)

Vi har tilføjet en DTO (Data Transfer Object) kaldet CarDTO, som bruges til at overføre data mellem lagene i applikationen, specielt til JsonCarRepository. CarDTO indeholder kun de nødvendige data for at gemme og hente biler, f.eks. Brand, Model, og Year. Dette beskytter den interne struktur af vores Model (Car), da kun de nødvendige data sendes frem og tilbage. 

Sammenhæng mellem DTO og ViewModel:
DTO (CarDTO) bruges til at hente og gemme data i JsonCarRepository. Det fungerer som et transportobjekt, som kun indeholder de nødvendige felter for at overføre data.
Model (Car) repræsenterer den interne struktur og logik. Når vi henter CarDTO fra Repository, mapper vi det til Car i Controlleren.
ViewModel (CarViewModel) bruges til at forberede data til præsentation i View. CarViewModel modtager Car og omdanner den til præsentationsvenlige data, såsom DisplayName og Age.
Workflow: Repository henter CarDTO. Controller mapper CarDTO til Car. Controller mapper Car til CarViewModel for præsentation i View.

MVC 07 (ViewModel)

I denne løsning har vi opdateret vores Views til at arbejde med ViewModel i stedet for Model direkte.
Vi oprettede CarViewModel for at forberede data til visning i et brugervenligt format, såsom DisplayName og Age.
Både CarView og ColorCarView blev opdateret til at modtage List<CarViewModel> og vise dataene.
Dette giver en klar separation mellem datahåndtering og præsentation, og vi sikrer, at Views kun modtager de nødvendige data, der skal vises.

MVC 06 (Controller: Repository DI)

Vi har oprettet en ny mappe kaldet "Data" for at adskille datatilgang fra resten af applikationen.
I Data-mappen har vi lavet et interface ICarRepository, som definerer hvordan vi arbejder med bil-data.
Vi har to repositories: DummyCarRepository som bruger RAM og JsonCarRepository som gemmer til fil.
Det gør vores system fleksibelt, så vi kan skifte datakilde (Dependency Injection (DI)) uden at ændre Controlleren.
Data-folderen følger samme struktur som rigtige ASP.NET MVC projekter, hvilket forbereder os til webudvikling.

MVC 05 (Mappe Struktur)

Vi har nu organiseret projektet i mapper: Models, Views og Controllers.
Det gør det nemt at finde klasserne og viser klart deres rolle i systemet.
Strukturen følger standarden fra rigtig MVC-udvikling (og ASP.NET MVC).
Når projekter vokser, bliver mapper afgørende for overblik og vedligeholdelse.
Det hjælper både os selv og andre, der skal læse eller videreudvikle koden.

MVC 04 (Controller: View DI)

Vi har nu indført Dependency Injection ved at lade CarController modtage ICarView i sin constructor.
Programmet vælger hvilket View der skal bruges og giver det videre til Controlleren.
Dette fjerner Controllerens ansvar for at vælge afhængigheder selv.
Det giver lavere kobling, større fleksibilitet og gør koden nemmere at teste og udvide.
Controlleren styrer flowet uden at kende detaljerne om hvordan View fungerer.

MVC 03 (Controller)

Vi har nu oprettet en CarController, som styrer hele programmets logik.
Controlleren håndterer brugerens valg, og samarbejder med både View og Model.
Program-klassen starter kun Controlleren og har ikke længere logik selv.
Dette adskiller ansvar i koden, så hver del kun gør én ting, som i rigtig MVC.
Controlleren kalder View for brugerinput og output, og opdaterer Model baseret på valgene.

MVC 02 (IView)

Vi har oprettet et interface ICarView, som definerer hvad et View skal kunne.
CarView og ColorCarView implementerer ICarView med hver deres måde at vise data på.
Programmet arbejder kun gennem ICarView, og kender ikke konkrete Views.
Det gør koden fleksibel, så vi kan skifte View uden at ændre logikken.
Dette giver lav kobling, bedre struktur og fremtidssikrer applikationen.

MVC 01 (View) 

Første skridt mod MVC: Vi flytter al brugerinput og output til en separat View-klasse. Program-klassen holder nu mest styr på logikken (controller-rollen).

MVC 00 

En C# Console applikation som kan vise biler og oprette nye bilere også. Den er lavet helt uden MVC hensyn. Vi skal så udvide den i små skridt, til at blive en komplet MVC agtig løsning, så vi lærer at forstå og anvende MVC mønstret i vores fremtidige løsninger
