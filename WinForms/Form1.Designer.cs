namespace WinForms
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnLoadWebSite = new System.Windows.Forms.Button();
			this.txtDisplay = new System.Windows.Forms.TextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btnLoadWebSite
			// 
			this.btnLoadWebSite.Location = new System.Drawing.Point(60, 107);
			this.btnLoadWebSite.Name = "btnLoadWebSite";
			this.btnLoadWebSite.Size = new System.Drawing.Size(87, 23);
			this.btnLoadWebSite.TabIndex = 1;
			this.btnLoadWebSite.Text = "LoadWebSite";
			this.btnLoadWebSite.UseVisualStyleBackColor = true;
			this.btnLoadWebSite.Click += new System.EventHandler(this.btnLoadWebSite_Click);
			// 
			// txtDisplay
			// 
			this.txtDisplay.Location = new System.Drawing.Point(153, 110);
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.Size = new System.Drawing.Size(327, 20);
			this.txtDisplay.TabIndex = 2;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(60, 218);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(248, 121);
			this.listBox1.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(60, 189);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(332, 189);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// listBox2
			// 
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point(332, 218);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(248, 121);
			this.listBox2.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(805, 450);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.txtDisplay);
			this.Controls.Add(this.btnLoadWebSite);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnLoadWebSite;
		private System.Windows.Forms.TextBox txtDisplay;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox listBox2;
	}
}

