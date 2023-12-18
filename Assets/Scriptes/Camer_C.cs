using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camer_C : MonoBehaviour
{
    private Camera camera;

    private float moveSpeed = 50;
    // Start is called before the first frame update
    private Vector2 borderX = new Vector2(-100, 190);
    private Vector2 borderZ = new Vector2(147, 305);
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dir *= 3;
        }
        transform.position += dir * Time.deltaTime * moveSpeed;

        if (transform.position.x > borderX.y)
        {
            transform.position = new Vector3(borderX.y, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < borderX.x)
        {
            transform.position = new Vector3(borderX.x, transform.position.y, transform.position.z);
        }

        if (transform.position.z > borderZ.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, borderZ.y);
        }
        else if (transform.position.z < borderZ.x)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, borderZ.x);
        }



        float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (mouseScrollWheel > 0 && camera.fieldOfView<60)
        {
            camera.fieldOfView += mouseScrollWheel * 10 * 5;
        }
        else if (mouseScrollWheel < 0&& camera.fieldOfView > 10)
        {
            camera.fieldOfView -= mouseScrollWheel * -10 * 5;
        }

    }
}
