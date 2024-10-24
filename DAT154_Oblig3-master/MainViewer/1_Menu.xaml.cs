using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace Main
{
    /// <summary>
    /// Interaction logic for _1_Menu.xaml
    /// </summary>
    public partial class _1_Menu : Window
    {
        private dat154Entities entities = new dat154Entities();

        private DbSet<course> course;
        private DbSet<student> student;
        private DbSet<grade> grade;

        public _1_Menu()
        {
            InitializeComponent();

            course = entities.Set<course>();
            student = entities.Set<student>();
            grade = entities.Set<grade>();
        }

        private void View_Students_Click(object sender, RoutedEventArgs e)
        {
            new Students(entities).ShowDialog();
        }

        private void View_Grades_Click(object sender, RoutedEventArgs e)
        {

        }

        private void View_Courses_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
