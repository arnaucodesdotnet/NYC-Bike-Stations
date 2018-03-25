using DevExpress.Xpf.Core;
using Unity;

namespace CityBikeNYC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow
    {
        public MainWindow()
        {
            IUnityContainer container = new UnityContainer();
            ConfigureUnity.Configure(container);

            InitializeComponent();
            DataContext = container.Resolve<MainWindowViewModel>();
        }

        private void DXWindow_Initialized(object sender, System.EventArgs e)
        {
            dgStations.Loaded += (s, x) =>
            {
                dgStations.ShowLoadingPanel = false;
            };
        }
    }
}
