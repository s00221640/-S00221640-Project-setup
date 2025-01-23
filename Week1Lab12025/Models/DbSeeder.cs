﻿namespace Week1Lab12025.Models
{
    public class DbSeeder
    {
        private readonly UserContext _ctx;
        private readonly IWebHostEnvironment _hosting;
        private bool disposedValue;


        public DbSeeder(UserContext ctx, IWebHostEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Users.Any())
            {

                _ctx.Users.AddRange(new List<User>()
                {
                    new User
                    {
                        FirstName = "Mark",
                        MidName = "J",
                        LastName = "Lavin",
                        DOB = new DateTime(day: 11, month: 12, year: 1996)
                    },
                    new User(),
                    new User(),
                    new User(),
                    new User()
                    }
                );
                _ctx.SaveChanges();
            }
        }
    } 
}
