using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    internal class EmployeeViewModel
    {
        private NorthwindContext dc = new NorthwindContext();
        private List<EmployeeModel> _EmployeesList;
        private List<string> _listTitle;

        public List<EmployeeModel> EmployeesList
        {
            get { return _EmployeesList = _EmployeesList ?? loadEmployee(); }

        }

        private List<EmployeeModel> loadEmployee()
        {
            List<EmployeeModel> localCollection = new List<EmployeeModel>();
            foreach (var item in dc.Employees)
            {
                localCollection.Add(new EmployeeModel(item));
            }
            return localCollection;
        }


        public List<string> ListTitle
        {
            get { return _listTitle = _listTitle ?? LoadTitleOfCourtesy(); }
        }

        private List<string> LoadTitleOfCourtesy()
        {
            return dc.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList();
        }


    }
}
