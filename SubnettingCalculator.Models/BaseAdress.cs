namespace SubnettingCalculator.Models;

public class BaseAdress
{
    public byte[] Octets { get; protected set; }
    
    internal byte[] OctetsStringToBytesArray(string ip)
    {
        var splitted = ip.Split('.');
        if (splitted.Length != 4)
        {
            throw new ArgumentException("Invalid IP address");
        }

        var octets = new byte[4];
        for (var i = 0; i < splitted.Length; i++)
        {
            var octet = splitted[i];
            if (byte.TryParse(octet, out var result))
            {
                octets[i] = result;
            }
            else
            {
                throw new ArgumentException("Invalid IP address");
            }
        }

        return octets;
    }
}