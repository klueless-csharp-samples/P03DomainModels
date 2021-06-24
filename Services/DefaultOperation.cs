namespace P03DomainModels.Services
{
  using System;

  public class DefaultOperation :
          ITransientOperation,
          IScopedOperation,
          ISingletonOperation
  {
    // public string OperationId { get; } = new Guid().ToString()[^4..];
    public string OperationId { get; } = Guid.NewGuid().ToString()[^4..];
  }
}
