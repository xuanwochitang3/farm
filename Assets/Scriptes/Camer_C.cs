using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camer_C : MonoBehaviour
{
    private float moveSpeed = 50;
    private Camera camera;
    // Start is called before the first frame update
    private Vector2 borderX = new Vector2();
    private Vector2 borderZ = new Vector2();
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
        float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");

        Vector3 dir = new Vector3(h, 0, v);
        transform.position += dir * Time.deltaTime * moveSpeed;

    }
 

}
