﻿namespace SubnettingCalculator.Models;

public class Network
{
    public Network(string ip, int prefix)
    {
        CalculateAddresses(ip, prefix);
    }

    public Network(byte[] ip, int prefix)
    {
        CalculateAddresses(ip, prefix);
    }

    public IPAddress IPAddress { get; private set; }
    public IPAddress WildcardMask { get; private set; }
    public IPAddress SubnetMask { get; private set; }
    public IPAddress NetworkAddress { get; private set; }
    public IPAddress BroadcastAddress { get; private set; }
    public IPAddress FirstUsableAddress { get; private set; }
    public IPAddress LastUsableAddress { get; private set; }
    public int Prefix { get; private set; }
    public int HostBits { get; private set; }
    public int Subnets { get; private set; }
    public int Hosts { get; private set; }

    public List<Network> NetworkSplit(Network network, int subNetBits)
    {
        var networks = new List<Network>();
        uint networkId = 0;

        for (var i = 0; i < 4; i++)
        {
            networkId |= network.NetworkAddress.Octets[i];
            if (i != 3)
            {
                networkId <<= 8;
            }
        }

        for (uint i = 0; i < (uint)Math.Pow(2, subNetBits); i++)
        {
            var subNetId = networkId | (i << (32 - subNetBits));

            var octets = new byte[4];

            for (var j = 3; j >= 0; j--)
            {
                octets[j] = (byte)subNetId;
                subNetId >>= 8;
            }

            networks.Add(new Network(octets, subNetBits));
        }

        return networks;
    }

    private Network CalculateAddresses(string ip, int prefix)
    {
        IPAddress = new IPAddress(ip);
        Prefix = prefix;
        HostBits = 32 - Prefix;
        Subnets = (int)Math.Pow(2, Prefix);
        Hosts = (int)Math.Pow(2, HostBits) - 2;
        SubnetMask = new IPAddress(CalculateSubnetMask(prefix));
        WildcardMask = new IPAddress(CalculateWildcardMask(prefix));
        NetworkAddress = CalculateNetworkAddress(ip, SubnetMask.ToString());
        // wildcard method
        BroadcastAddress = NetworkAddress | WildcardMask.Octets;
        FirstUsableAddress = NetworkAddress + 1;
        LastUsableAddress = BroadcastAddress - 1;
        return this;
    }

    private Network CalculateAddresses(byte[] ip, int prefix)
    {
        IPAddress = new IPAddress(ip);
        Prefix = prefix;
        HostBits = 32 - Prefix;
        Subnets = (int)Math.Pow(2, Prefix);
        Hosts = (int)Math.Pow(2, HostBits) - 2;
        SubnetMask = new IPAddress(CalculateSubnetMask(prefix));
        WildcardMask = new IPAddress(CalculateWildcardMask(prefix));
        NetworkAddress = CalculateNetworkAddress(ip, SubnetMask.Octets);
        // wildcard method
        BroadcastAddress = NetworkAddress | WildcardMask.Octets;
        FirstUsableAddress = NetworkAddress + 1;
        LastUsableAddress = BroadcastAddress - 1;
        return this;
    }

    private byte[] CalculateWildcardMask(int prefix)
    {
        byte[] subNetMask;
        if (SubnetMask == null)
        {
            subNetMask = CalculateSubnetMask(prefix);
        }
        else
        {
            subNetMask = SubnetMask.Octets;
        }

        var wildcardMask = new byte[4];
        for (var i = 0; i < wildcardMask.Length; i++)
        {
            wildcardMask[i] = (byte)~subNetMask[i];
        }

        return wildcardMask;
    }

    private byte[] CalculateSubnetMask(int prefix)
    {
        var subNetMask = new byte[4];
        for (var i = 0; i < subNetMask.Length; i++)
        {
            if (prefix >= 8)
            {
                subNetMask[i] = 255;
                prefix -= 8;
            }
            else
            {
                subNetMask[i] = (byte)(256 - Math.Pow(2, 8 - prefix));
                prefix = 0;
            }
        }

        return subNetMask;
    }

    private IPAddress CalculateNetworkAddress(string ipAddress, string subnetMask)
    {
        var ipParts = ipAddress.Split('.');
        var maskParts = subnetMask.Split('.');
        var networkBytes = new byte[4];

        for (var i = 0; i < 4; i++)
        {
            var ipByte = byte.Parse(ipParts[i]);
            var maskByte = byte.Parse(maskParts[i]);
            networkBytes[i] = (byte)(ipByte & maskByte);
        }

        return new IPAddress(networkBytes);
    }

    private IPAddress CalculateNetworkAddress(byte[] ipAddress, byte[] subnetMask)
    {
        var networkBytes = new byte[4];

        for (var i = 0; i < 4; i++)
        {
            networkBytes[i] = (byte)(ipAddress[i] & subnetMask[i]);
        }

        return new IPAddress(networkBytes);
    }
}