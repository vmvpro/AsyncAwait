using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwaitWPF
{
	public partial class MainWindow
	{
		void ContinueWithInit()
		{
			btnContinueWith.Click += BtnContinueWithOnClick;
		}

		private async void BtnContinueWithOnClick(object sender, RoutedEventArgs routedEventArgs)
		{

			_worker = new Worker();
			_worker.ProcessChanged += WorkerOnProcessChanged_;

			btnContinueWith.IsEnabled = false;

			var cancelled = await Task<bool>.Factory.StartNew(_worker.WorkContinueWith);

			string message = cancelled ? "Proc Cancel" : "Proc Comlled";
			MessageBox.Show(message);
			btnTaskOn.IsEnabled = true;

			MessageBox.Show("Основной поток завершен!!!");
		}

		private void WorkerOnProcessChanged_(int i)
		{
			
		}

		private bool Work()
		{
			Action action = () =>
			{
				for (int i = 4; i < 6; i++)
				{
					ListBox1.Items.Add(i.ToString());
					Thread.Sleep(2000);
				}
			};

			Dispatcher.Invoke(action);
			

			return true;

		}
	}
}
