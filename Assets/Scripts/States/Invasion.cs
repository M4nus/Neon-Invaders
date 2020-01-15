using UnityEngine;

public class Invasion : State
{
    public Invasion(GameController gameController) : base(gameController) {}


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
