using EleCho.GoCqHttpSdk.Message.DataModel;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Message.JsonConverter;

internal class CqMsgModelArrayConverter : JsonConverter<CqMsgModel[]>
{
    public override CqMsgModel[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        JsonDocument jsondoc = JsonDocument.ParseValue(ref reader);

        if (jsondoc.RootElement.ValueKind == JsonValueKind.Array)
        {
            List<CqMsgModel> rst = [];

            foreach (var ele in jsondoc.RootElement.EnumerateArray())
                if (JsonSerializer.Deserialize<CqMsgModel>(ele, options) is CqMsgModel msg)
                    rst.Add(msg);

            return [.. rst];
        }
        else if (jsondoc.RootElement.ValueKind == JsonValueKind.String)
        {
            return CqCode.ModelChainFromCqCodeString(jsondoc.RootElement.GetString()!);
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, CqMsgModel[] value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        
        foreach (var msgModel in value)
            JsonSerializer.Serialize(writer, msgModel, msgModel.GetType(), options);
        
        writer.WriteEndArray();
    }
}