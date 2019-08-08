# Register multiple implementations of the same interface in DotNet Core (version 2.2 & less)

## Problem statement
Microsoft.Extensions.DependencyInjection doesn't support registering multiple implementations of the same interface in DotNet Core. Typically other IOC containers like Autofac, Structure Map, Unity, etc allow you to register concrete implementations by some Key that distinguishes them. See below example
```csharp
public interface IService { }
public class ServiceA : IService { }
public class ServiceB : IService { } 
public class ServiceC : IService { }

// This is supported by Microsoft.Extensions.DependencyInjection
var service = _serviceProvider.GetService<IService>();
await service.DoSomeThing("My implementation");

// This is not supported by Microsoft.Extensions.DependencyInjection
var serviceA = _serviceProvider.GetService<IService, ServiceA>();
await serviceA.DoSomeThing("My implementation");
var serviceB = _serviceProvider.GetService<IService, ServiceB>();
await serviceB.DoSomeThing("Another implementation");
```
## Solution
You can use IOC containers like Autofac along with Microsoft.Extensions.DependencyInjection, but using two Dependency Injection framework is going to make it more complicated.

Another option is to use the IEnumerable interface and then find the instance you want using LINQ. See example below. The detailed source code can be found [here](/src/DIDotnetCore2.2/DotnetCoreDI/Program.cs)
```csharp
IEnumerable<IService> services = _serviceProvider.GetServices<IService>();
var serviceA = services.Where(s => s.Name == "A").Single();
await serviceA.DoSomeThing("My implementation");

var serviceB = services.Where(s => s.Name == "B").Single();
await serviceB.DoSomeThing("Another implementation");
```