using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class City
    {
        private readonly string _name;
        private readonly List<Route> _routes;

        public City(string name)
            : this(name, Array.Empty<Route>())
        {
        }

        public City(string name, Route[] routes)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Название города не должно быть пустым.", nameof(name));
            }

            ArgumentNullException.ThrowIfNull(routes);

            _name = name.Trim();
            _routes = new List<Route>();

            foreach (var route in routes)
            {
                if (route == null)
                {
                    throw new ArgumentException("Путь не должен быть null.", nameof(routes));
                }

                _routes.Add(route);
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public IReadOnlyList<Route> Routes
        {
            get
            {
                return _routes.AsReadOnly();
            }
        }

        public void AddRoute(City destination, int cost)
        {
            _routes.Add(new Route(destination, cost));
        }

        public override string ToString()
        {
            var text = new StringBuilder();
            text.Append(Name);
            text.Append(": [");

            for (var index = 0; index < _routes.Count; index++)
            {
                if (index > 0)
                {
                    text.Append(", ");
                }

                text.Append(_routes[index]);
            }

            text.Append(']');
            return text.ToString();
        }
    }
}
