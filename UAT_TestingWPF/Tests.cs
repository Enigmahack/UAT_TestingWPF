using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace UAT_TestingWPF
{
    public class Tests
    {
        String outputFileName;

        public string[] DataTestsArray()
        {
            string[] testData = new string[7];

            testData[0] = "ipconfig /all";
            testData[1] = "iperf3 -c gt-aziperf-vm -t 50 -i 1";
            testData[2] = "iperf3 -c gt-aziperf-vm -t 50 -R -i 1";
            testData[3] = "iperf3 -c gt-aziperf-vm -t 50 -u -i 1";
            testData[4] = "iperf3 -c gt-aziperf-vm -t 50 -u -R -i 1";
            testData[5] = "iperf3 -c gt-aziperf-vm -t 50 -u -b 200M -i 1";
            testData[6] = "iperf3 -c gt-aziperf-vm -t 50 -u -b 200M -R -i 1";

            return testData;
        }

        public string[] MgmtTestsArray(IPHandler ipHandler)
        {
            string[] testMgmt = new string[7];

            testMgmt[0] = "tracert " + ipHandler.OverrideIP;
            testMgmt[1] = "iperf-2.0.13-win -c " + ipHandler.OverrideIP + " -t 50 -i 1";
            testMgmt[2] = "iperf-2.0.13-win -c " + ipHandler.OverrideIP + " -t 50 -R -i 1";
            testMgmt[3] = "iperf-2.0.13-win -c " + ipHandler.OverrideIP + " -t 50 -u -i 1";
            testMgmt[4] = "iperf-2.0.13-win -c " + ipHandler.OverrideIP + " -t 50 -u -R -i 1";
            testMgmt[5] = "iperf-2.0.13-win -c " + ipHandler.OverrideIP + " -t 50 -u -b 200M -i 1";
            testMgmt[6] = "iperf-2.0.13-win -c " + ipHandler.OverrideIP + " -t 50 -u -b 200M -R -i 1";

            return testMgmt;
        }

        public string[] MgmtTestsExtendedArray(IPHandler ipHandler)
        {
            string[] testMgmt = new string[5];

            testMgmt[0] = "tracert " + ipHandler.OverrideIP;
            testMgmt[1] = "iperf-2.0.13-win -c " + ipHandler.OverrideIP + " -t 50 -i 5 -w 150k";
            testMgmt[2] = "iperf-2.0.13-win -c " + ipHandler.OverrideIP + " -t 50 -R -i 5 -w 150k";
            testMgmt[3] = "iperf-2.0.13-win -c " + ipHandler.OverrideIP + " -t 50 -i 5 -w 300k";
            testMgmt[4] = "iperf-2.0.13-win -c " + ipHandler.OverrideIP + " -t 50 -R -i 5 -w 300k";

            return testMgmt;
        }

        public string[] NLTestsArray()
        {
            string[] nlTests = new string[2];

            nlTests[0] = "nltest /dnsgetdc:gtca.local ";
            nlTests[1] = "nltest /dsgetdc:ntd.local ";

            return nlTests;
        }

        public string SetDataFileName(string incomingWholePath)
        {
            DateTime dateTime = DateTime.Now;
            outputFileName = "DataOutput_" +
                dateTime.ToString("MM") + "_" +
                dateTime.ToString("dd") + "_" +
                dateTime.ToString("yyyy") + "_" +
                dateTime.ToString("hh") + "_" +
                dateTime.ToString("mm") + "_" +
                dateTime.ToString("ss") + "_" +
                ".txt";

            string fullDataPath = incomingWholePath + outputFileName;
            return fullDataPath;
        }

        public string SetMgmtFileName(string incomingWholePath)
        {

            DateTime dateTime = DateTime.Now;
            outputFileName = "MgmtOutput_" +
                dateTime.ToString("MM") + "_" +
                dateTime.ToString("dd") + "_" +
                dateTime.ToString("yyyy") + "_" +
                dateTime.ToString("hh") + "_" +
                dateTime.ToString("mm") + "_" +
                dateTime.ToString("ss") + "_" +
                ".txt";

            string fullDataPath = incomingWholePath + outputFileName;
            return fullDataPath;
        }

        public string SetNLTestsFileName(string incomingWholePath)
        {
            DateTime dateTime = DateTime.Now;
            outputFileName = "NLTestOutput_" +
                dateTime.ToString("MM") + "_" +
                dateTime.ToString("dd") + "_" +
                dateTime.ToString("yyyy") + "_" +
                dateTime.ToString("hh") + "_" +
                dateTime.ToString("mm") + "_" +
                dateTime.ToString("ss") + "_" +
                ".txt";

            string fullDataPath = incomingWholePath + outputFileName;
            return fullDataPath;
        }

        public string SetMgmtExtendedFileName(string incomingWholePath)
        {

            DateTime dateTime = DateTime.Now;
            outputFileName = "MgmtExtendedOutput_" +
                dateTime.ToString("MM") + "_" +
                dateTime.ToString("dd") + "_" +
                dateTime.ToString("yyyy") + "_" +
                dateTime.ToString("hh") + "_" +
                dateTime.ToString("mm") + "_" +
                dateTime.ToString("ss") + "_" +
                ".txt";

            string fullDataPath = incomingWholePath + outputFileName;
            return fullDataPath;
        }

        public void RunTests(string incomingWholePath, string[] incomingArray, IProgressHandler progressHandler)
        {

            for (int i = 0; i < incomingArray.Length; i++)
            {
                ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                cmdsi.Arguments = @"/C " + incomingArray[i] + @" >>" + incomingWholePath;
                Process cmd = Process.Start(cmdsi);
                cmd.WaitForExit();
                progressHandler.UpdateProgress(i + 1, incomingArray.Length);
            }
        }

        public void MakeDirectory(string incomingWholePath)
        {
            try
            {
                Directory.CreateDirectory(incomingWholePath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "error");
            }
        }

        public void MakeFile(string incomingWholePath)
        {
            if (!File.Exists(incomingWholePath))
            {
                File.Create(incomingWholePath);
            }
        }
    }
}
