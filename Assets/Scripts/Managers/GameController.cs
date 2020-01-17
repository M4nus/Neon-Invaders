using UnityEngine;

public class GameController : MonoBehaviour
{
    private State currentState;

    public bool isPaused;
    public bool isInvasion;
    public bool isPreparing;
    public bool isIntro;
    public bool isDead;
    public bool isWon;
    public bool isSceneLoaded;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SetState(new Intro(this));
    }

    void Update()
    {
        currentState.Tick();
    }

    public void SetState(State state)
    {
        if(currentState != null)
            currentState.OnStateExit();

        currentState = state;

        if(currentState != null)
            currentState.OnStateEnter();
    }

}
