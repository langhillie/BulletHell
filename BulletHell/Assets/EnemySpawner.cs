using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> EnemyPrefabs;

    [SerializeField]
    private GameObject BossPrefab;

    private float MaxCooldown = 10f;
    private float SpawnCooldown = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (SpawnCooldown <= 0)
        {
            SpawnCooldown = MaxCooldown;

            Vector2 SpawnPos = new Vector2(transform.position.x + Random.Range(-1f, 1f), transform.position.y);
            GameObject Enemy = GameObject.Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)], SpawnPos, transform.rotation);
            Enemy.GetComponent<EnemyController>().Initialize();
        }
        else
        {
            SpawnCooldown -= Time.deltaTime;
        }
    }
}
