using System.Windows;

using DesktopClient.Services;

using Microsoft.AspNetCore.SignalR.Client;

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/door")
                .Build();

            IDoorService doorService = new DoorService();

            DataContext = new MainWindowViewModel(doorService, connection);

            ConnectSignalR(connection);
        }

        private async void ConnectSignalR(HubConnection connection)
        {
            await connection.StartAsync().ContinueWith(task =>
            {
                if (task.Exception != null)
                {
                }
            });
        }
    }
}
