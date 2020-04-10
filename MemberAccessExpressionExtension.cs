using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace TestExpression
{
	public static class MemberAccessExpressionExtension
	{
		public static string GetMemberName<TDeclaring, TMember>(this TDeclaring obj, Expression<Func<TDeclaring, TMember>> expression)
		{
			if(expression.Body.NodeType != ExpressionType.MemberAccess)
			{
				throw new ArgumentException("Non member access expression");
			}

			return GetMemberName((MemberExpression)expression.Body);
		}

		private static string GetMemberName(MemberExpression memberExp)
		{
			if(memberExp.Expression.NodeType == ExpressionType.MemberAccess)
			{
				return GetMemberName((MemberExpression)memberExp.Expression) + '.' + memberExp.Member.Name;
			}
			if(memberExp.Expression.NodeType == ExpressionType.Parameter)
			{
				return memberExp.Member.Name;
			}
			throw new ArgumentException("Non member access expression");
		}

		public static TMember GetMemberValue<TDeclaring, TMember>(this TDeclaring obj, Expression<Func<TDeclaring, TMember>> expression)
		{
			if(expression.Body.NodeType != ExpressionType.MemberAccess)
			{
				throw new ArgumentException("Non member access expression");
			}

			var memberExp = (MemberExpression)expression.Body;
			if(memberExp.Member is FieldInfo fieldInfo)
			{
				return (TMember)fieldInfo.GetValue(WalkToTail(obj, memberExp));
			}
			if(memberExp.Member is PropertyInfo propInfo)
			{
				return (TMember)propInfo.GetValue(WalkToTail(obj, memberExp));
			}
			throw new ArgumentException("Member is neither Property nor Field.", memberExp.ToString());
		}

		public static void SetMemberValue<TDeclaring, TMember>(this TDeclaring obj, Expression<Func<TDeclaring, TMember>> expression, TMember value)
		{
			if(expression.Body.NodeType != ExpressionType.MemberAccess)
			{
				throw new ArgumentException("Non member access expression");
			}

			var memberExp = (MemberExpression)expression.Body;
			if(memberExp.Member is FieldInfo fieldInfo)
			{
				fieldInfo.SetValue(WalkToTail(obj, memberExp), value);
				return;
			}
			if(memberExp.Member is PropertyInfo propInfo)
			{
				propInfo.SetValue(WalkToTail(obj, memberExp), value);
				return;
			}
			throw new ArgumentException("Member is neither Property nor Field.", memberExp.ToString());
		}

		private static object WalkToTail(object obj, MemberExpression memberExp)
		{
			if(memberExp.Expression.NodeType == ExpressionType.Parameter)
			{
				return obj;
			}
			if(memberExp.Expression.NodeType == ExpressionType.MemberAccess)
			{
				memberExp = (MemberExpression)memberExp.Expression;
				if(memberExp.Member is FieldInfo fieldInfo)
				{
					return fieldInfo.GetValue(WalkToTail(obj, memberExp));
				}
				if(memberExp.Member is PropertyInfo propInfo)
				{
					return propInfo.GetValue(WalkToTail(obj, memberExp));
				}
				throw new ArgumentException("Member is neither Property nor Field.", memberExp.ToString());
			}
			throw new ArgumentException("Non member access expression");
		}
	}
}
