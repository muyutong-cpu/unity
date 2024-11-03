using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator1 : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private NewBehaviourScript physicsCheck;
    private PlayerMove playerMove;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<NewBehaviourScript>();
        playerMove = GetComponent<PlayerMove>();
    }
    private void Update()
    {
        SetAnimation();
    }
    public void SetAnimation()
    {
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x/5));
        anim.SetFloat("velocityY",rb.velocity.y);
        anim.SetBool("onGround",physicsCheck.onGround);
        anim.SetBool("isDead", playerMove.isDead);
        anim.SetBool("isAttack", playerMove.isAttack);
       


    }

    public void playHurt()
    {
        anim.SetTrigger("hurt");
    }


   public void PlayAttack()
    {
        anim.SetTrigger("attack");
    }
}
