namespace Mars.Services
{
    public interface IPlateauService
    {
        TransactionResult<IPlateauDto> Create(string widthHeightText);
        TransactionResult<string> DisplayText(IPlateauDto plateau);
    }
}
