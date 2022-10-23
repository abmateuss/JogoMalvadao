using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaoController : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    private Vector3 worldPosition;

    private Vector3 scale;


    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            

        //}
        if(worldPosition.x+transform.position.x<transform.position.x){
            float angle = Mathf.Atan2(worldPosition.y,worldPosition.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle-180,Vector3.forward);
            transform.rotation = rotation;
        } else {
            float angle = Mathf.Atan2(worldPosition.y,worldPosition.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
            transform.rotation = rotation;
        }
      

        
        //Debug.Log(worldPosition.x);
        //transform.localScale = new Vector3(transform.position.x > worldPosition.x? -scale.x:scale.x, scale.y, scale.z);
        
    }
}
