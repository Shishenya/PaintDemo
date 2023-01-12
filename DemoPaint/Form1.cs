using DemoPaint.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoPaint
{
    public partial class Form1 : Form
    {

        private bool _isMousePressed = false; // зажата ли клавиша мышки
        private ArrayPoints _arrayPoints = new ArrayPoints(2);

        private Bitmap _map = new Bitmap(100,100);
        private Graphics _graphics;
        private Pen _pen = new Pen(Color.Black, 3f);

        public Form1()
        {
            InitializeComponent();

            SetStartSize();
        }

        /// <summary>
        /// зажали мышку
        /// </summary>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _isMousePressed = true;
        }

        /// <summary>
        /// Отпустили мышку
        /// </summary>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _isMousePressed = false;
            _arrayPoints.ResetPoints(); // сбрасываем индекс
        }

        /// <summary>
        /// Ведем мышкой
        /// </summary>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMousePressed) return;

            _arrayPoints.SetPoint(e.X, e.Y);
            if (_arrayPoints.GetCurrentIndex()>=2)
            {
                _graphics.DrawLines(_pen, _arrayPoints.GetPoints());
                pictureBox1.Image = _map;
                _arrayPoints.SetPoint(e.X, e.Y);
            }
        }

        /// <summary>
        /// Установка начальных значений
        /// </summary>
        private void SetStartSize()
        {
            // определяем в каком разрешении работает пользователь
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;

            _map = new Bitmap(rectangle.Width, rectangle.Height);
            _graphics = Graphics.FromImage(_map);

            _pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            _pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        /// <summary>
        /// Установка цвета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetColorDraw_Click(object sender, EventArgs e)
        {
            _pen.Color = ((Button)sender).BackColor;
        }

        /// <summary>
        /// Очистка формы рисования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            _graphics.Clear(pictureBox1.BackColor);
            pictureBox1.Image = _map;
        }

        /// <summary>
        /// Изменение толщины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            _pen.Width = trackBar1.Value;
        }

        /// <summary>
        /// Сохранение рисунка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image!=null)
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
                }
            }
        }
    }
}
