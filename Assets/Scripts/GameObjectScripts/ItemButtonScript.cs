using UnityEngine;
using UnityEngine.UI;

public class ItemButtonScript : MonoBehaviour
{
    public AlchoholModel Alchohol;

    [SerializeField] public GameObject Title;

    public void SetupTitle()
    {
        Title.GetComponent<Text>().text = Alchohol.Title;
    }

    public void DestroySelf()
    {
        Alchohol.Volume = 0;
        Alchohol.Percentage = 0;

        //Updating calculations
        GameObject.Find("TopPanel").GetComponent<StateCalculationScript>().UpdateState();

        Destroy(gameObject);
    }
}
