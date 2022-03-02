using Furniture_Shop_Backend.Models;
using Furniture_Shop_Backend.Utilities.Constants;
using Furniture_Shop_Backend.ViewModels.Common;
using Furniture_Shop_Backend.ViewModels.Order;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Furniture_Shop_Backend.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly FurnitureShopContext _context;

        public OrdersService(FurnitureShopContext context)
        {
            _context = context;
        }
        public Task<bool> CheckExist(string productName)
        {
            //   var query = from p in _context.Invoices
            throw new System.NotImplementedException();
        }

        public async Task<ApiResult<bool>> Create(OrderCreateRequest request)
        {

            // non-check expire
            if (request?.VoucherId > 0)
            {
                var voucher = await _context.Vouchers.FindAsync(request.VoucherId);
                if (voucher == null)
                    return new ApiErrorResult<bool>($"Can't not find voucher with id: {request.VoucherId}");
            }
            // check exist user
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
            {
                return new ApiErrorResult<bool>($"Can't not find user with id: {request?.UserId}");
            }
            // check exist product
            foreach (var item in request.orderItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null)
                {
                    return new ApiErrorResult<bool>($"Can't not find Product with id: {item.ProductId}");
                }
            }
            // save Invoice
            var Invoice = new Invoice()
            {
                Destination = request.Destination,
                CreateAt = DateTime.Now,
                UserId = request.UserId,
                VoucherId = request.VoucherId,
                PaymentStatus = PaymentStatus.UnPaid,
                DeliveryStatus = DeliveryStatus.Pending
            };
            _context.Invoices.Add(Invoice);
            await _context.SaveChangesAsync();
            //save Invoice detail
            foreach (var item in request.orderItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null)
                {
                    return new ApiErrorResult<bool>($"Can't not find Product with id: {item.ProductId}");
                }
                var orderItem = new InvoiceDetail()
                {
                    InvoiceId = Invoice.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };
                _context.InvoiceDetails.Add(orderItem);
                await _context.SaveChangesAsync();
            }
            // return success
            return new ApiSuccessResult<bool>();
        }

        public Task<int> Delete(int productId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PagedResult<OrderVm>> GetAllPaging(GetOrderPagingRequest request)
        {

            var query = from i in _context.Invoices
                        join u in _context.Users on i.UserId equals u.Id
                        join v in _context.Vouchers on i.VoucherId equals v.Id into ps
                        from v in ps.DefaultIfEmpty()
                        select new { i, u, v };
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
               .Take(request.PageSize)
               .Select(x => new OrderVm()
               {
                   Id = x.i.Id,
                   UserId = x.u.Id,
                   UserName = x.u.Username,
                   VoucherId = x.v.Id == null ? 0 : x.v.Id,
                   VoucherDesc = x.v.Description == null ? "n/a" : x.v.Description,
                   CreateDate = x.i.CreateAt == null ? "n/a" : ((DateTime)x.i.CreateAt).ToString("dd/MM/yyyy"),
                   Destination = x.i.Destination,
                   DeliveryStatus = x.i.DeliveryStatus,
                   PaymentStatus = x.i.PaymentStatus,
               }).ToListAsync();
            foreach (var item in data)
            {
                var queryItem = from i in _context.InvoiceDetails
                                join p in _context.Products on i.ProductId equals p.Id
                                select new { i, p };
                queryItem = queryItem.Where(o => o.i.InvoiceId.Equals(item.Id));
                var dataItem = await queryItem.Select(
                x => new OrderItemVm()
                {
                    ProductId = x.p.Id,
                    ProductName = x.p.Name,
                    Quantity = (int)(x.i.Quantity),
                    Price = (decimal)(x.i.UnitPrice),
                }).ToListAsync();
                item.orderItems = dataItem.ToArray();
            }

            var pagedResult = new PagedResult<OrderVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<OrderVm> GetById(int id)
        {

            var query = from i in _context.Invoices
                        join u in _context.Users on i.UserId equals u.Id
                        join v in _context.Vouchers on i.VoucherId equals v.Id into ps
                        from v in ps.DefaultIfEmpty()
                        select new { i, u, v };
            query = query.Where(o => o.i.Id.Equals(id));
            Console.WriteLine(query);
            var data = await query.Select(
                x => new OrderVm()
                {
                    Id = x.i.Id,
                    UserId = x.u.Id,
                    UserName = x.u.Username,
                    VoucherId = x.v.Id == null ? 0 : x.v.Id,
                    VoucherDesc = x.v.Description == null ? "n/a" : x.v.Description,
                    CreateDate = x.i.CreateAt == null ? "n/a" : ((DateTime)x.i.CreateAt).ToString("dd/MM/yyyy"),
                    Destination = x.i.Destination,
                    DeliveryStatus = x.i.DeliveryStatus,
                    PaymentStatus = x.i.PaymentStatus,
                }).ToListAsync();

            foreach (var item in data)
            {
                var queryItem = from i in _context.InvoiceDetails
                                join p in _context.Products on i.ProductId equals p.Id
                                select new { i, p };
                queryItem = queryItem.Where(o => o.i.InvoiceId.Equals(item.Id));
                var dataItem = await queryItem.Select(
                x => new OrderItemVm()
                {
                    ProductId = x.p.Id,
                    ProductName = x.p.Name,
                    Quantity = (int)(x.i.Quantity),
                    Price = (decimal)(x.i.UnitPrice),
                }).ToListAsync();
                item.orderItems = dataItem.ToArray();
            }
            //4. Select 
            return data.FirstOrDefault();
        }

        public Task<ApiResult<int>> Update(int id, int request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApiResult<bool>> UpdateStatusDelivery(int id, string status)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return new ApiErrorResult<bool>($"Can't not find invoice with id: {id}");
            }
            if (status.Equals(DeliveryStatus.Pending))
            {
                invoice.DeliveryStatus = DeliveryStatus.Pending;
            }
            if (status.Equals(DeliveryStatus.Processing))
            {
                invoice.DeliveryStatus = DeliveryStatus.Processing;
            }
            if (status.Equals(DeliveryStatus.Delivery))
            {
                invoice.DeliveryStatus = DeliveryStatus.Delivery;
            }
            if (status.Equals(DeliveryStatus.Complete))
            {
                invoice.DeliveryStatus = DeliveryStatus.Complete;
            }
            if (status.Equals(DeliveryStatus.Cancle))
            {
                invoice.DeliveryStatus = DeliveryStatus.Cancle;
            }
            _context.Invoices.Update(invoice);
            var result = await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> UpdateStatusPayment(int id, string status)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return new ApiErrorResult<bool>($"Can't not find invoice with id: {id}");
            }
            if (status.Equals(PaymentStatus.UnPaid))
            {
                invoice.PaymentStatus = PaymentStatus.UnPaid;
            }
            if (status.Equals(PaymentStatus.PartiallyPaid))
            {
                invoice.PaymentStatus = PaymentStatus.PartiallyPaid;
            }
            if (status.Equals(PaymentStatus.Paid))
            {
                invoice.PaymentStatus = PaymentStatus.Paid;
            }
            if (status.Equals(PaymentStatus.Refund))
            {
                invoice.PaymentStatus = PaymentStatus.Refund;
            }
            if (status.Equals(PaymentStatus.Failed))
            {
                invoice.PaymentStatus = PaymentStatus.Failed;
            }
            _context.Invoices.Update(invoice);
            var result = await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
    }
}
