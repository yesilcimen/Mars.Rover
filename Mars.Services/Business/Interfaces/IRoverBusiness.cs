namespace Mars.Services
{
    internal interface IRoverBusiness
    {
        IRoverDto Create(IPlateauDto plateau, string roverPositionText);
        void Explore(IRoverDto rover, string commandText);
    }
}
