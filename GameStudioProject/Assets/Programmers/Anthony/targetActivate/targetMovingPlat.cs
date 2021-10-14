using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetMovingPlat : MonoBehaviour
{
    public bool active = false;
    public bool switchDir = false;
    float timer = 5;
    float timerReset = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                switchDir = !switchDir;
                timer = timerReset;
            }

            if (switchDir == true)
            {
                Debug.Log("FfF");
                transform.Translate(Vector3.forward * Time.deltaTime);
            }
            if (switchDir == false)
            {
                Debug.Log("BBBB");
                transform.Translate(Vector3.back * Time.deltaTime);
            }
        }
      
    }
}
