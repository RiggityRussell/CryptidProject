using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CryptidProject.Data;
using System;
using System.Linq;

namespace CryptidProject.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CryptidProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CryptidProjectContext>>()))
            {
                // Look for any cryptids.
                if (context.Cryptids.Any())
                {
                    return;   // DB has been seeded
                }

                context.Cryptids.AddRange(
                    new Cryptids
                    {
                        CryptidName = "Bigfoot",
                        OtherName = "Sasquatch",
                        Description = "Humanoid Woodland Ape.",
                        Location = "America"
                    },
                    new Cryptids
                    {
                        CryptidName = "Chupacabra(s)",
                        OtherName = "Goat Sucker",
                        Description = "Dog Monster that kills goats.",
                        Location = "Mexico"
                    },
                    new Cryptids
                    {
                        CryptidName = "DogMan",
                        OtherName = "Michigan Dog Man",
                        Description = "Bi-pedal canine like animal with the torso of a man!",
                        Location = "Wexford County, Michigan"
                    },
                    new Cryptids
                    {
                        CryptidName = "Yeti",
                        OtherName = "Abominable Snowman",
                        Description = "Like bigfoot but white.",
                        Location = "Himalayas"
                    },
                    new Cryptids
                    {
                        CryptidName = "Jersey Devil",
                        OtherName = "Leeds Devil",
                        Description = "Winged bi-pedal horse",
                        Location = "South Jersey Pine Barrens."
                    },
                    new Cryptids
                    {
                        CryptidName = "Moth Man",
                        OtherName = "N/A",
                        Description = "Mothlike humanoid with wings.",
                        Location = "Point Pleasant West Virginia"
                    },
                    new Cryptids
                    {
                        CryptidName = "Loch Ness Monster",
                        OtherName = "Nessy",
                        Description = "Lake Monster.",
                        Location = "Loch Ness, Scotland"
                    }, new Cryptids
                    {
                        CryptidName = "Ningen",
                        OtherName = "N/A",
                        Description = "Whalelike humanoid with human legs.",
                        Location = "Subantarctic"
                    },
                    new Cryptids
                    {
                        CryptidName = "Cthulhu",
                        OtherName = "The Ancient One",
                        Description = "Cosmic Entity",
                        Location = "Alternate planes of reality."
                    },
                    new Cryptids
                    {
                        CryptidName = "Mongolian Death Worm",
                        OtherName = "Allghoi",
                        Description = "Worm-like animal",
                        Location = "Gobi Desert"
                    },
                     new Cryptids
                     {
                         CryptidName = "Elwetritsch",
                         OtherName = "N/A",
                         Description = "Birdlike",
                         Location = "Germany"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
