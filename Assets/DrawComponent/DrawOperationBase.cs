//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEngine;

namespace Sparrow.Component
{
    /// <summary>
    /// 抽象基础绘图操作类
    /// </summary>
    public abstract class DrawOperationBase
    {
        /// <summary>
        /// 设置绘制图形事件间隔
        /// </summary>
        /// <param name="interval">时间间隔</param>
        public abstract void SetDrawGraphInterval(float interval);

        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="color">颜色值</param>
        public abstract void SetColor(Color color);

        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度</param>
        public abstract void SetWidth(float width);

        /// <summary>
        /// 撤销操作
        /// </summary>
        public abstract void Undo();

        /// <summary>
        /// 撤销撤销操作
        /// </summary>
        public abstract void Redo();

        /// <summary>
        /// 橡皮擦
        /// </summary>
        public abstract void Eraser();

        /// <summary>
        /// 绘制
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// 清除操作
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// 获取操作记录
        /// </summary>
        /// <returns></returns>
        public abstract DrawBase[] GetRecord();

    }
}
