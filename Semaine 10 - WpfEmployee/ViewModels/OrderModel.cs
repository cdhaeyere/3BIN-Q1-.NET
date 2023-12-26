using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    internal class OrderModel
    {
        private readonly Order _monOrder;
        private decimal total = 0;

        public OrderModel(Order current, decimal total)
        {
            this._monOrder = current;
            this.total = total;
        }

        public String OrderDate
        {
            get
            {
                if (_monOrder.OrderDate.HasValue)
                {
                    return _monOrder.OrderDate.Value.ToShortDateString();
                }

                return "";
            }
        }



        public String OrderID
        {
            get
            {
                return _monOrder.OrderId.ToString();

            }
        }

        public String OrderTotal
        {
            get
            {
                return total.ToString();

            }
        }
    }
}
