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
using ConsoleApp_GroupAssignment4_HighQuality;
using ConsoleApp_GroupAssignment4_HighQuality.Models;
using ConsoleApp_GroupAssignment4_HighQuality.Services;
using DogWalkingBusiness.Models;
using WpfApp_GroupAssignment4_HighQuality;

namespace WpfApp_GroupAssignment4_HighQuality
{
   public partial class MainWindow : Window
    {
        private DogWalkingService dogWalkingService;
        private FileStorageService fileStorageService;
        private DogOwnerClass currentOwner;
        private DogWalkerClass currentWalker;
        public MainWindow()
        {
            InitializeComponent();
            dogWalkingService = new DogWalkingService();
            fileStorageService = new FileStorageService();
            var sessions = fileStorageService.loadSessions();
        }        

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {           
            string username = txtUserName.Text;
            string password = txtPassword.Text;
           
            currentOwner = new DogOwnerClass(username, password);
            currentWalker = new DogWalkerClass("walker1", "password", 20.0);

            MessageBox.Show("Logged in as " + username);
        }

        private void btnLogin_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (currentOwner == null || currentWalker == null)
            {
                MessageBox.Show("Please log in first.");
                return;
            }

            // Schedule a session
            string dogName = "Buddy"; // Example dog name
            DateTime date = DateTime.Now; // Example date

            dogWalkingService.scheduleSession(currentWalker, currentOwner, dogName, date);
            MessageBox.Show("Session scheduled successfully!");

            // Save sessions to file
            fileStorageService.saveSessions(currentOwner.scheduledSessions);
        }
    }
}




