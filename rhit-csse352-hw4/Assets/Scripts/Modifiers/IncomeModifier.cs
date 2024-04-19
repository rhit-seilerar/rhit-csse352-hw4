using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeModifier : IGameModifier
{
    readonly float income;

    public IncomeModifier(float income)
    {
        this.income = income;
    }

    public void Apply(ModifierInfo info)
    {
        info.passiveIncome += income;
    }

    public override string ToString()
    {
        return $"<color={GameManager.MONEY_COLOR}>+${income:n1} per Second</color>";
    }
}
