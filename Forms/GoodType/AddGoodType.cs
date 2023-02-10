using AdoNetWinformsApp.Constant;
using System.ComponentModel;

namespace AdoNetWinformsApp.Forms.GoodType
{
    public partial class AddGoodType : Form
    {
        public string GoodTypeName => txtAddGoodType.Text.Trim();

        public AddGoodType()
        {
            InitializeComponent();
        }

        private void TxtAddGoodType_Validated(object sender, CancelEventArgs e)
        {
            if (txtAddGoodType.Text.Trim().Length > DatabaseDefaults.StringValueMaxLength)
            {
                nameError.SetError(txtAddGoodType, "Слишком длинное имя товара");
                e.Cancel = true;
            }
            else
            {
                nameError.SetError(txtAddGoodType, string.Empty);
                e.Cancel = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
