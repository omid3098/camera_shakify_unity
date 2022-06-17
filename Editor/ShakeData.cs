using System.Collections.Generic;
namespace Shakfy.Editor
{
    [System.Serializable]
    public class ShakeData
    {
        public List<ShakeDataEntry> entries = new List<ShakeDataEntry>();
    }

    [System.Serializable]
    public class ShakeDataEntry
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float FPS { get; set; }
        public Dictionary<int, float> PosX { get; set; }
        public Dictionary<int, float> PosY { get; set; }
        public Dictionary<int, float> PosZ { get; set; }
        public Dictionary<int, float> RotX { get; set; }
        public Dictionary<int, float> RotY { get; set; }
        public Dictionary<int, float> RotZ { get; set; }
    }

    [System.Serializable]
    public struct KeyFrame
    {
        public int Frame { get; set; }
        public float Value { get; set; }
    }
}