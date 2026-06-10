namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            const string xmlRootName = "Creators";

            StringBuilder output = new StringBuilder();
            ICollection<Creator> creatorsToImport = new List<Creator>();

            // the following may be nullable
            IEnumerable<ImportCreatorDto>? creatorDtos =
                XmlSerializerWrapper.Deserialize<ImportCreatorDto[]>(xmlString, xmlRootName);

            if (creatorDtos != null)
            {
                foreach (ImportCreatorDto creatorDto in creatorDtos)
                {
                    if (!IsValid(creatorDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Creator creator = new Creator()
                    {
                        FirstName = creatorDto.FirstName,
                        LastName = creatorDto.LastName
                    };

                    foreach (ImportCreatorBoardgameDto boardgameDto in creatorDto.Boardgames)
                    {
                        if (!IsValid(boardgameDto) || (!Enum.IsDefined(typeof(CategoryType), boardgameDto.CategoryType)))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        Boardgame boardgame = new Boardgame()
                        {
                            Name = boardgameDto.Name,
                            Rating = boardgameDto.Rating,
                            YearPublished = boardgameDto.YearPublished,
                            CategoryType = (CategoryType)boardgameDto.CategoryType,
                            Mechanics = boardgameDto.Mechanics
                        };

                        creator.Boardgames.Add(boardgame);
                    }

                    creatorsToImport.Add(creator);
                    output.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
                }

                context.Creators.AddRange(creatorsToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Seller> sellersToImport = new List<Seller>();

            // nullable
            IEnumerable<ImportSellerDto>? sellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            if (sellerDtos != null)
            {
                foreach (ImportSellerDto sellerDto in sellerDtos)
                {
                    if (!IsValid(sellerDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Seller newSeller = new Seller()
                    {
                        Name = sellerDto.Name,
                        Address = sellerDto.Address,
                        Country = sellerDto.Country,
                        Website = sellerDto.Website
                    };

                    foreach (int id in sellerDto.Boardgames.Distinct())
                    {
                        bool boardgameExists = context.Boardgames.Any(b => b.Id == id);

                        if (!boardgameExists)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        newSeller.BoardgamesSellers.Add(new BoardgameSeller()
                        {
                            BoardgameId = id
                        });
                    }

                    sellersToImport.Add(newSeller);

                    output.AppendLine(String.Format(SuccessfullyImportedSeller, newSeller.Name, newSeller.BoardgamesSellers.Count));
                }

                context.Sellers.AddRange(sellersToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
