using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public InputController ic;
    public LayerMask targetLayerMask;
    private NewBehaviourScript physicsCheck;
    private Animator1 playerAnimation;
    public int jumpCount;
    public float speed;
    public bool isHurt;
    public float hurtForce;
    public bool isDead;
    public bool isAttack;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<NewBehaviourScript>();
        playerAnimation = GetComponent<Animator1>();
    }

    private void OnEnable()
    {
        ic.inputJson.Basic.Jump.performed += Jump;
        ic.inputJson.Basic.Interact.performed += Interact;
        ic.inputJson.Basic.Attack.started += PlayerAttack;
    }

   

    private void OnDisable()
    {
        ic.inputJson.Basic.Jump.performed -= Jump;
        ic.inputJson.Basic.Interact.performed -= Interact;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        Collider2D[] results = new Collider2D[10];
        Physics2D.OverlapCircle(transform.position, 1.5f, new ContactFilter2D { useLayerMask = true, useTriggers = true, layerMask = targetLayerMask }, results);
        if (results[0] != null) results[0].GetComponent<ShowContent>()?.ShowIt();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.onGround)
            jumpCount = 2;
        else
            jumpCount--;
        if (jumpCount > 0)
            rb.velocity += new Vector2(0, 12);
    }


    private void PlayerAttack(InputAction.CallbackContext context)
    {
        playerAnimation.PlayAttack();
        isAttack = true;
        
    }

    public void Move()
    {
        Vector2 dir = ic.inputJson.Basic.Move.ReadValue<Vector2>();
        rb.velocity = new Vector2(speed * dir.x, rb.velocity.y);

        int faceDir = (int)transform.localScale.x;

        if (dir.x > 0)
            faceDir = 1;
        if (dir.x < 0)
            faceDir = -1;
        transform.localScale = new Vector3(faceDir, 1, 1);
    }
    private void Update()
    {
        if (!isHurt&&!isAttack)
            Move();
    }

    public void GetHurt(Transform attacker)
    {
        isHurt = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attacker.position.x), 0).normalized;

        rb.AddForce(dir * hurtForce, ForceMode2D.Impulse);
    }


    public void PlayDead()
    {
        isDead = true;
        ic.inputJson.Basic.Disable();
    }
}
