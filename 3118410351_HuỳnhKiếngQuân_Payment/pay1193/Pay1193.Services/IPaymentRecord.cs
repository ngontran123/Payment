using Pay1193.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay1193.Services
{
    public interface IPaymentRecord
    {
        Task CreateAsync(PaymentRecord paymentRecord);
        Task UpdateAsync(PaymentRecord paymentRecord);
        Task UpdateById(int id);
        PaymentRecord GetById(int id);
        Task Delete(int paymentRecordId);
        IEnumerable<PaymentRecord> GetAll();
        decimal UnionFee(int id);
        decimal StudentLoanRepaymentAmount(int id, decimal totalAmount);
        IEnumerable<TaxYear> GetAllTaxYear();
    }
}
