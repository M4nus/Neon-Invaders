using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : State
{
    public Intro(GameController gameController) : base(gameController) {}
    

    public override void Tick()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
            gameController.SetState(new Preparation(gameController));
        }
    }

    public override void OnStateEnter()
    {
        gameController.isIntro = true;
    }

    public override void OnStateExit()
    {
        gameController.isIntro = false;
    }
}
