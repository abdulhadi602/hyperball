using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndCheck : MonoBehaviour
{
    public GameObject Gamemanager;
    private GameManager manager;
    public GameObject Ball;
    private StarCollection collection;
    public GameObject DeathAnimation;
    public GameObject CanvasWithBackGroundMusic;
    private void Start()
    {
        manager = Gamemanager.GetComponent<GameManager>();
        collection = Ball.GetComponent<StarCollection>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanvasWithBackGroundMusic.GetComponent<AudioSource>().Stop();
            Ball.GetComponent<AudioSource>().Stop();
            GameObject.Instantiate(DeathAnimation, new Vector3(collision.transform.position.x,-5, 0), Quaternion.identity);
            StartCoroutine(EndGame(2));
        }
        else if (collision.CompareTag("Star"))
        {
            collection.SpawnStar();
        }
    }
    private IEnumerator EndGame(int sec)
    {
        yield return new WaitForSeconds(sec);
        manager.GameOver();
    }
}
