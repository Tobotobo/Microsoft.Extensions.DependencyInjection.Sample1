using Microsoft.Extensions.DependencyInjection;

// 基本的な使い方
Console.WriteLine("#1");
{
    var services = new ServiceCollection();
    services.AddTransient<IService1, Service1a>(); // ★

    var provider = services.BuildServiceProvider();

    var service1 = provider.GetRequiredService<IService1>();
    Console.WriteLine(service1.Generate("aiueo"));
}

// 登録するクラスを Service1b に差し替えるサンプル
Console.WriteLine("#2");
{
    var services = new ServiceCollection();
    services.AddTransient<IService1, Service1b>(); // ★

    var provider = services.BuildServiceProvider();

    var service1 = provider.GetRequiredService<IService1>();
    Console.WriteLine(service1.Generate("aiueo"));
}

// 自動的にコンストラクタ引数が解決されるサンプル
Console.WriteLine("#3");
{
    var services = new ServiceCollection();
    services.AddTransient<IService1, Service1a>();
    services.AddTransient<IService2, Service2>(); // ★

    var provider = services.BuildServiceProvider();

    var service2 = provider.GetRequiredService<IService2>();
    service2.Print("aiueo");
}

// 自動的にコンストラクタ引数が解決されるサンプル2
Console.WriteLine("#4");
{
    var services = new ServiceCollection();
    services.AddTransient<IService1, Service1b>(); // ★
    services.AddTransient<IService2, Service2>();

    var provider = services.BuildServiceProvider();

    var service2 = provider.GetRequiredService<IService2>();
    service2.Print("aiueo");
}

// Factory クラスを使ってインスタンス生成時にコンストラクタ引数を指定するサンプル
Console.WriteLine("#5");
{
    var services = new ServiceCollection();
    services.AddTransient<IService1, Service1a>(); // ★
    services.AddTransient<IService3Factory, Service3Factory>();

    var provider = services.BuildServiceProvider();

    var service3 = provider.GetRequiredService<IService3Factory>().CreateInstance(true); // ★
    service3.Print("aiueo");
}

// Factory クラスを使ってインスタンス生成時にコンストラクタ引数を指定するサンプル2
Console.WriteLine("#6");
{
    var services = new ServiceCollection();
    services.AddTransient<IService1, Service1b>(); // ★
    services.AddTransient<IService3Factory, Service3Factory>();

    var provider = services.BuildServiceProvider();

    var service3 = provider.GetRequiredService<IService3Factory>().CreateInstance(false); // ★
    service3.Print("aiueo");
}