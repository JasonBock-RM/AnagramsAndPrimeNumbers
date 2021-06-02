using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Numerics;

namespace AnagramsAndPrimeNumbers.Performance
{
	[MemoryDiagnoser]
	public class GetAnagramNumbers
	{
		public IEnumerable<object> GetArguments()
		{
			yield return "battlements";
			yield return "pneumonoultramicroscopicsilicovolcanoconiosis";
		}

		[Benchmark(Baseline = true)]
		[ArgumentsSource(nameof(GetAnagramNumbers.GetArguments))]
		public BigInteger GetAnagramNumber(string value) => 
			AnagramComparisons.GetAnagramNumber(value);

		[Benchmark]
		[ArgumentsSource(nameof(GetAnagramNumbers.GetArguments))]
		public BigInteger GetAnagramNumberMinimizeBigIntegerAllocations(string value) => 
			AnagramComparisons.GetAnagramNumberMinimizeBigIntegerAllocations(value);

		//[Benchmark]
		//[ArgumentsSource(nameof(GetAnagramNumbers.GetArguments))]
		//public BigInteger GetAnagramNumberOptimizedNoArray(string value) => 
		//	AnagramComparisons.GetAnagramNumberOptimizedNoArray(value);

		//[Benchmark]
		//[ArgumentsSource(nameof(GetAnagramNumbers.GetArguments))]
		//public BigInteger GetAnagramNumberOptimizedNoArrayNoMaxCount(string value) => 
		//	AnagramComparisons.GetAnagramNumberOptimizedNoArrayNoMaxCount(value);

		//[Benchmark]
		//[ArgumentsSource(nameof(GetAnagramNumbers.GetArguments))]
		//public BigInteger GetAnagramNumberOptimizedNoArrayNoMaxCountUsingLetterDistribution(string value) => 
		//	AnagramComparisons.GetAnagramNumberOptimizedNoArrayNoMaxCountUsingLetterDistribution(value);

		//[Benchmark]
		//[ArgumentsSource(nameof(GetAnagramNumbers.GetArguments))]
		//public BigInteger GetAnagramNumberOptimizedNoArrayNoMaxCountUsingSwitchLetterDistribution(string value) =>
		//	AnagramComparisons.GetAnagramNumberOptimizedNoArrayNoMaxCountUsingSwitchLetterDistribution(value);
	}
}