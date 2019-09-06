using System;
using UnityEngine;
using UnityEngine.UI;

public class AlchoholDialogScript : MonoBehaviour
{
    private AlchoholModel Alchohol;

    public GameObject Entity;

    [SerializeField] public GameObject TitleInput;
    private bool TitleCheck = false;

    [SerializeField] public GameObject VolumeInput;
    private bool VolumeCheck = false;

    [SerializeField] public GameObject PercentageInput;
    private bool PercentageCheck = false;

    [SerializeField] public GameObject AlchoholButton;

    private void Start()
    {
        if (Entity != null)
        {
            Alchohol = Entity.GetComponent<ItemButtonScript>().Alchohol;
            TitleInput.GetComponent<InputField>().text = Alchohol.Title;
            VolumeInput.GetComponent<InputField>().text = Alchohol.Volume.ToString();
            PercentageInput.GetComponent<InputField>().text = Alchohol.Percentage.ToString();
            TitleCheck = VolumeCheck = PercentageCheck = true;
        }
        else
        {
            Alchohol = new AlchoholModel();
        }
    }

    public void Save()
    {
        // Send AlchoholModel to logical entity
        if(!CheckValues())
            return;

        GameObject button;
        if (Entity != null)
        {
            button = Entity;
        }
        else
        {
            button = Instantiate(AlchoholButton, GameObject.Find("AddButton").transform.parent.transform);
            button.GetComponent<ItemButtonScript>().Alchohol.Title = Alchohol.Title;
            button.GetComponent<ItemButtonScript>().Alchohol.Volume = Alchohol.Volume;
            button.GetComponent<ItemButtonScript>().Alchohol.Percentage = Alchohol.Percentage;
        }
        button.GetComponent<ItemButtonScript>().SetupTitle();
        button.transform.SetAsFirstSibling();

        //Updating calculations
        GameObject.Find("TopPanel").GetComponent<StateCalculationScript>().UpdateState();

        DestroySelf();
    }

    public void ParseTitle()
    {
        string title = TitleInput.GetComponent<InputField>().text;
        if (title != null && title != "")
        {
            Alchohol.Title = title;
            TitleCheck = true;
        }
        else
        {
            TitleInput.GetComponent<InputField>().text = null;
            TitleCheck = false;
        }
    }

    public void ParseVolume()
    {
        float volume = 0;
        if(Single.TryParse(VolumeInput.GetComponent<InputField>().text.Replace('.', ','),out volume) && volume > 0)
        {
            Alchohol.Volume = volume;
            VolumeCheck = true;
        }
        else
        {
            VolumeInput.GetComponent<InputField>().text = null;
            VolumeCheck = false;
        }
    }

    public void ParsePercentage()
    {
        float percentage = 0;
        if (Single.TryParse(PercentageInput.GetComponent<InputField>().text.Replace('.', ','), out percentage) 
            && percentage > 0 && percentage <= 100)
        {
            Alchohol.Percentage = percentage;
            PercentageCheck = true;
        }
        else
        {
            PercentageInput.GetComponent<InputField>().text = null;
            PercentageCheck = false;
        }
    }

    public bool CheckValues()
    {
        return TitleCheck && VolumeCheck && PercentageCheck;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
