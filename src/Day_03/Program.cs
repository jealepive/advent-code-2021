using Utils;

var inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var rawInput = ReadData.AsString(inputPath);
var diagnosticReport = rawInput.Select(x => x.ToCharArray()).ToArray();
var bitsWidth = diagnosticReport.First().Length;

//---Day 3: Binary Diagnostic ---

void PartA()
{
	var gammaRate = new List<char>();
	var epsilonRate = new List<char>();

	for (var bitPosition = 0; bitPosition < bitsWidth; bitPosition++)
	{
		var mostCommonBit = GetMostCommonBit(bitPosition, diagnosticReport);
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
	var oxygenReport = diagnosticReport;
	var co2Report = diagnosticReport;

	for (int bitPosition = 0; bitPosition < bitsWidth; bitPosition++)
	{
		if (oxygenReport.Length > 1)
		{
			mostCommonBit = GetMostCommonBit(bitPosition, oxygenReport);
			oxygenReport = oxygenReport.Where(binaryNumber => binaryNumber[bitPosition] == mostCommonBit).ToArray();
		}

		if (co2Report.Length > 1)
		{
			leastCommonBit = GetLeastCommonBit(bitPosition, co2Report);
			co2Report = co2Report.Where(binaryNumber => binaryNumber[bitPosition] == leastCommonBit).ToArray();
		}
	}

	oxygenGeneratorRating = oxygenReport[0];
	co2ScrubberRating = co2Report[0];

	var lifeSupportRating = BinaryToDecimal(oxygenGeneratorRating) * BinaryToDecimal(co2ScrubberRating);

	Console.WriteLine($"Part B: Result is {lifeSupportRating}");
}

double BinaryToDecimal(IList<char> binaryNumber) => binaryNumber.Select((bit, idx) => bit == '1' ? Math.Pow(2, binaryNumber.Count - 1 - idx) : 0).Sum();

char GetMostCommonBit(int bitPosition, char[][] binaryNumbers)
{
	var onesCountPerBit = CountOnesOccurrence(bitPosition, binaryNumbers);

	return onesCountPerBit >= binaryNumbers.Length - onesCountPerBit ? '1' : '0';
}

char GetLeastCommonBit(int bitPosition, char[][] binaryNumbers)
{
	var onesCountPerBit = CountOnesOccurrence(bitPosition, binaryNumbers);

	return onesCountPerBit >= binaryNumbers.Length - onesCountPerBit ? '0' : '1';
}

int CountOnesOccurrence(int bitPosition, char[][] binaryNumbers)
{
	var onesCountPerBit = 0;

	for (int i = 0; i < binaryNumbers.Length; i++)
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