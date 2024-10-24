using Main;
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
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Window
    {
        private dat154Entities entities = new dat154Entities();
        private DbSet<student> student;
        public Students()
        {
            InitializeComponent();
        }
        public Students(dat154Entities context) : this() {
            entities = context;

            student = entities.student;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchField.Text == "")
            {
                studentList.DataContext = student.Local;
            }
            else
            {
                studentList.DataContext = student.Local.Where(student => student.studentname.Contains(SearchField.Text));
            }
        }
    }
}