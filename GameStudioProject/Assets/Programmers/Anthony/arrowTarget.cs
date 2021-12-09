using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowTarget : MonoBehaviour
{
    //create for each obstacle type
    targetTempPlatform tempplatform;
    targetMovingPlat movingplatform;

    public GameObject linkedObstacle;
    private bool targethit = false;
    public AudioClip targetHit;
    public float Volume = 1.0f;
    public GameObject audioSource;
    private AudioSource sourceRef;
    // Start is called before the first frame update
    void Start()
    {
        sourceRef = audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targethit == true && linkedObstacle.tag=="temp")
        {
            Play();
            tempplatform = linkedObstacle.GetComponent<targetTempPlatform>();
            tempplatform.active = true;
        }

        if (targethit == true && linkedObstacle.tag == "moving")
        {
            Play();
            movingplatform = linkedObstacle.GetComponent<targetMovingPlat>();
            movingplatform.active = true;
        }

        if(targethit == true && linkedObstacle.tag == "Blockade")
        {
            Play();
            Destroy(linkedObstacle);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Debug.Log("hit");
            targethit = true;
        }
    }
    public void Play()
    {
        Debug.Log("Target hit audio should play");
        sourceRef.PlayOneShot(targetHit, Volume);
    }

    public void Stop()
    {
        this.GetComponent<AudioSource>().Stop();
    }

}
