using Microsoft.VisualBasic;
using System.IO;

namespace JogoGourmet
{
    public partial class Form1 : Form
    {
        const string _dishQuestion = "Qual prato você pensou?";
        const string _dishAttrQuestion = "{0} é ________ mas {1} não.";
        const string _dishSuggestionQuestion = "O prato que você pensou é {0}?";

        Category _category = null;

        const string _successMessage = "Acertei de novo!";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfirmCategory(_category);
        }

        private void ConfirmCategory(Category category)
        {
            var confirmCategory = MessageBox.Show(category.Question, "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmCategory == DialogResult.Yes)
            {
                if (category.categoryPositive != null)
                {
                    ConfirmCategory(category.categoryPositive);
                }
                else
                {
                    var confirmQuestion = MessageBox.Show(string.Format(_dishSuggestionQuestion, category.Positive), "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmQuestion == DialogResult.Yes)
                    {
                        MessageBox.Show(_successMessage, "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        category.categoryPositive = AddCategory(category.Positive);
                    }
                }
            }
            else
            {
                if (category.categoryNegative != null)
                {
                    ConfirmCategory(category.categoryNegative);
                }
                else
                {
                    var confirmQuestion = MessageBox.Show(string.Format(_dishSuggestionQuestion, category.Negative), "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmQuestion == DialogResult.Yes)
                    {
                        MessageBox.Show(_successMessage, "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        category.categoryNegative = AddCategory(category.Negative);
                    }
                }
            }
        }

        private Category AddCategory(string positive)
        {
            var customDishName = new CustomPopUp(_dishQuestion, "Desisto");
            customDishName.ShowDialog();

            var customDishAttr = new CustomPopUp(string.Format(_dishAttrQuestion, customDishName.CustomResult, positive), "Complete");
            customDishAttr.ShowDialog();

            if (!string.IsNullOrEmpty(customDishName.CustomResult) && !string.IsNullOrEmpty(customDishAttr.CustomResult))
            {
                return new Category(
                    customDishAttr.CustomResult, 
                    string.Format(_dishSuggestionQuestion, customDishAttr.CustomResult),
                    customDishName.CustomResult,
                    positive);
            }
            else
            {
                return null;
            }
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            _category = new Category("Massa", 
                "O prato que você pensou é massa?", 
                "Lasanha", 
                "Bolo de Chocolate");
        }
    }
}
