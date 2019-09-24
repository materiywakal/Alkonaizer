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
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameObject obj = GameObject.Find("TopPanel");
        if (obj != null)
        {
            obj.GetComponent<StateCalculationScript>().UpdateState();
        }
    }
}