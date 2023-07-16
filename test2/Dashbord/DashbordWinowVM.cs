using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using test2.Add;
using test2.Models;
using test2.Read;
using test2.Conform;

namespace test2.Dashbord
{
    public partial class DashbordWinowVM : ObservableObject
    {


        public bool IsAdmin { get; set; }

        public int cons = 1000;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public string username;
        [ObservableProperty]
        public string userRole;

        [ObservableProperty] public ObservableCollection<User> dashusers;
        [ObservableProperty] public ObservableCollection<Student> dashStudents;
        [ObservableProperty] public ObservableCollection<Module> dashModules;

        [ObservableProperty] public Action closeAction;

        [ObservableProperty]
        public SeriesCollection seriesViews;

        [ObservableProperty] public SeriesCollection seriesViews_Gpa;
        [ObservableProperty] public SeriesCollection seriesViews_chart03;

        [ObservableProperty] public ObservableCollection<LoginHistory> loginHistories;

        [ObservableProperty] public User selecteduser;
        [ObservableProperty] public Student selcetedstduent;
        [ObservableProperty] public Module selectedmodule;
        public string louttime;

        public void Refresh()
        {
            LoadLoginhistry();
            LoadStuendts();
            LoadModules();
            LoadUsers();
            Loadchart();
        }

        [RelayCommand]
        public void Logut()
        {
            var vm = new ConformWIndowVM();
            var window = new ConformWindow(vm);
            window.ShowDialog();
            if(vm.result!=false)
            {
                louttime = DateTime.Now.ToString("HH:mm:ss");
                CloseAction();

            }
           




        }
        [RelayCommand]
        public void Deleteuer()
        {
            User user = Selecteduser;
            if (Selecteduser != null)
            {
                using (var db = new DatabaseDataContex())
                {
                    db.Dbusers.Remove(user);
                    db.SaveChanges();
                    MessageBox.Show("user deleted", "message");
                    LoadUsers();
                    Refresh();
                }
            }
        }
        [RelayCommand]
        public void Deletestduent()
        {
            Student student = Selcetedstduent;
            if (Selcetedstduent != null)
            {
                using (var db = new DatabaseDataContex())
                {
                    db.Dbstudnets.Remove(student);
                    db.SaveChanges();
                    MessageBox.Show("student deleted", "message");
                    LoadStuendts();
                    Refresh();

                }
            }
        }
        [RelayCommand]
        public void DeleteMod()
        {
            Module module = Selectedmodule;
            if (Selectedmodule != null)
            {
                using (var db = new DatabaseDataContex())
                {
                    db.Dbmodules.Remove(module);
                    db.SaveChanges();
                    MessageBox.Show("Module deleted", "message");
                    LoadModules();
                    Refresh();
                }
            }
        }

        public void LoadLoginhistry()
        {
            using (var db= new DatabaseDataContex())
            {
                LoginHistories = new ObservableCollection<LoginHistory>(db.DbLoginHistory_list.OrderByDescending(item => item.Logouttime).ToList());
            }
        }

        //charts
        public void Loadchart() {
            int s, u, m;
            ObservableCollection<Student> students_getgpa;
            ObservableCollection<Module> modules_chart;
            ObservableCollection<StudentModules> studentModules_chart;
            using (var db = new DatabaseDataContex())
            {
                s = db.Dbstudnets.Count();
                u = db.Dbusers.Count();
                m = db.Dbmodules.Count();
                var list =db.Dbstudnets.ToList();
                students_getgpa= new ObservableCollection<Student>(list);
                modules_chart= new ObservableCollection<Module>(db.Dbmodules.ToList());
                studentModules_chart =new ObservableCollection<StudentModules>(db.DBstudentModules.ToList());

            }
            var list2 = new List<double>();
            foreach( var gpa in students_getgpa)
            {
                list2.Add(gpa.Gpa);
            }
            //chart01
            SeriesViews = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Students",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(s)},
                    DataLabels = true,

                },
                new PieSeries
                {
                    Title = "Users",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(u)},
                    DataLabels = true,

                },
                 new PieSeries
                {
                    Title = "Modules",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(m)},
                    DataLabels = true,

                }
            };
            //chart02
            SeriesViews_Gpa = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Student's GPA",
                    Values = new ChartValues<double>(list2),
      
                }
               
            };
            //chart03
            SeriesViews_chart03 = new SeriesCollection();

            foreach (var md in modules_chart)
            {
                int count = 0;
                foreach (var sm in studentModules_chart)
                {
                    if (md.Id == sm.ModuleId)
                    {
                        count++;
                    }
                }
                var lns =new ColumnSeries
                {
                    Title = md.Code.ToString(),
                    Values = new ChartValues<ObservableValue> { new ObservableValue(count) },
                    DataLabels = true,
                };
                SeriesViews_chart03.Add(lns);
             }

            

        }
        public void LoadUsers()
        {
            using(var db = new DatabaseDataContex())
            {
                var list =db.Dbusers.ToList();
                Dashusers = new ObservableCollection<User>(list);                

              
            }
        }
        public void LoadStuendts()
        {
            using (var db = new DatabaseDataContex())
            {
                var list = db.Dbstudnets.ToList();
                DashStudents = new ObservableCollection<Student>(list);


            }
        }
        public void LoadModules()
        {
            using (var db = new DatabaseDataContex())
            {
                var list = db.Dbmodules.ToList();
                DashModules = new ObservableCollection<Module>(list);


            }
        }


        public DashbordWinowVM()
        {

        }
        [RelayCommand]
        public void AddUser() {

            var vm = new AddWindowVM();
            vm.title = "ADD USER";
            vm.isUser = true;
            vm.isstudent = false;
            vm.ismodule = false;
            var window = new AddWindow(vm);
            Application.Current.MainWindow.Hide();

            window.ShowDialog();
            Refresh();
            Application.Current.MainWindow.ShowDialog();
           
        
        }
        [RelayCommand]
        public void AddStudent()
        {

            var vm = new AddWindowVM();
            vm.title = "ADD STUDENT";
            vm.isUser = false;
            vm.isstudent = true;
            vm.ismodule = false;
            vm.IsUpdateMenu = false;
            int lastid;
            using(var db= new DatabaseDataContex()) {
                lastid = db.Dbstudnets.Max(s=>s.Id);
                
            }

            vm.regNoint = cons +lastid + 1;
            vm.RegNostring = "EG/" + vm.regNoint;
           
            
            var window = new AddWindow(vm);
            Application.Current.MainWindow.Hide();

            window.ShowDialog();
            Refresh();
            Application.Current.MainWindow.ShowDialog();


        }
        [RelayCommand]
        public void AddModule()
        {

            var vm = new AddWindowVM();
            vm.title = "ADD MODULE  ";
            vm.isUser = false;
            vm.isstudent = false;
            vm.ismodule = true;
            vm.regNoint = cons;
            vm.IsUpdateMenu = false;
            var window = new AddWindow(vm);
            Application.Current.MainWindow.Hide();

            window.ShowDialog();
            Refresh();
            Application.Current.MainWindow.ShowDialog();
    

        }

        [RelayCommand]
        public void ReadUsers()
        {
            var vm = new ReadWindoVM();
            vm.titel = "USER LIST";
            LoadUsers();
            vm.isstudent = false;
            vm.ismodule = false;
            vm.isuser = true;
            vm.readUsers = dashusers;
           
            var window = new ReadWindow(vm);
            Application.Current.MainWindow.Hide();

            window.ShowDialog();
            Refresh();
            Application.Current.MainWindow.ShowDialog();
        

        }
        [RelayCommand]
        public void ReadStudents()
        {
            var vm = new ReadWindoVM();
            vm.titel = "STUDENT  LIST";
            LoadStuendts();
            vm.readStudents = dashStudents;
            vm.isstudent= true;
            vm.ismodule= false;
            vm.isuser = false;
            vm.Height = 600;
            vm.Width = 1150;
            var window = new ReadWindow(vm);
            Application.Current.MainWindow.Hide();

            window.ShowDialog();
            Application.Current.MainWindow.ShowDialog();
            Refresh();

        }
        [RelayCommand]
        public void ReadModules()
        {
            var vm = new ReadWindoVM();
            vm.titel = "Module  LIST";
            LoadModules ();
            vm.isstudent = false;
            vm.ismodule = true;
            vm.isuser = false;
            vm.readModules = dashModules;
            var window = new ReadWindow(vm);
            Application.Current.MainWindow.Hide();

            window.ShowDialog();
            Refresh();
            Application.Current.MainWindow.ShowDialog();
            Loadchart();
        }

    }
}
