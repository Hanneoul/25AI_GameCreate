using UnityEngine;
using UnityEngine.UIElements;

public class PlayerContoller : MonoBehaviour
{
    float start_point = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_point++;
        transform.position = new Vector3(start_point, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        start_point= start_point - 0.005f;
        transform.position = new Vector3(start_point, transform.position.y, transform.position.z);
    }
}
