# Microsoft.Extensions.DependencyInjection.Sample1

## 概要
Microsoft.Extensions.DependencyInjection のサンプルプログラムです。

## 導入

[nuget Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/)

```cmd
dotnet add package Microsoft.Extensions.DependencyInjection
```

## 基本的な使い方
1. ServiceCollection のインスタンスを生成し、DI したいクラスを追加する
2. ServiceCollection から ServiceProvider を生成する
3. ServiceProvider からクラスのインスタンスを取得し使用する

```cs
using Microsoft.Extensions.DependencyInjection;

// 1
var services = new ServiceCollection();
services.AddTransient<IService1, Service1a>();
// AddTransient() … 取得のたびに新しいインスタンスが生成される
// AddSingleton() … 常に同じインスタンスが返る
// AddScoped() … ServiceProvider の CreateScope() と一緒に使用する。そのスコープの範囲では常に同じインスタンスが返る

// 2
var provider = services.BuildServiceProvider();

// 3
var service1 = provider.GetRequiredService<IService1>();
Console.WriteLine(service1.Generate("aiueo"));
// GetRequiredService() … 対象となるクラスが登録されていない場合はエラーとなる
// GetService() … 対象となるクラスが登録されていない場合は null が返る

// 出力
// Service1a - aiueo
```

## インスタンス生成時にパラメータを渡すには
→[インスタンス生成時にパラメータを渡すには](doc/インスタンス生成時にパラメータを渡すには.md)
