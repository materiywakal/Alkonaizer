using System;
using UnityEngine;
using UnityEngine.UI;

public class AlchoholDialogScript : MonoBehaviour
{
    public AlchoholModel Alchohol;
    
    [SerializeField] public GameObject VolumeInput;
    [SerializeField] public GameObject PercentageInput;

    private void Start()
    {
        Alchohol = new AlchoholModel();
    }

    private void LoadModel()
    {
        // Take AlchoholModel from logical entity
    }

    public void Save()
    {
        // Send AlchoholModel to logical entity

        DestroySelf();
    }

    public void ParseVolume()
    {
        float volume = Single.Parse(VolumeInput.GetComponent<InputField>().text.Replace('.', ','));
        if (volume >= 0)
        {
            Alchohol.Volume = volume;
        }
        else
        {
            VolumeInput.GetComponent<InputField>().text = null;
        }
    }

    public void ParsePercentage()
    {
        float percentage = Single.Parse(PercentageInput.GetComponent<InputField>().text.Replace('.', ','));
        if (percentage >= 0 && percentage <= 100)
        {
            Alchohol.Percentage = percentage;
        }
        else
        {
            PercentageInput.GetComponent<InputField>().text = null;
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
