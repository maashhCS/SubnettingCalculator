using SubnettingCalculator.Models;

namespace SubnettingCalculator.UnitTests;

public class SubnettingCalculatorTest
{
    
    [Test]
    [Order(1)]
    [TestCaseSource(typeof(TestCases), nameof(TestCases.TestOctets))]
    public void ConvertOctets(byte[] octets, byte[] expected)
    {
        var result = new IPAddress(octets);
        
        Assert.That(result.Octets, Is.EqualTo(expected));
    }
        
    
    
    [Test]
    [Order(2)]
    [TestCaseSource(typeof(TestCases), nameof(TestCases.TestIps))]
    public void TestIpAdress(string ip, bool expected)
    {
        var test = new BaseAdress();

        if (expected)
        {
            Assert.DoesNotThrow(() => test.OctetsStringToBytesArray(ip));
        } 
        else if (!expected)
        {
            Assert.Throws<ArgumentException>(() => test.OctetsStringToBytesArray(ip));
        }
    }

    [Test]
    [Order(3)]
    [TestCaseSource(typeof(TestCases), nameof(TestCases.TestIpsToOctets))]
    public void ConvertIps(string ip, byte[] result)
    {
        if (result != null)
        {
            Assert.DoesNotThrow(() =>
            {
                new IPAddress(ip);
            });
        }
        else
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new IPAddress(ip);
            });
        }
    }
    
}