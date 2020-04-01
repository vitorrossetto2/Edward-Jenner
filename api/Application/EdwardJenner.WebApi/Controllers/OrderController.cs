using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdwardJenner.Domain.Interfaces.Repositories;
using EdwardJenner.Domain.Interfaces.Services;
using EdwardJenner.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdwardJenner.WebApi.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICacheService<Order> _cacheService;

        public OrderController(IOrderRepository orderRepository, ICacheService<Order> cacheService)
        {
            _orderRepository = orderRepository;
            _cacheService = cacheService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Order result;

            try
            {
                result = await _cacheService.GetObjectCache($"ej.order.getbyid.{id}");

                if (result == null)
                {
                    result = await _orderRepository.FindBy(x => x.Id == id);
                    await _cacheService.SetObjectCache($"ej.order.getbyid.{id}", result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = await _orderRepository.FindBy(x => x.Id == id);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> List()
        {
            IList<Order> result;

            try
            {
                result = await _cacheService.GetObjectListCache("ej.order.listall");

                if (result == null)
                {
                    result = await _orderRepository.ListBy(x => true);
                    await _cacheService.SetObjectListCache("ej.order.listall", result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = await _orderRepository.ListBy(x => true);
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Put([FromBody] Order order)
        {
            var update = await _orderRepository.Update(order);

            try
            {
                await _cacheService.RemoveCacheByPattern("ej.order");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok(update);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            await _orderRepository.Insert(order);

            try
            {
                await _cacheService.RemoveCacheByPattern("ej.order");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _orderRepository.Delete(x => x.Id == id);

            try
            {
                await _cacheService.RemoveCacheByPattern("ej.order");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("near")]
        public async Task<IActionResult> GetByNear(double longitude, double latitude, int distance)
        {
            IList<Order> result;

            try
            {
                result = await _cacheService.GetObjectListCache($"ej.order.getbynear.{longitude}.{latitude}.{distance}");

                if (result == null)
                {
                    result = await _orderRepository.ListByNearAsync(longitude, latitude, distance);
                    await _cacheService.SetObjectListCache($"ej.order.getbynear.{longitude}.{latitude}.{distance}", result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = await _orderRepository.ListByNearAsync(longitude, latitude, distance);
            }

            return Ok(result);
        }
    }
}
