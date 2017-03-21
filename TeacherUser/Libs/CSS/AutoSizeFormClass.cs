using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace TeacherUser
{
    class AutoSizeFormClass
    {
        public struct controlRect
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
        }

        public List<controlRect> oldCtrl;
    
        public void controllInitializeSize(Form mForm)
        {
            // if (ctrl_first == 0)
            {
                //  ctrl_first = 1;
                oldCtrl = new List<controlRect>();
                controlRect cR;
                cR.Left = mForm.Left;
                cR.Top = mForm.Top;
                cR.Width = mForm.Width;
                cR.Height = mForm.Height;
                oldCtrl.Add(cR);
                foreach (Control c in mForm.Controls)
                {
                    controlRect objCtrl;
                    objCtrl.Left = c.Left;
                    objCtrl.Top = c.Top;
                    objCtrl.Width = c.Width;
                    objCtrl.Height = c.Height;
                    oldCtrl.Add(objCtrl);
                }
            }
           
        }
      
        public void controlAutoSize(Form mForm)
        {
            if (mForm != null)
            {
                try {

                    float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;
                    float hScale = (float)mForm.Height / (float)oldCtrl[0].Height;//.Height;
                    int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;
                    int ctrlNo = 1;
                    foreach (Control c in mForm.Controls)
                    {
                        ctrLeft0 = oldCtrl[ctrlNo].Left;
                        ctrTop0 = oldCtrl[ctrlNo].Top;
                        ctrWidth0 = oldCtrl[ctrlNo].Width;
                        ctrHeight0 = oldCtrl[ctrlNo].Height;
                        c.Left = (int)((ctrLeft0) * wScale);
                        c.Top = (int)((ctrTop0) * hScale);
                        c.Width = (int)(ctrWidth0 * wScale);
                        c.Height = (int)(ctrHeight0 * hScale);
                        ctrlNo += 1;
                    }
                }catch(Exception ex)
                {
                
                }
            
            
            }
          
        }
    }
}
