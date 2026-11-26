using System;
using System.Globalization;

namespace Lab2
{
    public class Route
    {
        private readonly City _destination;
        private readonly int _cost;

        public Route(City destination, int cost)
        {
            ArgumentNullException.ThrowIfNull(destination);

            if (cost < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cost), "Стоимость пути не может быть отрицательной.");
            }

            _destination = destination;
            _cost = cost;
        }

        public City Destination
        {
            get
            {
                return _destination;
            }
        }

        public int Cost
        {
            get
            {
                return _cost;
            }
        }

        public override string ToString()
        {
            // Выводим только название, чтобы не обходить циклические связи между городами.
            return Destination.Name + ":" + Cost.ToString(CultureInfo.InvariantCulture);
        }
    }
}
