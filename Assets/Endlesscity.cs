using UnityEngine;

public class Endlesscity : MonoBehaviour
{
    public Transform city1;
    public Transform city2;
    public Transform player;

    public float cityLength = 96f;

    void Update()
    {
        if (player.position.z < city2.position.z - cityLength)
        {
            city1.position = new Vector3(
                city1.position.x,
                city1.position.y,
                city2.position.z + cityLength
            );
        }

        if (player.position.z < city1.position.z - cityLength)
        {
            city2.position = new Vector3(
                city2.position.x,
                city2.position.y,
                city1.position.z + cityLength
            );
        }
    }
}