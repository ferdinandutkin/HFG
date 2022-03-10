namespace HashCore;

public interface IFunctionGenerator<T>
{
    Function<T> GetFunction();
}