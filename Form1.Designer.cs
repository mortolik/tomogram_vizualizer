namespace Morozov_tomogram_visualizer
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
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            trackBar1 = new TrackBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1018, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(121, 22);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(110, 30);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(561, 45);
            trackBar1.TabIndex = 2;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(860, 31);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(117, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Режим текстуры";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(861, 56);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(120, 19);
            checkBox2.TabIndex = 4;
            checkBox2.Text = "QuadStrip режим";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(110, 736);
            trackBar2.Maximum = 5000;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(561, 45);
            trackBar2.TabIndex = 5;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(110, 790);
            trackBar3.Maximum = 5000;
            trackBar3.Minimum = 100;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(561, 45);
            trackBar3.TabIndex = 6;
            trackBar3.Value = 2000;
            trackBar3.Scroll += trackBar3_Scroll;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(860, 82);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(95, 19);
            checkBox3.TabIndex = 7;
            checkBox3.Text = "Сверху-вниз";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(861, 105);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(110, 19);
            checkBox4.TabIndex = 8;
            checkBox4.Text = "Справа-налево";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 847);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(trackBar3);
            Controls.Add(trackBar2);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(trackBar1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private TrackBar trackBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
    }
}
