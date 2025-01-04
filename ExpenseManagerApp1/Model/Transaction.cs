using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerApp1.Model
{
    public  class Transaction
    {
        public int Id { get; set; } = 0;

        public string Status { get; set; }  = string.Empty;

        public string Type {  get; set; } = string.Empty ;

        public string Title { get; set; } = string.Empty;

        public string Amount { get; set; } = string.Empty;

        public string Date {  get; set; } = string.Empty;

    } 


}
