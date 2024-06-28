using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pressing.BL.repository;
using Pressing.BL.Extensions;
using Pressing.DAL.BaseRepository;
using Pressing.PL.Les_form_services;
using Pressing.DAL;
using System.IO;

namespace Pressing.PL.les_form_caisse
{
    public partial class FRM_Caisse : Form
    {
        //baserepository db = new baserepository();

        CategorieRepository categorierepository = new CategorieRepository();
        ArticlRepository articlerepository = new ArticlRepository();
        ClientRepository clientrepository = new ClientRepository();
        CaisseRepository caisserepository = new CaisseRepository();
        ServiceRepository servicerepository = new ServiceRepository();

        private string SelectedItem;
        private string SelectedService;
        private Color defaultButtonColor;
        private bool isTShirtSelect = false;
        private bool isRepassageSelect = false;
        private Button selectedButton;

        private Button selectedServiceButton;
        private Color defaultServiceButtonColor = Color.Empty;

        private Button selectedcategoryButton;
        private Color defultcategoryButtonColor = Color.Empty;

        public FRM_Caisse()
        {
            InitializeComponent();
            PNL_Menu.Visible = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (PNL_Menu.Visible == false)
            {
                PNL_Menu.Visible = true;
            }
            else
            {
                PNL_Menu.Visible = false;
            }
        }

        private void panelArticl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FRM_Caisse_Load(object sender, EventArgs e)
        {
            

            //combobox affiche client
            comboBox2.DataSource = clientrepository.selctBox3();
            comboBox2.ValueMember = "ID_CLIENT";
            comboBox2.DisplayMember = "Name";

            // menu mghadix tkon khdama
            PNL_Menu.Visible = false;


            //dataGridView2.Columns.Add("Column 1", "article");
            //dataGridView2.Columns.Add("Column 2", "prix repassage");
            //dataGridView2.Columns.Add("Column 3", "prix lessive");
            //
            defaultButtonColor = btn_tshirt.BackColor;
            //
            LoadClothingButtons();
            //
            LoadServiceButtons();
            //
            //LoadCategoryButtons();

        }
        private void LoadClothingButtons()
        {
            flowLayoutPanel1.Controls.Clear();

            var clothingItems = caisserepository.Get();

            foreach (var item in clothingItems)
            {

                Image image = null;
                if (item.IMAGE != null && item.IMAGE.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(item.IMAGE as byte[]))
                    {
                        image = Image.FromStream(ms);
                    }
                }

                var button = new Button
                {


                    Text = item.LIB_ARTICLE,
                    Size = new Size(80, 70),
                    Image = image,

                    ImageAlign = ContentAlignment.TopCenter,
                    TextAlign = ContentAlignment.BottomCenter,
                    FlatStyle = FlatStyle.Flat,

                    //TextImageRelation = TextImageRelation.Overlay,
                    BackColor = defaultButtonColor
                };
                button.Click += new EventHandler(ClothingButton_Click);
                button.Click += new EventHandler(Button_Enter);
                button.Leave += new EventHandler(Button_Leave);

                flowLayoutPanel1.Controls.Add(button);

                if (defaultButtonColor == Color.Empty)
                {
                    defaultButtonColor = button.BackColor;
                }
            }
        }
        private void Button_Enter(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button != selectedButton)
            {
                button.BackColor = Color.LightGray;
            }
        }
        private void Button_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button != selectedButton)
            {
                button.BackColor = defaultButtonColor;
            }
        }
        public class ClothingItem
        {
            public string LIB_ARTICLE { get; set; }
            public byte[] IMAGE { get; set; }
            public decimal PRIX_REPASSAGE { get; set; }
            public decimal PRIX_LESSIVE { get; set; }
        }
        private void ClothingButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (selectedButton != null)
                {
                    selectedButton.BackColor = defaultButtonColor;
                }

                // تغيير لون الخلفية للزر المحدد
                button.BackColor = Color.FromArgb(23, 162, 183);
                selectedButton = button;

                var item = button.Tag as ClothingItem;
                if (item != null)
                {
                    // إضافة اللباس إلى DataGridView
                    dataGridView2.Rows.Add(item.LIB_ARTICLE, item.PRIX_REPASSAGE, item.PRIX_LESSIVE);
                }
            }
        }
        public class ServiceItem
        {
            public string LIB_SERVICE { get; set; }
        }
        private void LoadServiceButtons()
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown; // ترتيب الأزرار عموديًا

            var serviceItems = servicerepository.Get(); // Assuming you have a repository for services

            foreach (var item in serviceItems)
            {
                var button = new Button
                {
                    Text = item.LIB_SERVICE,
                    Size = new Size(215, 38),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Tag = item // تعيين العنصر كـ Tag للزر
                };

                // إضافة الأحداث المطلوبة للزر
                button.Click += new EventHandler(ServiceButton_Click);
                button.Enter += new EventHandler(ButtonService_Enter);
                button.Leave += new EventHandler(ButtonService_Leave);

                flowLayoutPanel2.Controls.Add(button);

                // حفظ اللون الافتراضي للزر الأول
                if (defaultServiceButtonColor == Color.Empty)
                {
                    defaultServiceButtonColor = button.BackColor;
                }
            }
        }
        private void ServiceButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                // إعادة تعيين لون الخلفية للزر السابق المحدد
                if (selectedServiceButton != null)
                {
                    selectedServiceButton.BackColor = defaultServiceButtonColor;
                }

                // تغيير لون الخلفية للزر المحدد
                button.BackColor = Color.FromArgb(23, 162, 183);
                selectedServiceButton = button;

                var item = button.Tag as ServiceItem;
                if (item != null)
                {
                    // إضافة الخدمة إلى DataGridView
                    dataGridView2.Rows.Add(item.LIB_SERVICE);
                }
            }
        }
        private void ButtonService_Enter(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button != selectedServiceButton)
            {
                button.BackColor = Color.LightGray;
            }
        }
        private void ButtonService_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button != selectedServiceButton)
            {
                button.BackColor = defaultServiceButtonColor;
            }
        }
        public class CategoryItem
        {
            public string LIB_CAT_ART { get; set; }
        }
        private void LoadCategoryButtons()
        {
            flowLayoutPanelCategory.Controls.Clear();
            flowLayoutPanelCategory.FlowDirection = FlowDirection.TopDown; // ترتيب الأزرار عموديًا

            var categories = categorierepository.Get(); // Assuming you have a repository for services

            foreach (var category in categories)
            {
                var button = new Button
                {
                    Text = category.LIB_CAT_ART,
                    Size = new Size(215, 38),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Tag = category // تعيين العنصر كـ Tag للزر
                };

                // إضافة الأحداث المطلوبة للزر
                button.Click += new EventHandler(CategoryButton_Click);
                button.Enter += new EventHandler(ButtonCategory_Enter);
                button.Leave += new EventHandler(ButtonCategory_Leave);

                flowLayoutPanelCategory.Controls.Add(button);

                // حفظ اللون الافتراضي للزر الأول
                if (defultcategoryButtonColor == Color.Empty)
                {
                    defultcategoryButtonColor = button.BackColor;
                }
            }
        }
        private void ButtonCategory_Enter(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button != selectedcategoryButton)
            {
                button.BackColor = Color.LightGray;
            }
        }
        private void ButtonCategory_Leave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button != selectedcategoryButton)
            {
                button.BackColor = defultcategoryButtonColor;
            }
        }
        private void CategoryButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                // إعادة تعيين لون الخلفية للزر السابق المحدد
                if (selectedcategoryButton != null)
                {
                    selectedcategoryButton.BackColor = defultcategoryButtonColor;
                }

                // تغيير لون الخلفية للزر المحدد
                button.BackColor = Color.FromArgb(23, 162, 183);
                selectedcategoryButton = button;

                var category = button.Tag as CategoryItem;
                if (category != null)
                {
                    // إضافة الخدمة إلى DataGridView
                    dataGridView2.Rows.Add(category.LIB_CAT_ART);
                }
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Recherche")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Recherche";
                textBox1.ForeColor = Color.FromArgb(255, 105, 0);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //CategorieRepository obj = comboBox1.SelectedItem as CategorieRepository;
            //if(obj != null)
            //{
                
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnRapports_Click(object sender, EventArgs e)
        {
            new FRM_service().Show();
            Close();
        }

        private void btn_ajt_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(selectedButton.ToString())&& !string.IsNullOrEmpty(selectedServiceButton.ToString()))
            //{
            //    int rowIndex = dataGridView2.Rows.Add();
            //    DataGridViewRow row = dataGridView2.Rows[rowIndex];
            //    row.Cells[0].Value = SelectedItem;
            //    row.Cells[1].Value = SelectedService;
            //    SelectedItem = null;
            //    SelectedService = null;
            //    btn_rep.BackColor = defaultButtonColor;
            //    btn_tshirt.BackColor = defaultButtonColor;
            //    isTShirtSelect = false;
            //    isRepassageSelect = false;

            //}
            //else
            //{
            //    MessageBox.Show("please select an item first");
            //}
        }

        private void btn_tshirt_Click(object sender, EventArgs e)
        {
            if (!isTShirtSelect)
            {
                SelectedItem = "T-Shirt";
                btn_tshirt.BackColor = Color.FromArgb(23, 162, 183);
                isTShirtSelect = true;
            }
            else
            {
                SelectedItem = null ;
                btn_tshirt.BackColor = defaultButtonColor;
                isTShirtSelect = false;
            }
        }

        private void btn_rep_Click(object sender, EventArgs e)
        {
            if (!isRepassageSelect)
            {
                SelectedService = "repassage";
                btn_rep.BackColor = Color.FromArgb(23, 162, 183);
                isRepassageSelect = false;
            }
            else
            {
                SelectedService = null;
                btn_rep.BackColor = defaultButtonColor;
                isRepassageSelect = false;
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            int plusvaleu = int.Parse(number.Text);
            if (plusvaleu < 1000)
            {
                plusvaleu++;
                number.Text = plusvaleu.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int minvaleu = int.Parse(number.Text);
            if(minvaleu > 1)
            {
                minvaleu--;
                number.Text = minvaleu.ToString();
            }
        }
    }
}
