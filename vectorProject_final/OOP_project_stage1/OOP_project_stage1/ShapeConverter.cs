using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OOP_project_stage1
{
    public class ShapeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(Shape);

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            string typeName = jo["Type"]?.ToString();//looking for "Type"

            Shape shape = typeName switch//default values
            {
                "Rectangle" => new Rectangle(0, 0, 0, 0, 0, 0, Color.Black, Color.White),
                "Circle" => new Circle(0, 0, 0, 0, 0, 0, Color.Black, Color.White),
                "Triangle" => new Triangle(0, 0, 0, 0, 0, 0, Color.Black, Color.White),
                _ => throw new Exception("Unknown shape type: " + typeName)
            };

            serializer.Populate(jo.CreateReader(), shape);//fill the default empty shape
            return shape;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var shape = value as Shape;
            if (shape == null)
            {
                writer.WriteNull();
                return;
            }

            JObject jo = new JObject
            {
                { "Type", shape.GetType().Name },
                { "X", shape.X },
                { "Y", shape.Y },
                { "Width", shape.Width },
                { "Height", shape.Height },
                { "FillColor", JToken.FromObject(ColorTranslator.ToHtml(shape.FillColor)) },
                { "OutlineColor", JToken.FromObject(ColorTranslator.ToHtml(shape.OutlineColor)) }
            };

            jo.WriteTo(writer);
        }
    }
}
