using Microsoft.AspNetCore.Mvc;
using Pay1193.Services;
using Pay1193.Entity;
using Pay1193.Models;
using System.Dynamic;

namespace Pay1193.Controllers
{
    public class PaymentRecordController : Controller
    {
        private readonly IPaymentRecord _paymentRecordService;
        private readonly IEmployee _employeeService;
        private readonly ITaxService _taxService;
        private readonly INationalInsuranceService _nationalInsuranceService;
        private readonly IPayService _payService;

        //private decimal overtimeHrs;
        //private decimal contractualEarnings;
        //private decimal overtimeEarnings;
        //private decimal totalEarnings;
        //private decimal tax;
        //private decimal unionFee;
        //private decimal studentLoan;
        //private decimal nationalInsurance;
        //private decimal totalDeduction;

        public PaymentRecordController(IPaymentRecord paymentRecordService, IEmployee employeeService, ITaxService taxService, INationalInsuranceService nationalInsuranceService, IPayService payService)
        {
            _paymentRecordService = paymentRecordService;
            _employeeService = employeeService;
            _taxService = taxService;
            _nationalInsuranceService = nationalInsuranceService;
            _payService = payService;
        }

        public IActionResult Index()
        {
            var paymentRecords = _paymentRecordService.GetAll().Select(paymentRecordItem => new PaymentRecordIndexViewModel
            {
                FullName = _employeeService.GetById(paymentRecordItem.EmployeeId).FullName,
                DatePay = paymentRecordItem.DatePay,
                MonthPay = paymentRecordItem.MonthPay,
                TaxYearId = paymentRecordItem.TaxYearId,
                TaxYear = _taxService.GetById(paymentRecordItem.TaxYearId).YearOfTax,
                TotalEarnings = paymentRecordItem.TotalEarnings,
                EarningDeduction = paymentRecordItem.EarningDeduction,
                NetPayment = paymentRecordItem.NetPayment,
            }).ToList();

            return View(paymentRecords);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.employees = _employeeService.GetAll();
            ViewBag.taxYears = _paymentRecordService.GetAllTaxYear();
            var model = new PaymentRecordCreateViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentRecordCreateViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            var paymentRecord = new PaymentRecord
            { 
                EmployeeId = model.EmployeeId,
                Employee = _employeeService.GetById(model.EmployeeId),
                DatePay = model.DatePay,
                MonthPay = model.MonthPay,
                TaxYearId = model.TaxYearId,
                TaxYear = _taxService.GetById(model.TaxYearId),
                HourlyRate = model.HourlyRate,
                HourWorked = model.HourWorked,
                ContractualHours = model.ContractualHours,
                ContractualEarnings = _payService.ContractualEarning(model.ContractualHours, model.HourWorked, model.HourlyRate),

                TaxCode = ""
            };


            await _paymentRecordService.CreateAsync(paymentRecord);
            return RedirectToAction("Index");
            //}
            //return View();
        }

        //public IActionResult Detail(int id)
        //{
        //    var PaymentRecord = _PaymentRecordService.GetById(id);
        //    if (PaymentRecord == null)
        //    {
        //        return NotFound();
        //    }
        //    PaymentRecordDetailsViewModel model = new PaymentRecordDetailsViewModel()
        //    {
        //        Id = PaymentRecord.Id,
        //        PaymentRecordNo = PaymentRecord.PaymentRecordNo,
        //        FullName = PaymentRecord.FullName,
        //        Gender = PaymentRecord.Gender,
        //        ImageUrl = PaymentRecord.ImageUrl,
        //        DoB = PaymentRecord.DoB,
        //        Designation = PaymentRecord.Designation,
        //        Email = PaymentRecord.Email,
        //        NationalInsuranceNo = PaymentRecord.NationalInsuranceNo,
        //        PaymentMethod = PaymentRecord.PaymentMethod,
        //        StudentLoan = PaymentRecord.StudentLoan,
        //        UnionMember = PaymentRecord.UnionMember,
        //        Address = PaymentRecord.Address,
        //        City = PaymentRecord.City,
        //        PostCode = PaymentRecord.PostCode
        //    };
        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var PaymentRecord = _PaymentRecordService.GetById(id);
        //    if (PaymentRecord == null)
        //    {
        //        return NotFound();
        //    }
        //    var model = new PaymentRecordEditViewModel()
        //    {
        //        Id = PaymentRecord.Id,
        //        FirstName = PaymentRecord.FirstName,
        //        LastName = PaymentRecord.LatName,
        //        MidleName = PaymentRecord.MiddleName,
        //        PaymentRecordNo = PaymentRecord.PaymentRecordNo,
        //        Gender = PaymentRecord.Gender,
        //        Email = PaymentRecord.Email,
        //        DOB = PaymentRecord.DoB,
        //        DateJoined = PaymentRecord.DateJoined,
        //        Designation = PaymentRecord.Designation,
        //        NationalInsuranceNo = PaymentRecord.NationalInsuranceNo,
        //        PaymentMethod = PaymentRecord.PaymentMethod,
        //        StudentLoan = PaymentRecord.StudentLoan,
        //        UnionMember = PaymentRecord.UnionMember,
        //        Address = PaymentRecord.Address,
        //        City = PaymentRecord.City,
        //        Postcode = PaymentRecord.PostCode
        //    };
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(PaymentRecordEditViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var PaymentRecord = new PaymentRecord
        //        {
        //            Id = model.Id,
        //            FirstName = model.FirstName,
        //            MiddleName = model.MidleName,
        //            LatName = model.LastName,
        //            Gender = model.Gender,
        //            DoB = model.DOB,
        //            DateJoined = model.DateJoined,
        //            Designation = model.Designation,
        //            NationalInsuranceNo = model.NationalInsuranceNo,
        //            StudentLoan = model.StudentLoan,
        //            PaymentMethod = model.PaymentMethod,
        //            UnionMember = model.UnionMember,
        //            Phone = model.Phone,
        //            Address = model.Address,
        //            City = model.City,
        //            PostCode = model.Postcode,
        //            Email = model.Email,
        //            PaymentRecordNo = model.PaymentRecordNo,
        //            FullName = model.FullName
        //        };
        //        if (model.ImageUrl != null & model.ImageUrl.Length > 0)
        //        {
        //            var uploadDir = @"images/PaymentRecords";
        //            var filename = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
        //            var extension = Path.GetExtension(model.ImageUrl.FileName);
        //            var webrootPath = _webHostEnvironment.WebRootPath;
        //            filename = DateTime.UtcNow.ToString("yymmssfff") + filename + extension;
        //            var path = Path.Combine(webrootPath, uploadDir, filename);
        //            await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
        //            PaymentRecord.ImageUrl = "/" + uploadDir + "/" + filename;

        //        }
        //        await _PaymentRecordService.UpdateAsync(PaymentRecord);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var PaymentRecord = _PaymentRecordService.GetById(id);
        //    if (PaymentRecord == null)
        //    {
        //        return NotFound();
        //    }
        //    var model = new PaymentRecordDeleteViewModel
        //    {
        //        Id = PaymentRecord.Id,
        //        FullName = PaymentRecord.FullName
        //    };
        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Delete(PaymentRecordDeleteViewModel model)
        //{
        //    await _PaymentRecordService.Delete(model.Id);
        //    return RedirectToAction("Index");
        //}
    }
}
