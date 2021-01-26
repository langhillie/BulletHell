using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameManager gm;

    [SerializeField]
    public float Health = 20;
    
    [SerializeField]
    private int ScoreValue;

    public void Initialize()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Health -= other.gameObject.GetComponent<Bullet>().damage;
            Destroy(other.gameObject);

            if (Health <= 0)
            {
                gm.EnemyKilled(ScoreValue);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameBoundries"))
        {
            Destroy(this.gameObject);
        }
    }
}