using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structure
{
        public struct GaussNumber : IEquatable<GaussNumber>
        {
            private const double Epsilon = 1e-13;

            private double _re;
            private double _im;

            public double Re
            {
                get => _re;
                set
                {
                    Validate(value);
                    _re = value;
                }
            }

            public double Im
            {
                get => _im;
                set
                {
                    Validate(value);
                    _im = value;
                }
            }

            public double Norma => _re * _re + _im * _im;

            public GaussNumber(double re, double im)
            {
                Validate(re);
                Validate(im);
                _re = re;
                _im = im;
            }

            private static void Validate(double value)
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                    throw new ArgumentException("Значение должно быть конечным числом.");
            }

            private static bool AlmostEqual(double x, double y)
            {
                return Math.Abs(x - y) <= Epsilon;
            }

            public override string ToString()
            {
                if (AlmostEqual(_re, 0) && AlmostEqual(_im, 0))
                    return "0";

                if (AlmostEqual(_im, 0))
                    return _re.ToString("G17");

                if (AlmostEqual(_re, 0))
                {
                    if (AlmostEqual(_im, 1)) return "i";
                    if (AlmostEqual(_im, -1)) return "-i";
                    return $"{_im:G17}i";
                }

                string sign = _im > 0 ? " + " : " - ";
                double absIm = Math.Abs(_im);

                if (AlmostEqual(absIm, 1))
                    return $"{_re:G17}{sign}i";

                return $"{_re:G17}{sign}{absIm:G17}i";
            }

            public override bool Equals(object obj)
            {
                return obj is GaussNumber other && Equals(other);
            }

            public bool Equals(GaussNumber other)
            {
                return AlmostEqual(_re, other._re) && AlmostEqual(_im, other._im);
            }

            public override int GetHashCode()
            {
                int hash = 17;
                hash = hash * 23 + Math.Round(_re / Epsilon).GetHashCode();
                hash = hash * 23 + Math.Round(_im / Epsilon).GetHashCode();
                return hash;
            }

            public static bool operator ==(GaussNumber left, GaussNumber right) => left.Equals(right);
            public static bool operator !=(GaussNumber left, GaussNumber right) => !left.Equals(right);

            public static GaussNumber operator ~(GaussNumber value)
            {
                return new GaussNumber(value._re, -value._im);
            }

            public static GaussNumber operator +(GaussNumber a, GaussNumber b)
            {
                return new GaussNumber(a._re + b._re, a._im + b._im);
            }

            public static GaussNumber operator *(GaussNumber a, GaussNumber b)
            {
                return new GaussNumber(
                    a._re * b._re - a._im * b._im,
                    a._re * b._im + a._im * b._re
                );
            }
        }
    }
