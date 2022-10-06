// See https://aka.ms/new-console-template for more information
using BilModelLib.model;
using ClassDemoConsumeBilREST;

Console.WriteLine("Hello, World!");
Consumer consumer = new Consumer();

List<Bil> biler = await consumer.GetAllAsync();

foreach (Bil bil in biler)
{
    Console.WriteLine(bil);
}




Bil ændretBil = new Bil()
{ Model = "Polo", StelNummer = "XC3.45627.456", Km = 23000, Aar = 2018, Maerke = "VW", Braendsel = "Diesel" };

Bil returBil = await consumer.PutAsync("XC3.45627.456", ændretBil);

Console.WriteLine(returBil);