using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Sin : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed = 1;

    private float CreationTime;

    // Start is called before the first frame update
    void Start()
    {
        CreationTime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.down * MovementSpeed * Time.deltaTime + new Vector3(Mathf.Sin(Time.timeSinceLevelLoad - CreationTime) / 200, 0, 0);
    }
}
