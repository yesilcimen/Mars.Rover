using Mars.Core;

namespace Mars.Model
{
    public enum Command
    {
        [Information(Value = "L")]
        Left,
        [Information(Value = "R")]
        Right,
        [Information(Value = "M")]
        Move
    }
}
