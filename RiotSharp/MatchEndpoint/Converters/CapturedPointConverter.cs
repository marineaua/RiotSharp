﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp.MatchEndpoint
{
    class CapturedPointConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();
            switch (str)
            {
                case "POINT_A":
                    return CapturedPoint.PointA;
                case "POINT_B":
                    return CapturedPoint.PointB;
                case "POINT_C":
                    return CapturedPoint.PointC;
                case "POINT_D":
                    return CapturedPoint.PointD;
                case "POINT_E":
                    return CapturedPoint.PointE;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((CapturedPoint)value).ToCustomString());
        }
    }
}