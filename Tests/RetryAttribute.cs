using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace SafelyShare.Tests.Tests;

[AttributeUsage(AttributeTargets.Method)]
public sealed class RetryAttribute : NUnitAttribute, IWrapSetUpTearDown
{
    private readonly int _maxAttempts;

    public RetryAttribute(int maxAttempts = 2)
    {
        _maxAttempts = maxAttempts;
    }

    public TestCommand Wrap(TestCommand command)
    {
        return new RetryCommand(command, _maxAttempts);
    }

    private sealed class RetryCommand : DelegatingTestCommand
    {
        private readonly int _maxAttempts;

        public RetryCommand(TestCommand innerCommand, int maxAttempts)
            : base(innerCommand)
        {
            _maxAttempts = maxAttempts;
        }

        public override TestResult Execute(TestExecutionContext context)
        {
            int attempt = 0;

            while (true)
            {
                attempt++;
                TestContext.Progress.WriteLine($"Retry attempt: {attempt}");
                if (context.CurrentResult.ResultState.Status != TestStatus.Failed ||
                    attempt >= _maxAttempts)
                {
                    return context.CurrentResult;
                }

                context.CurrentResult = context.CurrentTest.MakeTestResult();
            }
        }
    }
}