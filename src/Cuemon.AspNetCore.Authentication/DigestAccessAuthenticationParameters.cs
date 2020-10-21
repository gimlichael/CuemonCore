﻿using System.Collections.Immutable;
using Cuemon.Security.Cryptography;

namespace Cuemon.AspNetCore.Authentication
{
    /// <summary>
    /// Represents a set of parameters that is needed for creating an application of cryptographic hashing with usage of nonce values to prevent replay attacks.
    /// </summary>
    public class DigestAccessAuthenticationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DigestAccessAuthenticationParameters"/> class.
        /// </summary>
        /// <param name="credentials">The credentials used in the computation of HA1-, HA2-, and response hash values.</param>
        /// <param name="method">The HTTP method to include in the HA2 computed value.</param>
        /// <param name="password">The password to include in the HA1 computed value.</param>
        /// <param name="entityBody">The entity body to apply in the signature when qop is set to auth-int.</param>
        /// <param name="algorithm">The algorithm to use when computing the HA1-, HA2-, and response hash values.</param>
        internal DigestAccessAuthenticationParameters(ImmutableDictionary<string, string> credentials, string method, string password, string entityBody, UnkeyedCryptoAlgorithm algorithm)
        {
            Credentials = credentials;
            Method = method;
            Password = password;
            EntityBody = entityBody;
            Algorithm = algorithm;
        }

        /// <summary>
        /// Gets the credentials used in the computation of HA1-, HA2-, and RESPONSE hash values.
        /// </summary>
        /// <value>The credentials used in the computation of HA1-, HA2-, and RESPONSE hash values.</value>
        public ImmutableDictionary<string, string> Credentials { get; }

        /// <summary>
        /// Gets the HTTP method to include in the HA2 computed value.
        /// </summary>
        /// <value>The HTTP method to include in the HA2 computed value.</value>
        public string Method { get; }

        /// <summary>
        /// Gets the password to include in the HA1 computed value.
        /// </summary>
        /// <value>The password to include in the HA1 computed value.</value>
        public string Password { get; }

        /// <summary>
        /// Gets the algorithm to use when computing the HA1-, HA2-, and response hash values.
        /// </summary>
        /// <value>The algorithm to use when computing the HA1-, HA2-, and response hash values.</value>
        public UnkeyedCryptoAlgorithm Algorithm { get; }

        /// <summary>
        /// Gets the entity body to include in the HA2 computed value.
        /// </summary>
        /// <value>The entity body to include in the HA2 computed value.</value>
        public string EntityBody { get; }
    }
}