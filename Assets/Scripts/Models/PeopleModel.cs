using System;

[Serializable]
public class PeopleModel
{
    public bool IsMale;
    public float Height;
    public float Weight;

    public PeopleModel()
    {
        IsMale = true;
        Height = 0;
        Weight = 0;
    }

    public void Setup(bool? isMale, float? height, float? weight)
    {
        IsMale = isMale ?? IsMale;
        Height = height ?? Height;
        Weight = weight ?? Weight;
    }
}
