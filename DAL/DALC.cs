using BS_RJP.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace BS_RJP.DAL
{
    public class DALC : IDALC
    {
        private readonly DbBsynchroRjpContext _dbContext;
        public DALC(DbBsynchroRjpContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TblUser> GetUserByEmailOrUsername(string ParamEmailOrUsername)
        {
            var user = await _dbContext.TblUsers.Where(a => a.Username == ParamEmailOrUsername || a.Email == ParamEmailOrUsername).FirstOrDefaultAsync();
            return user;
        }
        public async Task<TblCustomer> GetCustomerByIdAdvancedAsync(int CustomerId)
        {
            var response = await _dbContext.TblCustomers
                 .Include(a => a.TblAccounts)
                 .ThenInclude(z => z.TblTransactions)
                 .Where(a => a.CustomerId == CustomerId)
                 .FirstOrDefaultAsync();
            return response;
        }

        public async Task<int> SubmitAccountAsync(TblAccount param)
        {
            if(param.AccountId != 0)
            {
                _dbContext.TblAccounts.Update(param);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                await _dbContext.TblAccounts.AddAsync(param);
                await _dbContext.SaveChangesAsync();
            }
            return param.AccountId;
        }

        public async Task<int> SubmitTransactionAsync(TblTransaction param)
        {
            if (param.TransactionId != 0)
            {
                _dbContext.TblTransactions.Update(param);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                await _dbContext.TblTransactions.AddAsync(param);
                await _dbContext.SaveChangesAsync();
            }
            return param.TransactionId;
        }
    }
}