using SubnettingCalculator.Models;

namespace SubnettingCalculator;

internal class Program
{
    private static void Main(string[] args)
    {
        var network = new Network("192.168.10.160", 28);
        Console.WriteLine($"IP Address: {network.IPAddress.OctetsToString()}");
        Console.WriteLine($"Subnet Mask: {network.SubnetMask.OctetsToString()}");
        Console.WriteLine($"Wildcard Mask: {network.WildcardMask.OctetsToString()}");
        Console.WriteLine($"Network Address: {network.NetworkAddress.OctetsToString()}/{network.Prefix}");
        Console.WriteLine($"Broadcast Address: {network.BroadcastAddress.OctetsToString()}");
        Console.WriteLine($"First Usable Address: {network.FirstUsableAddress.OctetsToString()}");
        Console.WriteLine($"Last Usable Address: {network.LastUsableAddress.OctetsToString()}");
        Console.WriteLine($"Prefix: {network.Prefix}");
        Console.WriteLine($"Host Bits: {network.HostBits}");
        Console.WriteLine($"Subnets: {network.Subnets}");
        Console.WriteLine($"Hosts: {network.Hosts}");
    }
}