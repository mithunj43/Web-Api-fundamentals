﻿using CityInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(
            int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            //find point of interest
            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (pointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }

        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto pointOfInterest)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointOfInterestId = finalPointOfInterest.Id
                },
                finalPointOfInterest);
        }

        [HttpPut("{pointofinterestid}")]
        public ActionResult UpdatePointOfInterst(int cityId, int pointOfInterestId,
            PointOfInterestForUpdateDto pointOfInterest)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            { 
                return NotFound(); 
            }

            var pointOfInterstFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
            if (pointOfInterstFromStore == null)
            {  
                return NotFound();
            }

            pointOfInterstFromStore.Name = pointOfInterest.Name;
            pointOfInterstFromStore.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpPatch("{pointofinterestid}")]
        public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId,
        JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterstFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
            if (pointOfInterstFromStore == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
            {
                Name = pointOfInterstFromStore.Name,
                Description = pointOfInterstFromStore.Description,
            };

            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState); // Model state should be used what if patchDocument contains property that even exists
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest(ModelState);
            }

            pointOfInterstFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterstFromStore.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }
    }
}
