using UnityEngine;

public class DiscardButtonScript : MonoBehaviour
{
    public GameObject ToDiscard;

    public void Discard()
    {
        Destroy(ToDiscard);
    }
}
