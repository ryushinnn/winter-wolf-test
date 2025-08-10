using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemViewDB", fileName = "ItemViewDB")]
public class ItemViewDB : ScriptableObjectSingleton<ItemViewDB> {
    [SerializeField] NormalItemView[] normalItemViews;
    [SerializeField] BonusItemView[] bonusItemViews;
    
    Dictionary<NormalItem.eNormalType, Sprite> cachedNormalItemViews = new Dictionary<NormalItem.eNormalType, Sprite>();
    Dictionary<BonusItem.eBonusType, Sprite> cachedBonusItemViews = new Dictionary<BonusItem.eBonusType, Sprite>();

    public Sprite GetNormalItemView(NormalItem.eNormalType type) {
        if (!cachedNormalItemViews.ContainsKey(type)) {
            cachedNormalItemViews.Add(type, Array.Find(normalItemViews, x => x.type == type).sprite);
        }
        
        return cachedNormalItemViews[type];
    }

    public Sprite GetBonusItemView(BonusItem.eBonusType type) {
        if (!cachedBonusItemViews.ContainsKey(type)) {
            cachedBonusItemViews.Add(type, Array.Find(bonusItemViews, x => x.type == type).sprite);
        }

        return cachedBonusItemViews[type];
    }
}

[Serializable]
public class NormalItemView {
    public NormalItem.eNormalType type;
    public Sprite sprite;
}

[Serializable]
public class BonusItemView {
    public BonusItem.eBonusType type;
    public Sprite sprite;
}