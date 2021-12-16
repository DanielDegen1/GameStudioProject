using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorBucket : MonoBehaviour
{
    [SerializeField]
    private bool redcheck;
    [SerializeField]
    private bool bluecheck;
    [SerializeField]
    private bool orangecheck;
    [SerializeField]
    private bool greencheck;

    public GameObject endDoor;

    public AudioClip bucketFilled;
    public float Volume = 1.0f;
    public GameObject audioSource;
    private AudioSource sourceRef;
    // Start is called before the first frame update
    void Start()
    {
        sourceRef = audioSource.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (redcheck==true && bluecheck == true && orangecheck == true && greencheck==true )
        {
            Debug.Log("door");
            Play();
            Destroy(endDoor);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "red")
        {
            Debug.Log("red!");
            redcheck = true;
        }
        if (other.tag == "blue")
        {
            Debug.Log("blue!");
            bluecheck = true;
        }
        if (other.tag == "orange")
        {
            Debug.Log("orange!");
            orangecheck = true;
        }
        if (other.tag == "green")
        {
            Debug.Log("green!");
            greencheck = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "red")
        {
            Debug.Log("red!");
            redcheck = true;
        }
        if (other.tag == "blue")
        {
            Debug.Log("blue!");
            bluecheck = true;
        }
        if (other.tag == "orange")
        {
            Debug.Log("orange!");
            orangecheck = true;
        }
        if (other.tag == "green")
        {
            Debug.Log("green!");
            greencheck = true;
        }
    }
    public void Play()
    {
        Debug.Log("bucket audio should play");
        sourceRef.PlayOneShot(bucketFilled, Volume);
    }

    public void Stop()
    {
        this.GetComponent<AudioSource>().Stop();
    }
}
