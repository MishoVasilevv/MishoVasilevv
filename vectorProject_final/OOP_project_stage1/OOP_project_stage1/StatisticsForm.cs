using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_project_stage1
{
    public partial class StatisticsForm: Form
    {
        private List<Shape> shapes;
        private System.Windows.Forms.Timer refreshTimer;

        public StatisticsForm(List<Shape> shapes)
        {
            InitializeComponent();
            this.shapes = shapes;
            
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 10,
                                 Screen.PrimaryScreen.WorkingArea.Height - Height - 10);

            var textBox = new TextBox()
            {
                Multiline = true,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                ScrollBars = ScrollBars.Vertical
            };
            Controls.Add(textBox);
            textBox.ReadOnly = true;
            textBox.TabStop = false;
            textBox.Cursor = Cursors.Arrow;
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 500;
            refreshTimer.Tick += (s, e) => UpdateStatistics(textBox);
            refreshTimer.Start();

            UpdateStatistics(textBox);
        }

        private void UpdateStatistics(TextBox textBox)
        {
            if (shapes == null) return;

            var stats = new StringBuilder();
            if (shapes.Any())
            {
                stats.AppendLine($"Total shapes: {shapes.Count}");

                stats.AppendLine($"Rectangles: {shapes.OfType<Rectangle>().Count()}");
                stats.AppendLine($"Circles: {shapes.OfType<Circle>().Count()}");
                stats.AppendLine($"Triangles: {shapes.OfType<Triangle>().Count()}");

                stats.AppendLine($"Average Width: {shapes.Average(s => s.Width):F2}");
                stats.AppendLine($"Average Height: {shapes.Average(s => s.Height):F2}");

                var largestArea = shapes.OrderByDescending(s => s.CalculateArea()).FirstOrDefault();
                double currentArea = largestArea.Area * 0.0264583333;
                stats.AppendLine($"Largest Area Shape: {largestArea?.GetType().Name ?? "None"} {Math.Round(currentArea,2)} cm");
            }
            else
            {
                stats.AppendLine();
                stats.AppendLine();
            }
                textBox.Text = stats.ToString();
        }
    }
}
