class Service2 : IService2
{
    private IService1 _service1;

    public Service2(IService1 service1)
    {
        _service1 = service1;
    }

    public void Print(string s)
    {
        Console.WriteLine($"Service2 - {_service1.Generate(s)}");
    }
}