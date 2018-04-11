using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int CurrentHP = 3;
    public int MaxHP = 3;
    public delegate void Death();
    public Death OnDeath;
    public delegate void OnDamaged();
    public OnDamaged OnDamage;
    public void TakeDamage(int amount)
    {
        CurrentHP -= amount;
        OnDamage.Invoke();
        if (CurrentHP <= 0)
        {
            OnDeath.Invoke();
            //ON DEATH INVOKE
        }
    }
    public void Heal(int amount)
    {
        CurrentHP += amount;
        if (CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        }
    }
}
