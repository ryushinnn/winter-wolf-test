using System.Collections.Generic;
using UnityEngine;

public static class BoardResources {
    static GameObject prefabBg;
    static GameObject prefabItemView;
    static Queue<Cell> cells;
    static Queue<Transform> itemViews;

    static BoardResources() {
        prefabBg = Resources.Load<GameObject>(Constants.PREFAB_CELL_BACKGROUND);
        prefabItemView = Resources.Load<GameObject>(Constants.PREFAB_ITEM_VIEW);
        cells = new Queue<Cell>();
        itemViews = new Queue<Transform>();
    }

    public static Cell GetCell() {
        Cell c;
        if (cells.Count > 0) {
            c = cells.Dequeue();
        }
        else {
            c = GameObject.Instantiate(prefabBg).GetComponent<Cell>();
        }

        c.gameObject.SetActive(true);
        return c;
    }

    public static Transform GetItemView() {
        Transform v;
        if (itemViews.Count > 0) {
            v = itemViews.Dequeue();
        }
        else {
            v = GameObject.Instantiate(prefabItemView).transform;
        }

        v.gameObject.SetActive(true);
        return v;
    }

    public static void Return(Cell c) {
        c.gameObject.SetActive(false);
        cells.Enqueue(c);
    }
    
    public static void Return(Transform v) {
        v.gameObject.SetActive(false);
        itemViews.Enqueue(v);
    }
}