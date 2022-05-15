internal class Service3Factory : IService3Factory
{
    private IService1 _service1;

    public Service3Factory(IService1 service1)
    {
        _service1 = service1;
    }

    public IService3 CreateInstance(bool f)
    {
        return new Service3(_service1, f);
    }
}