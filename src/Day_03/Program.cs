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
    char mostCommonBit;

    for (int bitPosition = 0; bitPosition < bitsWidth; bitPosition++)
    {
        mostCommonBit = GetMostCommonBit(bitPosition, diagnosticReport);
        gammaRate.Add(mostCommonBit);
        epsilonRate.Add(mostCommonBit == '1' ? '0' : '1');
    }

    var powerConsumption = BinaryToDecimal(gammaRate) * BinaryToDecimal(epsilonRate);

    Console.WriteLine($"Part A: Result is {powerConsumption}");
}

void PartB()
{
    var oxygenGeneratorRating = new char[bitsWidth];
    var co2ScrubberRating = new char[bitsWidth];
    char mostCommonBit;
    char leastCommonBit;
    var oxygenReport = diagnosticReport.ToList();
    var co2Report = diagnosticReport.ToList();

    for (int bitPosition = 0; bitPosition < bitsWidth; bitPosition++)
    {
        if (oxygenReport.Count > 1)
        {
            mostCommonBit = GetMostCommonBit(bitPosition, oxygenReport);
            oxygenReport = oxygenReport.Where(binaryNumber => binaryNumber[bitPosition] == mostCommonBit).ToList();
        }

        if (co2Report.Count > 1)
        {
            leastCommonBit = GetLeastCommonBit(bitPosition, co2Report);
            co2Report = co2Report.Where(binaryNumber => binaryNumber[bitPosition] == leastCommonBit).ToList();
        }
    }

    oxygenGeneratorRating = oxygenReport[0];
    co2ScrubberRating = co2Report[0];

    var lifeSupportRating = BinaryToDecimal(oxygenGeneratorRating) * BinaryToDecimal(co2ScrubberRating);

    Console.WriteLine($"Part B: Result is {lifeSupportRating}");
}

double BinaryToDecimal(IEnumerable<char> binaryNumber)
{
    return binaryNumber.Select((bit, idx) => bit == '1' ? Math.Pow(2, (binaryNumber.Count() - 1) - idx) : 0).Sum();
}

char GetMostCommonBit(int bitPosition, IEnumerable<char[]> binaryNumbers)
{
    var onesCountPerBit = CountOnesOcurrency(bitPosition, binaryNumbers);

    if (onesCountPerBit >= binaryNumbers.Count() - onesCountPerBit)
    {
        return '1';
    }

    return '0';
}

char GetLeastCommonBit(int bitPosition, IEnumerable<char[]> binaryNumbers)
{
    var onesCountPerBit = CountOnesOcurrency(bitPosition, binaryNumbers);

    if (onesCountPerBit >= binaryNumbers.Count() - onesCountPerBit)
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
PartB();