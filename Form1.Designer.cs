namespace Coursework
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Width = new System.Windows.Forms.TextBox();
            this.Height = new System.Windows.Forms.TextBox();
            this.Complexity = new System.Windows.Forms.TextBox();
            this.ExitNumb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Generate = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ширина";
            // 
            // Width
            // 
            this.Width.Location = new System.Drawing.Point(32, 69);
            this.Width.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(114, 27);
            this.Width.TabIndex = 1;
            // 
            // Height
            // 
            this.Height.Location = new System.Drawing.Point(227, 76);
            this.Height.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(114, 27);
            this.Height.TabIndex = 2;
            // 
            // Complexity
            // 
            this.Complexity.Location = new System.Drawing.Point(32, 185);
            this.Complexity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Complexity.Name = "Complexity";
            this.Complexity.Size = new System.Drawing.Size(114, 27);
            this.Complexity.TabIndex = 3;
            // 
            // ExitNumb
            // 
            this.ExitNumb.ForeColor = System.Drawing.Color.Black;
            this.ExitNumb.Location = new System.Drawing.Point(32, 292);
            this.ExitNumb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ExitNumb.Name = "ExitNumb";
            this.ExitNumb.Size = new System.Drawing.Size(114, 27);
            this.ExitNumb.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Высота";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(510, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Сложность (отношение длины кратчайшего пути до выхода к площади)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Количество выходов (опционально)";
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(344, 261);
            this.Generate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(120, 31);
            this.Generate.TabIndex = 8;
            this.Generate.Text = "Сгенерировать";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(354, 347);
            this.Remove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(86, 31);
            this.Remove.TabIndex = 9;
            this.Remove.Text = "Удалить";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExitNumb);
            this.Controls.Add(this.Complexity);
            this.Controls.Add(this.Height);
            this.Controls.Add(this.Width);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Main window";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox Width;
        private TextBox Height;
        private TextBox Complexity;
        private TextBox ExitNumb;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button Generate;
        private Button Remove;
    }
}