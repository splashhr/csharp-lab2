using System.Text;

namespace Lab2
{
    public class PersonName
    {
        private readonly string _surname;
        private readonly string _givenName;
        private readonly string _patronymic;

        public PersonName(string? surname = null, string? givenName = null, string? patronymic = null)
        {
            _surname = surname?.Trim() ?? string.Empty;
            _givenName = givenName?.Trim() ?? string.Empty;
            _patronymic = patronymic?.Trim() ?? string.Empty;
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
        }

        public string GivenName
        {
            get
            {
                return _givenName;
            }
        }

        public string Patronymic
        {
            get
            {
                return _patronymic;
            }
        }

        public override string ToString()
        {
            var parts = new string[] { _surname, _givenName, _patronymic };
            var result = new StringBuilder();

            foreach (var part in parts)
            {
                if (part.Length == 0)
                {
                    continue;
                }

                if (result.Length > 0)
                {
                    result.Append(' ');
                }

                result.Append(part);
            }

            return result.ToString();
        }
    }
}
