using UnityEngine;

namespace AsyncOperator.Extensions {
    public static class Extensions {
        public static Vector3 XZ( this Vector2 v ) => new Vector3( v.x, 0, v.y );
    }
}