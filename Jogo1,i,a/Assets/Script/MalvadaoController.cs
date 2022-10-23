using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalvadaoController : MonoBehaviour
{
/*
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float speed;

    private bool andando;
    private bool andandoLado;
    private Vector3 scale;

    [SerializeField]
    private Rigidbody2D robertin2;
*/
    private Vector3 posicaoInicial;
    private GameObject malvadaso;

    [SerializeField]
    private GameObject bonecao;

    private GameObject bonecaso;
    private Animator anime;
    private int direction;

    private Vector3 scale;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        malvadaso = GameObject.Find("MALVADAO");
        bonecaso = GameObject.Find("BONECAO");
        direction = 1;
        anime = GetComponent<Animator>();
        posicaoInicial = transform.position;
        //Debug.Log("Jamais saberao oq e ser falmengo");

        scale = malvadaso.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector2.Distance(transform.position , bonecaso.transform.position);
        Vector2 direction = bonecaso.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        
        transform.position = Vector2.MoveTowards(this.transform.position,bonecaso.transform.position, speed*Time.deltaTime);
        Debug.Log(angle);
        if((angle > 90 && angle <180) || (angle < -90 && angle >-180)){
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);  
        } else {
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);  
        }
        //transform.rotation = Quaternion.Euler(Vector3.forward *angle);
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tiro"))
        {
            anime.SetTrigger("Hit");
            Destroy(collision.gameObject);
            //Destroy(gameObject);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bonecao"))
        {
            transform.localScale = new Vector3(transform.position.x>bonecaso.transform.position.x? scale.x:-scale.x, scale.y, scale.z); 
            anime.SetTrigger("Attack");
            //Destroy(collision.gameObject);
            //Destroy(gameObject);
        }
    
    }
}
