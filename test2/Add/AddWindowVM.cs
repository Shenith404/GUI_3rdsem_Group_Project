using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using test2.Conform;
using test2.Models;

namespace test2.Add
{
    public partial class AddWindowVM : ObservableObject
    {
        [ObservableProperty] public string userName;
        [ObservableProperty] public string password;
        [ObservableProperty] public bool isrole;

        [ObservableProperty] public string title = "dfgdf";

        [ObservableProperty] public bool isUser;
        [ObservableProperty] public bool isstudent;
        [ObservableProperty] public bool ismodule;


        [ObservableProperty] public string email;
        [ObservableProperty] public string regNostring;
        [ObservableProperty] public ObservableCollection<Module> getModules;
        [ObservableProperty] public ObservableCollection<Module> getRegModules;

        public int regNoint;

        [ObservableProperty] public string getModuleName;
        [ObservableProperty] public int getcode;
        [ObservableProperty] public int getcredit;

        [ObservableProperty] public bool isUpdateMenu;

        [ObservableProperty] public User updateuser;
        [ObservableProperty] public Module updatemod;
        [ObservableProperty] public Student updatestudent;

        [ObservableProperty] public Module selectedMod;
        [ObservableProperty] public Module selectedMod2;
        [ObservableProperty] public int mark;

        [ObservableProperty] public Action closeAction;

        [ObservableProperty]
        public int height = 400;
        [ObservableProperty]
        public int width = 350;



        public AddWindowVM(User user)
        {
            userName = user.UserName;
            password = user.Password;
            if (user.Role == "admin")
            {
                Isrole = true;
            }
            isUpdateMenu = true;
            updateuser = user;

        }
        public AddWindowVM(Module module)
        {
            getModuleName = module.Name;
            getcode = module.Code;
            getcredit = module.Credit;
            isUpdateMenu = true;
            updatemod = module;
        }
        public AddWindowVM(Student student)

        {
            userName = student.Name;
            email = student.Email;
            regNostring = "EG/" + student.RegNo;
            isUpdateMenu = true;
            updatestudent = student;
            GetRegmod();
            Height = 500;
            Width = 600;




        }

        public AddWindowVM()
        {
            isUpdateMenu = false;
            Height = 400;
            Width = 350;

        }

        [RelayCommand]
        public void Close()
        {
            var vm = new ConformWIndowVM();
            var window = new ConformWindow(vm);
            window.ShowDialog();
            if (vm.Result != false)
            {
                
                CloseAction();

            }
            
        }
        
        //for add user
        [RelayCommand]
        public void Adduser()
        {
            if(isUpdateMenu==false)
            {
                if (userName != null)
                {
                    User user = new User()
                    {
                        UserName = userName,

                        Password = password

                    };
                    if (isrole)
                    {
                        user.Role = "admin";
                    }
                    else
                    {
                        user.Role = "regular";
                    }
                    using (var db = new DatabaseDataContex())
                    {
                        db.Dbusers.Add(user);
                        db.SaveChanges();
                        MessageBox.Show("New User Added", "Message");

                    }


                }
            }
            else
            {
                using(var db = new DatabaseDataContex())
                {
                    User u=db.Dbusers.Find(updateuser.Id);
                    u.UserName = userName;
                    u.Password = password;
                    if (isrole)
                    {
                        u.Role = "admin";
                    }
                    else
                    {
                        u.Role = "regular";
                    }
                    db.SaveChanges();
                    MessageBox.Show("User Updated", "Message");

                }
            }

            UserName = null;
            Password = null;
            CloseAction();
                             
        }
        [RelayCommand]
        public void AddStudent()
        {
           if(isUpdateMenu ==false){
                if (userName != null)
                {
                    Student student = new Student()
                    {
                        Name = userName,
                        RegNo = regNoint,

                        Email = email

                    };



                    using (var db = new DatabaseDataContex())
                    {
                        db.Dbstudnets.Add(student);
                        db.SaveChanges();
                        MessageBox.Show("New Student Added", "Message");

                    }


                }
            }
            else
            {
                using(var db = new DatabaseDataContex())
                {
                    Student s = db.Dbstudnets.Find(Updatestudent.Id);
                    s.Name = UserName;
                    s.Email=email=Email;
                    db.SaveChanges();
                    MessageBox.Show("Student Updated!", "Messsage");
                }
            }

            UserName = null;
            Email = null;
            CloseAction() ;

        }
        [RelayCommand]
        public void AddModule()
        {
            if (isUpdateMenu == false)
            {
                if (getModuleName != null)
                {
                    Module module = new Module()
                    {
                        Name = getModuleName,
                        Code = getcode,
                        Credit = getcredit

                    };


                    using (var db = new DatabaseDataContex())
                    {
                        db.Dbmodules.Add(module);
                        db.SaveChanges();
                        MessageBox.Show("New Module Added", "Message");

                    }


                }
            }
            else
            {
                if (getModuleName != null)
                {
                    


                    using (var db = new DatabaseDataContex())
                    {
                        Module module=db.Dbmodules.Find(updatemod.Id);
                        module.Credit=getcredit;
                        module.Code=getcode;
                        module.Name=getModuleName;
                        db.SaveChanges();
                        MessageBox.Show("Module Updated", "Message");
                        

                    }


                }

            }
           
            CloseAction();
        }

        [RelayCommand]
        public void regmod()
        {
            if(selectedMod != null)
            {
                using (var db = new DatabaseDataContex())
                {
                    bool isreg = db.DBstudentModules.Any(sm => sm.ModuleId == selectedMod.Id && sm.StudentId == updatestudent.Id);
                    if (isreg == false)
                    {
                        StudentModules studentModules = new StudentModules()
                        {
                            StudentId = updatestudent.Id,
                            ModuleId = selectedMod.Id,
                            Credit = selectedMod.Credit,

                            Grade = "None"
                        };
                        db.DBstudentModules.Add(studentModules);
                        db.SaveChanges();


                        MessageBox.Show("Module Registred");
                        GetRegmod();
                    }
                    else
                    {
                        MessageBox.Show("Already registred");
                    }

                }
            }
        }

        [RelayCommand]
        public void RemoveRegMod()
        {
            if (selectedMod2 != null )
            {
                using (var db = new DatabaseDataContex())
                {


                    StudentModules studentModules = new StudentModules();

                    studentModules = db.DBstudentModules.FirstOrDefault(sm => sm.ModuleId == selectedMod2.Id && sm.StudentId == updatestudent.Id);
                    db.DBstudentModules.Remove(studentModules);
                    db.SaveChanges();
                    GetRegmod();

                    MessageBox.Show("Module Removed");
                    GetRegmod();

                }
            }

        }
        [RelayCommand]
        public void AddMarks()
        {
            if (selectedMod2 != null && Mark != 0)
            {
                if (Mark >= 0 && Mark <= 100)
                {
                    using (var db = new DatabaseDataContex())
                    {


                        StudentModules studentModules = new StudentModules();

                        studentModules = db.DBstudentModules.FirstOrDefault(sm => sm.ModuleId == selectedMod2.Id && sm.StudentId == updatestudent.Id);

                        studentModules.Grade = GetGrade(Mark);
                        db.SaveChanges();
                        GetRegmod();

                        MessageBox.Show("Marks Added");
                        GetRegmod();
                        Mark=0;

                    }
                }else { MessageBox.Show("Invalid Marks"); }
            }
        }

        public  string GetGrade(int mark)
        {
            string grade = "";

            if (mark >= 85)
                grade = "A+";
            else if (mark >= 75)
                grade = "A";
            else if (mark >= 70)
                grade = "A-";
            else if (mark >= 65)
                grade = "B+";
            else if (mark >= 60)
                grade = "B";
            else if (mark >= 55)
                grade = "B-";
            else if (mark >= 50)
                grade = "C+";
            else if (mark >= 45)
                grade = "C";
            else if (mark >= 40)
                grade = "C-";
            else
                grade = "F";

            return grade;
        }



        public void GetRegmod()
        {
            using(var db = new DatabaseDataContex())
            {
                 List<int> getmodid =new List<int>();
                var list = db.DBstudentModules.ToList();
                var list2 = db.Dbmodules.ToList();
                GetRegModules = new ObservableCollection<Module>();
                getModules = new ObservableCollection<Module>(list2);
                foreach (var sm in list)
                {
                    if(sm.StudentId == updatestudent.Id)
                    {
                        getmodid.Add(sm.ModuleId);
                    }
                }
                foreach(var m in getmodid)
                {
                    
                    foreach (var M in getModules)
                    {
                        if (m == M.Id)
                        {
                            GetRegModules.Add(M);
                        }
                    }
                }

            }

            
        }
    }
}
