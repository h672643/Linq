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
    /// Interaction logic for CourseEditor.xaml
    /// </summary>
    public partial class CourseEditor : Window
    {
        private dat154Entities dbContext = new dat154Entities();
        private course thisCourse;

        public CourseEditor()
        {
            InitializeComponent();
        }

        public CourseEditor(dat154Entities context, course course) : this()
        {
            dbContext = context;
            this.thisCourse = course;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            grade grade = new grade();
            student student = dbContext.student.Find(int.Parse(id.Text));

            grade.studentid = student.id;
            grade.coursecode = thisCourse.coursecode;
            grade.grade1 = gradeBox.Text.ToUpper();
            grade.course = thisCourse;
            grade.student = student;

            dbContext.grade.Add(grade);
            dbContext.SaveChanges();
            MessageBox.Show(student.studentname + " has been added to the course " + thisCourse.coursename + " with the grade " + grade.grade1);
            ClearFields();
            Close();
        }

        private void FindStudent(object sender, TextChangedEventArgs e)
        {
            if (name.Text == "")
            {
                ClearFields();
                return;
            }
            else
            {
                student student = dbContext.student.Where(s => s.studentname.Contains(name.Text)).FirstOrDefault();
                if (student != null)
                {
                    id.Text = student.id.ToString();
                    age.Text = student.studentage.ToString();
                } else
                {
                    id.Text = age.Text = "";
                }
            }
        }

        private void ClearFields()
        {
            id.Text = name.Text = age.Text = "";
        }
    }
}
