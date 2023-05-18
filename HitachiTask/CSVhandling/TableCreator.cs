namespace HitachiTask.CSVhandling
{
    public static class TableCreator
    {
        public static string[][] GenerateTable(string[][] table, int index)
        {
            var rows = new string[] { "Parameter", "Temperature (C)", "Wind (m/s)", "Humidity (%)", "Precipitation (%)", "Lightning", "Clouds" };
            var columns = new string[] { "Average Value", "Max Value", "Min Value", "Median Value", "MALDPV" };
            string[][] csvTable = new string[rows.Length][];
            for (int i = 0; i < csvTable.Length; i++)
            {
                csvTable[i] = new string[columns.Length + 1];
                csvTable[i][0] = rows[i];
            }
            for (int i = 1; i < csvTable[0].Length; i++)
            {
                csvTable[0][i] = columns[i - 1];
            }

            foreach (var array in table)
            {
                if (array[0] == "Temperature (C)")
                {
                    csvTable[1][1] = FindAverageValue(array);
                    csvTable[1][2] = FindMaxValue(array);
                    csvTable[1][3] = FindMinValue(array);
                    csvTable[1][4] = FindMedianValue(array);
                    csvTable[1][5] = MostAppropriateValue(array, index);
                }
                else if (array[0] == "Wind (m/s)")
                {
                    csvTable[2][1] = FindAverageValue(array);
                    csvTable[2][2] = FindMaxValue(array);
                    csvTable[2][3] = FindMinValue(array);
                    csvTable[2][4] = FindMedianValue(array);
                    csvTable[2][5] = MostAppropriateValue(array, index);
                }
                else if (array[0] == "Humidity (%)")
                {
                    csvTable[3][1] = FindAverageValue(array);
                    csvTable[3][2] = FindMaxValue(array);
                    csvTable[3][3] = FindMinValue(array);
                    csvTable[3][4] = FindMedianValue(array);
                    csvTable[3][5] = MostAppropriateValue(array, index);
                }
                else if (array[0] == "Precipitation (%)")
                {
                    csvTable[4][1] = FindAverageValue(array);
                    csvTable[4][2] = FindMaxValue(array);
                    csvTable[4][3] = FindMinValue(array);
                    csvTable[4][4] = FindMedianValue(array);
                    csvTable[4][5] = MostAppropriateValue(array, index);
                }
                else if (array[0] == "Lightning")
                {
                    csvTable[5][1] = "";
                    csvTable[5][2] = "";
                    csvTable[5][3] = "";
                    csvTable[5][4] = "";
                    csvTable[5][5] = MostAppropriateValue(array, index);
                }
                else if (array[0] == "Clouds")
                {
                    csvTable[6][1] = "";
                    csvTable[6][2] = "";
                    csvTable[6][3] = "";
                    csvTable[6][4] = "";
                    csvTable[6][5] = MostAppropriateValue(array, index);
                }
            }
            return csvTable;
        }
        public static string FindAverageValue(string[] array)
        {

            double average = 0;
            int[] intArray = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int.TryParse(array[i], out intArray[i]);
            }
            foreach (var value in intArray)
            {
                average += value;
            }
            average = Math.Round(average / (array.Length - 1), 2);
            return average.ToString();
        }

        public static string FindMinValue(string[] array)
        {
            int minValue = int.MaxValue;
            int currentValue;
            for (int i = 1; i < array.Length; i++)
            {
                int.TryParse(array[i], out currentValue);
                if (minValue > currentValue)
                {
                    minValue = currentValue;
                }
            }
            return minValue.ToString();
        }

        public static string FindMaxValue(string[] array)
        {
            int maxValue = int.MinValue;
            int currentValue;
            for (int i = 1; i < array.Length; i++)
            {
                int.TryParse(array[i], out currentValue);
                if (maxValue < currentValue)
                {
                    maxValue = currentValue;
                }
            }
            return maxValue.ToString();
        }

        public static string FindMedianValue(string[] array)
        {
            double median = 0;
            List<string> values = array.ToList();
            values.RemoveAt(0);
            values.Sort();

            if (values.Count % 2 == 0)
            {
                int middle = values.Count / 2;
                median = int.Parse(array[middle]) + int.Parse(values[middle - 1]) / 2;
                median = Math.Round(median, 2);
            }
            else
            {
                int middle = values.Count / 2;
                median = int.Parse(values[middle]);
            }
            return median.ToString();
        }

        public static string MostAppropriateValue(string[] array, int index)
        {
            string mostAppropriate = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (i == index)
                {
                    mostAppropriate = array[i];
                }
            }
            return mostAppropriate;
        }
    }
}