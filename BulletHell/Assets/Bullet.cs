using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 20f;
    public float damage = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * Speed * Time.deltaTime;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameBoundries"))
        {
            Destroy(this.gameObject);
        }
    }
}
