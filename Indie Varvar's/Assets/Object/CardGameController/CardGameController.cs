using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CardGameController : Singleton<CardGameController>
{
    public static UnityEvent StartTurnEvent = new UnityEvent();

    public static UnityEvent FinishTurnEvent = new UnityEvent();

    public static UnityEvent EnemyTurnEvent = new UnityEvent();

    public static UnityEvent AfterEnemyTurnEvent = new UnityEvent();

    [SerializeField] private Player _player;
    [SerializeField] private EnemyBoardController _enemyBoard;
    [SerializeField] private DeckController _deck;
    [SerializeField] private PlayerHandController _hand;

    private TurnPhase _phase;
    private void Start()
    {
        //LoadGame
        StartTurn();
    }

    private void StartTurn()
    {
        _phase = TurnPhase.STARTING;
        Debug.Log(2);
        StartTurnEvent.Invoke();

        StartCoroutine(GoToNextTurnPhase());
    }

    private void PassTurnToPlayer()
    {
        _phase = TurnPhase.PLAYER_TURN;



        //StartCoroutine(GoToNextTurnPhase());
    }

    private void FinishTurn()
    {
        _phase = TurnPhase.FINISHING;

        FinishTurnEvent.Invoke();

        StartCoroutine(GoToNextTurnPhase());
    }

    private void EnemyTurn()
    {
        _phase = TurnPhase.ENEMY_TURN;

        EnemyTurnEvent.Invoke();

        StartCoroutine(GoToNextTurnPhase());
    }

    private void AfterEnemyTurn()
    {
        _phase = TurnPhase.ENEMY_TURN;

        AfterEnemyTurnEvent.Invoke();

        StartCoroutine(GoToNextTurnPhase());
    }

    private IEnumerator GoToNextTurnPhase()
    {
        yield return new WaitForSeconds(3);
        switch (_phase)
        {
            case TurnPhase.STARTING:
                PassTurnToPlayer();
                break;
            case TurnPhase.PLAYER_TURN:
                FinishTurn();
                break;
            case TurnPhase.FINISHING:
                EnemyTurn();
                break;
            case TurnPhase.ENEMY_TURN:
                AfterEnemyTurn();
                break;
            case TurnPhase.After_Enemy_Turn:
                StartTurn();
                break;
            default:
                StartTurn();
                break;
        }
    }

    public Player Player
    {
        get
        {
            return _player;
        }
    }

    public EnemyBoardController EnemyBoard
    {
        get
        {
            return _enemyBoard;
        }
    }

    public DeckController Deck
    {
        get
        {
            return _deck;
        }
    }

    public PlayerHandController Hand
    {
        get
        {
            return _hand;
        }
    }
}

enum TurnPhase
{
    STARTING,
    PLAYER_TURN,
    FINISHING,
    ENEMY_TURN,
    After_Enemy_Turn
}

