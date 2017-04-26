using CCWin;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace StudentUser
{
    public partial class CSkinBaseForm : CCSkinMain
    {
        

        #region 无参构造
        public CSkinBaseForm() {
            InitializeComponent();
            
        }
        #endregion

     

        #region 窗体重绘时
        private void ChatForm_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
 
        }
        #endregion

     

        
    }
}
