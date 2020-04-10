using System;
using System.Linq.Expressions;

namespace TestExpression
{
	public class Model
	{
		public string PropStr { get; set; }
		public int PropInt { get; set; }
		public bool PropBool { get; set; }
		public Model PropMdl { get; set; }
		public DateTime PropDt { get; set; }
	}

	public static class ModelExtension
	{
		public static void TestExp1<TModel, TResult>(this TModel model, Expression<Func<TModel, TResult>> expression)
		{
			DebugPrint(nameof(expression), expression);
			Debug.Print();
		}

		private static void DebugPrint(string prefix, LambdaExpression expression)
		{
			Debug.Print($"{prefix}.NodeType = {expression.NodeType}");
			Debug.Print($"{prefix}.Type = {expression.Type}");
			for(int i = 0; i < expression.Parameters.Count; i++)
			{
				DebugPrint($"{prefix}.Parameters[{i}]", expression.Parameters[i]);
			}
			DebugPrint($"{prefix}.Body", expression.Body);
			Debug.Print($"{prefix}.ReturnType = {expression.ReturnType.Name}");
		}

		private static void DebugPrint(string prefix, ParameterExpression expression)
		{
			Debug.Print($"{prefix}.NodeType = {expression.NodeType}");
			Debug.Print($"{prefix}.Type = {expression.Type.Name}");
			Debug.Print($"{prefix}.Name = {expression.Name}");
			Debug.Print($"{prefix}.IsByRef = {expression.IsByRef}");
		}

		private static void DebugPrint(string prefix, MemberExpression expression)
		{
			Debug.Print($"{prefix}.NodeType = {expression.NodeType}");
			Debug.Print($"{prefix}.Type = {expression.Type.Name}");
			DebugPrint($"{prefix}.Expression", expression.Expression);
			Debug.Print($"{prefix}.Member.Name = {expression.Member.Name}");
			Debug.Print($"{prefix}.Member.DeclaringType = {expression.Member.DeclaringType.Name}");
			Debug.Print($"{prefix}.Member.MemberType = {expression.Member.MemberType}");
		}

		private static void DebugPrint(string prefix, UnaryExpression expression)
		{
			Debug.Print($"{prefix}.NodeType = {expression.NodeType}");
			Debug.Print($"{prefix}.Type = {expression.Type.Name}");
			if(expression.Method != null)
			{
				Debug.Print($"{prefix}.Method.Name = {expression.Method.Name}");
				Debug.Print($"{prefix}.Method.DeclaringType = {expression.Method.DeclaringType.Name}");
				Debug.Print($"{prefix}.Method.CallingConvention = {expression.Method.CallingConvention}");
				Debug.Print($"{prefix}.Method.ReturnType = {expression.Method.ReturnType.Name}");
			}
			DebugPrint($"{prefix}.Operand", expression.Operand);
		}

		private static void DebugPrint(string prefix, Expression expression)
		{
			if(expression is LambdaExpression lambda)
			{
				DebugPrint(prefix, lambda);
			}
			else if(expression is ParameterExpression parameter)
			{
				DebugPrint(prefix, parameter);
			}
			else if(expression is MemberExpression member)
			{
				DebugPrint(prefix, member);
			}
			else if(expression is UnaryExpression unary)
			{
				DebugPrint(prefix, unary);
			}
			else
			{
				Debug.Print($"{prefix}.NodeType = {expression.NodeType} <<<=== Missing NodeType");
			}
		}
	}
}
