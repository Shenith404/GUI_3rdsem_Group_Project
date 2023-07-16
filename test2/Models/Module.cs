using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int Credit     { get; set; }

        public ObservableCollection<StudentModules>  Modulestudents { get; set; }
    }
}
