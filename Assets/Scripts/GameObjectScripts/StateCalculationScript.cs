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
        DataSaver = new DataSaveScript();
        DataSaver.DeserializeData();

        People = DataSaver.People;
        if (People == null)
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
        int statePercentage = PercentageOfState(C);

        if (C <= 0.5f)
        {
            return "Трезвость (" + statePercentage + "%)";
        }
        else if (C > 0.5f && C <= 1.5f)
        {
            return "Легкое опьянение (" + statePercentage + "%)";
        }
        else if (C > 1.5f && C <= 2)
        {
            return "Среднее опьянение (" + statePercentage + "%)";
        }
        else if (C > 2 && C <= 3)
        {
            return "Сильное опьянение (" + statePercentage + "%)";
        }
        else if (C > 3 && C < 5)
        {
            return "Отравление (" + statePercentage + "%)";
        }
        else
        {
            return "Смерть (" + statePercentage + "%)";
        }
    }

    private int PercentageOfState(float C)
    {
        if (C <= 0.5f)
        {
            return (int) (C * 100f / 0.5f);
        }
        else if (C > 0.5f && C <= 1.5f)
        {
            return (int) ((C - 0.5f) * 100);
        }
        else if (C > 1.5f && C <= 2)
        {
            return (int) ((C - 1.5f) * 100f / 0.5f);
        }
        else if (C > 2 && C <= 3)
        {
            return (int) ((C - 2f) * 100f);
        }
        else if (C > 3 && C < 5)
        {
            return (int) ((C - 3f) * 100f / 2f);
        }
        else
        {
            return (int) ((C - 5f) * 100f / 5f + 100f);
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