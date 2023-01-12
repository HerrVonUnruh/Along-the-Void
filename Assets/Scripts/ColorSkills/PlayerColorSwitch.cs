using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorSwitch : MonoBehaviour
{

    //public float Geschwindigkeit = 20f;// Erstellt einen öffentlichen Float namens "Geschwindigkeit"
    //public float GeschwindigkeitsAbfall = 40f;
    //public float StandartGeschwindigkeit = 50f;
    ////public float SprungGeschwindigkeit = 50f; // Erstellt öffentlichen Float namens "SprungGeschwindigkeit"
    //public float maxSpeed = 150f; // Erstellt einen öffentlichen Float für die Maximalgeschwindigkeit
    //public float flipSteigerung = 10f;

    public float Direction = 0f;// erstellt einen privaten Float namens "Direction" auf 0
    //public float DirectionVertical = 0f; // erstellt einen privaten Float für namens "DirectionVertical" auf 0

    [SerializeField] private Vector3 redSize = new Vector3(0.1f,0.1f,1f);
    

    private Vector3 startSize;
    ////private bool canDash = true; // Bool für "Kann Dashen" ist auf "Start" - wahr
    ////private bool isDashing;
    ////public float dashingPower = 24f;
    ////public float dashingTime = 0.2f;
    ////public float dashingCooldown = 1f;

    //public KillPlayer killSpawn;
    //public bool isDead; 
    //public float waitAtSpawn = 2f;

    public Material[] material;
    Renderer rend;

    //[SerializeField] Transform spawnPoint;
    //[SerializeField] private bool onSpawn = false;

    public bool isFacingRight = true;

    [SerializeField] private Rigidbody2D Player; // Bezug zu Rigidbody2D namens Player
                                                 ////[SerializeField] public Transform groundCheck;
                                                 ////[SerializeField] private LayerMask groundLayer;
                                                 ////[SerializeField] private TrailRenderer tr;


    ////private float triggerLength = 2f;
    ////private float triggerCounter;




    void Start()
    {
        Player = GetComponent<Rigidbody2D>(); // Erstellt am Anfang des Games einen Bezug zum Rigidbody namens "Player"
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        startSize = transform.localScale;
       

    }



    void Update()
    {


        ////Movement
        ////__________________________________________________________________________________________________________

        Direction = Input.GetAxisRaw("Horizontal"); // schaltet den Unity Bezug der Tasteneingaben zu "Horizontal" Voreinstellung von Unity frei
        //DirectionVertical = Input.GetAxisRaw("Vertical");

        //if (Direction == 0f)
        //{
        //    Geschwindigkeit = Geschwindigkeit - GeschwindigkeitsAbfall * Time.deltaTime;

        //    if (Geschwindigkeit <= 20f)
        //    { Geschwindigkeit = StandartGeschwindigkeit; }

        //}



        //if (Direction > 0f) // wenn die Richtung der gedrückten Tasten ( a oder d ) auf der Y Achse über 0 sind
        //{
        //    Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y);
        //    if (Geschwindigkeit < maxSpeed)
        //    {
        //        Geschwindigkeit += flipSteigerung * Time.deltaTime;
        //    }
        //}

        //else if (Direction < 0f) // wenn die Richtung der gedrückten Tasten(a oder d ) auf der Y Achse unter 0 sind
        //{
        //    Player.velocity = new Vector2(Direction * Geschwindigkeit, Player.velocity.y);
        //    if (Geschwindigkeit < maxSpeed)
        //    {
        //        Geschwindigkeit += flipSteigerung * Time.deltaTime;
    }
}