namespace SubnettingCalculator.Models;

public class IPAddress : BaseAdress
{
    public IPAddress(byte[] octets)
    {
        Octets = octets;
    }

    public IPAddress(string octets)
    {
        Octets = OctetsStringToBytesArray(octets);
    }
    
    
    public static IPAddress operator +(IPAddress ip, int value)
    {
        var newOctets = (byte[])ip.Octets.Clone();
        var carry = value;

        for (var i = 3; i >= 0 && carry != 0; i--)
        {
            var newValue = newOctets[i] + carry;
            newOctets[i] = (byte)(newValue % 256);
            carry = newValue / 256;
        }

        return new IPAddress(newOctets);
    }

    public static IPAddress operator -(IPAddress ip, int value)
    {
        var newOctets = (byte[])ip.Octets.Clone();
        var borrow = value;

        for (var i = 3; i >= 0 && borrow != 0; i--)
        {
            var newValue = newOctets[i] - borrow;
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

        return new IPAddress(newOctets);
    }

    public static IPAddress operator |(IPAddress ip, int value)
    {
        var newOctets = (byte[])ip.Octets.Clone();
        var carry = value;

        for (var i = 3; i >= 0 && carry != 0; i--)
        {
            var newValue = newOctets[i] | carry;
            newOctets[i] = (byte)(newValue % 256);
            carry = newValue / 256;
        }

        return new IPAddress(newOctets);
    }
    
    public static IPAddress operator | (IPAddress a, byte[] b)
    {
        var masked = new byte[4];
        
        for (var i = 3; i >= 0; i--)
        {
            var octet = (byte)(b[i] | a.Octets[i]);

            masked[i] = octet;
        }

        return new IPAddress(masked);
    }

    public static IPAddress operator &(IPAddress ip, int value)
    {
        var newOctets = (byte[])ip.Octets.Clone();
        var carry = value;

        for (var i = 3; i >= 0 && carry != 0; i--)
        {
            var newValue = newOctets[i] & carry;
            newOctets[i] = (byte)(newValue % 256);
            carry = newValue / 256;
        }

        return new IPAddress(newOctets);
    }
}