using Microsoft.VisualBasic.FileIO;

namespace HitachiTask.CSVhandling
{
    public class CsvReader
    {
        public CsvReader(string filePath, int minTemp, int maxTemp, int windSpeed, int humidity, int precipitation,
            string lightning, List<string> unacceptableClouds)
        {
            FilePath = filePath;
            MinTemp = minTemp;
            MaxTemp = maxTemp;
            WindSpeed = windSpeed;  
            Humidity = humidity;
            Precipitation = precipitation;
            Lightning = lightning;
            UnacceptableClouds = unacceptableClouds;
        }
        public CsvReader(string filePath)
        {
            FilePath = filePath;
        }
        public string FilePath { get; set; }
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }
        public int WindSpeed { get; set; }
        public int Humidity { get; set; }
        public int Precipitation { get; set; }
        public string Lightning { get; set; }
        public List<string> UnacceptableClouds { get; set; } = new List<string>();

        List<int> suitableDays = new List<int>();
        List<string[]> list = new List<string[]>();

        public bool TryReadingFile(string successMessage, string failMessage)
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(FilePath))
                {
                    Console.WriteLine(successMessage);
                    return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine(failMessage);
                return false;
            }
        }
        public List<int> FindMostSuitableDaysForFlight(List<string[]> list)
        {
            string[][] table = list.ToArray();
            foreach (var array in table)
            {
                if (array[0] == "Temperature (C)")
                {
                    for (int i = 1; i < array.Length; i++)
                    {
                        int current;
                        if (int.TryParse(array[i], out current))
                        {
                            if (current >= MinTemp && current <= MaxTemp)
                            {
                                suitableDays.Add(i);
                            }
                        }
                    }
                }
                else if (array[0] == "Wind (m/s)")
                {
                    for (int i = 1; i < array.Length; i++)
                    {
                        if (!suitableDays.Contains(i))
                        {
                            continue;
                        }
                        else
                        {
                            int current;
                            if (int.TryParse(array[i], out current))
                            {
                                if (current > WindSpeed)
                                {
                                    suitableDays.Remove(i);
                                }
                            }
                        }
                    }
                }
                else if (array[0] == "Humidity (%)")
                {
                    for (int i = 1; i < array.Length; i++)
                    {
                        if (!suitableDays.Contains(i))
                        {
                            continue;
                        }
                        else
                        {
                            int current;
                            if (int.TryParse(array[i], out current))
                            {
                                if (current > Humidity)
                                {
                                    suitableDays.Remove(i);
                                }
                            }
                        }
                    }
                }
                else if (array[0] == "Precipitation (%)")
                {
                    for (int i = 1; i < array.Length; i++)
                    {
                        if (!suitableDays.Contains(i))
                        {
                            continue;
                        }
                        else
                        {
                            int current;
                            if (int.TryParse(array[i], out current))
                            {
                                if (current > Precipitation)
                                {
                                    suitableDays.Remove(i);
                                }
                            }
                        }
                    }
                }
                else if (array[0] == "Lightning")
                {
                    for (int i = 1; i < array.Length; i++)
                    {
                        if (!suitableDays.Contains(i))
                        {
                            continue;
                        }
                        else
                        {
                            if (array[i] == "Yes" && Lightning == "Yes")
                            {
                                suitableDays.Remove(i);
                            }
                        }
                    }
                }
                else if (array[0] == "Clouds")
                {
                    for (int i = 1; i < array.Length; i++)
                    {
                        if (!suitableDays.Contains(i))
                        {
                            array[i] = "Not today";
                            continue;
                        }
                        else
                        {
                            if (UnacceptableClouds.Contains(array[i]))
                            {
                                suitableDays.Remove(i);
                            }
                        }
                    }
                }
            }
            return suitableDays;
        }

        public List<string[]> ConvertCsvFileIntoListOfArrays()
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(FilePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        list.Add(fields);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    }
}