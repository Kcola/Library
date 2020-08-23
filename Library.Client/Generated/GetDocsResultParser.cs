using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Configuration;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetDocsResultParser
        : JsonResultParserBase<IGetDocs>
    {
        private readonly IValueSerializer _intSerializer;
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _booleanSerializer;
        private readonly IValueSerializer _longSerializer;
        private readonly IValueSerializer _dateTimeSerializer;

        public GetDocsResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _intSerializer = serializerResolver.Get("Int");
            _stringSerializer = serializerResolver.Get("String");
            _booleanSerializer = serializerResolver.Get("Boolean");
            _longSerializer = serializerResolver.Get("Long");
            _dateTimeSerializer = serializerResolver.Get("DateTime");
        }

        protected override IGetDocs ParserData(JsonElement data)
        {
            return new GetDocs
            (
                ParseGetDocsDoc(data, "doc")
            );

        }

        private global::Library.Client.Generated.IDocUnionBookConnection ParseGetDocsDoc(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new DocUnionBookConnection
            (
                ParseGetDocsDocEdges(obj, "edges"),
                ParseGetDocsDocPageInfo(obj, "pageInfo"),
                DeserializeInt(obj, "totalCount")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::Library.Client.Generated.IDocUnionBookEdge> ParseGetDocsDocEdges(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            int objLength = obj.GetArrayLength();
            var list = new global::Library.Client.Generated.IDocUnionBookEdge[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new DocUnionBookEdge
                (
                    DeserializeString(element, "cursor"),
                    ParseGetDocsDocEdgesNode(element, "node")
                );

            }

            return list;
        }

        private global::Library.Client.Generated.IPageInfo ParseGetDocsDocPageInfo(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new PageInfo
            (
                DeserializeNullableString(obj, "endCursor"),
                DeserializeBoolean(obj, "hasNextPage"),
                DeserializeBoolean(obj, "hasPreviousPage"),
                DeserializeNullableString(obj, "startCursor")
            );
        }

        private global::Library.Client.Generated.IDocUnionBook ParseGetDocsDocEdgesNode(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new DocUnionBook
            (
                DeserializeInt(obj, "docid"),
                DeserializeNullableString(obj, "title"),
                DeserializeLong(obj, "isbn"),
                DeserializeDateTime(obj, "pDate"),
                DeserializeNullableString(obj, "pName"),
                ParseGetDocsDocEdgesNodeCopy(obj, "copy")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::Library.Client.Generated.ICopy> ParseGetDocsDocEdgesNodeCopy(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            int objLength = obj.GetArrayLength();
            var list = new global::Library.Client.Generated.ICopy[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Copy
                (
                    DeserializeNullableString(element, "copyid")
                );

            }

            return list;
        }

        private int DeserializeInt(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (int)_intSerializer.Deserialize(value.GetInt32());
        }
        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString());
        }
        private string DeserializeNullableString(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (string)_stringSerializer.Deserialize(value.GetString());
        }

        private bool DeserializeBoolean(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (bool)_booleanSerializer.Deserialize(value.GetBoolean());
        }
        private long DeserializeLong(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (long)_longSerializer.Deserialize(value.GetInt64());
        }

        private System.DateTimeOffset DeserializeDateTime(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.DateTimeOffset)_dateTimeSerializer.Deserialize(value.GetString());
        }
    }
}
