using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateCalculationScript : MonoBehaviour
{
    [SerializeField] public GameObject Container;
    [SerializeField] public GameObject TextObject;
    [SerializeField] public GameObject AlchoholButton;

    private PeopleModel People;
    private List<AlchoholModel> AlchoholList;
    private DataSaveScript DataSaver;

    private void Start()
    {
        Debug.Log("start");
        DataSaver = new DataSaveScript();
        DataSaver.DeserializeData();

        People = DataSaver.People;
        if(People == null)
            People = new PeopleModel();

        AlchoholList = DataSaver.AlchoholList;
        if (AlchoholList == null)
            AlchoholList = new List<AlchoholModel>();

        InstantiateAlchohol();

        Calculate();
    }

    public PeopleModel GetPeople()
    {
        return People;
    }

    public void SetPeople(PeopleModel people)
    {
        People = people;
    }

    public void UpdateState()
    {
        AlchoholList = new List<AlchoholModel>();
        foreach (var item in Container.GetComponentsInChildren<ItemButtonScript>())
        {
            AlchoholList.Add(item.Alchohol);
        }

        DataSaver.SerializeData(People);
        DataSaver.SerializeData(AlchoholList);

        Calculate();
    }

    private void InstantiateAlchohol()
    {
        GameObject button;
        foreach (var alchohol in AlchoholList)
        {
            button = Instantiate(AlchoholButton, Container.transform);
            button.GetComponent<ItemButtonScript>().Alchohol.Title = alchohol.Title;
            button.GetComponent<ItemButtonScript>().Alchohol.Volume = alchohol.Volume;
            button.GetComponent<ItemButtonScript>().Alchohol.Percentage = alchohol.Percentage;
            button.GetComponent<ItemButtonScript>().SetupTitle();
            button.transform.SetAsFirstSibling();
        }
    }

    private void Calculate()
    {
        float C = 0;
        foreach (var alchohol in AlchoholList)
        {
            C += (alchohol.Volume * (alchohol.Percentage / 100) * HeightCoefficient()) /
                 (People.Weight * GenderCoefficient());
        }

        TextObject.GetComponent<Text>().text = StringResult(C);
    }

    private string StringResult(float C)
    {
        if (C <= 0.5f)
        {
            return "No cause";
        }
        else if (C > 0.5f && C <= 1.5f)
        {
            return "Easy";
        }
        else if (C > 1.5f && C <= 2)
        {
            return "Medium";
        }
        else if (C > 2 && C <= 3)
        {
            return "Hard";
        }
        else if (C > 3 && C < 5)
        {
            return "Hard intoxication";
        }
        else
        {
            return "Lethal intoxication";
        }
    }

    private float HeightCoefficient()
    {
        if (People.Height <= 140)
        {
            return 1;
        }
        else if (People.Height > 140 && People.Height <= 160)
        {
            return 0.9f;
        }
        else if (People.Height > 160 && People.Height <= 180)
        {
            return 0.8f;
        }
        else
        {
            return 0.75f;
        }
    }

    private float GenderCoefficient()
    {
        if (People.IsMale)
        {
            return 0.7f;
        }
        else
        {
            return 0.6f;
        }
    }
}