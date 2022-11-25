using Pay1193.Entity;
using Pay1193.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay1193.Services.Implement
{
    public class PayService : IPayService
    {
        private decimal overTimeHours;
        private decimal contractualEarnings;
        private readonly ApplicationDbContext _context;
        public PayService(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal ContractualEarning(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if(hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;

            }
            else
            {
                contractualEarnings = contractualHours * hourlyRate;
            }
            return contractualEarnings;
        }

        public Task CreateAsync(PaymentRecord paymentRecord)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public PaymentRecord GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TaxYear GetTaxYearById(int id)
        {
            throw new NotImplementedException();
        }

        public decimal NetPay(decimal totalEarnings, decimal totalDeduction)
        {
            throw new NotImplementedException();
        }

        public decimal OvertimeEarnings(decimal overtimeEarnings, decimal contractualEarnings)
        {
            throw new NotImplementedException();
        }

        public decimal OverTimeHours(decimal hoursWorked, decimal contractualHours)
        {
            throw new NotImplementedException();
        }

        public decimal OvertimeRate(decimal hourlyRate)
        {
            throw new NotImplementedException();
        }

        public decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFees)
        {
            throw new NotImplementedException();
        }
    }
}
