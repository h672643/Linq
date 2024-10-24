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

namespace Viewer
{
    
    public partial class Courses : Window
    {
        private dat154Entities dbContext = new dat154Entities();
        private DbSet<course> course;
        public Courses()
        {
            InitializeComponent();
        }

        public Courses(dat154Entities context) : this()
        {
            dbContext = context;
            course = dbContext.course;

            course.Load();
            courseList.DataContext = course.Local;
        }

        public void View(object sender, RoutedEventArgs e)
        {
            course course = (course)courseList.SelectedItem;
            new StudentsInCourse(dbContext, course).ShowDialog();
        }
    }
}
