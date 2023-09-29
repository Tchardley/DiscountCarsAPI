
using DiscountCarsAPI.Interface;
using DiscountCarsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscountCarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;

        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Car>>> GetAllCars()
        {
            var car = await _carRepository.GetAllCars();
            if( car == null)
            {
                return BadRequest("Sorry this car doesn't exist");
            }
            return Ok(car);
           
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            
          var result = await _carRepository.GetCar(id);
            
            if (result is null)
                return NotFound("Car is not found!");
            return Ok(result);
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Car>>> CreateCar([FromBody] Car car)
        {
            
            var result = await _carRepository.CreateCar(car);
            if (result is null)
                return NotFound("Car is not found!");

            return Ok(result);
        }

       
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Car>>> UpdateCar(int id, Car request)
        {
           var result = await _carRepository.UpdateCar(id, request);
            if (result is null)
                return NotFound("Car is not found!");
            return Ok(result);
        }

       
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Car>>> DeleteCar(int id)
        {
            var result = await _carRepository.DeleteCar(id);
            if (result is null)
                return NotFound("Car is not found!");
            return Ok(result);
        }
    }
}
