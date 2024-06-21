namespace CaseStudy.Infrastructure.Constants
{
    public static class QueryConstants
    {
        public const string randomCarsQuery = "SELECT TOP 10 * FROM Cars ";
        public const string carByUserId = @"
                SELECT c.*
                FROM UserFavourites uf
                JOIN Cars c ON uf.VIN = c.VIN
               
                WHERE uf.UserId = @userId";
    }
}
