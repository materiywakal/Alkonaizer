using System;
using UnityEngine;
using UnityEngine.UI;

public class PeopleDialogScript : MonoBehaviour
{
    public PeopleModel People;

    [SerializeField] public GameObject MCheckBox;
    [SerializeField] public GameObject HeightInput;
    [SerializeField] public GameObject WeightInput;

    private void Start()
    {
        People = new PeopleModel();
    }

    private void LoadModel()
    {
        // Take PeopleModel from logical entity
    }

    public void Save()
    {
        // Send PeopleModel to logical entity

        DestroySelf();
    }

    public void ParseHeight()
    {
        float height = Single.Parse(HeightInput.GetComponent<InputField>().text.Replace('.', ','));
        if (height >= 30 && height <= 300)
        {
            People.Height = height;
        }
        else
        {
            HeightInput.GetComponent<InputField>().text = null;
        }
    }

    public void ParseWeight()
    {
        float weight = Single.Parse(WeightInput.GetComponent<InputField>().text.Replace('.', ','));
        if (weight >= 20 && weight <= 300)
        {
            People.Weight = weight;
        }
        else
        {
            WeightInput.GetComponent<InputField>().text = null;
        }
    }

    public void ParseGender()
    {
        People.IsMale = MCheckBox.GetComponent<Toggle>().isOn;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
