using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{

	bool isRewinding = false;
	public static bool rewind;
	float recordTime = 120f;
	public PlayerController player;
	public List<PointInTime> pointsInTime;

	Rigidbody2D rb;

	// Use this for initialization
	void Start()
	{
		rewind = false;
		pointsInTime = new List<PointInTime>();
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update()
	{
		if (rewind)
			StartRewind();
	}

	void FixedUpdate()
	{
		if (isRewinding)
			Rewind();
		else
			Record();
	}

	void Rewind()
	{
		if (pointsInTime.Count > 0)
		{
			PointInTime pointInTime = pointsInTime[0];
			
            switch (gameObject.tag)
            {
				case "Player":
					GetComponent<SpriteRenderer>().flipX = pointInTime.b1;
					transform.position = pointInTime.position;
					break;
				case "Goomba":
					GetComponent<GoombaScript>().alive = pointInTime.b1;
					transform.position = pointInTime.position;
					break;
				case "Dispenser":
					GetComponent<DispenserScript>().open = pointInTime.b1;
					break;
				case "Button":
					GetComponent<ButtonScript>().forcePressed = pointInTime.b1;
					break;
				case "Invader":
					GetComponent<InvaderScript>().visible = pointInTime.b1;
					break;
				case "Bullet":
					GetComponent<SpriteRenderer>().enabled = pointInTime.b1;
					transform.position = pointInTime.position;
					break;
				case "Crate":
					GetComponent<Pushable>().inDispenser = pointInTime.b1;
					transform.position = pointInTime.position;
					break;
				case "Rocket":
					GetComponent<SpriteRenderer>().enabled = pointInTime.b1;
					transform.position = pointInTime.position;
					break;
				case "Heart":
					GetComponent<SpriteRenderer>().enabled = pointInTime.b1;
					break;
                //case "Cover":
                //    GetComponent<Animator>().SetBool("open", pointInTime.b1);
                //    break;
                case "Boss":
					GetComponent<Animator>().SetBool("pressed", pointInTime.b1);
					break;
				default:
					transform.position = pointInTime.position;
					break;
            }
            pointsInTime.RemoveAt(0);
		}
		else
		{
			StopRewind();
		}

	}

	void Record()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			player.dead = true;
			//pointsInTime.RemoveAt(pointsInTime.Count - 1);
			
		}

		bool b1 = false;
		switch (gameObject.tag)
		{
			case "Player":
				b1 = GetComponent<SpriteRenderer>().flipX;
				break;
			case "Goomba":
				b1 = GetComponent<GoombaScript>().alive;
				break;
			case "Dispenser":
				b1 = GetComponent<DispenserScript>().open;
				break;
			case "Button":
				b1 = GetComponent<ButtonScript>().pressed;
				break;
			case "Invader":
				b1 = GetComponent<SpriteRenderer>().enabled;
				break;
			case "Bullet":
				b1 = GetComponent<SpriteRenderer>().enabled;
				break;
			case "Crate":
				b1 = GetComponent<Pushable>().inDispenser;
				break;
			case "Rocket":
				b1 = GetComponent<SpriteRenderer>().enabled;
				break;
			case "Heart":
				b1 = GetComponent<SpriteRenderer>().enabled;
				break;
            //case "Cover":
            //    b1 = GetComponent<Animator>().GetBool("open");
            //    break;
            case "Boss":
				b1 = GetComponent<Animator>().GetBool("pressed");
				break;
			default:
				break;
		}

		pointsInTime.Insert(0, new PointInTime(transform.position, b1));
	}

	public void StartRewind()
	{
		if(GameObject.Find("Music") && !isRewinding)
        {
			GameObject.Find("Music").GetComponent<Animator>().SetBool("rewind", false);
        }
		isRewinding = true;
		if (rb && !rb.isKinematic)
		{
			rb.simulated = false;
		}
		if (gameObject.tag == "Player")
        {
			GetComponent<PlayerController>().locked = true;
        }
	}

	public void StopRewind()
	{
		//isRewinding = false;
		//if(rb && !rb.isKinematic)
  //      {
		//	rb.simulated = true;
		//}
		
		if (gameObject.tag == "Player")
		{
			Debug.Log("Stopped Rewind");
			//GetComponent<PlayerController>().locked = true;
			rb.simulated = true;
			GetComponent<PlayerController>().exit = true;

		}

	}

	//public void ToggleRewind()
	//{
	//	isRewinding = !isRewinding;
	//	if(rb && !rb.isKinematic)
 //       {
 //           rb.simulated = !rb.simulated;
 //       }
	//	if (gameObject.tag == "Player")
	//	{
	//		GetComponent<PlayerController>().locked = !GetComponent<PlayerController>().locked;
	//	}
	//}
}