using Api.Collections;
using Api.Collections.Models;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Collections.MongoDB _mongoDB;
        IMongoCollection<Infected> _infectedCollection;

        public InfectedController(Collections.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedCollection = _mongoDB.database.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpGet]
        public ActionResult FindAll()
        {
            var infected = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();
            return Ok(infected);
        }

        [HttpPost]
        public ActionResult SaveInfected([FromBody] InfectedDTO dto)
        {
            var infected = new Infected(dto.BornDate, dto.Gender, dto.Latitude, dto.Longitude);
            _infectedCollection.InsertOne(infected);
            return StatusCode(201, "Infected has been added");
        }

        [HttpPut]
        public ActionResult UpdateInfected([FromBody] InfectedDTO dto)
        {
            var infected = new Infected(dto.BornDate, dto.Gender, dto.Latitude, dto.Longitude);
            _infectedCollection.UpdateOne(Builders<Infected>.Filter.Where(inf => inf.BornDate == dto.BornDate),
                Builders<Infected>.Update.Set("gender", dto.Gender));
            return Ok(infected);
        }

        [HttpDelete]

        public ActionResult DeleteInfected(DateTime bornDate)
        {
            _infectedCollection.DeleteOne(Builders<Infected>.Filter.Where(inf => inf.BornDate == bornDate));
            return StatusCode(200, "Infected is no more infected");
        }
    }
}
