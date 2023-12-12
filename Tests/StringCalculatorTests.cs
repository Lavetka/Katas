using Katas;

namespace Tests;

public class StringCalculatorTests
{
    StringCalculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new StringCalculator();
    }

    [Test]
    public void Add_EmptyString_ReturnsZero()
    {
        int result = calculator.Add("");
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    [TestCase("0",0)]
    [TestCase("1", 1)]
    [TestCase("2", 2)]
    public void Add_OneNumber_ReturnsNumber(string stringNumber, int expectedResult)
    {
        int result = calculator.Add(stringNumber);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    [TestCase("1,2", 3)]
    [TestCase("0,2", 2)]
    [TestCase("0,1", 1)]
    public void Add_TwoNumbers_ReturnsNumber(string stringNumber, int expectedResult)
    {
        int result = calculator.Add(stringNumber);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    [TestCase("1,2,0", 3)]
    [TestCase("0,1,2", 3)]
    [TestCase("2,1,0", 3)]
    [TestCase("0,0,0", 0)]
    public void Add_ThreeNumbers_ReturnsNumber(string stringNumber, int expectedResult)
    {
        int result = calculator.Add(stringNumber);
        Assert.That(result, Is.EqualTo(expectedResult));
    }


    [Test]
    [TestCase("1,2,0,0,0", 3)]
    [TestCase("0,1,2,2,1,0,0,0", 6)]
    public void Add_ManyNumbers_ReturnsNumber(string stringNumber, int expectedResult)
    {
        int result = calculator.Add(stringNumber);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    [TestCase("1,2,0,0,0a")]
    [TestCase("!,1,2,2,1,0,0,0")]
    [TestCase("1.2.3")]
    public void Add_NotNumbers_ReturnsArgumentException(string stringNumber)
    {
        Assert.Throws<ArgumentException>(() => calculator.Add(stringNumber));
    }

    [Test]
    [TestCase("1,2,0,0,3")]
    [TestCase("1,4,2,1,0,0,0")]
    [TestCase("1,5,3")]
    public void Add_OutOfRangeNumbers_ReturnsArgumentException(string stringNumber)
    {
        Assert.Throws<ArgumentException>(() => calculator.Add(stringNumber));
    }

    [Test]
    [TestCase("1\n2",3)]
    [TestCase("0\n2\n1", 3)]
    [TestCase("1\n2\n1\n2", 6)]
    public void Add_NewLinesBetweenNumbers_ReturnsSum(string stringNumber, int expectedResult)
    {
        int result = calculator.Add(stringNumber);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    [TestCase("\n1")]
    [TestCase("1,\n")]
    [TestCase("1\n2\n1\n")]
    public void Add_NewLinesBetweenNumbers_ReturnsException(string stringNumber)
    {
        Assert.Throws<ArgumentException>(() => calculator.Add(stringNumber));
    }

    [Test]
    [TestCase(";\n1;2", 3)]
    [TestCase(".\n1.2", 3)]
    [TestCase("!\n1!2", 3)]
    public void Add_CustomDelimiter_ReturnsSum(string a, int expectedResult)
    {
        int result = calculator.Add(a);
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    [TestCase("-1", "negatives not allowed: -1")]
    [TestCase("1,-2", "negatives not allowed: -2")]
    [TestCase("-1,-2,-3", "negatives not allowed: -1, -2, -3")]
    public void Add_NegativeNumbers_ThrowsException(string numbers, string expectedExceptionMessage)
    {
        Assert.Throws<ArgumentException>(() => calculator.Add(numbers), expectedExceptionMessage);
    }
}