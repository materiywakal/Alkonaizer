using System;
using UnityEngine;
using UnityEngine.UI;

public class AlchoholDialogScript : MonoBehaviour
{
    private AlchoholModel Alchohol;

    public GameObject Entity;

    [SerializeField] public GameObject TitleInput;
    [SerializeField] public GameObject TitleInputName;
    private string TempTitle;
    private bool TitleCheck = false;

    [SerializeField] public GameObject VolumeInput;
    [SerializeField] public GameObject VolumeInputName;
    private float TempVolume;
    private bool VolumeCheck = false;

    [SerializeField] public GameObject PercentageInput;
    [SerializeField] public GameObject PercentageInputName;
    private float TempPercentage;
    private bool PercentageCheck = false;

    [SerializeField] public GameObject AlchoholButton;

    private void Start()
    {
        if (Entity != null)
        {
            Alchohol = Entity.GetComponent<ItemButtonScript>().Alchohol;
            TempTitle = Alchohol.Title;
            TempPercentage = Alchohol.Percentage;
            TempVolume = Alchohol.Volume;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DestroySelf();
        }
    }

    public void Save()
    {
        // Send AlchoholModel to logical entity
        if(!CheckValues())
            return;

        Alchohol.Title = TempTitle;
        Alchohol.Volume = TempVolume;
        Alchohol.Percentage = TempPercentage;

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

        Destroy(gameObject);
    }

    public void ParseTitle()
    {
        string title = TitleInput.GetComponent<InputField>().text;
        if (title != null && title != "")
        {
            TempTitle = title;
            TitleCheck = true;
            TitleInputName.SetActive(true);
        }
        else
        {
            TitleInput.GetComponent<InputField>().text = null;
            TitleCheck = false;
            TitleInputName.SetActive(false);
        }
    }

    public void ToggleTitleInputName()
    {
        string title = TitleInput.GetComponent<InputField>().text;
        if (title != null && title != "")
        {
            TitleInputName.SetActive(true);
        }
        else
        {
            TitleInputName.SetActive(false);
        }
    }

    public void ParseVolume()
    {
        float volume = 0;
        if(Single.TryParse(VolumeInput.GetComponent<InputField>().text, out volume) && volume > 0)
        {
            TempVolume = volume;
            VolumeCheck = true;
        }
        else
        {
            VolumeInput.GetComponent<InputField>().text = null;
            VolumeCheck = false;
        }
    }

    public void ToggleVolumeInputName()
    {
        string volume = VolumeInput.GetComponent<InputField>().text;
        if (volume != null && volume != "")
        {
            VolumeInputName.SetActive(true);
        }
        else
        {
            VolumeInputName.SetActive(false);
        }
    }

    public void ParsePercentage()
    {
        float percentage = 0;
        if (Single.TryParse(PercentageInput.GetComponent<InputField>().text, out percentage) 
            && percentage > 0 && percentage <= 100)
        {
            TempPercentage = percentage;
            PercentageCheck = true;
        }
        else
        {
            PercentageInput.GetComponent<InputField>().text = null;
            PercentageCheck = false;
        }
    }

    public void TogglePercentageInputName()
    {
        string percentage = PercentageInput.GetComponent<InputField>().text;
        if (percentage != null && percentage != "")
        {
            PercentageInputName.SetActive(true);
        }
        else
        {
            PercentageInputName.SetActive(false);
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
