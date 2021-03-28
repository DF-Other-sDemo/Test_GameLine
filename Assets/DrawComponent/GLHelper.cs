//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace Sparrow.Utility
{
    /// <summary>
    /// GL / OpenGL Unity上层库助手类
    /// </summary>
	public static class GLHelper  
	{
        public static Vector3[] Line2DPointsConvert(Vector3 firstPoint, Vector3 secondPoint, float lineWidth)
        {
            Vector3 normal = Quaternion.Euler(0f,0f,90f) * (secondPoint - firstPoint).normalized;
            var threshold = normal * lineWidth;
            Vector3[] points = new Vector3[4];
            points[0] = firstPoint  - threshold;
            points[1] = firstPoint  + threshold;
            points[2] = secondPoint + threshold;
            points[3] = secondPoint - threshold;
            return points;
        }

        public static void DrawLine2D(Vector3 firstPoint,Vector3 secondPoint,float lineWidth,Material material)
        {
            if (null == material) { throw new System.NullReferenceException("材质不能为空!"); }

            lineWidth = lineWidth/100f;
            GL.PushMatrix();
            material.SetPass(0);
            GL.LoadOrtho();
            GL.Begin(GL.QUADS);
            var points = Line2DPointsConvert(firstPoint,secondPoint,lineWidth);
            for (int i = 0; i < points.Length; i++)
            {
                GL.Vertex(points[i]);
            }
            GL.End();
            GL.PopMatrix();

        }

        public static void DrawLine2D(Vector3 firstPoint, Vector3 secondPoint, float lineWidth,Color color)
        {
            lineWidth = lineWidth / 100f;
            GL.PushMatrix();
            GL.Begin(GL.QUADS);
            GL.Color(color);
            var points = Line2DPointsConvert(firstPoint, secondPoint,lineWidth);
            for (int i = 0; i < points.Length; i++)
            {
                GL.Vertex(points[i]);
            }
            GL.End();
            GL.PopMatrix();

        }


    }
}
