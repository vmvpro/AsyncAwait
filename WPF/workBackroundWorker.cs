using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwaitWPF
{
	public partial class MainWindow
	{
		private BackgroundWorker backgroundWorker;

		private void BackroundWorkerInit()
		{
			//------------------ BackroundWorker -------------------------

			btnBackroundWorker.Click += BtnBackroundWorkerOnClick;
			btnBackroundWorkerCanceled.Click += BtnBackroundWorkerCanceledOnClick;

			backgroundWorker = new BackgroundWorker();
			backgroundWorker.WorkerReportsProgress = true;
			backgroundWorker.WorkerSupportsCancellation = true;
			backgroundWorker.DoWork += BackgroundWorkerOnDoWork;
			backgroundWorker.RunWorkerCompleted += BackgroundWorkerOnRunWorkerCompleted;
			backgroundWorker.ProgressChanged += BackgroundWorkerOnProgressChanged;

			//------------------------------------------------------------
		}

		private void BtnBackroundWorkerOnClick(object sender, RoutedEventArgs routedEventArgs)
		{
			btnBackroundWorker.IsEnabled = false;
			backgroundWorker.RunWorkerAsync();
		}

		private void BtnBackroundWorkerCanceledOnClick(object sender, RoutedEventArgs routedEventArgs)
		{
			backgroundWorker.CancelAsync();
		}

		private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs e)
		{
			for (int i = 0; i <= 100; i++)
			{
				if (backgroundWorker.CancellationPending)
				{
					e.Cancel = true;
					break;
				}

				if (i == 30)
					throw new Exception(String.Format("Ошибка i = {0}", i));

				backgroundWorker.ReportProgress(i);

				Thread.Sleep(50);
			}

		}

		private void BackgroundWorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			ProgressBar1.Value = e.ProgressPercentage;
		}

		private void BackgroundWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message);
			}
			else
			{
				string message = e.Cancelled ? "Proc Cancel" : "Proc Comlled";
				MessageBox.Show(message);

				btnBackroundWorker.IsEnabled = true;
			}

			
		}
	}
}
