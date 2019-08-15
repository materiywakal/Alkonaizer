using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject DialogPrefab;

    [SerializeField]
    private Transform DialogParent;


    public void ActivateDialog()
    {
        Instantiate(DialogPrefab, DialogParent);
    }

    
}
