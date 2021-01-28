namespace Mars.Services
{
    public interface IRoverService
    {
        TransactionResult<IRoverDto> Create(IPlateauDto plateau, string roverPositionText);
        TransactionResult Explore(IRoverDto rover, string commandText);

    }
}
