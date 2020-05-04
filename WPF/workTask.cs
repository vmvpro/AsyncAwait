using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwaitWPF
{
	public partial class MainWindow
	{
		private void TaskInit()
		{
			_worker = new Worker();
			_worker.WorkCompleted += WorkerOnWorkCompleted;
			_worker.ProcessChanged += WorkerOnProcessChanged;

			btnTaskOn.Click += BtnTaskOnOnClick;
			btnTaskOff.Click += BtnTaskOffOnClick;
		}

		private void WorkerOnProcessChanged(int i)
		{
			
		}

		private void WorkerOnWorkCompleted(bool b)
		{
			
		}

		private void BtnTaskOffOnClick(object sender, RoutedEventArgs routedEventArgs)
		{
			if(_worker != null)
				_worker.Canceled();
		}

		private async void BtnTaskOnOnClick(object sender, RoutedEventArgs routedEventArgs)
		{
			btnTaskOn.IsEnabled = false;

			var task = await Task<bool>.Factory.StartNew(_worker.WorkTask);
			bool cancelled = task;

			string message = cancelled ? "Proc Cancel" : "Proc Comlled";
			//MessageBox.Show(message);

			btnTaskOn.IsEnabled = true;
		}
	}
}
