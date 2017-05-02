using System.ComponentModel;
using System.Windows.Forms;

namespace SharedForms
{
    public partial class MyButton : Button
    {
        public MyButton()
        {
            InitializeComponent();
            Init();
        }

        public MyButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.ForeColor = System.Drawing.Color.White;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.Cursor = Cursors.Hand;
        }
    }
}
