using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character : MonoBehaviour
{
    public int health;
    [Header("Projectile")]
    public float fireRate = 1f;
    public float projectileSpeed;
    public GameObject projectile;

    [Header("Swordplay")]
    public float swingRate = 1f;
    public float swordSpeed;
    public GameObject sword;


    [Header("Movement")]
    public float moveSpeed = 0f;
    public float jumpHeight = 0f;
    public Rigidbody2D rb;
    public Animator animator;
    //[HideInInspector]
    public bool jumping;

    [Header("Sound Effects")]
    public AudioSource audioSource;
    public AudioClip fireSound, jumpsound, swingSound;
    System.DateTime timeFired, fireNow;
    System.DateTime timeSwung, swingNow;
    private void Start()
    {
        timeFired = System.DateTime.Now;
        timeSwung = System.DateTime.Now;
    }
    public void Fire()
    {
        // Check if enough time has passed to fire again
        fireNow = System.DateTime.Now;
        if (fireNow.Subtract(timeFired).TotalSeconds > 1 / fireRate)
        {
            audioSource.PlayOneShot(fireSound);
            GameObject bullet = GameObject.Instantiate(projectile);
            bullet.SetActive(true);
            bullet.transform.position = projectile.transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = projectileSpeed *
               Vector3.left * this.transform.localScale.x;
            // Set time fired so we don't shoot again
            timeFired = fireNow;

        }
    }
    public void Swing()
    {
        // Check if enough timem has passed to swing again
        swingNow = System.DateTime.Now;
        if (swingNow.Subtract(timeSwung).TotalSeconds > 1/ swingRate)
        {
            audioSource.PlayOneShot(swingSound);
            //TODO: swing the sword

            timeSwung = swingNow;
        }
    }
}