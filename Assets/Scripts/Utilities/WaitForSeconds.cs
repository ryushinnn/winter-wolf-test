using System.Collections.Generic;
using UnityEngine;

public static class BetterWaitForSeconds {
    class WaitForSecond : CustomYieldInstruction {
        float waitUntil;

        public override bool keepWaiting {
            get {
                if (Time.time < waitUntil) return true;

                pool.Push(this);
                return false;
            }
        }

        public void Initialize(float seconds) {
            waitUntil = Time.time + seconds;
        }
    }

    static readonly Stack<WaitForSecond> pool;
    
    const int POOL_INITIAL_SIZE = 3;
    
    static BetterWaitForSeconds() {
        pool = new Stack<WaitForSecond>(POOL_INITIAL_SIZE);
        for (int i = 0; i < POOL_INITIAL_SIZE; i++) {
            pool.Push(new WaitForSecond());
        }
    }

    public static CustomYieldInstruction Wait(float seconds) {
        WaitForSecond w;
        if (pool.Count > 0) {
            w = pool.Pop();
        }
        else {
            w = new WaitForSecond();
        }

        w.Initialize(seconds);
        return w;
    }
}