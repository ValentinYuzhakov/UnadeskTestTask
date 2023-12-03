using System;
using Xunit;

namespace Geometry.UnitTests;

public sealed class TriangleTests
{
    [Theory]
    [InlineData(-4, 3, 4)]
    [InlineData(4, -3, 4)]
    [InlineData(4, 3, -4)]
    [InlineData(0, 3, 4)]
    [InlineData(4, 0, 4)]
    [InlineData(4, 3, 0)]
    public void Constructor_CreateTriangleWithZeroOrLessLengthSides_Exception(double a, double b, double c)
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => new Triangle(a, b, c));

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [InlineData(10, 3, 4)]
    [InlineData(4, 10, 4)]
    [InlineData(4, 3, 10)]
    public void Constructor_CreateTriangleWithSideMoreThanSumOfOtherSides_Exception(double a, double b, double c)
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => new Triangle(a, b, c));

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [InlineData(4, 3, 4)]
    public void Constructor_CreateTriangleWithPositiveSides_NoException(double a, double b, double c)
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => new Triangle(a, b, c));

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(17, 15, 8)]
    [InlineData(15, 17, 8)]
    [InlineData(8, 17, 15)]
    public void DetermineType_CreateRightTriangle_RightType(double a, double b, double c)
    {
        //Arrange
        var triangle = new Triangle(a, b, c);

        //Act
        var type = triangle.DetermineType();

        //Assert
        Assert.Equal(TriangleType.Right, type);
    }

    [Theory]
    [InlineData(6, 9, 4)]
    [InlineData(9, 6, 4)]
    [InlineData(4, 6, 9)]
    public void DetermineType_CreateObtuseTriangle_ObtuseType(double a, double b, double c)
    {
        //Arrange
        var triangle = new Triangle(a, b, c);

        //Act
        var type = triangle.DetermineType();

        //Assert
        Assert.Equal(TriangleType.Obtuse, type);
    }

    [Theory]
    [InlineData(4, 3, 4)]
    [InlineData(4, 4, 3)]
    [InlineData(3, 4, 4)]
    public void DetermineType_CreateAcuteTriangle_AcuteType(double a, double b, double c)
    {
        //Arrange
        var triangle = new Triangle(a, b, c);

        //Act
        var type = triangle.DetermineType();

        //Assert
        Assert.Equal(TriangleType.Acute, type);
    }
}
