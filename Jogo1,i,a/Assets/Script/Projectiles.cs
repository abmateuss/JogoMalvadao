using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    [SerializeField]
    private GameObject tiro;

    [SerializeField]
    private int dano;

    [SerializeField]
    private float velocidade;

    private Vector3 direcao;

    private float distanciatodestroy ;

    
    
        
    // Start is called before the first frame update
    void Start()
    {
        distanciatodestroy = .01f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirecao = (direcao - transform.position).normalized;

        transform.position += moveDirecao*velocidade*Time.deltaTime;

        //transform.position += new Vector3(1,0,0)*velocidade*Time.deltaTime;

        float angulo = FixProjectileAngle(moveDirecao);
        transform.eulerAngles = new Vector3(0,0,angulo);

        if(Vector3.Distance(direcao , transform.position)<distanciatodestroy){
            //Debug.Log("ENTROU");
            //Debug.Log(direcao);
            Destroy(gameObject);
        }


    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Malvadao"))
        {
            malvadao.SetTrigger("Hit");
            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }*/

    public void create(Transform shootposicao, Vector3 targetposicao){
        GameObject tiraco = Instantiate(tiro, shootposicao);
        Projectiles projetilocal = tiraco.transform.GetComponent<Projectiles>();
        projetilocal.setTarget(targetposicao);
        projetilocal.transform.parent = null;
        if (projetilocal.transform.localScale.x < 0 ){ //rotacionar bala
            projetilocal.transform.localScale = new Vector3(-projetilocal.transform.localScale.x, projetilocal.transform.localScale.y, projetilocal.transform.localScale.z);
        }
        
    }

    public void setTarget(Vector3 targetposicao){
        //direcao = new Vector3(targetposicao.x+10,targetposicao.y+10,targetposicao.z+10);
        direcao = targetposicao;
    }

    public float FixProjectileAngle(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }
        return n;
    } 


}
