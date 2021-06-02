using AnagramsAndPrimeNumbers;
using AnagramsAndPrimeNumbers.Performance;
using BenchmarkDotNet.Running;
using System;

BenchmarkRunner.Run<AreAnagrams>();

//for (var i = 0; i < 1000; i++)
//{
//	AnagramComparisons.GetAnagramNumberOptimizedNoArrayNoMaxCountUsingSwitchLetterDistribution(
//		"pneumonoultramicroscopicsilicovolcanoconiosis");
//}