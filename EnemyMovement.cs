using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("FPS Character");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 5f * Time.deltaTime);
    }
}
