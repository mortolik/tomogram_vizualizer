using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Morozov_tomogram_visualizer
{
    class View
    {
        private int tfMin = 0;
        private int tfWidth = 2000;
        public void SetupView(int width, int height)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, Bin.X, 0, Bin.Y, -1, 1);
            GL.Viewport(0, 0, width, height);
        }

        public Color TransferFunction(short value)
        {
            int newVal = Math.Clamp((value - tfMin) * 255 / tfWidth, 0, 255);
            return Color.FromArgb(255, newVal, newVal, newVal);
        }

        public void DrawQuads(int layerNumber)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(BeginMode.Quads);
            for (int x = 0; x < Bin.X - 1; x++)
            {
                for (int y = 0; y < Bin.Y - 1; y++)
                {
                    int x0, x1, y0, y1;

                    if (m_flipHorizontally)
                    {
                        x0 = Bin.X - 1 - x;
                        x1 = Bin.X - 2 - x;
                    }
                    else
                    {
                        x0 = x;
                        x1 = x + 1;
                    }

                    if (m_flipVertically)
                    {
                        y0 = Bin.Y - 1 - y;
                        y1 = Bin.Y - 2 - y;
                    }
                    else
                    {
                        y0 = y;
                        y1 = y + 1;
                    }


                    short value;

                    value = Bin.array[x + y * Bin.X + layerNumber * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(x0, y0);

                    value = Bin.array[x + (y + 1) * Bin.X + layerNumber * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(x0, y1);

                    value = Bin.array[(x + 1) + (y + 1) * Bin.X + layerNumber * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(x1, y1);

                    value = Bin.array[(x + 1) + y * Bin.X + layerNumber * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(x1, y0);
                }
            }
            GL.End();
        }

        public void DrawQuadStrip(int layerNumber)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(BeginMode.QuadStrip);

            for (int y = 0; y < Bin.Y - 1; y++)
            {
                for (int x = 0; x < Bin.X; x++)
                {
                    int drawX;
                    int drawY1;
                    int drawY2;

                    if (m_flipHorizontally)
                    {
                        drawX = Bin.X - 1 - x;
                    }
                    else
                    {
                        drawX = x;
                    }

                    if (m_flipVertically)
                    {
                        drawY1 = Bin.Y - 1 - y;
                        drawY2 = Bin.Y - 2 - y;
                    }
                    else
                    {
                        drawY1 = y;
                        drawY2 = y + 1;
                    }


                    short value = Bin.array[x + y * Bin.X + layerNumber * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(drawX, drawY1);

                    value = Bin.array[x + (y + 1) * Bin.X + layerNumber * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(drawX, drawY2);
                }
            }

            GL.End();
        }


        Bitmap textureImage;
        int VBOtexture;

        public void Load2DTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);
            BitmapData data = textureImage.LockBits(
                new System.Drawing.Rectangle(0, 0, textureImage.Width, textureImage.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte, data.Scan0);

            textureImage.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int)TextureMagFilter.Linear);

            ErrorCode Er = GL.GetError();
            string str = Er.ToString();
        }

        public void generateTextureImage(int layerNumber)
        {
            textureImage = new Bitmap(Bin.X, Bin.Y);
            for (int i = 0; i < Bin.X; ++i)
                for (int j = 0; j < Bin.Y; ++j)
                {
                    int pixelNumber = i + j * Bin.X + layerNumber * Bin.X * Bin.Y;
                    textureImage.SetPixel(i, j, TransferFunction(Bin.array[pixelNumber]));
                }
        }

        public void DrawTexture()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);

            float x0, x1, y0, y1;

            if (m_flipHorizontally)
            {
                x0 = 1f;
                x1 = 0f;
            }
            else
            {
                x0 = 0f;
                x1 = 1f;
            }

            if (m_flipVertically)
            {
                y0 = 1f;
                y1 = 0f;
            }
            else
            {
                y0 = 0f;
                y1 = 1f;
            }


            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(x0, y0); GL.Vertex2(0, 0);
            GL.TexCoord2(x0, y1); GL.Vertex2(0, Bin.Y);
            GL.TexCoord2(x1, y1); GL.Vertex2(Bin.X, Bin.Y);
            GL.TexCoord2(x1, y0); GL.Vertex2(Bin.X, 0);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
        }

        public void SetTransferFunction(int min, int width)
        {
            tfMin = min;
            tfWidth = width;
        }

        private bool m_flipVertically = false;
        private bool m_flipHorizontally = false;

        public void SetFlip(bool vertical, bool horizontal)
        {
            m_flipVertically = vertical;
            m_flipHorizontally = horizontal;
        }


    }
}
