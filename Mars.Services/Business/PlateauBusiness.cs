using Mars.Core;
using Mars.Model;
using System.Text.RegularExpressions;

namespace Mars.Services
{
    internal class PlateauBusiness : IPlateauBusiness
    {
        public IPlateauDto Create(string widthHeightText)
        {
            if (widthHeightText is null)
                throw new ValidationException($"Size information is null. Please try again.");

            var match = Regex.Match(widthHeightText, RegexPatterns.PlateauSize, RegexOptions.Singleline);

            if (match.Success)
                return new PlateauDto(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));

            throw new ValidationException($"{widthHeightText} is not matched.");
        }
    }
}
