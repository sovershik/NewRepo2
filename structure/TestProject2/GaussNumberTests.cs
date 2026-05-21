using NUnit.Framework;
using structure;
using System;

namespace structure.Tests
{
    [TestFixture]
    public class GaussNumberTests
    {
        private const double Epsilon = 1e-13;

        [Test]
        public void Constructor_SetsPropertiesCorrectly()
        {
            var z = new GaussNumber(2, -3);

            Assert.That(z.Re, Is.EqualTo(2).Within(Epsilon));
            Assert.That(z.Im, Is.EqualTo(-3).Within(Epsilon));
            Assert.That(z.Norma, Is.EqualTo(13).Within(Epsilon));
        }

        [Test]
        public void ToString_WorksCorrectly()
        {
            Assert.That(new GaussNumber(0, 0).ToString(), Is.EqualTo("0"));
            Assert.That(new GaussNumber(5, 0).ToString(), Is.EqualTo("5"));
            Assert.That(new GaussNumber(0, 1).ToString(), Is.EqualTo("i"));
            Assert.That(new GaussNumber(0, -1).ToString(), Is.EqualTo("-i"));
            Assert.That(new GaussNumber(2, 1).ToString(), Is.EqualTo("2 + i"));
            Assert.That(new GaussNumber(2, -1).ToString(), Is.EqualTo("2 - i"));
            Assert.That(new GaussNumber(-2, 3).ToString(), Is.EqualTo("-2 + 3i"));
            Assert.That(new GaussNumber(1, -4).ToString(), Is.EqualTo("1 - 4i"));
        }

        [Test]
        public void EqualsAndHashCode_WorkConsistently()
        {
            var a = new GaussNumber(1.0, 2.0);
            var b = new GaussNumber(1.0 + 1e-14, 2.0 - 1e-14);

            Assert.That(a, Is.EqualTo(b));
            Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
        }

        [Test]
        public void ConjugationOperator_WorksCorrectly()
        {
            var z = new GaussNumber(3, -4);
            var c = ~z;

            Assert.That(c.Re, Is.EqualTo(3).Within(Epsilon));
            Assert.That(c.Im, Is.EqualTo(4).Within(Epsilon));
        }

        [Test]
        public void AdditionOperator_WorksCorrectly()
        {
            var a = new GaussNumber(2, 3);
            var b = new GaussNumber(-1, 4);
            var s = a + b;

            Assert.That(s.Re, Is.EqualTo(1).Within(Epsilon));
            Assert.That(s.Im, Is.EqualTo(7).Within(Epsilon));
        }

        [Test]
        public void MultiplicationOperator_WorksCorrectly()
        {
            var a = new GaussNumber(2, 3);
            var b = new GaussNumber(4, -5);
            var p = a * b;

            Assert.That(p.Re, Is.EqualTo(23).Within(Epsilon));
            Assert.That(p.Im, Is.EqualTo(2).Within(Epsilon));
        }

        [Test]
        public void PropertySetters_ThrowOnInvalidValues()
        {
            var z = new GaussNumber(1, 2);

            Assert.Throws<ArgumentException>(() => z.Re = double.NaN);
            Assert.Throws<ArgumentException>(() => z.Im = double.PositiveInfinity);
        }
    }
}