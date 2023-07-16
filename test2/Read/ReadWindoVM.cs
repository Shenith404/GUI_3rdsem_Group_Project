using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using test2.Add;
using test2.Conform;
using test2.Models;

namespace test2.Read
{
    public partial class ReadWindoVM : ObservableObject
    {
        [ObservableProperty] public string titel;

        //for users
        [ObservableProperty]
        public ObservableCollection<User> readUsers;
        [ObservableProperty]
        public ObservableCollection<Student> readStudents;
        [ObservableProperty]
        public ObservableCollection<Module> readModules;

        [ObservableProperty] public bool isstudent;
        [ObservableProperty] public bool isuser;
        [ObservableProperty] public bool ismodule;

        [ObservableProperty] public Student selcetedstduent;
        [ObservableProperty] public User selecteduser;
        [ObservableProperty] public Module selectedmodule;

        [ObservableProperty] public bool isrole;

        [ObservableProperty] public int width=820;
        [ObservableProperty] public int height=480;

        [ObservableProperty] public Action closeAction;


        [RelayCommand] 
        public void Close()
        {
            var vm = new ConformWIndowVM();
            var window = new ConformWindow(vm);
            window.ShowDialog();
            if (vm.result != false)
            {
               
                CloseAction();

            }
        }

        [RelayCommand]
        public void Deleteuer()
        {
            User user = selecteduser;
            if (selecteduser != null)
            {
                using (var db = new DatabaseDataContex())
                {
                    db.Dbusers.Remove(user);
                    db.SaveChanges();
                    MessageBox.Show("user deleted", "message");
                    LoadUsers();

                }
            }
        }
        [RelayCommand]
        public void Deletestduent()
        {
            Student student = selcetedstduent;
            if (selcetedstduent != null)
            {
                using (var db = new DatabaseDataContex())
                {
                    db.Dbstudnets.Remove(student);
                    db.SaveChanges();
                    MessageBox.Show("student deleted", "message");
                    LoadStuendts();

                }
            }
        }
        [RelayCommand]
        public void DeleteMod()
        {
            Module module = selectedmodule;
            if (selectedmodule != null)
            {
                using (var db = new DatabaseDataContex())
                {
                    db.Dbmodules.Remove(module);
                    db.SaveChanges();
                    MessageBox.Show("Module deleted", "message");
                    LoadModules();

                }
            }
        }
        public ReadWindoVM()
        {


        }
        public void LoadUsers()
        {
            using (var db = new DatabaseDataContex())
            {
                var list = db.Dbusers.ToList();
                ReadUsers = new ObservableCollection<User>(list);



            }
        }
        public void LoadStuendts()
        {
            using (var db = new DatabaseDataContex())
            {
                var list = db.Dbstudnets.ToList();
                ReadStudents = new ObservableCollection<Student>(list);


            }
        }


        public void LoadModules()
        {
            using (DatabaseDataContex db = new DatabaseDataContex())
            {
                var list = db.Dbmodules.ToList();
                ReadModules = new ObservableCollection<Module>(list);
            }
        }

        [RelayCommand]
        public void UpdateUser()
        {

            if(selecteduser != null)
            {
                var vm = new AddWindowVM(selecteduser);
                vm.title = "UPDATE USER";
                vm.isUser = true;
                vm.isstudent = false;
                vm.ismodule = false;

                var window = new AddWindow(vm);
                window.ShowDialog();
                LoadUsers();
            }
        }

        [RelayCommand]
        public void UpdateStuendts()
        {
            if(selcetedstduent != null)
            {
                var vm = new AddWindowVM(selcetedstduent);
                vm.title = "UPDATE  STUDENT";
                vm.isUser = false;
                vm.isstudent = true;
                vm.ismodule = false;
                LoadModules();
                vm.GetModules = readModules;
                var window = new AddWindow(vm);
                window.ShowDialog();
                
                LoadStuendts();
            }
        }

        [RelayCommand]
        public void UpdateMod()
        {
            if(selectedmodule != null)
            {

                var vm = new AddWindowVM(selectedmodule);
                vm.title = "UPDATE MODULE";
                vm.isUser = false;
                vm.isstudent = false;
                vm.ismodule = true;

                var window = new AddWindow(vm);
                window.ShowDialog();
                LoadModules();

            }
        }


    }
}
