using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MenuApplication.Domain;
using MenuApplication.DataAccess;

namespace MenuApplication
{
    public partial class MainForm : Form
    {
        int PositionDish;
        Controller _controller = new Controller(//IngredientRepositoryPlug.CreateInstance(),
        DishRepositoryPlug.CreateInstance(), MenuRepositoryPlug.CreateInstance());//,SubdivisionRepositoryPlug.CreateInstance());

        public MainForm()
        {
            InitializeComponent();
            Ingredient ing = new Ingredient();
        }

        //настройка формы реестра при разных режимах работы
        public void RegistryChangeMode(bool IngMode)
        {
            dgvRegistry.ReadOnly = IngMode;
            btStartEditing.Visible = IngMode;
            btCancleEditing.Visible = !IngMode;
            btStopEditing.Visible = !IngMode;
            btAddIngredient.Visible = IngMode;

            dgvRegistry.Columns[0].ReadOnly = IngMode;
            dgvRegistry.Columns[4].ReadOnly = IngMode;

            btRegisterInExcel.Visible = IngMode;
            //tcMenu.Enabled = IngMode;
        }

        //настройка формы Калькуляции при разных режимах работы
        private void CalculationChangeMode(bool mode)
        {
            if (mode)
            {
                ingredientBindingSource1.DataSource = _controller.GetALLIngredientAsBindingList().OrderBy(x=>x.NameIngredient);               
            } else
            {
                ingredientBindingSource1.DataSource = _controller.GetRegistryAsBindingList().OrderBy(x=>x.NameIngredient);
            }
            btRefreshDish.Visible = mode;
            btEndRefreshDish.Visible = false;

            //tcMenu.Enabled = mode;
            //btStartEditing.Visible = !mode;
            //btCancleEditing.Visible = mode;
            //btStopEditing.Visible = mode;
            tbExpandedNameDish.Visible = !mode;
            cbExpandedNameDish.Visible = mode;
            //btAddIngredient.Visible = mode;
            btStartCreatingCalculation.Visible = mode;
            btEndCreatingCalculation.Visible = !mode;
            btCancleCreatingCalculation.Visible = !mode;

            dtpRecord.Enabled = !mode;
            
            dgvCalculation.ReadOnly = mode;
            dgvCalculation.AllowUserToAddRows=!mode;
            dgvCalculation.AllowUserToDeleteRows = !mode;
            tbNameDish.ReadOnly = mode;
            tbNumberInCollectionOfRecipes.ReadOnly = mode;
            tbWeightDish.ReadOnly = mode;

            lbForHistoryDishes.Enabled = mode;
            cbExpandedNameDish.Enabled = mode;

            btDishInExcel.Visible = mode;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {   

            CalculationChangeMode(true);
            RegistryChangeMode(true);
            MenuChangeMode(true);

            //_controller.ChangeSubdivisionInReport(subdivisionBindingSource.Current as Subdivision)


            

            subdivisionBindingSource.DataSource = _controller.GetSubdivisionAsBindingList();

            ingredientBindingSource.DataSource = _controller.GetRegistryAsBindingList().OrderBy(x => x.NameIngredient);
            ingredientBindingSource1.DataSource = _controller.GetALLIngredientAsBindingList();



            ALLDishBindingSource.DataSource = _controller.GetFreshDish();

            dishBindingSource.DataSource = _controller.GetHistoryDish((ALLDishBindingSource.Current as IDish).ExpandedNameDish);
            dishItemBindingSource.DataSource = (dishBindingSource.Current as IDish).DishItems;

            menuBindingSource.DataSource = _controller.GetAllMenuAsBindingList();
            DishBindingSourceForMenu.DataSource = (menuBindingSource.Current as IMenu).Dishs;
        }

        //действия при смене калькуляционной карточки
        

        private void dishBindingSource_PositionChanged(object sender, EventArgs e)
        {
            dishItemBindingSource.DataSource = (dishBindingSource.Current as IDish).DishItems;

            if (dishBindingSource.Count != 0)
            {
            }
        }

        //Добавление ингредиента
        private void btAddIngredient_Click(object sender, EventArgs e)
        {
            var _AddIngredientDialog = new AddIngredientDialog();
            if (_AddIngredientDialog.ShowDialog() != DialogResult.OK) return;
            if (_AddIngredientDialog.tbName.Text == "" || _AddIngredientDialog.nudPrice.Value==0)
            {
                MessageBox.Show("Ингредиент не добавлен, т.к. были заполнены не все поля");
                return;
            }

            if (_controller.AddNewIngredientInRepository(_AddIngredientDialog.tbName.Text,
                (double)_AddIngredientDialog.nudMass.Value,
                _AddIngredientDialog.nudPrice.Value,
                _AddIngredientDialog.dtpRecord.Value,
                (double)_AddIngredientDialog.nudProtein.Value,
                (double)_AddIngredientDialog.nudFat.Value,
                (double)_AddIngredientDialog.nudCarbohydrate.Value) == false)
            {
                MessageBox.Show("Ингредиент с таким именем уже существует");
            }
            else
            {
                ingredientBindingSource.DataSource = _controller.GetRegistryAsBindingList().OrderBy(x => x.NameIngredient);
                ingredientBindingSource.ResetBindings(false);
            }
        }

        private void cbSearchIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Завершение редактирования реестра цен, сохранением результатов 
        private void btEndEditing_Click(object sender, EventArgs e)
        {         
            if((ingredientBindingSource.List as IList<Ingredient>).Where(x => x.MassInKg == 0).Count() > 0)
            {

                MessageBox.Show("В столбце Масса не может быть нулевого значения");
                return;
            }
            _controller.EndEditingRegistryIngredients((IEnumerable<IIngredient>)ingredientBindingSource.List);
            ingredientBindingSource.DataSource = _controller.GetRegistryAsBindingList().OrderBy(x=>x.NameIngredient);


            ingredientBindingSource1.DataSource = _controller.GetALLIngredientAsBindingList();//.OrderBy(x => x.NameIngredient);

            ALLDishBindingSource.DataSource = _controller.GetFreshDish();
            dishBindingSource.DataSource = _controller.GetHistoryDish((ALLDishBindingSource.Current as IDish).ExpandedNameDish);
            dishItemBindingSource.DataSource = (ALLDishBindingSource.Current as IDish).DishItems;

            RegistryChangeMode(true);
        }

        //Переход в режим редактирования реестра цен
        private void btStartEditing_Click(object sender, EventArgs e)
        {
            RegistryChangeMode(false);
            dgvRegistry.Columns[0].ReadOnly = true;
            dgvRegistry.Columns[4].ReadOnly = true;            
            ingredientBindingSource.DataSource=_controller.StartEditingRegistryIngredients().OrderBy(x=>x.NameIngredient);
        }        

        //Отмена редактирования рестра цен
        private void btCancleEditing_Click(object sender, EventArgs e)
        {
            RegistryChangeMode(true);

            ingredientBindingSource.Clear();
            dgvRegistry.Rows.Clear();

            //ingredientBindingSource.DataSource = _controller.GetALLIngredientAsBindingList();
            ingredientBindingSource.DataSource = _controller.GetRegistryAsBindingList().OrderBy(x => x.NameIngredient);
            ingredientBindingSource.ResetBindings(false);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        //Переход в режим добавления новой калькуляционной карточки
        private void btAddCalculation_Click(object sender, EventArgs e)
        {
            CalculationChangeMode(false);
            //ingredientBindingSource1.DataSource = _controller.GetFreshDish().OrderBy(x => x.NameDish);
            dishBindingSource.DataSource = _controller.NewDish();
            dishItemBindingSource.DataSource = (dishBindingSource.Current as Dish).DishItems;
            dtpRecord.Value = DateTime.Now;
        }

        //Завершение создания новой Калькуляционной Карточки
        private void btEndCreatingCalculation_Click(object sender, EventArgs e)
        {
            if (tbNameDish.Text == "" ||
                tbExpandedNameDish.Text == "" ||
                tbNumberInCollectionOfRecipes.Text == "" ||
                tbWeightDish.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }

            IList<DishItem> LDI = (dishBindingSource.Current as IDish).DishItems;
            if (LDI.Count == 0)
            {
                MessageBox.Show("Заполните список ингредиентов");
                return;
            }
            if (LDI.Count != LDI.Select(x => x.GetNameIngredient).Distinct().Count())
            {
                MessageBox.Show("В списке ингредиентов встречаются одинаковые поля");
                return;
            }
            if (LDI.Where(x => x.NormOn100Portions == 0).Count() > 0)
            {
                MessageBox.Show("Не всем ингредиентам указана норма");
                return;
            }
            if (LDI.Where(x => x.Ingredient == null).Count() > 0)
            {
                MessageBox.Show("Не всем ингредиенты выбраны");
                return;
            }
            IDish dish = (dishBindingSource.Current as IDish);
            if (_controller.CheckExpandedNameDish(dish.ExpandedNameDish))
            {
                MessageBox.Show("Введённое расширенное наименование блюда уже занято");
                return;
            }
            try
            { 
             dish.DateCreate = dtpRecord.Value;
             dish.NumberDoc = _controller.NextNumberDocDish();
            _controller.AddDishInRepository(dish);//(dishBindingSource.Current as IDish);
            }
            catch
            {
                MessageBox.Show("Добавление не произошло, проверьте список ингредиентов");
                return;
            }

            CalculationChangeMode(true);

            ALLDishBindingSource.DataSource = _controller.GetFreshDish();
            dishBindingSource.DataSource = _controller.GetHistoryDish((ALLDishBindingSource.Current as IDish).ExpandedNameDish);
            dishItemBindingSource.DataSource = (ALLDishBindingSource.Current as IDish).DishItems;
            

            // ingredientBindingSource1.DataSource = _controller.GetFreshDish().OrderBy(x => x.NameDish);
        }

        //Отмена создания новой Калькуляционной карточки
        private void btCancleCreatingCalculation_Click(object sender, EventArgs e)
        {
            CalculationChangeMode(true);
            ALLDishBindingSource.DataSource = _controller.GetFreshDish();
            dishBindingSource.DataSource = _controller.GetHistoryDish((ALLDishBindingSource.Current as IDish).ExpandedNameDish);
            dishItemBindingSource.DataSource = (ALLDishBindingSource.Current as IDish).DishItems;
        }

        private void btRefreshDish_Click(object sender, EventArgs e)
        {
            var dish = dishBindingSource.Current as Dish;
            
            if (_controller.TestOnRelevanceDish(dish))
            {
                MessageBox.Show("Данная калькуляционная карточка актуальна");
            }
            else
            {
                btEndRefreshDish.Visible = true;
                btRefreshDish.Visible = false;
                lbForHistoryDishes.Enabled = false;
                cbExpandedNameDish.Enabled = false;
                dishBindingSource.DataSource = _controller.RefreshDish(dish,DateTime.Now);
                dishItemBindingSource.DataSource = (dishBindingSource.Current as IDish).DishItems;

            }
        }
        //Выход из режима проверки калькуляционной карточки на актуальность
        private void btEndRefreshDish_Click(object sender, EventArgs e)
        {
            CalculationChangeMode(true);

   //dishBindingSource.DataSource = _controller.GetFreshDish();
            //dishItemBindingSource.DataSource = (dishBindingSource.Current as IDish).DishItems;
            //ALLDishBindingSource.DataSource = _controller.GetFreshDish();
            ALLDishBindingSource.DataSource = _controller.GetFreshDish();
            dishBindingSource.DataSource = _controller.GetHistoryDish((ALLDishBindingSource.Current as IDish).ExpandedNameDish);
            dishItemBindingSource.DataSource = (ALLDishBindingSource.Current as IDish).DishItems;


        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cbExpandedNameDish.DisplayMember = "";
            cbExpandedNameDish.Visible = false;//КОСТЫЛЁК
        }

        private void lbForHistoryDishes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ALLDishBindingSource_PositionChanged(object sender, EventArgs e)
        {
            dishBindingSource.DataSource = _controller.GetHistoryDish((ALLDishBindingSource.Current as IDish).ExpandedNameDish);
            dishItemBindingSource.DataSource = (dishBindingSource.Current as IDish).DishItems;
            PositionDish = ALLDishBindingSource.Position;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MenuChangeMode(bool modeMenu)
        {
            //tcMenu.Enabled = modeMenu;
            btBrokerashInExcel.Visible = modeMenu;
            btMenuInExcel.Visible = modeMenu;

            btStartEditingMenu.Visible = modeMenu;
            btEndCreatingMenu.Visible = !modeMenu;
            btCancleCreatingMenu.Visible = !modeMenu;

            btAddDishInMenu.Visible = !modeMenu;
            cbCreateMenu.Visible = !modeMenu;
            
            dgvMenu.AllowUserToDeleteRows = !modeMenu;
            dgvMenu.Columns[1].ReadOnly = true;

            btMenuInExcel.Visible = modeMenu;
        }

        private void tpMenu_Click(object sender, EventArgs e)
        {

        }

        //Переход в режим создания меню
        private void btStartCreateMenu_Click(object sender, EventArgs e)
        {   
            MenuChangeMode(false);
            menuBindingSource.DataSource = _controller.NewMenu();
            DishBindingSourceForMenu.DataSource = (menuBindingSource.Current as IMenu).Dishs;
            dishBindingSourceForCreateMenu.DataSource = _controller.GetFreshDish();
            dtpMenu.Value = DateTime.Now;
        }

        //Завершение создания меню
        private void btEndCreatingMenu_Click(object sender, EventArgs e)
        {
            if (DishBindingSourceForMenu.Count == 0)
            {
                MessageBox.Show("В меню нет ни одного блюда");
                return;
            }
            MenuChangeMode(true);
            var c = (menuBindingSource.Current as IMenu);
            c.DateCreateMenu = dtpMenu.Value;
            _controller.AddMenuInRepository(menuBindingSource.Current as IMenu);

            menuBindingSource.DataSource = _controller.GetAllMenuAsBindingList().OrderByDescending(x=>x.DateCreateMenu);
            DishBindingSourceForMenu.DataSource = (menuBindingSource.Current as IMenu).Dishs;

            ALLDishBindingSource.DataSource = _controller.GetFreshDish().OrderBy(x=>x.NameDish);// dishBindingSource.DataSource = _controller.GetFreshDish();
            dishBindingSource.DataSource = _controller.GetHistoryDish((ALLDishBindingSource.Current as IDish).ExpandedNameDish);
            dishItemBindingSource.DataSource = (ALLDishBindingSource.Current as IDish).DishItems;
        }

        //Отменить создание меню
        private void btCancleCreatingMenu_Click(object sender, EventArgs e)
        {
            MenuChangeMode(true);
            menuBindingSource.DataSource = _controller.GetAllMenuAsBindingList();
            DishBindingSourceForMenu.DataSource = (menuBindingSource.Current as IMenu).Dishs;
        }

        //переход на другое меню
        private void menuBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (menuBindingSource.Count != 0)// && DishBindingSourceForMenu.Count != 0)
            {
                //menuBindingSource.DataSource = _controller.GetAllMenuAsBindingList();
                DishBindingSourceForMenu.DataSource = (menuBindingSource.Current as IMenu).Dishs.OrderBy(x=>x.DateCreate);
                //DishBindingSourceForMenu.DataSource = (menuBindingSource.Current as IMenu).Dishs;
                //DishBindingSourceForMenu.DataSource=(menuBindingSource.Current as Domain.Menu).Dishs;

            }
        }

        //При добавлении блюд в меню
        private void btAddDishInMenu_Click(object sender, EventArgs e)
        {
            var Dish = dishBindingSourceForCreateMenu.Current as Dish;

            if ((DishBindingSourceForMenu.DataSource as IList<Dish>).Select(x => x.ExpandedNameDish).Contains(Dish.ExpandedNameDish))
            {
                MessageBox.Show("Данное блюдо присутствует в меню");
                return;
            }

            if (_controller.TestOnRelevanceDish(Dish))
            {
                DishBindingSourceForMenu.Add(Dish);
            }else
            {
                DishBindingSourceForMenu.Add(_controller.RefreshDish(Dish, DateTime.Now));
            }         
            
        }

        private void btMenuInExcel_Click(object sender, EventArgs e)
        {
            _controller.MenuInExcel(menuBindingSource.Current as IMenu);
        }

        private void btRegisterInExcel_Click(object sender, EventArgs e)
        {
            _controller.RegistryInExcel();
        }

        private void btDishInExcel_Click(object sender, EventArgs e)
        {
            _controller.DishInExcel(dishBindingSource.Current as IDish);
        }

        private void subdivisionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            _controller.ChangeSubdivisionInReport(subdivisionBindingSource.Current as Subdivision);
            _controller.ChangeCurrentSubdivision(subdivisionBindingSource.Current as ModelDB.Subdivision);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.BrokerashInExcel(menuBindingSource.Current as IMenu);
        }

        private void dgvRegistry_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Введите корректное значение");
        }

        private void dgvCalculation_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Попробуйте еще раз");
            //btEndRefreshDish.PerformClick();
            //btRefreshDish.PerformClick();
        }

        private void tcMenu_TabIndexChanged(object sender, EventArgs e)
        {
            
            //if ()
            //{

            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //public void df()
        //{
        //    tcMenu.TabPages[0].
        //}

    }
}
