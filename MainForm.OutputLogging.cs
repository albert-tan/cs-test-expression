using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TestExpression
{
	partial class MainForm
	{
		#region Output logging

		public void WriteLine(string format, params object[] args)
		{
			OutputAppendText(string.Format(format, args) + Environment.NewLine);
		}

		public void WriteLine(string message)
		{
			OutputAppendText(message + Environment.NewLine);
		}

		public void WriteLine()
		{
			OutputAppendText(Environment.NewLine);
		}

		private void InitOutputControls()
		{
			uxOutputWrap.CheckedChanged += UxOutputWrap_CheckedChanged;
			uxOutputWrap.Checked = false;
			UpdateWordWrapState();
		}

		private void UpdateWordWrapState()
		{
			uxOutput.WordWrap = uxOutputWrap.Checked;
			uxOutput.ScrollToCaret();
			uxOutput.Focus();
		}

		private void OutputAppendText(string text)
		{
			if(uxOutput.InvokeRequired)
			{
				uxOutput.BeginInvoke(new Action<string>(OutputAppendText), text);
			}
			else
			{
				uxOutput.AppendTextEx(text);
			}
		}

		private void UxOutputWrap_CheckedChanged(object sender, EventArgs e)
		{
			UpdateWordWrapState();
		}

		private class OutputTextBox : TextBox
		{
			#region Win32 calls

			private const int SB_HORZ = 0x0;
			private const int SB_VERT = 0x1;
			private const int WM_HSCROLL = 0x114;
			private const int WM_VSCROLL = 0x115;
			private const int SB_THUMBPOSITION = 4;

			[DllImport("user32.dll")]
			static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			private static extern int GetScrollPos(IntPtr hWnd, int nBar);
			[DllImport("user32.dll")]
			private static extern bool PostMessageA(IntPtr hWnd, int nBar, int wParam, int lParam);

			#endregion

			public void AppendTextEx(string text)
			{
				if(Text.Length != SelectionStart)
				{
					var savedVPos = GetScrollPos(Handle, SB_VERT);
					var savedHPos = GetScrollPos(Handle, SB_HORZ);
					var selLength = SelectionLength;
					var selStart = SelectionStart;
					AppendText(text);
					SetScrollPos(Handle, SB_VERT, savedVPos, false);
					SetScrollPos(Handle, SB_HORZ, savedVPos, false);
					PostMessageA(Handle, WM_VSCROLL, SB_THUMBPOSITION + 0x10000 * savedVPos, 0);
					PostMessageA(Handle, WM_HSCROLL, SB_THUMBPOSITION + 0x10000 * savedHPos, 0);
					Select(selStart, selLength);
				}
				else
				{
					AppendText(text);
				}
			}

			protected override void OnKeyDown(KeyEventArgs e)
			{
				if(e.Control && e.KeyCode == Keys.A)
				{
					SelectAll();
				}
				else
				{
					base.OnKeyDown(e);
				}
			}
		}

		#endregion
	}
}
