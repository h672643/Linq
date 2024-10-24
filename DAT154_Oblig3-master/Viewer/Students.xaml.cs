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
    
    public partial class Students : Window
    {
        private dat154Entities dbContext = new dat154Entities();
        private DbSet<student> student;
        public Students()
        {
            InitializeComponent();
        }
        public Students(dat154Entities context) : this()
        {
            dbContext = context;
            student = dbContext.student;
            student.Load();
            studentList.DataContext = student.Local;
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            if (SearchField.Text == "")
            {
                if (student != null)
                    studentList.DataContext = student.Local;
            }
            else
            {
                studentList.DataContext = student.Local.Where(student => student.studentname.Contains(SearchField.Text));
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            student student = (student)studentList.SelectedItem;
            new Editor(dbContext, student).ShowDialog(); 
        }
    }
}