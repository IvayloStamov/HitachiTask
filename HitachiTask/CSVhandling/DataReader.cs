namespace HitachiTask.CSVhandling
{
    public static class DataReader
    {
        public static int FindTheMostSuitableDay(List<int> indexes, List<string[]> list)
        {
            if (indexes.Count == 0)
            {
                return -1;
            }
            if (indexes.Count == 1)
            {
                return indexes[0];
            }
            List<int> lowestWindSpeedDays = FindLowestWindSpeed(indexes, list);
            List<int> lowestHumidityDays = FindLowestHumidity(lowestWindSpeedDays, list);

            return lowestHumidityDays[0];

        }

        private static List<int> FindLowestWindSpeed(List<int> indexes, List<string[]> list)
        {
            List<int> lowestWindSpeedIndexes = new List<int>();
            int lowestWindSpeed = int.MaxValue;

            string[][] table = list.ToArray();
            foreach (var array in table)
            {
                if (array[0] == "Wind (m/s)")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (indexes.Contains(i))
                        {
                            int current;
                            if (int.TryParse(array[i], out current))
                            {
                                if (lowestWindSpeed > current)
                                {
                                    lowestWindSpeedIndexes.Clear();
                                    lowestWindSpeedIndexes.Add(i);
                                    lowestWindSpeed = current;
                                }
                                else if (lowestWindSpeed == current)
                                {
                                    lowestWindSpeedIndexes.Add(i);
                                }
                            }
                        }
                    }
                }
            }
            return lowestWindSpeedIndexes;
        }

        private static List<int> FindLowestHumidity(List<int> indexes, List<string[]> list)
        {
            List<int> lowestHumidityIndexes = new List<int>();
            int lowestHumidity = int.MaxValue;

            string[][] table = list.ToArray();
            foreach (var array in table)
            {
                if (array[0] == "Humidity (%)")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (indexes.Contains(i))
                        {
                            int current;
                            if (int.TryParse(array[i], out current))
                            {
                                if (lowestHumidity > current)
                                {
                                    lowestHumidityIndexes.Clear();
                                    lowestHumidityIndexes.Add(i);
                                    lowestHumidity = current;
                                }
                                else if (lowestHumidity == current)
                                {
                                    lowestHumidityIndexes.Add(i);
                                }
                            }
                        }
                    }
                }
            }
            return lowestHumidityIndexes;
        }
    }
}
