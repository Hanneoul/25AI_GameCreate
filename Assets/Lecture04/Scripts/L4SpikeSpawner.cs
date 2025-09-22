using UnityEngine;

public class L4SpikeSpawner : MonoBehaviour
{
    public GameObject SpikePrefab;

    
    float timeTrigger = 0;

    float currentCenter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeTrigger = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeTrigger += Time.deltaTime;

        float center = 0;
        float width = 0;

        bool check = false;

        if (timeTrigger > 0.2)
        {
            while (!check)
            { 
                center = Random.Range(-0.5f, 0.5f);
                width = Random.Range(2.5f, 3f);
                if(currentCenter + center >= -3.3 && currentCenter + center <= 5 )
                {
                    check = true;
                    currentCenter += center;

                    Debug.Log("Spawner : Spike ����");
                    GameObject spike = Instantiate(SpikePrefab);
                    GameObject spike2 = Instantiate(SpikePrefab);

                    spike.transform.position = new(transform.position.x, currentCenter + width);
                    spike2.transform.position = new(transform.position.x, currentCenter - width);
                    timeTrigger = 0;
                }
            }
            check = false;

            
        }
    }
}
