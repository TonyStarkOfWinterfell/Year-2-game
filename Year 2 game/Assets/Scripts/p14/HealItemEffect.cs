using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Heal")]
public class HealItemEffect : UsableItemEffect
{
    public int HealthAmount;

    public override void ExecuteEffect(UsableItem usableItem, Character character)
    {
        //character.Health += HealthAmount;
    }
   
}
