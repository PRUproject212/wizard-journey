using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Animator animator;
    public GameObject popupComplete;
    public Transform m_GroundCheck;

    PlayerMovement playerMovement;
    float horizontalMove;
    float verticalMove;
    bool m_FacingRight = true;
    public bool m_Grounded = true;
    const float k_GroundedRadius = 0.25f;
    [SerializeField] public LayerMask m_WhatIsGround;
    public PlayerHealth playerHealth;

    int countJump = 0;
    bool isClimbing = false;


    bool firstDie;

    [Header("Dash")]
    bool canDash = true;
    bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
        horizontalMove = 0f;
        verticalMove = 0f;
        PlayerHealth.PlayerMoveToPointStart += SetIdleAnimation;
    }

    private void SetIdleAnimation()
    {
        animator.SetTrigger("Idle");
    }

    private void OnDestroy()
    {
        PlayerHealth.PlayerMoveToPointStart -= SetIdleAnimation;
    }

    private void Update()
    {
        firstDie = playerHealth.isDie;
        CheckOnLanding();
        if (isDashing) return;
        if (firstDie) return;

        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        if (horizontalMove == 0)
        {
            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || InputController.Instance.isKeySpacePress) && (countJump < 1 || m_Grounded == true))
        {
            countJump = 1;
            animator.SetTrigger("TakeOf");
            playerMovement.Jumping(m_Grounded);
            InputController.Instance.SetSpaceBtn(false);
            GetComponent<PlayerHealth>().EffectJump.SetActive(true);
            StartCoroutine(CancelAnimationEffectJump());
        }

        if ((Input.GetKeyDown(KeyCode.S) || InputController.Instance.isKeyDashPress) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (m_Grounded == true)
        {
            animator.SetBool("IsJumping", false);
        }



        if (horizontalMove > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (horizontalMove < 0 && m_FacingRight)
        {
            Flip();
        }

        ProcessMove();
    }

    public void UpdateAnimation()
    {
        if (!firstDie)
        {
            animator.SetTrigger("Die");
            firstDie = true;
        }
    }


    void ProcessMove()
    {
        if (firstDie) return;
        if (isDashing) return;
        playerMovement.Moving(horizontalMove, m_Grounded);

        playerMovement.ResetGravity();

    }


    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Endpoint")
        {
            popupComplete.SetActive(true);
        }
        countJump = 0;
    }


    public void CheckOnLanding()
    {
        m_Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("TitleMap"))
            {
                m_Grounded = true;
                countJump = 0;
            }
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = playerMovement.rd.gravityScale;
        playerMovement.rd.gravityScale = 0f;
        playerMovement.rd.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        playerMovement.tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        playerMovement.tr.emitting = false;
        playerMovement.rd.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    IEnumerator CancelAnimationEffectJump()
    {
        yield return new WaitForSeconds(0.35f);
        GetComponent<PlayerHealth>().EffectJump.SetActive(false);
    }

}
