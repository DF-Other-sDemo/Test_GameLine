//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using Sparrow.Component;
using UnityEngine;

namespace Alan
{
    /// <summary>
    /// GL测试类
    /// </summary>
	internal sealed class GLTest : MonoBehaviour
    {
        private DrawBase[] m_CacheDrawBaseArray = null;

        private DrawOperationBase m_DrawOperation = new DrawLineOperation(Color.red,0.2f); //颜色 和 线宽

        private void Update()
        {
            m_DrawOperation.Draw();

            if (Input.GetKeyDown(KeyCode.A))
            {
                m_DrawOperation.Undo();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                m_DrawOperation.Redo();
            }

        }

        private void OnPostRender()
        {
            m_CacheDrawBaseArray = m_DrawOperation.GetRecord();
            for (int i = 0; i < m_CacheDrawBaseArray.Length; i++)
            {
                m_CacheDrawBaseArray[i].DrawGraph();
            }
        }

    }







}
