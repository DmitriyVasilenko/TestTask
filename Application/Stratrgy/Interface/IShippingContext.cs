namespace Application.Stratrgy.Interface;

public interface ITotalContext
{
    void SetStrategy(ITotalStrategy strategy);
    void SetStrategy(int item);
    decimal ExecuteStrategy(decimal total);
}
