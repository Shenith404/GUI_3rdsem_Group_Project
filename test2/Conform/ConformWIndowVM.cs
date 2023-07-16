using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2.Conform
{
    public partial class ConformWIndowVM:ObservableObject
    {
        [ObservableProperty]
        public bool result;

        public Action CloseAction { get; set; }

        [RelayCommand]
        public void PressYES()
        {
            Result = true;
            CloseAction();
           
        }

        [RelayCommand]
        public void PressNO()
        {
            Result = false;
            CloseAction();
        }
    }
}
