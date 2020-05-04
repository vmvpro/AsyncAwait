using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncAwaitWPF
{



	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Worker _worker;

		private Thread thread;

		private SynchronizationContext context;

		private TaskScheduler taskScheduler;

		//private bool cancelled = false;

		public MainWindow()
		{
			InitializeComponent();

			context = SynchronizationContext.Current;

			BackroundWorkerInit();
			TaskInit();
			ContinueWithInit();

			btnOn.Click += btn1_Click;
			btnCancel.Click += btn2_Click;

			btnSynchronizationContext.Click += BtnSynchronizationContextOnClick;

			btnList1.Click += BtnList1OnClick;

			_worker = new Worker();
			_worker.ProcessChanged += _worker_ProcessChanged;
			_worker.WorkCompleted += _worker_WorkCompleted;

			_worker.ProcessAddListBox += WorkerOnProcessAddListBox;
			_worker.WorkCompletedListBox += WorkerOnWorkCompletedListBox;



		}



		private void BtnSynchronizationContextOnClick(object sender, RoutedEventArgs routedEventArgs)
		{
			//_worker.WorkSynchronizationContext(context); 
			thread = new Thread(_worker.WorkSynchronizationContext);
			thread.Start(context);
		}

		private void WorkerOnWorkCompletedListBox(bool b)
		{
			Action action = () =>
			{
				string message = b ? "Proc Cancel" : "Proc Comlled";
				MessageBox.Show(message);

				//btn1.IsEnabled = true;
			};

			ListBox1.Dispatcher.Invoke(action);
		}

		private async void WorkerOnProcessAddListBox(int i)
		{
			#region Action 1

			//Action action = () =>
			//{
			//	ListBox1.Items.Add((i + 1).ToString());
			//};

			//ListBox1.Dispatcher.Invoke(action);
			//Dispatcher.Invoke(action);

			Dispatcher.Invoke(() =>
			{
				ListBox1.Items.Add((i + 1).ToString());
			});




			#endregion
		}

		private void BtnList1OnClick(object sender, RoutedEventArgs routedEventArgs)
		{
			thread = new Thread(_worker.listWork);
			thread.Start();
		}

		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show("Hello VMV");

			btnOn.IsEnabled = false;

			thread = new Thread(_worker.Work);
			thread.Start();

		}

		private void _worker_WorkCompleted(bool cancelled)
		{
			Action action = () =>
			{
				string message = cancelled ? "Proc Cancel" : "Proc Comlled";
				MessageBox.Show(message  /* + "\n" + (ProgressBar1.Value + 1)*/);

				btnOn.IsEnabled = true;
			};

			ProgressBar1.Dispatcher.Invoke(action);

		}

		private void _worker_ProcessChanged(int progress)
		{

			#region Action 1

			Action action = () =>
			{
				ProgressBar1.Value = progress;
			};

			ProgressBar1.Dispatcher.Invoke(action);

			#endregion

			//Action action2 = Action2;

			//ProgressBar1.Dispatcher.Invoke(action2);

		}

		private void Action2(int progress)
		{
			//ProgressBar1.Value = progress + 1;
			ProgressBar1.Value = progress;
		}

		private void btn2_Click(object sender, RoutedEventArgs e)
		{
			thread.Abort();

			MessageBox.Show("Proc Stop");

			btnOn.IsEnabled = true;
		}


		#region AsyncAwait

		private void Button_Click(object sender, RoutedEventArgs e)
		{

			//Label1.Content = "YES!!!";
			//Label1.Content = await Task<string>.Factory.StartNew(() =>
			//{
			//	Thread.Sleep(3000);
			//	return "Выполнено!!!";
			//});

			//await Task.Factory.StartNew(() =>
			//	{
			//		 Thread.Sleep(2000);
			//		ListBox1.Items.Add(1.ToString());

			//		Thread.Sleep(2000);
			//		ListBox1.Items.Add(2.ToString());
			//	});

			//await Task.Factory.StartNew(listTask1(1));

			//await Task.Run(lst);
			//await listTask1(1);

			//ListBox1.Items.Add(3.ToString());
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			#region Часы

			Action action = () =>
			{
				while (true)
				{
					Dispatcher.Invoke((Action)(() => Label1.Content = DateTime.Now.ToLongTimeString()));

					Thread.Sleep(1000);
				}

			};

			#endregion

			taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

			// Вызов задач, несколько способов
			// 1
			//Task task = new Task(action);
			//task.Start();

			// 2
			//new Task(action).Start();

			// 3
			Task task3 = Task.Factory.StartNew(action);
			

			//Label1.Dispatcher.Invoke(action);

			
			

		}

		//async Action lst()
		//{
		//	MessageBox.Show("Hello!!!");
		//}

		//private Func<int> listTask1(int i)
		//{
		//	Thread.Sleep(2000);
		//	ListBox1.Items.Add(i.ToString());

		//	return (Func<int>) i;
		//}



		//private async Task listTask()
		//{
		//	for (int i = 0; i < 3; i++)
		//	{
		//		ListBox1.Items.Add((i + 1).ToString());
		//		Thread.Sleep(2000);
		//	}
		//}

		#endregion



	}
}
