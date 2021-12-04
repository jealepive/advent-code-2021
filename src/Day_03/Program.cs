using Utils;

var inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var rawInput = ReadData.AsString(inputPath);
var diagnosticReport = rawInput.Select(x => x.ToCharArray());
var bitsWidth = diagnosticReport.First().Length;

//---Day 3: Binary Diagnostic ---

void PartA()
{
    var onesCountPerBit = new int[bitsWidth];

    for (int i = 0; i < diagnosticReport.Count(); i++)
    {
        for (int j = 0; j < bitsWidth; j++)
        {
            if (diagnosticReport.ElementAt(i).ElementAt(j) == '1')
            {
                onesCountPerBit[j]++;
            }
        }
    }

    var gammaRate = onesCountPerBit.Select(onesCount => onesCount > diagnosticReport.Count() / 2 ? '1' : '0');
    var epsilonRate = onesCountPerBit.Select(onesCount => onesCount < diagnosticReport.Count() / 2 ? '1' : '0');
    var powerConsumption = BinaryToDecimal(gammaRate) * BinaryToDecimal(epsilonRate);

    Console.WriteLine($"Part A: Result is {powerConsumption}");
}

double BinaryToDecimal(IEnumerable<char> binaryNumber)
{
    return binaryNumber.Select((bit, idx) => bit == '1' ? Math.Pow(2, (binaryNumber.Count() - 1) - idx) : 0).Sum();
}

PartA();