using UnityEngine;

public class Pause : State
{
    public Pause(GameController gameController) : base(gameController) {}


    public override void Tick()
    {
        if(gameController.isInvasion)
            gameController.SetState(new Invasion(gameController));
    }

    public override void OnStateEnter()
    {
        gameController.isPaused = true;
        GameObject.Find("GameManager").GetComponent<UIFunctionalities>().Pause(true);
        Time.timeScale = 0f;
    }

    public override void OnStateExit()
    {
        gameController.isPaused = false;
        GameObject.Find("GameManager").GetComponent<UIFunctionalities>().Pause(false);
        Time.timeScale = 1f;
    }
}
