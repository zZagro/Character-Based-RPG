using Sirenix.OdinInspector;
using UnityEngine;

namespace CombatSystem
{
    [TypeInfoBox("Placeholder class to represent an attackable entity")]
    public class Health : MonoBehaviour
    {
        [SerializeField] private int health = 100;

        public void TakeDamage(float damage)
        {
            health -= Mathf.RoundToInt(damage);
        }

        public void Heal(float amount)
        {

        }
    }
}