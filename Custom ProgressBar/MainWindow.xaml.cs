using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Custom_ProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker WorkerThread = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();
           // InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            try
            {
                WorkerThread.WorkerReportsProgress = true;
                WorkerThread.DoWork += new DoWorkEventHandler(WorkerThread_DoWork);
                WorkerThread.ProgressChanged += new ProgressChangedEventHandler(WorkerThread_ProgressChanged);
                WorkerThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkerThread_RunWorkerCompleted);

                WorkerThread.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void WorkerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                PBar.Value = PBar.Maximum;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void WorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                PBar.Value = e.ProgressPercentage;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void WorkerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(30);


                    WorkerThread.ReportProgress(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
