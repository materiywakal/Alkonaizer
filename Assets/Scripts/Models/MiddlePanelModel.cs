using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePanelModel : MonoBehaviour
{
    public int ActiveTabId { get; set; }
    
    [SerializeField]
    public PeopleModel People { get; set; }
    [SerializeField]
    public List<AlchoholModel> Alchohol { get; set; }

    private void Start()
    {
        ActiveTabId = 1;
        Alchohol = new List<AlchoholModel>();
    }
}
