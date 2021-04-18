﻿using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace Cuemon.AspNetCore.Http
{
    /// <summary>
    /// The exception that is thrown when the request method is known by the server but has been disabled and cannot be used.
    /// </summary>
    /// <seealso cref="HttpStatusCodeException" />
    [Serializable]
    public class MethodNotAllowedException : HttpStatusCodeException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MethodNotAllowedException"/> class.
        /// </summary>
        public MethodNotAllowedException() : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodNotAllowedException"/> class.
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public MethodNotAllowedException(Exception innerException) : this(default, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodNotAllowedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the HTTP status code.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public MethodNotAllowedException(string message, Exception innerException = null) : base(StatusCodes.Status405MethodNotAllowed, message ?? "The method specified in the request is not allowed for the resource identified by the request URI.", innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodNotAllowedException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected MethodNotAllowedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}