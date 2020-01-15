public abstract class State
{
    protected GameController gameController;

    // Update of every state
    public abstract void Tick();

    public virtual void OnStateEnter() {}
    public virtual void OnStateExit() {}

    public State(GameController gameController)
    {
        this.gameController = gameController;
    }
}
