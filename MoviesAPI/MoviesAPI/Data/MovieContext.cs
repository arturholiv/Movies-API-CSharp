﻿using MoviesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opts) : base(opts) 
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
