using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]private Vector3 rotation;
    [SerializeField]private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) rotation = 10 * Vector3.down;
        else if (Input.GetKey(KeyCode.D)) rotation = 10 * Vector3.up;
        else{
            rotation = Vector3.zero;
            rotation = Vector3.up;
        } 
    }

    void FixedUpdate()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
