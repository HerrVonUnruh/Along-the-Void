using System.Collections;
using UnityEngine;

public class DashScript : MonoBehaviour
{



    public float Direction = 0f;// erstellt einen privaten Float namens "Direction" auf 0
    public float DirectionVertical = 0f; // erstellt einen privaten Float f�r namens "DirectionVertical" auf 0
    private PlayerController DashControll;


    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    public Animator animator;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] public TrailRenderer tr;




    private void Start()
    {
        DashControll = GetComponent<PlayerController>();
    }


    private void FixedUpdate()
    {
        if (isDashing)
        {

            DashControll.Geschwindigkeit = 90f;

        }
    }
    private IEnumerator Dash()
    {
        animator.SetTrigger("IsDashingAnimation");
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        SoundManager.sndMan.PlayDashSound();
        //rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        rb.AddForce(new Vector2(transform.localScale.x * dashingPower, 0f), ForceMode2D.Impulse);
        //rb.AddForce(transform.right * dashingPower, ForceMode2D.Impulse);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator DashVertical()
    {

        animator.SetTrigger("IsDashingAnimation");
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(0f, transform.localScale.y * DashControll.Geschwindigkeit * 5f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator DashVerticalRechtsHoch()
    {

        animator.SetTrigger("IsDashingAnimation");
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * DashControll.Geschwindigkeit, transform.localScale.y * DashControll.Geschwindigkeit);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator DashVerticalRechtsRunter()
    {

        animator.SetTrigger("IsDashingAnimation");
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * DashControll.Geschwindigkeit, transform.localScale.y * -DashControll.Geschwindigkeit);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator DashVerticalLinksHoch()
    {

        animator.SetTrigger("IsDashingAnimation");
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * -DashControll.Geschwindigkeit, transform.localScale.y * DashControll.Geschwindigkeit);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator DashVerticalLinksRunter()
    {

        animator.SetTrigger("IsDashingAnimation");
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(-transform.localScale.x * -DashControll.Geschwindigkeit, transform.localScale.y * -DashControll.Geschwindigkeit);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }


    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        Direction = Input.GetAxis("Horizontal");
        DirectionVertical = Input.GetAxis("Vertical");



        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && Direction != 0f && DirectionVertical == 0f || Input.GetKeyDown(KeyCode.Joystick1Button5) && canDash && Direction != 0f && DirectionVertical == 0f)
        {
            DashControll.Geschwindigkeit = DashControll.StandartGeschwindigkeit;
            StartCoroutine(Dash());
        }



        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && DirectionVertical > 0f && Direction == 0f || Input.GetKey(KeyCode.Joystick1Button5) && canDash && DirectionVertical > 0f && Direction == 0f /*|| Input.GetKeyDown(KeyCode.LeftShift) && canDash && DirectionVertical < 0f && Direction == 0f || Input.GetKey(KeyCode.Joystick1Button5) && canDash && DirectionVertical < 0f && Direction == 0f*/)
        {
            StartCoroutine(DashVertical());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && DirectionVertical > 0f && Direction > 0f || Input.GetKey(KeyCode.Joystick1Button5) && canDash && DirectionVertical > 0f && Direction > 0f)
        {
            StartCoroutine(DashVerticalRechtsHoch());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && DirectionVertical < 0f && Direction > 0f || Input.GetKey(KeyCode.Joystick1Button5) && canDash && DirectionVertical < 0f && Direction > 0f)
        {
            StartCoroutine(DashVerticalRechtsRunter());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && DirectionVertical > 0f && Direction < 0f || Input.GetKey(KeyCode.Joystick1Button5) && canDash && DirectionVertical > 0f && Direction < 0f)
        {
            StartCoroutine(DashVerticalLinksHoch());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && DirectionVertical < 0f && Direction < 0f || Input.GetKey(KeyCode.Joystick1Button5) && canDash && DirectionVertical < 0f && Direction < 0f)
        {
            StartCoroutine(DashVerticalLinksRunter());
        }
    }
}
