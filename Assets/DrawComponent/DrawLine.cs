//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using Sparrow.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Sparrow.Component
{
    /// <summary>
    /// 绘线类
    /// </summary>
    public sealed class DrawLine : DrawBase
    {
        /// <summary>
        /// 绘制记录点
        /// </summary>
        public List<Vector3> DrawPointList { get; private set; }

        /// <summary>
        /// 材质
        /// </summary>
        public Material m_LineMaterial = null;

        public DrawLine()
        {
            m_LineMaterial = new Material(Shader.Find("Unlit/Color"));
            DrawPointList = new List<Vector3>();
        }

        public DrawLine(Material material)
        {
            m_LineMaterial = material;
            DrawPointList = new List<Vector3>();
        }

        public override Color Color
        {
            get
            {
                return m_LineMaterial.color;
            }

            set
            {
                m_LineMaterial.color = value;
            }
        }

        public override void DrawGraph()
        {

            for (int i = 0; i < DrawPointList.Count; i++)
            {
                GLHelper.DrawLine2D(DrawPointList[i], DrawPointList[DrawPointList.Count <= i + 1 ? i : i + 1], LineWidth, m_LineMaterial);
            }
        }

        internal override void OnDrawGraph()
        {
            var mousePosition = Input.mousePosition;
            DrawPointList.Add(new Vector3(mousePosition.x / Screen.width, mousePosition.y / Screen.height, 0));
        }
    }
}
