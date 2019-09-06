using System;

[Serializable]
public class AlchoholModel
{
    public string Title;
    public float Volume;
    public float Percentage;

    public AlchoholModel()
    {
        Title = null;
        Volume = 0;
        Percentage = 0;
    }

    public AlchoholModel(string title, float? volume, float? percentage)
    {
        Title = title ?? "unknow";
        Volume = volume ?? 0;
        Percentage = percentage ?? 0;
    }

    public AlchoholModel(AlchoholModel model)
    {
        Title = model.Title;
        Volume = model.Volume;
        Percentage = model.Percentage;
    }
}
