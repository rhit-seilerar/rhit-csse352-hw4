using System.Collections.Generic;
using UnityEngine;

public abstract class PurchasableManager<D, T> : GameUpdatable where T : ModifierPurchaseInfo where D : PurchasableDisplay<T>
{
    [SerializeField] GameObject prefab;
    List<GameObject> purchasables = new List<GameObject>();

    protected override void OnStart()
    {
        foreach (var upgrade in purchasables)
            Destroy(upgrade);
        
        purchasables.Clear();

        int i = 0;
        foreach (var info in GetInfos())
        {
            GameObject purchasable = Instantiate(prefab);
            purchasables.Add(purchasable);
            purchasable.name = GetName(i);
            purchasable.transform.SetParent(transform);
            purchasable.GetComponent<D>().Init(info, purchasable.name);
            i++;
        }
    }

    protected override void OnStop() { }
    protected override void OnUpdate() { }

    protected abstract string GetName(int index);
    protected abstract ICollection<T> GetInfos();
}
