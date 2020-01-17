using UnityEngine;

public class End : State
{
    public End(GameController gameController) : base(gameController) { }


    public override void Tick()
    {
        if(gameController.isPreparing)
            gameController.SetState(new Preparation(gameController));
    }

    public override void OnStateEnter()
    {
        gameController.isDead = true;
        GameObject.Find("GameManager").GetComponent<UIFunctionalities>().Dead(true);
        Time.timeScale = 0f;
    }

    public override void OnStateExit()
    {
        gameController.isDead = false;
        GameObject.Find("GameManager").GetComponent<UIFunctionalities>().Dead(false);
        GameObject.Find("GameManager").GetComponent<UIFunctionalities>().wave = 1;
        Time.timeScale = 1f;
    }
}
