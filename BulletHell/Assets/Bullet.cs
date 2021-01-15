using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float StartSpeed = 20f;
    public float EndSpeed = 20f;
    public float damage = 3f;

    private float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Speed = StartSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Speed = Mathf.Lerp(Speed, EndSpeed, Time.deltaTime * 3);
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
