using UnityEngine;

public class Pause : State
{
    public Pause(GameController gameController) : base(gameController) {}


    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}
