//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace Sparrow.Component
{
    /// <summary>
    /// 抽象基础绘图类
    /// </summary>
    public abstract class DrawBase
    {

        /// <summary>
        /// 本次绘制记录颜色
        /// </summary>
        public abstract Color Color { get; set; }

        /// <summary>
        /// 绘制的宽度
        /// </summary>
        public float LineWidth = 0.001f;

        /// <summary>
        /// 绘制图形事件
        /// </summary>
        internal abstract void OnDrawGraph();

        /// <summary>
        /// 绘制图形
        /// </summary>
        public abstract void DrawGraph();
    }
}
