using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Animator p_Animator;
	Rigidbody2D rb;
	[Header("Player System")]
	public float speed = 1f;
	public float jumpPower = 1.5f;
	[Header("Game System")]
	public int maxPoint = 20;
	public float maxTime = 60;
	[Header("UI")]
	public Text timerText;
	public Image timerImage;
	public Text pointText;

	int point;
    float t; /////////////// เป็นตัวแปรเวลา ///////////////////

	bool onPlatform;
	bool isStop;
	Vector2 reset_pos;

	// Use This For Initialization
	void Start () {
		reset_pos = transform.position;
		p_Animator = gameObject.GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		isStop = false;
		reset_pos = transform.position;
		point = maxPoint;

		if (pointText != null) pointText.text = "" + point;
		if (timerText != null) timerText.text = t.ToString("N0");
		t = maxTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isStop) SunnyController();
	}

    void Update()
    {
        if (!isStop)
        {
            Timer();
            Jump();
        }

		if (Input.GetKeyDown(KeyCode.R)) Application.LoadLevel(0);
		if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
	}

	void Timer()
    {
		if( t >= 0){
			t = t - Time.deltaTime;
			if (timerText != null) timerText.text = t.ToString("N0");
			if (timerImage != null) timerImage.fillAmount = t * 1 / maxTime;
		}else{
			isStop = true;
			if (timerText != null) timerText.text = "Game Over";
		}
	}

	void SunnyController()
    {
		if (Input.GetKey(KeyCode.D)) 
		{
			p_Animator.SetBool("run", true);
			transform.position += Vector3.right * speed * Time.deltaTime;
			GetComponent<SpriteRenderer>().flipX = false;
		}
		else if (Input.GetKey(KeyCode.A)) 
		{
			p_Animator.SetBool("run", true);
			GetComponent<SpriteRenderer>().flipX = true;
			transform.position -= Vector3.right * speed * Time.deltaTime;
		}
		else
		{
			p_Animator.SetBool("run", false);
			transform.Translate(new Vector2(0, 0));
		}
	}

	void Jump()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !onPlatform)
		{
			p_Animator.SetBool("jump_up", false);
			p_Animator.SetBool("jump_down", true);
		} 
         
        if (Input.GetKeyDown(KeyCode.Space) && onPlatform)
		{
            p_Animator.SetBool("jump_up", true);
			rb.velocity = new Vector2(0, jumpPower);
            onPlatform = false;
        }
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if(c.gameObject.tag == "Platform")
        {
			p_Animator.SetBool("jump_up", false);
			p_Animator.SetBool("jump_down", false);
			onPlatform = true;
		}
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Fail")
		{
			transform.position = reset_pos;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<Rigidbody2D>().angularVelocity = 0;
		}

		if (c.gameObject.tag == "Door")
        {
			if (point <= 0)
			{
				isStop = true;
				if (pointText != null) pointText.text = "Win";
				p_Animator.SetBool("run", false);
			}
        }

		if (c.gameObject.tag == "Point")
		{
			point--;
			if (pointText != null) pointText.text = "" + point;
			Destroy(c.gameObject);
		}
	}
}
