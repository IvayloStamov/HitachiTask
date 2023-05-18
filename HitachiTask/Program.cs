using HitachiTask.CSVhandling;
using HitachiTask.FileStreaming;
using HitachiTask.Language;

namespace HitachiTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string endProgramm = "1";

            bool changeLanguage = true;
            bool isEnglish = true;
            Console.WriteLine("Language selection: Please enter 1 for English or enter any other key for German." +
                "\nSprachauswahl: Bitte drücken Sie 1 für Englisch, oder drücken Sie eine beliebige andere Taste für Deutch");
            int language = int.Parse(Console.ReadLine());
            if (language == 1)
            {
                isEnglish = true;
            }
            else
            {
                isEnglish = false;
            }
            while (endProgramm == "1")
            {
                var factory = new CsvReaderFactory(isEnglish);
                var csvReader = factory.CreateCsvReader();
                List<string[]> list = csvReader.ConvertCsvFileIntoListOfArrays();
                List<int> suitableDays = csvReader.FindMostSuitableDaysForFlight(list);
                int bestDay = DataReader.FindTheMostSuitableDay(suitableDays, list);
                if(bestDay == -1)
                {
                    changeLanguage = true;
                    while (changeLanguage == true)
                    {
                        if (isEnglish)
                        {
                            Console.WriteLine("No suitable days for a flight.");
                            Console.WriteLine("Enter 0 to switch to German");
                            Console.WriteLine("Press 1 to continue using the program." +
                                "\nPress any other button to end the program.");
                        }
                        else
                        {
                            Console.WriteLine("Keine passenden Tage für einen Flug.");
                            Console.WriteLine("Geben Sie 0 ein, um zu Englisch zu wechseln");
                            Console.WriteLine("Drücken Sie 1, um das Programm weiter zu verwenden." +
                                "\nDrücken Sie eine beliebige andere Taste, um das Programm zu beenden.");
                        }
                        string input = Console.ReadLine();
                        if (input == "0")
                        {
                            isEnglish = LanguageChanger.ChangeLanguage(isEnglish);
                        }
                        else
                        {
                            changeLanguage = false;
                            endProgramm = input;
                        }
                    }
                    continue;
                }
                string[][] table = list.ToArray();
                string[][] csvFileTable = TableCreator.GenerateTable(table, bestDay);

                string result = "";
                changeLanguage = true;
                while (changeLanguage == true)
                {
                    if (isEnglish)
                    {
                        Console.WriteLine("Enter 0 to switch to German");
                        Console.WriteLine("Do you want to send the file via gmail?" +
                            "\nPlease, press 1 for yes" +
                            "\nPlease, press 2 for no");
                    }
                    else
                    {
                        Console.WriteLine("Geben Sie 0 ein, um zu Englisch zu wechseln");
                        Console.WriteLine("Möchten Sie die Datei per Gmail versenden?" +
                            "\nBitte geben Sie 1 für Ja ein" +
                            "\nBitte geben Sie eine beliebige andere Taste für Nein ein");
                    }
                    string input = Console.ReadLine();
                    if (input == "0")
                    {
                        isEnglish = LanguageChanger.ChangeLanguage(isEnglish);
                    }
                    else
                    {
                        changeLanguage = false;
                        result = input;
                    }
                }    
                
                if (result == "1")
                {
                    changeLanguage = true;
                    string senderEmail = "";
                    while (changeLanguage == true)
                    {
                        if (isEnglish)
                        {
                            Console.WriteLine("Enter 0 to switch to German");
                            Console.WriteLine("Please, enter your Gmail");
                        }
                        else
                        {
                            Console.WriteLine("Geben Sie 0 ein, um zu Englisch zu wechseln");
                            Console.WriteLine("Bitte geben Sie Ihr Gmail-Konto ein");
                        }
                        string input = Console.ReadLine();
                        if (input == "0")
                        {
                            isEnglish = LanguageChanger.ChangeLanguage(isEnglish);
                        }
                        else
                        {
                            changeLanguage = false;
                            senderEmail = input;
                        }
                    }

                    changeLanguage = true;
                    string senderPassword = "";
                    while (changeLanguage == true)
                    {
                        if (isEnglish)
                        {
                            Console.WriteLine("Enter 0 to switch to German");
                            Console.WriteLine("Please, enter your Gmail app password");
                        }
                        else
                        {
                            Console.WriteLine("Geben Sie 0 ein, um zu Englisch zu wechseln");
                            Console.WriteLine("Bitte geben Sie Ihr Gmail-App-Passwort ein");
                        }
                        string input = Console.ReadLine();
                        if (input == "0")
                        {
                            isEnglish = LanguageChanger.ChangeLanguage(isEnglish);
                        }
                        else
                        {
                            changeLanguage = false;
                            senderPassword = input;
                        }
                    }

                    changeLanguage = true;
                    string recipientEmail = "";
                    while (changeLanguage == true)
                    {
                        if (isEnglish)
                        {
                            Console.WriteLine("Enter 0 to switch to German");
                            Console.WriteLine("Please, enter the email address, where you want to send the file to");
                        }
                        else
                        {
                            Console.WriteLine("Geben Sie 0 ein, um zu Englisch zu wechseln");
                            Console.WriteLine("Bitte geben Sie die E-Mail-Adresse ein, an die Sie die Datei senden möchten");
                        }
                        string input = Console.ReadLine();
                        if (input == "0")
                        {
                            isEnglish = LanguageChanger.ChangeLanguage(isEnglish);
                        }
                        else
                        {
                            changeLanguage = false;
                            recipientEmail = input;
                        }
                    }
                    FileStreamer.SendDirectlyToEmail(csvFileTable, senderEmail,senderPassword, recipientEmail, isEnglish, bestDay);
                }

                changeLanguage = true;
                while (changeLanguage == true)
                {
                    if (isEnglish)
                    {
                        Console.WriteLine("Enter 0 to switch to German");
                        Console.WriteLine("Press 1 to continue using the program." +
                            "\nPress any other button to end the program.");
                    }
                    else
                    {
                        Console.WriteLine("Geben Sie 0 ein, um zu Englisch zu wechseln");
                        Console.WriteLine("Drücken Sie 1, um das Programm weiter zu verwenden." +
                            "\nDrücken Sie eine beliebige andere Taste, um das Programm zu beenden.");
                    }
                    string input = Console.ReadLine();
                    if (input == "0")
                    {
                        isEnglish = LanguageChanger.ChangeLanguage(isEnglish);
                    }
                    else
                    {
                        changeLanguage = false;
                        endProgramm = input;
                    }
                }
            }
        }
    }
}