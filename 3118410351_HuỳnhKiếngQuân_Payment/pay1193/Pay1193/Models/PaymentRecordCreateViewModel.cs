using Pay1193.Entity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pay1193.Models
{
    public class PaymentRecordCreateViewModel
    {
        public int EmployeeId { get; set; }
        public DateTime DatePay { get; set; }
        public DateTime MonthPay { get; set; }
        public int TaxYearId { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal HourWorked { get; set; }
        public decimal ContractualHours { get; set; }       
    }
}
