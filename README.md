# G4BDev / Projet C# Hôtelerie
Sacha Volery, Théo Brocard, Matteo Da Cunha

## Software et version 

##### .NET version 6.0
##### C# Winform
##### Visual Studio 2022
##### HeidiSQL version 12.6
##### MySQl dll version 4.8

## Prerequesites

### [Installation Visual Studio Code](https://learn.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022) 
### [Installation HeidiSQL](https://www.heidisql.com/download.php)

## Add MySql to your own project 

For your project, you will need to add manually the MySql Package.

Tools->Nuget Packet Manager->Package Manager Console ;

```
[INPUT]
PM> Install-Package MySQL.Data
Restoring packages for C:\Users\pn44lvn\Desktop\g4bDev\G4bDev_Hôtellerie\G4bDev_Hôtellerie\G4bDev_Hôtellerie.csproj...
Installing NuGet package MySQL.Data 8.2.0.
Generating MSBuild file  C:\Users\pn44lvn\Desktop\g4bDev\G4bDev_Hôtellerie\G4bDev_Hôtellerie\obj\PrototypeDbConnector.csproj.nuget.g.targets.
Writing assets file to disk. Path: C:\Users\pn44lvn\Desktop\g4bDev\G4bDev_Hôtellerie\G4bDev_Hôtellerie\obj\project.assets.json
Restored C:\Users\pn44lvn\Desktop\g4bDev\G4bDev_Hôtellerie\G4bDev_Hôtellerie\G4bDev_Hôtellerie.csproj (in 183 ms).
[...]
Successfully installed 'ZstdSharp.Port 0.7.1' to G4bDev_Hôtellerie
Executing nuget actions took 743 ms
Time Elapsed: 00:00:02.8070762

```


## Desciption du projet 

#### Nous allons faire le système de résevation d'un hotêl avec plusieurs options ;

##### Réservation : 
   ###### Permettra aux clients de réserver une / plusieurs chambres

##### Client : 
   ###### Les informations des clients de l'hôtel

##### Chambres :
   ###### Le prix et les différentes options possible (chambre simple, double, etc...) + ces disponibilité

##### Personnel :
   ###### Les informations sur les salariers de l'hôtel
    
##### Facture :
   ###### Les factures après séjour
    



