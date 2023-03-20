using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab01
{
    public partial class StringCalc : Form
    {
        public StringCalc()
        {
            InitializeComponent();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var input = txtResult.Text;
                var removeString = txtRemoveString.Text;

                txtResult.Text = input.Replace(removeString, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void replaceSubstring_Click(object sender, EventArgs e)
        {
            try
            {
                var input = txtResult.Text;
                var oldString = txtOldString.Text;
                var newString = txtNewString.Text;

                txtResult.Text = input.Replace(oldString, newString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void findByIndex_Click(object sender, EventArgs e)
        {
            try
            {
                var input = txtResult.Text;
                var index = Convert.ToInt32(txtIndex.Text);

                MessageBox.Show(@"symbol: " + input[index], "Find Character",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butLength_Click(object sender, EventArgs e)
        {
            try
            {
                var input = txtResult.Text;

                MessageBox.Show(@"length: " + input.Length, "text Length",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butVowels_Click(object sender, EventArgs e)
        {
            try
            {
                var input = txtResult.Text;
                char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

                var vowelsCount = input.Count(c => vowels.Contains(c));

                MessageBox.Show(@"vowels fount: " + vowelsCount, "count vowels",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butConsonants_Click(object sender, EventArgs e)
        {
            try
            {
                var input = txtResult.Text;
                char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

                var consonanceCount = input.Count(c => !vowels.Contains(c));

                MessageBox.Show(@"consonance fount: " + consonanceCount, "count consonance",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butOffers_Click(object sender, EventArgs e)
        {
            try
            {
                var input = txtResult.Text;
                var count = input.Count(t => t == '.' || t == '!' || t == '?');

                MessageBox.Show(@"sentences fount: " + count, "count sentences",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butWordsPerLine_Click(object sender, EventArgs e)
        {
            try
            {
                var input = txtResult.Text;
                var count = input.Count(t => t == ' ' || t == '\t' || t == '\n') + 1;

                MessageBox.Show(@"words fount: " + count, "count words",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
