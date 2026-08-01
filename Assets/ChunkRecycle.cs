using UnityEngine;

public class ChunkRecycle : MonoBehaviour
{
    public Transform chunkToMove;
    public float chunkLength = 95.8f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Hit");
        if (other.CompareTag("Player"))
        {
            chunkToMove.position = new Vector3(
    chunkToMove.position.x,
    chunkToMove.position.y,
    chunkToMove.position.z - (chunkLength * 2)
);
        }
    }
}