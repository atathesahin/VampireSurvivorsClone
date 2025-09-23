using UnityEngine;

public class ExpItem : BaseItem
{
    [SerializeField] private int experience;

    protected override void OnItemEvent(PlayerStats playerStats)
    {
        playerStats.CurrentExperience += experience;
    }
}
