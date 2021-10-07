using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

[System.Serializable]
public class SaveData
{
    public static SaveData Deserialize(string json)
    {
        JsonReader jsonReader = new JsonReader(json);
        return JsonMapper.ToObject<SaveData>(jsonReader);
    }

    public static string Serialize(SaveData saveData)
    {
        return JsonMapper.ToJson(saveData);
    }

    public PersonalityData PersonalityData;

    public SaveData()
    {
        PersonalityData = new PersonalityData();
    }


}
