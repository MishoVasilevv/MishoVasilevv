﻿namespace OOP_project_stage1
{
    partial class ShapeEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(123, 29);
            button1.TabIndex = 0;
            button1.Text = "Change Outline";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(12, 58);
            button2.Name = "button2";
            button2.Size = new Size(123, 29);
            button2.TabIndex = 1;
            button2.Text = "Change Fill";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 112);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(123, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 159);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(123, 27);
            textBox2.TabIndex = 3;
            // 
            // button3
            // 
            button3.Location = new Point(147, 112);
            button3.Name = "button3";
            button3.Size = new Size(123, 29);
            button3.TabIndex = 4;
            button3.Text = "Change Width";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(147, 159);
            button4.Name = "button4";
            button4.Size = new Size(123, 29);
            button4.TabIndex = 5;
            button4.Text = "Change Height";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.BackColor = Color.IndianRed;
            button5.Location = new Point(147, 12);
            button5.Name = "button5";
            button5.Size = new Size(123, 75);
            button5.TabIndex = 6;
            button5.Text = "Delete";
            button5.UseVisualStyleBackColor = false;
            // 
            // ShapeEditorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 203);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShapeEditorForm";
            StartPosition = FormStartPosition.Manual;
            Text = "ShapeEditorFrom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}