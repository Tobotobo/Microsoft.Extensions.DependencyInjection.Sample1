class Service3 : IService3
{
    private IService1 _service1;
    private bool _f;

    public Service3(IService1 service1, bool f)
    {
        _service1 = service1;
        _f = f;
    }

    public void Print(string s)
    {
        Console.WriteLine($"Service3 - {_f} - {_service1.Generate(s)}");
    }
}