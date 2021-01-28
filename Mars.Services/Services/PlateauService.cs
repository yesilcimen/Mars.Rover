using Mars.Core;
using System;
using System.Linq;
using System.Text;

namespace Mars.Services
{
    public class PlateauService : IPlateauService
    {
        #region SingletonPattern
        private static readonly Lazy<IPlateauService> lazy = new Lazy<IPlateauService>(() => new PlateauService(), true);
        public static IPlateauService Current => lazy.Value;
        #endregion

        private readonly IPlateauBusiness _plateauBusiness;
        private PlateauService()
        {
            _plateauBusiness = new PlateauBusiness();
        }
        public TransactionResult<IPlateauDto> Create(string widthHeightText)
        {
            var result = new TransactionResult<IPlateauDto>();

            try
            {
                result.ResponseObject = _plateauBusiness.Create(widthHeightText);
                result.SetStatusSucceeded("Transaction succeed.");
            }
            catch (ValidationException ve)
            {
                result.SetStatusValidationException(ve.Message);
            }
            catch (Exception ex)
            {
                result.SetStatusUnhandledException(ex);
            }

            return result;
        }
        public TransactionResult<string> DisplayText(IPlateauDto plateau)
        {
            var result = new TransactionResult<string>();
            StringBuilder textBuilder = new StringBuilder();

            var dimentionX = plateau.Width + 1;
            var dimentionY = plateau.Heigth;
            var cellWidth = plateau.Width.ToString().Length + 2;
            if (cellWidth < 7)
                cellWidth = 7;
            var startHeight = plateau.Heigth.ToString().Length + 1;
            var whiteSpaces = string.Join(" ", new string[startHeight + 1]);

            for (int i = dimentionY; i >= 0; i--)
            {
                textBuilder.Append(whiteSpaces);
                for (int h = 0; h < dimentionX; h++)
                    textBuilder.Append($"+{string.Join("-", new string[cellWidth + 1])}");

                textBuilder.Append("+\n");
                textBuilder.Append($"{whiteSpaces.Substring(0, whiteSpaces.Length - i.ToString().Length)}{i}");

                for (int v = 0; v < dimentionX; v++)
                {
                    var rover = plateau.Rovers.Where(w => w.Position.X == v && w.Position.Y == i).Select((s, k) => new { s, k }).FirstOrDefault();
                    var roverText = $@"{rover?.k}{rover?.s.Symbol}{rover?.s.Position.Direction.Key}";
                    var lengthX = roverText.ToString().Length;
                    var startX = (int)Math.Floor((double)(cellWidth - lengthX) / 2);
                    var finishX = cellWidth - (startX + lengthX);

                    roverText = $"{string.Join(" ", new string[startX + 1])}{roverText}{string.Join(" ", new string[finishX + 1])}";

                    textBuilder.Append($"|{roverText}");
                }
                textBuilder.Append("|\n");
            }

            textBuilder.Append(whiteSpaces);
            for (int h = 0; h < dimentionX; h++)
                textBuilder.Append($"+{string.Join("-", new string[cellWidth + 1])}");
            textBuilder.Append("+\n");

            string footerX = whiteSpaces;

            for (int i = 0; i < dimentionX; i++)
            {
                var lengthX = i.ToString().Length;
                var startX = (int)Math.Floor((double)(cellWidth - lengthX) / 2);
                var finishX = cellWidth - (startX + lengthX);

                footerX += $"{string.Join(" ", new string[startX + 2])}{i}{string.Join(" ", new string[finishX + 1])}";
            }
            textBuilder.AppendLine(footerX);

            textBuilder.Append("\n\n");

            foreach (var rover in plateau.Rovers)
            {
                textBuilder.AppendLine(rover.Position.ToString());
            }


            result.ResponseObject = textBuilder.ToString();
            textBuilder = null;
            result.SetStatusSucceeded("Transaction succeed.");
            return result;
        }
    }
}
