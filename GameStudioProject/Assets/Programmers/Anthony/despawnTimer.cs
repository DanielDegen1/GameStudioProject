using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawnTimer : MonoBehaviour
{
    public float DespawnTime = 5;
    public bool DoNotDestroy = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (DoNotDestroy == false)
        {
            DespawnTime -= Time.deltaTime;

            if (DespawnTime < 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Do Not Destroy"))
        {
            DoNotDestroy = true;
        }
    }

}
