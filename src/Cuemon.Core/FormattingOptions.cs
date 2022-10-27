﻿using System;
using Cuemon.Configuration;

namespace Cuemon
{
    /// <summary>
    /// Configuration options for <see cref="IFormatProvider"/>.
    /// </summary>
    /// <seealso cref="IParameterObject"/>
    public class FormattingOptions<T> : IParameterObject where T : IFormatProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormattingOptions{T}"/> class.
        /// </summary>
        public FormattingOptions()
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="IFormatProvider"/> that provides a mechanism for retrieving an object to control formatting.
        /// </summary>
        /// <value>The <see cref="IFormatProvider"/> that provides a mechanism for retrieving an object to control formatting.</value>
        public virtual T FormatProvider { get; set; }
    }
}
