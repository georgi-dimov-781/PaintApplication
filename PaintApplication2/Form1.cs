using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;

namespace PaintApplication2
{
    public partial class Form1 : Form
    {
        Graphics g;

        Pen p = new Pen(Color.Black, 1);
        Point sp = new Point(0, 0);
        Point ep = new Point(0, 0);
        int k = 0;
        int figura;
        private int cX, cY, x, y, dX, dY;

        Color color;



        public Form1()
        {
            InitializeComponent();
            color = Color.Black;
        }


        private Image Img;
        private Size OriginalImageSize;
        private Size ModifiedImageSize;

        int cropX;
        int cropY;
        int cropWidth;

        int cropHeight;
        int oCropX;
        int oCropY;
        public Pen cropPen;

        public DashStyle cropDashStyle = DashStyle.DashDot;
        public bool Makeselection = false;


        private void LoadImage()
        {
            //we set the picturebox size according to image, we can get image width and height with the help of Image.Width and Image.height properties.
            int imgWidth = Img.Width;
            int imghieght = Img.Height;
            pictureBox1.Width = imgWidth;
            pictureBox1.Height = imghieght;
            pictureBox1.Image = Img;
            PictureBoxLocation();
            OriginalImageSize = new Size(imgWidth, imghieght);

            SetResizeInfo();
        }

        private void SetResizeInfo()
        {

        }

        private void PictureBoxLocation()
        {
            int _x = 0;
            int _y = 0;
            if (groupBox1.Width > pictureBox1.Width)
            {
                _x = (groupBox1.Width - pictureBox1.Width) / 0;
            }
            if (groupBox1.Height > pictureBox1.Height)
            {
                _y = (groupBox1.Height - pictureBox1.Height) / 0;
            }

            pictureBox1.Location = new Point(_x, _y);


        }


        private void button5_Click(object sender, EventArgs e)
        {
            color = Color.Black;
            button4.BackColor = color;
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            color = Color.DarkGray;
            button4.BackColor = color;
        }
        
        private void button9_Click(object sender, EventArgs e)
        {
            color = Color.Brown;
            button4.BackColor = color;
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            color = Color.Gray;
            button4.BackColor = color;
        }
        
        private void button10_Click(object sender, EventArgs e)
        {
            color = Color.Maroon;
            button4.BackColor = color;
        }
        
        private void button11_Click(object sender, EventArgs e)
        {
            color = Color.Red;
            button4.BackColor = color;
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            color = Color.White;
            button4.BackColor = color;
        }
        
        private void button12_Click(object sender, EventArgs e)
        {
            color = Color.Pink;
            button4.BackColor = color;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            color = Color.OrangeRed;
            button4.BackColor = color;
        }
        
        private void button14_Click(object sender, EventArgs e)
        {
            color = Color.Yellow;
            button4.BackColor = color;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            color = Color.Gold;
            button4.BackColor = color;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            color = Color.LightSalmon;
            button4.BackColor = color;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            color = Color.Green;
            button4.BackColor = color;
        }
        
        private void button18_Click(object sender, EventArgs e)
        {
            color = Color.YellowGreen;
            button4.BackColor = color;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            color = Color.SteelBlue;
            button4.BackColor = color;
        }
        
        private void button20_Click(object sender, EventArgs e)
        {
            color = Color.Aqua;
            button4.BackColor = color;
        }
        
        private void button21_Click(object sender, EventArgs e)
        {
            color = Color.MediumSlateBlue;
            button4.BackColor = color;
        }
        
        private void button22_Click(object sender, EventArgs e)
        {
            color = Color.RoyalBlue;
            button4.BackColor = color;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            color = Color.Purple;
            button4.BackColor = color;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            color = Color.Bisque;
            button4.BackColor = color;
        }

        void pictureBox1MouseDown(object sender, MouseEventArgs e)
        {
            sp = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                k = 1;
            }
            cX = e.X;
            cY = e.Y;

            {
                Cursor = Cursors.Default;
                if (Makeselection)
                {

                    try
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            Cursor = Cursors.Cross;
                            cropX = e.X;
                            cropY = e.Y;

                            cropPen = new Pen(Color.Black, 1);
                            cropPen.DashStyle = DashStyle.DashDotDot;


                        }
                        pictureBox1.Refresh();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            { }
        }

        private void pictureBox1MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "X: " + Convert.ToString(x);
            label2.Text = "y: " + Convert.ToString(y);
            if (k == 1)
            {
                ep = e.Location;
                x = e.X;
                y = e.Y;

                if (figura == 1)
                {
                    g.DrawLine(new Pen(color), sp, ep);
                }
                else if (figura == 2)
                {
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, 60, 60);
                }
                else if (figura == 6)
                {
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, 60, 60);
                }
                else if (figura == 7)
                {
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, 5, 5);
                }
                else if (figura == 8)
                {
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, 15, 15);
                }
                else if (figura == 9)
                {
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, 25, 25);
                }
                else if (figura == 10)
                {
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, 35, 35);
                }
                sp = ep;
                { }

                Cursor = Cursors.Default;
                if (Makeselection)
                {

                    try
                    {
                        if (pictureBox1.Image == null)
                            return;


                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            pictureBox1.Refresh();
                            cropWidth = e.X - cropX;
                            cropHeight = e.Y - cropY;
                            pictureBox1.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                        }



                    }
                    catch (Exception ex)
                    {
                        //if (ex.Number == 5)
                        //    return;
                    }
                }
                
            }
        }
        
       private void pictureBox1MouseUp(object sender, MouseEventArgs e)
        {
            k = 0;

            if (Makeselection)
            {
                Cursor = Cursors.Default;
            }
        }

       private void Form1Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
        }
        
        private void button25_Click(object sender, EventArgs e)
        {
            figura = 1;
        }
        
        private void button26_Click(object sender, EventArgs e)
        {
            figura = 2;
            color = Color.White;
        }
        
        private void button32_Click(object sender, EventArgs e)
        {
            figura = 3;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            figura = 4;
        }
        
        private void button34_Click(object sender, EventArgs e)
        {
            figura = 5;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label1Click(object sender, EventArgs e)
        {

        }

        private void Label2Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1Click(object sender, EventArgs e)
        {

        }
        
        private void button27_Click(object sender, EventArgs e)
        {
            figura = 6;
        }
        

        private void button28_Click(object sender, EventArgs e)
        {
            figura = 7;
        }
        
        private void button29_Click(object sender, EventArgs e)
        {
            figura = 8;
        }
        
        private void button30_Click(object sender, EventArgs e)
        {
            figura = 9;
        }

        private void Form1MouseUp(object sender, MouseEventArgs e)
        {

        }



        private void button31_Click(object sender, EventArgs e)
        {
            figura = 10;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            ColorDialog warna = new ColorDialog();
            if (warna.ShowDialog() == DialogResult.OK)
            {
                button4.BackColor = warna.Color;
                color = warna.Color;
            }
        }

        private void отвориToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = (Image)Image.FromFile(o.FileName).Clone();
            }
        }

        private void записванеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Rectangle rect = pictureBox1.RectangleToScreen(pictureBox1.ClientRectangle);
            g.CopyFromScreen(rect.Location, Point.Empty, pictureBox1.Size);
            g.Dispose();
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(s.FileName))
                {
                    File.Delete(s.FileName);
                }
                if (s.FileName.Contains(".jpg"))
                {
                    bmp.Save(s.FileName, ImageFormat.Jpeg);
                }
                else if (s.FileName.Contains(".png"))
                {
                    bmp.Save(s.FileName, ImageFormat.Png);
                }
                else if (s.FileName.Contains(".bmp"))
                {
                    bmp.Save(s.FileName, ImageFormat.Bmp);
                }
            }
        }

        private void новToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            pictureBox1.Image = null;
        }

        private void заСъздателяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Това приложение е разработено от Георги Димов", "За създателя", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Makeselection = true;
            button38.Enabled = true;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;

            try
            {
                if (cropWidth < 1)
                {
                    return;
                }
                Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                //Дефинираме правоъгълник с помощта на вече изчислените точки.
                Bitmap OriginalImage = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                //Оригиналното изображение
                Bitmap _img = new Bitmap(cropWidth, cropHeight);
                //Изображение за изрязване
                Graphics g = Graphics.FromImage(_img);
                //Създаване на нова графика
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //Задаваме атрибути на изображението
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

                pictureBox1.Image = _img;
                pictureBox1.Width = _img.Width;
                pictureBox1.Height = _img.Height;
                PictureBoxLocation();
                button14.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(pictureBox1.Image);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                pictureBox1.Image = Clipboard.GetImage();
            }
        }

        private void pictureBox1MouseClick(object sender, MouseEventArgs e)
        {
            if (k == 1)
            {
                x = e.X;
                y = e.Y;
                dX = e.X - cX;
                dY = e.Y - cY;
                if (figura == 3)
                {
                    g.DrawLine(new Pen(color), cX, cY, e.X, e.Y);
                }
                if (figura == 4)
                {
                    g.DrawEllipse(new Pen(color), cX, cY, dX, dY);
                }
                if (figura == 5)
                {
                    g.DrawRectangle(new Pen(color), cX, cY, dX, dY);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = (Image)Image.FromFile(o.FileName).Clone();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Rectangle rect = pictureBox1.RectangleToScreen(pictureBox1.ClientRectangle);
            g.CopyFromScreen(rect.Location, Point.Empty, pictureBox1.Size);
            g.Dispose();
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(s.FileName))
                {
                    File.Delete(s.FileName);
                }
                if (s.FileName.Contains(".jpg"))
                {
                    bmp.Save(s.FileName, ImageFormat.Jpeg);
                }
                else if (s.FileName.Contains(".png"))
                {
                    bmp.Save(s.FileName, ImageFormat.Png);
                }
                else if (s.FileName.Contains(".bmp"))
                {
                    bmp.Save(s.FileName, ImageFormat.Bmp);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            pictureBox1.Image = null;
        }
        
        private void button35_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Желаете ли да излезете ?", "Изход!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
