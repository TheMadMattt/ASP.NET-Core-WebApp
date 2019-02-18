using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Cars.Any())
            {
                context.AddRange(
new Car { Mark = "Ford", Model = "Mustang", ProductionYear = 2016, Mileage = "34 000 km", TankSize = "4 900 cm3", FuelType = "benzyna", Power = "421 KM", Description = "Mam do sprzedania Mustanga 5.0 GT V8 421KM. Kupiony w Polskim SALONIE FORDA w Opolu jako NOWY w kwietniu 2016", Price = 160000M, PhotoURL = "/images/fordMustang.jpg", ThumbnailURL = "/images/fordMustang.jpg", IsCarOfTheWeek = true },
                    new Car { Mark = "Audi", Model = "S5", ProductionYear = 2013, Mileage = "112 000 km", TankSize = "3 000 cm3", FuelType = "benzyna", Power = "280 KM", Description = "Do sprzedania Audi S5 z 2013 roku. Jestem właścicielem tego Caru od ponad dwóch lat.", Price = 115000M, PhotoURL = "/images/audiS5.jpg", ThumbnailURL = "/images/audiS5.jpg", IsCarOfTheWeek = true },
                    new Car { Mark = "BMV", Model = "X4", ProductionYear = 2017, Mileage = "4 300 km", TankSize = "1 995 cm3", FuelType = "benzyna", Power = "190 KM", Description = "BMV X4 20d xDrive. SaPowerhód krajowy. SaPowerhód serwisowany. Wystawiamy fakturę VAT 23%. SaPowerhód bezwypadkowy. I właściciel.", Price = 194000M, PhotoURL = "/images/bmvx4.jpg", ThumbnailURL = "/images/bmvx4.jpg", IsCarOfTheWeek = true },
                    new Car { Mark = "Chevrolet", Model = "Corvette", ProductionYear = 1972, Mileage = "28 000 km", TankSize = "5 700 cm3", FuelType = "benzyna", Power = "300 KM", Description = "Corvetta jest w świetnym stanie wizualnym i mechanicznym. Oczywiście jest ZAREJESTROWANA i ubezpieczona w PL.", Price = 90000M, PhotoURL = "/images/chevroletCorvete.jpg", ThumbnailURL = "/images/chevroletCorvete.jpg", IsCarOfTheWeek = true },
                    new Car { Mark = "Nissan", Model = "Skyline", ProductionYear = 1995, Mileage = "144 000 km", TankSize = "2 500 cm3", FuelType = "benzyna", Power = "410 KM", Description = "Na sprzedaż trafia moja perełka Nissan Skyline R33.Auto z Japonii sprowadzone do Szwecji, gdzie było przez wiele lat modyfikowane, uczestniczyło w zlotach, zdobywało nagrody, saPowerhód sponsorowany latami przez Sonax Sweden.", Price = 120000M, PhotoURL = "/images/nissan.jpg", ThumbnailURL = "/images/nissan.jpg", IsCarOfTheWeek = true },
                    new Car { Mark = "Jaguar", Model = "ZX", ProductionYear = 2006, Mileage = "78000 km", TankSize = "5 000 cm3", FuelType = "benzyna", Power = "510 KM", Description = "Przedstawiam Państwu wyjątkowe auto jakim jest Jaguar XKR, a zwłaszcza ten egzemplarz. Jaguar XKR to ikona światowej i brytyjskiem motoryzacji, a przede wszystkim kontynuator legendarnego już Jaguara E-typa, przez wielu uważany za najpiękniejsze auto w historii motoryzacji.", Price = 200000M, PhotoURL = "/images/jaguar.jpg", ThumbnailURL = "/images/jaguar.jpg", IsCarOfTheWeek = true }
                    );
            }

            context.SaveChanges();
        }
    }
}
