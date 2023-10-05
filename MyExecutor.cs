using Practise.Interfaces;

namespace Practise
{
    public class MyExecutor
    {
        private readonly IProblems _problems;
        public MyExecutor(IProblems problems)
        {
            _problems = problems;
        }

        public void Execute()
        {
            _problems.Execute();
        }
    }
}
