using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKontrol : MonoBehaviour
{
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
   

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Jump = false;
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
