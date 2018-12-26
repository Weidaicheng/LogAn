namespace LogAn
{
    public static class TimeLogger
    {
        public static string CreateMessage(string info)
        {
            return $"{SystemTime.Now.ToString("yyyy-MM-dd")} {info}";
        }
    }
}