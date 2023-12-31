using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore() { 
            Cities = new List<CityDto>() { 
                new CityDto() 
                { 
                    Id = 1,
                    Name = "Bangalore",
                    Description = "The one with garden city"
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Mysore",
                    Description = "The one with Mysore Palace"
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Mangalore",
                    Description = "The one with Ocean"
                }
            };
        }
    }
}
