using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 10;
    public int currentHealth;

    public bool enemyTakesDamage;

    public bool enemyDeath;

    public AudioSource bossBackGroundSound;

    public AudioSource winSound;

    //Split enemy death
    float randomX;
    float randomZ;
    public Transform trans;
    public Transform spawnTrans;
    public GameObject smallerEnemy;
    public GameObject bossCube;
    private Vector3 scale1;
    private Vector3 scale2;
    private Vector3 scale3;

    void Start()
    {
        currentHealth = maxHealth;
        enemyTakesDamage = false;
        enemyDeath = false;

        bossBackGroundSound.Play();

        // Gets a random point to set at the cubes position when it spawns new cubes
        randomX = Random.Range(5f, 15f);
        randomZ = Random.Range(10f, 20f);
        spawnTrans.position = trans.position + new Vector3(randomX, 0, randomZ);

        //// Sets variables used to chekc the scal of the cube(s)
        scale1 = new Vector3(2f, 2f, 2f);
        scale2 = new Vector3(1f, 1f, 1f);
        scale3 = new Vector3(0.5f, 0.5f, 0.5f);
    }


    public void Update()
    {
        if (currentHealth <= 0)
        {
            enemyDeath = true;
            winSound.Play();
            bossBackGroundSound.Stop();
            //   Destroy(gameObject);

            if (bossCube.transform.localScale == scale1)
            {
                smallerEnemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Instantiate(smallerEnemy, spawnTrans.position, Quaternion.identity);
                Instantiate(smallerEnemy, spawnTrans.position, Quaternion.identity);
                //Destroy(smallerEnemy);
                Destroy(gameObject);

            }
            else if (bossCube.transform.localScale == scale2)
            {
                smallerEnemy.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                Instantiate(smallerEnemy, spawnTrans.position, Quaternion.identity);
                Instantiate(smallerEnemy, spawnTrans.position, Quaternion.identity);
                //Destroy(smallerEnemy);
                Destroy(gameObject);
            }
            else if (bossCube.transform.localScale == scale3)
            {
                Destroy(gameObject);
            }
        }
    }
            
            
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
