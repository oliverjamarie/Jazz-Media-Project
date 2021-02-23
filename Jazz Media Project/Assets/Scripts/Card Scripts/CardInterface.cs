using UnityEngine.UI;

public interface CardInterface
{
    void effect(Unit playedBy, Unit target);
    Text getCardTitle();
    Text getCardDesc();
    int getCardCost();
}
