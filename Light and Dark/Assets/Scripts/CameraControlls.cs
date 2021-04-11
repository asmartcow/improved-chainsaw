using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlls : MonoBehaviour
{
    //public\\
    [Header("Cam Settings")]
    public float c_speed;
    public float c_closeSpeed;
    public float c_maxdist;
    public GameObject target = null;
    public GameObject cam = null;

    //privates\\
    private float yaw;
    private float pitch;
    private float r_length;

    private void Start()
    {
    }

    private void Update()
    {
        LookAt();
        Raycast();
        Rotate();
    }

    private void LookAt()
    {
        cam.transform.LookAt(target.transform.position);
    }

    private void Rotate()
    {
        Cursor.lockState = CursorLockMode.Locked;

        yaw -= c_speed * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= c_speed * Input.GetAxis("Mouse Y") * Time.deltaTime;

        target.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    private void Raycast()
    {
        RaycastHit hit;
        if (Physics.Linecast(target.transform.position, cam.transform.position, out hit))
        {
            Vector3 inverse = hit.transform.InverseTransformPoint(cam.transform.position);
            cam.transform.position = inverse;
        }
    }
}
