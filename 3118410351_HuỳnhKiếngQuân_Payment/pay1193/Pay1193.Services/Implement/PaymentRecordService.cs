using Microsoft.EntityFrameworkCore;
using Pay1193.Entity;
using Pay1193.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay1193.Services.Implement
{
    public class PaymentRecordService : IPaymentRecord
    {
        private readonly ApplicationDbContext _context;
        public PaymentRecordService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
            await _context.PaymentRecords.AddAsync(paymentRecord);
            await _context.SaveChangesAsync();
        }

        public PaymentRecord GetById(int id)
        {
            return _context.PaymentRecords.Where(u => u.Id == id).FirstOrDefault();
        }

        public async Task Delete(int PaymentRecordId)
        {
            var PaymentRecord = GetById(PaymentRecordId);
            _context.PaymentRecords.Remove(PaymentRecord);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll()
        {
            return _context.PaymentRecords.ToList(); 
        }

       

        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            throw new NotImplementedException();
        }

        public decimal UnionFee(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PaymentRecord PaymentRecord)
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaxYear> GetAllTaxYear()
        {
            return _context.TaxYears.ToList();
        }
    }
}
