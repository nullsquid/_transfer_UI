using UnityEngine;
using UnityEditor;

public class MemoryDataAsset {
    [MenuItem("Assets/Create/MemoryData")]
    public static void CreateAsset() {
        ScriptableObjectUtility.CreateAsset<MemoryData>();
    }
}
