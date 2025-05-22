using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Morozov_tomogram_visualizer
{
    public partial class Form1 : Form
    {
        Bin bin = new Bin();
        View view = new View();
        bool loaded = false;
        int currentLayer = 0;
        bool needReload = false;
        bool quadStripMode = false;
        private bool textureMode = false;
        int FrameCount = 0;
        GLControl glControl1;
        DateTime NextFPSUpdate = DateTime.Now.AddSeconds(1);
        public Form1()
        {
            InitializeComponent();

            this.glControl1 = new OpenTK.GLControl();
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(40, 80);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(800, 600);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += GlControl1_Load;
            this.glControl1.Paint += glControl1_Paint;
            this.Controls.Add(this.glControl1);


            Application.Idle += Application_Idle;
        }
        private void GlControl1_Load(object sender, EventArgs e)
        {

            GL.ClearColor(Color.Black);
        }
        private void îòêðûòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string str = dialog.FileName;
                bin.readBIN(str);
                view.SetupView(glControl1.Width, glControl1.Height);
                loaded = true;
                glControl1.Invalidate();
            }
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (loaded)
            {
                if (textureMode)
                {
                    if (needReload)
                    {
                        view.generateTextureImage(currentLayer);
                        view.Load2DTexture();
                        needReload = false;
                    }
                    view.DrawTexture();
                }

                else if (quadStripMode)
                {
                    view.DrawQuadStrip(currentLayer);
                }
                else
                {
                    view.DrawQuads(currentLayer);
                }
                glControl1.SwapBuffers();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentLayer = trackBar1.Value;
            needReload = true;
            glControl1.Invalidate();
        }
        void displayFPS()
        {
            if (DateTime.Now >= NextFPSUpdate)
            {
                this.Text = String.Format("CT Visualizer (fps={0})", FrameCount);
                NextFPSUpdate = DateTime.Now.AddSeconds(1);
                FrameCount = 0;
            }
            FrameCount++;
        }
        void Application_Idle(object sender, EventArgs e)
        {
            while (glControl1.IsIdle)
            {
                displayFPS();
                glControl1.Invalidate();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textureMode = checkBox1.Checked;
            needReload = true;
            glControl1.Invalidate();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            quadStripMode = checkBox2.Checked;
            needReload = false;
            glControl1.Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            view.SetTransferFunction(trackBar2.Value, trackBar3.Value);
            needReload = true;
            glControl1.Invalidate();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            view.SetTransferFunction(trackBar2.Value, trackBar3.Value);
            needReload = true;
            glControl1.Invalidate();
        }
    }

}
