namespace HashCore;

public interface IFunctionGeneratorFactory<T>
{
    IFunctionGenerator<T> CreateInstance(GeneratorConfig config);
}