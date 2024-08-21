using ThemisEngine.Interfaces;

namespace ThemisEngine.EngineUtil
{
    public class GameEngineState
    {
        public Dictionary<string, ISpace> Spaces = [];
        public string ActiveSpace = "";
        public string? NextActiveSpace = null;
    }
}
