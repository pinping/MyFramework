using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Function {

    /// <summary>
    /// Function percent.
    /// </summary>
    public static class FunctionPercent {
        // 百分比 (1-100)
        public static bool Percent(int percent) {
            return Random.Range(0,100) <= percent;
        }
    }
}

