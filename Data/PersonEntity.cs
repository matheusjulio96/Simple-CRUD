namespace Simple_CRUD.Data
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public string Country { get; set; } = null!;
        public string Role { get; set; } = null!;
    }

    public static class PersonExtensions
    {
        public static Person ToModel(this PersonEntity entity)
        {
            return new Person
            {
                Active = entity.Active,
                Country = entity.Country,
                Date = entity.Date,
                Fullname = entity.FullName,
                Id = entity.Id,
                Role = entity.Role,
                Username = entity.UserName,
            };
        }
    }
}
