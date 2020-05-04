using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AsyncAwaitWPF
{
	/// <summary>
	/// Логика взаимодействия для wndAsyncAwait.xaml
	/// </summary>
	public partial class wndAsyncAwait : Window
	{

		private WorkerNew _workerNew;
		private CancellationTokenSource _tokenSource;				

		public wndAsyncAwait()
		{
			InitializeComponent();
		}

		private void btnThreadOff_Click(object sender, RoutedEventArgs e)
		{
			if (_workerNew != null)
				_workerNew.Canceled();

			btnTaskOn.IsEnabled = true;
		}
		

		private async void btnTaskOn_Click(object sender, RoutedEventArgs e)
		{
			_workerNew = new WorkerNew();

			_workerNew.ProcessChanged += WorkerOnProcessChanged;
			_workerNew.WorkCompleted += WorkerOnWorkCompleted;

			btnTaskOn.IsEnabled = false;

			Thread thread = new Thread(_workerNew.Work);
			thread.Start();

		}

		private void WorkerOnProcessChanged(int progress)
		{
			Action action = () =>{ progressBar1.Value = progress; };

			Dispatcher.Invoke(action);
		}

		private void WorkerOnWorkCompleted(bool _cancelled)
		{
			Action action = () =>
			{
				string message = _cancelled ? "Процесс отменен!" : "Процесс завершен!";

				MessageBox.Show(message);

				btnTaskAsyncAwaitOn.IsEnabled = true;
			};

			Dispatcher.Invoke(action);
		}

		private async void btnTaskAsyncAwaitOn_Click(object sender, RoutedEventArgs e)
		{

			#region MyRegion

			//_worker = new Worker();
			//_worker.ProcessChanged += WorkerOnProcessChanged;
			//_worker.WorkCompleted += WorkerOnWorkCompleted;

			//_tokenSource = new CancellationTokenSource();
			//CancellationToken token = _tokenSource.Token;

			//Task<bool> task = null;
			//btnTaskOn.IsEnabled = false;
			//bool isError = false;
			//string message_ = "";

			//bool _cancelled = false;

			//try
			//{
			//	task = Task<bool>.Factory.StartNew(() => _worker.WorkTask(token), token);
			//	_cancelled = await task;
			//}
			//catch (Exception ex)
			//{
			//	isError = true;
			//	message_ = String.Format("Error btnTaskAsyncAwaitOn {0} !", ex.Message);
			//}
			
			//if (!isError)
			//	message_ = _cancelled ? "Proc Cancel" : "Proc Comlled";
	
			//MessageBox.Show(message_);

			//btnTaskOn.IsEnabled = true;

			#endregion
		}

		

		private void btnTaskAsyncAwaitOff_Click(object sender, RoutedEventArgs e)
		{


			if (_workerNew != null)
				_workerNew.Canceled();
		}

		
	}
}
