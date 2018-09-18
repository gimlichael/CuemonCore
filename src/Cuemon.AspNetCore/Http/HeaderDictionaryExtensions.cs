﻿using Cuemon.Collections.Generic;
using Cuemon.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Cuemon.AspNetCore.Http
{
    /// <summary>
    /// Extension methods for the <see cref="IHeaderDictionary"/> interface.
    /// </summary>
    public static class HeaderDictionaryExtensions
    {
        /// <summary>
        /// Adds an element with the provided key and value to the <see cref="IHeaderDictionary"/>.
        /// </summary>
        /// <param name="dic">The <see cref="IHeaderDictionary"/> to extend.</param>
        /// <param name="key">The string to use as the key of the element to add.</param>
        /// <param name="value">The string to use as the value of the element to add.</param>
        /// <param name="useAsciiEncodingConversion">if set to <c>true</c> an ASCII encoding conversion is applied to the <paramref name="value"/>.</param>
        public static void AddOrUpdateHeader(this IHeaderDictionary dic, string key, StringValues value, bool useAsciiEncodingConversion = true)
        {
            dic.AddOrUpdate(key, useAsciiEncodingConversion ? new StringValues(EncodingConverter.ToAsciiEncodedString(value)) : value);
        }
    }
}