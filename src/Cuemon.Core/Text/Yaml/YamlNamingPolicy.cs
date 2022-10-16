﻿namespace Cuemon.Text.Yaml
{
    /// <summary>
    /// Determines the naming policy used to convert a string-based name to another format.
    /// </summary>
    public abstract class YamlNamingPolicy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YamlNamingPolicy"/> class.
        /// </summary>
        protected YamlNamingPolicy()
        {
        }

        /// <summary>
        /// When overridden in a derived class, converts the specified name according to the policy.
        /// </summary>
        /// <param name="name">The name to convert.</param>
        /// <returns>The converted name.</returns>
        public abstract string ConvertName(string name);
    }
}
