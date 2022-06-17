using UnityEngine;
using NaughtyAttributes;
using Newtonsoft.Json;
using UnityEditor;
using Shakfy.Core;

namespace Shakfy.Editor
{
    [CreateAssetMenu]
    public class ShakeDataReader : ScriptableObject
    {
        private const string NewFolderName = "ShakeTypes";
        [SerializeField] TextAsset jsonFile;
        [Button]
        void Convert()
        {
            // var fakeData = new ShakeData();
            // fakeData.entries.Add(new ShakeDataEntry());
            // fakeData.entries[0].Id = "INVESTIGATION";
            // fakeData.entries[0].Name = "Investigation";
            // fakeData.entries[0].FPS = 24.0f;
            // fakeData.entries[0].PosX = new Dictionary<int, float>(){
            //     {0, 0.0f},
            //     {1, 0.0f},
            //     {2, 0.0f}
            // };
            // fakeData.entries[0].PosY = new Dictionary<int, float>(){
            //     {0, 0.0f},
            //     {1, 0.0f},
            //     {2, 0.0f}
            // };


            // Debug.Log(JsonUtility.ToJson(fakeData));
            // JsonSerializer serializer = new JsonSerializer();
            // var data = JsonUtility.FromJson<ShakeData>(jsonFile.text);
            var data = JsonConvert.DeserializeObject<ShakeData>(jsonFile.text);

            // Create ScriptableShakeData and save it to current folder into a subfolder called "ScriptableShakeData"
            for (int i = 0; i < data.entries.Count; i++)
            {
                ShakeDataEntry firstEntry = data.entries[i];
                var scriptableData = ScriptableObject.CreateInstance<ScriptableShakeData>();
                scriptableData.Id = firstEntry.Id;
                scriptableData.Name = firstEntry.Name;
                scriptableData.FPS = firstEntry.FPS;
                scriptableData.PosX = new AnimationCurve();
                if (firstEntry.PosX != null)
                {
                    foreach (var key in firstEntry.PosX.Keys)
                    {
                        scriptableData.PosX.AddKey(key, firstEntry.PosX[key]);
                    }
                }
                scriptableData.PosY = new AnimationCurve();
                if (firstEntry.PosY != null)
                {
                    foreach (var key in firstEntry.PosY.Keys)
                    {
                        scriptableData.PosY.AddKey(key, firstEntry.PosY[key]);
                    }
                }
                scriptableData.PosZ = new AnimationCurve();
                if (firstEntry.PosZ != null)
                {
                    foreach (var key in firstEntry.PosZ.Keys)
                    {
                        scriptableData.PosZ.AddKey(key, firstEntry.PosZ[key]);
                    }
                }
                scriptableData.RotX = new AnimationCurve();
                if (firstEntry.RotX != null)
                {
                    foreach (var key in firstEntry.RotX.Keys)
                    {
                        scriptableData.RotX.AddKey(key, firstEntry.RotX[key]);
                    }
                }
                scriptableData.RotY = new AnimationCurve();
                if (firstEntry.RotY != null)
                {
                    foreach (var key in firstEntry.RotY.Keys)
                    {
                        scriptableData.RotY.AddKey(key, firstEntry.RotY[key]);
                    }
                }
                scriptableData.RotZ = new AnimationCurve();
                if (firstEntry.RotZ != null)
                {
                    foreach (var key in firstEntry.RotZ.Keys)
                    {
                        scriptableData.RotZ.AddKey(key, firstEntry.RotZ[key]);
                    }
                }
                // Get current asset path
                var path = AssetDatabase.GetAssetPath(this);
                // Get current folder path
                var folderPath = path.Substring(0, path.LastIndexOf("/"));
                var targetFolder = folderPath + "/" + NewFolderName;
                // if folder doesn't exist, create it
                if (!AssetDatabase.IsValidFolder(targetFolder))
                {
                    AssetDatabase.CreateFolder(folderPath, NewFolderName);
                }
                // Save scriptableData to current folder into a subfolder called "ScriptableShakeData"
                AssetDatabase.CreateAsset(scriptableData, targetFolder + "/" + (i + 1) + "-" + scriptableData.Name + ".asset");
                AssetDatabase.SaveAssets();
            }
            // Refresh assets
            AssetDatabase.Refresh();
        }
    }
}