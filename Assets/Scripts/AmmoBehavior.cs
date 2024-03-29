using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehavior : MonoBehaviour
{
    public float invTime = .1f;
    public float lifeAfterCollision = 5f;
    public ParticleSystem explosionPrefab = null;
    float lifeTime = 0f;
    bool collided = false;
    public AudioClip explosionSound = null;
    AudioSource audioSource = null;
    

    // Start is called before the first frame update
    void Start()
    {
        explosionPrefab.Stop();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if( collided && lifeTime >lifeAfterCollision)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(lifeTime > invTime) 
        {
            lifeTime = 0f;
            collided = true;
            explosionPrefab.Play();
            audioSource.PlayOneShot(explosionSound);
            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            /*
            transform.DetachChildren();
            Destroy(gameObject);
            */
        }
    }
}
