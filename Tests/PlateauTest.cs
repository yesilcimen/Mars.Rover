using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mars.Services;

namespace Tests
{
    [TestClass]
    public class PlateauTest
    {
        private IPlateauDto plateauDto;

        [TestInitialize]
        public void Initialize()
        {
            plateauDto = null;
        }

        [TestMethod("Create Plateau")]
        [DataRow("5 5", DisplayName = "Plateau width and height")]
        public void IsPlateauCreate(string plateauSizeText)
        {
            var plateauServiceResult = PlateauService.Current.Create(plateauSizeText);
            plateauDto = plateauServiceResult.ResponseObject;
            Assert.IsTrue(plateauServiceResult.IsSuccess, plateauServiceResult.Message);
        }

        [TestMethod("Create Plateau Display Text")]
        public void IsDisplayTextCreate()
        {
            IsPlateauCreate("5 5");
            var plateauServiceResult = PlateauService.Current.DisplayText(plateauDto);
            Assert.IsTrue(plateauServiceResult.IsSuccess, plateauServiceResult.Message);
            Assert.IsFalse(string.IsNullOrWhiteSpace(plateauServiceResult.ResponseObject), "Display text is empty or null");
        }

        [TestMethod("Validation Plateau")]
        [DataRow("55", DisplayName = "Plateau width and height wrong!")]
        public void HandleValidationException(string plateauSizeText)
        {
            var plateauServiceResult = PlateauService.Current.Create(plateauSizeText);
            Assert.IsFalse(plateauServiceResult.IsSuccess, plateauServiceResult.Message);
            Assert.AreEqual(plateauServiceResult.Message, $"{plateauSizeText} is not matched.");
        }
    }
}
