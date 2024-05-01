using System;

public class BoardRule
{
    public virtual bool EsCompatible(int posicionJugador)
    {
        throw new NotImplementedException();
    }

    public virtual BoardRuleResult Accionar(int idJugador, int posicionJugador)
    {
        throw new NotImplementedException();
    }
}
