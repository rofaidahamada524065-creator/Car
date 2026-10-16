using Car.Model;
using Microsoft.EntityFrameworkCore;

namespace Car.Data
{
    public class AppDbcontext: DbContext
    {
        public AppDbcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasMany(a => a.vehicles).WithOne(a => a.category).HasForeignKey(a => a.CatigoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasMany(a => a.sales).WithOne(a => a.customer).HasForeignKey(a => a.CustomerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Employee>().HasMany(a => a.sales).WithOne(a => a.employee).HasForeignKey(a => a.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Vehicle>().HasOne(a => a.sale).WithOne(a => a.vehicle).HasForeignKey<Sale>(a => a.VehicleId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasOne(a => a.customerProfile).WithOne(a => a.customer).HasForeignKey<CustomerProfile>(a => a.CustomerId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                 .HasIndex(c => c.Name)
                 .IsUnique();

            // Vehicle: VIN must be unique
            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.VIN)
                .IsUnique();

            // Customer: Email must be unique
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            // Customer: DriverLicenseNumber must be unique
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.DriverLicenseNumber)
                .IsUnique();

            // Employee: Email must be unique
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

            // Vehicle: Price decimal(12,2)
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Price)
                 .HasPrecision(12, 2);

            // Sale: SalePrice decimal(12,2)
            modelBuilder.Entity<Sale>()
                .Property(s => s.SalePrice)
                .HasPrecision(12,2);

            // Vehicle: Default Status = Available
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Status)
                .HasDefaultValue("Available");
            // 1. Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sedan", Discreption = "Comfortable passenger cars" },
                new Category { Id = 2, Name = "SUV", Discreption = "Sport utility vehicles" },
                new Category { Id = 3, Name = "Hatchback", Discreption = "Compact practical cars" }
            );

            // 2. Vehicles
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = 1,
                    Make = "Toyota",
                    Model = "Corolla",
                    Year = 2024,
                    Color = "White",
                    Price = 650000,
                    Mileage = 12000,
                    VIN = "VIN00000000000001",
                    FuelType = "Petrol",
                    Transmission = "Automatic",
                    Status = "Available",
                    CatigoryId = 1
                },
                new Vehicle
                {
                    Id = 2,
                    Make = "Hyundai",
                    Model = "Elantra",
                    Year = 2023,
                    Color = "Black",
                    Price = 590000,
                    Mileage = 18000,
                    VIN = "VIN00000000000002",
                    FuelType = "Petrol",
                    Transmission = "Automatic",
                    Status = "Available",
                    CatigoryId = 1
                },
                new Vehicle
                {
                    Id = 3,
                    Make = "Kia",
                    Model = "Sportage",
                    Year = 2024,
                    Color = "Gray",
                    Price = 980000,
                    Mileage = 9000,
                    VIN = "VIN00000000000003",
                    FuelType = "Petrol",
                    Transmission = "Automatic",
                    Status = "Available",
                    CatigoryId = 2
                }
            );

            // 3. Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed.hassan@example.com",
                    Phone = "01010000001",
                    DriverLicenseNumber = "DL100001"
                },
                new Customer
                {
                    Id = 2,
                    FullName = "Mona Adel",
                    Email = "mona.adel@example.com",
                    Phone = "01010000002",
                    DriverLicenseNumber = "DL100002"
                },
                new Customer
                {
                    Id = 3,
                    FullName = "Omar Khaled",
                    Email = "omar.khaled@example.com",
                    Phone = "01010000003",
                    DriverLicenseNumber = "DL100003"
                }
            );

            // 4. Customer Profiles
            modelBuilder.Entity<CustomerProfile>().HasData(
                new CustomerProfile
                {
                    Id = 1,
                    Address = "12 Nile St.",
                    City = "Cairo",
                    Nationality = "Egyptian",
                    DateOfBirth = new DateTime(1992, 3, 12),
                    CustomerId = 1
                },
                new CustomerProfile
                {
                    Id = 2,
                    Address = "25 Tahrir St.",
                    City = "Giza",
                    Nationality = "Egyptian",
                    DateOfBirth = new DateTime(1995, 7, 24),
                    CustomerId = 2
                },
                new CustomerProfile
                {
                    Id = 3,
                    Address = "18 El Nasr St.",
                    City = "Cairo",
                    Nationality = "Egyptian",
                    DateOfBirth = new DateTime(1988, 11, 5),
                    CustomerId = 3
                }
            );

            // 5. Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FullName = "Mostafa Nabil",
                    Position = "Sales Manager",
                    Email = "mostafa.nabil@autodrive.com",
                    Phone = "01020000001",
                    HireDate = new DateTime(2021, 1, 10)
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Aya Emad",
                    Position = "Sales Consultant",
                    Email = "aya.emad@autodrive.com",
                    Phone = "01020000002",
                    HireDate = new DateTime(2022, 4, 15)
                },
                new Employee
                {
                    Id = 3,
                    FullName = "Hassan Ali",
                    Position = "Sales Consultant",
                    Email = "hassan.ali@autodrive.com",
                    Phone = "01020000003",
                    HireDate = new DateTime(2023, 2, 20)
                }
            );

            // 6. Sales
            modelBuilder.Entity<Sale>().HasData(
                new Sale
                {
                    Id = 1,
                    SaleDate = new DateTime(2026, 8, 15),
                    SalePrice = 1750000,
                    PaymentMethod = "Bank Transfer",
                    Note = "Completed sale.",
                    CustomerId = 1,
                    EmployeeId = 1,
                    VehicleId = 1
                },
                new Sale
                {
                    Id = 2,
                    SaleDate = new DateTime(2026, 8, 22),
                    SalePrice = 1850000,
                    PaymentMethod = "Bank Transfer",
                    Note = "Completed sale.",
                    CustomerId = 2,
                    EmployeeId = 2,
                    VehicleId = 3
                },
                new Sale
                {
                    Id = 3,
                    SaleDate = new DateTime(2026, 9, 5),
                    SalePrice = 510000,
                    PaymentMethod = "Cash",
                    Note = "Completed sale.",
                    CustomerId = 3,
                    EmployeeId = 3,
                    VehicleId = 2
                }
            );
        }

    }
}
