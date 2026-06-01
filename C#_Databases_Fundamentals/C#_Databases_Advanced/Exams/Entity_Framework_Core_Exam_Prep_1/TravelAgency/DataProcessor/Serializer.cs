using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            const string xmlRootName = "Guides";

            ExportGuideDto[] guidesWithSpanishLanguageWithTourPackages = context
                .Guides
                .AsNoTracking()
                .Include(g => g.TourPackagesGuides)
                .ThenInclude(tpg => tpg.TourPackage)
                .Where(g => g.Language == Data.Models.Enums.Language.Spanish)
                .OrderByDescending(g => g.TourPackagesGuides.Count)
                .ThenBy(g => g.FullName)
                .ToArray()
                .Select(g => new ExportGuideDto()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                        .Select(tg => tg.TourPackage)
                        .Select(tp => new ExportGuideTourPackageDto()
                        {
                            Name = tp.PackageName,
                            Description = tp.Description ?? "",
                            Price = tp.Price.ToString("F2")
                        })
                        .OrderByDescending(tg => tg.Price)
                        .ThenBy(tg => tg.Name)
                        .ToArray()
                })
                .ToArray();

            string xmlResult = XmlSerializerWrapper
                .Serialize(guidesWithSpanishLanguageWithTourPackages, xmlRootName);

            return xmlResult;
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            const string targetPackage = "Horse Riding Tour";

            var customers = context
                .Customers
                .AsNoTracking()
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == targetPackage))
                .OrderByDescending(c => c.Bookings.Count(b => b.TourPackage.PackageName == targetPackage))
                .ThenBy(c => c.FullName)
                .Select(c => new
                {
                    c.FullName,
                    c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b => b.TourPackage.PackageName == targetPackage)
                        .OrderBy(b => b.BookingDate)
                        .Select(b => new
                        {
                            TourPackageName = b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString("yyyy-MM-dd")
                        })
                        .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
    }
}
