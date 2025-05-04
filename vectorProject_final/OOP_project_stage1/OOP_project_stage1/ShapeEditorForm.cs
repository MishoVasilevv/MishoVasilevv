using OOP_project_stage1.CommandClasses;
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
    public partial class ShapeEditorForm : Form
    {
        private Shape shape;
        private Action onUpdate;
        private UndoRedoManager undoRedoManager;
        private List<Shape> shapeList;

        public ShapeEditorForm(Shape shapeToEdit, List<Shape> allShapes, Action onUpdateCallback, UndoRedoManager manager)
        {
            InitializeComponent();
            shape = shapeToEdit;
            shapeList = allShapes;
            onUpdate = onUpdateCallback;
            undoRedoManager = manager;

            textBox1.Text = shape.Width.ToString();
            textBox2.Text = shape.Height.ToString();

            button1.Click += (s, e) =>
            {
                using (var dlg = new ColorDialog())
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        var cmd = new OutlineColorChangeCommand(shape, dlg.Color);
                        undoRedoManager.ExecuteCommand(cmd);
                        onUpdate();
                    }
                }
            };

            button2.Click += (s, e) =>
            {
                using (var dlg = new ColorDialog())
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        var cmd = new FillColorChangeCommand(shape, dlg.Color);
                        undoRedoManager.ExecuteCommand(cmd);
                        onUpdate();
                    }
                }
            };

            button3.Click += (s, e) =>
            {
                if (double.TryParse(textBox1.Text, out double newWidth))
                {
                    var resizeCmd = new ResizeCommand(shape, newWidth, shape.Height, onUpdate);
                    undoRedoManager.ExecuteCommand(resizeCmd);
                    onUpdate();
                }
            };

            button4.Click += (s, e) =>
            {
                if (double.TryParse(textBox2.Text, out double newHeight))
                {
                    var resizeCmd = new ResizeCommand(shape, shape.Width, newHeight, onUpdate);
                    undoRedoManager.ExecuteCommand(resizeCmd);
                    onUpdate();
                }
            };

            button5.Click += (s, e) =>
            {
                var cmd = new DeleteCommand(shapeList, shape, onUpdate);
                undoRedoManager.ExecuteCommand(cmd);
                Close();
            };
        }
    }
}
