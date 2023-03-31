using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinasourController : MonoBehaviour
{
    private  Rigidbody2D dinasour;
    private  Vector3 direction;
    private Animator ani;
    float time;
    [SerializeField]  private bool checkjump;
    [SerializeField]  private bool checkground;

    
    
    GameSetting lose;

    [SerializeField] public AudioSource AudioSo;

    [SerializeField] public AudioClip jumpSound;
    [SerializeField] public AudioClip loseSound;
  

    private void Awake()
    {
        dinasour = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        
    }

    IEnumerator speedup()
    {
        
        yield return new WaitForSeconds(10f);
        Time.timeScale += 0.5f;
        StartCoroutine(speedup());
        
    }

    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        lose=FindObjectOfType<GameSetting>();
        StartCoroutine(speedup());
    }

    // Update is called once per frame
    void Update()
    {
        //tinh luc va dieu kien de khung long nhay

         
        bool isjump = Input.GetKeyDown(KeyCode.Space);
        if (isjump && checkground == true )
        {
            if (isjump == true)
            {
                dinasour.AddForce(Vector3.up * 600);
                checkground = false;
                ani.SetBool("isjump", true);

                if(AudioSo && jumpSound)
                {
                    AudioSo.PlayOneShot(jumpSound);
                }
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {

            checkground = true;
            ani.SetBool("isjump", false);
            
        }
        else
        {
            
        }

        
        
        if(collision.gameObject.tag=="Enemy")
        {
            if (AudioSo && loseSound && !lose.IsGameOver())
            {
                AudioSo.PlayOneShot(loseSound);
                Time.timeScale = 0f;
            }
            lose.SetGameOverStage(true);

            
        }
    }

    public void Offmusic()
    {
        AudioSo.Stop();
    }
    
    public void Onmusic()
    {
        AudioSo.Play();
    }    


    


}
