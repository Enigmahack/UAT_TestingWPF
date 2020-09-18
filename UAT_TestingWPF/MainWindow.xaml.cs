using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace UAT_TestingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Tests MyTestSuite;
        private ProgressBar progressBarDataPlane1;

        public MainWindow(Tests tests)
        {
            InitializeComponent();

            MyTestSuite = tests;

            string folderPath = @"UAT_Output\";
            var wholePath = Environment.ExpandEnvironmentVariables(folderPath);

            if (!File.Exists("iperf3.exe") || !File.Exists("iperf-2.0.13-win.exe"))
            {
                MessageBox.Show("Please ensure both iperf3.exe and iperf-2.0.13-win.exe are in the same directory as the UAT testing application.");
                Close();
            }
            else if (!Directory.Exists(wholePath))
            {
                tests.MakeDirectory(wholePath);
            }

        }

        private void runAllDPTestsBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Starting Data Plane Tests");

            //string folderPath = @"%UserProfile%\Desktop\UAT_Output\";
            string folderPath = @"UAT_Output\";
            var wholePath = Environment.ExpandEnvironmentVariables(folderPath);

            string fullDataFileName = MyTestSuite.SetDataFileName(wholePath);

            MyTestSuite.RunTests(fullDataFileName, MyTestSuite.DataTestsArray(), new ProgressBarHandler(progressBarDataPlane1));
        }
    }

}
