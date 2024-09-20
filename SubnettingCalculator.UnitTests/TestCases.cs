namespace SubnettingCalculator.UnitTests;

public class TestCases
{
    public static IEnumerable<TestCaseData> TestIps
    {
        get
        {
            yield return new TestCaseData("0.0.0.0", true).SetName("0.0.0.0");
            yield return new TestCaseData("127.0.0.1", true).SetName("127.0.0.1");
            yield return new TestCaseData("255.255.255.0", true).SetName("255.255.255.0");
            yield return new TestCaseData("10.0.0.1", true).SetName("10.0.0.1");
            yield return new TestCaseData("172.16.0.1", true).SetName("172.16.0.1");
            yield return new TestCaseData("192.0.2.1", true).SetName("192.0.2.1");
            yield return new TestCaseData("203.0.113.1", true).SetName("203.0.113.1");
            yield return new TestCaseData("123.456.789.0", false).SetName("123.456.789.0");
            yield return new TestCaseData("192.168.1.256", false).SetName("192.168.1.256");
            yield return new TestCaseData("192.168.1.", false).SetName("192.168.1.");
            yield return new TestCaseData("192.168..1", false).SetName("192.168..1");
            yield return new TestCaseData(".192.168.1.1", false).SetName(".192.168.1.1");
            yield return new TestCaseData("192.168.1.1.", false).SetName("192.168.1.1.");
            yield return new TestCaseData("192.168.1.1.1", false).SetName("192.168.1.1.1");
            yield return new TestCaseData("abc.def.ghi.jkl", false).SetName("abc.def.ghi.jkl");
            yield return new TestCaseData("192.168.1", false).SetName("192.168.1");
            yield return new TestCaseData("192.168", false).SetName("192.168");
            yield return new TestCaseData("192", false).SetName("192");
        }
    }
    
    
    public static IEnumerable<TestCaseData> TestOctets
    {
        get
        {
            yield return new TestCaseData(new byte[]{1, 1, 1, 1}, new byte[]{1, 1, 1, 1}).SetName("Case 1");
            yield return new TestCaseData(new byte[]{1, 1, 156, 1}, new byte[]{1, 1, 156, 1}).SetName("Case 2");
            yield return new TestCaseData(new byte[]{255, 255, 255, 255}, new byte[]{255, 255, 255, 255}).SetName("Case 3");
            yield return new TestCaseData(new byte[]{192, 168, 10, 1}, new byte[]{192, 168, 10, 1}).SetName("Case 4");
        }
    }

    public static IEnumerable<TestCaseData> TestIpsToOctets
    {
        get
        {
            yield return new TestCaseData(string.Empty, null).SetName("Case 1");
            yield return new TestCaseData("1.1.1.1", new byte[]{1, 1, 1, 1}).SetName("Case 2");
            yield return new TestCaseData("1.1.1", null).SetName("Case 3");
            yield return new TestCaseData("1.1.156.1", new byte[]{1, 1, 156, 1}).SetName("Case 4");
            yield return new TestCaseData("255", null).SetName("Case 5");
            yield return new TestCaseData("255.255.255.255", new byte[]{255, 255, 255, 255}).SetName("Case 6");
            yield return new TestCaseData("192.168.10.1", new byte[]{192, 168, 10, 1}).SetName("Case 7");
            yield return new TestCaseData("255.b.123.2", null).SetName("Case 8");
            yield return new TestCaseData("8.8.8.8", new byte[]{8, 8, 8, 8}).SetName("Case 9");
            yield return new TestCaseData("256.168.10.1", null).SetName("Case 10");
            yield return new TestCaseData("0.0.0.0", new byte[]{0, 0, 0, 0}).SetName("Case 11");
            yield return new TestCaseData("127.0.0.1", new byte[]{127, 0, 0, 1}).SetName("Case 12");
            yield return new TestCaseData("192.0.2.0", new byte[]{192, 0, 2, 0}).SetName("Case 13");
            yield return new TestCaseData("255.255.255.256", null).SetName("Case 14");
            yield return new TestCaseData("123.456.789.0", null).SetName("Casee 15");
        }
    }
}