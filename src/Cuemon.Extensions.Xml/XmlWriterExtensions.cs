﻿using System;
using System.Reflection;
using System.Xml;
using Cuemon.Collections.Generic;
using Cuemon.Extensions.Xml.Serialization;
using Cuemon.Reflection;
using Cuemon.Runtime.Serialization;

namespace Cuemon.Extensions.Xml
{
    /// <summary>
    /// Extension methods for the <see cref="XmlWriter"/> class.
    /// </summary>
    public static class XmlWriterExtensions
    {
        /// <summary>
        /// Serializes the specified <paramref name="value"/> into an XML format.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="writer">The <see cref="XmlWriter"/> to extend.</param>
        /// <param name="value">The object to serialize.</param>
        /// <param name="setup">The <see cref="XmlSerializerOptions"/> which need to be configured.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="writer"/> cannot be null.
        /// </exception>
        public static void WriteObject<T>(this XmlWriter writer, T value, Action<XmlSerializerOptions> setup = null)
        {
            Validator.ThrowIfNull(writer, nameof(writer));
            WriteObject(writer, value, typeof(T), setup);
        }

        /// <summary>
        /// Serializes the specified <paramref name="value"/> into an XML format.
        /// </summary>
        /// <param name="writer">The <see cref="XmlWriter"/> to extend.</param>
        /// <param name="value">The object to serialize.</param>
        /// <param name="objectType">The type of the object to serialize.</param>
        /// <param name="setup">The <see cref="XmlSerializerOptions"/> which need to be configured.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="writer"/> cannot be null.
        /// </exception>
        public static void WriteObject(this XmlWriter writer, object value, Type objectType, Action<XmlSerializerOptions> setup = null)
        {
            Validator.ThrowIfNull(writer, nameof(writer));
            var serializer = XmlSerializer.Create(setup == null ? null : Patterns.Configure(setup));
            serializer.Serialize(writer, value, objectType);
        }

        /// <summary>
        /// Writes the specified start tag and associates it with the given <paramref name="elementName"/>.
        /// </summary>
        /// <param name="writer">The <see cref="XmlWriter"/> to extend.</param>
        /// <param name="elementName">The fully qualified name of the element.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="writer"/> cannot be null.
        /// </exception>
        public static void WriteStartElement(this XmlWriter writer, XmlQualifiedEntity elementName)
        {
            Validator.ThrowIfNull(writer, nameof(writer));
            writer.WriteStartElement(elementName.Prefix, elementName.LocalName, elementName.Namespace);
        }

        /// <summary>
        /// Writes the specified <paramref name="value"/> with the delegate <paramref name="nodeWriter"/>.
        /// If <paramref name="elementName"/> is not null, then the delegate <paramref name="nodeWriter"/> is called from within an encapsulating Start- and End-element.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="writer">The <see cref="XmlWriter"/> to extend.</param>
        /// <param name="value">The object to serialize.</param>
        /// <param name="elementName">The optional fully qualified name of the element.</param>
        /// <param name="nodeWriter">The delegate node writer.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="writer"/> cannot be null.
        /// </exception>
        public static void WriteEncapsulatingElementWhenNotNull<T>(this XmlWriter writer, T value, XmlQualifiedEntity elementName, Action<XmlWriter, T> nodeWriter)
        {
            Validator.ThrowIfNull(writer, nameof(writer));
            if (elementName == null)
            {
                nodeWriter(writer, value);
                return;
            }
            WriteStartElement(writer, elementName);
            nodeWriter(writer, value);
            writer.WriteEndElement();
        }

        /// <summary>
        /// Writes the XML root element to an existing <paramref name="writer"/>.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="writer">The <see cref="XmlWriter"/> to extend.</param>
        /// <param name="value">The object to serialize.</param>
        /// <param name="treeWriter">The delegate used to write the XML hierarchy.</param>
        /// <param name="rootEntity">The optional <seealso cref="XmlQualifiedEntity"/> that will provide the name of the root element.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="writer"/> cannot be null.
        /// </exception>
        public static void WriteXmlRootElement<T>(this XmlWriter writer, T value, Action<XmlWriter, T, XmlQualifiedEntity> treeWriter, XmlQualifiedEntity rootEntity = null)
        {
            Validator.ThrowIfNull(writer, nameof(writer));
            WriteXmlRootElementCore(writer, value, (w, o) => treeWriter(w, value, rootEntity), null, rootEntity);
        }

        internal static void WriteXmlRootElement(this IDecorator<XmlWriter> decorator, object value, Action<XmlWriter, IHierarchy<object>> treeWriter, XmlQualifiedEntity rootEntity = null)
        {
            WriteXmlRootElementCore(decorator.Inner, value, null, treeWriter, rootEntity);
        }

        private static void WriteXmlRootElementCore(XmlWriter writer, object value, Action<XmlWriter, object> treeWriterPublic, Action<XmlWriter, IHierarchy<object>> treeWriterInternal, XmlQualifiedEntity rootEntity = null)
        {
            Validator.ThrowIfNull(writer, nameof(writer));
            if (value == null) { return; }
            try
            {
                IHierarchy<object> nodes;
                XmlQualifiedEntity rootElement;
                if (treeWriterInternal == null)
                {
                    nodes = new Hierarchy<object>().Add(value);
                    rootElement = nodes.GetXmlRootOrElement(rootEntity);
                    writer.WriteStartElement(rootElement.Prefix, rootElement.LocalName, rootElement.Namespace);
                    treeWriterPublic?.Invoke(writer, value);
                }
                else
                {
                    nodes = new HierarchySerializer(value).Nodes;
                    rootElement = nodes.GetXmlRootOrElement(rootEntity);
                    writer.WriteStartElement(rootElement.Prefix, rootElement.LocalName, rootElement.Namespace);
                    treeWriterInternal(writer, nodes);
                }
            }
            catch (Exception ex)
            {
                var innerException = ex;
                if (innerException is OutOfMemoryException) { throw; }
                if (innerException is TargetInvocationException) { innerException = innerException.InnerException; }
                throw ExceptionInsights.Embed(new InvalidOperationException("There is an error in the XML document.", innerException), Decorator.Enclose(typeof(XmlWriterExtensions)).MatchMember(flags: new MemberReflection(excludeInheritancePath: true)), Arguments.ToArray(writer, value));
            }
            writer.WriteEndElement();
            writer.Flush();
        }
    }
}