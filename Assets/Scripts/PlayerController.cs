using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    // Rock Bolt Variables
    public GameObject rockBoltPrefab;
    private List<GameObject> rockBolts = new List<GameObject>();
    [SerializeField] private float rockCooldown;
    private float timeStamp;
    private float projectileVelocity;
    private bool shooting;

    private Animator anim;
    private Rigidbody2D rb2d;

    private bool playerMoving;
    private Vector2 lastMove;
    
    [SerializeField] private Vector2 debugVector;
    [SerializeField] Vector2 forcePos;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        timeStamp = Time.time;
        projectileVelocity = 750f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // TODO : Implement Running

        //if (Input.GetKey(KeyCode.LeftShift))
        //    moveSpeed *= 2;
        //else
        //    moveSpeed = 2;

        PlayerMovement();

        if (Input.GetMouseButtonDown(0) && timeStamp <= Time.time)
        {
            timeStamp = Time.time + rockCooldown;

            shooting = true;
        }              
    }

    private void FixedUpdate()
    {
        if (shooting)
        {
            shooting = false;
            ShootRock();
        }           
    }

    private void PlayerMovement()
    {
        playerMoving = false;
        debugVector = new Vector2(0f, 0f);

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f)
        {
            debugVector.x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            debugVector.y = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        debugVector.Normalize();
        rb2d.velocity += debugVector;

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("Moving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    private void ShootRock()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 playerPos = transform.position;

        forcePos = new Vector2(mousePos.x - playerPos.x, mousePos.y - playerPos.y);
        forcePos = forcePos.normalized;

        float angle = Mathf.Atan2(forcePos.y, forcePos.x) * Mathf.Rad2Deg;
        Quaternion.Euler(new Vector3(0, 0, angle));

        GameObject rockBolt = Instantiate(rockBoltPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        rockBolts.Add(rockBolt);

        rockBolt.GetComponent<Rigidbody2D>().AddForce(forcePos * projectileVelocity);
    }
}
