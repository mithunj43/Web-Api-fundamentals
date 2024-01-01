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
                    Description = "The one with garden city",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    { 
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "Lalbagh",
                            Description = "A centre for botanical artwork and conservation of plants"
                        },
                        new PointOfInterestDto(){
                            Id = 2,
                            Name = "ISKCON",
                            Description = "Sri Radha Krishna-Chandra Temple is one of the largest Krishna-Hindu temples in the world"
                        },
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Mysore",
                    Description = "The one with Mysore Palace",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "Mysore Palace",
                            Description = "Mysore Palace, also known as Amba Vilas Palace, is a historical palace and a royal residence"
                        },
                        new PointOfInterestDto(){
                            Id = 2,
                            Name = "Chamundeshwari Temple",
                            Description = "Temple was named after Chamundeshwari or, the fierce form of Shakti"
                        },
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Mangalore",
                    Description = "The one with Ocean",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto(){
                            Id = 1,
                            Name = "Panamburu Beach",
                            Description = "Tranquil beach featuring a broad stretch of sand & a lighthouse with views from the top"
                        },
                        new PointOfInterestDto(){
                            Id = 2,
                            Name = "Dharmasthala",
                            Description = "It is an 800-year-old Hindu religious institution in the temple town of Dharmasthala in Dakshina Kannada"
                        },
                    }
                }
            };
        }
    }
}
