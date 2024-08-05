namespace Test.Server.Api;

public class SomeSingletonExample
{
    public static SomeSingletonExample Instance => _instance.Value;
    private static readonly Lazy<SomeSingletonExample> _instance = new Lazy<SomeSingletonExample>(() => new SomeSingletonExample());

    private SomeSingletonExample() { }

    public void Initialize() { }

    public void ExecuteHangfireJob()
    {
        Console.WriteLine("Job executed");
    }
}
