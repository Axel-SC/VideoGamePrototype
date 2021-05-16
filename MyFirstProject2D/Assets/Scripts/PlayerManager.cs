using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float life = 100;
    public Rigidbody2D RBD;

    public Image Corazon;
    public int numCorazones;
    public RectTransform posicionPrimerCorazon;
    public Canvas myCanvas;
    public int offSet;
    public Transform positionHeart;
    public Animator animator;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Transform posCorazon = positionHeart;
        posCorazon.position = posicionPrimerCorazon.position;
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < numCorazones-1; i++)
        {
            posCorazon.position = new Vector2(posCorazon.position.x + offSet, posCorazon.position.y);
            Image newCorazon = Instantiate(Corazon, posCorazon.position, Quaternion.identity);
            newCorazon.transform.parent = myCanvas.transform;
            newCorazon.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
   
        if (numCorazones<=0)
        {
            Destroy(gameObject);
            Destroy(Corazon);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            Destroy(myCanvas.transform.GetChild(numCorazones).gameObject);
            numCorazones -= 1;
            animator.SetBool("hit", true);
            audioSource.Play();
        }
        if (collision.gameObject.tag == "Water")
        {
            Destroy(gameObject);
            Destroy(Corazon);
        }     
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Skeleton"))
        {
            Destroy(myCanvas.transform.GetChild(numCorazones).gameObject);
            numCorazones -= 1;
            animator.SetBool("hit", true);
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            gameObject.transform.parent = other.gameObject.transform;
        }
        else
        {
            gameObject.transform.parent = null;
        }
        
    }
}
