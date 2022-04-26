namespace WebApplication2.Model
{
    public class Weather
    {
        private readonly List<Weather> weatherValueList;

        public Weather()
        {
            weatherValueList = new List<Weather>();
        }

        /// <summary>
        /// Температура
        /// </summary>
        public float Temperature { get; set; }

        /// <summary>
        /// Время
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Добавить дату и температуру
        /// </summary>
        /// <param name="value"></param>
        public void Add(Weather value)
        {
            weatherValueList.Add(value);
        }

        /// <summary>
        /// возвращает все данные 
        /// </summary>
        /// <returns>string</returns>
        public string Get()
        {
            return weatherValueList.Aggregate("", (current, i) 
                => current + (i.Time + " " + i.Temperature + "\n"));
        }

        /// <summary>
        /// Возвращает все значения после заданного времени
        /// </summary>
        /// <param name="time">время</param>
        /// <returns>string</returns>
        public string Get(DateTime time)
        {
            return weatherValueList.Where(i => i.Time >= time).Aggregate("", (current, i)
                => current + (i.Time + " " + i.Temperature + "\n"));
        }

        /// <summary>
        /// Обновляет значение температуры в указанную дату
        /// </summary>
        /// <param name="time">время</param>
        /// <param name="temperature">температура</param>
        public void Update(DateTime time, float temperature)
        {
            foreach (var i in weatherValueList)
            {
                if (i.Time == time)
                {
                    Console.WriteLine("OK");
                    i.Temperature = temperature;
                    break;
                }
            }
        }

        /// <summary>
        /// удаляет значение по времени
        /// </summary>
        /// <param name="time">время</param>
        public void Delete(DateTime time)
        {
            foreach (var i in weatherValueList)
            {
                if (i.Time == time)
                {
                    Console.WriteLine("Delete");
                    weatherValueList.Remove(i);
                    break;
                }
            }
        }
    }
}
