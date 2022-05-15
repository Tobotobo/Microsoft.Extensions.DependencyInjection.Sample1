class Service1a : IService1
{
    public string Generate(string s)
    {
        return $"Service1a - {s}";
    }
}