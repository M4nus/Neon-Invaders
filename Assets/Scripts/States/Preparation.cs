using UnityEngine;

public class Preparation : State
{
    public Preparation(GameController gameController) : base(gameController) {}
    

    public override void Tick()
    {
        if(!gameController.isSceneLoaded)
        {
            GameObject.Find("Enemies").GetComponent<WaveSpawner>().Spawn();
            GameObject.Find("GameManager").GetComponent<UIFunctionalities>().Wave(true);
            gameController.isSceneLoaded = true;
        }
        if(Input.GetKeyDown(KeyCode.Space))
            gameController.SetState(new Invasion(gameController));
    }

    public override void OnStateEnter()
    {
        gameController.isSceneLoaded = false;
        gameController.isPreparing = true;
        Time.timeScale = 0f;
    }

    public override void OnStateExit()
    {
        gameController.isPreparing = false;
        GameObject.Find("GameManager").GetComponent<UIFunctionalities>().Wave(false);
        Time.timeScale = 1f;
    }
}
