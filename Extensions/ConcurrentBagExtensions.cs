﻿using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Test.WindowsServiceWithHealthcheck.Extensions
{
	public static class ConcurrentBagExtensions
	{
		public static void AddRange<T>(this ConcurrentBag<T> @this, IEnumerable<T> toAdd)
		{
			foreach (var element in toAdd)
			{
				@this.Add(element);
			}
		}
	}
}
