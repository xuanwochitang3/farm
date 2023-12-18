using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_C : MonoBehaviour
{
    private GameObject prefab_Crop_Empty;
     
    public GameObject Prefab_Crop_Sunflower;

    private List<GameObject> corps = new List<GameObject> ();
    // Start is called before the first frame update
    private GameObject crop_Empty;
    private void Start()
    {
        prefab_Crop_Empty = Resources.Load<GameObject>("Crop_Empty");

        crop_Empty = GameObject.Instantiate<GameObject>(prefab_Crop_Empty);
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, int.MaxValue, 1 <<
            LayerMask.NameToLayer("Ground")))
        {
            if(hit.collider!=null&&hit.collider.gameObject.tag=="Ground")
            {
                GameObject crop = null;
                for(int i = 0;i< corps.Count; i++)
                {
                    if (Vector3.Distance(hit.point, corps[i].transform.position)<12)
                    {
                        crop = corps[i];
                        break;
                    }
                }
                if(crop!=null)
                {
                    Vector3 top = crop.transform.position + new Vector3(0, 0, 10);
                    Vector3 bottom = crop.transform.position + new Vector3(0, 0, -10);
                    Vector3 left = crop.transform.position + new Vector3(-10, 0, 0);
                    Vector3 right = crop.transform.position + new Vector3(10, 0, 0);
                    Vector3[] points = new Vector3[] { top, bottom, left, right };

                    float dis = 10000;
                    Vector3 tempPoint = Vector3.zero;
                    for(int i = 0;i<points.Length;i++)
                    {
                        if (Vector3.Distance(hit.point, points[i])<dis)
                        {
                            dis = Vector3.Distance(hit.point, points[i]);
                            tempPoint = points[i];
                        }
                    }

                    crop_Empty.transform.position = tempPoint;
                }
                else
                {
                    crop_Empty.transform.position = hit.point;
                }
            }
            if(Input.GetMouseButtonDown(0))
            {

                    GameObject temp = GameObject.Instantiate<GameObject>
                    (Prefab_Crop_Sunflower, crop_Empty.transform.position,
                    Quaternion.identity, null);
                    corps.Add(temp);
 
            }
        }
    }
}
