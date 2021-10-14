using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private PlayerController playerController;

    public GameObject bow;
    public GameObject arrow;
    public Transform bowParent;
    public Transform arrowParent;

    public int animIndex;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAnim(int index)
    {
        anim.SetInteger("State", index);
    }

    public void SpawnBowandArrow() {
        Instantiate(bow, bowParent);
        Instantiate(arrow, arrowParent);
    }

    public void DeleteArrow() {
        Destroy(arrow);
    }

    public void DeleteBow(){
        Destroy(bow);
    }
}
