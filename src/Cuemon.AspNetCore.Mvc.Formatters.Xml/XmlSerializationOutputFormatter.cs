﻿using System.IO;
using System.Text;
using System.Threading.Tasks;
using Cuemon.Xml.Serialization.Formatters;
using Cuemon.IO;
using Cuemon.Xml;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace Cuemon.Extensions.AspNetCore.Mvc.Formatters.Xml
{
    /// <summary>
    /// This class handles serialization of objects to XML using <see cref="XmlFormatter"/>.
    /// </summary>
    public class XmlSerializationOutputFormatter : TextOutputFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSerializationOutputFormatter"/> class.
        /// </summary>
        public XmlSerializationOutputFormatter(XmlFormatterOptions formatterOptions)
        {
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
            FormatterOptions = formatterOptions;
        }

        /// <summary>
        /// Write response body as an asynchronous operation.
        /// </summary>
        /// <param name="context">The formatter context associated with the call.</param>
        /// <param name="selectedEncoding">The <see cref="Encoding" /> that should be used to write the response.</param>
        /// <returns>A <see cref="Task" /> which can write the response body.</returns>
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            Validator.ThrowIfNull(context, nameof(context));
            Validator.ThrowIfNull(selectedEncoding, nameof(selectedEncoding));
            var value = context.Object;
            using (var textWriter = context.WriterFactory(context.HttpContext.Response.Body, selectedEncoding))
            {
                var formatter = new XmlFormatter(FormatterOptions);
                var raw = Decorator.Enclose(formatter.Serialize(value)).CopyXmlStream(o => o.Encoding = selectedEncoding);
                using (var streamReader = new StreamReader(raw, selectedEncoding))
                {
                    await Decorator.Enclose(streamReader).CopyToAsync(textWriter).ConfigureAwait(false);
                }
                await textWriter.FlushAsync().ConfigureAwait(false);
            }
        }

        private XmlFormatterOptions FormatterOptions { get; }
    }
}