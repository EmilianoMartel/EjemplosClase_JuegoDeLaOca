using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Game : MonoBehaviour
{
    [SerializeField] private TMP_Text labelCurrentPlayer;
    [SerializeField] private TMP_Text labelWhatHappened;
    [SerializeField] private Board board;
    [SerializeField] private TMP_Text labelDiceResult;
    [SerializeField] private LevelSelection levelSelection;

    private Player player1 = new Player(1, 1);
    private Player player2 = new Player(2, 1);
    private BoardDataConverter boardDataConverter = new();

    private List<Player> _players;

    private int turno = 1;
    private bool done = false;

    private int diceResult = 0;
    private bool waitingForDice = false;

    private List<BoardRule> tablero = new List<BoardRule>();

    private void OnEnable()
    {
        levelSelection.sendData += Initialize;
    }

    private void OnDisable()
    {
        levelSelection.sendData -= Initialize;
    }

    public void Initialize(BoardData tableroTemp)
    {
        tablero = boardDataConverter.BoardRules(tableroTemp);
        labelCurrentPlayer.text = "";
        labelWhatHappened.text = "";
        labelDiceResult.text = "?";

        turno = 1;
        done = false;
        StartCoroutine(PlayTurn());
    }

    private IEnumerator PlayTurn()  // ---> TAREA: Refactorear este método para que sea mas "clean code"
    {
        diceResult = 0;
        labelWhatHappened.text = "";
        
        if (turno == 1)
        {
            yield return StartCoroutine(Trun(player1));
            turno = 2;
        }
        else
        {
            yield return StartCoroutine(Trun(player2));
            turno = 1;
        }

        yield return StartCoroutine(GameOverCheck());
    }

    private IEnumerator Trun(Player player)
    {
        labelCurrentPlayer.text = player.playerID.ToString();
        if (!player.playerLooseTurn)
        {
            yield return StartCoroutine(WaitForDice());

            player.playerPosition = Math.Min(36, player.playerPosition + diceResult);
            labelWhatHappened.text = "Sacó un " + diceResult.ToString() + " y se mueve al casillero nro " + player.playerPosition.ToString();
            board.MovePlayerToCell(turno, player.playerPosition);
            yield return new WaitForSeconds(1);

            player.playerPosition = CheckWhatHappens(player);
            board.MovePlayerToCell(turno, player.playerPosition);
        }
        else
        {
            labelWhatHappened.text = "había perdido el turno - no juega";
            player.playerLooseTurn = false;
        }
        done = player.playerPosition == 36;
    }

    private IEnumerator WaitForDice()
    {
        waitingForDice = true;
        while (diceResult == 0)
        {
            yield return new WaitForEndOfFrame();
        }
        waitingForDice = false;
    }

    private int CheckWhatHappens(Player player)
    {
        BoardRuleResult result = new BoardRuleResult(player.playerPosition);

        foreach (var regla in tablero)
        {
            if (regla.EsCompatible(player.playerPosition))
                result = regla.Accionar(player.playerID, player.playerPosition);
        }

        player1.playerLooseTurn = player1.playerLooseTurn || result.jugador1PierdeTurno;
        player2.playerLooseTurn = player2.playerLooseTurn || result.jugador2PierdeTurno;

        labelWhatHappened.text += result.textWhatHappened;

        return result.newPosition;
    }

    public void OnDiceRoll()
    {
        if (!waitingForDice)
            return;

        System.Random r = new System.Random();

        int resultado = r.Next(1, 7);
        labelDiceResult.text = resultado.ToString();

        diceResult = resultado;
    }

    private IEnumerator GameOverCheck()
    {
        if (done)
        {
            if (player1.playerPosition == 36)
                labelWhatHappened.text = "Gana el jugador 1 - fin del juego";
            else
                labelWhatHappened.text = "Gana el jugador 2 - fin del juego";
        }
        else
        {
            yield return new WaitForSeconds(2);
            StartCoroutine(PlayTurn());
        }
    }
}
