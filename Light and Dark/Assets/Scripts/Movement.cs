using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Public\\
    public float p_speed = 1f;
    public GameObject cam = null;
    public Rigidbody p_rb = null;
    public GameObject player = null;

    //private\\
    private Vector3 c_vel;

    private void Start()
    {
        if (p_rb == null) { p_rb = GetComponent<Rigidbody>(); }
        if (player == null) { player = this.gameObject; }
        p_speed *= 2f;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            p_rb.AddForce(cam.transform.forward * p_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {

            p_rb.AddForce(-cam.transform.right * p_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_rb.AddForce(-cam.transform.forward * p_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_rb.AddForce(cam.transform.right * p_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            p_rb.AddForce(cam.transform.up * p_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            p_rb.AddForce(-cam.transform.up * p_speed * Time.deltaTime);
        }
    }
}
