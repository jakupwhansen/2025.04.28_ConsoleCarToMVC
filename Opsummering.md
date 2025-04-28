
# Car Management System (Console MVC)

Dette projekt er en konsolbaseret applikation bygget efter **Model-View-Controller (MVC)**-mønstret.  
Systemet er struktureret i mapper: **Models**, **Views**, **Controllers**, og **Data**, hvilket skaber en klar adskillelse af ansvar.

Vi bruger **DTO (Data Transfer Objects)** til at transportere data sikkert mellem Repository og Controller,  
**ViewModel** til at forberede data til visning i View, og **Dependency Injection (DI)** til at levere Repository og View til Controlleren, hvilket gør systemet fleksibelt og let at teste.

Applikationen understøtter to repository-implementeringer:
- **DummyCarRepository**: Arbejder i RAM.
- **JsonCarRepository**: Gemmer data til og læser fra en JSON-fil.

Systemet er designet med henblik på **lav kobling**, **høj fleksibilitet**, **nem udskiftelighed af lag**, og **forberedelse til unit testing**.

---

## Opbygning

### CarDTO (Data Transfer Object)

**CarDTO** bruges til at beskytte og overføre data mellem Repository og Controller. DTO'en indeholder kun de nødvendige felter: **Brand**, **Model**, og **Year**.  
Dette sikrer, at vi ikke eksponerer interne Model-strukturer direkte ud af systemet.

Eksempel:

```csharp
public class CarDTO
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public CarDTO(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }
}
```

---

### Car (Model)

**Car** repræsenterer den interne forretningsmodel og logik.  
Når data hentes fra Repository (som CarDTO), mapper Controlleren DTO til en Car-model, så vi kan arbejde med domænelogik såsom at beregne bilens alder.

---

### CarViewModel (ViewModel)

**CarViewModel** bruges til at forberede data til visning i View.  
Den modtager en **Car** og præsenterer information på en brugervenlig måde, eksempelvis som **DisplayName** (mærke + model) og **Age** (alder på bilen).

Eksempel:

```csharp
public class CarViewModel
{
    public string DisplayName { get; set; }
    public int Age { get; set; }

    public CarViewModel(Car car)
    {
        DisplayName = $"{car.Brand} {car.Model}";
        Age = DateTime.Now.Year - car.Year;
    }
}
```

---

## Workflow (Dataflow)

1. **Repository** (DummyCarRepository eller JsonCarRepository) henter en liste af **CarDTO**.
2. **Controlleren** mapper **CarDTO** til **Car** (Model).
3. **Controlleren** mapper **Car** til **CarViewModel** for præsentation.
4. **Viewet** viser data baseret på **CarViewModel**.

---

## Mapperstruktur

- **Models/** → Indeholder Car-modellen.
- **Views/** → Indeholder CarView, ColorCarView, ICarView interface og CarViewModel.
- **Controllers/** → Indeholder CarController, som styrer flowet mellem View og Repository.
- **Data/** → Indeholder ICarRepository interface, DummyCarRepository og JsonCarRepository, samt CarDTO.

---

## Dependency Injection

Controlleren modtager både en instans af **ICarRepository** og **ICarView** via konstruktør-injektion.  
Det gør det nemt at skifte repository (f.eks. fra DummyCarRepository til JsonCarRepository) eller skifte View (fra CarView til ColorCarView) uden at ændre logikken i Controlleren.

Eksempel:

```csharp
var repository = new JsonCarRepository();
var view = new ColorCarView();
var controller = new CarController(repository, view);
controller.Run();
```

---

## Teknisk Opsummering

- **Low Coupling**: Lagene er uafhængige af hinanden via interfaces og DTO'er.
- **High Cohesion**: Hvert lag har ét klart ansvar.
- **Testbar**: Systemet kan nemt udvides med mocks eller stubs for enhedstest.
- **Klar MVC-struktur**: Adskillelse mellem Model, View, Controller.
- **JSON-understøttelse**: Mulighed for persistens af data uden database.

---

# Konklusion

Systemet er bygget op efter gode arkitekturmønstre med opdeling i Model, View, Controller, ViewModel og DTO.  
Brugen af Dependency Injection og interfaces gør applikationen både fleksibel, testbar og klar til fremtidige udvidelser eller migrering til f.eks. en rigtig database eller en web-applikation.

---

### 🚀 Klar til GitHub!

Vil du også have, at jeg laver en lille liste med "Hvordan man bygger og kører projektet" (Build Instructions), hvis du vil gøre README helt perfekt? 🎯  
(Så kan du bare copy-paste det bagefter!)
