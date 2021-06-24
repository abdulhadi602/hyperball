using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollection : MonoBehaviour
{
    // Start is called before the first frame update
    public int counter;
    public GameObject ScoreManager;
    private Score ScoreManagerSC;
    private GameObject Star;
    public GameObject StarEffect;

    public Vector3 BallScale;

    private new Rigidbody2D rigidbody;

    public GameObject SmileyFace, SadFace;
    void Start()
    {
        counter = 1;
        ScoreManagerSC = ScoreManager.GetComponent<Score>();
        Star = Resources.Load("Prefabs/star") as GameObject;


        rigidbody = GetComponent<Rigidbody2D>();
        BallScale = transform.localScale;
        EnableSmiley();


    }

    // Update is called once per frame
    void Update()
    {
        transform.up = Vector3.Slerp(transform.up, rigidbody.velocity.normalized, Time.fixedDeltaTime * 25);
       
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.collider.CompareTag("Line"))
        {
            StartCoroutine(StretchBall());
            gameObject.GetComponent<AudioSource>().Play();
          
        }
            
           
    }
    private void EnableSmiley()
    {
        if (!SmileyFace.activeSelf)
        {
            SmileyFace.SetActive(true);
            SadFace.SetActive(false);
        }
    }
    private void EnableSad()
    {
        if (!SadFace.activeSelf)
        {
            SmileyFace.SetActive(false);
            SadFace.SetActive(true);
        }
    }
    IEnumerator StretchBall()
    {
        EnableSad();
        transform.localScale = new Vector3(BallScale.x-0.2f, BallScale.y+0.2f, 0f);
        while (transform.localScale.x < BallScale.x && transform.localScale.y > BallScale.y)
        {
            transform.localScale =new Vector3(transform.localScale.x+0.01f,transform.localScale.y-0.01f,0);
            if(transform.localScale.x > 0.35f)
            {
                EnableSmiley();
            }
            yield return new WaitForSeconds(0.03f);
        }
     
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {

            ScoreManagerSC.IncrementScore(1);

           /** if (counter < 3)
            {

                for (int i = 0; i < counter; i++)
                {
                    SpawnStar();
                }
            }
            else
            {**/
                SpawnStar();
            //}
            counter++;
            
                GameObject effectwithsound = GameObject.Instantiate(StarEffect, collision.transform.position, Quaternion.identity);
                effectwithsound.GetComponent<AudioSource>().Play();
            
            Destroy(collision.gameObject);
        }
    }
    public void SpawnStar()
    {
        int x = Random.Range(-2, 2);
        int y = Random.Range(-2, 2);
        Instantiate(Star, new Vector2(x, y), Quaternion.identity);
    }
}
