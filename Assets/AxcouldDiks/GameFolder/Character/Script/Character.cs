using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int life;
    public Transform sprite;
    public Transform cam;

    public Text heartCountText;

    public AudioClip bossBattleMusic;
    public AudioClip youWin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(life <= 0 && !transform.name.Equals("BossBrain"))
        {
            sprite.GetComponent<Animator>().Play("Die", -1);
        }

        if (transform.CompareTag("Player"))
        {
            heartCountText.text = "x" + life.ToString();

            if (SceneManager.GetActiveScene().name.Equals("Level5"))
            {
                cam.GetComponent<Animator>().enabled = false;
                cam.GetComponent<Camera>().orthographicSize = 11.4f;
                cam.position = new Vector3(7.9f, 5.5f, -1);
                cam.parent = null;
                SceneManager.MoveGameObjectToScene(cam.gameObject, SceneManager.GetActiveScene());

                if(GameObject.Find("BossBrain").GetComponent<Character>().life > 0)
                {
                    if(cam.GetComponent<AudioSource>().clip != bossBattleMusic)
                    {
                        cam.GetComponent<AudioSource>().clip = bossBattleMusic;
                        cam.GetComponent<AudioSource>().Play();
                    }                  
                }
                else
                {

                    GameObject.Find("YouWin").GetComponent<GameOver>().enabled = true;
                    GetComponent<PlayerControler>().enabled = false;
                    GetComponent<CapsuleCollider2D>().enabled = false;
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

                    if (cam.GetComponent<AudioSource>().clip != null)
                    {
                        cam.GetComponent<AudioSource>().Stop();

                        cam.GetComponent<AudioSource>().clip = null;
                        cam.GetComponent<AudioSource>().PlayOneShot(youWin);
                    }
                }
                
            }
        }

        if (transform.name.Equals("BossBrain"))
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(1.78f, (life * 1.09f / 30f) );
            if(life <= 0)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }

    }

    public void PlayerDamage(int value)
    {
        life = life - value;
        sprite.GetComponent<Animator>().Play("PlayerDamage", 1);
        cam.GetComponent<Animator>().Play("Camera", -1);
        GetComponent<PlayerControler>().audioSource.PlayOneShot(GetComponent<PlayerControler>().damageSound, 0.3f);
    }
}
