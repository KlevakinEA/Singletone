

class Servers
{
    static readonly Servers uniqueInstance = new Servers();
    string[] servers = new string[0];
    private Servers() { }
    public static Servers Instance() { return uniqueInstance; }
    public bool Add(string address)
    {
        if (servers.Contains(address) || (!address.StartsWith("http") && !address.StartsWith("https"))) return false;
        else
        {
            servers.Append(address);
            return true;
        }
    }
}