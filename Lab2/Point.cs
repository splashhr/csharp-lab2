using System;
using System.Globalization;

namespace Lab2
{
    public class Point
    {
        private double _x;
        private double _y;

        public Point(double x, double y)
        {
            if (!double.IsFinite(x))
            {
                throw new ArgumentOutOfRangeException(nameof(x), "Координата должна быть конечным числом.");
            }

            if (!double.IsFinite(y))
            {
                throw new ArgumentOutOfRangeException(nameof(y), "Координата должна быть конечным числом.");
            }

            _x = x;
            _y = y;
        }

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                if (!double.IsFinite(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Координата должна быть конечным числом.");
                }

                _x = value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (!double.IsFinite(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Координата должна быть конечным числом.");
                }

                _y = value;
            }
        }

        public override string ToString()
        {
            var xText = _x.ToString(CultureInfo.InvariantCulture);
            var yText = _y.ToString(CultureInfo.InvariantCulture);
            return $"{{{xText};{yText}}}";
        }
    }
}
