using System.Drawing;
namespace TeacherUser.Controls
{
    partial class SMSPanelEx
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        Image topimg = Properties.Resources.lt;
        Image middleimg = Properties.Resources.lm;
        Image bottomimg = Properties.Resources.lb;
        Image topimgR = Properties.Resources.rt;
        Image middleimgR = Properties.Resources.rm;
        Image bottomimgR = Properties.Resources.rb;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            topimg.Dispose();
            middleimg.Dispose();
            bottomimg.Dispose();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SMSPanelEx
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Name = "SMSPanelEx";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.Size = new System.Drawing.Size(352, 142);
            this.ResumeLayout(false);

        }

        #endregion





    }
}
