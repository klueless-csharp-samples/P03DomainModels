namespace P03DomainModels.Services
{
  public class BarService : IBarService
  {
    private readonly IFooService fooService;
    public BarService(IFooService fooService)
    {
      this.fooService = fooService;
    }

    public void DoSomeRealWork()
    {
      for (int i = 0; i < 10; i++)
      {
        this.fooService.DoThing(i);
      }
    }
  }
}
