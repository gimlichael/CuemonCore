﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Cuemon.Collections.Generic
{
    /// <summary>
    /// Represents a generic and read-only collection that is iterated in partitions.
    /// Implements the <see cref="PartitionerEnumerable{T}" />
    /// Implements the <see cref="IReadOnlyCollection{T}" />
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <seealso cref="PartitionerEnumerable{T}" />
    /// <seealso cref="IReadOnlyCollection{T}" />
    public class PartitionerCollection<T> : PartitionerEnumerable<T>, IReadOnlyCollection<T>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PartitionerCollection{T}"/> class.
        /// </summary>
        /// <param name="source">The sequence to iterate in partitions.</param>
        /// <param name="sourceCount">The number of elements contained in the <paramref name="source"/>.</param>
        /// <param name="partitionSize">The size of the partitions.</param>
        public PartitionerCollection(IEnumerable<T> source, int sourceCount = -1, int partitionSize = 128) : base(source, partitionSize)
        {
            Count = sourceCount > 0 ? sourceCount : Origin.Count();
            PartitionsCount = Converter.FromObject<int>(Math.Ceiling(Count / Converter.FromObject<double>(PartitionSize)));
        }

        /// <summary>
        /// Gets the total number of elements in the sequence before partitioning is applied.
        /// </summary>
        /// <value>The total number of elements in the sequence before partitioning is applied.</value>
        public int Count { get; }

        /// <summary>
        /// Gets the number of elements remaining in the partitioned sequence.
        /// </summary>
        /// <value>The number of elements remaining in the partitioned sequence.</value>
        public int Remaining => (Count - IteratedCount);

        /// <summary>
        /// Gets the total amount of partitions for the elements in this sequence.
        /// </summary>
        /// <returns>The total amount of partitions for the elements in this sequence.</returns>
        public int PartitionsCount { get; }
    }
}