using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BedrottGameManager01.Instance.GameOver();
        }
    }
}
