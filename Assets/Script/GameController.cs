using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float groundSpeed;
    [SerializeField] GameSetting gs;


    // Start is called before the first frame update
    void Start()
    {
        gs=FindObjectOfType<GameSetting>();
    }

    
    // Update is called once per frame
    void Update()
    {
        //Run of ground
        transform.position = transform.position + Vector3.left * groundSpeed * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("SceneLimit"))
        {
            //get score
            gs.ScoreInscre();

            //Destroy object when touch SceneLimit
            Destroy(gameObject);
        }
    }
    
}
