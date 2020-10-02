using AutoMapper;
using CSharp.DTOs;
using CSharp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Controllers
{
	[Route("orders")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderRepository _repository;
		private readonly IMapper _mapper;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderRepository repository, IMapper mapper, ILogger<OrderController> logger)
		{
			_repository = repository;
			_mapper = mapper;
			_logger = logger;

		}
/*
		[HttpPut]
		public ActionResult CreateOrder(OrderCreateDTO order)
		{

			return null;
		}
*/
		[HttpGet("customers/{id}")]
		public ActionResult<IEnumerable<OrderReadDTO>> GetOrdersByCustomer(int id)
		{
			if(id < 0)
            {
				_logger.LogError("customer_id was less that 0");
				return BadRequest();
            }
			var cart = _repository.GetAllOrdersByCustomer(id);

			return Ok(_mapper.Map<List<OrderReadDTO>>(cart));
		}
/*
		[HttpPatch("{order_id}")]
		public ActionResult UpdateOrder(int order_id, Order order)
		{
			return null;
		}
*/
		[HttpDelete("{order_id}")]
		public ActionResult DeleteOrder(int order_id)
		{			
			_repository.DeleteOrder(order_id);
			return Ok();
		}
	}
}
