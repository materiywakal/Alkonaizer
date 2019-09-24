using System;
using UnityEngine;
using UnityEngine.UI;

public class PeopleDialogScript : MonoBehaviour
{
    private PeopleModel People;

    [SerializeField] public GameObject MCheckBox;
    [SerializeField] public GameObject FCheckBox;
    [SerializeField] public GameObject HeightInput;
    [SerializeField] public GameObject HeightInputName;
    private bool HeightCheck = true;
    [SerializeField] public GameObject WeightInput;
    [SerializeField] public GameObject WeightInputName;
    private bool WeightCheck = true;

    private void Start()
    {
        People = GameObject.Find("TopPanel").GetComponent<StateCalculationScript>().GetPeople();
        if (People == null)
            People = new PeopleModel();

        if (People.IsMale)
        {
            MCheckBox.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            FCheckBox.GetComponent<Toggle>().isOn = true;
        }

        if (People.Height != 0)
            HeightInput.GetComponent<InputField>().text = People.Height.ToString();
        if (People.Weight != 0)
            WeightInput.GetComponent<InputField>().text = People.Weight.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DestroySelf();
        }
    }

    public void Save()
    {
        if (CheckValues())
        {
            GameObject topPanel = GameObject.Find("TopPanel");

            topPanel.GetComponent<StateCalculationScript>().SetPeople(People);
            
            topPanel.GetComponent<StateCalculationScript>().UpdateState();

            DestroySelf();
        }
    }

    public void ParseHeight()
    {
        float height = 0;
        if (Single.TryParse(HeightInput.GetComponent<InputField>().text.Replace('.', ','), out height) &&
            height >= 30 && height <= 300)
        {
            People.Height = height;
            HeightCheck = true;
        }
        else
        {
            HeightInput.GetComponent<InputField>().text = null;
            HeightCheck = false;
        }
    }

    public void ToggleHeightInputName()
    {
        string height = HeightInput.GetComponent<InputField>().text;
        if (height != null && height != "")
        {
            HeightInputName.SetActive(true);
        }
        else
        {
            HeightInputName.SetActive(false);
        }
    }

    public void ParseWeight()
    {
        float weight = 0;
        if (Single.TryParse(WeightInput.GetComponent<InputField>().text.Replace('.', ','), out weight) &&
            weight >= 20 && weight <= 300)
        {
            People.Weight = weight;
            WeightCheck = true;
        }
        else
        {
            WeightInput.GetComponent<InputField>().text = null;
            WeightCheck = false;
        }
    }

    public void ToggleWeightInputName()
    {
        string weight = WeightInput.GetComponent<InputField>().text;
        if (weight != null && weight != "")
        {
            WeightInputName.SetActive(true);
        }
        else
        {
            WeightInputName.SetActive(false);
        }
    }

    public void ParseGender()
    {
        People.IsMale = MCheckBox.GetComponent<Toggle>().isOn;
    }

    private bool CheckValues()
    {
        return HeightCheck && WeightCheck;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}