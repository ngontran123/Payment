using Pay1193.Entity;
using System.ComponentModel.DataAnnotations;

namespace Pay1193.Models
{
    public class PaymentRecordIndexViewModel
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string FullName { get; set; }
        public DateTime DatePay { get; set; }
        public DateTime MonthPay { get; set; }
        public int TaxYearId { get; set; }
        public string TaxYear { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal EarningDeduction { get; set; }
        public decimal NetPayment { get; set; }
    }
}
