using Navtech.OMS.Api.Models;
using Navtech.OMS.Data.Contracts;
using Navtech.OMS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Navtech.OMS.Api.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly AddressRepository _AddressRepository;
        private readonly BuyerRepository _BuyerRepository;
        private readonly ProductRepository _ProductRepository;
        private readonly OrderRepository _OrderRepository;

        public OrdersController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
            _AddressRepository = new AddressRepository(_UnitOfWork);
            _BuyerRepository = new BuyerRepository(_UnitOfWork);
            _ProductRepository = new ProductRepository(_UnitOfWork);
            _OrderRepository = new OrderRepository(_UnitOfWork);
        }

        [HttpPost]
        public HttpResponseMessage Post(OrderModel model)
        {
            bool isNewOder = model.Order.Id == default(int) ? true : false;

            if (!model.IsValid())
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, string.Join(",", model.ValidationMessages));
            }
            else
            {
                try
                {
                    if (model.Buyer.Id == default(int))
                        model.Buyer = _BuyerRepository.Insert(model.Buyer);
                    else
                        _BuyerRepository.Update(model.Buyer);

                    model.Addresses.ForEach(address =>
                    {
                        address.BuyerId = model.Buyer.Id;
                        if (address.Id == default(int))
                            address = _AddressRepository.Insert(address);
                        else
                            _AddressRepository.Update(address);
                    });

                    model.Order.BuyerId = model.Buyer.Id;
                    if (model.Order.Id == default(int))
                        model.Order = _OrderRepository.Insert(model.Order);
                    else
                        _OrderRepository.Update(model.Order);

                    model.Products.ForEach(product =>
                    {
                        product.OrderId = model.Order.Id;
                        if (product.Id == default(int))
                            product = _ProductRepository.Insert(product);
                        else
                            _ProductRepository.Update(product);
                    });
                }
                catch (Exception error)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, string.Format("Order has been {0} successfully", isNewOder ? "placed" : "updated"));
            }
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            //In General, Application user role is determined after authentication. I'm assuming that admin has requested the GET
            List<OrderModel> orders = new List<OrderModel>();
            _OrderRepository.GetAll().ToList().ForEach(order =>
            {
                OrderModel orderModel = new OrderModel();
                orderModel.Products = _ProductRepository.GetAll(product => product.OrderId == order.Id).ToList();
                orderModel.Buyer = _BuyerRepository.GetAll(buyer => buyer.Id == order.BuyerId).FirstOrDefault();
                orderModel.Addresses = _AddressRepository.GetAll(address => address.Id == order.BuyerId).ToList();
                orderModel.Order = order;

                orders.Add(orderModel);
            });
            return Json(orders);
        }
    }
}