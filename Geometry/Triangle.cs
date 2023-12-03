using System;
using System.Linq;

namespace Geometry;

public sealed class Triangle
{
    private readonly double[] _sides;
    private readonly double _longestSideSquared;
    private readonly double _sidesLengthSquaredSum;

    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Triangle(double a, double b, double c)
    {
        ThrowIfZeroOrLess(a, nameof(A));
        ThrowIfZeroOrLess(b, nameof(B));
        ThrowIfZeroOrLess(c, nameof(C));

        ValidateSidesLength(a, b, c);

        A = a;
        B = b;
        C = c;

        _sides = [A, B, C];
        _longestSideSquared = Math.Pow(_sides.Max(), 2);

        foreach (var side in _sides)
            _sidesLengthSquaredSum += Math.Pow(side, 2);

        _sidesLengthSquaredSum -= _longestSideSquared;
    }

    public TriangleType DetermineType()
    {
        if (_longestSideSquared == _sidesLengthSquaredSum)
            return TriangleType.Right;

        if (_longestSideSquared > _sidesLengthSquaredSum)
            return TriangleType.Obtuse;

        if (_longestSideSquared < _sidesLengthSquaredSum)
            return TriangleType.Acute;

        throw new Exception("Unable to determine the type of triangle.");
    }

    private static void ValidateSidesLength(double a, double b, double c)
    {
        if (a > b + c || b > a + c || c > a + b)
            throw new ArgumentException("Any side of a triangle must be less than the sum of the other two sides.");
    }

    private static void ThrowIfZeroOrLess(double value, string fieldName)
    {
        if (value <= 0)
            throw new ArgumentException($"'{fieldName}' cannot be zero or less than zero.");
    }
}