using Utils;

var inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var rawInputList = ReadData.AsString(inputPath);
var movementsList = rawInputList
	.Select(x =>
	{
		var t = x.Split(' ');
		return (command: t[0], units: int.Parse(t[1]));
	})
	.ToList();

//--- Day 2: Dive! ---

void PartA()
{
	var currentPosition = (horizontal: 0, depth: 0);

	foreach (var (command, units) in movementsList)
	{
		switch (command)
		{
			case "forward":
				currentPosition.horizontal += units;
				break;

			case "down":
				currentPosition.depth += units;
				break;

			case "up":
				currentPosition.depth -= units;
				break;
		}
	}

	Console.WriteLine($"Part A: Result is {currentPosition.depth * currentPosition.horizontal}");
}

void PartB()
{
	var currentPosition = (horizontal: 0, depth: 0, aim: 0);

	foreach (var (command, units) in movementsList)
	{
		switch (command)
		{
			case "forward":
				currentPosition.horizontal += units;
				currentPosition.depth += currentPosition.aim * units;
				break;

			case "down":
				currentPosition.aim += units;
				break;

			case "up":
				currentPosition.aim -= units;
				break;
		}
	}

	Console.WriteLine($"Part B: Result is {currentPosition.depth * currentPosition.horizontal}");
}

PartA();
PartB();