using SubnettingCalculator.Models;

namespace SubnettingCalculator;

internal class Program
{
    private static void Main(string[] args)
    {
        var network = new Network("192.168.10.1", 24);
        Console.WriteLine($"IP Address: {network.IPAddress}");
        Console.WriteLine($"Subnet Mask: {network.SubnetMask}");
        Console.WriteLine($"Wildcard Mask: {network.WildcardMask}");
        Console.WriteLine($"Network Address: {network.NetworkAddress}/{network.Prefix}");
        Console.WriteLine($"Broadcast Address: {network.BroadcastAddress}");
        Console.WriteLine($"First Usable Address: {network.FirstUsableAddress}");
        Console.WriteLine($"Last Usable Address: {network.LastUsableAddress}");
        Console.WriteLine($"Prefix: {network.Prefix}");
        Console.WriteLine($"Host Bits: {network.HostBits}");
        Console.WriteLine($"Subnets: {network.Subnets}");
        Console.WriteLine($"Hosts: {network.Hosts}");
    }
}