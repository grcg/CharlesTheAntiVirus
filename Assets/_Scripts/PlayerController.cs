using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {

	//Public properties 
	public GameController gameController;

    public AudioSource shootingSound;

    //Borders
    public float LeftBoundary;
	public float RightBoundary;
	public float TopBoundary;
	public float BottomBoundary;

	public GameObject bullet;
    public Animator anim;
    //public Ga
	//to limit the shots
	public float fireCooldown = 0.5f;
	//timestamp of when the last shot was fired
	private float fireTimer;

	// changed
	public float playerX = -955;
    
	//Public methods


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>(); 
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			this.transform.position += new Vector3(0, 5, 0);
		}

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(-5, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(5, 0, 0);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			this.transform.position += new Vector3(0, -5, 0);
		}

		if (Input.GetKey(KeyCode.Space) || Input.GetButton("Fire1"))
		{
			if (fireTimer < Time.time) {
                this.shootingSound.Play();
                Instantiate(bullet, transform.position, Quaternion.identity);
				fireTimer = Time.time + fireCooldown;
			}
		}
        
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag =="WhiteBloodCell")
		{
			gameController.SetPoints(gameController.GetPoints() + 25, true);
            Debug.Log("Collided with White Blood Cell");

            //         gameController.SetLifePoints(gameController.GetLifePoints() + 5, true);
            //Debug.Log("Life gained");        

            // TODO: starts coroutine
            StartCoroutine(IncreaseFiringSpeed());
			Destroy (collision.gameObject);



		}
		if (collision.gameObject.tag == "Bacteria")
		{
			gameController.SetLifePoints(gameController.GetLifePoints() - 5, true);
            //bar.setHealth(gameController.GetLifePoints() - 5);
			Debug.Log("Collided with Bacteria");
		}




	}

    // TODO: coroutine to change firing speed
    IEnumerator IncreaseFiringSpeed()
    {
        fireCooldown = 0.25f;
        yield return new WaitForSeconds(5);
        fireCooldown = 0.5f;
    }
}
