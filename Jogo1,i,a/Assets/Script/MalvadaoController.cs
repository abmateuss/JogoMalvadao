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

    private GameObject bonecaso;
    private Animator anime;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        malvadaso = GameObject.Find("MALVADAO");
        bonecaso = GameObject.Find("BONECAO");
        direction = 1;
        anime = GetComponent<Animator>();
        posicaoInicial = transform.position;
        Debug.Log("Jamais saberao oq e ser falmengo");
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.RoundToInt(Mathf.Abs(transform.position.x - malvadaso.transform.position.x));

        if(distance <= 20)
        {
            transform.Translate(0.01f * direction, 0.0f, 0.0f);
            transform.localScale = new Vector3(direction, 1f, 1f);
            if (Mathf.Abs(transform.position.x - posicaoInicial.x) > 10) direction *= -1;
        }

        /*if(malvadaso.transform.position.x - bonecaso.transform.position.x < 1){
            anime.SetTrigger("Attack");
        }*/

        //anime.SetInteger("Distance", distance);
        
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
            anime.SetTrigger("Attack");
            //Destroy(collision.gameObject);
            //Destroy(gameObject);
        }
    
    }
}
