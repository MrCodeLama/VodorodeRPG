using UnityEngine;

public class MapRestartTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<AbstractDungeonGenerator>().GenerateDungeon();
        }
    }
}