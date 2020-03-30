using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdwardJenner.Domain.Interfaces.Repositories;
using EdwardJenner.Domain.Interfaces.Services;
using EdwardJenner.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdwardJenner.WebApi.Controllers
{
    public class RatingController : BaseController
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ICacheService<Rating> _cacheService;

        public RatingController(IRatingRepository ratingRepository, ICacheService<Rating> cacheService)
        {
            _ratingRepository = ratingRepository;
            _cacheService = cacheService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Rating result;

            try
            {
                result = await _cacheService.GetObjectCache($"ej.rating.getbyid.{id}");

                if (result == null)
                {
                    result = await _ratingRepository.FindBy(x => x.Id == id);
                    await _cacheService.SetObjectCache($"ej.rating.getbyid.{id}", result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = await _ratingRepository.FindBy(x => x.Id == id);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> List()
        {
            IList<Rating> result;

            try
            {
                result = await _cacheService.GetObjectListCache("ej.rating.listall");

                if (result == null)
                {
                    result = await _ratingRepository.ListBy(x => true);
                    await _cacheService.SetObjectListCache("ej.rating.listall", result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = await _ratingRepository.ListBy(x => true);
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Put([FromBody] Rating rating)
        {
            var update = await _ratingRepository.Update(rating);

            try
            {
                await _cacheService.RemoveCacheByPattern("ej.rating");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok(update);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Rating rating)
        {
            await _ratingRepository.Insert(rating);

            try
            {
                await _cacheService.RemoveCacheByPattern("ej.rating");
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
            await _ratingRepository.Delete(x => x.Id == id);

            try
            {
                await _cacheService.RemoveCacheByPattern("ej.rating");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok();
        }
    }
}
