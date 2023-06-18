using System;
using System.Collections.Generic;

class Programm
{
    static List<List<object>> produkte = new List<List<object>>
    {
        new List<object> { 1, "Haribo", 5.00m, 20 },
        new List<object> { 2, "Chips", 3.00m, 20 },
        new List<object> { 3, "Cola", 2.50m, 20 },
        new List<object> { 4, "Rivella", 1.75m, 20 },
        new List<object> { 5, "Toblerone", 5.00m, 20 }
    };

    static void Main(string[] args)
    {
        Console.WriteLine("Verfügbare Produkte:");
        foreach (var produkt in produkte)
        {
            Console.WriteLine($"Produktnummer: {produkt[0]}, Produkt: {produkt[1]}, Preis: {produkt[2]:0.00} CHF");
        }

        Console.WriteLine();

        List<List<object>> ausgewählteProdukte = new List<List<object>>();

        bool weiterEinkaufen = true;

        while (weiterEinkaufen)
        {
            Console.WriteLine("Geben Sie die Produktnummer ein: ");
            int produktNummer = int.Parse(Console.ReadLine());

            List<object> ausgewähltesProdukt = ProduktNachNummerSuchen(produktNummer);

            if (ausgewähltesProdukt != null)
            {
                Console.WriteLine("Geben Sie die gewünschte Menge ein: ");
                int menge = int.Parse(Console.ReadLine());

                if ((int)ausgewähltesProdukt[3] >= menge)
                {
                    ausgewähltesProdukt[3] = (int)ausgewähltesProdukt[3] - menge;

                    if ((int)ausgewähltesProdukt[3] < 3)
                    {
                        Console.WriteLine("Warnung: Produktmenge ist unter 3 gefallen!");
                    }

                    ausgewählteProdukte.Add(new List<object>
                    {
                        ausgewähltesProdukt[0],
                        ausgewähltesProdukt[1],
                        ausgewähltesProdukt[2],
                        menge
                    });
                }
                else
                {
                    Console.WriteLine("Fehler: Nicht genügend Vorrat!");
                }
            }


            Console.WriteLine();
            Console.WriteLine("Verfügbare Produkte:");
            foreach (var produkt in produkte)
            {
                Console.WriteLine($"Produktnummer: {produkt[0]}, Produkt: {produkt[1]}, Preis: {produkt[2]:0.00} CHF, Menge: {produkt[3]}");
            }

            Console.WriteLine();

            Console.WriteLine("Möchten Sie ein anderes Produkt auswählen? (J/N)");
            string antwort = Console.ReadLine();
            weiterEinkaufen = (antwort.ToLower() == "j");
        }

        decimal gesamtPreis = GesamtPreisBerechnen(ausgewählteProdukte);
        Console.WriteLine("Gesamtbetrag, den Sie bezahlen müssen: " + gesamtPreis.ToString("0.00") + " CHF");

        Console.ReadLine();
    }

    static List<object> ProduktNachNummerSuchen(int produktNummer)
    {
        foreach (var produkt in produkte)
        {
            if ((int)produkt[0] == produktNummer)
            {
                return produkt;
            }
        }
        return null;
    }

    static decimal GesamtPreisBerechnen(List<List<object>> ausgewählteProdukte)
    {
        decimal gesamtPreis = 0;

        foreach (var produkt in ausgewählteProdukte)
        {
            gesamtPreis += (decimal)produkt[2] * (int)produkt[3];
        }

        return gesamtPreis;
    }
}
