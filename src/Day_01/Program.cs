using Utils;

string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var inputList = ReadData.AsInt(inputPath);

//--- Day 1: Sonar Sweep ---

void PartA()
{
    var count = GetIncreasedCount(inputList);

    Console.WriteLine($"Part A: Result is {count}");
}

void PartB()
{
    var windowSum = new List<int>();

    for (int i = 0; i < inputList.Count; i++)
    {
        if (i + 3 > inputList.Count)
        {
            break;
        }
        windowSum.Add(inputList[i] + inputList[i + 1] + inputList[i + 2]);
    }
    var count = GetIncreasedCount(windowSum);

    Console.WriteLine($"Part B: Result is {count}");
}

int GetIncreasedCount(IReadOnlyList<int> list)
{
    var count = 0;
    for (int i = 1; i < list.Count; i++)
    {
        if (list[i - 1] < list[i])
        {
            count++;
        }
    }

    return count;
}

PartA();
PartB();