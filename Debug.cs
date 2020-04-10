using System;
using System.Collections.Generic;
using System.Text;

namespace TestExpression
{
	public static class Debug
	{
		private static Action<string> _writeLine;

		public static void Init(Action<string> writeLine)
		{
			_writeLine = writeLine;
		}

		public static void Print(string msg)
		{
			_writeLine?.Invoke(msg);
		}

		public static void Print()
		{
			_writeLine?.Invoke(string.Empty);
		}
	}
}
