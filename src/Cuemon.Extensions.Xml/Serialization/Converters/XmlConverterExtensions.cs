﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using Cuemon.Diagnostics;
using Cuemon.Extensions.Xml.Linq;
using Cuemon.Runtime.Serialization;

namespace Cuemon.Extensions.Xml.Serialization.Converters
{
    /// <summary>
    /// Extension methods for the <see cref="XmlConverter"/> class.
    /// </summary>
    public static class XmlConverterExtensions
    {
        /// <summary>
        /// Returns the first <see cref="XmlConverter"/> of the <paramref name="converters"/> that <see cref="XmlConverter.CanConvert"/> and <see cref="XmlConverter.CanRead"/> the specified <paramref name="objectType"/>; otherwise <c>null</c> if no <see cref="XmlConverter"/> is found.
        /// </summary>
        /// <param name="converters">The <see cref="T:IList{XmlConverter}" /> to extend.</param>
        /// <param name="objectType">Type of the object to deserialize.</param>
        /// <returns>An <see cref="XmlConverter"/> that can deserialize the specified <paramref name="objectType"/>; otherwise <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="converters"/> cannot be null.
        /// </exception>
        public static XmlConverter FirstOrDefaultReaderConverter(this IList<XmlConverter> converters, Type objectType)
        {
            Validator.ThrowIfNull(converters, nameof(converters));
            return converters.FirstOrDefault(c => c.CanConvert(objectType) && c.CanRead);
        }

        /// <summary>
        /// Returns the first <see cref="XmlConverter"/> of the <paramref name="converters"/> that <see cref="XmlConverter.CanConvert"/> and <see cref="XmlConverter.CanWrite"/> the specified <paramref name="objectType"/>; otherwise <c>null</c> if no <see cref="XmlConverter"/> is found.
        /// </summary>
        /// <param name="converters">The <see cref="T:IList{XmlConverter}" /> to extend.</param>
        /// <param name="objectType">Type of the object to serialize.</param>
        /// <returns>An <see cref="XmlConverter"/> that can serialize the specified <paramref name="objectType"/>; otherwise <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="converters"/> cannot be null.
        /// </exception>
        public static XmlConverter FirstOrDefaultWriterConverter(this IList<XmlConverter> converters, Type objectType)
        {
            Validator.ThrowIfNull(converters, nameof(converters));
            return converters.FirstOrDefault(c => c.CanConvert(objectType) && c.CanWrite);
        }

        /// <summary>
        /// Adds an XML converter to the list.
        /// </summary>
        /// <typeparam name="T">The type of the object to converts to and from XML.</typeparam>
        /// <param name="converters">The <see cref="T:IList{XmlConverter}" /> to extend.</param>
        /// <param name="writer">The delegate that converts <typeparamref name="T"/> to its XML representation.</param>
        /// <param name="reader">The delegate that generates <typeparamref name="T"/> from its XML representation.</param>
        /// <param name="canConvertPredicate">The delegate that determines if an object can be converted.</param>
        /// <param name="qe">The optional <seealso cref="XmlQualifiedEntity"/> that will provide the name of the root element.</param>
        /// <returns>A reference to <paramref name="converters"/> after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="converters"/> cannot be null.
        /// </exception>
        public static IList<XmlConverter> AddXmlConverter<T>(this IList<XmlConverter> converters, Action<XmlWriter, T, XmlQualifiedEntity> writer = null, Func<XmlReader, Type, T> reader = null, Func<Type, bool> canConvertPredicate = null, XmlQualifiedEntity qe = null)
        {
            Validator.ThrowIfNull(converters, nameof(converters));
            converters.Add(DynamicXmlConverter.Create(writer, reader, canConvertPredicate, qe));
            return converters;
        }

        /// <summary>
        /// Inserts an XML converter to the list at the specified <paramref name="index" />.
        /// </summary>
        /// <typeparam name="T">The type of the object to converts to and from XML.</typeparam>
        /// <param name="converters">The <see cref="T:IList{XmlConverter}" /> to extend.</param>
        /// <param name="index">The zero-based index at which an XML converter should be inserted.</param>
        /// <param name="writer">The delegate that converts <typeparamref name="T" /> to its XML representation.</param>
        /// <param name="reader">The delegate that generates <typeparamref name="T" /> from its XML representation.</param>
        /// <param name="canConvertPredicate">The delegate that determines if an object can be converted.</param>
        /// <param name="qe">The optional <seealso cref="XmlQualifiedEntity"/> that will provide the name of the root element.</param>
        /// <returns>A reference to <paramref name="converters"/> after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="converters"/> cannot be null.
        /// </exception>
        public static IList<XmlConverter> InsertXmlConverter<T>(this IList<XmlConverter> converters, int index, Action<XmlWriter, T, XmlQualifiedEntity> writer = null, Func<XmlReader, Type, T> reader = null, Func<Type, bool> canConvertPredicate = null, XmlQualifiedEntity qe = null)
        {
            Validator.ThrowIfNull(converters, nameof(converters));
            converters.Insert(index, DynamicXmlConverter.Create(writer, reader, canConvertPredicate, qe));
            return converters;
        }

        /// <summary>
        /// Adds an <see cref="IEnumerable"/> XML converter to the list.
        /// </summary>
        /// <param name="converters">The <see cref="T:IList{XmlConverter}" /> to extend.</param>
        /// <returns>A reference to <paramref name="converters"/> after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="converters"/> cannot be null.
        /// </exception>
        public static IList<XmlConverter> AddEnumerableConverter(this IList<XmlConverter> converters)
        {
            Validator.ThrowIfNull(converters, nameof(converters));
            return converters.AddXmlConverter<IEnumerable>((w, o, q) =>
            {
                w.WriteXmlRootElement(o, (writer, sequence, qe) =>
                {
                    var type = sequence.GetType();
                    var hasKeyValuePairType = type.GetGenericArguments().Any(gt => Decorator.Enclose(gt).HasKeyValuePairImplementation());

                    if (Decorator.Enclose(type).HasDictionaryImplementation() || hasKeyValuePairType)
                    {
                        foreach (var element in sequence)
                        {
                            var elementType = element.GetType();
                            var keyProperty = elementType.GetProperty("Key");
                            var valueProperty = elementType.GetProperty("Value");
                            var keyValue = keyProperty.GetValue(element, null);
                            var valueValue = valueProperty.GetValue(element, null);
                            var valuePropertyType = valueProperty.PropertyType;
                            if (valuePropertyType == typeof(object) && valueValue != null) { valuePropertyType = valueValue.GetType(); }
                            writer.WriteStartElement("Item");
                            writer.WriteAttributeString("name", keyValue.ToString());
                            if (Decorator.Enclose(valuePropertyType).IsComplex())
                            {
                                writer.WriteObject(valueValue, valuePropertyType);
                            }
                            else
                            {
                                writer.WriteValue(valueValue);
                            }
                            writer.WriteEndElement();
                        }
                    }
                    else
                    {
                        foreach (var item in sequence)
                        {
                            if (item == null) { continue; }
                            var itemType = item.GetType();
                            writer.WriteStartElement("Item");
                            if (Decorator.Enclose(itemType).IsComplex())
                            {
                                writer.WriteObject(item, itemType);
                            }
                            else
                            {
                                writer.WriteValue(item);
                            }
                            writer.WriteEndElement();
                        }
                    }
                }, q);
            }, (reader, type) => Decorator.Enclose(type).HasDictionaryImplementation() ? Decorator.Enclose(reader.ToHierarchy()).UseDictionary(type.GetGenericArguments()) : Decorator.Enclose(reader.ToHierarchy()).UseCollection(type.GetGenericArguments().First()), type => type != typeof(string));
        }

        /// <summary>
        /// Adds an <see cref="ExceptionDescriptor"/> XML converter to the list.
        /// </summary>
        /// <param name="converters">The <see cref="T:IList{XmlConverter}" /> to extend.</param>
        /// <param name="setup">The <see cref="ExceptionDescriptorSerializationOptions"/> which may be configured.</param>
        /// <returns>A reference to <paramref name="converters"/> after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="converters"/> cannot be null.
        /// </exception>
        public static IList<XmlConverter> AddExceptionDescriptorConverter(this IList<XmlConverter> converters, Action<ExceptionDescriptorSerializationOptions> setup = null)
        {
            Validator.ThrowIfNull(converters, nameof(converters));
            var options = Patterns.Configure(setup);
            return converters.AddXmlConverter<ExceptionDescriptor>((writer, descriptor, qe) =>
            {
                writer.WriteStartElement("ExceptionDescriptor");
                writer.WriteStartElement("Error");
                writer.WriteElementString("Code", descriptor.Code);
                writer.WriteElementString("Message", descriptor.Message);
                if (descriptor.HelpLink != null) { writer.WriteElementString("HelpLink", descriptor.HelpLink.OriginalString); }
                if (options.IncludeFailure)
                {
                    writer.WriteStartElement("Failure");
                    writer.WriteObject(descriptor.Failure);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                if (options.IncludeEvidence && descriptor.Evidence.Any())
                {
                    writer.WriteStartElement("Evidence");
                    foreach (var evidence in descriptor.Evidence)
                    {
                        if (evidence.Value == null) { continue; }
                        writer.WriteObject(evidence.Value, evidence.Value.GetType(), o => o.RootName = new XmlQualifiedEntity(evidence.Key));
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }, canConvertPredicate: type => type == typeof(ExceptionDescriptor));
        }

        /// <summary>
        /// Adds a <see cref="Uri"/> XML converter to the list.
        /// </summary>
        /// <param name="converters">The <see cref="T:IList{XmlConverter}" /> to extend.</param>
        /// <returns>A reference to <paramref name="converters"/> after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="converters"/> cannot be null.
        /// </exception>
        public static IList<XmlConverter> AddUriConverter(this IList<XmlConverter> converters)
        {
            Validator.ThrowIfNull(converters, nameof(converters));
            return converters.AddXmlConverter(reader: (reader, type) => Decorator.Enclose(reader.ToHierarchy()).UseUriFormatter());
        }

        /// <summary>
        /// Adds an <see cref="DateTime"/> XML converter to the list.
        /// </summary>
        /// <param name="converters">The <see cref="T:IList{XmlConverter}" /> to extend.</param>
        /// <returns>A reference to <paramref name="converters"/> after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="converters"/> cannot be null.
        /// </exception>
        public static IList<XmlConverter> AddDateTimeConverter(this IList<XmlConverter> converters)
        {
            Validator.ThrowIfNull(converters, nameof(converters));
            return converters.AddXmlConverter((w, d, q) =>
            {
                w.WriteEncapsulatingElementWhenNotNull(d, q, (writer, value) =>
                {
                    writer.WriteValue(value.ToString("u", CultureInfo.InvariantCulture));
                });
            }, (reader, type) => Decorator.Enclose(reader.ToHierarchy()).UseDateTimeFormatter());
        }

        /// <summary>
        /// Adds an <see cref="TimeSpan"/> XML converter to the list.
        /// </summary>
        /// <param name="converters">The <see cref="T:IList{XmlConverter}" /> to extend.</param>
        /// <returns>A reference to <paramref name="converters"/> after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="converters"/> cannot be null.
        /// </exception>
        public static IList<XmlConverter> AddTimeSpanConverter(this IList<XmlConverter> converters)
        {
            Validator.ThrowIfNull(converters, nameof(converters));
            return converters.AddXmlConverter(reader: (reader, type) => Decorator.Enclose(reader.ToHierarchy()).UseTimeSpanFormatter());
        }

        /// <summary>
        /// Adds an <see cref="string"/> XML converter to the list.
        /// </summary>
        /// <param name="converters">The <see cref="T:IList{XmlConverter}" /> to extend.</param>
        /// <returns>A reference to <paramref name="converters"/> after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="converters"/> cannot be null.
        /// </exception>
        public static IList<XmlConverter> AddStringConverter(this IList<XmlConverter> converters)
        {
            Validator.ThrowIfNull(converters, nameof(converters));
            return converters.AddXmlConverter<string>((w, s, q) =>
            {
                if (string.IsNullOrWhiteSpace(s)) { return; }
                if (w.WriteState == WriteState.Start && q == null) { q = new XmlQualifiedEntity(Decorator.Enclose(typeof(string)).ToFriendlyName()); }
                w.WriteEncapsulatingElementWhenNotNull(s, q, (writer, value) =>
                {
                    if (value.IsXmlString())
                    {
                        writer.WriteCData(value);
                    }
                    else
                    {
                        writer.WriteValue(value);
                    }
                });
            });
        }

        /// <summary>
        /// Adds an <see cref="Exception" /> XML converter to the list.
        /// </summary>
        /// <param name="converters">The <see cref="T:IList{XmlConverter}" /> to extend.</param>
        /// <param name="includeStackTraceFactory">The function delegate that is invoked when it is needed to determine whether the stack of an exception is included in the converted result.</param>
        /// <returns>A reference to <paramref name="converters"/> after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="converters"/> cannot be null.
        /// </exception>
        public static IList<XmlConverter> AddExceptionConverter(this IList<XmlConverter> converters, Func<bool> includeStackTraceFactory)
        {
            Validator.ThrowIfNull(converters, nameof(converters));
            return converters.AddXmlConverter<Exception>((writer, exception, qe) =>
            {
                WriteException(writer, exception, includeStackTraceFactory?.Invoke() ?? false);
            });
        }

        private static void WriteException(XmlWriter writer, Exception exception, bool includeStackTrace)
        {
            var exceptionType = exception.GetType();
            writer.WriteStartElement(exceptionType.Name.SanitizeXmlElementName());
            writer.WriteAttributeString("namespace", exceptionType.Namespace);
            WriteExceptionCore(writer, exception, includeStackTrace);
            writer.WriteEndElement();
        }

        private static void WriteExceptionCore(XmlWriter writer, Exception exception, bool includeStackTrace)
        {
            if (!string.IsNullOrEmpty(exception.Source))
            {
                writer.WriteElementString("Source", exception.Source);
            }

            if (!string.IsNullOrEmpty(exception.Message))
            {
                writer.WriteElementString("Message", exception.Message);
            }

            if (exception.StackTrace != null && includeStackTrace)
            {
                writer.WriteStartElement("Stack");
                var lines = exception.StackTrace.Split(new[] { Alphanumeric.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    writer.WriteElementString("Frame", line.Trim());
                }
                writer.WriteEndElement();
            }

            if (exception.Data.Count > 0)
            {
                writer.WriteStartElement("Data");
                foreach (DictionaryEntry entry in exception.Data)
                {
                    writer.WriteStartElement(entry.Key.ToString().SanitizeXmlElementName());
                    writer.WriteString(entry.Value.ToString().SanitizeXmlElementText());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            var properties = Decorator.Enclose(exception.GetType()).GetRuntimePropertiesExceptOf<AggregateException>().Where(pi => !Decorator.Enclose(pi.PropertyType).IsComplex());
            foreach (var property in properties)
            {
                var value = property.GetValue(exception);
                if (value == null) { continue; }
                writer.WriteObject(value, value.GetType(), settings => settings.RootName = new XmlQualifiedEntity(property.Name));
            }

            WriteInnerExceptions(writer, exception, includeStackTrace);
        }

        private static void WriteInnerExceptions(XmlWriter writer, Exception exception, bool includeStackTrace)
        {
            var aggregated = exception as AggregateException;
            var innerExceptions = new List<Exception>();
            if (aggregated != null) { innerExceptions.AddRange(aggregated.Flatten().InnerExceptions); }
            if (exception.InnerException != null) { innerExceptions.Add(exception.InnerException); }
            if (innerExceptions.Count > 0)
            {
                var endElementsToWrite = 0;
                foreach (var inner in innerExceptions)
                {
                    var exceptionType = inner.GetType();
                    writer.WriteStartElement(exceptionType.Name.SanitizeXmlElementName());
                    writer.WriteAttributeString("namespace", exceptionType.Namespace);
                    WriteExceptionCore(writer, inner, includeStackTrace);
                    endElementsToWrite++;
                }
                for (var i = 0; i < endElementsToWrite; i++) { writer.WriteEndElement(); }
            }
        }
    }
}