using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] float points = 100;
    [SerializeField] AudioClip hit;
    AudioSource ad;
    Animator ani;
    GameManger GM;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        GM = GameManger.Instance;
        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponent<DistractableHolder>() && !collision.gameObject.GetComponent<Destructible>())
        {
            ad.PlayOneShot(hit);
            Destroy(gameObject, 5f);
            ani.SetTrigger("DestroyBox");
            GM.AddScore(points);

        }
       
    }
}
