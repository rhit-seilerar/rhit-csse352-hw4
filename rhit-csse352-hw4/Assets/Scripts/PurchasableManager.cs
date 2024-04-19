using System.Collections.Generic;
using UnityEngine;

public abstract class PurchasableManager<D, T> : MonoSingleton<PurchasableManager<D, T>> where T : ModifierPurchaseInfo where D : PurchasableDisplay<T>
{
    [SerializeField] GameObject prefab;
    List<D> purchasables = new List<D>();

    protected virtual void Start()
    {
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Start, OnStart);
    }

    protected virtual void OnStart()
    {
        foreach (var purchasable in purchasables)
            Destroy(purchasable.gameObject);
        purchasables.Clear();

        int i = 0;
        foreach (var info in GetInfos())
        {
            GameObject purchasable = Instantiate(prefab);
            purchasables.Add(purchasable.GetComponent<D>());
            purchasable.name = GetName(i);
            purchasable.transform.SetParent(transform);
            purchasable.GetComponent<D>().Init(info, $"Textures/{purchasable.name}");
            i++;
        }
    }

    public void RemovePurchasable(D purchasable)
    {
        purchasables.Remove(purchasable);
        Destroy(purchasable.gameObject);
    }

    protected abstract string GetName(int index);
    protected abstract ICollection<T> GetInfos();
}
