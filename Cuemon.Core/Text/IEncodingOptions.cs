﻿using System.Text;

namespace Cuemon.Text
{
    /// <summary>
    /// Configuration options for <see cref="System.Text.Encoding"/>.
    /// </summary>
    public interface IEncodingOptions
    {
        /// <summary>
        /// Gets or sets the action to take in regards to encoding related preamble sequences.
        /// </summary>
        /// <value>A value that indicates whether to preserve or remove preamble sequences.</value>
        PreambleSequence Preamble { get; set; }

        /// <summary>
        /// Gets or sets the character encoding to use for the operation.
        /// </summary>
        /// <value>The character encoding to use for the operation.</value>
        Encoding Encoding { get; set; }
    }
}