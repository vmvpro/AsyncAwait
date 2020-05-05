using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private async void btnLoadWebSite_Click(object sender, EventArgs e)
		{
			txtDisplay.Text = "Fetching...";
			txtDisplay.Text = await LoadAsync();

		}

		private void Load()
		{
			txtDisplay.Text = "";
		}

		private Task<string> async01()
		{
			return null;
		}

		private Task<string> LoadAsync()
		{
			Func<string> methodCall = () =>
			{
				Thread.Sleep(5000);
				return "Hello VMV!!!";
			};

			return Task.Run(methodCall);
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			await AddListAsync01();
		}

		private async Task AddListAsync01()
		{
			await Task.Run(() =>
			{
				for (int i = 0; i < 5; i++)
					ItemAdd("Item " + i + " VMV");
			});

		}

		private void ItemAdd(string item)
		{
			Thread.Sleep(2000);
			listBox1.Items.Add(item);
		}

		private async void button2_Click(object sender, EventArgs e)
		{
			await AddListAsync02();
		}

		private async Task AddListAsync02()
		{
			Action action2 = itemAdd2;
			await Task.Run(action2);

		}

		private void itemAdd2()
		{
			for (int i = 0; i < 5; i++)
			{
				Thread.Sleep(2000);
				listBox2.Items.Add("task2: " + (i+1) + " VMV");
			}
				
			
		}

		


	}
}
