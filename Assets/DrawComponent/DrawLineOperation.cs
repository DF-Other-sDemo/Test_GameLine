//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sparrow.Component
{
    /// <summary>
    /// 绘线操作类
    /// </summary>

    public sealed class DrawLineOperation : DrawOperationBase
    {

        public DrawLineOperation(Color color, float width)
        {
            SetColor(color);
            SetWidth(width);
        }

        /// <summary>
        /// 操作栈
        /// </summary>
        private Stack<DrawBase> m_DoStack = new Stack<DrawBase>();

        /// <summary>
        /// 撤销栈
        /// </summary>
        private Stack<DrawBase> m_UndoStack = new Stack<DrawBase>();

        /// <summary>
        /// 缓存的绘制对象
        /// </summary>
        private DrawBase m_CacheDrawObject = null;

        /// <summary>
        /// 累加的时间缓存
        /// </summary>
        private float m_CacheAddtionTime = 0f;

        /// <summary>
        /// 当前缓存的宽度值
        /// </summary>
        private float m_CacheWidth = 0f;

        /// <summary>
        /// 当前缓存的颜色
        /// </summary>
        private Color m_CacheColor = default(Color);

        /// <summary>
        /// 绘制图形的时间间隔
        /// </summary>
        public float m_DrawGraphInterval = 0.01f;

        /// <summary>
        /// 绘制
        /// </summary>
        public override void Draw()
        {
            //未设置间隔，PC端无所畏惧，蹦了再说。=L=

            if (Input.GetMouseButton(0))
            {
                if (null == m_CacheDrawObject)
                {
                    m_CacheDrawObject = new DrawLine();
                    m_CacheDrawObject.LineWidth = m_CacheWidth;
                    m_CacheDrawObject.Color = m_CacheColor;
                    m_DoStack.Push(m_CacheDrawObject);
                    m_UndoStack.Clear();
                }
                m_CacheDrawObject.OnDrawGraph();
            }
            else if ((Input.GetMouseButtonUp(0)))
            {
                m_CacheDrawObject = null;
            }
        }

        /// <summary>
        /// 橡皮擦
        /// </summary>
        public override void Eraser()
        {

        }

        /// <summary>
        /// 获取操作记录
        /// </summary>
        /// <returns></returns>
        public override DrawBase[] GetRecord()
        {
            return m_DoStack.ToArray();
        }

        /// <summary>
        /// 撤销撤销操作
        /// </summary>
        public override void Redo()
        {
            if (0 < m_UndoStack.Count)
                m_DoStack.Push(m_UndoStack.Pop());
        }

        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="width">颜色</param>
        public override void SetColor(Color color)
        {
            m_CacheColor = color;
        }

        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度</param>
        public override void SetWidth(float width)
        {
            m_CacheWidth = width;
        }

        /// <summary>
        /// 撤销
        /// </summary>
        public override void Undo()
        {
            if (0 < m_DoStack.Count)
                m_UndoStack.Push(m_DoStack.Pop());
        }

        /// <summary>
        /// 设置绘制图形事件间隔
        /// </summary>
        /// <param name="interval">时间间隔</param>
        public override void SetDrawGraphInterval(float interval)
        {
            m_DrawGraphInterval = interval;
        }

        /// <summary>
        /// 清除操作
        /// </summary>
        public override void Clear()
        {
            m_DoStack.Clear();
            m_UndoStack.Clear();
        }
    }
}
