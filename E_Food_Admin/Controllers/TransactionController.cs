using BussinessObject.Models;
using E_Food_Admin.Data;
using E_Food_Admin.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IPremium_hisRepository _premiumHisRepository;
        private readonly IPremiumRepository _premiumRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;


        public TransactionController(ITransactionRepository transactionRepository,IPremium_hisRepository premium_HisRepository, IPremiumRepository premiumRepository, IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _transactionRepository = transactionRepository;
            _premiumRepository = premiumRepository;
            _premiumHisRepository = premium_HisRepository;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllTransactions()
        {
            //var transactions = _transactionRepository.GetAll();
            //return Ok(transactions);

            List<TransactionApiModel> result = new List<TransactionApiModel>();
            List<Transaction> transaction = _transactionRepository.GetAll();
            if (transaction != null && transaction.Count > 0)
            {
                foreach (Transaction item in transaction)
                {
                    result.Add(new TransactionApiModel
                    {
                        TransactionId = item.TransactionId,
                        PaymentMethodId = item.PaymentMethodId,
                        AccountId = item.AccountId,
                        Value = item.Value,
                        TimeTrans = item.TimeTrans.Value.ToString(),
                        IsSuccess = item.IsSuccess,
                        Note = item.Note                       
                    });
                }
                return Ok(result);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetTransactionById(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            var trans = _transactionRepository.GetById(id);
            if (trans == null || trans.Count == 0)
            {
                return NotFound();
            }
            List<TransactionApiModel> results = new List<TransactionApiModel>();
            foreach (var item in trans)
            {
                results.Add(new TransactionApiModel
                {
                    TransactionId = item.TransactionId,
                    PaymentMethodId = item.PaymentMethodId,
                    AccountId = item.AccountId,
                    Value = item.Value,
                    TimeTrans = item.TimeTrans.Value.ToString(),
                    IsSuccess = item.IsSuccess,
                    Note = item.Note
                });
            }

            return Ok(results);
        }

        //[HttpPost]
        //public IActionResult CreateTransaction(TransApiModel trans)
        //{
        //    Transaction transaction = new Transaction();
        //    transaction.PaymentMethodId = trans.paymentMethodId;
        //    transaction.AccountId = trans.accountId;
        //    transaction.Value = trans.value;
        //    transaction.TimeTrans = TimeSpan.Parse(DateTime.Now.ToString());
        //    transaction.IsSuccess = false;
        //    transaction.Note = "pending";
        //    _transactionRepository.Create(transaction);
        //    return CreatedAtAction(nameof(GetTransaction), new { id = transaction.TransactionId }, transaction);
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateTransaction(int id, Transaction transaction)
        //{
        //    var existingTransaction = _transactionRepository.Get(id);
        //    if (existingTransaction == null)
        //    {
        //        return NotFound(new ResponseObject
        //        {
        //            Message = "Transaction not found",
        //            Data = transaction
        //        });
        //    }

        //    existingTransaction.PaymentMethodId = transaction.PaymentMethodId;
        //    existingTransaction.AccountId = transaction.AccountId;
        //    existingTransaction.Value = transaction.Value;
        //    existingTransaction.TimeTrans = transaction.TimeTrans;
        //    existingTransaction.IsSuccess = transaction.IsSuccess;
        //    existingTransaction.Note = transaction.Note;

        //    _transactionRepository.Update(existingTransaction);

        //    return NoContent();
        //}
        //[HttpPut("confirm/{transid}")]
        //public IActionResult ConfirmPremium(int transid)
        //{
        //    // update transaction
        //    var existingTransaction = _transactionRepository.Get(transid);
        //    if (existingTransaction == null)
        //    {
        //        return NotFound(new ResponseObject
        //        {
        //            Message = "Transaction not found",

        //        });
        //    }
        //    existingTransaction.IsSuccess = true;
        //    existingTransaction.Note = "done";

        //    _transactionRepository.Update(existingTransaction);
        //    // end update transaction

        //    // update premium
        //    PremiumHi newp = new PremiumHi();
        //    newp.TimeStart = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString());
        //    foreach (Premium p in _premiumRepository.GetAll())
        //    {
        //        if (p.Value == existingTransaction.Value)
        //        {
        //            newp.PremiumId = p.PremiumId;
        //            var time = p.Period;
        //            newp.TimeEnd = TimeSpan.Parse((DateTime.Now.AddMonths(Int32.Parse(time)).TimeOfDay).ToString());
        //        }
        //    }
        //    newp.Status = 1;
        //    newp.UserId = _accountRepository.Get(existingTransaction.AccountId.Value).UserId;
        //    _premiumHisRepository.Update(newp);
        //    // end update premium

        //    // update premium in user
        //    var user = _userRepository.Get(newp.UserId.Value);
        //    if (user != null) user.IsPremium = true;
        //    _userRepository.Update(user);

        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public IActionResult DeleteTransaction(int id)
        {
            var transaction = _transactionRepository.GetById(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _transactionRepository.Remove(id);

            return NoContent();
        }

        [HttpPut("Confirm/{transid}")]
        public IActionResult ConfirmPremium(int transid)
        {
            var transaction = _transactionRepository.FindById(transid);
            if (transaction == null)
            {
                return NotFound();
            }

            // Tìm thông tin Account dựa trên AccountId của Transaction
            var account = _accountRepository.FindById((int)transaction.AccountId);
            if (account == null)
            {
                return NotFound();
            }

            // Tìm thông tin User dựa trên UserId của Account
            var user = _userRepository.FindById((int)account.UserId);
            if (user == null)
            {
                return NotFound();
            }

            // Thay đổi giá trị Is_premium trong User từ 0 thành 1
            user.IsPremium = true;
            _userRepository.Update(user);

            return Ok();
        }
    }
}
