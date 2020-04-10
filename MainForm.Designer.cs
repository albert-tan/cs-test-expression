namespace TestExpression
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.uxRootLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.uxOutputWrap = new System.Windows.Forms.CheckBox();
			this.uxOutput = new TestExpression.MainForm.OutputTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.uxRootLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// uxOutputWrap
			// 
			this.uxOutputWrap.AutoSize = true;
			this.uxOutputWrap.Location = new System.Drawing.Point(3, 430);
			this.uxOutputWrap.Name = "uxOutputWrap";
			this.uxOutputWrap.Size = new System.Drawing.Size(105, 17);
			this.uxOutputWrap.TabIndex = 2;
			this.uxOutputWrap.Text = "Wrap output text";
			this.uxOutputWrap.UseVisualStyleBackColor = true;
			// 
			// uxOutput
			// 
			this.uxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxOutput.Location = new System.Drawing.Point(3, 71);
			this.uxOutput.Multiline = true;
			this.uxOutput.Name = "uxOutput";
			this.uxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.uxOutput.Size = new System.Drawing.Size(794, 353);
			this.uxOutput.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 55);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Output:";
			// 
			// uxRootLayoutPanel
			// 
			this.uxRootLayoutPanel.ColumnCount = 1;
			this.uxRootLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.uxRootLayoutPanel.Controls.Add(this.uxOutputWrap, 0, 3);
			this.uxRootLayoutPanel.Controls.Add(this.uxOutput, 0, 2);
			this.uxRootLayoutPanel.Controls.Add(this.label1, 0, 1);
			this.uxRootLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxRootLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.uxRootLayoutPanel.Name = "uxRootLayoutPanel";
			this.uxRootLayoutPanel.RowCount = 4;
			this.uxRootLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.uxRootLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.uxRootLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.uxRootLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.uxRootLayoutPanel.Size = new System.Drawing.Size(800, 450);
			this.uxRootLayoutPanel.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.uxRootLayoutPanel);
			this.Name = "MainForm";
			this.Text = "Test Form";
			this.uxRootLayoutPanel.ResumeLayout(false);
			this.uxRootLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel uxRootLayoutPanel;
		private System.Windows.Forms.CheckBox uxOutputWrap;
		private TestExpression.MainForm.OutputTextBox uxOutput;
		private System.Windows.Forms.Label label1;
	}
}

