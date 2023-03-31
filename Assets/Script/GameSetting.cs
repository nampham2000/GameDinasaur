using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetting : MonoBehaviour
{


    [SerializeField]
    private GameObject Enemy;
    int score;
    bool gameover;
    [SerializeField] UIManager ui;
    [SerializeField] DinasourController dina;

    // Start is called before the first frame update
    void Start()
    {
        ui.SetScoreText("Score: " + score);
        ui.gameoverPanel.SetActive(false);

        StartCoroutine(SpwanEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        //Gameover(Stop spawn)
        if(gameover)
        {
            ui.ShowGameOverPanel(true);
            return;
        }

    }

    //Spawn Enemy
    IEnumerator SpwanEnemy() 
    {
        yield return new WaitForSeconds(2f);
        Vector2 pos = Enemy.transform.position;
        pos.x = Random.Range(11f,17f);
        Instantiate(Enemy, pos, Quaternion.identity);
        StartCoroutine(SpwanEnemy());
    }
    
    
    public void replay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void menu()
    {
        SceneManager.LoadScene("MenuScene");
    }



    public void SetScore(int value)
    {
        score = value;
    }
    
    
    public int GetScore() 
    { 
        return score;
    }

    
    public void ScoreInscre()
    {
        if(gameover)
        {
            return;
        }    
        score++;
        ui.SetScoreText("Score:" + score);
    }

   
    
    public bool IsGameOver() 
    {
        return gameover;
    }

    public void SetGameOverStage(bool stae) 
    { 
        gameover = stae;
    }

}
