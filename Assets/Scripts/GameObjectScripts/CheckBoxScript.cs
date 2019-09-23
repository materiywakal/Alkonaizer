using UnityEngine;
using UnityEngine.UI;

public class CheckBoxScript : MonoBehaviour
{
    public GameObject Toggle;

    public void ChangeOtherToggle()
    {
        Toggle.GetComponent<Toggle>().isOn = !gameObject.GetComponent<Toggle>().isOn;
    }
}
