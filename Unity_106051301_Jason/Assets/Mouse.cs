using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public int speed = 10;
    public float turn = 20.5f;
    public bool mission = false;
    public string Name = "Player";
    public Transform tran;
    public Rigidbody rigi;
    public Animator ani;
    public AudioSource aud;
    public AudioClip soundbark;
    [Header("撿東西")]
    public Rigidbody cat_rig;


    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Mouse"&& ani.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.GetComponent<HingeJoint>().connectedBody = cat_rig;
            //other.GetComponent<Collider>().enabled = false;
        }
    }

    private void Update()
    {


        WALK();
        Attack();
        Turn();
        RUN();

    }

    private void WALK()
    {


        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;

        float v = Input.GetAxis("Vertical");//W1 S-1 
        ///rigi.AddForce(0, 0, speed * v);//世界座標
        rigi.AddForce(tran.forward * speed * v * Time.deltaTime);

        ani.SetBool("WALK", v != 0);

        print("移動速度" + speed);


    }
    private void Turn()
    {
        float h = Input.GetAxis("Horizontal");///A-1,D1

        tran.Rotate(0, turn * h * Time.deltaTime, 0);

        print("旋轉" + turn);


    }



    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            ani.SetTrigger("Attack");
            aud.PlayOneShot(soundbark);

        }




    }
    private void RUN(bool RUN = true)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ani.SetBool("RUN",true);
            ani.SetBool("WALK", false);
        }
        else
        {
            ani.SetBool("RUN", false);
        }


        print("疾跑" + RUN);


    }


}