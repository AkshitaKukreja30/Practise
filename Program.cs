using Microsoft.Extensions.DependencyInjection;
using Practise.Interfaces;
using Practise.Services;


namespace Practise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var serviceProvider = ConfigureServices();

            MyExecutor myExecutor = new MyExecutor(serviceProvider.GetService<IProblems>());
            myExecutor.Execute();
        }


        private static IServiceProvider ConfigureServices()
        {
            var serviceProvider = new ServiceCollection()
                       .AddTransient<IProblems, LongestSubstringWithoutRepeatingChars>()
                       .BuildServiceProvider();
            return serviceProvider;
        }
    }
}