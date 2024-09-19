namespace SubnettingCalculator.Models;

public class IpAdress : BaseAdress
{
    public IpAdress(byte[] octets)
    {
        Octets = octets;
    }

    public IpAdress(string octets)
    {
        Octets = OctetsStringToBytesArray(octets);
    }

    public static IpAdress operator +(IpAdress ip, int value)
    {
        var newOctets = (byte[])ip.Octets.Clone();
        int carry = value;

        for (int i = 3; i >= 0 && carry != 0; i--)
        {
            int newValue = newOctets[i] + carry;
            newOctets[i] = (byte)(newValue % 256);
            carry = newValue / 256;
        }

        return new IpAdress(newOctets);
    }

    public static IpAdress operator -(IpAdress ip, int value)
    {
        var newOctets = (byte[])ip.Octets.Clone();
        int borrow = value;

        for (int i = 3; i >= 0 && borrow != 0; i--)
        {
            int newValue = newOctets[i] - borrow;
            if (newValue < 0)
            {
                newOctets[i] = (byte)(newValue + 256);
                borrow = 1;
            }
            else
            {
                newOctets[i] = (byte)newValue;
                borrow = 0;
            }
        }

        return new IpAdress(newOctets);
    }

    public static IpAdress operator |(IpAdress ip, int value)
    {
        var newOctets = (byte[])ip.Octets.Clone();
        int carry = value;

        for (int i = 3; i >= 0 && carry != 0; i--)
        {
            int newValue = newOctets[i] | carry;
            newOctets[i] = (byte)(newValue % 256);
            carry = newValue / 256;
        }

        return new IpAdress(newOctets);
    }

    public static IpAdress operator &(IpAdress ip, int value)
    {
        var newOctets = (byte[])ip.Octets.Clone();
        int carry = value;

        for (int i = 3; i >= 0 && carry != 0; i--)
        {
            int newValue = newOctets[i] & carry;
            newOctets[i] = (byte)(newValue % 256);
            carry = newValue / 256;
        }

        return new IpAdress(newOctets);
    }
}