using System;

namespace Lab2
{
    public class Line
    {
        private Point _start;
        private Point _end;

        public Line(Point start, Point end)
        {
            ArgumentNullException.ThrowIfNull(start);
            ArgumentNullException.ThrowIfNull(end);
            _start = start;
            _end = end;
        }

        public Point Start
        {
            get
            {
                return _start;
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                _start = value;
            }
        }

        public Point End
        {
            get
            {
                return _end;
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                _end = value;
            }
        }

        public override string ToString()
        {
            return $"Линия от {_start} до {_end}";
        }
    }
}
