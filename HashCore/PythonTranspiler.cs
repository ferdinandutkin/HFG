using System.Linq.Expressions;
using System.Text;

namespace HashCore;

public class PythonTranspiler : IExpressionTranspiler
{
    private class Visitor : ExpressionVisitor
    {
        private const string Spacing = "    ";
        private const string Return = "return ";
        private static readonly Dictionary<ExpressionType, string> BinaryOperators = new()
        {
            [ExpressionType.Add] = "+",
            [ExpressionType.AddChecked] = "+",
            [ExpressionType.Divide] = "/",
            [ExpressionType.Modulo] = "%",
            [ExpressionType.Multiply] = "*",
            [ExpressionType.MultiplyChecked] = "*",
            [ExpressionType.Subtract] = "-",
            [ExpressionType.SubtractChecked] = "-",
            [ExpressionType.And] = "&",
            [ExpressionType.Or] = "|",
            [ExpressionType.ExclusiveOr] = "^",
            [ExpressionType.AndAlso] = "&&",
            [ExpressionType.OrElse] = "||",
            [ExpressionType.Equal] = "==",
            [ExpressionType.NotEqual] = "!=",
            [ExpressionType.GreaterThanOrEqual] = ">=",
            [ExpressionType.GreaterThan] = ">",
            [ExpressionType.LessThan] = "<",
            [ExpressionType.LessThanOrEqual] = "<=",
            [ExpressionType.Coalesce] = "??",
            [ExpressionType.LeftShift] = "<<",
            [ExpressionType.RightShift] = ">>",
            [ExpressionType.Assign] = "=",
            [ExpressionType.AddAssign] = "+=",
            [ExpressionType.AddAssignChecked] = "+=",
            [ExpressionType.AndAssign] = "&=",
            [ExpressionType.DivideAssign] = "/=",
            [ExpressionType.ExclusiveOrAssign] = "^=",
            [ExpressionType.LeftShiftAssign] = "<<=",
            [ExpressionType.ModuloAssign] = "%=",
            [ExpressionType.MultiplyAssign] = "*=",
            [ExpressionType.MultiplyAssignChecked] = "*=",
            [ExpressionType.OrAssign] = "|=",
            [ExpressionType.RightShiftAssign] = ">>=",
            [ExpressionType.SubtractAssign] = "-=",
            [ExpressionType.SubtractAssignChecked] = "-="
        };

        private readonly StringBuilder _buffer;

        public Visitor(StringBuilder buffer)
        {
            _buffer = buffer;
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            _buffer.Append("def method(");
            _buffer.AppendJoin(", ", node.Parameters.Select(param => $"{param.Name}: {param.Type.GetFriendlyName()}"));
            _buffer.AppendLine($") -> {node.ReturnType.GetFriendlyName()}:");

            Visit(node.Body);

            return node;
        }
        protected override Expression VisitBlock(BlockExpression block)
        {
            foreach (var ex in block.Expressions)
            {
                _buffer.Append(Spacing);

                if (block.Type != typeof(void) && block.Result.Equals(ex) && !ex.IsAssignmentExpression())
                {
                    _buffer.Append(Return);
                }
                Visit(ex);
                _buffer.AppendLine();
                if (block.Type != typeof(void) && block.Result.Equals(ex) && ex.IsAssignmentExpression())
                {
                    _buffer.Append(Spacing);
                    _buffer.Append(Return);
                    Visit((ex as BinaryExpression).Left);
                    _buffer.AppendLine();
                }
            }
            _buffer.AppendLine();
            return block;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            _buffer.Append(node.Name);
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            _buffer.Append(node.Value);
            return node;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Visit(node.Left);
            _buffer.Append($" {BinaryOperators[node.NodeType]} ");
            Visit(node.Right);
            return node;
        }

    }
    public string Transpile(Expression expression)
    {
        var buffer = new StringBuilder();
        new Visitor(buffer).Visit(expression);

        return buffer.ToString();
    }
}