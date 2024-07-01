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
using Pressing.PL.les_form_client;

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

        string CategoryName;
        string ServiceName;
        string ArticleName;

        
        private Color defaultButtonColor;
        
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


            
            //
            //
            LoadClothingButtons();
            //
            LoadServiceButtons();
            //
            LoadCategoryButtons();

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
                    Size = new Size(80, 100),
                    Image = image,
                    
                    ImageAlign = ContentAlignment.TopCenter,
                    TextAlign = ContentAlignment.BottomCenter,
                    FlatStyle = FlatStyle.Flat,

                    //TextImageRelation = TextImageRelation.Overlay,
                    BackColor = defaultButtonColor
                };

                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.WhiteSmoke;

                button.Click += new EventHandler(ClothingButton_Click);
                
                flowLayoutPanel1.Controls.Add(button);

                if (defaultButtonColor == Color.Empty)
                {
                    defaultButtonColor = button.BackColor;
                }
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

            ArticleName = button.Text;

            if (button != null)
            {
                if (selectedButton != null)
                {
                    selectedButton.BackColor = defaultButtonColor;
                }

                // تغيير لون الخلفية للزر المحدد
                button.BackColor = Color.FromArgb(23, 162, 183);
                selectedButton = button;

               
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
                    FlatStyle = FlatStyle.Flat,
                     

                };
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.WhiteSmoke;
                // إضافة الأحداث المطلوبة للزر
                button.Click += new EventHandler(ServiceButton_Click);


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

            ServiceName = button.Text;

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
                    Size = new Size(130, 38),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White,
                    
                    FlatStyle = FlatStyle.Flat,
                };
                button.BackColor = Color.FromArgb(255, 105, 0);
                button.FlatAppearance.BorderSize = 0;
                // إضافة الأحداث المطلوبة للزر
                button.Click += new EventHandler(CategoryButton_Click);
                

                flowLayoutPanelCategory.Controls.Add(button);

                // حفظ اللون الافتراضي للزر الأول
                if (defultcategoryButtonColor == Color.Empty)
                {
                    defultcategoryButtonColor = button.BackColor;
                }
            }
        }
       
        private void CategoryButton_Click(object sender, EventArgs e)
        {
           

            var categoryButton = sender as Button;

            CategoryName = categoryButton.Text;



            flowLayoutPanel1.Controls.Clear();

            var clothingItems = caisserepository.GetByCategoryName(CategoryName);

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
                    Size = new Size(80, 100),
                    Image = image,

                    ImageAlign = ContentAlignment.TopCenter,
                    TextAlign = ContentAlignment.BottomCenter,
                    FlatStyle = FlatStyle.Flat,

                    //TextImageRelation = TextImageRelation.Overlay,
                    BackColor = defaultButtonColor
                };

                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.WhiteSmoke;

                button.Click += new EventHandler(ClothingButton_Click);

                flowLayoutPanel1.Controls.Add(button);

                if (defaultButtonColor == Color.Empty)
                {
                    defaultButtonColor = button.BackColor;
                }
            
                if (button != null)
                {
                    // إعادة تعيين لون الخلفية للزر السابق المحدد
                    if (selectedButton != null)
                    {
                        selectedButton.BackColor = defaultButtonColor;
                    }

                    // تغيير لون الخلفية للزر المحدد
                    button.BackColor = Color.FromArgb(23, 162, 183);
                    selectedcategoryButton = button;


                }
            }

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Tu as vraiment envie de sortir ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            
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
            

            dataGridView2.Rows.Add(ArticleName, ServiceName, number.Text);
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
        public static int panrentX;

        private void button7_Click(object sender, EventArgs e)
        {
            // إنشاء الفورم الجديدة
            Form modelBackground = new Form();
            using (FRM_Ajoute_Client model = new FRM_Ajoute_Client())
            {
                modelBackground.StartPosition = FormStartPosition.Manual;
                modelBackground.FormBorderStyle = FormBorderStyle.None;
                modelBackground.Opacity = 0.50;
                modelBackground.BackColor = Color.Black;
                modelBackground.Size = this.Size;
                modelBackground.Location = this.Location;
                modelBackground.ShowInTaskbar = false;
                modelBackground.Show();
                model.Owner = modelBackground;

                panrentX = this.Location.X;

                model.ShowDialog();
                modelBackground.Dispose();

            }
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {

        }
    }
}
