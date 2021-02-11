using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; // DB contem informações
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d3);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 2500.0, d2);
            Seller s3 = new Seller(3, "Irgo", "irgo@gmail.com", new DateTime(1996, 1, 3), 2200.0, d1);
            Seller s4 = new Seller(4, "Keyse", "keyse@gmail.com", new DateTime(1999, 6, 25), 1600.0, d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2012, 7, 5), 13520.0, SaleStatus.Billed, s3);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2021, 3, 20), 9000.0, SaleStatus.Billed, s2);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2020, 4, 13), 11000.0, SaleStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4);

            _context.SalesRecord.AddRange(r1, r2, r3, r4);


            _context.SaveChanges();

        }
    }
}
