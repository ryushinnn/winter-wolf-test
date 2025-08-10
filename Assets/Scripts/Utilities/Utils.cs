using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

public static class Utils {
    static NormalItem.eNormalType[] normalTypes;
    static NormalItem.eNormalType[] tmpBuffer;

    static Utils() {
        normalTypes = (NormalItem.eNormalType[])Enum.GetValues(typeof(NormalItem.eNormalType));
        tmpBuffer = new NormalItem.eNormalType[normalTypes.Length];
    }
    
    public static NormalItem.eNormalType GetRandomNormalType()
    {
        return normalTypes[URandom.Range(0, normalTypes.Length)];
    }

    public static NormalItem.eNormalType GetRandomNormalTypeExcept(NormalItem.eNormalType[] types)
    {
        int count = 0;
        foreach (NormalItem.eNormalType type in normalTypes) {
            bool valid = true;
            foreach (NormalItem.eNormalType t in types) {
                if (type == t) {
                    valid = false;
                    break;
                }
            }

            if (valid) {
                tmpBuffer[count++] = type;
            }
        }
        return tmpBuffer[URandom.Range(0, count)];
    }
}
