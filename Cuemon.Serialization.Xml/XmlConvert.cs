﻿using System;

namespace Cuemon.Serialization.Xml
{
    /// <summary>
    /// Provides methods for converting between .NET types and XML types.
    /// </summary>
    public static class XmlConvert
    {
        /// <summary>
        /// Gets or sets a function delegate that creates default <see cref="XmlSerializerSettings"/>.
        /// </summary>
        /// <value>The function delegate which provides default settings for <seealso cref="XmlConvert"/> implementations.</value>
        public static Func<XmlSerializerSettings> DefaultSettings { get; set; }
    }
}