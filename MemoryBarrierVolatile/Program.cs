internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Blocking();
    }

    private static /*volatile*/ bool complete = false;

    private static void Blocking()
    {
        var t = new Thread(() =>
        {
            bool toggle = false;
            while (!complete) toggle = !toggle;
        });
        t.Start();
        Thread.Sleep(1000);
        complete = true;
        t.Join();     // blocks
    }
}