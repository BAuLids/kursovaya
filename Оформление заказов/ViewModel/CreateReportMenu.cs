using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.DTO;
using Оформление_заказов.MySQL;
using Оформление_заказов.Tool;
using Spire.Xls;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace Оформление_заказов.ViewModel
{
    class CreateReportMenu
    {
        public cPage currentPageControl;
        public  List<Types> Types { get; set; }
        public Types SelectType { get; set; }
        public Command Back { get; set; }
        public Command CreateReport { get; set; }

        public CreateReportMenu(cPage currentPageControl)
        {
            var sql = SQLModel.GetInstance();
            Types = sql.SelectAllType();

            CreateReport = new Command(() =>
            {
                if (SelectType == null)
                    return;
                Workbook wb = new Workbook();
                Worksheet sh = wb.Worksheets[0];
                sh.Range["B1:D1"].Merge();
                sh.Range["B1:D1"].HorizontalAlignment = HorizontalAlignType.Center;
                sh.Range["B1:D1"].Text = $"Все блюда с типом {SelectType} ";
                sh.Range["A2"].HorizontalAlignment = HorizontalAlignType.Center;
                sh.Range["A2"].Text = "№";
                sh.Range["B2"].HorizontalAlignment = HorizontalAlignType.Center;
                sh.Range["B2"].Text = "Наименование";
                sh.Range["C2"].HorizontalAlignment = HorizontalAlignType.Center;
                sh.Range["C2"].Text = "Описание";

                int nRow = 3, nCount = 1;
                List<Menu> MenuType = sql.SelectMenuType(SelectType);
                foreach (var menu in MenuType)
                {
                    List<Types> SelectType = sql.SelectAllType();
                    foreach (var type in SelectType)
                    {
                        sh.Range[$"A{nRow}"].NumberValue = nCount++;
                        sh.Range[$"B{nRow}"].Text = $"{menu.Title}";
                        sh.Range[$"C{nRow}"].Text = $"{menu.Description}";

                        nRow++;
                    }
                    CellRange range = sh.Range[$"A2:C{nRow}"];
                    range.BorderInside(LineStyleType.Thin, Color.Black);
                    range.BorderAround(LineStyleType.Medium, Color.Black);
                    nRow += 3;

                    sh.AllocatedRange.AutoFitColumns();
                   sh.AllocatedRange.AutoFitRows();

                    var file_stream = new FileStream("menu.xls", FileMode.Create);
                    wb.SaveToStream(file_stream);
                    file_stream.Close();

                    Process.Start("Explorer", Environment.CurrentDirectory + @"\menu.xls");
                }
            });
            Back = new Command(() =>
            {
                currentPageControl.Back();
            });
        }
    }
}
