using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKontrol : MonoBehaviour
{



    public Transform yol1;
    public Transform yol2;
    public Text can;
    



    //animasyon
    public Animator anim;
    public bool Jump;

    
    //Movement
    CharacterController controller;
    public float hiz = 0.1f;
    float nereye;
    int slot = 0;
   
    
    /// sol taraf slot = -1;
    /// orta taraf slot = 0
    /// sað taraf slot = 1

    //Jump
    public Transform ground;
    public float gravity;
    public float ZiplamaYuksekligi;
    bool isGround;
    float distance = 0.3f;
    Vector3 velocity;
    public LayerMask mask;
    int karakter_can = 100;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Jump = false;


    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "SahneSonu")
    //    {
    //        Instantiate(yol,new Vector3(-10.53936f, 9.063419f, 52.2f),transform.rotation);


    //    }   
    //}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "YolunSonu1")
        {
            yol2.position = new Vector3(yol1.position.x, yol1.position.y, yol1.position.z + 120.0f);
        }
        if (other.gameObject.name == "YolunSonu2")
        {
            yol1.position = new Vector3(yol2.position.x, yol2.position.y, yol2.position.z + 120.0f);
        }
        if (other.gameObject.tag == "traps")
        {
            karakter_can -= 50;
            can.text = karakter_can.ToString();
            if (karakter_can<10)
            {
                Time.timeScale=0.001f;
            }
        }
    }

    void Update()
    {
       
        Animasyonkontrolleri();

        #region Move
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //Vector3 move = transform.right * horizontal * Time.deltaTime * hiz;
        //controller.Move(move);

        
        //GetComponent<Rigidbody>().velocity = new Vector3(nereye,0f,0f);

        Vector3 move;


        if (Input.GetKeyDown(KeyCode.A) && slot >= 0)
        {


            move = new Vector3(-3f, 0f, 0f);
            //nereye =0;
            slot -= 1;
            
            controller.Move(move);

        }
        if (Input.GetKeyDown(KeyCode.D) && slot <= 0)
        {
            move = new Vector3(3f, 0f, 0f);
            slot += 1;
            controller.Move(move);
        }
        #endregion

        #region Jump

        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y += Mathf.Sqrt(ZiplamaYuksekligi * -3.0f * gravity);
            Jump = true;
        }

        isGround = Physics.CheckSphere(ground.position, distance, mask);
        if(isGround && velocity.y < 0)
        {
            velocity.y = 0f;
            Jump = false;

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        #endregion



       
        
    }
    public void Animasyonkontrolleri()
    {
        if (Jump)
        {
            anim.SetBool("Jump", true);

        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }




    
}
