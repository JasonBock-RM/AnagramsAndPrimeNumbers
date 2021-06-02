using System;
using System.Collections.Generic;
using System.Numerics;

namespace AnagramsAndPrimeNumbers
{
	public static class AnagramComparisons
	{
		private static readonly Dictionary<char, BigInteger> mappings = new()
		{
			{ 'a', 2 },
			{ 'b', 3 },
			{ 'c', 5 },
			{ 'd', 7 },
			{ 'e', 11 },
			{ 'f', 13 },
			{ 'g', 17 },
			{ 'h', 19 },
			{ 'i', 23 },
			{ 'j', 29 },
			{ 'k', 31 },
			{ 'l', 37 },
			{ 'm', 41 },
			{ 'n', 43 },
			{ 'o', 47 },
			{ 'p', 53 },
			{ 'q', 59 },
			{ 'r', 61 },
			{ 's', 67 },
			{ 't', 71 },
			{ 'u', 73 },
			{ 'v', 79 },
			{ 'w', 83 },
			{ 'x', 89 },
			{ 'y', 97 },
			{ 'z', 101 },
		};

		private static readonly Dictionary<char, ulong> mappingsOptimizedUsingUInt64 = new()
		{
			{ 'a', 2 },
			{ 'b', 3 },
			{ 'c', 5 },
			{ 'd', 7 },
			{ 'e', 11 },
			{ 'f', 13 },
			{ 'g', 17 },
			{ 'h', 19 },
			{ 'i', 23 },
			{ 'j', 29 },
			{ 'k', 31 },
			{ 'l', 37 },
			{ 'm', 41 },
			{ 'n', 43 },
			{ 'o', 47 },
			{ 'p', 53 },
			{ 'q', 59 },
			{ 'r', 61 },
			{ 's', 67 },
			{ 't', 71 },
			{ 'u', 73 },
			{ 'v', 79 },
			{ 'w', 83 },
			{ 'x', 89 },
			{ 'y', 97 },
			{ 'z', 101 },
		};

		public static bool AreAnagramsViaGetAnagramNumber(string value1, string value2)
		{
			if (value1 is null) throw new ArgumentNullException(nameof(value1));
			if (value2 is null) throw new ArgumentNullException(nameof(value2));

			return value1.GetAnagramNumber() == value2.GetAnagramNumber();
		}

		public static bool AreAnagramsViaGetAnagramNumberMinimizeBigIntegerAllocations(string value1, string value2)
		{
			if (value1 is null) throw new ArgumentNullException(nameof(value1));
			if (value2 is null) throw new ArgumentNullException(nameof(value2));

			return value1.GetAnagramNumberMinimizeBigIntegerAllocations() == value2.GetAnagramNumberMinimizeBigIntegerAllocations();
		}

		public static bool AreAnagramsViaGetAnagramNumberRemoveMaxCount(string value1, string value2)
		{
			if (value1 is null) throw new ArgumentNullException(nameof(value1));
			if (value2 is null) throw new ArgumentNullException(nameof(value2));

			return value1.GetAnagramNumberRemoveMaxCount() == value2.GetAnagramNumberRemoveMaxCount();
		}

		public static bool AreAnagramsViaGetAnagramNumberUsingSwitchLetterDistribution(string value1, string value2)
		{
			if (value1 is null) throw new ArgumentNullException(nameof(value1));
			if (value2 is null) throw new ArgumentNullException(nameof(value2));

			if (value1.Length != value2.Length) { return false; }

			return value1.GetAnagramNumberUsingSwitchLetterDistribution() == value2.GetAnagramNumberUsingSwitchLetterDistribution();
		}

		public static bool AreAnagramsViaArraySort(string value1, string value2)
		{
			if (value1 is null) throw new ArgumentNullException(nameof(value1));
			if (value2 is null) throw new ArgumentNullException(nameof(value2));

			if (value1.Length != value2.Length) { return false; }

			var content1 = value1.ToCharArray();
			Array.Sort(content1);
			var content2 = value2.ToCharArray();
			Array.Sort(content2);

			for (var i = 0; i < value1.Length; i++)
			{
				if(content1[i] != content2[i]) { return false; }
			}

			return true;
		}

		public static BigInteger GetAnagramNumber(this string self)
		{
			if (self is null) throw new ArgumentNullException(nameof(self));

			var value = BigInteger.One;

			foreach (var piece in self)
			{
				value *= AnagramComparisons.mappings[piece];
			}

			return value;
		}

		public static BigInteger GetAnagramNumberMinimizeBigIntegerAllocations(this string self)
		{
			if (self is null) throw new ArgumentNullException(nameof(self));

			const int MaxCount = 9;

			var currentValue = 1ul;
			var value = BigInteger.One;

			for (var i = 0; i < self.Length; i++)
			{
				currentValue *= AnagramComparisons.mappingsOptimizedUsingUInt64[self[i]];
				var currentValueIndex = i % MaxCount;

				if ((i == self.Length - 1) || (currentValueIndex == 0 && i > 0))
				{
					value *= currentValue;
					currentValue = 1ul;
				}
			}

			return value;
		}

		public static BigInteger GetAnagramNumberRemoveMaxCount(this string self)
		{
			if (self is null) throw new ArgumentNullException(nameof(self));

			const ulong MaximumValue = 182_641_030_432_767_837;

			var currentValue = 1ul;
			var value = BigInteger.One;

			for (var i = 0; i < self.Length; i++)
			{
				currentValue *= AnagramComparisons.mappingsOptimizedUsingUInt64[self[i]];

				if ((i == self.Length - 1) || (currentValue > MaximumValue))
				{
					value *= currentValue;
					currentValue = 1ul;
				}
			}

			return value;
		}

		public static BigInteger GetAnagramNumberUsingSwitchLetterDistribution(this string self)
		{
			if (self is null) throw new ArgumentNullException(nameof(self));

			const ulong MaximumValue = 182_641_030_432_767_837;

			var currentValue = 1ul;
			var value = BigInteger.One;

			for (var i = 0; i < self.Length; i++)
			{
				currentValue *= self[i] switch
				{
					'e' => 2,
					's' => 3,
					'i' => 5,
					'a' => 7,
					'r' => 11,
					'n' => 13,
					't' => 17,
					'o' => 19,
					'l' => 23,
					'c' => 29,
					'd' => 31,
					'u' => 37,
					'g' => 41,
					'p' => 43,
					'm' => 47,
					'h' => 53,
					'b' => 59,
					'y' => 61,
					'f' => 67,
					'v' => 71,
					'k' => 73,
					'w' => 79,
					'z' => 83,
					'x' => 89,
					'j' => 97,
					'q' => 101,
					_ => throw new NotSupportedException()
				};

				if ((i == self.Length - 1) || (currentValue > MaximumValue))
				{
					value *= currentValue;
					currentValue = 1ul;
				}
			}

			return value;
		}
	}
}