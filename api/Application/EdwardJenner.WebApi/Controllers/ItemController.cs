using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdwardJenner.Domain.Interfaces.Repositories;
using EdwardJenner.Domain.Interfaces.Services;
using EdwardJenner.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdwardJenner.WebApi.Controllers
{
    public class ItemController : BaseController
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICacheService<Item> _cacheService;
        private readonly ICacheService<Order> _orderCacheService;

        public ItemController(IItemRepository itemRepository, ICacheService<Item> cacheService, ICacheService<Order> orderCacheService)
        {
            _itemRepository = itemRepository;
            _cacheService = cacheService;
            _orderCacheService = orderCacheService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Item result;

            try
            {
                result = await _cacheService.GetObjectCache($"ej.item.getbyid.{id}");

                if (result == null)
                {
                    result = await _itemRepository.FindBy(x => x.Id == id);
                    await _cacheService.SetObjectCache($"ej.item.getbyid.{id}", result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = await _itemRepository.FindBy(x => x.Id == id);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> List()
        {
            IList<Item> result;

            try
            {
                result = await _cacheService.GetObjectListCache("ej.item.listall");

                if (result == null)
                {
                    result = await _itemRepository.ListBy(x => true);
                    await _cacheService.SetObjectListCache("ej.item.listall", result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = await _itemRepository.ListBy(x => true);
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Put([FromBody] Item item)
        {
            var update = await _itemRepository.Update(item);

            try
            {
                await _cacheService.RemoveCacheByPattern("ej.item");
                await _orderCacheService.RemoveCacheByPattern("ej.order");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok(update);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Item item)
        {
            await _itemRepository.Insert(item);

            try
            {
                await _cacheService.RemoveCacheByPattern("ej.item");
                await _orderCacheService.RemoveCacheByPattern("ej.order");
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
            await _itemRepository.Delete(x => x.Id == id);

            try
            {
                await _cacheService.RemoveCacheByPattern("ej.item");
                await _orderCacheService.RemoveCacheByPattern("ej.order");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok();
        }
    }
}
