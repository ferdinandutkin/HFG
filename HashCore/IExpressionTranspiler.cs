using System.Linq.Expressions;

namespace HashCore;

public interface IExpressionTranspiler
{
    string Transpile(Expression expression);
}