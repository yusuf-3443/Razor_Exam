using System.Data.Common;
using System.Net;
using AutoMapper;
using Domain.DTOs.TransactionDTOs;
using Domain.Entities;
using Domain.Filters;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        #region ctor

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public TransactionService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        #endregion

        #region GetTransactionsAsync

        public async Task<PagedResponse<List<GetTransactionDto>>> GetTransactionsAsync(TransactionFilter filter)
        {
            try
            {
                var transactions = _context.Transactions.AsQueryable();
               if (filter.Amount != 0)
    transactions = transactions.Where(x => x.Amount == filter.Amount);
                var result = await transactions.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize)
                    .ToListAsync();
                var total = await transactions.CountAsync();

                var response = _mapper.Map<List<GetTransactionDto>>(result);
                return new PagedResponse<List<GetTransactionDto>>(response, total, filter.PageNumber, filter.PageSize);
            }
            catch (Exception e)
            {
                return new PagedResponse<List<GetTransactionDto>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region GetTransactionByIdAsync

        public async Task<Response<GetTransactionDto>> GetTransactionByIdAsync(int transactionId)
        {
            try
            {
                var existing = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == transactionId);
                if (existing == null) return new Response<GetTransactionDto>(HttpStatusCode.BadRequest, "Transaction not found");
                var transaction = _mapper.Map<GetTransactionDto>(existing);
                return new Response<GetTransactionDto>(transaction);
            }
            catch (Exception e)
            {
                return new Response<GetTransactionDto>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region CreateTransactionAsync

        public async Task<Response<string>> CreateTransactionAsync(AddTransactionDto transaction)
        {
            try
            {
                var newTransaction = _mapper.Map<Transaction>(transaction);
                await _context.Transactions.AddAsync(newTransaction);
                await _context.SaveChangesAsync();
                return new Response<string>("Successfully created ");
            }
            catch (DbException e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region UpdateTransactionAsync

        public async Task<Response<string>> UpdateTransactionAsync(UpdateTransactionDto transaction)
        {
            try
            {
                var existing = await _context.Transactions.AnyAsync(x => x.Id == transaction.Id);
                if (!existing) return new Response<string>(HttpStatusCode.BadRequest, "Transaction not found");
                var newTransaction = _mapper.Map<Transaction>(transaction);
                _context.Transactions.Update(newTransaction);
                await _context.SaveChangesAsync();
                return new Response<string>("Transaction successfully updated");
            }
            catch (DbException e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
            catch (Exception e)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion

        #region RemoveTransactionAsync

        public async Task<Response<bool>> RemoveTransactionAsync(int transactionId)
        {
            try
            {
                var existing = await _context.Transactions.Where(x => x.Id == transactionId).ExecuteDeleteAsync();
                return existing == 0
                    ? new Response<bool>(HttpStatusCode.BadRequest, "Transaction not found")
                    : new Response<bool>(true);
            }
            catch (DbException e)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
            catch (Exception e)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion
    }
}
