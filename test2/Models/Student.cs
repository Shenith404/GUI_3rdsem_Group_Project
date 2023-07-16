using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2.Models
{
     public class Student
    {
        [Key]
        public int Id { get; set; }

        public int RegNo { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public ObservableCollection<StudentModules> StudentModules { get; set; }

        public double Gpa { get {
                GetRegmod();
                double totalGradePoints = 0;
                double totalCredits = 0.00001;
                if (getModules != null)
                {
                    
                    foreach (var module in getModules)
                    {
                        int credit = module.Credit;
                        string grade = module.Grade;
                        double gradePoint = 0;

                        switch (grade)
                        {
                            case "A+":
                                gradePoint = 4.0;
                                break;
                            case "A":
                                gradePoint = 4.0;
                                break;
                            case "A-":
                                gradePoint = 3.7;
                                break;
                            case "B+":
                                gradePoint = 3.3;
                                break;
                            case "B":
                                gradePoint = 3.0;
                                break;
                            case "B-":
                                gradePoint = 2.7;
                                break;
                            case "C+":
                                gradePoint = 2.3;
                                break;
                            case "C":
                                gradePoint = 2.0;
                                break;
                            case "C-":
                                gradePoint = 1.7;
                                break;
                            case "D":
                                gradePoint = 1.0;
                                break;
                            case "F":
                                gradePoint = 0.0;
                                break;
                        }

                        totalGradePoints += credit * gradePoint;
                        totalCredits += credit;
                    }
  
                };
                return Math.Round( totalGradePoints / totalCredits,4);
            }  
        }

        
        ObservableCollection<StudentModules> getModules = new ObservableCollection<StudentModules>();
        public void GetRegmod()
        {
            using (var db = new DatabaseDataContex())
            {
                
                var list = db.DBstudentModules.ToList();

                ObservableCollection<StudentModules>  Modules = new ObservableCollection<StudentModules>(list);
                foreach (var sm in Modules)
                {
                    if(sm.StudentId== Id)
                    {
                        getModules.Add(sm); 
                    }

                }
              

            }


        }
                         
    }
}
