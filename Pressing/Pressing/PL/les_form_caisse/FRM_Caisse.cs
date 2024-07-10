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
using System.Globalization;


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
        decimal? price = 0;
        string selectedArticleID;
        string selectedServiceID;


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
            dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
            dataGridView2.RowsRemoved += new DataGridViewRowsRemovedEventHandler(dataGridView2_RowsRemoved);
            dataGridView2.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView2_RowsAdded);
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
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 )
            {
                CalculateTotal();
            }
        }
        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateTotal();
        }
        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotal();
        }
        private void CalculateTotal()
        {
           
        
            double total = 0;
            //textBox2.Text = 0.ToString();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells[4].Value != null && dataGridView2.Rows[i].Cells[3].Value != null)
                {
                    double quantite = 0;
                    double prix = 0;

                    if (double.TryParse(dataGridView2.Rows[i].Cells[3].Value.ToString(), out quantite) &&
                        double.TryParse(dataGridView2.Rows[i].Cells[4].Value.ToString(), out prix))
                    {
                         //var txtremis = textBox2.Text;
                        total += (quantite * prix) ;
                    }
                }
            }
            label6.Text = total.ToString()+" DH";
        
        //label6.Text = "0";
        //for (int i = 0; i < dataGridView2.Rows.Count; i++)
        //{
        //    label6.Text = Convert.ToString(double.Parse(label6.Text) + double.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString()));
        //}

    }
        private void FRM_Caisse_Load(object sender, EventArgs e)
        {
            CalculateTotal();
            textBox2.TextChanged += new EventHandler(textBox2_TextChanged);
            //combobox affiche client
            comboBox2.DataSource = clientrepository.selctBox3();
            comboBox2.ValueMember = "ID_CLIENT";
            comboBox2.DisplayMember = "Name";

            // menu mghadix tkon khdama
            PNL_Menu.Visible = false;
            //
            label1.Text = price.ToString();
            //
            List<string> option = new List<string> { "rouge", "vert", "white", "mix", "blue" };
            comboBox1.DataSource = option;
            //
           
            //
            LoadClothingButtons();
            //
            LoadServiceButtons();
            //
            LoadCategoryButtons();
            //
            textBox2.Text = 0.ToString();

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


                    Text = item.LIB_ARTICLE ,
                    Size = new Size(80, 100),
                    Image = image,
                    Tag = item.REF_ARTICLE,


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
            public string REF_ARTICLE { get; set; }
            public string LIB_ARTICLE { get; set; }
            public byte[] IMAGE { get; set; }
            public decimal PRIX_REPASSAGE { get; set; }
            public decimal PRIX_LESSIVE { get; set; }
        }
        private void ClothingButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            ArticleName = button.Text;

            selectedArticleID = button.Tag.ToString();

            
                if (button != null)
            {

                if (selectedButton != null)
                {
                    selectedButton.BackColor = defaultButtonColor;
                }

                //تغيير لون الخلفية للزر المحدد
                button.BackColor = Color.FromArgb(23, 162, 183);
                selectedButton = button;


            }
        }
        public class ServiceItem
        {
            public string ID_SERVICE { get; set; }
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
                    Tag = item.ID_SERVICE,

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
            selectedServiceID = button.Tag.ToString();

            if (button != null)
            {
                
                if(ServiceName != null)
                {
                    var art = caisserepository.GetArticleByID(selectedArticleID);

                    try
                    {
                        if (ServiceName == "Repassage")
                        {
                            price = art.PRIX_REPASSAGE;
                        }
                        else if (ServiceName.Contains("Nettoyage"))
                        {
                            price = art.PRIX_LESSIVE;
                        }
                        // إعادة تعيين لون الخلفية للزر السابق المحدد
                        if (selectedServiceButton != null)
                        {
                            selectedServiceButton.BackColor = defaultServiceButtonColor;
                        }

                        // تغيير لون الخلفية للزر المحدد
                        button.BackColor = Color.FromArgb(23, 162, 183);
                        selectedServiceButton = button;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Veuillez sélectionner le vêtement", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        
                    }
                    label1.Text =  price.ToString();
               }
                
               
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

            //var button1 = new Button
            //{
            //    Text = "Touts",
            //    Size = new Size(130, 38),
            //    TextAlign = ContentAlignment.MiddleCenter,
            //    ForeColor = Color.White,

            //    FlatStyle = FlatStyle.Flat,
            //};
            //button1.BackColor = Color.FromArgb(23, 162, 183);
            //button1.FlatAppearance.BorderSize = 0;
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
            if (categoryButton != null)
            {

                // إعادة تعيين لون الخلفية للزر السابق المحدد
                if (selectedcategoryButton != null)
                {
                    selectedcategoryButton.BackColor = defultcategoryButtonColor;
                }

                // تغيير لون الخلفية للزر المحدد
                categoryButton.BackColor = Color.FromArgb(23, 162, 183);
                selectedcategoryButton = categoryButton;
            }


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
                    Tag = item.REF_ARTICLE,


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

            try
            {
                if (selectedButton!=null && selectedServiceButton!=null)
                {
                    dataGridView2.Rows.Add(ArticleName, comboBox1.SelectedValue.ToString(), ServiceName, number.Text, label1.Text);
                }
                if (selectedButton != null)
                {
                    selectedButton.BackColor = defaultButtonColor;
                }
                if (selectedServiceButton != null)
                {
                    selectedServiceButton.BackColor = defaultServiceButtonColor;
                }
                label1.Text = 0.ToString();
                number.Text = 1.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez sélectionner", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            short plusvaleu = short.Parse(number.Text);
            if (plusvaleu < 1000)
            {
                plusvaleu++;
                number.Text = plusvaleu.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            short minvaleu = short.Parse(number.Text);
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

        private void button8_Click(object sender, EventArgs e)
        {

            //var articl = ArticleName;
            //var color = comboBox1.SelectedValue.ToString();
            //var service = ServiceName;
            //var quntite = number.ToString();
            //var prix = label1.ToString();
            //var remis =textBox2.Text;

            //var repository = new CommandeRepository();
            //repository.Create(articl, color, service, quntite, prix, remis);
            //MessageBox.Show("Créé avec succès");
            string article = ArticleName;
            string art = selectedArticleID;
            string color = comboBox1.SelectedValue.ToString();
            string service = ServiceName;
            string srv = selectedServiceID;
            string quntite = dataGridView2.Rows[].Cells[3].Value.ToString();
            string remis = textBox2.Text;
            string montantTotal = label6.Text;
            string clients = comboBox2.Text;
            string clt = comboBox2.SelectedValue.ToString();
            

            Form modelBackground = new Form();
            using (FRM_Paye frm_paye = new FRM_Paye())
            {
                modelBackground.StartPosition = FormStartPosition.Manual;
                modelBackground.FormBorderStyle = FormBorderStyle.None;
                modelBackground.Opacity = 0.50;
                modelBackground.BackColor = Color.Black;
                modelBackground.Size = this.Size;
                modelBackground.Location = this.Location;
                modelBackground.ShowInTaskbar = false;
                modelBackground.Show();
                frm_paye.Owner = modelBackground;

                panrentX = this.Location.X;

                frm_paye.Article = article;
                frm_paye.Art = art;
                frm_paye.Color = color;
                frm_paye.Service = service;
                frm_paye.Srv = srv;
                frm_paye.Quntite = quntite;
                frm_paye.Remis = remis;

                frm_paye.MontantTotal = montantTotal;
                frm_paye.Clients = clients;
                frm_paye.Clt = clt;
                frm_paye.ShowDialog();
                modelBackground.Dispose();

            }
        }
        //private void CalcuateRemis()
        //{
        //    decimal total = 0;
        //    decimal remis = 0;
        //    if (decimal.TryParse(CalculateTotalRemis(), out total) && decimal.TryParse(textBox2.Text, out remis))
        //    {
        //        decimal Total = total - remis;
        //        label6.Text = Total.ToString();
        //    }
        //    else
        //    {
        //        MessageBox.Show("entrée invalide");
        //    }
        //}
        //private dynamic CalculateTotalRemis()
        //{


        //    double total = 0;
        //    //textBox2.Text = 0.ToString();
        //    for (int i = 0; i < dataGridView2.Rows.Count; i++)
        //    {
        //        if (dataGridView2.Rows[i].Cells[4].Value != null && dataGridView2.Rows[i].Cells[3].Value != null)
        //        {
        //            double quantite = 0;
        //            double prix = 0;

        //            if (double.TryParse(dataGridView2.Rows[i].Cells[3].Value.ToString(), out quantite) &&
        //                double.TryParse(dataGridView2.Rows[i].Cells[4].Value.ToString(), out prix))
        //            {
        //                //var txtremis = textBox2.Text;
        //                total += (quantite * prix);
        //            }
        //        }
        //    }
        //    return total;
        //}
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
           


        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    dataGridView2.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Il n'y a rien à supprimer");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //CalcuateRemis();
        }
    }
}
