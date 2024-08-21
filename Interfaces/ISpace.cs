using ThemisEngine.EngineUtil;

namespace ThemisEngine.Interfaces
{
    public interface ISpace : IPaintable, IUpdatable
    {
        string SpaceTitle { get; }

        string ID { get; set; }

        void Initialize(Engine engine);
    }
}
