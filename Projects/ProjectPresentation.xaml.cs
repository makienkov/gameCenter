using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using gameCenter.Projects;
using gameCenter.Projects.CurrencyConverter;
using gameCenter.Projects.Project1;
using gameCenter.Projects.TodoList;
namespace gameCenter.Projects
{
    public partial class ProjectPresentation : Window
    {


        public ProjectPresentation()
        {
            InitializeComponent();


        }

        public void OnStartUp(string projectInfo, ImageSource imageSource)
        {
            InfoTextBox.Text = projectInfo;
            ProjectImage.Source = imageSource;

        }



    }
}

