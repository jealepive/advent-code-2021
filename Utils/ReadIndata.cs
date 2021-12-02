namespace Utils
{
    public static class ReadIndata
    {
        public static List<int> Ints(string path)
        {
            var streamReader = File.OpenText(path);
            var list = new List<int>();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                list.AddRange(line.Split(',').Select(int.Parse).ToList());
            }
            return list;
        }

        public static List<long> Longs(string path)
        {
            var streamReader = File.OpenText(path);
            var list = new List<long>();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                list.AddRange(line.Split(',').Select(long.Parse).ToList());
            }
            return list;
        }

        public static List<string> Strings(string path)
        {
            var streamReader = File.OpenText(path);
            var list = new List<string>();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                list.Add(line);
            }
            return list;
        }
    }
}