using HitachiTask.Language;

namespace HitachiTask.CSVhandling
{
    public class CsvReaderFactory
    {
        public CsvReaderFactory(bool isEnglish)
        {
            IsEnglish = isEnglish;
        }
        public bool IsEnglish { get; set; }

        private const int defaultMinTemp = 2;
        private const int defaultMaxTemp = 31;
        private const int defaultWindSpeed = 10;
        private const int defaultHumidity = 60;
        private const int defaultPrecipitation = 0;
        private const string defaultLightning = "Yes";
        private readonly List<string> defaultUnacceptableClouds = new List<string> { "Cumulus", "Nimbus" };

        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }
        public int WindSpeed { get; set; }
        public int Humidity { get; set; }
        public int Precipitation { get; set; }
        public string Lightning { get; set; }
        public List<string> UnacceptableClouds { get; set; } = new List<string>();
        public CsvReader CreateCsvReader()
        {
            bool changeLanguage = true;
            string filePath = "";
            while(changeLanguage == true)
            {
                if (IsEnglish)
                {
                    Console.WriteLine("Enter 0 to switch to German");
                    Console.WriteLine("Please, enter the path to the file, that you want to work with!");
                }
                else
                {
                    Console.WriteLine("Geben Sie 0 ein, um zu Englisch zu wechseln");
                    Console.WriteLine("Bitte geben Sie den Pfad zu der Datei ein, mit der Sie arbeiten möchten!");
                }
                string input = Console.ReadLine();
                if(input == "0")
                {
                    IsEnglish = LanguageChanger.ChangeLanguage(IsEnglish);
                }
                else
                {
                    changeLanguage = false;
                    filePath = input;
                }
            }

            CsvReader tempReader = new CsvReader(filePath);

            bool fileFound = false;
            while (!fileFound)
            {
                if (IsEnglish)
                {
                    fileFound = tempReader.TryReadingFile("File found", $"Could not find file '{filePath}'.");
                }
                else
                {
                    fileFound = tempReader.TryReadingFile("Datei gefunden", $"Die Datei '{filePath}‘ konnte nicht gefunden werden.");
                }

                if (!fileFound)
                {
                    if (IsEnglish)
                    {
                        Console.WriteLine("Please, enter the file path again!");
                        filePath = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Bitte geben Sie den Dateipfad erneut ein!");
                        filePath = Console.ReadLine();
                    }
                }
            }
            Console.WriteLine();

            changeLanguage = true;
            string useDefaultValues = "";
            while(changeLanguage == true)
            {
                if (IsEnglish)
                {
                    Console.WriteLine("Enter 0 to switch to German");
                    Console.WriteLine("Do you want to use the default values for the file?" +
                        "\nEnter 1 if you want to use the default values" +
                        "\nEnter any other button if you want to enter custom values");
                }
                else
                {
                    Console.WriteLine("Geben Sie 0 ein, um zu Englisch zu wechseln");
                    Console.WriteLine("Möchten Sie die Standardwerte für die Datei verwenden?" +
                        "\nGeben Sie 1 ein, wenn Sie die Standardwerte verwenden möchten" +
                        "\nGeben Sie eine beliebige andere Taste ein, wenn Sie benutzerdefinierte Werte eingeben möchten");

                }
                string input = Console.ReadLine();
                if (input == "0")
                {
                    IsEnglish = LanguageChanger.ChangeLanguage(IsEnglish);
                }
                else
                {
                    changeLanguage = false;
                    useDefaultValues = input;
                }
            }

            if (useDefaultValues == "1")
            {
                MinTemp = defaultMinTemp;
                MaxTemp = defaultMaxTemp;
                WindSpeed = defaultWindSpeed;
                Humidity = defaultHumidity;
                Precipitation = defaultPrecipitation;
                Lightning = defaultLightning;
                UnacceptableClouds = defaultUnacceptableClouds;
            }
            else
            {
                changeLanguage = true;
                while(changeLanguage == true)
                { 
                    if (IsEnglish)
                    {
                        Console.WriteLine("Enter Q to switch to German");
                        Console.WriteLine("Please, enter the lowest acceptable tempereture(C)!(inclusive)");
                    }
                    else
                    {
                        Console.WriteLine("Geben Sie Q ein, um zu Englisch zu wechseln");
                        Console.WriteLine("Bitte geben Sie die niedrigste akzeptable Temperatur(C) ein!(inklusive)");
                    }
                    string input = Console.ReadLine().ToUpper();
                    if (input == "Q")
                    {
                        IsEnglish = LanguageChanger.ChangeLanguage(IsEnglish);
                    }
                    else
                    {
                        changeLanguage = false;
                        MinTemp = int.Parse(input);
                    }
                }

                changeLanguage = true;
                while(changeLanguage == true)
                {
                    if (IsEnglish)
                    {
                        Console.WriteLine("Enter Q to switch to German");
                        Console.WriteLine("Please, enter the highest acceptable temperature(C)!(inclusive)");
                    }
                    else
                    {
                        Console.WriteLine("Geben Sie Q ein, um zu Englisch zu wechseln");
                        Console.WriteLine("Bitte geben Sie die höchste akzeptable Temperatur(C) ein!(inklusive)");
                    }
                    string input = Console.ReadLine().ToUpper();
                    if (input == "Q")
                    {
                        IsEnglish = LanguageChanger.ChangeLanguage(IsEnglish);
                    }
                    else
                    {
                        changeLanguage = false;
                        MaxTemp = int.Parse(input);
                    }
                }

                changeLanguage = true;
                while (changeLanguage == true)
                {
                    if (IsEnglish)
                    {
                        Console.WriteLine("Enter Q to switch to German");
                        Console.WriteLine("Please, enter the highest acceptable wind speed(m/s)!(inclusive)");
                    }
                    else
                    {
                        Console.WriteLine("Geben Sie Q ein, um zu Englisch zu wechseln");
                        Console.WriteLine("Bitte geben Sie die höchste zulässige Windgeschwindigkeit(m/s) ein!(inklusive)");
                    }
                    string input = Console.ReadLine().ToUpper();
                    if (input == "Q")
                    {
                        IsEnglish = LanguageChanger.ChangeLanguage(IsEnglish);
                    }
                    else
                    {
                        changeLanguage = false;
                        WindSpeed = int.Parse(input);
                    }
                }

                changeLanguage = true;
                while (changeLanguage == true)
                {
                    if (IsEnglish)
                    {
                        Console.WriteLine("Enter Q to switch to German");
                        Console.WriteLine("Please, enter the highest acceptable humidity percentage!(inclusive)");
                    }
                    else
                    {
                        Console.WriteLine("Geben Sie Q ein, um zu Englisch zu wechseln");
                        Console.WriteLine("Bitte geben Sie den höchsten akzeptablen Feuchtigkeitsprozentsatz ein!(inklusive)");
                    }
                    string input = Console.ReadLine().ToUpper();
                    if (input == "Q")
                    {
                        IsEnglish = LanguageChanger.ChangeLanguage(IsEnglish);
                    }
                    else
                    {
                        changeLanguage = false;
                        Humidity = int.Parse(input);
                    }
                }

                changeLanguage = true;
                while (changeLanguage == true)
                {
                    if (IsEnglish)
                    {
                        Console.WriteLine("Enter Q to switch to German");
                        Console.WriteLine("Please, enter the highest acceptable precipitation percentage!(inclusive)");
                    }
                    else
                    {
                        Console.WriteLine("Geben Sie Q ein, um zu Englisch zu wechseln");
                        Console.WriteLine("Bitte geben Sie den höchsten akzeptablen Niederschlagsprozentsatz ein! (inklusive)");
                    }
                    string input = Console.ReadLine().ToUpper();
                    if (input == "Q")
                    {
                        IsEnglish = LanguageChanger.ChangeLanguage(IsEnglish);
                    }
                    else
                    {
                        changeLanguage = false;
                        Precipitation = int.Parse(input);
                    }
                }

                changeLanguage = true;
                string lightningInput = "";
                while (changeLanguage == true)
                {
                    if (IsEnglish)
                    {
                        Console.WriteLine("Enter Q to switch to German");
                        Console.WriteLine("Please, enter whether lightnings can disturb the flight or not!(Yes/No)" +
                            "\nPlease enter 1 for yes" +
                            "\nPlease enter any other key for no");
                    }
                    else
                    {
                        Console.WriteLine("Geben Sie Q ein, um zu Englisch zu wechseln");
                        Console.WriteLine("Bitte geben Sie an, ob Blitze den Flug stören können oder nicht!" +
                            "\nBitte geben Sie 1 für Ja ein" +
                            "\nBitte geben Sie eine beliebige andere Taste für Nein ein");
                    }
                    string input = Console.ReadLine().ToUpper();
                    if (input == "Q")
                    {
                        IsEnglish = LanguageChanger.ChangeLanguage(IsEnglish);
                    }
                    else
                    {
                        changeLanguage = false;
                        lightningInput = input;
                    }
                }
                
                if (lightningInput == "1")
                {
                    Lightning = "Yes";
                }
                else
                {
                    Lightning = "No";
                }

                changeLanguage = true;
                string cloudInput = "";
                while (changeLanguage == true)
                {
                    if (IsEnglish)
                    {
                        Console.WriteLine("Enter Q to switch to German");
                        Console.WriteLine("Please, list the type of clouds, that can hinder the flight! Please, separate them with whitespace!");
                    }
                    else
                    {
                        Console.WriteLine("Geben Sie Q ein, um zu Englisch zu wechseln");
                        Console.WriteLine("Bitte geben Sie die Art der Wolken an, die den Flug behindern können! Bitte trennen Sie diese durch Leerzeichen!");
                    }
                    string input = Console.ReadLine().ToUpper();
                    if (input == "Q")
                    {
                        IsEnglish = LanguageChanger.ChangeLanguage(IsEnglish);
                    }
                    else
                    {
                        changeLanguage = false;
                        cloudInput = input.ToLower();
                    }
                }
                    
                UnacceptableClouds = cloudInput.Split(" ").ToList();

                for (int i = 0; i < UnacceptableClouds.Count; i++)
                {
                    if (!string.IsNullOrEmpty(UnacceptableClouds[i]))
                    {
                        char firstChar = char.ToUpper(UnacceptableClouds[i][0]);
                        UnacceptableClouds[i] = firstChar + UnacceptableClouds[i].Substring(1);
                    }
                }
            }
            CsvReader reader = new CsvReader(filePath, MinTemp, MaxTemp, WindSpeed, Humidity, Precipitation, Lightning, UnacceptableClouds);
            return reader;
        }
    }
}
