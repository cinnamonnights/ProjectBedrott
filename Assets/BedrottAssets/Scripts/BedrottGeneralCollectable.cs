using UnityEngine;

public class BedrottGeneralObjective : MonoBehaviour
{
    void Start()
    {
        BedrottGameManager01.Instance.RegisterObjective();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        if (BedrottGameManager01.Instance != null)
        {
            BedrottGameManager01.Instance.ObjectiveCollected();
        }
    }
}
