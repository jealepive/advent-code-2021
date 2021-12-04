using Utils;

var inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var rawInput = ReadData.AsString(inputPath);
var diagnosticReport = rawInput.Select(x => x.ToCharArray());
var bitsWidth = diagnosticReport.First().Length;

//---Day 3: Binary Diagnostic ---

void PartA()
{
    var gammaRate = new List<char>();
    var epsilonRate = new List<char>();
    var onesCountPerBit = new int[bitsWidth];

    for (int i = 0; i < bitsWidth; i++)
    {
        var mostCommonBit = GetMostCommonBit(i, diagnosticReport);
        gammaRate.Add(mostCommonBit);
        epsilonRate.Add(mostCommonBit == '1' ? '0' : '1');
    }

    var powerConsumption = BinaryToDecimal(gammaRate) * BinaryToDecimal(epsilonRate);

    Console.WriteLine($"Part A: Result is {powerConsumption}");
}

void PartB()
{
}

double BinaryToDecimal(IEnumerable<char> binaryNumber)
{
    return binaryNumber.Select((bit, idx) => bit == '1' ? Math.Pow(2, (binaryNumber.Count() - 1) - idx) : 0).Sum();
}

char GetMostCommonBit(int bitPosition, IEnumerable<char[]> binaryNumbers)
{
    var onesCountPerBit = CountOnesOcurrency(bitPosition, binaryNumbers);

    if (onesCountPerBit >= binaryNumbers.Count() / 2)
    {
        return '1';
    }

    return '0';
}

char GetLeastCommonBit(int bitPosition, IEnumerable<char[]> binaryNumbers)
{
    var onesCountPerBit = CountOnesOcurrency(bitPosition, binaryNumbers);

    if (onesCountPerBit <= binaryNumbers.Count() / 2)
    {
        return '0';
    }

    return '1';
}

int CountOnesOcurrency(int bitPosition, IEnumerable<char[]> binaryNumbers)
{
    var onesCountPerBit = 0;

    for (int i = 0; i < binaryNumbers.Count(); i++)
    {
        if (binaryNumbers.ElementAt(i).ElementAt(bitPosition) == '1')
        {
            onesCountPerBit++;
        }
    }

    return onesCountPerBit;
}
PartA();