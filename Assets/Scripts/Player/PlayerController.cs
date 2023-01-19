using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float Geschwindigkeit = 20f;// Erstellt einen öffentlichen Float namens "Geschwindigkeit"
    public float GeschwindigkeitsAbfall = 40f;
    public float StandartGeschwindigkeit = 50f;
    public float maxSpeed = 150f; // Erstellt einen öffentlichen Float für die Maximalgeschwindigkeit
    public float flipSteigerung = 10f;

    public float Direction = 0f;// erstellt einen privaten Float namens "Direction" auf 0
    public float DirectionVertical = 0f; // erstellt einen privaten Float für namens "DirectionVertical" auf 0

    public float GroundCheckRadius = 0.2f;
    public float ShroomCheckRadius = 0.2f;
    public float RedGroundCheckRadius = 0.2f;

    [SerializeField]LayerMask groundLayer;
    [SerializeField]LayerMask shroomLayer;
    [SerializeField]LayerMask redgroundLayer;


    public bool isRedGrounded = false;
    public bool isGrounded = false;
    [SerializeField]Transform GroundCheckCollider;

    public bool isJumping = false;
    [SerializeField]Transform ShroomCheckCollider;

  
    [SerializeField]Transform RedGroundCheckCollider;

    //private Vector3 redSize = new Vector3(0.1f,0.1f,1f);
    //private Vector3 startSizze = new Vector3(0.4f, 0.4f, 1f);


    //private Vector3 startSize;


    public KillPlayer killSpawn;
    public bool isDead; 
    public float waitAtSpawn = 2f;


    [SerializeField] Transform spawnPoint;
    [SerializeField] private bool onSpawn = false;

    public bool isFacingRight = true;

    [SerializeField] public Rigidbody2D Player; // Bezug zu Rigidbody2D namens Player



    public Animator animator;

    [Header("Events")]
    [Space]

    public UnityEvent OnJumpEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnGravityEvent;
    private bool GravityControl = false;
    private bool GravityControlAnimation = false;
    public ColorManager colorManager;

    //public Material[] material;
    //Renderer rend;
    //[SerializeField] public Transform groundCheck;
    //[SerializeField] private LayerMask groundLayer;
    //[SerializeField] private TrailRenderer tr;
    //private float triggerLength = 2f;
    //private float triggerCounter;
    public float SprungGeschwindigkeit = 50f; // Erstellt öffentlichen Float namens "SprungGeschwindigkeit"
    private void Awake()
    {
        Player = GetComponent<Rigidbody2D>();

        if (OnJumpEvent == null)
            OnJumpEvent = new UnityEvent();

        if (OnGravityEvent == null)
            OnGravityEvent = new BoolEvent();
    }


    void Start()
    {
        Player = GetComponent<Rigidbody2D>(); // Erstellt am Anfang des Games einen Bezug zum Rigidbody namens "Player"
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        //rend.sharedMaterial = material[0];
        


    }



    void Update()
    {
        
        

        //Movement
        //__________________________________________________________________________________________________________

        Direction = Input.GetAxis("Horizontal"); // schaltet den Unity Bezug der Tasteneingaben zu "Horizontal" Voreinstellung von Unity frei
        DirectionVertical = Input.GetAxis("Vertical");

        if (Direction == 0f)
        {
            Geschwindigkeit = Geschwindigkeit - GeschwindigkeitsAbfall * Time.deltaTime;

            if (Geschwindigkeit <= 20f)
            { Geschwindigkeit = StandartGeschwindigkeit; }

        }




        if (Direction > 0f) // wenn die Richtung der gedrückten Tasten ( a oder d ) auf der Y Achse über 0 sind
        {
            Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y);
            if (Geschwindigkeit < maxSpeed)
            {
                Geschwindigkeit += flipSteigerung * Time.deltaTime;
            }
        }

        else if (Direction < 0f) // wenn die Richtung der gedrückten Tasten(a oder d ) auf der Y Achse unter 0 sind
        {
            Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y);
            if (Geschwindigkeit < maxSpeed)
            {
                Geschwindigkeit += flipSteigerung * Time.deltaTime;
            }
        }
        else // "Andernfalls", also wenn gar keine Taste A oder D gedrückt wird, dann bedeutet das, dass auf der X Achse 0 Bewegung stattfindet!
        {
            Player.velocity = new Vector2(0, Player.velocity.y);
        }




        if (/*DirectionVertical == 0f &&*/ Input.GetKeyDown(KeyCode.S) && !isGrounded || /*DirectionVertical < 0f &&*/ Input.GetKey(KeyCode.Joystick1Button4) && !isGrounded)
        {
            Player.gravityScale = 70f; ;
            GravityControl = true;
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button4) || Input.GetKeyUp("s"))
        {
            Player.gravityScale = 7f;
            GravityControl = false;
        }
        if (GravityControl == true)
        {
            animator.SetBool("IsGravityControl", true);
            //GravityControlAnimation = false;
        }
        if (isGrounded == true)
        {
            animator.SetBool("IsGravityControl", false);
        }





        Flip(); // HIER IST DIE FUNKTION FÜR DIE STEIGERUNG FUER DIE GESCHWINDIGKEIT PRO SEKUNDE!!!!!!

        //__________________________________________________________________________________________________________
        

        //RESPAWN
        //__________________________________________________________________________________________________________

        Spawn();
        if (onSpawn == true)
        { Geschwindigkeit = 0f;
            //canDash = false;
        }
        // Spawn natürlich
        //__________________________________________________________________________________________________________

        //SKILLS
        //__________________________________________________________________________________________________________


        //Rote Fähigkeit
        //if (isRedGrounded && colorManager.redIsActive)
        //{
        //    //rend.sharedMaterial = material[1];
        //    ChangeSize(redSize);

        //}

        //else
        //{
        //    ChangeSize(startSizze);
        //}


        //__________________________________________________________________________________________________________

        //Dash
        //__________________________________________________________________________________________________________
        //if (isDashing)
        //{
        //    Geschwindigkeit = StandartGeschwindigkeit;
        //    return;
        //}

        //if (Input.GetKeyUp(KeyCode.LeftShift) && canDash && Input.GetKeyUp("a") ||  Input.GetKey(KeyCode.Joystick1Button5) && canDash || (Input.GetKeyUp(KeyCode.LeftShift) && canDash && Input.GetKeyUp("d")) || (Input.GetKeyUp("s") && Input.GetKeyUp(KeyCode.LeftShift)) && canDash || Input.GetKeyUp(KeyCode.LeftShift) && (Input.GetKeyUp("w")) && canDash)

        //{
        //    StartCoroutine(Dash());


        //}

        //Debug.Log (Player.transform.localScale.x);
        //Debug.Log(Direction);
        //Debug.Log(DirectionVertical);


        //__________________________________________________________________________________________________________


        //if (triggerCounter > 0)
        //{
        //    triggerCounter -= Time.deltaTime;
        //}




        // JUMP
        // ______________________________________________________________________________________________________
        if (Input.GetAxis("Left Trigger") > 0f)
        {
            Player.velocity = new Vector2(Player.velocity.x, SprungGeschwindigkeit);
        }

        if (Input.GetAxis("Left Trigger") > 0f && Player.velocity.y > 0f)
        {
            Player.velocity = new Vector2(Player.velocity.x, Player.velocity.y * 0.5f);
        }
        //_________________________________________________________________________________________________________
        //if (isDashing && (Input.GetKeyDown(KeyCode.LeftShift) &&  Input.GetKey("a")) || Input.GetKeyDown(KeyCode.Joystick1Button5) && Input.GetKeyDown("Horizontal")|| Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("d"))
        //{
        //    Player.velocity = new Vector2(transform.localScale.x * dashingPower, transform.localScale.y);
        //}


        animator.SetFloat("Speed", (Geschwindigkeit));
        Debug.Log("Fischgesicht");

        if (isGrounded)
        {
             animator.SetBool("IsGrounded", true);
             animator.SetBool("IsJumping", false);
        }
            else
        {
            animator.SetBool("IsGrounded", false);
        }


        if (isJumping)
        {
            animator.SetBool("IsJumping", true);
        }
    }

    public void FixedUpdate()
    {
        GroundCheck();
        ShroomCheck();
        RedGroundCheck();
    }

    public void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheckCollider.position, GroundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
            //GravityControlAnimation = true;
        }
        
    }


    public void ShroomCheck()
    {
       isJumping = false;
       Collider2D[] colliders = Physics2D.OverlapCircleAll(ShroomCheckCollider.position, ShroomCheckRadius, shroomLayer);
       if (colliders.Length > 0)
        isJumping = true;
        
    }

    public void RedGroundCheck()
    {
        isRedGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(RedGroundCheckCollider.position, RedGroundCheckRadius, redgroundLayer);
        if (colliders.Length > 0)
        isRedGrounded = true;
        
    }

    //__________________________________________________________________________________________________________________________________________
    //private void FixedUpdate()
    //{
    //    if (Input.GetKeyUp(KeyCode.Joystick1Button5) && Direction > 0f && canDash)
    //    {
    //        Player.velocity = new Vector2(transform.localScale.x * dashingPower, transform.localScale.y);
    //    }
    //    if (Input.GetKeyUp(KeyCode.Joystick1Button5) && Direction < 0f && canDash)
    //    {
    //        Player.velocity = new Vector2(-transform.localScale.x * -dashingPower, -transform.localScale.y);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Joystick1Button5) && DirectionVertical > 0f && canDash)
    //    {
    //        Player.velocity = new Vector2(transform.localScale.x, transform.localScale.y * dashingPower);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Joystick1Button5) && DirectionVertical < 0f && canDash && Input.GetKey("Horizontal"))
    //    {
    //        Player.velocity = new Vector2(transform.localScale.x, transform.localScale.y * -dashingPower);
    //    }
    //    __________________________________
    //    if (Input.GetKey(KeyCode.Joystick1Button5) && Direction == 0f && canDash && DirectionVertical == 0f)
    //    {
    //        Player.velocity = new Vector2(transform.localScale.x * dashingPower * 10, transform.localScale.y);
    //    }
    //}

    //private IEnumerator Dash()
    //{
    //    canDash = false;
    //    isDashing = true;
    //    float originalGravity = Player.gravityScale;
    //    Player.gravityScale = 0f;
    //    tr.emitting = true;
    //    yield return new WaitForSeconds(dashingTime);
    //    tr.emitting = false;
    //    Player.gravityScale = originalGravity;
    //    isDashing = false;
    //    yield return new WaitForSeconds(dashingCooldown);
    //    canDash = true;

    //}

    public void Flip()
    {
        if (isFacingRight && Direction < 0f || !isFacingRight && Direction > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void Spawn()
    { //SPAWN mit eigener Tastenbelegung
        //______________________________________________________       
        if (Input.GetKeyUp(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            StartCoroutine(SpawnPause());
            Debug.Log("Test1");
            // return;
        }

        if (killSpawn.willSpawn)
        {
            StartCoroutine(SpawnPause());
        }

    }

    public IEnumerator SpawnPause()
    {
        Debug.Log("Start");
        transform.CompareTag("Player");
        transform.position = spawnPoint.position;
        onSpawn = true;
        Player.velocity = Vector2.zero;
        yield return new WaitForSeconds(waitAtSpawn);
        onSpawn = false;
        killSpawn.willSpawn = false;
        Debug.Log("Ende");

    }

    public void StartWallPause()
    {
        StartCoroutine(WallPause());
    }

    public IEnumerator WallPause()
    {
        Player.velocity = Vector2.zero;
        Geschwindigkeit = 0f;
        yield return new WaitForSeconds(3);
    }

    //private void Movement()

    //{

    //    Direction = Input.GetAxisRaw("Horizontal"); // schaltet den Unity Bezug der Tasteneingaben zu "Horizontal" Voreinstellung von Unity frei
    //    DirectionVertical = Input.GetAxisRaw("Vertical");

    //    if (Direction == 0f)
    //    {
    //        Geschwindigkeit = Geschwindigkeit - GeschwindigkeitsAbfall * Time.deltaTime;

    //        if (Geschwindigkeit <= 20f)
    //        { Geschwindigkeit = StandartGeschwindigkeit; }

    //    }



    //    if (Direction > 0f) // wenn die Richtung der gedrückten Tasten ( a oder d ) auf der Y Achse über 0 sind
    //    {
    //        Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y);
    //        if (Geschwindigkeit < maxSpeed)
    //        {
    //            Geschwindigkeit += flipSteigerung * Time.deltaTime;
    //        }
    //    }

    //    else if (Direction < 0f) // wenn die Richtung der gedrückten Tasten(a oder d ) auf der Y Achse unter 0 sind
    //    {
    //        Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y);
    //        if (Geschwindigkeit < maxSpeed)
    //        {
    //            Geschwindigkeit += flipSteigerung * Time.deltaTime;
    //        }
    //    }
    //    else // "Andernfalls", also wenn gar keine Taste A oder D gedrückt wird, dann bedeutet das, dass auf der X Achse 0 Bewegung stattfindet!
    //    {
    //        Player.velocity = new Vector2(0, Player.velocity.y);
    //    }
    //}

    //________________________________________________________________
    // AUTOMATIC SPAWN



    //private bool IsGrounded()
    //{
    //    return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    //}





    private void ChangeSize(Vector3 groesseAendern)
    {
        if(isFacingRight)
        {
            Player.gameObject.transform.localScale = groesseAendern;
        }
       
        else
        {
            Player.gameObject.transform.localScale = new Vector3(-groesseAendern.x, groesseAendern.y, groesseAendern.z);
        }
    }

}