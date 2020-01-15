public abstract class State
{
    protected GameController gameController;

    public abstract void Tick();

    public virtual void OnStateEnter() {}
    public virtual void OnStateExit() {}

    public State(GameController gameController)
    {
        this.gameController = gameController;
    }
}
