using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace TestExpression
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			InitOutputControls();
			Debug.Init(WriteLine);

			IEnumerable<Model> arr = new Model[]
			{
				new Model() { PropMdl = new Model() { PropStr = "Test" } },
				new Model(),
				new Model(),
				new Model(),
				new Model()
			};

			var query = from m in arr where m.PropInt == 0 select m;

			var a = query.FirstOrDefault();

			a.TestExp1(a => a.PropStr);
			a.TestExp1(a => a.PropMdl.PropDt);
			a.TestExp1(a => !a.PropMdl.PropBool);

			try
			{
				Debug.Print($"GetMemberName(m => m.PropMdl.PropStr) = {a.GetMemberName(m => m.PropMdl.PropStr)}");
				Debug.Print($"GetMemberValue(m.PropMdl.PropStr.Length) = {a.GetMemberValue(m => m.PropMdl.PropStr.Length)}");
				Debug.Print();
				Debug.Print($"Before: a.PropMdl.PropInt = {a.PropMdl.PropInt}");
				a.SetMemberValue(m => m.PropMdl.PropInt, 100);
				Debug.Print($"After: a.PropMdl.PropInt = {a.PropMdl.PropInt}");
			}
			catch(Exception ex)
			{
				Debug.Print(ex.ToString());
			}
		}
	}
}
