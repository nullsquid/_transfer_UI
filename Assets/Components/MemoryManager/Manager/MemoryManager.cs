using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryManager : MonoBehaviour {

    public static MemoryManager instance;
    void Awake() {

        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public List<MemoryData> AMemories = new List<MemoryData>();
    public List<MemoryData> BMemories = new List<MemoryData>();
    public List<MemoryData> CMemories = new List<MemoryData>();
    public List<MemoryData> DMemories = new List<MemoryData>();
    public List<MemoryData> EMemories = new List<MemoryData>();
    public List<MemoryData> FMemories = new List<MemoryData>();
    public List<MemoryData> GMemories = new List<MemoryData>();
    public List<MemoryData> HMemories = new List<MemoryData>();
    public List<MemoryData> IMemories = new List<MemoryData>();
    public List<MemoryData> ZMemories = new List<MemoryData>();

    private void Start() {
        
    }
}
