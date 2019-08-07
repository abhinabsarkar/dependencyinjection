# Dependency Inversion Principle, Inversion of Control and Dependency Injection

[One of  my favourite article on DI](https://www.codeproject.com/Articles/615139/An-Absolute-Beginners-Tutorial-on-Dependency-Inver)

## Summary
Dependency Injection makes design extensible by allowing to add a new implementation to the abstract class following the Dependency Inversion Principle.

![Alt text](/images/ioc-class-design.jpg)

In this case (see sample [code](/src/DependencyInjection)), adding implementation class "EmailSender", which is extended from the abstract class (Interface) INotificationAction. It is done by passing the object of the concrete class into the constructor of the dependent class (*Constructor Injection*). Dependency Injection can be done in 3 ways - Constructor, Method & Property Injection.

```csharp
// In Program.cs
AppPoolWatcher watcher = new AppPoolWatcher(writer);
await watcher.Notify("Sample message to log");
```

