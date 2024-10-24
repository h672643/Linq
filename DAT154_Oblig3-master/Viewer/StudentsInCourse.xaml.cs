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
   
    public partial class StudentsInCourse : Window
    {
        private dat154Entities dbContext = new dat154Entities();
        private DbSet<grade> grade;
        private course thisCourse;


        public StudentsInCourse()
        {
            InitializeComponent();
        }
        public StudentsInCourse(dat154Entities context) : this()
        {
            dbContext = context;

        }
        public StudentsInCourse(dat154Entities context, course SelectedCourse) : this()
        {
            dbContext = context;
            grade = dbContext.grade;
            grade.Load();
            thisCourse = SelectedCourse;
            updateView();

        }


        private void Search(object sender, TextChangedEventArgs e)
        {
            if (SearchField.Text != "")
            {
                //studentGradeList.DataContext = grade.Local.Where(grade => grade.student.studentname.Contains(SearchField.Text));

                studentGradeList.DataContext = from grade in grade.Local
                                               where grade.coursecode.Equals(thisCourse.coursecode)
                                               where grade.student.studentname.Contains(SearchField.Text)
                                               select grade;
            } 
            else
            {
                studentGradeList.DataContext = grade.Local.Where(course => course.coursecode.Equals(thisCourse.coursecode));
            }

           
        }


        private void Remove_Student(object sender, RoutedEventArgs e)
        {
            grade grade = (grade) studentGradeList.SelectedItem;

            if (grade != null)
            {
                string studentname = dbContext.student.Find(grade.studentid).studentname; 
                dbContext.grade.Remove(grade);
                dbContext.SaveChanges();
                MessageBox.Show(studentname + " has been removed from the course.");
            } 
            else
            {
                MessageBox.Show("No student selected, please select one to remove.");
            }
            updateView();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new CourseEditor(dbContext, thisCourse).ShowDialog();
            updateView();
            dbContext.SaveChanges();
        }

        private void updateView()
        {
            studentGradeList.DataContext = grade.Local.Where(course => course.coursecode.Equals(thisCourse.coursecode));
        }
    }
}
