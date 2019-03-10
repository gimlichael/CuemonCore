﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Cuemon.Collections.Generic
{
	/// <summary>
	/// This utility class provides a set of static methods for querying objects that implement <see cref="IEnumerable{T}"/>. 
	/// </summary>
	public static class EnumerableUtility
	{
        /// <summary>
        /// Returns a random element of a sequence of elements, or a default value if no element is found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to return a random element of.</param>
        /// <returns>default(TSource) if source is empty; otherwise, a random element of <paramref name="source"/>.</returns>
        public static TSource RandomOrDefault<TSource>(IEnumerable<TSource> source)
	    {
            Validator.ThrowIfNull(source, nameof(source));
	        return RandomOrDefault(source, DefaultRandomizer);
	    }

        /// <summary>
        /// Returns a random element of a sequence of elements, or a default value if no element is found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to return a random element of.</param>
        /// <param name="randomizer">The function delegate that will select a random element of <paramref name="source"/>.</param>
        /// <returns>default(TSource) if source is empty; otherwise, a random element of <paramref name="source"/>.</returns>
        public static TSource RandomOrDefault<TSource>(IEnumerable<TSource> source, Func<IEnumerable<TSource>, TSource> randomizer)
	    {
	        Validator.ThrowIfNull(source, nameof(source));
            Validator.ThrowIfNull(randomizer, nameof(randomizer));
            return randomizer(source);
	    }

        private static TSource DefaultRandomizer<TSource>(IEnumerable<TSource> source)
	    {
            if (source == null) { return default(TSource); }
            ICollection<TSource> collection = source as ICollection<TSource> ?? new List<TSource>(source);
            return collection.Count == 0 ? default(TSource) : collection.ElementAt(NumberUtility.GetRandomNumber(collection.Count));
	    }

        /// <summary>
        /// Generates a sequence of <typeparamref name="T"/> within a specified range.
        /// </summary>
        /// <typeparam name="T">The type of the elements to return.</typeparam>
        /// <param name="count">The number of objects of <typeparamref name="T"/> to generate.</param>
        /// <param name="resolver">The function delegate that will resolve the value of <typeparamref name="T"/>; the parameter passed to the delegate represents the index of the element to return.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains a range of <typeparamref name="T"/> elements.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="count"/> is less than 0.
        /// </exception>
	    public static IEnumerable<T> RangeOf<T>(int count, Func<int, T> resolver) 
	    {
            if (count < 0) { throw new ArgumentOutOfRangeException(nameof(count)); }
            for (int i = 0; i < count; i++) { yield return resolver(i); }

	    }

        /// <summary>
        /// Returns a chunked <see cref="IEnumerable{T}"/> sequence with a maximum of 128 elements.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}" /> to chunk into smaller slices for a batch run or similar.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> that contains no more than 128 elements from the <paramref name="source" /> sequence.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="source"/> is null.
        /// </exception>
        /// <remarks>The original <paramref name="source"/> is reduced equivalent to the number of elements in the returned sequence.</remarks>
        public static IEnumerable<TSource> Chunk<TSource>(ref IEnumerable<TSource> source)
        {
            return Chunk(ref source, 128);
        }

        /// <summary>
        /// Returns a chunked <see cref="IEnumerable{T}"/> sequence with a maximum of the specified <paramref name="size"/>. Default is 128.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}" /> to chunk into smaller slices for a batch run or similar.</param>
        /// <param name="size">The amount of elements to process at a time.</param>
        /// <returns>An <see cref="IEnumerable{T}" /> that contains no more than the specified <paramref name="size" /> of elements from the <paramref name="source" /> sequence.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="source"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="size"/> is less or equal to 0.
        /// </exception>
        /// <remarks>The original <paramref name="source"/> is reduced equivalent to the number of elements in the returned sequence.</remarks>
        public static IEnumerable<TSource> Chunk<TSource>(ref IEnumerable<TSource> source, int size)
        {
            int processedCount;
            return Chunk(ref source, size, out processedCount);
        }

        internal static IEnumerable<TSource> Chunk<TSource>(ref IEnumerable<TSource> source, int size, out int processedCount)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            if (size <= 0) { throw new ArgumentException("Value must be greater than 0.", nameof(size)); }
            List<TSource> pending = new List<TSource>(source);
            List<TSource> processed = new List<TSource>();
            size = size - 1;
            for (int i = 0; i < pending.Count; i++)
            {
                processed.Add(pending[i]);
                if (i >= size) { break; }
            }
            processedCount = processed.Count;
            pending.RemoveRange(0, processedCount);
            source = pending;
            return processed;
        }

		/// <summary>
        /// Concatenates the specified sequences in <paramref name="sources"/> into one sequence.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of the input sequences of <see paramref="sources"/>.</typeparam>
		/// <param name="sources">The sequences to concatenate into one <see cref="IEnumerable{T}"/>.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains the concatenated elements of the specified sequences in <paramref name="sources"/>.</returns>
		public static IEnumerable<TSource> Concat<TSource>(params IEnumerable<TSource>[] sources)
		{
			foreach (IEnumerable<TSource> source in sources)
			{
				foreach (TSource type in source)
				{
					yield return type;
				}
			}
		}

        /// <summary>
        /// Determines whether a sequence contains a specified element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the <see cref="IEnumerable{T}"/> of <see paramref="source"/>.</typeparam>
        /// <param name="source">A sequence in which to locate a value.</param>
        /// <param name="value">The value to locate in the sequence.</param>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <returns>
        /// 	<c>true</c> if the source sequence contains an element that has the specified value; otherwise, <c>false</c>.
        /// </returns>
        public static bool Contains<TSource>(IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            Validator.ThrowIfNull(source, nameof(source));
            Validator.ThrowIfNull(comparer, nameof(comparer));
            return Contains(source, value, comparer.Equals);
        }

        /// <summary>
        /// Determines whether a sequence contains a specified element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the <see cref="IEnumerable{T}"/> of <see paramref="source"/>.</typeparam>
        /// <param name="source">A sequence in which to locate a value.</param>
        /// <param name="value">The value to locate in the sequence.</param>
        /// <param name="condition">The function delegate that will compare values from the <paramref name="source"/> sequence with <paramref name="value"/>.</param>
        /// <returns>
        /// 	<c>true</c> if the source sequence contains an element that has the specified value; otherwise, <c>false</c>.
        /// </returns>
        public static bool Contains<TSource>(IEnumerable<TSource> source, TSource value, Func<TSource, TSource, bool> condition)
        {
            Validator.ThrowIfNull(source, nameof(source));
            Validator.ThrowIfNull(condition, nameof(condition));
            foreach (TSource item in source)
            {
                if (condition(value, item))
                {
                    return true;
                }
            }
            return false;
        }

	    /// <summary>
	    /// Returns an <see cref="IEnumerable{T}"/> sequence with the specified <paramref name="source"/> as the only element.
	    /// </summary>
	    /// <typeparam name="TSource">The type of <paramref name="source"/>.</typeparam>
	    /// <param name="source">The value to yield into an <see cref="IEnumerable{T}"/> sequence.</param>
	    /// <returns>An <see cref="IEnumerable{T}"/> sequence with the specified <paramref name="source"/> as the only element.</returns>
	    public static IEnumerable<TSource> Yield<TSource>(TSource source)
	    {
	        yield return source;
	    }
	}
}