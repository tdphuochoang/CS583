using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAnimation : MonoBehaviour
{
    public Animator recoil;
    public ParticleSystem explosion;
    float previousTime;
    // Start is called before the first frame update
    void Start()
    {
        recoil.GetComponent<Animator>();
        previousTime = -1.8F;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(playAnimation());
    }

    IEnumerator playAnimation()
    {
        if(Input.GetKeyDown("space") && ((Time.time - previousTime) > 1.8F))
        {
            previousTime = Time.time;
            recoil.SetBool("Shooting", true);
            explosion.Play();
            yield return new WaitForSeconds(1);
            recoil.SetBool("Shooting", false);
            
        }
    }
}
