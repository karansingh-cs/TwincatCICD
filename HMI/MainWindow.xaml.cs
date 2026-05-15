using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwinCAT.Ads;

namespace HMI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string amsNetId = "192.168.1.10.1.1";
        private int adsPort = 851;
        private AdsClient ?adsClient;

        public MainWindow()
        {
            InitializeComponent();
            ConnectToPlc();
        }

        public void ConnectToPlc()
        {
            try
            {
                adsClient = new AdsClient();
                adsClient.Connect(amsNetId, adsPort);
                //adsClient.ReadValue("MAIN.bAutoMode",typeof(bool));
                adsClient.ReadValue("MAIN.DoesNotExist", typeof(bool));

                lblStatus.Content = "PLC: Connected";
            }
            catch
            {
                lblStatus.Content = "PLC: Offline";
            }

        }

       
    }
}