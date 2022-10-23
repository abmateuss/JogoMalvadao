using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BonecaoController : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float speed;
    private bool andando;
    private Vector3 scale;

    private Vector3 worldPosition;
    
    [SerializeField]
    private Rigidbody2D robertin;

    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f){
            if(!andando){
                animator.SetTrigger("WalkUp");
                andando = true;
            }
            robertin.velocity = new Vector2(speed*Input.GetAxis("Horizontal"), speed*Input.GetAxis("Vertical"));
        } else {
            if(andando){
                animator.SetTrigger("Idle");
            }
            andando = false;
        }

       
        //transform.localScale = new Vector3(Input.GetAxis("Horizontal")>0? scale.x:-scale.x, scale.y, scale.z);


        //if(Input.GetMouseButtonDown(0))
        //{
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                     
        //}
        transform.localScale = new Vector3(transform.position.x<worldPosition.x? scale.x:-scale.x, scale.y, scale.z);  
        //if(!andando)
           

        
        //Debug.Log(worldPosition.x);
        //transform.localScale = new Vector3(transform.position.x > worldPosition.x? -scale.x:scale.x, scale.y, scale.z);

        
    }
}


