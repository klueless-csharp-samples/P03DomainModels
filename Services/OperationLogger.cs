namespace P03DomainModels.Services
{
  using System;

  public class OperationLogger
  {
    private readonly ITransientOperation transientOperation;
    private readonly IScopedOperation scopedOperation;
    private readonly ISingletonOperation singletonOperation;

    // public OperationLogger(
    //     ITransientOperation transientOperation,
    //     IScopedOperation scopedOperation,
    //     ISingletonOperation singletonOperation) =>
    //     (_transientOperation, _scopedOperation, _singletonOperation) =
    //         (transientOperation, scopedOperation, singletonOperation);

    public OperationLogger(
        ITransientOperation transientOperation,
        IScopedOperation scopedOperation,
        ISingletonOperation singletonOperation)
    {
      this.transientOperation = transientOperation;
      this.scopedOperation = scopedOperation;
      this.singletonOperation = singletonOperation;
    }

    public void LogOperations(string scope)
    {
      LogOperation(this.transientOperation, scope, "Always different");
      LogOperation(this.scopedOperation, scope, "Changes only with scope");
      LogOperation(this.singletonOperation, scope, "Always the same");
    }

    private static void LogOperation<T>(T operation, string scope, string message)
        where T : IOperation =>
        Console.WriteLine(
            $"{scope}: {typeof(T).Name,-19} [ {operation.OperationId}...{message,-23} ]");
  }
}
