using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;
using static System.Windows.Forms.AxHost;

namespace OOP_project_stage1
{
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(ShapeConverter))]
    public abstract class Shape : IShape
    {
        [JsonProperty] public float X { get; set; }
        [JsonProperty] public float Y { get; set; }
        [JsonProperty] public double Height { get; set; }
        [JsonProperty] public double Width { get; set; }
        [JsonProperty] public double Area { get; set; }
        [JsonProperty] public double Perimeter { get; set; }
        [JsonIgnore] public bool IsSelected { get; set; }
        [JsonProperty] public Color OutlineColor { get; set; }
        [JsonProperty] public Color FillColor { get; set; }

        public Shape(float x, float y, double height, double width, double area, double perimeter, Color outlineColor, Color fillColor)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
            Area = area;
            Perimeter = perimeter;
            OutlineColor = outlineColor;
            FillColor = fillColor;
        }//shape constructor

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();

        public virtual bool SelectShape(Point mousePoint)
        {
            return false;
        }

        public abstract void DrawShape(Graphics g);
    }
}
