﻿using System;
using Cuemon.Extensions.AspNetCore.Xml.Formatters;
using Cuemon.Xml.Serialization.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Cuemon.Extensions.AspNetCore.Mvc.Formatters.Xml
{
    /// <summary>
    /// Extension methods for the <see cref="IMvcCoreBuilder"/> interface.
    /// </summary>
    public static class MvcCoreBuilderExtensions
    {
        /// <summary>
        /// Adds the XML serializer formatters to MVC.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <param name="setup">The <see cref="XmlFormatterOptions"/> which may be configured.</param>
        /// <returns>A reference to <paramref name="builder"/> after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="builder"/> cannot be null -or-
        /// <paramref name="setup"/> cannot be null.
        /// </exception>
        public static IMvcCoreBuilder AddXmlFormatters(this IMvcCoreBuilder builder, Action<XmlFormatterOptions> setup = null)
        {
            Validator.ThrowIfNull(builder);
            builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, XmlSerializationMvcOptionsSetup>());
            AddXmlFormattersOptions(builder, setup);
            return builder;
        }

        /// <summary>
        /// Adds configuration of <see cref="XmlFormatterOptions"/> for the application.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcBuilder"/>.</param>
        /// <param name="setup">The <see cref="XmlFormatterOptions"/> which need to be configured.</param>
        /// <returns>A reference to <paramref name="builder"/> after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="builder"/> cannot be null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="setup"/> failed to configure an instance of <see cref="XmlFormatterOptions"/> in a valid state.
        /// </exception>
        public static IMvcCoreBuilder AddXmlFormattersOptions(this IMvcCoreBuilder builder, Action<XmlFormatterOptions> setup = null)
        {
            Validator.ThrowIfNull(builder);
            builder.Services.AddXmlFormatterOptions(setup);
            builder.Services.AddXmlExceptionResponseFormatter();
            return builder;
        }
    }
}
