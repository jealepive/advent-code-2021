namespace Utils;

public static class ReadData
{
	public static List<int> AsInt(string path)
	{
		var streamReader = File.OpenText(path);
		var list = new List<int>();
		while (streamReader.ReadLine() is { } line)
		{
			list.AddRange(line.Split(',').Select(int.Parse).ToList());
		}

		return list;
	}

	public static List<long> AsLong(string path)
	{
		var streamReader = File.OpenText(path);
		var list = new List<long>();
		while (streamReader.ReadLine() is { } line)
		{
			list.AddRange(line.Split(',').Select(long.Parse).ToList());
		}

		return list;
	}

	public static List<string> AsString(string path)
	{
		var streamReader = File.OpenText(path);
		var list = new List<string>();
		while (streamReader.ReadLine() is { } line)
		{
			list.Add(line);
		}

		return list;
	}
}