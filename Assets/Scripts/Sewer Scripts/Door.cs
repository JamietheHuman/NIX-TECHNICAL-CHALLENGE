using UnityEngine;

public class Door : MonoBehaviour
{
    [field: SerializeField]
    private Door PairedRoom;

    public static Door NextRoom;


    private void OnTriggerEnter(Collider other)
    {
        NextRoom = PairedRoom;
    }
}
