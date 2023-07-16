using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using test2.Dashbord;
using test2.Models;

namespace test2
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string userName;
        [ObservableProperty]
        public string password;

        [RelayCommand]
        public void Close() {
            Application.Current.MainWindow.Close();
        }

        
        [RelayCommand]
        public void Login()
        {
            if (userName != null)
            {

                using (var db = new DatabaseDataContex())
                {

                    bool userfound = db.Dbusers.Any(usr => usr.UserName == userName && usr.Password == password);
                   
                    if (userfound)
                    {
                        bool isUserAdmin = db.Dbusers.Any(usr => usr.UserName == userName && usr.Password == password && usr.Role == "admin");

                        var vm = new DashbordWinowVM();
                        vm.LoadStuendts();
                        vm.LoadUsers();
                        vm.LoadModules();
                        vm.Loadchart();
                        vm.LoadLoginhistry();
                        vm.IsAdmin = isUserAdmin;
                        if(isUserAdmin)
                        {
                            vm.title = "Admin User";
                            vm.username =  userName;
                            vm.userRole = "Admin";
                        }
                        else { vm.title = "Reguler User";
                            vm.username = userName;
                            vm.userRole = "Reguler";
                        }

                        string logtime = DateTime.Now.ToString("HH:mm:ss");
                         
                        var window = new DashbordWindow(vm);
                        Application.Current.MainWindow.Hide();
                        var mv = Application.Current.MainWindow;

                        Application.Current.MainWindow = window;
                        window.ShowDialog();
                        Application.Current.MainWindow = mv;

                        Application.Current.MainWindow.Show();



                        LoginHistory loginHistory = new LoginHistory()
                        {
                            Name = userName,
                            Logtime = logtime,
                            Logouttime = vm.louttime,
                            Date = DateTime.Now.ToString("yyyy-MM-dd")

                        };
                        db.DbLoginHistory_list.Add(loginHistory);
                        db.SaveChanges();
                        UserName = null;
                        Password = null;
                    }
                    else
                    {
                        MessageBox.Show("User name or password was incorrect", "Warning");
                    }


                }


            }
        }
    }
}
