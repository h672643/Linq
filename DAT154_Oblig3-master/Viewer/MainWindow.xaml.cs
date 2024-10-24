using System;
using System.Collections.Generic;
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

namespace Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private dat154Entities dbContext = new dat154Entities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void View_Students_Click(object sender, RoutedEventArgs e)
        {
            new Students(dbContext).ShowDialog();
        }

        private void View_Grades_Click(object sender, RoutedEventArgs e)
        {
            new Grades(dbContext).ShowDialog();  
        }

        private void View_Courses_Click(object sender, RoutedEventArgs e)
        {
            new Courses(dbContext).ShowDialog();
        }

    }
}
