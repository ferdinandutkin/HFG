using System.Linq.Expressions;

namespace HashCore;
public static class ExpressionExtensions
{
    public static bool IsAssignmentExpression(this Expression expression) => expression.NodeType is
             ExpressionType.Assign or
             ExpressionType.AddAssign  or
             ExpressionType.AddAssignChecked or
             ExpressionType.AndAssign or
             ExpressionType.DivideAssign or
             ExpressionType.ExclusiveOrAssign or
             ExpressionType.LeftShiftAssign or
             ExpressionType.ModuloAssign or
             ExpressionType.MultiplyAssign or
             ExpressionType.MultiplyAssignChecked  or
             ExpressionType.OrAssign or
             ExpressionType.RightShiftAssign or
             ExpressionType.SubtractAssign or
             ExpressionType.SubtractAssignChecked;
}
