using UnityEngine;

public class AddButtonScript : MonoBehaviour
{
    [SerializeField] public GameObject DialogPrefab;

    private Transform DialogParent;

    private void Start()
    {
        DialogParent = GameObject.Find("Canvas").transform;
    }

    public void ActivateDialog()
    {
        GameObject obj = Instantiate(DialogPrefab, DialogParent);
        if (gameObject.GetComponent<ItemButtonScript>() != null)
        {
            obj.GetComponent<AlchoholDialogScript>().Entity = gameObject;
        }
    }
}