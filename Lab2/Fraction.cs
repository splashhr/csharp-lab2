using System;

namespace Lab2
{
    public class Fraction
    {
        private readonly int _numerator;
        private readonly int _denominator;

        public Fraction(int numerator, int denominator)
            : this((long)numerator, denominator)
        {
        }

        private Fraction(long numerator, long denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(denominator), "Знаменатель не должен быть равен нулю.");
            }

            // Знак хранится в числителе, а знаменатель всегда положительный.
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            var divisor = GreatestCommonDivisor(Math.Abs(numerator), denominator);
            _numerator = checked((int)(numerator / divisor));
            _denominator = checked((int)(denominator / divisor));
        }

        public int Numerator
        {
            get
            {
                return _numerator;
            }
        }

        public int Denominator
        {
            get
            {
                return _denominator;
            }
        }

        public Fraction Sum(Fraction other)
        {
            ArgumentNullException.ThrowIfNull(other);
            var numerator = (long)_numerator * other._denominator + (long)other._numerator * _denominator;
            var denominator = (long)_denominator * other._denominator;
            return new Fraction(numerator, denominator);
        }

        public Fraction Sum(int value)
        {
            return Sum(new Fraction(value, 1));
        }

        public Fraction Minus(Fraction other)
        {
            ArgumentNullException.ThrowIfNull(other);
            var numerator = (long)_numerator * other._denominator - (long)other._numerator * _denominator;
            var denominator = (long)_denominator * other._denominator;
            return new Fraction(numerator, denominator);
        }

        public Fraction Minus(int value)
        {
            return Minus(new Fraction(value, 1));
        }

        public Fraction Multiply(Fraction other)
        {
            ArgumentNullException.ThrowIfNull(other);
            var numerator = (long)_numerator * other._numerator;
            var denominator = (long)_denominator * other._denominator;
            return new Fraction(numerator, denominator);
        }

        public Fraction Multiply(int value)
        {
            return Multiply(new Fraction(value, 1));
        }

        public Fraction Div(Fraction other)
        {
            ArgumentNullException.ThrowIfNull(other);
            if (other._numerator == 0)
            {
                throw new DivideByZeroException("Нельзя делить на нулевую дробь.");
            }

            var numerator = (long)_numerator * other._denominator;
            var denominator = (long)_denominator * other._numerator;
            return new Fraction(numerator, denominator);
        }

        public Fraction Div(int value)
        {
            return Div(new Fraction(value, 1));
        }

        public override string ToString()
        {
            return $"{_numerator}/{_denominator}";
        }

        private static long GreatestCommonDivisor(long first, long second)
        {
            while (second != 0)
            {
                var remainder = first % second;
                first = second;
                second = remainder;
            }

            return first;
        }
    }
}
