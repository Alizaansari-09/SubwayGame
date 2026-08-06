using UnityEngine;

public class PoliceMovement : MonoBehaviour
{
    public float speed = 15f;
    public float runTime = 10f;

    private float timer;

    void Update()
    {
        if (timer < runTime)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            timer += Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}