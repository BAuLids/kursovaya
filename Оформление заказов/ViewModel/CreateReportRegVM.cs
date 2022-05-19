using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Оформление_заказов.DTO;
using Оформление_заказов.MySQL;
using Оформление_заказов.Tool;
using Оформление_заказов.Pages;
using Spire.Xls;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace Оформление_заказов.ViewModel
{
     public class CreateReportRegVM : BaseVM
    {
        public cPage currentPageControl;
        public List<Reg> Reg { get; set; }
        public Reg SelectReg { get; set; }
        public List<User> User { get; set; }
        public User SelectUser { get; set; }
        public List<string> Months { get; set; }
        public string SelectMonths { get; set; }
        public Command CreateReport { get; set; }
        public int SelectYear { get; set; }
        public Command Back { get; set; }

        public CreateReportRegVM(cPage currentPageControl)
        {
            SelectYear = DateTime.Now.Year;
            var sql = SQLModel.GetInstance();
            User = sql.SelectUser();

            Months = new List<string>(new string[]
            {
                "Январь",
                "Февраль",
                "Март",
                "Апрель",
                "Май",
                "Июнь",
                "Июль",
                "Август",
                "Сентябрь",
                "Октябрь",
                "Ноябрь",
                "Декабрь"
            });

            CreateReport = new Command(() => 
            {
                if (SelectMonths == null)
                    return;
                Workbook wb = new Workbook();
                Worksheet sh = wb.Worksheets[0];
                sh.Range["C1:F1"].Merge();
                sh.Range["C1:F1"].HorizontalAlignment = HorizontalAlignType.Center;
                sh.Range["C1:F1"].Text = $"Заказы за {SelectMonths} {SelectYear}г.";
                sh.Range["A3"].Text = "№";
                sh.Range["A3"].HorizontalAlignment = HorizontalAlignType.Center;
                sh.Range["B3"].Text = "Номер заказа";
                sh.Range["B3"].HorizontalAlignment= HorizontalAlignType.Center;
                sh.Range["C2:D2"].Merge();
                sh.Range["C2:D2"].Text = "Покупатель";
                sh.Range["C2:D2"].HorizontalAlignment = HorizontalAlignType.Center;
                sh.Range["C3"].Text = "Фамилия";
                sh.Range["C3"].HorizontalAlignment = HorizontalAlignType.Center;
                sh.Range["D3"].Text = "Имя";
                sh.Range["D3"].HorizontalAlignment = HorizontalAlignType.Center;
                sh.Range["E3"].Text = "Дата заказа";
                sh.Range["E3"].HorizontalAlignment=HorizontalAlignType.Center;

                int nRow = 4, nCount = 1;
                List<User> SelectedUser = sql.SelectAllUsers();
                foreach(var user in SelectedUser)
                {
                    List<Reg> SelectedReg = sql.SelectAllReg(SelectYear, Months.IndexOf(SelectMonths) + 1);
                    foreach (var reg in SelectedReg)
                    {
                        sh.Range[$"A{nRow}"].NumberValue = nCount++;
                        sh.Range[$"B{nRow}"].Text = $"{reg.Nomer}";
                        sh.Range[$"C{nRow}"].Text = $"{user.LastName}";
                        sh.Range[$"D{nRow}"].Text = $"{user.Name}";
                        sh.Range[$"E{nRow}"].Text = $"{reg.Date}";
                        nRow++;
                    }
                    
                }
                CellRange range = sh.Range[$"A2:E{nRow}"];
                    range.BorderInside(LineStyleType.Thin, Color.Black);
                    range.BorderInside(LineStyleType.Medium, Color.Black);
                    nRow += 3;

                    sh.AllocatedRange.AutoFitColumns();
                    sh.AllocatedRange.AutoFitRows   ();
                    
                    var file = new FileStream("stream.xls", FileMode.Create);
                    wb.SaveToStream(file);
                    file.Close();
                    Process.Start("Explorer", Environment.CurrentDirectory + @"\stream.xls");
            });
            Init();
        }
        private void Init()
        {
            Back = new Command(() =>
            {
                currentPageControl.SetPage(new StartPage(new StartVM(currentPageControl)));
            });
        }
    }
}
