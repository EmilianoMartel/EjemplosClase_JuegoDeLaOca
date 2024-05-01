
using System.Collections.Generic;
using System.Linq;

public class GoForward : BoardRule
{
    private Dictionary<int, int> rules;

    public GoForward(Dictionary<int,int> rule)
    {
        rules = rule;
    }

    public override bool EsCompatible(int posicionJugador)
    {
        return rules.ContainsKey(posicionJugador);
    }

    public override BoardRuleResult Accionar(int idJugador, int posicionJugador)
    {
        int nuevaPos = rules[posicionJugador];
        return new BoardRuleResult(nuevaPos, false, false, "y avanza al casillero " + nuevaPos);
    }
}
