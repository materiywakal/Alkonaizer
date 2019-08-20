using UnityEngine;
using UnityEngine.UI;

public class CheckBoxScript : MonoBehaviour
{
    public GameObject Toggle;

    public void ChangeOtherToggle()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            Toggle.GetComponent<Toggle>().isOn = false;
        }
    }
}
