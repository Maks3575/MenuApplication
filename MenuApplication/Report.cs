using MenuApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuApplication
{
    class Report
    {   
        /// <summary>
        /// Структурное подразделение 
        /// </summary>
        public Subdivision Subdivision { get; set; }

        private Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
        
        /// <summary>
        /// Создает меню в Excel
        /// </summary>
        /// <param name="menu">Меню</param>
        public void MenuInExcel(IMenu menu)
        {
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Rows.RowHeight = "24";
            ExcelApp.Cells[4, 1] = "№";
                ExcelApp.Columns[1].ColumnWidth = "2,7";

            ExcelApp.Cells[4, 2] = "Наименования блюд";
                ExcelApp.Columns[2].ColumnWidth = "75";

            ExcelApp.Cells[4, 3] = "Выход";
                ExcelApp.Columns[3].ColumnWidth = "13";

            ExcelApp.Cells[4, 4] = "Цена";
                ExcelApp.Columns[4].ColumnWidth = "13";

            ExcelApp.Cells[4, 5] = "Энергетическая ценность в блюде";
            ExcelApp.Cells[4, 5].WrapText = true;
            ExcelApp.Columns[5].ColumnWidth = "22";
            int x = 5;
            foreach (Dish dish in menu.Dishs)
            {
                ExcelApp.Cells[x, 1] = x-4;
                ExcelApp.Cells[x, 2] = dish.NameDish;
                ExcelApp.Cells[x, 3] = dish.WeightDish;
                ExcelApp.Cells[x, 4] = Math.Round(dish.PriceDish,2);
                ExcelApp.Cells[x, 5] = $" Белки - {Math.Round(dish.ProteinOnOnePortion,1)}; жиры - {Math.Round(dish.FatOnOnePortion,1)}; углеводы - {Math.Round(dish.CarbohydrateOnOnePortion,1)}; {Math.Round(dish.CalorificValueOnOnePortion)} ккал";
                x++;
            }
            ExcelApp.Range[ExcelApp.Cells[x, 1], ExcelApp.Cells[x, 5]].Font.Size = "10";
            ExcelApp.Range[ExcelApp.Cells[x, 1], ExcelApp.Cells[x, 5]].Merge();
            ExcelApp.Range[ExcelApp.Cells[x, 1], ExcelApp.Cells[x, 5]].Font.Size = "10";
            ExcelApp.Range[ExcelApp.Cells[x, 1], ExcelApp.Cells[x, 5]] = "             Шеф - повар:                                                                                              Калькулятор:";


            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[x, 5]].Font.Name = "Arial";
            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[4, 5]].Font.Bold = true;
            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[x-1, 4]].Font.Size = "12";

            ExcelApp.Range[ExcelApp.Cells[5, 5], ExcelApp.Cells[x-1, 5]].Font.Name = "Times New Roman";
            ExcelApp.Range[ExcelApp.Cells[4, 5], ExcelApp.Cells[x-1, 5]].Font.Size = "9";
            ExcelApp.Range[ExcelApp.Cells[4, 5], ExcelApp.Cells[x - 1, 5]].WrapText = true;

            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[x-1, 5]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ExcelApp.Range[ExcelApp.Cells[5, 2], ExcelApp.Cells[x-1, 2]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 4]].Merge();
            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 4]] = Subdivision.NameSubdivision;

            ExcelApp.Range[ExcelApp.Cells[2, 1], ExcelApp.Cells[2, 4]].Merge();
            ExcelApp.Range[ExcelApp.Cells[2, 1], ExcelApp.Cells[2, 4]] = "АО  \"Транснефть-Север\"";

            ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 4]].Merge();
            ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 4]] = $"Меню на {menu.DateCreateMenu.ToShortDateString()}" ;
        

            ExcelApp.Range[ExcelApp.Cells[4, 1], ExcelApp.Cells[x-1, 5]].Borders.ColorIndex=1;
            ExcelApp.Visible = true;
         }


        /// <summary>
        /// Создает Реестр цен в Excel
        /// </summary>
        /// <param name="registry">Реестр цен</param>
        public void RegistryInExcel(IEnumerable<IIngredient> registry)
        {
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Rows.RowHeight = "15";

            ExcelApp.Cells[2, 1] = "№";
                ExcelApp.Columns[1].ColumnWidth = "4";

            ExcelApp.Cells[2, 2] = "Наименование продукта";
                ExcelApp.Columns[2].ColumnWidth = "40";

            ExcelApp.Cells[2, 3] = "Масса";
                ExcelApp.Columns[3].ColumnWidth = "10";

            ExcelApp.Cells[2, 4] = "Цена";
                ExcelApp.Columns[4].ColumnWidth = "13";

            ExcelApp.Cells[2, 5] = "Закупочная цена 1 кг";
                ExcelApp.Cells[2, 5].WrapText = true;
                ExcelApp.Columns[5].ColumnWidth = "22";

            int x = 3;
            foreach (IIngredient ingr in registry)
            {
                ExcelApp.Cells[x, 1] = x-2;
                ExcelApp.Cells[x, 2] = ingr.NameIngredient;
                ExcelApp.Cells[x, 3] = Math.Round(ingr.MassInKg,3);
                ExcelApp.Cells[x, 4] = Math.Round(ingr.StartingPrice,2);
                ExcelApp.Cells[x, 5] = Math.Round(ingr.PricePerOneKg,2);
               // ExcelApp.Cells[x, 5] = $" Белки - {Math.Round(dish.ProteinOnOnePortion,1)}; жиры - {Math.Round(dish.FatOnOnePortion,1)}; углеводы - {Math.Round(dish.CarbohydrateOnOnePortion,1)}; {Math.Round(dish.CalorificValueOnOnePortion)} ккал";
                x++;
            }
            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Font.Size = "11";
            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]] = $"РЕЕСТР ЦЕН {Subdivision.NameSubdivision}";


            ExcelApp.Range[ExcelApp.Cells[1, 4], ExcelApp.Cells[1, 5]].Merge();
            ExcelApp.Range[ExcelApp.Cells[1, 4], ExcelApp.Cells[1, 5]].Font.Size = "10";
            ExcelApp.Range[ExcelApp.Cells[1, 4], ExcelApp.Cells[1, 5]] = registry.Max(y=>y.RecordDate).ToShortDateString();

            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[x-1, 5]].Font.Name = "Arial";
            ExcelApp.Range[ExcelApp.Cells[2, 1], ExcelApp.Cells[2, 5]].Font.Bold = true;
            ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[x-1, 5]].Font.Size = "10";

            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[x - 1, 1]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ExcelApp.Range[ExcelApp.Cells[1, 4], ExcelApp.Cells[1, 5]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ExcelApp.Range[ExcelApp.Cells[3, 2], ExcelApp.Cells[x - 1, 5]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            ExcelApp.Range[ExcelApp.Cells[2, 1], ExcelApp.Cells[x - 1, 5]].Borders.ColorIndex = 1;
            ExcelApp.Range[ExcelApp.Cells[2, 1], ExcelApp.Cells[2, 5]].Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
            ExcelApp.Visible = true;
        }


        /// <summary>
        /// Вставляет строку между строк в Excel 
        /// </summary>
        /// <param name="rowNum"></param>
        public void InsertRow(int rowNum)
        {
            Microsoft.Office.Interop.Excel.Range cellRange = (Microsoft.Office.Interop.Excel.Range)ExcelApp.Cells[rowNum, 1];
            Microsoft.Office.Interop.Excel.Range rowRange = cellRange.EntireRow;
            rowRange.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, false);
        }

        //public void InsertRow(int rowNum)
        /// <summary>
        /// Создает Калькуляционную карточку в экселе
        /// </summary>
        /// <param name="dishNew">Карточка по которой создаем</param>
        /// <param name="dishPrev">Предыдущая карточка</param>
        public void CalculationInExcel(IDish dishNew, IDish dishPrev)
        {
            ExcelApp.Application.Workbooks.Add(Application.StartupPath + @"\Calculation.xlsx");

            int x = 26;

            foreach (IDishItem di in dishNew.DishItems)
            {

                if (dishNew.DishItems.Count > x - 25) { InsertRow(x + 1); }
                ExcelApp.Range[ExcelApp.Cells[x, 1], ExcelApp.Cells[x, 2]].Merge();
                ExcelApp.Range[ExcelApp.Cells[x, 1], ExcelApp.Cells[x, 2]] = x - 25;

                ExcelApp.Range[ExcelApp.Cells[x, 3], ExcelApp.Cells[x, 9]].Merge();
                ExcelApp.Range[ExcelApp.Cells[x, 3], ExcelApp.Cells[x, 9]] = di.GetNameIngredient;

                ExcelApp.Range[ExcelApp.Cells[x, 10], ExcelApp.Cells[x, 12]].Merge();
                ExcelApp.Range[ExcelApp.Cells[x, 10], ExcelApp.Cells[x, 12]] = di.NormOn100Portions;

                ExcelApp.Range[ExcelApp.Cells[x, 13], ExcelApp.Cells[x, 14]].Merge();
                ExcelApp.Range[ExcelApp.Cells[x, 13], ExcelApp.Cells[x, 14]] = di.PricePerOneKg;

                ExcelApp.Range[ExcelApp.Cells[x, 15], ExcelApp.Cells[x, 16]].Merge();
                ExcelApp.Range[ExcelApp.Cells[x, 15], ExcelApp.Cells[x, 16]] = di.TotalInItem;
                
                x++;
            }

            x = 26;

            foreach (IDishItem di in dishPrev.DishItems)
            {
                ExcelApp.Range[ExcelApp.Cells[x, 17], ExcelApp.Cells[x, 19]].Merge();
                ExcelApp.Range[ExcelApp.Cells[x, 17], ExcelApp.Cells[x, 19]] = di.NormOn100Portions;

                ExcelApp.Range[ExcelApp.Cells[x, 20], ExcelApp.Cells[x, 21]].Merge();
                ExcelApp.Range[ExcelApp.Cells[x, 20], ExcelApp.Cells[x, 21]] = di.PricePerOneKg;

                ExcelApp.Range[ExcelApp.Cells[x, 22], ExcelApp.Cells[x, 23]].Merge();
                ExcelApp.Range[ExcelApp.Cells[x, 22], ExcelApp.Cells[x, 23]] = di.TotalInItem;
               
                x++;
            }

            ExcelApp.Range[ExcelApp.Cells[27, 1], ExcelApp.Cells[x - 1, 23]].Borders.ColorIndex = 1;

            ExcelApp.Cells[6,1]= "АО  \"Транснефть-Север\"";

            ExcelApp.Cells[8, 1] = Subdivision.NameSubdivision;

            ExcelApp.Cells[10, 1] = dishNew.NameDish;

            ExcelApp.Range[ExcelApp.Cells[11, 27], ExcelApp.Cells[11,34]] = dishNew.NumberInCollectionOfRecipes;
            ExcelApp.Range[ExcelApp.Cells[11, 27], ExcelApp.Cells[11,34]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            ExcelApp.Range[ExcelApp.Cells[16,10],ExcelApp.Cells[16,16]] = dishNew.NumberDoc;
            ExcelApp.Range[ExcelApp.Cells[16, 17], ExcelApp.Cells[16, 23]] = dishNew.DateCreate.ToShortDateString();

            ExcelApp.Range[ExcelApp.Cells[21, 10], ExcelApp.Cells[21, 16]] = dishNew.DateCreate.ToShortDateString();
            ExcelApp.Range[ExcelApp.Cells[21, 17], ExcelApp.Cells[21, 23]] = dishPrev.DateCreate.ToShortDateString();

            ExcelApp.Range[ExcelApp.Cells[x, 15], ExcelApp.Cells[x, 16]].Merge();
            ExcelApp.Range[ExcelApp.Cells[x, 15], ExcelApp.Cells[x, 16]] = dishNew.TotalDishOn100Portsion;

            ExcelApp.Range[ExcelApp.Cells[x+1, 10], ExcelApp.Cells[x+1, 16]].Merge();
            ExcelApp.Range[ExcelApp.Cells[x+1, 10], ExcelApp.Cells[x+1, 16]] = dishNew.PriceDish;

            ExcelApp.Range[ExcelApp.Cells[x+2, 10], ExcelApp.Cells[x+2, 16]].Merge();
            ExcelApp.Range[ExcelApp.Cells[x + 2, 10], ExcelApp.Cells[x + 2, 16]] = dishNew.WeightDish;
            
            

            ExcelApp.Range[ExcelApp.Cells[x, 22], ExcelApp.Cells[x, 23]].Merge();
            ExcelApp.Range[ExcelApp.Cells[x, 22], ExcelApp.Cells[x, 23]] = dishPrev.TotalDishOn100Portsion;

            ExcelApp.Range[ExcelApp.Cells[x + 1, 17], ExcelApp.Cells[x + 1, 23]].Merge();
            ExcelApp.Range[ExcelApp.Cells[x + 1, 17], ExcelApp.Cells[x + 1, 23]] = dishPrev.PriceDish;

            ExcelApp.Range[ExcelApp.Cells[x + 2, 17], ExcelApp.Cells[x + 2, 23]].Merge();
            ExcelApp.Range[ExcelApp.Cells[x + 2, 17], ExcelApp.Cells[x + 2, 23]] = dishPrev.WeightDish;

            ExcelApp.Visible = true;
        }

        /// <summary>
        /// Создание заготовки брокеражного журнала на основе меню
        /// </summary>
        /// <param name="menu">Меню на основе которого составляется бракераж</param>
        public void BrokerachInExcel(IMenu menu)
        {
            ExcelApp.Application.Workbooks.Add(Type.Missing);
           

            ExcelApp.Cells[1, 1] = "Дата, время изготовления продукта";
            ExcelApp.Columns[1].ColumnWidth = "12";

            ExcelApp.Cells[1, 2] = "Наименование продукции, блюда";
            ExcelApp.Columns[2].ColumnWidth = "33";

            ExcelApp.Cells[1, 3] = "Органолептическая оценка, ключая оценку степени готовности продукта";
            ExcelApp.Columns[3].ColumnWidth = "23";

            ExcelApp.Cells[1, 4] = "Разрешение к реализации (время)";
            ExcelApp.Columns[4].ColumnWidth = "14";

            ExcelApp.Cells[1, 5] = "Ответственный исполнитель    (Ф.И.О. должность)";
            ExcelApp.Columns[5].ColumnWidth = "17";

            ExcelApp.Cells[1, 6] = "Ф.И.О. лица, проводившего бракераж";
            ExcelApp.Columns[6].ColumnWidth = "12";

            ExcelApp.Cells[1, 7] = "Примечание";
            ExcelApp.Columns[7].ColumnWidth = "12";

            for (int i=1; i<8; i++)
            {
                ExcelApp.Cells[2, i] = i;
            }

            int x =3;
            foreach (Dish dish in menu.Dishs)
            {
                ExcelApp.Cells[x, 2] = dish.NameDish;
                x++;
            }
            ExcelApp.Range[ExcelApp.Cells[1, 1],ExcelApp.Cells[1,7]].WrapText = true;
            ExcelApp.Rows[1].RowHeight = "48";

            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[2, 7]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 7]].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[x-1, 7]].Font.Size = 10;
            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 7]].Font.Name = "Times New Roman";
            ExcelApp.Range[ExcelApp.Cells[2, 1], ExcelApp.Cells[x-1, 7]].Font.Name = "Arial";

            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[x - 1, 7]].Borders.ColorIndex = 1;
            ExcelApp.Visible = true;
        }        
    }
}