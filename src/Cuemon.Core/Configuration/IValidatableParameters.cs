﻿namespace Cuemon.Configuration
{
    /// <summary>
    /// Denotes a Parameter Object where one or more conditions can be verified that they are in a valid state.
    /// </summary>
    /// <seealso cref="IParameters" />
    public interface IValidatableParameters : IParameters
    {
        /// <summary>
        /// Determines whether this instance is in a valid state.
        /// </summary>
        /// <remarks>This method is expected to throw exceptions when one or more conditions fails to be in a valid state.</remarks>
        void Validate();
    }
}
