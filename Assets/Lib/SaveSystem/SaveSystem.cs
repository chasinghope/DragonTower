using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public const string saveFileName = "saveData.txt";
    public static SaveSystem Instance;
    public SaveData SaveData;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
            
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveToFile();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SaveData.PersonalityData.R8_weight++;
        }
    }

    public void Init()
    {
        //实例化存档实例
        LoadFromFile();
    }

    /// <summary>
    /// 从磁盘加载数据， 并执行序列化
    /// </summary>
    /// <returns></returns>
    public string LoadFromFile()
    {
        string data = null;
        string filePath = Path.Combine(Application.dataPath, "Resources/" + saveFileName);
        if (File.Exists(filePath))
        {
            data = File.ReadAllText(filePath);
            this.SaveData = SaveData.Deserialize(data);
        }
        else
        {
            File.Create(filePath);
            this.SaveData = new SaveData();
        }
        return data;
    }


    /// <summary>
    /// 反序列化文件， 保存数据至磁盘
    /// </summary>
    public void SaveToFile()
    {
        string jsonData = SaveData.Serialize(this.SaveData);
        if (string.IsNullOrEmpty(jsonData))
            return;

        string filePath = Path.Combine(Application.dataPath, "Resources/" + saveFileName);
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }

        File.WriteAllText(filePath, jsonData);

    }

    

}
