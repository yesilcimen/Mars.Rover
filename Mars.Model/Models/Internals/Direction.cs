namespace Mars.Model
{
    internal class Direction : IDirection
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public int Angle { get; set; }
        public int AxisY { get; set; }
        public int AxisX { get; set; }
    }
}
