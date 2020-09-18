using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace UAT_TestingWPF
{
    public interface IProgressHandler
    {
        void UpdateProgress(int value, int max);
    }
    public class ProgressBarHandler : IProgressHandler
    {

        private ProgressBar PBar;

        private static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                                                  new Action(delegate { }));
        }

        public ProgressBarHandler(ProgressBar bar)
        {
            PBar = bar;
        }
        public void UpdateProgress(int value, int max)
        {
            if (value == max)
            {
                PBar.Value = PBar.Maximum;
            }
            else
            {
                PBar.Value = PBar.Maximum / max * (value);
            }
            ProgressBarHandler.DoEvents();
        }
    }
}
