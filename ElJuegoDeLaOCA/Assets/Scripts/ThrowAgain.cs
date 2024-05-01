
using System.Linq;

public class ThrowAgain : BoardRule
{
    private int[] rules;

    public ThrowAgain(int[] boardNum)
    {
        rules = boardNum;
    }

    public override bool EsCompatible(int posicionJugador)
    {
        return rules.ToList().Contains(posicionJugador);
    }

    public override BoardRuleResult Accionar(int idJugador, int posicionJugador)
    {
        return new BoardRuleResult(posicionJugador, idJugador == 2, idJugador == 1, "y tira de nuevo");
    }
}