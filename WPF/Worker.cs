using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitWPF
{
	public class Worker
	{
		

		public event Action<int> ProcessAddListBox;
		public event Action<bool> WorkCompletedListBox;

		private bool _cancelled = false;

		public void Canceled()
		{
			_cancelled = true;
		}

		public void WorkSynchronizationContext(object param) 
		{
			SynchronizationContext context = (SynchronizationContext) param;

			for (int i = 0; i <= 100; i++)
			{
				if (_cancelled)
					break;

				Thread.Sleep(50);

				context.Send(OnProgressChange, i);
			}

			context.Send(OnCompleted, _cancelled);
		}

		public void OnProgressChange(object i)
		{
			if (ProcessChanged != null)
				ProcessChanged((int) i);
		}

		public void OnCompleted(object cancelled)
		{
			if (WorkCompleted != null)
				WorkCompleted((bool)cancelled);
		}

		public void Work()
		{
			for (int i = 0; i <= 100; i++)
			{
				if (_cancelled)
					break;

				Thread.Sleep(50);

				ProcessChanged(i);
			}

			WorkCompleted(_cancelled);

		}

		public bool WorkContinueWith()
		{
			for (int i = 0; i <= 100; i++)
			{
				if (_cancelled)
					break;

				Thread.Sleep(50);

				OnProgressChange(i);
			}

			OnCompleted(_cancelled);

			return _cancelled;

		}

		public bool WorkTask()
		{
			for (int i = 0; i <= 100; i++)
			{
				if (_cancelled)
					break;

				Thread.Sleep(50);

				if (i == 30)
					throw new Exception(String.Format("Ошибка i = {0}", i));

				OnProgressChange(i);
			}

			OnCompleted(_cancelled);

			return _cancelled;

		}

		public bool WorkTask(CancellationToken token)
		{
			for (int i = 0; i <= 100; i++)
			{
				token.ThrowIfCancellationRequested();

				//if (_cancelled)
				//	break;

				Thread.Sleep(50);

				//if (i == 30)
				//	throw new Exception(String.Format("Ошибка i = {0}", i));

				OnProgressChange(i);
				//ProcessChanged(i);
			}

			//WorkCompleted(_cancelled);

			return _cancelled;

		}

		public event Action<int> ProcessChanged;
		public event Action<bool> WorkCompleted;

		public void listWork()
		{
			for (int i = 0; i < 3; i++)
			{
				if (_cancelled)
					break;

				Thread.Sleep(2000);

				ProcessAddListBox(i);
			}

			WorkCompletedListBox(_cancelled);

		}

		
	}
}
