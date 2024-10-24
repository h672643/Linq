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
using System.Windows.Shapes;

namespace Viewer
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        private dat154Entities dbContext = new dat154Entities();

        public Editor()
        {
            InitializeComponent();
        }

        public Editor(dat154Entities context) : this()
        {
            dbContext = context;
        }

        public Editor(dat154Entities context, student s) : this()
        {
            dbContext = context;

            if (s != null)
            {
                id.Text = s.id.ToString();
                name.Text = s.studentname;
                age.Text = s.studentage.ToString();
            }
            
        }

        private void Add_Student(object sender, RoutedEventArgs e)
        {
            student student = new student();
            student.id = int.Parse(id.Text);
            student.studentname = name.Text;
            student.studentage = int.Parse(age.Text);

            dbContext.student.Add(student);
            dbContext.SaveChanges();
            MessageBox.Show(name.Text + " was added!");
            ClearFields();
        }

        private void Delete_Student(object sender, RoutedEventArgs e)
        {
            int sid = int.Parse(id.Text);
            student student = dbContext.student.Where(stud => stud.id == sid).FirstOrDefault();
            if (student != null)
            {
                dbContext.student.Remove(student);
                dbContext.SaveChanges();
            }
            MessageBox.Show(name.Text + " was deleted!");
            ClearFields();
        }

        private void Edit_Student(object sender, RoutedEventArgs e)
        {
            int sid = int.Parse(id.Text);
            student student = dbContext.student.Where(stud => stud.id == sid).FirstOrDefault();

            if (student != null)
            {
                if(!name.Text.Equals("")) student.studentname = name.Text;
                if(!age.Text.Equals("")) student.studentage = int.Parse(age.Text);

                dbContext.SaveChanges();
            }
            MessageBox.Show("Information about " + name.Text + " has been edited.");
            ClearFields();
        }

        private void ClearFields()
        {
            id.Text = name.Text = age.Text = "";
        }

        private void UpdateIDField(object sender, TextChangedEventArgs e)
        {
            if (id.Text == "")
            {
                ClearFields();
                return;
            }
            else
            {
                int sid = int.Parse(id.Text);

                if (!sid.Equals(""))
                {
                    student student = dbContext.student.Where(stud => stud.id == sid).FirstOrDefault();
                    if (student != null)
                    {
                        name.Text = student.studentname;
                        age.Text = student.studentage.ToString();
                    }
                    else
                    {
                        name.Text = age.Text = "";
                    }
                }
            }
        }


    }
}
