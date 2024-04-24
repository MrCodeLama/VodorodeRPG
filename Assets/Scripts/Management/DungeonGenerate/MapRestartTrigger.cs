using UnityEngine;

public class MapRestartTrigger : MonoBehaviour
{
    public AbstractDungeonGenerator dungeonGenerator; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dungeonGenerator.GenerateDungeon();
        }
    }
}