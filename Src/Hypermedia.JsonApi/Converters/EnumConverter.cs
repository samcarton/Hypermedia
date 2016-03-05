﻿using System;
using JsonLite.Ast;

namespace Hypermedia.JsonApi.Converters
{
    internal sealed class EnumConverter : IJsonConverter
    {
        internal static readonly IJsonConverter Instance = new EnumConverter();

        /// <summary>
        /// Constructor.
        /// </summary>
        EnumConverter() { }

        /// <summary>
        /// Serialize the value.
        /// </summary>
        /// <param name="value">The value to serialize.</param>
        /// <returns>The JSON value that represents the given CLR value.</returns>
        public JsonValue Serialize(object value)
        {
            return new JsonString(value.ToString());
        }

        /// <summary>
        /// Deserialize a JSON value to a defined CLR type.
        /// </summary>
        /// <param name="type">The CLR type to deserialize the JSON value to.</param>
        /// <param name="jsonValue">The JSON value to deserialize.</param>
        /// <returns>The object that represents the CLR version of the given JSON value.</returns>
        public object Deserialize(Type type, JsonValue jsonValue)
        {
            var text = ((JsonString)jsonValue).Value;

            return Enum.Parse(type, text, true);
        }
    }
}
