using CombatSystem.Utilities;
using UnityEngine;

namespace CombatSystem
{
    [CreateAssetMenu(menuName = "Custom/Combat/On Hit Effect")]
    public class OnHitEffect : ActionList<OnHitComponent, IOnHitBehavior>
    {

    }
}
