namespace Tms.Services.EdgeManagement.Domain
{
    public static class Locations
    {      
        public static Location KölnerDom = new Location{ Name = "Kölner Dom", Position = new GeoPosition{Longitude = 50.9413, Latitude = 6.9583} };

        public static Location PZ_50 = new Location{ Name = "Kölner Dom", Position = new GeoPosition{Longitude = 50.886129, Latitude = 6.919789} };
    }

    
    public static class ContainerTypes
    {      
        public static ContainerType Kiste = new ContainerType { Id = 1, Name = "Kiste" };

        public static ContainerType Sack = new ContainerType { Id = 2, Name = "Sack" };
    }

    public static class ProductTypes
    {
        public static ProductType Brief = new ProductType { Id = 1, Name = "Brief" };

        public static ProductType Paket = new ProductType { Id = 2, Name = "Paket" };

        public static ProductType Nuss = new ProductType { Id = 3, Name = "Nuss" };
    }
}