using UnityEngine;

public class Invasion : State
{
    public Invasion(GameController gameController) : base(gameController) {}


    public override void Tick()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            gameController.SetState(new Pause(gameController));
        if(gameController.isWon)
        {
            GameObject.Find("GameManager").GetComponent<UIFunctionalities>().wave += 1;
            gameController.SetState(new Preparation(gameController));
        }
        if(gameController.isDead)
            gameController.SetState(new End(gameController));
    }

    public override void OnStateEnter()
    {
        gameController.isInvasion = true;
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemiesMovement>().canEnemiesMove = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().canControl = true;
        GameObject.Find("Enemies").GetComponent<EnemiesMovement>().ResetSpeed();
    }

    public override void OnStateExit()
    {
        gameController.isInvasion = false;
        gameController.isWon = false;
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemiesMovement>().canEnemiesMove = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().canControl = false;
    }
}
