using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float bulletwidth, knockback, range;
	private GameObject player;
	public float fireRate = 1.0f;
	private float nextFire = 0.0f;
	protected Vector2 tipoffset = new Vector2(.1f,.1f);
	public bool canshoot,canbuild;
	public GameObject Wall, gunlight;
	GameObject Wallclone;


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		knockback = 1;
		canshoot = true;

	}

	void Build() 
	{
		var camerapos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		camerapos.z = 0;

		if (Input.GetKeyDown(KeyCode.B))
		{
			canshoot = !canshoot;
			canbuild = !canbuild;
		}

		if (Input.GetMouseButtonDown (0) && canbuild)

			Instantiate (Wall, camerapos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = player.transform.position; //weapon position = player position

		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position); 
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Shoot ();
		}
		Build ();
	
	}

	void DrawLine(Vector2 start, Vector2 end, Color color, float duration = 0.005f)
	{
		GameObject myLine = new GameObject();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
		lr.startColor = (new Color(.5F, .5F, .5F, 0.2F));
		lr.endColor = (new Color(.8F, .8F, .8F, 0.8F));
		GameObject.Destroy(myLine, duration);
		lr.widthMultiplier = 0.01f * bulletwidth;
		lr.sortingOrder = 2;
	}

	void Shoot ()
	{
		
		Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		var recoilPos = mousePos + Random.insideUnitCircle * .15f;
		Vector2 firePointPosition = GameObject.FindWithTag ("guntip").transform.position;
			//gameObject.GetComponentInChildren<Transform>().position; //(transform.position);

		if (canshoot)
		{
			Ray2D r = new Ray2D(firePointPosition, recoilPos - firePointPosition);
			Vector2 rangedist = r.GetPoint(range);
			Vector2 gunldist = r.GetPoint (0.15f);
			RaycastHit2D hit = Physics2D.Raycast (firePointPosition, recoilPos - firePointPosition, range);

			//if (Physics2D.Raycast(firePointPosition,recoilPos - firePointPosition,range))   IF THE OTHER ONE WORKS DELETE THIS
			if (hit.collider != null)
			{
				GameObject hitobject = hit.transform.gameObject;
				float hitdist = Vector2.Distance (firePointPosition, (Vector2)hitobject.transform.position);

				if ((hit) && hitobject.tag == "Wall" || hitobject.tag == "Enemy") //TESTING, was working::    hitobject.tag == "Wall" || hitobject.tag == "Enemy"
				{
					Vector2 hitobjectdist = r.GetPoint (hitdist);
					DrawLine (firePointPosition, hitobjectdist, Color.white, 0.02f);
					Debug.Log ("Player Hit : " + hitobject.transform.name);

					if (hitobject != null && hitobject.GetComponent<Rigidbody2D> () != null && hitobject.tag != "Wall")
					{
						hitobject.GetComponent<Rigidbody2D> ().position = Vector2.MoveTowards(hitobject.transform.position, player.transform.position, (-knockback/5));
						hitobject.GetComponent<HealthComponent>().takeDam(30);
						//hitobject.GetComponent<ZombieMovement> ().slowtoggle();
					}
				}

			}
			//if (hit.collider == null)
			else
			//if (!(Physics2D.Raycast(firePointPosition,recoilPos - firePointPosition,range)))
			{
				DrawLine (firePointPosition, rangedist, Color.white, 0.02f);
				Debug.Log ("Player Hit : Noothing ");
			}
			//hit.collider.name);
			Instantiate (gunlight, gunldist, Quaternion.identity);

		}




	}
}