using Newtonsoft.Json;
using OOP_project_stage1.CommandClasses;

namespace OOP_project_stage1
{
    public partial class Form1 : Form
    {
        private double x;
        private double y;
        private double height;
        private double width;
        private double area;
        private double perimeter;
        private Color outline = Color.Black;
        private Color fill;
        bool isDrawing = false;
        private Shape? previewShape = null;
        private Shape? selectedShape = null;
        private Point lastMousePosition;
        private UndoRedoManager undoRedoManager = new UndoRedoManager();
        private StatisticsForm statisticsForm = null;
        private Point startPoint;
        private Point endPoint;
        private List<Shape> shapes = new List<Shape>();

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            bool isDrawingMode = checkBox1.Checked || checkBox2.Checked || checkBox3.Checked;

            if (!isDrawingMode)//select mode
            {
                foreach (var shape in shapes)
                {
                    if (shape.SelectShape(e.Location))//if shape is selected
                    {
                        selectedShape = shape;
                        lastMousePosition = e.Location;

                        if (e.Button == MouseButtons.Right)
                        {
                            var editor = new ShapeEditorForm(shape, shapes, () => this.Refresh(), undoRedoManager);
                            editor.Location = Cursor.Position;
                            editor.Show();
                            this.Refresh();
                        }

                        break;
                    }
                }
            }
            else if (e.Button == MouseButtons.Left)//normal drawing mode
            {
                startPoint = e.Location;
                isDrawing = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing == true && e.Button == MouseButtons.Left)
            {
                endPoint = e.Location;

                int width = Math.Abs(endPoint.X - startPoint.X);
                int height = Math.Abs(endPoint.Y - startPoint.Y);
                int startX = Math.Min(startPoint.X, endPoint.X);
                int startY = Math.Min(startPoint.Y, endPoint.Y);

                if (checkBox1.Checked)
                {
                    previewShape = new Rectangle(startX, startY, height, width, area, perimeter, Color.Gray, Color.Transparent);
                }
                else if (checkBox2.Checked)
                {
                    previewShape = new Circle(startX, startY, height, width, area, perimeter, Color.Gray, Color.Transparent);
                }
                else if (checkBox3.Checked)
                {
                    previewShape = new Triangle(startX, startY, height, width, area, perimeter, Color.Gray, Color.Transparent);
                }

                this.Refresh();
            }
            else if (selectedShape != null && e.Button == MouseButtons.Left)
            {
                float x = e.X - lastMousePosition.X;
                float y = e.Y - lastMousePosition.Y;

                var cmd = new MoveCommand(selectedShape, selectedShape.X + x, selectedShape.Y + y);
                undoRedoManager.ExecuteCommand(cmd);

                lastMousePosition = e.Location;
                this.Refresh();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            width = endPoint.X - startPoint.X;
            height = endPoint.Y - startPoint.Y;

            Graphics g = this.CreateGraphics();

            if (isDrawing == true)
            {
                isDrawing = false;

                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);
                int startX = Math.Min(startPoint.X, e.X);
                int startY = Math.Min(startPoint.Y, e.Y);

                Shape shape = null;

                if (checkBox1.Checked)
                {
                    shape = new Rectangle(startX, startY, height, width, area, perimeter, outline, fill);

                    var cmd = new CreateShapeCommand(shapes, shape);
                    undoRedoManager.ExecuteCommand(cmd);
                }
                if (checkBox2.Checked)
                {
                    shape = new Circle(startX, startY, height, width, area, perimeter, outline, fill);

                    var cmd = new CreateShapeCommand(shapes, shape);
                    undoRedoManager.ExecuteCommand(cmd);
                }
                if (checkBox3.Checked)
                {
                    shape = new Triangle(startX, startY, height, width, area, perimeter, outline, fill);

                    var cmd = new CreateShapeCommand(shapes, shape);
                    undoRedoManager.ExecuteCommand(cmd);
                }

                previewShape = null;
                this.Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = this.CreateGraphics();


            if (previewShape != null)
            {
                previewShape.DrawShape(g);
            }

            foreach (var shape in shapes)
            {
                shape.DrawShape(g);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }//lets only a single checkbox to be checked
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }//lets only a single checkbox to be checked

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }//lets only a single checkbox to be checked

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.ShowDialog();//opens the color dialog

            outline = colorDialog.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.ShowDialog();//opens the color dialog

            fill = colorDialog.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            g.Clear(SystemColors.Control);//clears the whole drawing space and fills it with the default color

            shapes.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (selectedShape != null)
            {
                textBox1.Visible = true;

                double currentArea = selectedShape.CalculateArea() * 0.0264583333;

                textBox1.Text = Math.Round(currentArea, 2) + " cm".ToString();//convert from pixels to cm
            }

            //foreach (var shape in shapes)
            //{
            //    double currentArea = selectedShape.CalculateArea() * 0.0264583333;

            //    textBox1.Text = Math.Round(currentArea, 2) + " cm".ToString();//convert from pixels to cm
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (selectedShape != null)
            {
                textBox2.Visible = true;

                double currentArea = selectedShape.CalculatePerimeter() * 0.0264583333;

                textBox2.Text = Math.Round(currentArea, 2) + " cm".ToString();//convert from pixels to cm
            }
            
            //foreach (var shape in shapes)
            //{
            //    double currentPerimeter = selectedShape.CalculatePerimeter() * 0.0264583333;//convert from pixels to cm

            //    textBox2.Text = Math.Round(currentPerimeter, 2) + " cm".ToString();
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            undoRedoManager.Undo();
            Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            undoRedoManager.Redo();
            Refresh();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            {
                undoRedoManager.Undo();
                Refresh();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Y))
            {
                undoRedoManager.Redo();
                Refresh();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SaveShapesToFile(string path)
        {
            string json = JsonConvert.SerializeObject(shapes, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        private void LoadShapesFromFile(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                shapes = JsonConvert.DeserializeObject<List<Shape>>(json);
                Refresh();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "JSON Files|*.json";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SaveShapesToFile(dlg.FileName);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "JSON Files|*.json";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadShapesFromFile(dlg.FileName);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (statisticsForm == null || statisticsForm.IsDisposed)
            {
                statisticsForm = new StatisticsForm(shapes);
                statisticsForm.Show();
            }
            else
            {
                statisticsForm.BringToFront();
            }
        }
    }
}
