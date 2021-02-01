using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public GameObject kamor;
    public LayerMask whatStopsMov;
    public LayerMask pushing;
    public LayerMask nowy;
    public int kamyczki2;
    float lastx;
    float lasty;
    private Vector3 last;
    public GameObject kamor1;
    public GameObject kamor2;
    private int ruchy;
    public GameObject ruszki;
    public Animator transition;
    public float transT = 1f;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        ruchy = 15;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        
        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        { 

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 0f)
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMov))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        ruchy--;
                        Debug.Log(ruchy);


                    }
                    last = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
                }


                    if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 0f)
                        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                        {
                            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMov))
                            {
                                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        ruchy--;
                        Debug.Log(ruchy);

                    }
                         last = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
                }

        }

        ruszki.GetComponent<Text>().text = ruchy.ToString("F0");
        if (ruchy <= 0)
        {
            // transition.SetTrigger("restart");
            // SceneManager.LoadScene("SampleScene");
            RestartLvl();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "kamor")
        {
            movePoint.position -= last;
        }
        else if (collision.tag == "kolce")
        {
            ruchy--;
        }

    }
    public void RestartLvl()
    {

        StartCoroutine(LoadLvl(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLvl(int levelIndex)
    {

        transition.SetTrigger("restart");


        yield return new WaitForSeconds(transT);

        SceneManager.LoadScene("SampleScene");

    }


}
