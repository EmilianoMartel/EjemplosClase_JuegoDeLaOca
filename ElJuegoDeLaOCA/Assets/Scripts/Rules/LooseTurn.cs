
using System;
using System.Linq;

public class LooseTurn : BoardRule
{
    private int[] rules;

    public LooseTurn(int[] rule)
    {
        rules = rule;
    }

    public override bool EsCompatible(int posicionJugador)
    {
        return rules.ToList().Contains(posicionJugador);
    }

    public override BoardRuleResult Accionar(int idJugador, int posicionJugador)
    {
        return new BoardRuleResult(posicionJugador, idJugador == 1, idJugador == 2, "y pierde un turno");
    }
}
