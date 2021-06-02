using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace AnagramsAndPrimeNumbers.Performance
{
	[MemoryDiagnoser]
	public class AreAnagrams
	{
		// All of these are 
		public IEnumerable<object[]> GetArguments()
		{
			yield return new[] { "cdeab", "daebc" };
			yield return new[] { "mentsbatte", "stnemettab" };
			yield return new[] { "pneumonoultramicroscopicsilicovolcanoconiosis", "silicovolcanoconiosispneumonoultramicroscopic" };
		}

		[Benchmark(Baseline = true)]
		[ArgumentsSource(nameof(AreAnagrams.GetArguments))]
		public bool AreAnagramsViaArraySort(string value1, string value2) =>
			AnagramComparisons.AreAnagramsViaArraySort(value1, value2);

		[Benchmark]
		[ArgumentsSource(nameof(AreAnagrams.GetArguments))]
		public bool AreAnagramsViaGetAnagramNumber(string value1, string value2) =>
			AnagramComparisons.AreAnagramsViaGetAnagramNumber(value1, value2);

		[Benchmark]
		[ArgumentsSource(nameof(AreAnagrams.GetArguments))]
		public bool AreAnagramsViaGetAnagramNumberMinimizeBigIntegerAllocations(string value1, string value2) =>
			AnagramComparisons.AreAnagramsViaGetAnagramNumberMinimizeBigIntegerAllocations(value1, value2);

		[Benchmark]
		[ArgumentsSource(nameof(AreAnagrams.GetArguments))]
		public bool AreAnagramsViaGetAnagramNumberRemoveMaxCount(string value1, string value2) =>
			AnagramComparisons.AreAnagramsViaGetAnagramNumberRemoveMaxCount(value1, value2);

		[Benchmark]
		[ArgumentsSource(nameof(AreAnagrams.GetArguments))]
		public bool AreAnagramsViaGetAnagramNumberUsingSwitchLetterDistribution(string value1, string value2) =>
			AnagramComparisons.AreAnagramsViaGetAnagramNumberUsingSwitchLetterDistribution(value1, value2);
	}
}