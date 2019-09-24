using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSaveScript
{
    public PeopleModel People;
    public List<AlchoholModel> AlchoholList;

    private string PeopleFilePath;
    private string AlchoholFilePath;

    public DataSaveScript()
    {
        PeopleFilePath = Path.Combine(Application.persistentDataPath, "PeopleData.json");
        AlchoholFilePath = Path.Combine(Application.persistentDataPath, "AlchoholData.json");
    }

    public void SerializeData(PeopleModel people)
    {
        string jsonDataString = JsonUtility.ToJson(people, true);

        File.WriteAllText(PeopleFilePath, jsonDataString);
    }

    public void SerializeData(List<AlchoholModel> alchohol)
    {
        AlchoholList list = new AlchoholList();
        list.Container = alchohol;

        string jsonDataString = JsonUtility.ToJson(list, true);

        File.WriteAllText(AlchoholFilePath, jsonDataString);
    }

    public void DeserializeData()
    {
        try
        {
            string peopleJsonDataString = File.ReadAllText(PeopleFilePath);
            People = JsonUtility.FromJson<PeopleModel>(peopleJsonDataString);
        }
        catch
        {
            People = null;
        }

        try
        {
            string alchoholJsonDataString = File.ReadAllText(AlchoholFilePath);
            AlchoholList list = JsonUtility.FromJson<AlchoholList>(alchoholJsonDataString);
            AlchoholList = list.Container;
            AlchoholList.Reverse();
        }
        catch
        {
            AlchoholList = null;
        }
    }
}

[SerializeField]
public class AlchoholList
{
    public List<AlchoholModel> Container;
}