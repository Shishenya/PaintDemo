using System.Drawing;


namespace DemoPaint.Models
{
    public class ArrayPoints
    {

        private int _index = 0;
        private Point[] points;

        public ArrayPoints(int size)
        {
            if (size <= 0) { size = 2; }
            points = new Point[size];
        }

        /// <summary>
        /// Установка точки
        /// </summary>
        public void SetPoint(int x, int y)
        {
            if (_index >= points.Length)
            {
                _index = 0;
            }
            else
            {
                points[_index] = new Point(x, y);
                _index++;
            }
        }

        /// <summary>
        /// Сброс точки начала отчета массива точек
        /// </summary>
        public void ResetPoints()
        {
            _index = 0;
        }

        /// <summary>
        /// Возвращает длину массива нашех точек
        /// </summary>
        public int GetCurrentIndex()
        {
            return _index;
        }

        /// <summary>
        /// Возвращает наш массив точек
        /// </summary>
        public Point[] GetPoints() {
            return points;
        }

    }
}
